<?php
session_start();
$user = $_SESSION['user'];

$url = $_SERVER['SERVER_NAME'] . $_SERVER['REQUEST_URI'];

$restrictedUrls = ['events'];

$isRestrictedUrl = !empty(array_filter($restrictedUrls, function ($restrictedUrl) use($url) {
    return strpos($url, $restrictedUrl) !== false;
}));

if ($isRestrictedUrl && !isset($user)) {
    header('Location: /auth/login');
    die();
}


?>

<html lang="pl">
<head>
    <link href="/styles/index.css" rel="stylesheet"/>
    <link href="/styles/header.css" rel="stylesheet"/>
    <link href="/styles/events.css" rel="stylesheet"/>
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <link rel="icon" href="/res/images/favicon.ico" type="image/x-icon"/>
    <link href="https://fonts.googleapis.com/icon?family=Material+Icons" rel="stylesheet">
    <link href="https://fonts.googleapis.com/css?family=Charm" rel="stylesheet">
    <title>Muzyka4zycie</title>
</head>
<body>

<header>
    <span class="top-right-button closed" id="remove-navbar-button" onclick="closeNav()">
        <i class="material-icons">close</i>
    </span>

    <span class="top-right-button" id="open-navbar-button" onclick="openNav()">
        <i class="material-icons">menu</i>
    </span>

    <nav class="nav-bar closed" id="nav-bar">
        <ul class="left-menu">
            <li class="menu-item">
                <a href="/" class="logo">
                    <img src="/res/images/logo.svg"/>
                    <p>Muzyka4zycie</p>
                </a>
            </li>
            <li class="menu-item" <?php echo isset($user) ? '' : 'style="visibility: hidden"'?>>
                <a href="/events">Wydarzenia</a>
            </li>
            <li class="menu-item" <?php echo isset($user) ? '' : 'style="visibility: hidden"'?>>
                <a href=<?php echo $_ENV['SHOP_URL_FRONT']?>>
                    Koszyk</a>
            </li>
        </ul>

        <ul class="right-menu">
            <?php
            if (isset($user)) {
                echo "<li class='menu-hello menu-item noselect'>Witaj, $user</li><li class='menu-item'><a href='auth/logout'>Wyloguj</a></li>";
            } else {
                echo "<li class='menu-item'><a href='auth/register'>Rejestracja</a></li><li class='menu-item'><a href='auth/login'>Logowanie</a></li>";
            }
            ?>
        </ul>
    </nav>
</header>

