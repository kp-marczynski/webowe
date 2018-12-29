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
    public $ageRange;
    public $additionalInfo;

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
     * @param $ageRange
     * @param $additionalInfo
     */
    public function __construct($id, $name, $price, $place, $date, $shortInfo, $description, $imageUrl, $availableTickets, $createdBy, $ageRange, $additionalInfo)
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
        $this->ageRange = $ageRange;
        $this->additionalInfo = $additionalInfo;
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
            $result['created_by'],
            $result['age_range'],
            $result['additional_info']
        );
    }


    public function getMeta()
    {
        return date("m/d/y g:i", $this->date) . ", " . $this->place;
    }
}