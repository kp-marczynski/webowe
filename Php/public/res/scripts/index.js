function closeNav() {
    ['remove-navbar-button', 'nav-bar']
        .map(id => document.getElementById(id))
        .forEach(dom => dom.classList.add('closed'));

    ['open-navbar-button']
        .map(id => document.getElementById(id))
        .forEach(dom => dom.classList.remove('closed'));
}

function openNav() {
    ['remove-navbar-button', 'nav-bar']
        .map(id => document.getElementById(id))
        .forEach(dom => dom.classList.remove('closed'));

    ['open-navbar-button']
        .map(id => document.getElementById(id))
        .forEach(dom => dom.classList.add('closed'));
}