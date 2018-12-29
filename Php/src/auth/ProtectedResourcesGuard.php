<?php

class ProtectedResourcesGuard
{


    public static function verifyAccess() {
        session_start();

        $user = $_SESSION['user'];
        $url = $_SERVER['SERVER_NAME'] . $_SERVER['REQUEST_URI'];
        $restrictedUrls = ['events', 'create-event'];

        $isRestrictedUrl = !empty(array_filter($restrictedUrls, function ($restrictedUrl) use ($url) {
            return strpos($url, $restrictedUrl) !== false;
        }));

        if ($isRestrictedUrl && !isset($user)) {
            header('Location: /auth/login');
            die();
        }
    }

}