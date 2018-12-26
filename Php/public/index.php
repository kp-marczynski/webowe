<?php
include_once '../src/main/header.template.php';


if (isset($user)) {
    echo "Zalogowany jako $user";
} else {
    echo "Niezalgoowany";
}

include_once '../src/main/header.template.php';

?>

<h1>Połączyłeś się z serwerem, brawo ty!</h1>