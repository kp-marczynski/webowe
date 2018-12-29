<?php


class EventsController
{

    private $service;

    /**
     * EventsController constructor.
     */
    public function __construct()
    {
        include_once dirname($_SERVER["DOCUMENT_ROOT"]) . '/src/events/EventsService.php';
        include_once dirname($_SERVER["DOCUMENT_ROOT"]) . '/src/events/EventsDao.php';
        include_once dirname($_SERVER["DOCUMENT_ROOT"]) . '/src/events/Event.php';
        $this->service = new EventsService(new EventsDao());
    }


    /**
     * @return Event[]
     */
    function findAllEvents()
    {
        try {
            return $this->service->findAllEvents();
        } catch (Exception $e) {
            return null;
        }
    }

    private static function isDateValid($date, $format = 'Y-m-d')
    {
        $d = DateTime::createFromFormat($format, $date);
        return $d && $d->format($format) === $date && $d >= new DateTime();
    }

    /**
     * @param String[] $POST
     * @param int $userId
     * @return int
     */
    function createFromPost($POST, $userId)
    {
        $name = trim($POST['event-name']);
        $imageUrl = trim($POST['event-image-url']);
        $additionalInfo = $POST['additional-info'];
        $age = $POST['age'];
        $date = trim($POST['event-date']);
        $price = trim($POST['event-price']);
        $place = trim($POST['event-place']);
        $tickets = trim($POST['event-tickets']);
        $description = trim($POST['event-description']);

        $errors = [];

        if (empty($name) || empty($date) || empty($price) || empty($place) || empty($tickets)) {
            $errors[] = "Wymagane pola nie są uzupełnione";
        }

        if (!preg_match("/^[0-9]+([,.][0-9]+)?$/", $price)) {
            $errors[] = "Cena być dodatnią liczbą rzeczywistą";
        }

        if (!preg_match("/^[0-9]+$/", $tickets)) {
            $errors[] = "Liczba biletów powinna być naturalna";
        }

        if (!self::isDateValid($date)) {
            $errors[] = "Podana data jest niepoprawna (musi być w przyszłości)";
        }


        $event = new Event(null,
            $name,
            $price,
            $place,
            $date,
            substr($description, 0, 20),
            $description,
            empty($imageUrl) ? "/res/images/placeholder.png" : $imageUrl,
            $tickets,
            $userId,
            $age,
            implode("|", $additionalInfo)
        );

        return $this->service->createEvent($event);
    }
}