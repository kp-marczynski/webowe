<?php

class ProtectedResourcesGuard
{

    /*
     *  funkcja session_start() – inicjuje mechanizm sesji,
        tablica $_SESSION – przechowuje wartości zmiennych sesji,
        funkcja isset($_SESSION[’zmienna’]) – sprawdza status zmiennej sesji.
     * */

    public static function verifyAccess()
    {
        session_start();

        $user = $_SESSION['user'];
        $url = $_SERVER['SERVER_NAME'] . $_SERVER['REQUEST_URI'];
        $restrictedUrls = ['events', 'create-event', 'user'];

        $isRestrictedUrl = !empty(array_filter($restrictedUrls, function ($restrictedUrl) use ($url) {
            return strpos($url, $restrictedUrl) !== false;
        }));

        if ($isRestrictedUrl && !isset($user)) {
            header('Location: /auth/login');
            die();
        }
    }

}