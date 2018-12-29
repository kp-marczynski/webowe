<?php

class EventsDao
{
    private $connection;

    public function __construct()
    {
        include_once dirname($_SERVER["DOCUMENT_ROOT"]) . '/src/config/dbCredentials.php';

        $this->connection = mysqli_connect($DB_HOST, $DB_USER, $DB_PASSWORD, $DB_DATABASE) or die("Cannot connect to db");
    }

    public function findAllEvents()
    {
        $statement = $this->connection->prepare("SELECT * FROM events");
        $statement->execute() or die(mysqli_error($this->connection));

        $result = $statement->get_result();
        $events = [];

        while ($row = $result->fetch_array()) {
            $events[] = Event::fromDbResult($row);
        }

        return $events;
    }

    /**
     * @param Event $event
     * @return int
     */
    public function createEvent($event)
    {
        $statement = $this->connection->prepare("INSERT INTO events(name, price, place, date, short_info, description, image_url, number_of_available_tickets, created_by) 
VALUES (?, ?, ?, ?, ?, ?, ?, ?, ?)");

        $statement->bind_param('sdsssssii',
            $event->name,
            $event->price,
            $event->place,
            $event->date,
            $event->shortInfo,
            $event->description,
            $event->imageUrl,
            $event->availableTickets,
            $event->createdBy);

        $statement->execute() or die(mysqli_error($this->connection));
        return $statement->insert_id;
    }
}