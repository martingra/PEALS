$(document).ready(init());

var _actividad;
var _ejercicio_sel;
var _recurso_sel;
var _criterio;
var _managerRecurso;

var _panel_lista;
var _panel_ejercicio;
var _panel_solucion;

var _dialog_recursos;
var _tipo_recurso;
var _valorTmp;

function init() {
    this._panel_lista = $(".menu_vertical");
    this._panel_ejercicio = $(".contenido_ejercicio");
    this._panel_solucion = $("contenido_solucion");

    this._dialog_recursos = $("#dialog");

    this._actividad = new Actividad();
    this._criterio = new Criterio();
    agregarEjercicio();

    _managerRecurso = new ManagerRecursos();

    //document.getElementById("select_senias").onchange = onSeniaChange;
    document.getElementById("select_criterio").onchange = onCriterioChange;
}

function agregarEjercicio() {
    if (_actividad.ejercicios.length == 16) {
        alert("YA SE HA ALCANZADO EL LÍMITE DE EJERCICIOS PERMITIDOS POR ACTIVIDAD");
    }
    else {
        $(_panel_ejercicio).empty();
        if (_ejercicio_sel != null)
            $(_ejercicio_sel.html).removeClass('active');

        _ejercicio_sel = this._actividad.agregarEjercicio();
        $(_panel_lista).append(_ejercicio_sel.html);
    }
}

function mostrarEjercicio(id) {
    $(_panel_ejercicio).empty();

    $(_ejercicio_sel.html).removeClass('active');
    _ejercicio_sel = _actividad.getEjercicio(id);
    $(_ejercicio_sel.html).addClass('active');

    for (i in _ejercicio_sel.recursos) {
        $(_panel_ejercicio).append(_ejercicio_sel.recursos[i].html);
        _ejercicio_sel.recursos[i].setDnD(_ejercicio_sel.recursos[i].html, _ejercicio_sel.recursos[i]);
        _ejercicio_sel.recursos[i].setActions(
            function () {
                var id_to_delete = $(this.parentElement.parentElement).attr('id');
                var lista = null;
                if (_ejercicio_sel.recursos[i].type == TIPO_RECURSO.IMAGEN) lista = _managerRecurso.imagenesCargadas;
                else if (_ejercicio_sel.recursos[i].type == TIPO_RECURSO.AUDIO) lista = _managerRecurso.audiosCargados;
                else if (_ejercicio_sel.recursos[i].type == TIPO_RECURSO.VIDEO) lista = _managerRecurso.videossCargados;
                _ejercicio_sel.eliminarRecurso(id_to_delete, lista);
            },
            function () { _ejercicio_sel.marcarRecursoComoCorrecto(id); });

        $(_ejercicio_sel.recursos[i].html).css({ '-webkit-transform': 'scale(' + _ejercicio_sel.zoom + ')', '-ms-transform': 'scale(' + _ejercicio_sel.zoom + ')', 'transform': 'scale(' + _ejercicio_sel.zoom + ')' });

        if ($(_ejercicio_sel.recursos[i].html.firstChild).is('textarea'))
            $(_ejercicio_sel.recursos[i].html.firstChild).attr('contenteditable', 'true');
    }

    _ejercicio_sel.mostrarSolucion();
}

function eliminarEjercicio(id, e) {
    e.stopPropagation();
    if (_ejercicio_sel.id == id) {
        if (_actividad.ejercicios.length == 1) {
            alert("Error al eliminar. La activdad debe tener al menos un ejercicio");
        }
        else {
            _actividad.eliminarEjercicio(id);

            $(_panel_ejercicio).empty();
            var new_id = $(_panel_lista).children('ul li:nth-child(2)').attr('id');
            mostrarEjercicio(new_id);
        }
    } else {
        _actividad.eliminarEjercicio(id);
    }
}

function cargarPC() {
    _ejercicio_sel.mostrarRecursos(true);

    $("#panel_recursos").css('display', 'none');
    document.getElementById('file').click();
    
    agregarCheck();

    _managerRecurso.imagenesSeleccionadas = new Array();
    _managerRecurso.audiosSeleccionados = new Array();
    _managerRecurso.videoSeleccionados = new Array();
}

