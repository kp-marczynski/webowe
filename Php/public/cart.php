<?php


if (isset($_POST['eventId'])) {
    include_once dirname($_SERVER["DOCUMENT_ROOT"]) . '/src/cart/CartService.php';
    $cartService = new CartService();

    $cartService->addEventToCart($_POST['eventId']);

    echo "{added: true}";
}
