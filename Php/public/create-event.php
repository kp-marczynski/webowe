<?php
session_start();

include_once dirname($_SERVER["DOCUMENT_ROOT"]) . '/src/events/EventsController.php';
$controller = new EventsController();

if ($_SERVER['REQUEST_METHOD'] === 'POST') {
    $userId = $_SESSION['userId'];

    $controller->createFromPost($_POST, $userId);
    header("Location: /events");
    die();
}
?>

<?php
include_once dirname($_SERVER["DOCUMENT_ROOT"]) . '/src/main/header.template.php';
?>


<main class="under-nav">

    <form class="add-event-form" action="create-event.php" method="post">
        <h2 class="add-event-title">Dodaj nowe wydarzenie</h2>

        <div class="add-event-image-wrapper">
            <h5 class="add-event-image-title">Dodaj zdjęcie</h5>
            <img class="add-event-image"
                 id="add-event-image"
                 onerror="alert('Nie można załadować zdjęcia')"
                 src="/res/images/placeholder.png">

            <div class="add-event-row-wrapper">
                <label class="add-event-input-label" for="event-image-url">
                    Wklej adres zdjęcia
                </label>

                <div class="add-event-img-input-wrapper">
                    <i class="material-icons add-event-input-img">cloud_queue</i>
                    <input
                            name="event-image-url"
                            id="event-image-url"
                            type="url"
                            class="add-event-form-input"
                            placeholder="URL">
                </div>
            </div>

            <section class="add-event-row-wrapper">
                <h5 class="add-event-row-title">Zaznacz dodatkowe informacje o wydarzeniu</h5>
                <label class="checkbox-wrapper">
                    <input type="checkbox" name="additional-info[]" value="DOGS">
                    <span>Można przyjść ze zwierzętami</span>
                </label>
                <label class="checkbox-wrapper">
                    <input type="checkbox" name="additional-info[]" value="DANGER">
                    <span>Impreza o podwyższonym ryzyku</span>
                </label>
                <label class="checkbox-wrapper">
                    <input type="checkbox" name="additional-info[]" value="VIP">
                    <span>Wydzielona strefa dla VIPów</span>
                </label>
                <label class="checkbox-wrapper">
                    <input type="checkbox" name="additional-info[]" value="ALCOHOL">
                    <span>Możliwy zakup alkoholu</span>
                </label>
            </section>

            <section class="add-event-row-wrapper">
                <h5 class="add-event-row-title">Zaznacz przedział wiekowy</h5>
                <div class="radio-wrapper">
                    <input type="radio" name="age" value="ALL" id="add-event-radio-all" checked>
                    <label for="add-event-radio-all">Impreza dozwolona dla wszystkich</label>
                </div>
                <div class="radio-wrapper">
                    <input type="radio" name="age" value="ADULTS" id="add-event-radio-adults">
                    <label for="add-event-radio-adults">Tylko dla dorosłych</label>
                </div>
            </section>

        </div>

        <div class="add-event-all-inputs">

            <div class="add-event-row-wrapper">
                <label class="add-event-input-label" for="event-name">
                    Nazwa wydarzenia
                </label>

                <div class="add-event-img-input-wrapper">
                    <i class="material-icons add-event-input-img">star</i>
                    <input
                            name="event-name"
                            id="event-name"
                            type="text"
                            class="add-event-form-input"
                            placeholder="Nazwa">
                </div>
            </div>

            <div class="add-event-row-wrapper">
                <label class="add-event-input-label" for="event-date">
                    Data wydarzenia
                </label>

                <div class="add-event-img-input-wrapper">
                    <i class="material-icons add-event-input-img">date_range</i>
                    <input
                            name="event-date"
                            id="event-date"
                            type="date"
                            class="add-event-form-input"
                            placeholder="Data">
                </div>
            </div>

            <div class="add-event-row-wrapper">
                <label class="add-event-input-label" for="event-price">
                    Cena
                </label>

                <div class="add-event-img-input-wrapper">
                    <i class="material-icons add-event-input-img">attach_money</i>
                    <input
                            name="event-price"
                            id="event-price"
                            type="number"
                            class="add-event-form-input"
                            placeholder="Cena"
                            value="100">
                </div>
            </div>

            <div class="add-event-row-wrapper">
                <label class="add-event-input-label" for="event-place">
                    Miasto
                </label>

                <div class="add-event-img-input-wrapper">
                    <i class="material-icons add-event-input-img">location_city</i>
                    <select name="event-place" id="event-place" class="add-event-form-input">
                        <option>Wrocław</option>
                        <option>Warszawa</option>
                        <option>Kalisz</option>
                        <option>Leszno</option>
                        <option selected>Zduńska Wola</option>
                        <option>Kraków</option>

                    </select>
                </div>
            </div>

            <div class="add-event-row-wrapper">
                <label class="add-event-input-label" for="event-tickets">
                    Liczba dostępnych biletów
                </label>

                <div class="add-event-img-input-wrapper">
                    <i class="material-icons add-event-input-img">aspect_ratio</i>
                    <input
                            name="event-tickets"
                            id="event-tickets"
                            type="number"
                            class="add-event-form-input"
                            placeholder="Bilety"
                            value="100">
                </div>
            </div>

            <div class="add-event-row-wrapper">
                <label class="add-event-input-label" for="event-description">
                    Opis wydarzenia
                </label>

                <textarea
                        name="event-description"
                        id="event-description"
                        class="add-event-form-text-area"
                        placeholder="Dodaj opis wydarzenia"></textarea>
            </div>
        </div>

        <div class="add-event-buttons-wrapper">
            <button type="submit" class="add-event-form-button" id="add-event-form-button" disabled>Utwórz wydarzenie
            </button>
            <button type="reset" class="add-event-form-button" id="add-event-form-reset-button">Zresetuj ustawienia
            </button>
        </div>
    </form>

</main>

<?php
include_once dirname($_SERVER["DOCUMENT_ROOT"]) . '/src/main/footer.template.php';
?>
