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
        $hash = password_hash($password, PASSWORD_BCRYPT);

        $statement = $this->connection->prepare("INSERT INTO users(email, password, role) VALUES (?, ?, 'USER')");
        $statement->bind_param('ss', $email, $hash);

        $statement->execute() or die(mysqli_error($this->connection));
    }


    public function loginUser($email, $password) {
        $statement = $this->connection->prepare("SELECT email, password FROM users WHERE email = ?");
        $statement->bind_param('s', $email);

        $statement->execute() or die(mysqli_error($this->connection));

        $result = $statement->get_result();

        if (!$row = $result->fetch_row()) {
            return null;
        }

        $username = $row[0];
        $password_hash = $row[1];

        if (!password_verify($password, $password_hash)) {
            return null;
        }

        return $username;
    }

    public function insertToken($email, $token) {
        $statement = $this->connection->prepare("UPDATE users SET token = ? WHERE email = ?");
        $statement->bind_param('ss', $token, $email);

        $statement->execute() or die(mysqli_error($this->connection));
    }
}