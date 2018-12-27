<?php

if (isset($_POST['email']) && isset($_POST['password']) && isset($_POST['confirm-password'])) {

    include_once dirname($_SERVER["DOCUMENT_ROOT"]) . '/src/auth/AuthService.php';
    include_once dirname($_SERVER["DOCUMENT_ROOT"]) . '/src/auth/AuthDao.php';
    include_once dirname($_SERVER["DOCUMENT_ROOT"]) . '/src/auth/SessionService.php';

    $authService = new AuthService(new AuthDao());
    $sessionService = new SessionService($authService);

    $email = trim($_POST['email']);
    $password = trim($_POST['password']);
    $confirmPassword = trim($_POST['confirm-password']);

    $errors = $authService->validateRegistration($email, $password, $confirmPassword);

    if (!empty($errors)) {
        $error = implode("|", $errors);
    } else {
        $authService->createUser($email, $password);
        $sessionService->saveSession($email);

        header("Location: /auth/register?success=true");
        die();
    }
}