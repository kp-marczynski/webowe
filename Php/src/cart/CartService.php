<?php

class CartService
{

    static function countEventsInCart() {
        session_start();

        $existingEvents = $_COOKIE['items-in-cart'];

        return isset($existingEvents) ? sizeof(json_decode($existingEvents, true)) : 0;
    }


    function addEventToCart($eventId) {
        session_start();

        $existingEvents = $_COOKIE['items-in-cart'];
        $updatedEvents = [];

        if (isset($existingEvents)) {
            $updatedEvents = json_decode($existingEvents, true);
            $updatedEvents[] = $eventId;
        } else {
            $updatedEvents[] = $eventId;
        }

        setcookie('items-in-cart', json_encode($updatedEvents), time() + (60 * 60 * 24 * 30), "/");
    }

}