<?php

class AuthDao
{
    private $connection;

    public function __construct()
    {
        include('../../src/config/dbCredentials.php');
        $this->connection = mysqli_connect($DB_HOST, $DB_USER, $DB_PASSWORD, $DB_DATABASE) or die("Cannot connect to db");
    }

    public function createUser($email, $password)
    {
        $escaped_email = mysqli_real_escape_string($this->connection, $email);
        $escaped_password = mysqli_real_escape_string($this->connection, $password);

        $hash = password_hash($escaped_password, PASSWORD_BCRYPT);

        $statement = $this->connection->prepare("INSERT INTO users(email, password, role) VALUES (?, ?, 'USER')");
        $statement->bind_param('ss', $escaped_email, $hash);

        $statement->execute() or die(mysqli_error($this->connection));
    }
}