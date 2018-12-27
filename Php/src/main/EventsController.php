<?php


class EventsController
{

    private $service;

    /**
     * EventsController constructor.
     */
    public function __construct()
    {
        include_once dirname($_SERVER["DOCUMENT_ROOT"]) . '/src/main/EventsService.php';
        $this->service = new EventsService(null);
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
}