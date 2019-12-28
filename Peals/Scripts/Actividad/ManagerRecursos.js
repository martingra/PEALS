function ManagerRecursos() {
    this.paginaImagenes = 1;
    this.paginaAudios = 1;
    this.paginaVideos = 1;
    this.imagenesPorPagina = 20;
    this.audiosPorPagina = 15;
    this.videoPorPagina = 15;
    this.imagenesSeleccionadas = new Array();
    this.audiosSeleccionados = new Array();
    this.videoSeleccionados = new Array();

    this.imagenesCargadas = new Array();
    this.audiosCargados = new Array();
    this.videosCargados = new Array();

    this._playing = null;
}

ManagerRecursos.prototype.getImagenes = function () {
    $("#contenido_recursos").empty();
    $("#contenido_recursos").addClass('scrollbar-ext');

    var manager = this;
    var filtro = $("#txt_buscarRecurso")[0].value;

    var values = { "tipo": 1, "filtro": filtro, "pagina": this.paginaImagenes, "limite": this.imagenesPorPagina, "resCargados": null };
    $.post('/Recurso/GetRecursosAsJson', values, function (data) {
        //        data.total += manager.imagenesCargadas.length;
        if (manager.paginaImagenes == 1 && filtro == "") {
            for (var j in manager.imagenesCargadas) {
                var img_content = $('<div>').attr({ 'id': manager.imagenesCargadas[j].id, 'name': manager.imagenesCargadas[j].src, 'class': 'rContent_img' });
                var img = $('<img>').attr({ 'class': 'image', 'src': manager.imagenesCargadas[j].src }).on('click', function (event) { manager.agregarImagenALista(this.parentNode, manager); stopPropagation(event); });
                var img_check = $('<img>').attr({ 'class': 'img_check', 'src': '../../Content/Resources/Actividad/check.png' }).on('click', function (event) { manager.quitarImagenDeLista(this.parentNode, manager); stopPropagation(event); });
                img_content.append(img).append(img_check);

                $("#contenido_recursos").append(img_content);
            }
        }

        for (var i in data.recursos) {
            var img_content = $('<div>').attr({ 'id': data.recursos[i].id, 'name': data.recursos[i].ruta.replace("~", "../.."), 'class': 'rContent_img' });
            var img = $('<img>').attr({ 'class': 'image', 'src': data.recursos[i].ruta.replace("~", "../.."), 'alt': data.recursos[i].nombre }).on('click', function (event) { manager.agregarImagenALista(this.parentNode, manager); stopPropagation(event); });
            var img_check = $('<img>').attr({ 'class': 'img_check', 'src': '../../Content/Resources/Actividad/check.png' }).on('click', function (event) { manager.quitarImagenDeLista(this.parentNode, manager); stopPropagation(event); });
            img_content.append(img).append(img_check);

            $("#contenido_recursos").append(img_content);
        }

        var paginas = Math.floor(data.total / manager.imagenesPorPagina) + 1;

        var callback_inicio = function () { manager.paginaImagenes = 1; manager.getImagenes(); };
        var callback_anterior = function () { if (manager.paginaImagenes > 1) { manager.paginaImagenes -= 1; manager.getImagenes(); } };
        var callback_pagina = function () { manager.paginaImagenes = parseInt($(this).text()); manager.getImagenes(); };
        var callback_siguiente = function () { if (manager.paginaImagenes < paginas) { manager.paginaImagenes += 1; manager.getImagenes(); } };
        var callback_fin = function () { manager.paginaImagenes = paginas; manager.getImagenes(); };
        manager.crearPaginado(manager.paginaImagenes, manager.imagenesPorPagina, data.total, callback_inicio, callback_anterior, callback_pagina, callback_siguiente, callback_fin);
    });
}

