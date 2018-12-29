<?php

class AuthDao
{
    private $connection;

    public function __construct()
    {
        include_once dirname($_SERVER["DOCUMENT_ROOT"]) . '/src/config/dbConfig.php';

        $this->connection = createDatabaseConnection();
    }

    public function createUser($email, $password)
    {
        $hash = password_hash($password, PASSWORD_BCRYPT);

        $statement = $this->connection->prepare("INSERT INTO users(email, password, role) VALUES (?, ?, 'USER')");
        $statement->bind_param('ss', $email, $hash);

        $statement->execute() or die(mysqli_error($this->connection));
    }

    public function getIdByEmail($email) {
        $statement = $this->connection->prepare("SELECT id FROM users WHERE email = ?");
        $statement->bind_param('s', $email);
        $statement->execute() or die(mysqli_error($this->connection));

        $row = $statement->get_result()->fetch_row();
        return $row[0];
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

    public function emailExists($email) {
        $statement = $this->connection->prepare("SELECT COUNT(*) FROM users WHERE email = ?");
        $statement->bind_param('s', $email);
        $statement->execute() or die(mysqli_error($this->connection));

        $row = $statement->get_result()->fetch_row();
        return $row[0] > 0;
    }
}