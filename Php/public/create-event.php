<?php
session_start();

/*
 * Skrypt powinien wykrywać, czy jest to rejestracja nowego użytkownika, czy wpisane dane są poprawne
 *  (walidacja na podstawie wyrażeń regularnych) i jeśli tak, zapisać je do bazy oraz wyświetlić stosowny komunikat.
 *  Innymi słowy, skrypt w zależności od kontekstu powinien generować formularz (pusty lub wypełniony) lub dokonywać
 * zapisu danych do bazy
 * */

/// window.alert()

function isUpdatingExistingEvent()
{
    return isset($_GET['eventId']) && $_SERVER['REQUEST_METHOD'] === 'POST';
}

function isCreatingNewEvent()
{
    // inne tablice superglobalne
    return $_SERVER['REQUEST_METHOD'] === 'POST' && !isset($_GET['eventId']);
}

include_once dirname($_SERVER["DOCUMENT_ROOT"]) . '/src/events/EventsController.php';
$controller = new EventsController();

$eventId = $_GET['eventId'];

if (isUpdatingExistingEvent()) {
    $controller->updateFromPost($_POST, $eventId);
} else if (isCreatingNewEvent()) {
    $userId = $_SESSION['userId'];

    $controller->createFromPost($_POST, $userId);
    header("Location: /events");
    die();
}

if (isset($eventId)) {
    $event = $controller->findEvent($eventId);
}

?>

<?php
include_once dirname($_SERVER["DOCUMENT_ROOT"]) . '/src/main/header.template.php';
?>

<main class="under-nav">
    <form class="add-event-form-card add-event-form"
          action="<?php echo isset($event) ? "create-event?eventId=$event->id" : "create-event" ?>" method="post">
        <h2 class="add-event-title">Dodaj nowe wydarzenie</h2>

        <div class="add-event-image-wrapper">
            <h5 class="add-event-image-title">Dodaj zdjęcie</h5>
            <img class="add-event-image"
                 id="add-event-image"
                 onerror="alert('Nie można załadować zdjęcia')"
                 src=<?php echo isset($event) && $event->hasImageToDisplay() ? $event->imageUrl : '/res/images/placeholder.png' ?>
            >

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
                            placeholder="URL"
                        <?php echo isset($event) && $event->hasImageToDisplay() ? "value='" . $event->imageUrl . "'" : '' ?>>
                </div>
            </div>

            <section class="add-event-row-wrapper">
                <h5 class="add-event-row-title">Zaznacz dodatkowe informacje o wydarzeniu</h5>
                <label class="checkbox-wrapper">
                    <input type="checkbox" name="additional-info[]" value="DOGS"
                        <?php echo isset($event) && $event->hasAdditionalInfo("DOGS") ? "checked" : "" ?>
                    >
                    <span>Można przyjść ze zwierzętami</span>
                </label>
                <label class="checkbox-wrapper">
                    <input type="checkbox" name="additional-info[]" value="DANGER"
                        <?php echo isset($event) && $event->hasAdditionalInfo("DANGER") ? "checked" : "" ?>
                    >
                    <span>Impreza o podwyższonym ryzyku</span>
                </label>
                <label class="checkbox-wrapper">
                    <input type="checkbox" name="additional-info[]" value="VIP"
                        <?php echo isset($event) && $event->hasAdditionalInfo("VIP") ? "checked" : "" ?>
                    >
                    <span>Wydzielona strefa dla VIPów</span>
                </label>
                <label class="checkbox-wrapper">
                    <input type="checkbox" name="additional-info[]" value="ALCOHOL"
                        <?php echo isset($event) && $event->hasAdditionalInfo("ALCOHOL") ? "checked" : "" ?>
                    >
                    <span>Możliwy zakup alkoholu</span>
                </label>
            </section>

            <section class="add-event-row-wrapper">
                <h5 class="add-event-row-title">Zaznacz przedział wiekowy</h5>
                <div class="radio-wrapper">
                    <input type="radio" name="age" value="ALL" id="add-event-radio-all"
                        <?php echo isset($event) ? ($event->ageRange == "ALL" ? "checked" : "") : "checked" ?>
                    >
                    <label for="add-event-radio-all">Impreza dozwolona dla wszystkich</label>
                </div>
                <div class="radio-wrapper">
                    <input type="radio" name="age" value="ADULTS_ONLY" id="add-event-radio-adults"
                        <?php echo isset($event) && $event->ageRange == "ADULTS_ONLY" ? "checked" : "" ?>
                    >
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
                            placeholder="Nazwa"
                        <?php echo isset($event) ? "value='" . $event->name . "'" : '' ?>
                    >
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
                        <?php echo isset($event) ? "value='" . $event->dateToJsFormat() . "'" : '' ?>
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
                        <?php echo isset($event) ? "value='" . $event->price . "'" : "value='100'" ?>>
                </div>
            </div>

            <div class="add-event-row-wrapper">
                <label class="add-event-input-label" for="event-place">
                    Miasto
                </label>

                <div class="add-event-img-input-wrapper">
                    <i class="material-icons add-event-input-img">location_city</i>
                    <select name="event-place" id="event-place" class="add-event-form-input">
                        <option <?php echo isset($event) && $event->place == "Wrocław" ? "selected" : "" ?>>Wrocław
                        </option>
                        <option <?php echo isset($event) && $event->place == "Warszawa" ? "selected" : "" ?>>Warszawa
                        </option>
                        <option <?php echo isset($event) && $event->place == "Kalisz" ? "selected" : "" ?>>Kalisz
                        </option>
                        <option <?php echo isset($event) && $event->place == "Leszno" ? "selected" : "" ?>>Leszno
                        </option>
                        <option <?php echo isset($event) && $event->place == "Zduńska Wola" ? "selected" : "" ?>>Zduńska
                            Wola
                        </option>
                        <option <?php echo isset($event) && $event->place == "Kraków" ? "selected" : "" ?>>Kraków
                        </option>
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
                        <?php echo isset($event) ? "value='" . $event->availableTickets . "'" : "value='100'" ?>
                    >
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
                        placeholder="Dodaj opis wydarzenia"
                ><?php if (isset($event)) {
                        echo $event->description;
                    } ?></textarea>
            </div>
        </div>

        <div class="add-event-buttons-wrapper">
            <button type="submit" class="add-event-form-button" id="add-event-form-button" disabled>
                <?php echo isset($event) ? "Zapisz zmiany" : "Utwórz wydarzenie" ?>
            </button>
            <button type="reset" class="add-event-form-button" id="add-event-form-reset-button">Zresetuj ustawienia
            </button>
<!--            znaki specjalne w łańcuchach (rola
odwrotnego ukośnika-->
            <?php echo "
            <button type='button' class='add-event-form-button' id='add-event-form-remove-button'
                    onclick='removeEvent($event->id, \"$event->name\")'
            >USUŃ WYDARZENIE
            </button>"
            ?>
        </div>
    </form>

</main>

<?php
include_once dirname($_SERVER["DOCUMENT_ROOT"]) . '/src/main/footer.template.php';
?>