ManagerRecursos.prototype.getAudios = function () {
    $("#contenido_recursos").empty();
    $("#contenido_recursos").removeClass('scrollbar-ext');
    this._playing = null;

    var player = $('<div>').attr('class', 'audio_player');
    var audio = $('<audio>').attr({ 'id': "audio_player", 'src': "", 'type': "audio/mp3", 'controls': "controls" });

    player.append($('<h2>').text(" -- NADA PARA REPRODUCIR --")).append(audio);

    $("#contenido_recursos").append($('<div>').attr('class', 'audio_list scrollbar-ext'));
    $("#contenido_recursos").append(player);

    var manager = this;
    var filtro = $("#txt_buscarRecurso")[0].value;

    var values = { "tipo": 2, "filtro": filtro, "pagina": this.paginaAudios, "limite": this.audiosPorPagina, "resCargados": null };
    $.post('/Recurso/GetRecursosAsJson', values, function (data) {
        //        data.total += manager.audiosCargados.length;
        if (manager.paginaAudios == 1 && filtro == "") {
            for (var j in manager.audiosCargados) {
                var audio_content = $('<div>').attr({ 'id': manager.audiosCargados[j].id, 'class': 'rContent_audio', 'name': manager.audiosCargados[j].src, 'alt': '' }).on('click', function (event) { manager.playAudio(this, manager); stopPropagation(event); });
                var img_play = $('<img>').attr({ 'id': 'img_play', 'src': '../../Content/Resources/Actividad/ic_play.png' });
                var img_add = $('<img>').attr({ 'id': 'img_add', 'src': '../../Content/Resources/Actividad/ic_plus.png' }).on('click', function (event) { manager.agregarAudioALista(this.parentNode, manager); stopPropagation(event); });
                var img_check = $('<img>').attr({ 'id': 'img_menos', 'src': '../../Content/Resources/Actividad/ic_menos.png' }).on('click', function (event) { manager.quitarAudioDeLista(this.parentNode, manager); stopPropagation(event); });
                var nombre = $('<h2>').text(manager.audiosCargados[j].file.name);

                audio_content.append(img_play).append(nombre).append(img_add).append(img_check);
                $("#contenido_recursos > .audio_list").append(audio_content);

                $(audio_content).hover(
                    function () {
                        $(this).css({ 'cursor': 'pointer', 'background': '#D0473E', 'color': 'white' });

                        var id = $(this).attr('id');
                        if (manager._playing == null || id != $(manager._playing).attr('id')) {
                            $(this).children('#img_play').css('visibility', 'visible');
                        }
                    }, function () {
                        var id = $(this).attr('id');
                        if (manager._playing == null || id != $(manager._playing).attr('id')) {
                            $(this).children('#img_play').css('visibility', 'hidden');
                        }

                        if ($(this).attr('alt') == '')
                            $(this).css({ 'background': 'none', 'color': 'black' });
                    }
                );
            }
        }

        for (var i in data.recursos) {
            var audio_content = $('<div>').attr({ 'id': data.recursos[i].id, 'class': 'rContent_audio', 'name': data.recursos[i].ruta.replace("~", "../.."), 'alt': '' }).on('click', function (event) { manager.playAudio(this, manager); stopPropagation(event); });
            var img_play = $('<img>').attr({ 'id': 'img_play', 'src': '../../Content/Resources/Actividad/ic_play.png' });
            var img_add = $('<img>').attr({ 'id': 'img_add', 'src': '../../Content/Resources/Actividad/ic_plus.png' }).on('click', function (event) { manager.agregarAudioALista(this.parentNode, manager); stopPropagation(event); });
            var img_check = $('<img>').attr({ 'id': 'img_menos', 'src': '../../Content/Resources/Actividad/ic_menos.png' }).on('click', function (event) { manager.quitarAudioDeLista(this.parentNode, manager); stopPropagation(event); });
            var nombre = $('<h2>').text(data.recursos[i].nombre);

            audio_content.append(img_play).append(nombre).append(img_add).append(img_check);
            $("#contenido_recursos > .audio_list").append(audio_content);

            $(audio_content).hover(
                function () {
                    $(this).css({ 'cursor': 'pointer', 'background': '#D0473E', 'color': 'white' });

                    var id = $(this).attr('id');
                    if (manager._playing == null || id != $(manager._playing).attr('id')) {
                        $(this).children('#img_play').css('visibility', 'visible');
                    }
                }, function () {
                    var id = $(this).attr('id');
                    if (manager._playing == null || id != $(manager._playing).attr('id')) {
                        $(this).children('#img_play').css('visibility', 'hidden');
                    }

                    if ($(this).attr('alt') == '')
                        $(this).css({ 'background': 'none', 'color': 'black' });
                }
            );
        }

        var paginas = Math.floor(data.total / manager.audiosPorPagina) + 1;

        var callback_inicio = function () { manager.paginaAudios = 1; manager.getAudios(); };
        var callback_anterior = function () { if (manager.paginaAudios > 1) { manager.paginaAudios -= 1; manager.getAudios(); } };
        var callback_pagina = function () { manager.paginaAudios = parseInt($(this).text()); manager.getAudio(); };
        var callback_siguiente = function () { if (manager.paginaAudios < paginas) { manager.paginaAudios += 1; manager.getAudios(); } };
        var callback_fin = function () { manager.paginaAudios = paginas; manager.getAudios(); };
        manager.crearPaginado(manager.paginaAudios, manager.audiosPorPagina, data.total, callback_inicio, callback_anterior, callback_pagina, callback_siguiente, callback_fin);
    });
}

