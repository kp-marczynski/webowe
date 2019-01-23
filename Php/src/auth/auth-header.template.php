<?php
switch ($_SERVER["SCRIPT_NAME"]) {
    case "/auth/login.php":
        $PAGE_TITLE = "Muzyka4zycie | Logowanie";
        break;
    case "/auth/register.php":
        $PAGE_TITLE = "Muzyka4zycie | Rejestracja";
        break;
    default:
        $PAGE_TITLE = "Muzyka4zycie";
}
?>

<html lang="pl">
<head>
    <link href="/shared/styles/index.css" rel="stylesheet"/>
    <link href="/res/styles/auth.css" rel="stylesheet"/>
    <link rel="icon" href="/shared/images/favicon.ico" type="image/x-icon"/>
    <title><?php echo $PAGE_TITLE ?></title>
    <meta name="viewport" content="width=device-width, initial-scale=1">
</head>
<body>
