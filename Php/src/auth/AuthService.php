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

}