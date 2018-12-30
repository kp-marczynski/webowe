<?php

session_start();
session_unset();
session_destroy();


//foreach
foreach ( $_COOKIE as $key => $value )
{
    setcookie( $key, '', 1, '/');
}

header("Location: /auth/login.php");
exit();