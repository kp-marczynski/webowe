<html lang="pl">
<head>
    <link href="index.css" rel="stylesheet"/>
    <title>Sklep muzyczny</title>
</head>
<body>
<h1>Połączyłeś się z serwerem, brawo ty!</h1>


<?php

echo "Elo";
include('../src/config/dbCredentials.php');

$conn = mysqli_connect($DB_HOST, $DB_USER, $DB_PASSWORD, $DB_DATABASE);

?>
</body>
</html>