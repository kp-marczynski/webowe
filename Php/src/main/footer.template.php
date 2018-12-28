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
</body>
</html>