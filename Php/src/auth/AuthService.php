<?php

// stałe
define('EMAIL_PATTERN', "/^[_a-z0-9-]+(\.[_a-z0-9-]+)*@[a-z0-9-]+(\.[a-z0-9-]+)*(\.[a-z]{2,})$/i");
class AuthService
{

    private $authDao;

    /**
     * AuthService constructor.
     * @param AuthDao $authDao
     */
    public function __construct($authDao)
    {
        //operatory przypisania
        $this->authDao = $authDao;
    }


    function createUser($username, $password) {
        $this->authDao->createUser($username, $password);
    }

    function loginUser($email, $password) {
        $username = $this->authDao->loginUser($email, $password);
        if ($username) {
            return $username;
        }
        else {
            throw new Exception("Invalid username or password");
        }
    }

    function createTokenForUser($username) {
        return md5(uniqid($username, true));
    }

    function insertToken($username, $token) {
        $this->authDao->insertToken($username, $token);
    }

    function getIdByEmail($email) {
        return $this->authDao->getIdByEmail($email);
    }

    /**
     * @param String $email
     * @param String $password
     * @param String $confirm
     * @return String[] errors
     */
    function validateRegistration($email, $password, $confirm) {
        $errors = [];

        if (empty($email) || empty($password) || empty($confirm)) {
            $errors[] = "Brak danych";
            return $errors;
        }

        if (!preg_match(EMAIL_PATTERN, $email)) {
            $errors[] = "Niepoprawny email";
        }

        if ($this->authDao->emailExists($email)) {
            $errors[] = "Istnieje już taki użytkownik";
        }

        if ($password != $confirm) {
            $errors[] = "Hasła się nie zgadzają";
        }

        return $errors;
    }

}