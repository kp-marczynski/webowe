<?php

if (isset($_POST['email']) && isset($_POST['password']) && isset($_POST['confirm-password'])) {

    include_once dirname($_SERVER["DOCUMENT_ROOT"]) . '/src/auth/AuthService.php';
    include_once dirname($_SERVER["DOCUMENT_ROOT"]) . '/src/auth/AuthDao.php';

    $service = new AuthService(new AuthDao());

    $email = trim($_POST['email']);
    $password = trim($_POST['password']);
    $confirmPassword = trim($_POST['confirm-password']);

    $errors = $service->validateRegistration($email, $password, $confirmPassword);

    if (!empty($errors)) {
        $error = implode("|", $errors);
    } else {
        $service->createUser($email, $password);

        header("Location: /auth/register?success=true");
        die();
    }
}