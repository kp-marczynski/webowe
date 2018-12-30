async function addToCard(eventId) {
    const formData = new FormData();
    formData.append('eventId', eventId);

    await fetch(`${window.BACKEND_URL}/cart`, {
        method: "POST",
        body: formData,
    });

    const itemsCountDom = document.getElementById('cart-items');
    //parseInt
    const items = parseInt(itemsCountDom.innerText || 0, 10);
    itemsCountDom.style.display = 'flex';
    itemsCountDom.innerText = items + 1;
}