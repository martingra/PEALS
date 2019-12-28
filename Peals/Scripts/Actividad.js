// variables para controlar los ejercicios dentro de la actividad
var cont_ejercicio = 0;
var ejercicio_sel = -1;
var lista_ejercicios = [];
function EjercicioHash(id, htmlContent, htmlSolucion){
    this.id = id;
    this.htmlContent = htmlContent;
    this.htmlSolucion = htmlSolucion;
}

// variable para controlar la cantidad de recursos caragados.
var cantRecursos = 0;

var cuerpoActividadTemplate = $(".cuerpo_actividad").clone();
var cuerpoActividad = $(".cuerpo_actividad");  // contenedor del diseño de la actividad.

var cuerpoSolucionTemplate = $(".cuerpo_solucion").clone(); 
var cuerpoSolucion = $(".cuerpo_solucion");// contenedor de la solución.

var ubicacionRecurso = { peals: 1, pc: 2 };
var tRecurso = { imagen: 1, audio: 2, video: 3 };
var tRecursoSel;
var tSolucion = { escribir: "1", seleccionar: "2", repetir: "3", senias: "4" };

// Variable para controlar las colisiones
var hayColision = false;

var dialog = $('#dialog');

// variable usuada en la solución, para recordar el video seleccionado
var videoSel;

$(document).ready(init());

function init() {
    $(cuerpoSolucion).children('.div_acordion').accordion({
        collapsible: true,
        navigation: true,
        clearStyle: true,
        heightStyle: "content",
        icons: { "header": "ui-icon-plus", "activeHeader": "ui-icon-minus" },
        animate: true
    });

    $('.arbol_ejercicios').tabs().addClass("ui-tabs-vertical ui-helper-clearfix");
    $('.arbol_ejercicios li').removeClass("ui-corner-top").addClass("ui-corner-left");

    agregarEjercicio();
}

function checkDeletreo() {
    var deletreo = $('#presentacion').find('#rDeletreo');
    if ($(deletreo).is(':checked'))
        $(deletreo).attr('checked', 'checked');
    else
        $(deletreo).removeAttr('checked');
}

function nuevoRecurso(ubicacion, tipo) {
    tRecursoSel = tipo;
    switch (ubicacion) {
        case ubicacionRecurso.peals:
            $(dialog).empty();

            var size = (tRecursoSel == tRecurso.audio) ? "medium" : "xlarge";
            $(dialog).addClass(size);

            $.get('/Recurso/SeleccionarRecurso', { 'tipo': tipo }, function (data) {
                $(dialog).append(data);
                $(dialog).reveal({ closeonbackgroundclick: false, dismissmodalclass: "cerrar_dialog" });
            });

            break;

        case ubicacionRecurso.pc:
            document.getElementById('file').click();
            break;

            $(dialog).reveal();
            break;
    }
}

function btnClick_cancelarSelRecurso() {
    $(dialog).removeClass('xlarge');
    $(dialog).removeClass('medium');
    $(dialog).trigger('reveal:close');
}

function btnClick_aceptarSelRecurso(id, src, title) {
    agregarRecurso(id, src, title, false);

    $(dialog).removeClass('xlarge');
    $(dialog).trigger('reveal:close');
}

function handleFileSelect(event, res) {
    var f = event.target.files[0];
    var reader = new FileReader();

    var color = (f.size > 5242880) ? "red" : "green"; // si es mayor a 10MB
    var unidades = ["B", "KB", "MB", "GB"];
    var i = 0, filesize = f.size;
    for (i = 0; filesize >= 1024; i++)
        filesize /= 1024;

    reader.onload = (function (theFile) {
        return function (e) {
            var resSrc = e.target.result;

            $.post('/Recurso/_AgregarEditarRecurso', function (data) {
                $(dialog).empty();
                $(dialog).addClass('medium');
                $(dialog).append(data);
                $(dialog).find('img').attr('src', resSrc);
                $(dialog).find('b').css('color', color).text(filesize.toFixed(0) + unidades[i]);
                $(dialog).find('#nr_btnCancelar').on('click', function () { btnClick_cancelarSelRecurso(); });
                $(dialog).find('#nr_btnAceptar').on('click', function () {
                    var title = $(dialog).find('input').val();
                    agregarRecurso(null, resSrc, title, true);

                    $(dialog).removeClass('medium');
                    $(dialog).trigger('reveal:close');
                });

                $(dialog).reveal();
            });
        };
    })(f);

    // Leo la imagen como un data URL.
    reader.readAsDataURL(f);
}

