<?php


if ($_SERVER['REQUEST_METHOD'] === 'DELETE') {
    include_once dirname($_SERVER["DOCUMENT_ROOT"]) . '/src/events/EventsController.php';
    $controller = new EventsController();

    $eventId = $_GET['eventId'];

    $controller->deleteEvent($eventId);
}