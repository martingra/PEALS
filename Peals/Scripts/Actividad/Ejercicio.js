this.siguienteRecursoID = 0;

function Ejercicio(id) {
    this.id = id;
    this.nombre = "Ejercicio" + id;
    this.zoom = 1;
    this.solucion = new Solucion();
    this.recursos = new Array();    
    
    this.html = $('<li>').attr({'id':this.id, class:"active", onclick:"mostrarEjercicio("+ this.id + ")" });

    var pNombre = $('<p>').text(this.nombre);
    var pSolucion = $('<p>').text("-- --");
    var btnCerrar = $('<img>').attr({ src: "../../Content/Resources/MasterPage/delete.png", width: "16px", heigh: "16px", alt: "Eiminar", onclick: "eliminarEjercicio("+this.id+", event)"});

    $(this.html).append(pNombre);
    $(this.html).append(btnCerrar);
    $(this.html).append(pSolucion);

    this.setTipoSolucion(0);
}

Ejercicio.prototype.agregarImagen = function (nombre, src, file) {
    var id = (file != null) ? -(++siguienteRecursoID) : parseInt(nombre);
    var recurso = new Recurso(id, 'img', file, { 'class': 'content_recurso content_imagen', 'title': nombre }, { 'id': id, 'class': 'img_actividad', 'src': src, 'alt': nombre });
    recurso.setActions(
        function () { _ejercicio_sel.eliminarRecurso($(this.parentElement.parentElement).attr('id'), _managerRecurso.imagenesCargadas); },
        function () { _ejercicio_sel.marcarRecursoComoCorrecto($(this.parentElement.parentElement.firstChild).attr('id')); }
    );

    this.recursos.push(recurso);
    return recurso;
}

Ejercicio.prototype.agregarTexto = function () {
    var id = -(++siguienteRecursoID);
    var recurso = new Recurso(id, 'textarea', '', { 'class': 'content_recurso content_textarea' }, { 'id': id, 'class': 'texto_actividad', 'cols': '25', 'rows': '10' });
    recurso.setActions(
        function () { _ejercicio_sel.eliminarRecurso($(this.parentElement.parentElement).attr('id')); },
        function () { _ejercicio_sel.marcarRecursoComoCorrecto($(this.parentElement.parentElement.firstChild).attr('id')); });

    this.recursos.push(recurso);
    return recurso;
}

Ejercicio.prototype.agregarAudio = function (nombre, src, file) {
    var id = (file != null) ? -(++siguienteRecursoID) : parseInt(nombre);
    var recurso = new Recurso(id, 'audio', file, { 'class': 'content_recurso content_audio', 'title': nombre }, { 'id': id, 'class': 'audio_actividad', 'src': src, 'title': nombre, 'controls': 'controls' });
    recurso.setActions(
        function () { _ejercicio_sel.eliminarRecurso($(this.parentElement.parentElement).attr('id'), _managerRecurso.audiosCargados); },
        function () { _ejercicio_sel.marcarRecursoComoCorrecto($(this.parentElement.parentElement.firstChild).attr('id')); }
    );

    this.recursos.push(recurso);
    return recurso;
}

Ejercicio.prototype.agregarVideo = function (nombre, src, file) {
    var id = (file != null) ? -(++siguienteRecursoID) : parseInt(nombre);
    var recurso = new Recurso(id, 'video', file, { 'class': 'content_recurso content_video', 'title': nombre }, { 'id': id, 'class': 'video_actividad', 'src': src, 'title': nombre, 'controls': 'controls' });
    recurso.setActions(
        function () { _ejercicio_sel.eliminarRecurso($(this.parentElement.parentElement).attr('id'), _managerRecurso.videosCargados); },
        function () { _ejercicio_sel.marcarRecursoComoCorrecto($(this.parentElement.parentElement.firstChild).attr('id')); }
    );

    this.recursos.push(recurso);
    return recurso;
}

Ejercicio.prototype.eliminarRecurso = function (id, lista) {
    if (lista != null)
        _managerRecurso.quitarRecurso(lista, id);

    var pos = -1;
    for (i in this.recursos) {
        if (this.recursos[i].htmlID == id) {
            pos = i;
            break;
        }
    }

    if (pos != -1) {
        $(this.recursos[pos].html).remove();
        this.recursos.splice(pos, 1);
        return true;
    }

    return false;
}

Ejercicio.prototype.mostrarRecursos = function (mostrar) {
    if (mostrar) {
        $(".contenido_ejercicio").removeClass('temp');
    } else {
        $(".contenido_ejercicio").addClass('temp');
    }
//    $(".content_recurso").each(function (index) {
//        if (mostrar){
//            $(this).removeClass('temp');
//        } else {
//            $(this).addClass('temp');
//        }
//    });
}

