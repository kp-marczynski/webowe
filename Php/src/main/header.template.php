<?php
include_once dirname($_SERVER["DOCUMENT_ROOT"]) . '/src/cart/CartService.php';
include_once dirname($_SERVER["DOCUMENT_ROOT"]) . '/src/auth/ProtectedResourcesGuard.php';
session_start();
ProtectedResourcesGuard::verifyAccess();

$user = $_SESSION['user'];

$eventsInCart = CartService::countEventsInCart();
if ($eventsInCart > 0) {
    $eventsInCartToDisplay = $eventsInCart;
}
?>

<html lang="pl">
<head>
    <link href="/shared/styles/index.css" rel="stylesheet"/>
    <link href="/shared/styles/utils.css" rel="stylesheet"/>
    <link href="/shared/styles/header.css" rel="stylesheet"/>
    <link href="/res/styles/events.css" rel="stylesheet"/>
    <link href="/shared/styles/add-event.css" rel="stylesheet"/>
    <link href="/res/styles/landing.css" rel="stylesheet"/>
    <link href="/res/styles/user.css" rel="stylesheet"/>
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
                    <img src="/shared/images/logo.svg"/>
                    <p>Muzyka4zycie</p>
                </a>
            </li>
            <li class="menu-item" <?php echo isset($user) ? '' : 'style="visibility: hidden"' ?>>
                <a href="/events">Wydarzenia</a>
            </li>
            <li class="menu-item" <?php echo isset($user) ? '' : 'style="visibility: hidden"' ?>>
                <a href=<?php echo $_ENV['SHOP_URL_FRONT'] ?>>
                <span class="cart-items"
                      id="cart-items" <?php echo isset($eventsInCartToDisplay) ? "" : "style='display: none'" ?>><?php echo $eventsInCartToDisplay ?></span>
                    Koszyk</a>
            </li>
            <li class="menu-item" <?php echo isset($user) ? '' : 'style="visibility: hidden"' ?>>
                <a href=<?php echo $_ENV['SHOP_URL_FRONT']."/order-history" ?>>
                    Zamówienia</a>
            </li>
        </ul>

        <ul class="right-menu">
            <?php
            if (isset($user)) {
                echo "<li class='menu-item'><a href='user'>$user</a></li><li class='menu-item'><a href='auth/logout'>Wyloguj</a></li>";
            } else {
                echo "<li class='menu-item'><a href='auth/register'>Rejestracja</a></li><li class='menu-item'><a href='auth/login'>Logowanie</a></li>";
            }
            ?>
        </ul>
    </nav>
</header>

