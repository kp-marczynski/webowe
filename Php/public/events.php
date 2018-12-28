<?php
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
            foreach ($events as $event) {

                $html = "
<section class='event'>
    <img class='event-img' alt='$event->name' src='$event->imageUrl'/>
    <h4 class='event-name'> $event->name </h4>
    <h6 class='event-meta'>{$event->getMeta()}</h6>
    <p class='event-short-info'>$event->shortInfo</p>
    <div class='event-actions'>
     <i class='material-icons add-shopping-cart' onclick='addToCard(" . $event->id . ")'>add_shopping_cart</i>
</div>
            

</section>
            ";

                echo $html;
            }

            ?>

        </article>
    </main>


<?php
include_once dirname($_SERVER["DOCUMENT_ROOT"]) . '/src/main/footer.template.php';
?>