ManagerRecursos.prototype.getVideos = function () {
    $("#contenido_recursos").empty();
    $("#contenido_recursos").removeClass('scrollbar-ext');
    this._playing = null;

    var player = $('<div>').attr('class', 'video_player');
    var video = $('<video>').attr({ 'id': "video_player", 'src': "", 'controls': "controls" });

    player.append($('<h2>').text(" -- NADA PARA REPRODUCIR --")).append(video);

    $("#contenido_recursos").append($('<div>').attr('class', 'video_list scrollbar-ext'));
    $("#contenido_recursos").append(player);

    var manager = this;
    var filtro = $("#txt_buscarRecurso")[0].value;

    var values = { "tipo": 3, "filtro": filtro, "pagina": this.paginaVideos, "limite": this.videoPorPagina, "resCargados": null };
    $.post('/Recurso/GetRecursosAsJson', values, function (data) {
        //        data.total += manager.videosCargados.length;
        if (manager.paginaVideos == 1 && filtro == "") {
            for (var j in manager.videosCargados) {
                var video_content = $('<div>').attr({ 'id': manager.videosCargados[j].id, 'class': 'rContent_video', 'name': manager.videosCargados[j].src, 'alt': '' }).on('click', function (event) { manager.playVideo(this, manager); });
                var img_play = $('<img>').attr({ 'id': 'img_play', 'src': '../../Content/Resources/Actividad/ic_play.png' });
                var img_add = $('<img>').attr({ 'id': 'img_add', 'src': '../../Content/Resources/Actividad/ic_plus.png' }).on('click', function (event) { manager.agregarVideoALista(this.parentNode, manager); stopPropagation(event); });
                var img_check = $('<img>').attr({ 'id': 'img_menos', 'src': '../../Content/Resources/Actividad/ic_menos.png' }).on('click', function (event) { manager.quitarVideoDeLista(this.parentNode, manager); stopPropagation(event); });
                var nombre = $('<h2>').text(manager.videosCargados[j].file.name);

                video_content.append(img_play).append(nombre).append(img_add).append(img_check);
                $("#contenido_recursos > .video_list").append(video_content);

                $(video_content).hover(
                    function () {
                        $(this).css({ 'cursor': 'pointer', 'background': '#D0473E', 'color': 'white' });

                        var id = $(this).attr('id');
                        if (manager._playing == null || id != $(manager._playing).attr('id')) {
                            $(this).children('#img_play').css('visibility', 'visible');
                        }
                    }, function () {
                        var id = $(this).attr('id');
                        if (manager._playing == null || id != $(manager._playing).attr('id')) {
                            $(this).children('#img_play').css('visibility', 'hidden');
                        }

                        if ($(this).attr('alt') == '')
                            $(this).css({ 'background': 'none', 'color': 'black' });
                    }
                );
            }
        }

        for (var i in data.recursos) {
            var video_content = $('<div>').attr({ 'id': data.recursos[i].id, 'class': 'rContent_video', 'name': data.recursos[i].ruta.replace("~", "../.."), 'alt': '' }).on('click', function (event) { manager.playVideo(this, manager); });
            var img_play = $('<img>').attr({ 'id': 'img_play', 'src': '../../Content/Resources/Actividad/ic_play.png' });
            var img_add = $('<img>').attr({ 'id': 'img_add', 'src': '../../Content/Resources/Actividad/ic_plus.png' }).on('click', function (event) { manager.agregarVideoALista(this.parentNode, manager); stopPropagation(event); });
            var img_check = $('<img>').attr({ 'id': 'img_menos', 'src': '../../Content/Resources/Actividad/ic_menos.png' }).on('click', function (event) { manager.quitarVideoDeLista(this.parentNode, manager); stopPropagation(event); });
            var nombre = $('<h2>').text(data.recursos[i].nombre);

            video_content.append(img_play).append(nombre).append(img_add).append(img_check);
            $("#contenido_recursos > .video_list").append(video_content);

            $(video_content).hover(
                function () {
                    $(this).css({ 'cursor': 'pointer', 'background': '#D0473E', 'color': 'white' });

                    var id = $(this).attr('id');
                    if (manager._playing == null || id != $(manager._playing).attr('id')) {
                        $(this).children('#img_play').css('visibility', 'visible');
                    }
                }, function () {
                    var id = $(this).attr('id');
                    if (manager._playing == null || id != $(manager._playing).attr('id')) {
                        $(this).children('#img_play').css('visibility', 'hidden');
                    }

                    if ($(this).attr('alt') == '')
                        $(this).css({ 'background': 'none', 'color': 'black' });
                }
            );
        }

        var paginas = Math.floor(data.total / manager.videoPorPagina) + 1;

        var callback_inicio = function () { manager.paginaVideos = 1; manager.getVideos(); };
        var callback_anterior = function () { if (manager.paginaVideos > 1) { manager.paginaVideos -= 1; manager.getVideos(); } };
        var callback_pagina = function () { manager.paginaVideos = parseInt($(this).text()); manager.getVideos(); };
        var callback_siguiente = function () { if (manager.paginaVideos < paginas) { manager.paginaVideos += 1; manager.getVideos(); } };
        var callback_fin = function () { manager.paginaVideos = paginas; manager.getVideos(); };
        manager.crearPaginado(manager.paginaVideos, manager.videoPorPagina, data.total, callback_inicio, callback_anterior, callback_pagina, callback_siguiente, callback_fin);
    });
}

