<?php
session_start();

$userId = $_SESSION['userId'];
include_once dirname($_SERVER["DOCUMENT_ROOT"]) . '/src/main/header.template.php';
?>

<?php
include_once dirname($_SERVER["DOCUMENT_ROOT"]) . '/src/events/EventsController.php';
$controller = new EventsController();
?>
    <main class="under-nav">

        <article class="all-events">

            <?php
            $events = $controller->findAllEvents();

            // instrukcje sterujące for oraz funkcje count,
            for ($i = 0; $i < count($events); $i++) {
                $event = $events[$i];
                $html = "
<section class='event' onclick='goToEvent(" . $event->id . ")'>
    <img class='event-img' alt='$event->name' src='$event->imageUrl'/>
    <h4 class='event-name'> $event->name </h4>
    <h6 class='event-meta'>{$event->getMeta()}</h6>
    <p class='event-short-info'>$event->shortInfo</p>
    <div class='event-actions'>" . ($event->createdBy == $userId
                        ? "<a href='create-event?eventId=" . $event->id . "' class='event-anchor'><i class='material-icons add-shopping-cart'>edit</i></a>"
                        : "") .
                    "<i class='material-icons add-shopping-cart' onclick='addToCard(event, " . $event->id . "); return false'>add_shopping_cart</i>
</div>
            

</section>
            ";

                echo $html;
            }

            ?>

        </article>
    </main>

    <a class="fab" href="/create-event">
        <i class="material-icons">add</i>
    </a>


<?php
include_once dirname($_SERVER["DOCUMENT_ROOT"]) . '/src/main/footer.template.php';
?>