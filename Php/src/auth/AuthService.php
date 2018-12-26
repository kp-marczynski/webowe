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

}