ManagerRecursos.prototype.playAudio = function (id, manager) {
    var alt = $(id).attr('id');
    var src = $(id).attr('name');
    var name  = $(id).children("h2").text();

    $('.audio_player > h2').text(name);
    $('.audio_player > #audio_player').attr('src', src);

    $(id).children('#img_play').css('visibility', 'visible');

    if (manager._playing)
        $(manager._playing).children('#img_play').css('visibility', 'hidden');

    manager._playing = id;
}

ManagerRecursos.prototype.playVideo = function(id, manager){
    var alt = $(id).attr('id');
    var src = $(id).attr('name');
    var name  = $(id).children("h2").text();

    $('.video_player > h2').text(name);
    $('.video_player > #video_player').attr('src', src);

    $(id).children('#img_play').css('visibility', 'visible');

    if (manager._playing)
        $(manager._playing).children('#img_play').css('visibility', 'hidden');

    manager._playing = id;
}

ManagerRecursos.prototype.agregarImagenALista = function (id_object, manager) {
    $(id_object).children(".img_check").css('display', 'block');

    var id = $(id_object).attr('id');
    var src = $(id_object).attr('name');
    manager.imagenesSeleccionadas.push(new arrayObject(id, src));
}

ManagerRecursos.prototype.quitarImagenDeLista = function (id_object, manager) {
    $(id_object).children(".img_check").css('display', 'none');

    var id = $(id_object).attr('id');

    var pos = -1;
    for (i in manager.imagenesSeleccionadas) {
        if (manager.imagenesSeleccionadas[i].id == id) {
            pos = i;
            break;
        }
    }

    if (pos != -1) {
        manager.imagenesSeleccionadas.splice(pos, 1);
    }
}

