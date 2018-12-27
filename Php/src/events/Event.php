<?php

class Event
{
    public $id;
    public $name;
    public $price;
    public $place;
    public $date;
    public $shortInfo;
    public $description;
    public $imageUrl;
    public $availableTickets;
    public $createdBy;

    /**
     * Event constructor.
     * @param $id
     * @param $name
     * @param $price
     * @param $place
     * @param $date
     * @param $shortInfo
     * @param $description
     * @param $imageUrl
     * @param $availableTickets
     * @param $createdBy
     */
    public function __construct($id, $name, $price, $place, $date, $shortInfo, $description, $imageUrl, $availableTickets, $createdBy)
    {
        $this->id = $id;
        $this->name = $name;
        $this->price = $price;
        $this->place = $place;
        $this->date = $date;
        $this->shortInfo = $shortInfo;
        $this->description = $description;
        $this->imageUrl = $imageUrl;
        $this->availableTickets = $availableTickets;
        $this->createdBy = $createdBy;
    }


    public static function fromDbResult($result)
    {
        return new Event(
            $result['id'],
            $result['name'],
            $result['price'],
            $result['place'],
            strtotime($result['date']),
            $result['short_info'],
            $result['description'],
            $result['image_url'],
            $result['number_of_available_tickets'],
            $result['created_by']
        );
    }


    public function getMeta()
    {
        return date("m/d/y g:i", $this->date) . ", " . $this->place;
    }
}