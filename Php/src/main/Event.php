<?php

class Event
{
    public $id;
    public $name;
    public $date;
    public $place;
    public $createdBy;
    public $imageUrl;
    public $shortInfo;
    public $description;

    /**
     * Event constructor.
     * @param Number $id
     * @param String $name
     * @param DateTime $date
     * @param $place
     * @param Number $createdBy
     * @param String $imageUrl
     * @param $shortInfo
     * @param $description
     */
    public function __construct($id, $name, $date, $place, $createdBy, $imageUrl, $shortInfo, $description)
    {
        $this->id = $id;
        $this->name = $name;
        $this->date = $date;
        $this->createdBy = $createdBy;
        $this->imageUrl = $imageUrl;
        $this->shortInfo = $shortInfo;
        $this->description = $description;
        $this->place = $place;
    }

    public function getMeta()
    {
        return $this->date->format("d/m/Y") . ", " . $this->place;
    }
}