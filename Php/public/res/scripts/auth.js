const EMAIL_PATTERN = /^[_a-z0-9-]+(\.[_a-z0-9-]+)*@[a-z0-9-]+(\.[a-z0-9-]+)*(\.[a-z]{2,})$/i;
const NO_DATA = 'NO_DATA';
const INVALID_EMAIL = 'INVALID_EMAIL';
const NOT_MATCHES = 'NOT_MATCHES';

function startValidatingRegistrationForm() {
    const emailInput = document.getElementsByName('email')[0];
    const passwordInput = document.getElementsByName('password')[0];
    const confirmPasswordInput = document.getElementsByName('confirm-password')[0];
    const confirmButton = document.querySelector('button');

    const validateForm = (callback) => {
        const email = emailInput.value.trim();
        const password = passwordInput.value.trim();
        const confirmPassword = confirmPasswordInput.value.trim();

        let errors = [];

        if (!email || !password || !confirmPassword) {
            errors.push(NO_DATA)
        }

        if (!EMAIL_PATTERN.test(email)) {
            errors.push(INVALID_EMAIL);
        }

        if (password && confirmPassword && password !== confirmPassword) {
            errors.push(NOT_MATCHES)
        }
        callback(errors);
    };

    const formInputs = [emailInput, passwordInput, confirmPasswordInput];

    //button.addEventListener()
    formInputs.forEach(dom =>
        dom.addEventListener('keyup', () =>
            validateForm(errors => confirmButton.disabled = errors.length !== 0)));

    formInputs.forEach(dom =>
        dom.addEventListener('blur', () =>
            validateForm(errors => {
                if (errors.includes(INVALID_EMAIL)) {
                    emailInput.classList.add('error')
                } else {
                    emailInput.classList.remove('error');
                }
                if (errors.includes(NOT_MATCHES)) {
                    confirmPasswordInput.classList.add('error')
                } else confirmPasswordInput.classList.remove('error');
            })
        ))
}

(function () {
    if (window.location.href.includes("register")) {
        startValidatingRegistrationForm();
    }

    const urlParams = new URLSearchParams(window.location.search);
    const isSuccess = !!urlParams.get('success');

    if (isSuccess) {
        const dialog = createActionDialog({
            title: "Stworzono konto",
            message: "Gratulacje! Twoje konto zostało stworzone z sukcesem. Możesz już zacząć wyszukiwać i tworzyć ciekawe wydarzenia!",
            okMessage: "Super",
            cancelMessage: "Cofnij",
            onOk: () => window.location.href = "/events",
        });

        dialog.open();
    }

})();