function agregarRecurso(id, resSrc, title, esResPc) {
    // html para el span
    var span = document.createElement('span');
    $(span).attr('class', 'op_recurso');

    var span_img = document.createElement('img');
    $(span_img).attr('src', '../../Content/Resources/Actividad/Delete.png');
    $(span_img).on('click', function () {
        this.parentElement.parentElement.remove();
    });

    $(span).append(span_img);

    var recurso;
    switch (tRecursoSel) {
        case tRecurso.imagen:
            recurso = generarHTMLRecurso('img', { 'id': ++cantRecursos, 'class': 'content_recurso', 'title': title }, { 'id': id, 'class': 'img_actividad', 'src': resSrc, 'alt': title }, esResPc, span);
            setDnD(recurso, $(recurso).children('img'));

            break;
        case tRecurso.audio:
            recurso = generarHTMLRecurso('audio', { 'id': ++cantRecursos, 'class': 'content_recurso', 'title': title }, { 'id': id, 'class': 'audio_actividad', 'src': resSrc, 'title': title, 'controls': 'controls' }, esResPc, span);
            setDnD(recurso, $(recurso).children('audio'));

            break;
        case tRecurso.video:
            recurso = generarHTMLRecurso('video', { 'id': ++cantRecursos, 'class': 'content_recurso', 'title': title }, { 'id': id, 'class': 'video_actividad', 'src': resSrc, 'title': title, 'controls': 'controls' }, esResPc, span);
            setDnD(recurso, $(recurso).children('video'));

            break;
        default:
            recurso = generarHTMLRecurso('textarea', { 'id': ++cantRecursos, 'class': 'content_recurso' }, { 'id': '0', 'class': 'texto_actividad', 'cols': '25', 'rows': '10' }, false, span);
            setDnD(recurso, $(recurso).children('textarea'));

            break;
    }

    tRecursoSel = -1;
    $(cuerpoActividad).append(recurso);
}

function cargarSolucion() {
    var explicacion, ocultar, mostrar;

    var tSolucionSel = $('#tipo_respuesta').val();
    switch (tSolucionSel) {
        case tSolucion.seleccionar:
            generarHTMLRecursosSolucion();

            explicacion = 'Selecciona cual será la opción correcta';
            ocultar = '#rTexto, .div_deletreo';
            mostrar = '.div_acordion, #seleccion';

            break;

        case tSolucion.escribir:
            explicacion = 'Escribe cual será la respuesta correcta. Si quieres agregar un poco de ayuda, puedes activar el deletreo.';
            ocultar = '.div_acordion, #seleccion';
            mostrar = '#rTexto, .div_deletreo';

            break;
        case tSolucion.repetir: case tSolucion.senias:
            explicacion = 'Escribe la resuesta. Esto nos servirá para saber si lo que hace el alumno esta bien.';
            ocultar = '.div_acordion, .div_deletreo, #seleccion';
            mostrar = '#rTexto';

            break;
    }

    $(cuerpoSolucion).find('#explicacion_solucion').text(explicacion);
    $(cuerpoSolucion).find(ocultar).css('display', 'none');
    $(cuerpoSolucion).find(mostrar).css('display', 'block');
}

