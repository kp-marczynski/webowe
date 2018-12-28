(function () {

    const imageDom = document.getElementById('add-event-image');
    const imageUrlInput = document.getElementById('event-image-url');

    const eventNameInput = document.getElementById('event-name');
    const eventDateInput = document.getElementById('event-date');
    const eventPriceInput = document.getElementById('event-price');
    const eventPlaceInput = document.getElementById('event-place');
    const eventTicketsInput = document.getElementById('event-tickets');
    const eventDescriptionInput = document.getElementById('event-description');
    const addEventButton = document.getElementById('add-event-form-button');
    
    imageUrlInput.addEventListener('keyup', () => {
        imageDom.src = imageUrlInput.value || '/res/images/placeholder.png';
    });
})();