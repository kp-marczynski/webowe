// function getCookie() {
//     var cname = "items-in-cart";
//     var name = cname + "=";
//     var decodedCookie = decodeURIComponent(document.cookie);
//     var ca = decodedCookie.split(';');
//     for (var i = 0; i < ca.length; i++) {
//         var c = ca[i];
//         while (c.charAt(0) == ' ') {
//             c = c.substring(1);
//         }
//         if (c.indexOf(name) == 0) {
//             return c.substring(name.length, c.length);
//         }
//     }
//     return "";
// }

function setCookie(cvalue) {
    var cname = "items-in-cart";
    var exdays = 1;
    var d = new Date();
    d.setTime(d.getTime() + (exdays * 24 * 60 * 60 * 1000));
    var expires = "expires=" + d.toUTCString();
    document.cookie = cname + "=" + encodeURIComponent(cvalue) + ";" + expires + ";path=/";
}

(function () {
    var shipment_inputs = [];

    const addEventButton = document.getElementById('add-event-form-button');
    addEventButton.disabled = false;

    const distinctEventsCount = parseInt(document.getElementById('distinct-event-count').innerText);
    for (var i = 0; i < distinctEventsCount; ++i) {
        const iter = i;
        shipment_inputs.push({
            id: 'CartCollection_BasketPositions_' + iter + '__Quantity',
            errorMessage: 'Przekroczono liczbę dostępnych biletów',
            isError: (val) => {
                const availableTickets = parseInt(document.getElementById('CurrentlyAvailableTickets_' + iter).innerText);
                return val > availableTickets;
            }
        });
        shipment_inputs.push({
            id: 'CartCollection_BasketPositions_' + iter + '__Quantity',
            errorMessage: 'Liczba biletów musi zawierać się w przedziale [0,10]',
            isError: (val) => {
                return val > 10 || val < 0;
            }
        });
        shipment_inputs.push({
            id: 'checkbox-wrapper_' + iter,
            errorMessage: 'Łączna liczba biletów w zamówieniu nie może przekroczyć 100',
            isError: () => countTicketsInOrder() > 100
        });
        shipment_inputs.push({
            id: 'checkbox-wrapper_' + iter,
            errorMessage: 'Łączna liczba biletów w zamówieniu nie może być mniejsza niż 1',
            isError: () => countTicketsInOrder() < 1
        });
    }


    function countTicketsInOrder() {
        var sum = 0;
        for (var i = 0; i < distinctEventsCount; ++i) {
            const iter = i;
            if ((document.getElementById('CartCollection_BasketPositions_' + iter + '__IsChecked').checked)) {
                //parseInt(document.getElementById('CartCollection_BasketPositions_0__Quantity').value);
                sum += parseInt(document.getElementById('CartCollection_BasketPositions_' + iter + '__Quantity').value);
            }
        }
        // console.log("tickets in order: " + sum);
        return sum;
    }

    const inputsToValidate = shipment_inputs.map((inp) => ({...inp, dom: document.getElementById(inp.id)}));


    function validateForm(inp) {
        const inputDom = inp.dom;
        const {value} = inputDom;
        const {id} = inputDom;
        const shouldDisplayError = inp.isError(value);
        const {parentNode} = inputDom;


        if (id.includes("checkbox-wrapper")) {

        } else {
            if (shouldDisplayError && !parentNode.querySelector('span')) {
                parentNode.classList.add('error');

                const errorSpan = document.createElement('span');
                errorSpan.classList.add('add-event-input-error');
                errorSpan.innerText = inp.errorMessage;

                parentNode.insertBefore(errorSpan, inputDom.nextSibling);
            } else {
                const errorSpan = parentNode.querySelector('span');
                if (errorSpan) {
                    if (errorSpan.innerText == inp.errorMessage && !shouldDisplayError) {
                        parentNode.removeChild(errorSpan);
                        parentNode.classList.remove('error');
                    }
                }
            }
        }
        if (validateNumberOfTicketsInForm()) {
            enableOrDisableButton();
            if (!addEventButton.disabled) {
                var result = [];
                for (var i = 0; i < distinctEventsCount; ++i) {
                    var eventIdFromInput = document.getElementById('CartCollection_BasketPositions_' + i + '__Event_Id').value;
                    var quantity = document.getElementById('CartCollection_BasketPositions_' + i + '__Quantity').value;
                    for (var j = 0; j < quantity; ++j) {
                        result.push(eventIdFromInput);
                    }
                }
                setCookie(JSON.stringify(result));
                document.getElementById('cart-items').innerText = result.length.toString();
            }
        } else {
            addEventButton.disabled = true;
        }
    }

    function validateNumberOfTicketsInForm() {
        const tickets = countTicketsInOrder();
        const node = document.getElementById('validation-summary-valid-error');

        if (tickets > 100) {
            node.setAttribute("style", "display:inline;");
            node.innerText = 'Łączna liczba biletów w zamówieniu nie może przekroczyć 100';
            return false;
        } else if (tickets < 1) {
            node.setAttribute("style", "display:inline;");
            node.innerText = 'Łączna liczba biletów w zamówieniu nie może być mniejsza niż 1';
            return false;
        } else {
            node.setAttribute("style", "display:none;");
            node.innerText = "";
            return true;
        }
    }

    function enableOrDisableButton() {
        addEventButton.disabled = inputsToValidate.some(inp => inp.isError(inp.dom.value))
    }

    inputsToValidate.forEach((inp) => {
        inp.dom.addEventListener('blur', () => validateForm(inp));
        inp.dom.addEventListener('mouseleave', () => validateForm(inp));
        inp.dom.addEventListener('keyup', () => validateForm(inp));
        inp.dom.addEventListener('click', () => validateForm(inp));
        // inp.dom.addEventListener('keyup', enableOrDisableButton)
    });

    function validateAll() {
        inputsToValidate.forEach((inp) => validateForm(inp));
    }

    addEventButton.addEventListener('mouseover', () => validateAll());

    // Array.from(document.querySelectorAll('input[type=checkbox]'))
    //     .forEach(i => {
    //         i.addEventListener('focus', () => {
    //             i.style.opacity = '0.12';
    //         });
    //         i.addEventListener('blur', () => {
    //             i.style.opacity = '0';
    //         })
    //     })

})();