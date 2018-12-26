<?php
include('../../src/auth/RegisterController.php');
?>


<?php
include('../../src/auth/auth-header.template.php')
?>
    <article class="auth-form-page">

        <form class="auth-form-wrapper" method="post" action="register">

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

        </form>
    </article>


<?php
include('../../src/auth/auth-footer.template.php')
?>