function setDnD(dndElement, innerElement) {
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

function sigPanel() {
    $("section#creacion").css('display', 'none');
    $("section#presentacion").css('display', 'block');

    $('#btn_siguiente').css('display', 'none');
    $('#btn_anterior').css('display', 'block');
    $('#btn_vistaPrevia').css('display', 'block');
    $('#btn_guardar').css('display', 'block');
}

function antPanel() {
    $("section#creacion").css('display', 'block');
    $("section#presentacion").css('display', 'none');

    $('#btn_siguiente').css('display', 'block');
    $('#btn_anterior').css('display', 'none');
    $('#btn_vistaPrevia').css('display', 'none');
    $('#btn_guardar').css('display', 'none');
}

function guardarActividad() {
    var nombre = $('#act_nombre').val();
    var op_correcta = document.getElementsByName('opcion_correcta');
    var id_opCorrecta = $(op_correcta).attr('id');
    var texto_solucion = $('.cuerpo_solucion').find('#rTexto').val();
    var deletreo = $('.cuerpo_solucion').find('#rDeletreo').is(':checked');
    var descripcion = $('#texto_explicacion').val();

    var fd = new FormData();
    fd.append('nombre', nombre);
    fd.append('texto_solucion', texto_solucion);
    fd.append('deletreo', deletreo);
    fd.append('descripcion', descripcion);

    var idRes = [], contFile = 0;

    debugger;

    for (var i = 0; i < lista_ejercicios.length; i++) {
        var tmp = lista_ejercicios[i];
        var test = $(tmp.htmlContent)[0];
        var recursos = $(tmp.htmlContent)[0].find('.content_recurso');
        recursos.each(function (index, node) {
            var id = $(this).attr('id');
            var file = $(this).children(':file');

            var top = this.style.top;
            var left = this.style.left;

            if ($(file).is('input')) {
                contFile++;
                fd.append('_upRecurso' + index + 1, file[0].files[0]);
                idRes.push(new UIRecurso(-contFile, i, $(this).attr('title'), (id == id_opCorrecta), top, left));
            }
            else {
                var res = this.firstChild;
                var texto = ($(res).is('textarea')) ? $(res).val() : $(this).attr('title');
                idRes.push(new UIRecurso($(res).attr('id'), i, texto, (id == id_opCorrecta), top, left));
            }
        });
    }

    fd.append('recursos', JSON.stringify(idRes));

    var xhr = new XMLHttpRequest();
    xhr.open('post', '/Actividad/GuardarActividad', true);
    xhr.send(fd);
    xhr.onreadystatechange = function () {
        if (this.readyState == 4 && this.status == 200) {
            $(dialog).empty();
            $(dialog).addClass('xlarge');
            $(dialog).append(this.responseText);
            $(dialog).reveal();
        }
    };
}

function btnClick_cancelarAsignacion() {
    $(dialog).removeClass('xlarge');
    $(dialog).trigger('reveal:close');
    location.href = '@Url.Action("Index", "Actividad")';
}

function generarHTMLRecurso(element, contentAttr, resAttr, esResPc, span) {
    // html contendor
    var div = document.createElement('div');
    $(div).attr(contentAttr);

    // html para el recurso
    var res = document.createElement(element);
    $(res).attr(resAttr);

    $(div).append(res);
    $(div).append(span);

    if (esResPc) {
        var input = $('#file').clone();
        $(input).removeAttr('id');
        $(input).attr('name', 'res_pc');
        $(input).on('change', function (event) { handleFileSelect(event, res); });

        $(div).append(input);
    }

    return div;
}

function generarHTMLRecursosSolucion() {
    var recursos = $(cuerpoActividad).find('.content_recurso');
    $(recursos).each(function () {
        var content;

        var span_img = $('<img>').attr({ 'src': '../../Content/Resources/MasterPage/ok.png', 'width': '32px', 'height': '32px', 'onclick': 'marcarRecursoCorrecto(event, this.parentElement.parentElement)' });
        var span = $('<span>').attr('class', 'op_correcta').append(span_img);

        var id = $(this).attr('id');
        var res = $(this.firstChild).clone();
        var nombre;
        if ($(res).is('img')) {
            nombre = $(res).attr('alt')
            content = $('<div>').attr({ 'id': id, 'class': 'content_recurso', 'title': nombre }).append($(res)).append(span);
            $(cuerpoSolucion).find('#da_imagenes').append(content);
        }
        else if ($(res).is('audio')) {
            nombre = $(res).attr('title');
            var label = $('<h3>').text(nombre);
            content = $('<li>').attr({ 'id': id, 'class': 'content_recurso', 'title': nombre }).append(span).append(label).append($(res));
            $(cuerpoSolucion).find('#da_sonidos ul').append(content);
        }
        else if ($(res).is('video')) {
            nombre = $(res).attr('title');
            var label = $('<h3>').text(nombre);
            var input = $('<input>').attr({ 'type': 'hidden', 'value': $(res).attr('src') });
            content = $('<li>').attr({ 'id': id, 'class': 'content_recurso', 'title': nombre }).append(span).append(label).append(input);
            $(content).on('click', function () {
                if (videoSel != null) $(videoSel).removeClass('webgrid-selected-row');

                $(this).attr('class', 'webgrid-selected-row');
                var src = $(this).children('input').val();
                $(cuerpoSolucion).find('#da_videos video').attr('src', src);

                videoSel = this;
            });
            $(cuerpoSolucion).find('#da_videos ul').append(content);
        }
    });
}

function marcarRecursoCorrecto(event, content) {
    var selPrevia = document.getElementsByName('opcion_correcta');
    var id = 0;

    if (selPrevia.length > 0) {
        id = $(selPrevia).attr('id');
        $(selPrevia).removeAttr('name')
                        .find('span').css('visibility', '')
                        .find('img').css('opacity', '');
    }

    if ($(content).attr('id') != id) {
        $(content).attr('name', 'opcion_correcta')
                      .find('span').css('visibility', 'visible')
                      .find('img').css('opacity', '1');

        var title = $(content).attr('title');
        $(cuerpoSolucion).find('#seleccion').removeClass('sinSeleccion').text(title);
    }
    else {
        $(cuerpoSolucion).find('#seleccion').attr('class', 'sinSeleccion').text('No ha seleccionado una opción.');
    }
}

function UIRecurso(id, ejercicio, texto, esCorrecto, pos_top, pos_left) {
    this.id = id;
    this.ejercicio = ejercicio;
    this.texto = texto;
    this.esCorrecto = esCorrecto;
    this.pos_top = pos_top;
    this.pos_left = pos_left;
}

function agregarEjercicio() {
    cont_ejercicio++;
    var id_ejercicio = 'e' + cont_ejercicio;

    var tab_li = $('<li>').append($('<a>').attr('href', '#' + id_ejercicio).text("E" + cont_ejercicio));

    var ejercicio = $('#creacion').children('.temp').clone();
    $(ejercicio).removeClass('temp');
    $(ejercicio).attr('id', id_ejercicio);

    $('#creacion').children('ul').append(tab_li);
    $('#creacion').append(ejercicio);

    ejercicio_sel = cont_ejercicio - 1;
}

function mostrarEjercicio(id) {
    var tmp = lista_ejercicios[ejercicio_sel];
    if (tmp.id != id) {
        tmp.htmlContent = $(cuerpoActividad).clone();
        tmp.htmlSolucion = $(cuerpoSolucion).clone();

        $(cuerpoActividad).empty();

        for (var i = 0; i < lista_ejercicios.length; i++) {
            tmp = lista_ejercicios[i];
            if (tmp.id == id) {
                $(cuerpoActividad).html($(tmp.htmlContent).html());
                $(cuerpoSolucion).html($(tmp.htmlSolucion).html());

                ejercicio_sel = i;

                break;
            }
        }
    }
}

function quitarEjercicio() {
    var b = 0;
}

function changeSize() {
    var width = parseInt($("#Width").val());
    var height = parseInt($("#Height").val());

    if (!width || isNaN(width)) {
        width = 600;
    }
    if (!height || isNaN(height)) {
        height = 400;
    }
    $(".arbol_ejercicios").width(width).height(height);

    // update perfect scrollbar
    $('.arbol_ejercicios').perfectScrollbar('update');
}

//$(function () {
//    $('.arbol_ejercicios').perfectScrollbar();
//});