function agregarImagen(src, file) {
    //$("#panel_recursos").css('display', 'block');
    $("#panel_recursos").show("slow");
    _ejercicio_sel.mostrarRecursos(false);

    $("#panel_recursos").css('display', 'block');
    $("#zoom_panel").css('visibility', 'hidden');
    _tipo_recurso = TIPO_RECURSO["IMAGEN"];
    _managerRecurso.getImagenes();

    agregarCheck();
}

function agregarTexto() {
    //$("#panel_recursos").css('display', 'none');
    $("#panel_recursos").hide("slow");
    _ejercicio_sel.mostrarRecursos(true);

    $("#panel_recursos").css('display', 'none');

    _tipo_recurso = TIPO_RECURSO["TEXTO"];
    _recurso_sel = _ejercicio_sel.agregarTexto();
    $(_panel_ejercicio).append(_recurso_sel.html);
    $(_recurso_sel.html).css({ '-webkit-transform': 'scale(' + _ejercicio_sel.zoom + ')', '-ms-transform': 'scale(' + _ejercicio_sel.zoom + ')', 'transform': 'scale(' + _ejercicio_sel.zoom + ')' });

    $(_panel_ejercicio)
    agregarCheck();
}

function agregarAudio(src, file) {
    _ejercicio_sel.mostrarRecursos(false);

    //$("#panel_recursos").css('display', 'block');
    $("#panel_recursos").show("slow");
    $("#zoom_panel").css('visibility', 'hidden');
    _tipo_recurso = TIPO_RECURSO["AUDIO"];
    _managerRecurso.getAudios();

    agregarCheck();
}

function agregarVideo(src, file) {
    //$("#panel_recursos").css('display', 'block');
    $("#panel_recursos").show("slow");
    _ejercicio_sel.mostrarRecursos(false);

    $("#panel_recursos").css('display', 'block');
    $("#zoom_panel").css('visibility', 'hidden');
    _tipo_recurso = TIPO_RECURSO["VIDEO"];
    _managerRecurso.getVideos();

    agregarCheck();
}

function agregarRecursosSeleccionados() {
    cerrarGaleria();

    for (i_img in _managerRecurso.imagenesSeleccionadas) {
        var id_img  = _managerRecurso.imagenesSeleccionadas[i_img].id;
        var src_img = _managerRecurso.imagenesSeleccionadas[i_img].src;
        var file_img = _managerRecurso.getFile(_managerRecurso.imagenesCargadas, id_img);
        _recurso_sel = _ejercicio_sel.agregarImagen(id_img, src_img, file_img);
        $(_panel_ejercicio).append(_recurso_sel.html);

        if (parseInt(id_img) < 0 && file_img == null)
            _managerRecurso.agregarRecurso(_managerRecurso.imagenesCargadas, id_img, src_img);
    }

    _managerRecurso.imagenesSeleccionadas = new Array();

    for (i_audio in _managerRecurso.audiosSeleccionados) {
        var id_audio = _managerRecurso.audiosSeleccionados[i_audio].id;
        var src_audio = _managerRecurso.audiosSeleccionados[i_audio].src;
        var file_audio = _managerRecurso.getFile(_managerRecurso.audiosCargados, id_audio);
        _recurso_sel = _ejercicio_sel.agregarAudio(id_audio, src_audio, file_audio);
        $(_panel_ejercicio).append(_recurso_sel.html);

        if (parseInt(id_audio) < 0 && file_audio == null)
            _managerRecurso.agregarRecurso(_managerRecurso.audiosCargados, id_audio, src_audio);
    }

    _managerRecurso.audiosSeleccionados = new Array();

    for (i_video in _managerRecurso.videoSeleccionados) {
        var id_video = _managerRecurso.videoSeleccionados[i_video].id;
        var src_video = _managerRecurso.videoSeleccionados[i_video].src;
        var file_video = _managerRecurso.getFile(_managerRecurso.videosCargados, id_video);
        _recurso_sel = _ejercicio_sel.agregarVideo(id_video, src_video, file_video);
        $(_panel_ejercicio).append(_recurso_sel.html);

        if (parseInt(id_video) < 0 && file_video == null)
            _managerRecurso.agregarRecurso(_managerRecurso.videosCargados, id_video, src_video);
    }

    _managerRecurso.videoSeleccionados = new Array();

    agregarCheck();

}

