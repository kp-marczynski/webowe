<?php

if (isset($_POST['email']) && isset($_POST['password'])) {
    include('../../src/auth/AuthService.php');
    include('../../src/auth/AuthDao.php');

    $service = new AuthService(new AuthDao());

    try {
        session_start();

        $user = $service->loginUser($_POST['email'], $_POST['password']);
        $_SESSION['user'] = $user;

        header("Location: /index");
        die();

    } catch (Exception $e) {
        $error = "Invalid username or password";
    }
}