ManagerRecursos.prototype.agregarAudioALista = function(id_object, manager) {
    manager.setCss(id_object, true);

    var id = $(id_object).attr('id');
    var src = $(id_object).attr('name');
    manager.audiosSeleccionados.push(new arrayObject(id, src));
}

ManagerRecursos.prototype.quitarAudioDeLista = function (id_object, manager) {
    manager.setCss(id_object, false);
    var id = $(id_object).attr('id');

    var pos = -1;
    for (i in manager.audiosSeleccionados) {
        if (manager.audiosSeleccionados[i].id == id) {
            pos = i;
            break;
        }
    }

    if (pos != -1) {
        manager.audiosSeleccionados.splice(pos, 1);
    }
}

ManagerRecursos.prototype.agregarVideoALista = function (id_object, manager) {
    manager.setCss(id_object, true);

    var id = $(id_object).attr('id');
    var src = $(id_object).attr('name');
    manager.videoSeleccionados.push(new arrayObject(id, src));
}

ManagerRecursos.prototype.quitarVideoDeLista = function (id_object, manager) {
    manager.setCss(id_object, false);
    var id = $(id_object).attr('id');

    var pos = -1;
    for (i in manager.videoSeleccionados) {
        if (manager.videoSeleccionados[i].id == id) {
            pos = i;
            break;
        }
    }

    if (pos != -1) {
        manager.videoSeleccionados.splice(pos, 1);
    }
}

ManagerRecursos.prototype.setCss = function(id, add) {
    if (add){
        $(id).attr('alt', 'Agregado');
        $(id).css({ 'background': '#D0473E', 'color': 'white' });
        $(id).children('#img_add').css('display', 'none');
        $(id).children('#img_menos').css('display', 'block');
    } else{
        $(id).attr('alt', '');
        $(id).css({ 'background': 'none', 'color': 'black' });
        $(id).children('#img_menos').css('display', 'none');
        $(id).children('#img_add').css('display', 'block');
    }
}

ManagerRecursos.prototype.crearPaginado = function (paginaActual, itemsPorPagina, total, callback_inicio, callback_anterior, callback_pagina, callback_siguiente, callback_fin) {
    $("#paginacion").empty();

    var paginas = Math.floor(total / itemsPorPagina) + 1;
    if (paginas > 1) {
        var pInicio = $("<p>").text("<<").on('click', callback_inicio);
        var pAnterior = $("<p>").text("<").on('click', callback_anterior);
        $("#paginacion").append(pInicio).append(pAnterior);

        for (pag = 1; pag <= paginas; pag++) {
            var p = $("<p>").text(pag).on('click', callback_pagina);
            $("#paginacion").append(p);
        }

        var pSiguiente = $("<p>").text(">").on('click', callback_siguiente);
        var pFin = $("<p>").text(">>").on('click', callback_fin);
        $("#paginacion").append(pSiguiente).append(pFin);
    }
}

ManagerRecursos.prototype.agregarRecurso = function (lista, id, src, file) {
    var pos = -1;
    for (i in lista) {
        if (lista[i].id == id) {
            pos = i;
            lista[i].count+=1;
            break;
        }
    }

    if (pos == -1) {
        lista.push(new arrayObject(id, src, file));
    }
}

ManagerRecursos.prototype.quitarRecurso = function (lista, id) {
    var pos = -1;
    for (i in lista) {
        if (lista[i].id == id) {
            pos = i;
            lista[i].count -= 1;
            break;
        }
    }
}

ManagerRecursos.prototype.getFile = function (lista, id) {
    var pos = -1;
    var file = null;
    for (i in lista) {
        if (lista[i].id == id) {
            pos = i;
            file = (lista[i].count == 0)? lista[i].file : null;
            break;
        }
    }

    return file;
}

function stopPropagation(e) {
    if (!e) e = window.event;
    //IE9 & Other Browsers
    if (e.stopPropagation) { e.stopPropagation(); }
    //IE8 and Lower
    else { e.cancelBubble = true; }
}

function arrayObject(id, src, file){
    this.id = id;
    this.src = src;
    this.file = file;
    this.count = 1;
}