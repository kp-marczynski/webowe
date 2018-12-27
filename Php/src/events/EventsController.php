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
}