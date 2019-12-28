var TIPO_RECURSO = { IMAGEN: 0, AUDIO: 1, VIDEO: 2, TEXTO: 3, CRITERIO: 4 };
var siguienteHTMLID = 0;

function Recurso(id, element, file, contentAttr, resAttr) {
    this.id = id;
    this.htmlID = ++siguienteHTMLID;
    this.file = file;
    this.top = "0px";
    this.left = "0px";

    // html contendor
    var div = document.createElement('div');
    $(div).attr('id', this.htmlID);
    $(div).attr(contentAttr);

    // html para el recurso
    var res = document.createElement(element);
    $(res).attr(resAttr);

    if (element == 'img') {
        this.type = TIPO_RECURSO.IMAGEN;
        this.width = "200px";
        this.height = "200px";
    } else if (element == 'textarea') {
        this.type = TIPO_RECURSO.TEXTO;
        this.width = "300px";
        this.height = "200px";
        this.text = "";
        $(res).on('change keyup paste', function () { _recurso_sel.text = $(this)[0].value; });
    } else if (element == 'audio') {
        this.type = TIPO_RECURSO.AUDIO;
        this.width = "270px";
        this.height = "35px";
    } else {
        this.type = TIPO_RECURSO.VIDEO;
        this.width = "500px";
        this.height = "300px";
    }

    $(div).append(res);
    
    this.html = div;
    this.setDnD(this.html, res);
}

Recurso.prototype.setDnD = function (dndElement, innerElement) {
        $(dndElement).draggable({
            scroll: true,
            delay: 100,
            containment: $('.contenido_ejercicio'),
            cancel: $(innerElement).attr('id'),
            drag: function (event, ui) {
                $(innerElement).css({ 'box-shadow': '0px 0px 5px 3px #ecae76', 'border': 'none', 'cursor': 'move' });
            },
            stop: function (event, ui) {
                $(innerElement).css({ 'box-shadow': 'none', 'border': 'solid 1px gray', 'cursor': 'pointer' });
                $(innerElement).focus();
            }
        });
//    $(dndElement).draggable();

    //    $(dndElement).droppable({
    //        greedy: true,
    //        tolerance: "touch",
    //        over: function (event, ui) {
    //            hayColision = true;
    //        },
    //        out: function (event, ui) {
    //            hayColision = false;
    //        }
    //    });

        $(dndElement).resizable();
}

Recurso.prototype.setActions = function (onCloseCallback, onCheckCallback) {
    if ($(this.html.lastChild).is('span'))
        this.html.removeChild(this.html.lastChild);

    var span = document.createElement('span');
    $(span).attr('class', 'op_recurso');

    var span_borrar = document.createElement('img');
    $(span_borrar).attr('src', '../../Content/Resources/MasterPage/delete.png');
    $(span_borrar).on('click', onCloseCallback);

    var span_check = document.createElement('img');
    $(span_check).attr('src', '../../Content/Resources/Actividad/checked.png');
    $(span_check).on('click', onCheckCallback);
    $(span_check).attr('class', 'btnCheck');

    $(span).append(span_borrar);
    $(span).append(span_check);

    $(this.html).append(span);
}