function agregarCheck() {
    if ($('#solucion_seleccion:visible').length == 1) {
        $(".btnCheck").show();
    }
    else {
        $(".btnCheck").hide();
    }
}

function cerrarGaleria() {
    _ejercicio_sel.mostrarRecursos(true);
    $("#panel_recursos").hide("slow");

    var filtro = $("#txt_buscarRecurso")[0].value = "";
}

function obtenerURLDisco(event) {
    var f = event.target.files[0];
    var reader = new FileReader();
    reader.onload = (function (theFile) {
        return function (e) {
            var src = e.target.result;
            var lista = null;
            var id = 0;
            switch (_tipo_recurso) {
                case TIPO_RECURSO["IMAGEN"]:
                    _recurso_sel = _ejercicio_sel.agregarImagen("", src, f);
                    lista = _managerRecurso.imagenesCargadas;
                    break;
                case TIPO_RECURSO["AUDIO"]:
                    _recurso_sel = _ejercicio_sel.agregarAudio("", src, f);
                    lista = _managerRecurso.audiosCargados;
                    break;
                case TIPO_RECURSO["VIDEO"]:
                    _recurso_sel = _ejercicio_sel.agregarVideo("", src, f);
                    lista = _managerRecurso.videosCargados;
                    break;
                case TIPO_RECURSO["CRITERIO"]:
                    _criterio.setImagen(_valorTmp, src, f);
                    event.stopPropagation();
                    return;
            }

            _managerRecurso.agregarRecurso(lista, _recurso_sel.id, src, f);

            $(_panel_ejercicio).append(_recurso_sel.html);
            $(_recurso_sel.html).css({ '-webkit-transform': 'scale(' + _ejercicio_sel.zoom + ')', '-ms-transform': 'scale(' + _ejercicio_sel.zoom + ')', 'transform': 'scale(' + _ejercicio_sel.zoom + ')' });
            agregarCheck();
        };
    })(f);

    // Leo la imagen.
    reader.readAsDataURL(f);
}

function responderSeleccionando() {
    _ejercicio_sel.setTipoSolucion(TIPO_SOLUCION["OPCIONES"]);

    $(".contenido_solucion > #solucion_escribir > #rTexto")[0].value = "";
    $(".btnCheck").show();
}

function responderEscribiendo() {
    _ejercicio_sel.setTipoSolucion(TIPO_SOLUCION["ESCRIBIR"]);
    $(".btnCheck").hide();
}

function responderConSenias() {
    _ejercicio_sel.setTipoSolucion(TIPO_SOLUCION["SENIAS"]);

    $(".contenido_solucion > #solucion_escribir > #rTexto")[0].value = "";
    $(".btnCheck").hide();
}

function onInputSolucionChange() {
    _ejercicio_sel.setRespuesta($("#solucion_escribir > #rTexto")[0].value);
}

function onDeletreoClick() {
    _ejercicio_sel.solucion.opcion = (_ejercicio_sel.solucion.opcion == 0) ? 1 : 0;
}

function agregarIntervalo() {
    var hasta = $("#intervalos > #intervalo > div > #txt_hasta")[0].value;
    if (parseInt(hasta) < 100) {
        var intervalo = _criterio.agregarIntervalo(hasta, "", -1);
        if (intervalo != null)
            $("#timeline_container > #timeline > ul > li:last").before(intervalo);
    }
}

function eliminarImage(valor) {
    var intervalo = _criterio.quitarIntervalo(valor, "");
    //alert(intervalo);
    if (intervalo != null)
        $("#timeline>ul>li:nth-child("+intervalo+")").remove();
}

