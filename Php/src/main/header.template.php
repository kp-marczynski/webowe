<?php
session_start();

$user = $_SESSION['user'];
?>

<html lang="pl">
<head>
    <link href="index.css" rel="stylesheet"/>
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <title>Muzyka4zycie</title>
</head>
<body>

<header>
    <nav>
        <ul class="left-menu">
            <li>
                <a href="/">
                    Strina główna
                </a>
            </li>
            <li>
                <a href="#">Wydarzenia</a>
            </li>
            <li>
                <a href="#">Koszyk</a>
            </li>
        </ul>

        <ul class="right-menu">
            <?php
                if (isset($user)) {
                    echo "<li>Witaj, $user</li><li><a href='auth/logout'>Wyloguj</a></li>";
                } else {
                    echo "<li><a href='auth/register'>Rejestracja</a></li><li><a href='auth/login'>Logowanie</a></li>";
                }
            ?>
        </ul>
    </nav>
</header>

