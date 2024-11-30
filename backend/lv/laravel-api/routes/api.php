<?php

use Illuminate\Http\Request;
use Illuminate\Support\Facades\Route;
use App\Http\Controllers\AuthController;
use App\Http\Controllers\UserController;

Route::get('/user', function (Request $request) {
    return $request->user();
})->middleware('auth:sanctum');

Route::post('register', [AuthController::class, 'register']);
Route::post('login', [AuthController::class, 'login']);
Route::get('verify-email/{token}', [AuthController::class, 'verifyEmail']);
//Route::post('forgot-password', [AuthController::class, 'forgotPassword']);
Route::post('resend-verification', [AuthController::class, 'resendVerificationLink']);


Route::middleware('auth:api')->post('/logout', [UserController::class, 'logout']);

Route::middleware('auth:api')->get('/user', [UserController::class, 'getUserData']);




