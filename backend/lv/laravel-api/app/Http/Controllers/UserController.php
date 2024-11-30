<?php

namespace App\Http\Controllers;

use Illuminate\Http\Request;
use Tymon\JWTAuth\Facades\JWTAuth;

class UserController extends Controller
{
    public function getUserData(Request $request)
    {

        $user = JWTAuth::user();


        return response()->json([
            'status' => true,
            'message' => 'تم جلب بيانات المستخدم بنجاح',
            'data' => $user
        ]);
    }

    public function logout(Request $request)
    {

        try {
          
            JWTAuth::invalidate(JWTAuth::getToken());

            return response()->json([
                'status' => true,
                'message' => 'تم تسجيل الخروج بنجاح'
            ]);
        } catch (\Exception $e) {
            return response()->json([
                'status' => false,
                'message' => 'حدث خطأ أثناء تسجيل الخروج'
            ], 500);
        }
    }
}
