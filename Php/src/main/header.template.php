<?php
session_start();

$user = $_SESSION['user'];
?>

<html lang="pl">
<head>
    <link href="index.css" rel="stylesheet"/>
    <title>Muzyka4zycie</title>
</head>
<body>

<header>
    <nav>
        <ul>
            <li>
                <a href="/">
                    Home
                </a>
            </li>
            <li>
                <a href="#">Strona główna</a>
            </li>
            <li>
                <a href="auth/login">Logowanie</a>
            </li>
        </ul>
    </nav>
</header>

