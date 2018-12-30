<?php

class SessionService
{
    private $authService;

    /**
     * SessionService constructor.
     * @param AuthService $authService
     */
    public function __construct($authService)
    {
        $this->authService = $authService;
    }

    public function saveSession($email) {
        session_start();

        $token = $this->authService->createTokenForUser($email);
        $this->authService->insertToken($email, $token);

        $_SESSION['user'] = $email;
        $_SESSION['userId'] = $this->authService->getIdByEmail($email);

        // operatory arytmetyczne
        setcookie('token', $token, time() + (60 * 60 * 24), "/");
    }


}