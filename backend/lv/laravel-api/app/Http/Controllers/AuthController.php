<?php

namespace App\Http\Controllers;

use App\Mail\EmailVerified;
use Illuminate\Http\Request;
use App\Models\User;
use Illuminate\Support\Facades\Auth;
use Illuminate\Support\Facades\Hash;
use Illuminate\Support\Facades\Mail;
use App\Mail\VerifyEmail;
use App\Mail\ResetPasswordEmail;
use Illuminate\Support\Str;
use Carbon\Carbon;
use Tymon\JWTAuth\Facades\JWTAuth;

use function Laravel\Prompts\error;

class AuthController extends Controller
{

    public function register(Request $request)
    {
        $validated = $request->validate([
            'name' => 'required',
            'email' => 'required|email|unique:users,email',
            'password' => 'required|min:6|confirmed',
        ]);



        $user = User::create([
            'name' => $validated['name'],
            'email' => $validated['email'],
            'password' => bcrypt($validated['password']),
            'email_verification_token' => Str::random(32),

        ]);


        Mail::to($user->email)->send(new VerifyEmail($user));

        return response()->json(['message' => 'تم التسجيل بنجاح. يرجى التحقق من بريدك الإلكتروني.']);
    }


    public function login(Request $request)
    {

        $user = User::where('email', $request->email)->first();


        if ($user && is_null($user->email_verified_at)) {
            return response()->json(['message' => 'الحساب غير مفعل. يرجى التحقق من بريدك الإلكتروني.'], 401);
        }

        $credentials = $request->only('email', 'password');
        if (!$token = JWTAuth::attempt($credentials)) {
            return response()->json(['error' => 'بيانات الدخول غير صحيحة.'], 401);
        }
        // if (!$token = Auth::attempt($credentials)) {
        //     return response()->json(['error' => 'بيانات الدخول غير صحيحة.'], 401);
        // }

        return response()->json([[
            "message" =>"تم تسجيل الدخول بنجاح",
            "token_type" => 'Bearer',
            "expires_in" => JWTAuth::factory()->getTTL() * 60,
            "token" => $token,
            "user" => JWTAuth::user(),

        ]]);
    }


    public function verifyEmail($token)
    {
        $user = User::where('email_verification_token', $token)
            ->where('email_verified_at', null)
            ->first();

        if (!$user) {
            return response()->json(['message' => 'رمز التحقق غير صالح.'], 400);
        }

        $user->update(['email_verified_at' => Carbon::now()]);

        Mail::to($user->email)->send(new EmailVerified($user));


        return response()->json(['message' => 'تم التحقق من البريد الإلكتروني.']);
    }


    // public function forgotPassword(Request $request)
    // {
    //     $validated = $request->validate(['email' => 'required|email']);

    //     $user = User::where('email', $validated['email'])->first();

    //     if (!$user) {
    //         return response()->json(['message' => 'المستخدم غير موجود.'], 404);
    //     }


    //     Mail::to($user->email)->send(new ResetPasswordEmail($user));

    //     return response()->json(['message' => 'تم إرسال رابط استعادة كلمة المرور.']);
    // }

    public function resendVerificationLink(Request $request)
    {

        $user = User::where('email', $request->email)->first();


        if (!$user) {
            return response()->json(['error' => 'المستخدم غير موجود.'], 404);
        }

        if ($user->hasVerifiedEmail()) {
            return response()->json(['message' => 'تم تفعيل حسابك مسبقًا.'], 400);
        }

        Mail::to($user->email)->send(new VerifyEmail($user));

        return response()->json(['message' => 'تم إرسال رابط التفعيل إلى بريدك الإلكتروني.']);
    }
}
