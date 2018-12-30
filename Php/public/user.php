<?php
session_start();
$userId = $_SESSION['userId'];
$user = $_SESSION['user'];

/*
 * Witrynę należy wyposażyć w mechanizm umożliwiający zmianę i zapamiętanie jej wyglądu (krój i kolor czcionki, kolor tła itp.).
 *  Można np. przygotować kilka garniturów stylów, które użytkownik będzie mógł wybierać w zależności od swoich preferencji.
 * Preferencje użytkownika serwer ma przechowywać w ciastku. Na podstawie zapisanych w ciastku danych, serwer ma odpowiednio
 * modyfikować strony witryny i przesyłać je do przeglądarki*/

/*
 * Należy skorzystać z następujących elementów języka PHP:
funkcja setcookie() – inicjuje ciastko,
funkcja time() – podaje aktualny znacznik czasu (przydaje się do wyznaczani terminu
ważności ciastka),
tablica $_COOKIE – przechowuje wartości ciastek.

 * */

if (isset($_POST['theme'])) {
    setcookie('theme', $_POST['theme'], time() + (60 * 60 * 24), "/");
    $_COOKIE['theme'] = $_POST['theme'];
}

$theme = isset($_COOKIE['theme']) ? $_COOKIE['theme'] : 'LIGHT_THEME';

include_once dirname($_SERVER["DOCUMENT_ROOT"]) . '/src/main/header.template.php';
?>

<main class="under-nav">
    <form class="user-preferences-form" method="post" action="user">
        <section class="add-event-row-wrapper">
            <h5 class="add-event-row-title">Zaznacz preferencje stylu</h5>
            <div class="radio-wrapper">
                <input type="radio" name="theme" value="LIGHT_THEME" id="theme-light"
                    <?php echo $theme == "LIGHT_THEME" ? "checked" : "" ?>
                >
                <label for="theme-light">Styl dzienny</label>
            </div>
            <div class="radio-wrapper">
                <input type="radio" name="theme" value="DARK_THEME" id="theme-dark"
                    <?php echo $theme == "DARK_THEME" ? "checked" : "" ?>>
                <label for="theme-dark">Styl nocny</label>
            </div>
            <div class="radio-wrapper">
                <input type="radio" name="theme" value="BLUE_THEME" id="theme-blue"
                    <?php echo $theme == "BLUE_THEME" ? "checked" : "" ?>>
                <label for="theme-blue">Styl niebieski</label>
            </div>
        </section>

        <div class="user-preferences-buttons-wrapper">
            <button type="submit" class="add-event-form-button">Zapisz
            </button>
        </div>
    </form>

</main>


<?php
include_once dirname($_SERVER["DOCUMENT_ROOT"]) . '/src/main/footer.template.php';
?>

