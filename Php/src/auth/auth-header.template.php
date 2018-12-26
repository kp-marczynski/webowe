<?php
switch ($_SERVER["SCRIPT_NAME"]) {
    case "/auth/login.php":
        $PAGE_TITLE = "Sklep muzyczny | Logowanie";
        break;
    case "/auth/register.php":
        $PAGE_TITLE = "Sklep muzyczny | Rejestracja";
        break;
    default:
        $PAGE_TITLE = "Sklep muzyczny";
}
?>

<html lang="pl">
<head>
    <link href="/index.css" rel="stylesheet"/>
    <link href="/auth/auth.css" rel="stylesheet"/>
    <title><?php echo $PAGE_TITLE ?></title>
    <meta name="viewport" content="width=device-width, initial-scale=1">
</head>
<body>
