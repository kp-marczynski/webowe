(function () {
    const shipment_inputs = [
        {
            id: 'ShipmentInfo_FullName',
            errorMessage: 'Imie i nazwisko są wymagane',
            isError: (val) => !val
        },
        {
            id: 'ShipmentInfo_PhoneNumber',
            errorMessage: 'Numer telefonu jest wymagany',
            isError: (val) => !val
        },
        {
            id: 'ShipmentInfo_City',
            errorMessage: 'Miasto jest wymagane',
            isError: (val) => !val
        },
        {
            id: 'ShipmentInfo_PostalAddress',
            errorMessage: 'Kod pocztowy jest wymagany',
            isError: (val) => !val
        },
        {
            id: 'ShipmentInfo_Street',
            errorMessage: 'Nazwa ulicy jest wymagana',
            isError: (val) => !val
        },
        {
            id: 'ShipmentInfo_HouseNumber',
            errorMessage: 'Numer domu jest wymagany',
            isError: (val) => !val
        }
    ];

    const addEventButton = document.getElementById('add-event-form-button');
    addEventButton.disabled = false;
    const inputsToValidate = shipment_inputs.map((inp) => ({...inp, dom: document.getElementById(inp.id)}));


    function validateForm(inp) {
        const inputDom = inp.dom;
        const {value} = inputDom;
        const shouldDisplayError = inp.isError(value);
        const {parentNode} = inputDom;

        if (shouldDisplayError && !parentNode.querySelector('span')) {
            parentNode.classList.add('error');

            const errorSpan = document.createElement('span');
            errorSpan.classList.add('add-event-input-error');
            errorSpan.innerText = inp.errorMessage;

            parentNode.insertBefore(errorSpan, inputDom.nextSibling);
        } else {
            const errorSpan = parentNode.querySelector('span');
            if (errorSpan) {
                parentNode.removeChild(errorSpan);
                parentNode.classList.remove('error');
            }
        }
        enableOrDisableButton();
    }

    function enableOrDisableButton() {
        addEventButton.disabled = inputsToValidate.some(inp => inp.isError(inp.dom.value))
    }

    inputsToValidate.forEach((inp) => {
        inp.dom.addEventListener('blur', () => validateForm(inp));
        inp.dom.addEventListener('keyup', () => validateForm(inp));
    });

    Array.from(document.querySelectorAll('input[type=checkbox]'))
        .forEach(i => {
            i.addEventListener('focus', () => {
                i.style.opacity = '0.12';
            });
            i.addEventListener('blur', () => {
                i.style.opacity = '0';
            })
        })

})();