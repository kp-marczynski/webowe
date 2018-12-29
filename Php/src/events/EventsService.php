<?php


class EventsService
{
    private $eventDao;


    /**
     * EventsService constructor.
     * @param EventsDao $eventDao
     */
    public function __construct($eventDao)
    {
        include_once dirname($_SERVER["DOCUMENT_ROOT"]) . '/src/events/Event.php';
        $this->eventDao = $eventDao;
    }


    /**
     * @return Event[]
     * @throws Exception
     */
    public function findAllEvents() {
       return $this->eventDao->findAllEvents();
    }


    /**
     * @param Event $event
     * @return int
     */
    public function createEvent($event) {
        return $this->eventDao->createEvent($event);
    }

}