<?php
include_once dirname($_SERVER["DOCUMENT_ROOT"]) . '/src/auth/RegisterController.php';
?>


<?php
include dirname($_SERVER["DOCUMENT_ROOT"]) . '/src/auth/auth-header.template.php';
?>
    <article class="auth-form-page">

        <form class="auth-form-card" method="post" action="register">


            <div class="auth-form-image-wrapper">
                <h2 class="auth-form-image-title">Nie przegap żadnego wydarzenia</h2>
                <img src="/res/images/auth-image.svg" class="auth-form-image">
            </div>


            <div class="auth-form-wrapper">

                <?php

                if (isset($error)) {
                    echo "<div class='auth-form-error'>
                $error
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

                    <input
                            name="confirm-password"
                            type="password"
                            class="auth-form-input"
                            placeholder="Potwierdź swoje hasło">
                </div>

                <button type="submit" class="auth-form-button">Stwórz konto</button>
                <a href="login" class="auth-toggle-link">Masz już konto? Zaloguj się</a>
            </div>

        </form>
    </article>


<?php
include dirname($_SERVER["DOCUMENT_ROOT"]) . '/src/auth/auth-footer.template.php';
?>