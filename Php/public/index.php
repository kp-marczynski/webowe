<?php
session_start();

$user = $_SESSION['user'];
?>

<html lang="pl">
<head>
    <link href="index.css" rel="stylesheet"/>
    <title>Sklep muzyczny</title>
</head>
<body>
<h1>Połączyłeś się z serwerem, brawo ty!</h1>


<?php
if (isset($user)) {
    echo "Zalogowany jako $user";
} else {
    echo "Niezalgoowany";
}

?>
</body>
</html>