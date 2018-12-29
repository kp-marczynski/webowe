const inputs = [
    {
        id: 'event-name',
        errorMessage: 'Nazwa jest niepoprawna',
        isError: (val) => !val
    },
    {
        id: 'event-date',
        errorMessage: 'Podana data jest niepoprawna (musi być w przyszłości)',
        isError: (val) => {
            if (!val) return true;
            const date = new Date(val);
            if (!date instanceof Date || isNaN(date)) return true;
            return date < new Date();
        }
    },
    {
        id: 'event-price',
        errorMessage: 'Cena być dodatnią liczbą rzeczywistą',
        isError: (val) => !val || !/^[0-9]+([,.][0-9]+)?$/g.test(val)
    },
    {
        id: 'event-tickets',
        errorMessage: 'Liczba biletów powinna być naturalna',
        isError: (val) => !val || !/^[0-9]+$/g.test(val)
    },
    {
        id: 'event-description',
        isError: () => false,
    }
];

function getTomorrowDate() {
    const tomorrow = new Date();
    tomorrow.setDate(tomorrow.getDate() + 1);
    return tomorrow;
}

(function () {

    const imageDom = document.getElementById('add-event-image');
    const imageUrlInput = document.getElementById('event-image-url');

    const addEventButton = document.getElementById('add-event-form-button');

    imageUrlInput.addEventListener('keyup', () => {
        imageDom.src = imageUrlInput.value || '/res/images/placeholder.png';
    });


    document.getElementById('event-date').valueAsDate = getTomorrowDate();

    const inputsToValidate = inputs.map((inp) => ({...inp, dom: document.getElementById(inp.id)}));


    function validateForm(inp) {
        const inputDom = inp.dom;
        const {value} = inputDom;
        const shouldDisplayError = inp.isError(value);
        const {parentNode} = inputDom;

        if (shouldDisplayError) {
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
    }

    function enableOrDisableButton() {
        addEventButton.disabled = inputsToValidate.some(inp => inp.isError(inp.dom.value))
    }

    inputsToValidate.forEach((inp) => {
        inp.dom.addEventListener('blur', () => validateForm(inp));
        inp.dom.addEventListener('keyup', enableOrDisableButton)
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