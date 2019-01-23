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

    /**
     * @param $id
     * @return Event
     */
    function findEvent($id) {
        return $this->service->findEvent($id);
    }

    private static function isDateValid($date, $format = 'Y-m-d')
    {
        //  operatory przypisania, operatory porównania, pierwszeństwo operatorów
        $d = DateTime::createFromFormat($format, $date);
        return $d && $d->format($format) === $date && $d >= new DateTime();
    }

    function deleteEvent($eventId) {
        $this->service->deleteEvent($eventId);
    }


    /**
     * @param String[] $POST
     * @param int $eventId
     * @return int
     * @throws RuntimeException
     */
    function updateFromPost($POST, $eventId) {
        $name = trim($POST['event-name']);
        $imageUrl = trim($POST['event-image-url']);
        $additionalInfo = $POST['additional-info'];
        $age = $POST['age'];
        $date = trim($POST['event-date']);
        $price = trim($POST['event-price']);
        $place = trim($POST['event-place']);
        $tickets = trim($POST['event-tickets']);
        $description = trim($POST['event-description']);

        $errors = $this->validateEvent($name, $date, $price, $place, $tickets);

        if (!empty($errors))
            throw new RuntimeException(implode("|", $errors));

        // rzutowanie
        $event = new Event((int)$eventId,
            $name,
            $price,
            $place,
            $date,
            $this->createShortDescription($description),
            $description,
            $this->createImageUrl($imageUrl),
            $tickets,
            null,
            $age,
            $this->createAdditionalInfoArray($additionalInfo)
        );

        return $this->service->updateEvent($event);
    }

    /**
     * @param String[] $POST
     * @param int $userId
     * @return int
     * @throws RuntimeException
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

        $errors = $this->validateEvent($name, $date, $price, $place, $tickets);

        if (!empty($errors))
            throw new RuntimeException(implode("|", $errors));


        $event = new Event(null,
            $name,
            $price,
            $place,
            $date,
            $this->createShortDescription($description),
            $description,
            $this->createImageUrl($imageUrl),
            $tickets,
            $userId,
            $age,
            $this->createAdditionalInfoArray($additionalInfo)
        );

        return $this->service->createEvent($event);
    }

    /**
     * @param $name
     * @param $date
     * @param $price
     * @param $place
     * @param $tickets
     * @return String[] array
     */

    private function validateEvent($name, $date, $price, $place, $tickets)
    {
        // typowanie dynamiczne
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
        return $errors;
    }

    private function createShortDescription($description)
    {
        $descriptionLength = strlen($description);
        $maxLength = 50;
        if ($descriptionLength <= $maxLength) {
            return $description;
        } else {
            return substr($description, 0, $maxLength) . "...";
        }
    }

    private function createAdditionalInfoArray($additionalInfo)
    {
        if ($additionalInfo) {
            return implode("|", $additionalInfo);
        } else {
            return "";
        }
    }

    private function createImageUrl($imageUrl){
        return empty($imageUrl) ? "/shared/images/placeholder.png" : $imageUrl;
    }
}