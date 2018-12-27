<?php

if (isset($_POST['email']) && isset($_POST['password'])) {
    include_once dirname($_SERVER["DOCUMENT_ROOT"]) . '/src/auth/AuthService.php';
    include_once dirname($_SERVER["DOCUMENT_ROOT"]) . '/src/auth/AuthDao.php';
    include_once dirname($_SERVER["DOCUMENT_ROOT"]) . '/src/auth/SessionService.php';

    $authService = new AuthService(new AuthDao());
    $sessionService = new SessionService($authService);

    try {
        $user = $authService->loginUser($_POST['email'], $_POST['password']);
        $sessionService->saveSession($user);

        header("Location: /index");
        die();

    } catch (Exception $e) {
        $error = "Invalid username or password";
    }
}