Ejercicio.prototype.marcarRecursoComoCorrecto = function (id) {
    this.setRespuesta(id);

    var img_src = "";
    $(".content_recurso").each(function (index) {
        if ($(this.firstChild).attr('id') == id) {
            if ($(this.firstChild).is('img'))
                img_src = $(this.firstChild).clone();
            else if ($(this.firstChild).is('audio'))
                img_src = $(this.firstChild).clone();
            else if ($(this.firstChild).is('textarea')) {
                img_src = $(this.firstChild).clone();
                img_src[0].value = $(this.firstChild)[0].value;
                $(img_src).attr('disabled', 'disabled');
            }
            else if ($(this.firstChild).is('video'))
                img_src = $(this.firstChild).clone();
        }
    });

    $(".contenido_solucion > #solucion_seleccion > #panel_img").empty();
    $(".contenido_solucion > #solucion_seleccion > #panel_img").append(img_src[0]);
    $(".contenido_solucion > #solucion_seleccion > #panel_drag").css('display', 'none');
}

Ejercicio.prototype.setTipoSolucion = function (tipo) {
    this.solucion.tipo = tipo;

    $(".contenido_solucion > #solucion_seleccion > #panel_img").empty();
    $(".contenido_solucion > #solucion_seleccion > #panel_drag").css('display', 'block');

    $(".contenido_solucion > #solucion_escribir > #rTexto")[0].value = "";
    $(".contenido_solucion > #solucion_escribir > .div_deletreo > #rDeletreo").removeAttr("checked");

    //$("#select_senias")[0].value = "default";
    $("#select_senias")[0].value = "";

    switch (tipo) {
        case 1:
            $("#tipos_soluciones > ul > li:nth-child(1)").addClass("opciones");

            $("#tipos_soluciones > ul > li:nth-child(2)").removeClass("escribir");
            $("#tipos_soluciones > ul > li:nth-child(3)").removeClass("senias");

            $(".contenido_solucion > #solucion_seleccion").removeClass("temp");
            $(".contenido_solucion > #solucion_escribir").addClass("temp");
            $(".contenido_solucion > #solucion_senias").addClass("temp");

            $(_ejercicio_sel.html).children("p:eq(1)").text("OPCIONES");

            break;
        case 2:
            $("#tipos_soluciones > ul > li:nth-child(2)").addClass("escribir");

            $("#tipos_soluciones > ul > li:nth-child(1)").removeClass("opciones");
            $("#tipos_soluciones > ul > li:nth-child(3)").removeClass("senias");

            $(".contenido_solucion > #solucion_seleccion").addClass("temp");
            $(".contenido_solucion > #solucion_escribir").removeClass("temp");
            $(".contenido_solucion > #solucion_senias").addClass("temp");

            $(_ejercicio_sel.html).children("p:eq(1)").text("ESCRIBIR");

            break;
        case 3:
            $("#tipos_soluciones > ul > li:nth-child(3)").addClass("senias");

            $("#tipos_soluciones > ul > li:nth-child(1)").removeClass("opciones");
            $("#tipos_soluciones > ul > li:nth-child(2)").removeClass("escribir");

            $(".contenido_solucion > #solucion_seleccion").addClass("temp");
            $(".contenido_solucion > #solucion_escribir").addClass("temp");
            $(".contenido_solucion > #solucion_senias").removeClass("temp");

            $(_ejercicio_sel.html).children("p:eq(1)").text("SEÑAS");

            break;
        default:
            $("#tipos_soluciones > ul > li:nth-child(1)").removeClass("opciones");
            $("#tipos_soluciones > ul > li:nth-child(2)").removeClass("escribir");
            $("#tipos_soluciones > ul > li:nth-child(3)").removeClass("senias");

            $(".contenido_solucion > #solucion_seleccion").addClass("temp");
            $(".contenido_solucion > #solucion_escribir").addClass("temp");
            $(".contenido_solucion > #solucion_senias").addClass("temp");


            $(".contenido_solucion > #solucion_seleccion > #panel_img").empty();
            $(".contenido_solucion > #solucion_seleccion > #panel_drag").css('display', 'block');
    }
}

Ejercicio.prototype.mostrarSolucion = function () {
    $("#tipos_soluciones > ul > li:nth-child(1)").removeClass("opciones");
    $("#tipos_soluciones > ul > li:nth-child(2)").removeClass("escribir");
    $("#tipos_soluciones > ul > li:nth-child(3)").removeClass("senias");

    this.setTipoSolucion(this.solucion.tipo);

    switch (this.solucion.tipo) {
        case 1:
            this.marcarRecursoComoCorrecto(this.solucion.respuesta);

            break;
        case 2:
            $(".contenido_solucion > #solucion_escribir > #rTexto")[0].value = this.solucion.respuesta;
            if (this.solucion.opcion == 0)
                $(".contenido_solucion > #solucion_escribir > .div_deletreo > #rDeletreo").removeAttr("checked");
            else
                $(".contenido_solucion > #solucion_escribir > .div_deletreo > #rDeletreo").attr("checked");
            break;
        case 3:
            $("#select_senias")[0].value = this.solucion.senia;
            break;
    }
}

Ejercicio.prototype.setRespuesta = function (respuesta) {
    this.solucion.respuesta = respuesta;
}