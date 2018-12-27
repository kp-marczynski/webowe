<?php


class EventsService
{
    private $eventDao;


    public function __construct($eventDao)
    {
        include_once dirname($_SERVER["DOCUMENT_ROOT"]) . '/src/main/Event.php';
        $this->eventDao = $eventDao;
    }


    /**
     * @return Event[]
     * @throws Exception
     */
    public function findAllEvents() {
        return [
            new Event(1, "Metallica", new DateTime('2018-11-11'), "Wrocław", 1, "https://amp.businessinsider.com/images/5bad1be2e55aa8fa0e8b4567-750-563.jpg", "Taki sobie koncert Taki sobie koncert", "Lorem ipsum Lorem ipsumLorem ipsumLorem ipsumLorem ipsumLorem ipsum Lorem ipsum Lorem ipsumLorem ipsumLorem ipsumLorem ipsumLorem ipsumLorem ipsum Lorem ipsumLorem ipsumLorem ipsumLorem ipsumLorem ipsum"),
            new Event(2, "Led Zeppelin", new DateTime('2018-10-11'), "Warszawa", 1, "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRstR8KPbn-GsQMNSlujHU-GR_uXAoURfPYPCJWDRXQoKmBMwSL", "Taki sobie koncert Taki sobie koncert Taki sobie koncert Taki sobie koncert Taki sobie koncert Taki sobie koncert", "Lorem ipsum Lorem ipsumLorem ipsumLorem ipsumLorem ipsumLorem ipsum Lorem ipsum Lorem ipsumLorem ipsumLorem ipsumLorem ipsumLorem ipsumLorem ipsum Lorem ipsumLorem ipsumLorem ipsumLorem ipsumLorem ipsum"),
            new Event(3, "Rammstein", new DateTime('2018-04-11'), "Kalisz", 2, "https://ichef.bbci.co.uk/images/ic/960x540/p01bqw3r.jpg", "Taki sobie koncert Taki sobie koncert", "Lorem ipsum Lorem ipsumLorem ipsumLorem ipsumLorem ipsumLorem ipsum Lorem ipsum Lorem ipsumLorem ipsumLorem ipsumLorem ipsumLorem ipsumLorem ipsum Lorem ipsumLorem ipsumLorem ipsumLorem ipsumLorem ipsum"),
            new Event(4, "The Beatles", new DateTime('2018-11-11'), "Leszno", 1, "https://upload.wikimedia.org/wikipedia/commons/thumb/3/3a/The_Beatles_and_Lill-Babs_1963.jpg/220px-The_Beatles_and_Lill-Babs_1963.jpg", "Taki sobie koncert Taki sobie koncert", "Lorem ipsum Lorem ipsumLorem ipsumLorem ipsumLorem ipsumLorem ipsum Lorem ipsum Lorem ipsumLorem ipsumLorem ipsumLorem ipsumLorem ipsumLorem ipsum Lorem ipsumLorem ipsumLorem ipsumLorem ipsumLorem ipsum"),
        ];
    }

}