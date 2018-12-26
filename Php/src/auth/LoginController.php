<?php

if (isset($_POST['email']) && isset($_POST['password'])) {
    include_once dirname($_SERVER["DOCUMENT_ROOT"]) . '/src/auth/AuthService.php';
    include_once dirname($_SERVER["DOCUMENT_ROOT"]) . '/src/auth/AuthDao.php';

    $service = new AuthService(new AuthDao());

    try {
        session_start();

        $user = $service->loginUser($_POST['email'], $_POST['password']);
        $token = $service->createTokenForUser($user);
        $service->insertToken($user, $token);

        $_SESSION['user'] = $user;
        setcookie('token', $token, time() + (60 * 60 * 24), "/");

        header("Location: /index");
        die();

    } catch (Exception $e) {
        $error = "Invalid username or password";
    }
}