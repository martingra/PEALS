$.fn.setDnD = function (dragElement, innerElement, esLista, dragStyle, dropElement, dropStyle, controlarCollision){    

    $(dndElement).draggable({
        scroll: true,
        delay: 100,
        containment: $('.cuerpo_actividad'),
        cancel: $(innerElement).attr('id'),
        drag: function (event, ui) {
            if (!hayColision)
                $(innerElement).css({ 'box-shadow': '0px 0px 5px 3px #ecae76', 'border': 'none', 'cursor': 'move' });
            else
                $(innerElement).css({ 'box-shadow': '0px 0px 5px 3px red' });
        },
        stop: function (event, ui) {
            $(innerElement).css({ 'box-shadow': 'none', 'border': 'solid 1px gray', 'cursor': 'pointer' });
            $(innerElement).focus();
        },
        revert: function () {
            if (hayColision) {
                hayColision = false;
                return true;
            } else {
                return false;
            }
        }
    });

    $(dndElement).droppable({
        greedy: true,
        tolerance: "touch",
        over: function (event, ui) {
            hayColision = true;
        },
        out: function (event, ui) {
            hayColision = false;
        }
    });
}