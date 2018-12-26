<?php

if (isset($_POST['email']) && isset($_POST['password'])) {
    echo "Podali emaij, super!";
    echo "";
    echo $_POST['email'];
}

else {
    echo "Nie podali nic :///";
}