function cambiarImage(valor) {
    _tipo_recurso = TIPO_RECURSO["CRITERIO"];
    _valorTmp = valor;
    var values = { "tipo": 1, "filtro": "", "pagina": 1, "limite": 12, "resCargados": null };
    $.post('/Recurso/GetRecursosAsJson', values, function (data) {
        $("#contenido_recursosCriterio").empty();
        for (var i in data.recursos) {
            var img_content = $('<div>').attr({ 'id': data.recursos[i].id, 'name': data.recursos[i].ruta.replace("~", "../.."), 'class': 'rContent_img' });
            var img = $('<img>').attr({ 'class': 'image close-reveal-modal', 'src': data.recursos[i].ruta.replace("~", "../.."), 'alt': data.recursos[i].nombre }).on('click', function (event) {
                var src = $(this).attr('src');
                var id_res_cri = $(this.parentElement).attr('id');
                _criterio.setImagen(valor, src, parseInt(id_res_cri));
            });

            img_content.append(img);
            $("#contenido_recursosCriterio").append(img_content);
        }
        
        $('#dialog_recursoCriterio').reveal({
            animation: 'fadeAndPop', 
            animationspeed: 300,
            closeonbackgroundclick: true,
            dismissmodalclass: 'close-reveal-modal'
        });
    });
}

function cargarCriterioPC() { document.getElementById('file').click(); }

function volver() {
    $("#creacion").removeClass('temp');
    $("#presentacion").addClass('temp');

    $("#botones > #panel_1").removeClass("temp");
    $("#botones > #panel_2").addClass("temp");
}

function siguiente() {
    if (_actividad.sonEjerciciosBienFormulados()) {
        $("#creacion").addClass('temp');
        $("#presentacion").removeClass('temp');

        $("#botones > #panel_1").addClass("temp");
        $("#botones > #panel_2").removeClass("temp");
    } else {
        alert("Error al guardar ejercicios. Recuerda que todos los ejercicios tienen que tener contenido y una solución.");
    }
}

function verVistaPrevia() {
}

function guardar() {
    var nombre = $("#presentacion > .left > #act_nombre")[0].value;
    var explicacion = $("#presentacion > .left > #pAct_explicacion > #texto_explicacion")[0].value;
    //var video = $("#presentacion > .right > video").attr('src');
    var fileInput = $("#info_urlVideo")[0];

    if (nombre && explicacion) {
        _actividad.nombre = nombre;
        _actividad.explicacion = explicacion;
        //_actividad.video = fileInput.files[0];

        var criterio = $("select#select_criterio option:selected").val();

        var fd = new FormData();
        for (i in _actividad.ejercicios) {
            for (j in _actividad.ejercicios[i].recursos) {
                if (_actividad.ejercicios[i].recursos[j] != null) {
                    _actividad.ejercicios[i].recursos[j].top = _actividad.ejercicios[i].recursos[j].html.style.top;
                    _actividad.ejercicios[i].recursos[j].left = _actividad.ejercicios[i].recursos[j].html.style.left;
                    //fd.append(_actividad.ejercicios[i].id + '.' + _actividad.ejercicios[i].recursos[j].id, _actividad.ejercicios[i].recursos[j].file);
                    fd.append(_actividad.ejercicios[i].recursos[j].id, _actividad.ejercicios[i].recursos[j].file);
                    _actividad.ejercicios[i].recursos[j].top = $(_actividad.ejercicios[i].recursos[j].html).css('top');
                    _actividad.ejercicios[i].recursos[j].left = $(_actividad.ejercicios[i].recursos[j].html).css('left');
                    _actividad.ejercicios[i].recursos[j].width = $(_actividad.ejercicios[i].recursos[j].html).css('width');
                    _actividad.ejercicios[i].recursos[j].height = $(_actividad.ejercicios[i].recursos[j].html).css('height');
                }
            }
        }
        fd.append('actividad', JSON.stringify(_actividad));
        fd.append('criterio', criterio);
        fd.append('video', fileInput.files[0]);

        $("#dialog").css('display', 'block');

        $("#guardar-actividad").removeClass("temp");
        $("#guardar-actividad").show();

        var xhr = new XMLHttpRequest();
        xhr.onprogress = onProgressChangeCallback // onProgressChangeCallback(evt);
        xhr.open('post', '/Actividad/GuardarActividad', true);
        xhr.send(fd);
        xhr.onreadystatechange = function () {
            $("#dialog").css('display', 'none');
            if (this.readyState == 4 && this.status == 200) {
                location.href = '/Actividad/Index';
            }
        }
    } else {
        alert("Es necesario que la actividad tenga un nombre y una explicación");
    }
}

