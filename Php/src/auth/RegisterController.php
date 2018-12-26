<?php

if (isset($_POST['email']) && isset($_POST['password']) && isset($_POST['confirm-password'])) {

    include('../../src/auth/AuthService.php');
    include('../../src/auth/AuthDao.php');

    $service = new AuthService(new AuthDao());

    $service->createUser($_POST['email'], $_POST['password']);

    header("Location: /index");
    die();
}