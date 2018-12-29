<script>
    <?php
    $protocol = (!empty($_SERVER['HTTPS']) && $_SERVER['HTTPS'] !== 'off' || $_SERVER['SERVER_PORT'] == 443) ? "https://" : "http://";
    ?>
    window.BACKEND_URL = <?php echo "'$protocol{$_SERVER['HTTP_HOST']}'"?>;
</script>
<script src="/scripts/dialogs.js"></script>
<script src="/scripts/index.js"></script>
<script src="/scripts/events.js"></script>
<script src="/scripts/add-event.js"></script>

<script>
    let theme = <?php echo "'" . $_COOKIE['theme'] . "'" ?> || 'LIGHT_THEME';

    switch (theme) {
        // defaults from css
        case 'LIGHT_THEME': {
            document.documentElement.style.setProperty('--muted-text-color', '#6c757d');
            document.documentElement.style.setProperty('--not-black-color', '#424242');
            document.documentElement.style.setProperty('--card-background', '#ffffff');
            document.documentElement.style.setProperty('--background', '#f2f2f2');
            document.documentElement.style.setProperty('--primary-color', '#4f8f5f');
            document.documentElement.style.setProperty('--secondary-color', '#c98e75');
            document.documentElement.style.setProperty('--error-color', '#e74c3c');
            document.documentElement.style.setProperty('--error-background', 'bisque');
            document.documentElement.style.setProperty('--text-color-on-primary', '#fff');
            document.documentElement.style.setProperty('--card-text', '#232F34');
            document.documentElement.style.setProperty('--card-meta-text', '#757575');
            document.documentElement.style.setProperty('--disabled-background', '#dddddd');
            document.documentElement.style.setProperty('--disabled-color', '#9b9b9b');
            document.documentElement.style.setProperty('--dialog-background', '#ffffff');
            document.documentElement.style.setProperty('--dialog-title-color', 'rgba(0, 0, 0, .87)');
            document.documentElement.style.setProperty('--dialog-text-color', 'rgba(0, 0, 0, .6)');
            document.documentElement.style.setProperty('--dialog-button-hover-background', 'rgba(79, 143, 95, .08)');
            document.documentElement.style.setProperty('--font-family', '\'Roboto\', sans-serif');
            break;
        }
        case 'DARK_THEME': {
            document.documentElement.style.setProperty('--muted-text-color', '#eeeeee');
            document.documentElement.style.setProperty('--not-black-color', '#f2f2f2');
            document.documentElement.style.setProperty('--card-background', '#303030');
            document.documentElement.style.setProperty('--background', '#212121');
            document.documentElement.style.setProperty('--primary-color', '#4f8f5f');
            document.documentElement.style.setProperty('--secondary-color', '#c98e75');
            document.documentElement.style.setProperty('--error-color', '#e74c3c');
            document.documentElement.style.setProperty('--error-background', 'bisque');
            document.documentElement.style.setProperty('--text-color-on-primary', '#fff');
            document.documentElement.style.setProperty('--card-text', '#bababa');
            document.documentElement.style.setProperty('--card-meta-text', '#cecece');
            document.documentElement.style.setProperty('--disabled-background', '#dddddd');
            document.documentElement.style.setProperty('--disabled-color', '#9b9b9b');
            document.documentElement.style.setProperty('--dialog-background', '#646464');
            document.documentElement.style.setProperty('--dialog-title-color', 'rgba(255, 255, 255, .87)');
            document.documentElement.style.setProperty('--dialog-text-color', 'rgba(255, 255, 255, .6)');
            document.documentElement.style.setProperty('--dialog-button-hover-background', 'rgba(79, 143, 95, .08)');
            document.documentElement.style.setProperty('--font-family', '\'Roboto\', sans-serif');
            break;
        }
        case 'BLUE_THEME': {
            document.documentElement.style.setProperty('--primary-color', '#303F9F');
            document.documentElement.style.setProperty('--secondary-color', '#C2185B');
            document.documentElement.style.setProperty('--font-family', '"Comic Sans MS", fantasy');
        }
    }


</script>
</body>
</html>