<?php
include_once dirname($_SERVER["DOCUMENT_ROOT"]) . '/src/auth/LoginController.php';
?>

<?php
include dirname($_SERVER["DOCUMENT_ROOT"]) . '/src/auth/auth-header.template.php';
?>

    <article class="auth-form-page">

        <form class="auth-form-wrapper" method="post" action="login">
            <?php

            if (isset($error)) {
                echo "<div class='auth-form-error'>
                $error;
            </div>";
            }
            ?>

            <div class="auth-form-input-wrapper">
                <input
                        name="email"
                        type="email"
                        class="auth-form-input"
                        placeholder="Podaj swój email">

                <input
                        name="password"
                        type="password"
                        class="auth-form-input"
                        placeholder="Podaj swoje hasło">
            </div>

            <button type="submit" class="auth-form-button">Zaloguj się</button>

            <a href="register" class="auth-toggle-link">Jesteś nowy? Stwórz konto!</a>

        </form>
    </article>

<?php
include dirname($_SERVER["DOCUMENT_ROOT"]) . '/src/auth/auth-footer.template.php';
?>