function onProgressChangeCallback(evt) {
    if (evt.lengthComputable) {
        var percentComplete = evt.loaded / evt.total;
        $("#dialog > #mensaje > #anim_line").text(percentComplete);
    } else {
        $("#dialog > #mensaje > #anim_line").text("No se puede conocer el progreso");
    }
}

//function onSeniaChange() {
//    var id_senia = $("select#select_senias option:selected").val();
//    _ejercicio_sel.solucion.respuesta = id_senia;
//}

function onCriterioChange() {
    var criterio = $("select#select_criterio option:selected").val();
    if (criterio != 0) {
        $("#txt_nombre")[0].value = $("select#select_criterio option:selected").text();

        $("#timeline_container > #timeline > ul").empty();

        _criterio = new Criterio();
        _criterio.recuperarCriterio(criterio);

        $("#criterio_correccion > #intervalos").css('display', 'block');

        $("#btn_editarCriterio").css('display', 'block');
        $("#btn_guardarCriterio").css('display', 'none');

        disableEdition(true);
    }
}

function nuevoCriterio() {
    $("#intervalos").css('display', 'block');
    $("#intervalos").fadeIn(3000);

    _criterio = new Criterio();
    $("#intervalos > #intervalo > div > #txt_nombre")[0].value = "";
    $("#timeline_container > #timeline > ul").empty();

    _criterio.nuevoCriterio();

    $("#btn_editarCriterio").css('display', 'none');
    $("#btn_guardarCriterio").css('display', 'block');

    disableEdition(false);
}

function editarCriterio() {
    disableEdition(false);

    $.each($("#timeline>ul>li>span"), function (key, value) {
        $(this).find("#img_opciones").css('display', '');
    });

    $("#btn_editarCriterio").css('display', 'none');
    $("#btn_guardarCriterio").css('display', 'block');
}

function guardarCriterio() {
    _criterio.guardarCriterio();

    $("#btn_editarCriterio").css('display', 'block');
    $("#btn_guardarCriterio").css('display', 'none');

    disableEdition(true);
}

function disableEdition(disable) {
    $("#txt_nombre").prop("disabled", disable);
    $("#txt_hasta").prop("disabled", disable);
    $("#btn_agregarIntervalo").prop("disabled", disable);
}

function onZoomIn() {
    if (_ejercicio_sel.zoom < 1) {
        _ejercicio_sel.zoom += 0.1;

        $(".content_recurso").each(function (index) {
            $(this).css({ '-webkit-transform': 'scale(' + _ejercicio_sel.zoom + ')', '-ms-transform': 'scale(' + _ejercicio_sel.zoom + ')', 'transform': 'scale(' + _ejercicio_sel.zoom + ')' });
        });
    }
}

function onZoomOut() {
    if (_ejercicio_sel.zoom > 0.5) {
        _ejercicio_sel.zoom -= 0.1;
        $(".content_recurso").each(function (index) {
            $(this).css({ '-webkit-transform': 'scale(' + _ejercicio_sel.zoom + ')', '-ms-transform': 'scale(' + _ejercicio_sel.zoom + ')', 'transform': 'scale(' + _ejercicio_sel.zoom + ')' });
        });
    }
}

function buscarRecurso() {
    switch (_tipo_recurso) {
        case TIPO_RECURSO["IMAGEN"]:
            _managerRecurso.getImagenes();
            break;
        case TIPO_RECURSO["AUDIO"]:
            _managerRecurso.getAudios();
            break;
        case TIPO_RECURSO["VIDEO"]:
            _managerRecurso.getVideos();
            break;
    }
}