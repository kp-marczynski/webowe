<?php

class AuthService
{

    private $authDao;

    public function __construct($authDao)
    {
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

}