var paginaActual;
var totalPaginas;

var totalRecursos;
var recursosPorPagina;

var thumbs;
var contentRecurso;
var caption;
var navegacion;
var paginacion;

var currElement;
var selectStyle;

var cambiarPagCallback;

$.galeria = {
    init: function () {
        $.galeria.calcularTotalPaginas();

        if (totalRecursos > 1) $.galeria.agregarNavegacion();
        if (recursosPorPagina < totalRecursos) $.galeria.construirPaginacion();

        $(thumbs).find('li').on('click', function (e) { $.galeria.seleccionarRecurso(e, this); });

        $.galeria.seleccionarPrimero();
    },

    seleccionarPrimero: function () {
        var primero = $(thumbs).children('li:first');

        var id = $(primero).children('a').attr('id');
        var src = $(primero).children('a').attr('href');
        var nombre = $(primero).children('a').attr('title');

        $(contentRecurso).attr({ 'id': id, 'src': src, 'alt': nombre, 'title': nombre });
        $(caption).empty();
        $(caption).append($(primero).children('.caption').html());

        $(primero).addClass(selectStyle);

        currElement = primero;
    },

    recursoAnterior: function (event) {
        if (!$(currElement).prev('li').length && paginaActual > 1)
            this.cambiarPagina(paginaActual - 1);
        else {
            var element = $(currElement).prev('li');
            this.seleccionarRecurso(event, element);
        }
    },

    recursoSiguiente: function (event) {
        if (!$(currElement).next('li').length && paginaActual <= totalPaginas)
            this.cambiarPagina(paginaActual + 1);
        else {
            var element = $(currElement).next('li');
            this.seleccionarRecurso(event, element);
        }
    },

    cambiarPagina: function (pagina) {
        paginaActual = pagina;
        cambiarPagCallback(pagina);
    },

    seleccionarRecurso: function (event, element) {
        var id = $(element).children('a').attr('id');
        var src = $(element).children('a').attr('href');
        var nombre = $(element).children('a').attr('title');

        $(contentRecurso).attr({ 'id': id, 'src': src, 'alt': nombre, 'title': nombre });
        $(caption).empty();
        $(caption).append($(element).children('.caption').html());

        $('.slideshow img').attr('id', id);

        if (currElement) {
            $(currElement).removeClass(selectStyle);
        }

        $(element).addClass(selectStyle);
        currElement = element;

        event.preventDefault();
        return false;
    },

    agregarNavegacion: function () {
        $(navegacion).css('display', 'block');
        $(navegacion).children('.prev').on('click', function (e) { $.galeria.recursoAnterior(e); });
        $(navegacion).children('.next').on('click', function (e) { $.galeria.recursoSiguiente(e); });
    },

    construirPaginacion: function () {
        $(paginacion).empty();

        if (paginaActual > 1) {
            $(paginacion).append('<a href="#" title="' + (paginaActual - 1) + '">Anterior</a>');
        }

        var totalPagAMostrar = 7;

        pagina = (paginaActual - 3 <= 0) ? 1 : paginaActual - 3;

        while (pagina <= totalPaginas && totalPagAMostrar > 0) {
            this.construirLinkPagina(pagina);
            pagina++;
            totalPagAMostrar--;
        }

        if (paginaActual < totalPaginas) {
            $(paginacion).append('<a href="#" title="' + (parseInt(paginaActual) + 1) + '">Siguiente</a>');
        }

        $(paginacion).find('a').click(function (e) {
            var pag = $(this).attr('title');
            $.galeria.cambiarPagina(pag);
        });
    },

    construirLinkPagina: function (nroPagina) {
        if (nroPagina == paginaActual)
            $(paginacion).append('<span class="current">' + nroPagina + '</span>');
        else if (nroPagina < totalPaginas) {
            var resourceIndex = nroPagina * this.numThumbs;
            $(paginacion).append('<a href="#' + nroPagina + '" title="' + nroPagina + '">' + nroPagina + '</a>');
        }

        return this;
    },

    recargarImagenes: function (data) {
        (thumbs).empty();
        $.each(data, function (index, node) {
            var src = (node.ruta).replace('~', '');

            var res = $('<img>').attr({ 'id': node.id, 'src': src, 'alt': node.nombre });
            var a = $('<a>').attr({ 'class': 'thumb', 'href': src, 'title': node.nombre }).append(res);

            var reportar = $('<img>').attr({ 'id': "@imagen.id", 'class': "reportar", 'src': "../../Content/Resources/General/Alert.png", 'width': "32px", 'height': "32px", 'alt': "Reportar", 'onclick': "repotarRecurso()" });
            var caption = $('<div>').attr('class', 'caption')
                                    .append('<div class="image-title">' + node.nombre + '</div>')
                                    .append('<div class="subido_por">Subido por: ' + node.subido_por + '</div>')
                                    .append(reportar);

            var li = $('<li>').append(a).append(caption);

            $(thumbs).append(li);
        });

        $.galeria.init();
    },

    recargarAudios: function (data) {
        (thumbs).empty();
        $.each(data, function (index, node) {
            var src = (node.ruta).replace('~', '');

            var a = $('<a>').attr({ 'class': 'thumb', 'href': src, 'title': node.nombre }).append(node.nombre);
            var caption = $('<div>').attr('class', 'caption')
                                    .append('<div class="image-title">' + node.nombre + '</div>')
                                    .append('<div class="subido_por">Subido por: ' + node.subido_por + '</div>');

            var li = $('<li>').append(a).append(caption);

            $(thumbs).append(li);
        });

        $.galeria.init();
    },

    recargarVideos: function (data) {
        (thumbs).empty();
        $.each(data, function (index, node) {
            var src = (node.ruta).replace('~', '');

            var a = $('<a>').attr({ 'class': 'thumb', 'href': src, 'title': node.nombre }).append(node.nombre);

            var reportar = $('<img>').attr({ 'id': "@imagen.id", 'class': "reportar", 'src': "../../Content/Resources/General/Alert.png", 'width': "32px", 'height': "32px", 'alt': "Reportar", 'onclick': "repotarRecurso()" });
            var caption = $('<div>').attr('class', 'caption')
                                    .append('<div class="image-title">' + node.nombre + '</div>')
                                    .append('<div class="subido_por">Subido por: ' + node.subido_por + '</div>')
                                    .append(reportar);

            var li = $('<li>').append(a).append(caption);

            $(thumbs).append(li);
        });

        $.galeria.init();
    },

    setTotalRecursos: function (cantidad) {
        totalRecursos = cantidad;
        $.galeria.calcularTotalPaginas();
    },

    calcularTotalPaginas: function () {
        var aux = (totalRecursos % recursosPorPagina > 0) ? 1 : 0;
        totalPaginas = Math.floor(totalRecursos / recursosPorPagina) + aux;
    }
};

$.fn.galeria = function (opciones) {
    thumbs = this;
    contentRecurso = opciones.content;
    caption = opciones.caption;
    navegacion = opciones.navegacion;
    paginacion = opciones.paginacion;
    cambiarPagCallback = opciones.cambiarPagCallback;

    selectStyle = opciones.selectStyle;

    totalRecursos = opciones.totalRecursos;
    recursosPorPagina = opciones.recursosPorPagina;
    paginaActual = 1;

    $.galeria.init();
};