<?php

if (isset($_POST['email']) && isset($_POST['password']) && isset($_POST['confirm-password'])) {

    include_once dirname($_SERVER["DOCUMENT_ROOT"]) . '/src/auth/AuthService.php';
    include_once dirname($_SERVER["DOCUMENT_ROOT"]) . '/src/auth/AuthDao.php';

    $service = new AuthService(new AuthDao());

    $service->createUser($_POST['email'], $_POST['password']);

    header("Location: /index");
    die();
}