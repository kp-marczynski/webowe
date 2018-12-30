<?php

/**
 * @return mysqli
 */
function createDatabaseConnection() {
    $DB_HOST = getenv('DB_HOST');
    $DB_DATABASE = getenv('DB_DATABASE');
    $DB_USER = getenv('DB_USER');
    $DB_PASSWORD_NAME = "DB_PASSWORD";
//    zmienna nazwa zmiennej ($$zmienna).
    $$DB_PASSWORD_NAME = getenv('DB_PASSWORD');

//    mysqli_connect
    $connection =  mysqli_connect($DB_HOST, $DB_USER, $DB_PASSWORD, $DB_DATABASE) or die("Cannot connect to db");
    $connection->set_charset("utf8mb4");
    return $connection;
}