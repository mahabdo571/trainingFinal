<?php

namespace App\Http\Controllers;

use Illuminate\Http\Request;
use App\Models\User;
use Illuminate\Support\Facades\Auth;
use Illuminate\Support\Facades\Hash;
use Illuminate\Support\Facades\Mail;
use App\Mail\VerifyEmail;
use App\Mail\ResetPasswordEmail;
use Lcobucci\JWT\Token;

class AuthController extends Controller
{
    // تسجيل مستخدم جديد
    public function register(Request $request)
    {
        $validated = $request->validate([
            'name' => 'required',
            'email' => 'required|email|unique:users,email',
            'password' => 'required|min:6',
        ]);

        $user = User::create([
            'name' => $validated['name'],
            'email' => $validated['email'],
            'password' => Hash::make($validated['password']),
        ]);

        // إرسال بريد للتحقق
        Mail::to($user->email)->send(new VerifyEmail($user));

        return response()->json(['message' => 'تم التسجيل بنجاح. يرجى التحقق من بريدك الإلكتروني.']);
    }

    // تسجيل الدخول
    public function login(Request $request)
    {
        $credentials = $request->only('email', 'password');

        if (!$token = Auth::attempt($credentials)) {
            return response()->json(['error' => 'بيانات الدخول غير صحيحة.'], 401);
        }

        return response()->json([[
            "status" => true,
            "message" => "User logged in succcessfully",
            "token" => $token,

        ]]);
    }

    // التحقق من البريد
    public function verifyEmail($token)
    {
        $user = User::where('email_verification_token', $token)->first();

        if (!$user) {
            return response()->json(['message' => 'رمز التحقق غير صالح.'], 400);
        }

        $user->update(['email_verified' => true]);

        return response()->json(['message' => 'تم التحقق من البريد الإلكتروني.']);
    }

    // استعادة كلمة المرور
    public function forgotPassword(Request $request)
    {
        $validated = $request->validate(['email' => 'required|email']);

        $user = User::where('email', $validated['email'])->first();

        if (!$user) {
            return response()->json(['message' => 'المستخدم غير موجود.'], 404);
        }

        // إرسال بريد لاستعادة كلمة المرور
        Mail::to($user->email)->send(new ResetPasswordEmail($user));

        return response()->json(['message' => 'تم إرسال رابط استعادة كلمة المرور.']);
    }

    public function resendVerificationLink(Request $request)
    {
        // التحقق من البريد الإلكتروني الذي أرسله المستخدم
        $user = User::where('email', $request->email)->first();

        // التأكد من وجود المستخدم
        if (!$user) {
            return response()->json(['error' => 'المستخدم غير موجود.'], 404);
        }

        // التأكد من أن البريد الإلكتروني غير مفعل
        if ($user->hasVerifiedEmail()) {
            return response()->json(['message' => 'تم تفعيل حسابك مسبقًا.'], 400);
        }

        // إرسال رابط التفعيل عبر البريد الإلكتروني
        Mail::to($user->email)->send(new VerifyEmail($user));

        return response()->json(['message' => 'تم إرسال رابط التفعيل إلى بريدك الإلكتروني.']);
    }

    
}
