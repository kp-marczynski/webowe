<?php

class EventsDao
{
    private $connection;

    public function __construct()
    {
        include_once dirname($_SERVER["DOCUMENT_ROOT"]) . '/src/config/dbConfig.php';

        $this->connection = createDatabaseConnection();
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
        $statement = $this->connection->prepare("INSERT INTO events(name, price, place, date, short_info, description, image_url, number_of_available_tickets, created_by, age_range, additional_info) 
VALUES (?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?)");

        $statement->bind_param('sdsssssiiss',
            $event->name,
            $event->price,
            $event->place,
            $event->date,
            $event->shortInfo,
            $event->description,
            $event->imageUrl,
            $event->availableTickets,
            $event->createdBy,
            $event->ageRange,
            $event->additionalInfo);

        $statement->execute() or die(mysqli_error($this->connection));
        return $statement->insert_id;
    }

    public function updateEvent($event)
    {
        $statement = $this->connection->prepare("UPDATE events
SET name                        = ?,
    price                       = ?,
    place                       = ?,
    date                        = ?,
    short_info                  = ?,
    description                 = ?,
    image_url                   = ?,
    number_of_available_tickets = ?,
    age_range                   = ?,
    additional_info             = ?
WHERE id = ?");

        $statement->bind_param('sdsssssissi',
            $event->name,
            $event->price,
            $event->place,
            $event->date,
            $event->shortInfo,
            $event->description,
            $event->imageUrl,
            $event->availableTickets,
            $event->ageRange,
            $event->additionalInfo,
            $event->id);

        $statement->execute() or die(mysqli_error($this->connection));
        return $event->id;
    }

    /**
     * @param int $id
     * @return Event
     */
    public function findEvent($id)
    {
        $statement = $this->connection->prepare("SELECT * FROM events where id = ?");
        $statement->bind_param("i", $id);
        $statement->execute() or die(mysqli_error($this->connection));

        $row = $statement->get_result()->fetch_array();
        return Event::fromDbResult($row);
    }
}