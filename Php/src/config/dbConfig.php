<?php

/**
 * @return mysqli
 */
function createDatabaseConnection() {
    $DB_HOST = getenv('DB_HOST');
    $DB_DATABASE = getenv('DB_DATABASE');
    $DB_USER = getenv('DB_USER');
    $DB_PASSWORD = getenv('DB_PASSWORD');

    $connection =  mysqli_connect($DB_HOST, $DB_USER, $DB_PASSWORD, $DB_DATABASE) or die("Cannot connect to db");
    $connection->set_charset("utf8mb4");
    return $connection;
}