var mostrarProgreso = true;

$(document).ready(function () {
    var i = 0;

    function openModal() {
        $("#modal").fadeIn();
        $("#fade").fadeIn();
    }

    function closeModal() {
        $("#modal").fadeOut();
        $("#fade").fadeOut();
    }

    $(document).ajaxSend(function () {
        if (i == 0 && mostrarProgreso) {
            openModal();
        }
        i++;
    });

    $(document).ajaxComplete(function () {  
        i--;
        if (i == 0 && mostrarProgreso) {
            closeModal();
        }

        mostrarProgreso = true;
    });
});

