function Criterio() {
    this.id = -1;
    this.nombre = "";
    this.intervalos = new Array();
    this.intervalos.push(new Intervalo(-1, 0, "", -1, null));
    this.intervalos.push(new Intervalo(-1, 100, "", -1, null));
}

function Intervalo(prev, value, res, db_id, file) {
    this.value = value;
    this.db_id = db_id;
    this.file = file;

    if (value == 0) 
        return 1;

    var weight = 769 / 100;

    var min = prev;
    var max = value * weight;
    var line_width = max - min;

    if (res == "")
        res = "../../Content/Resources/Actividad/carita-feliz.png";
    else
        res = res.replace("~", "../..");

    var span = $('<span>');
    var img = $('<div id="panel_imagen">').append('<img id="img_foreground" src="' + res + '")">');

    var img_cambiar = $('<img src="../../Content/Resources/Actividad/ic_refresh.png" width="24px" height="24px" onclick="cambiarImage(' + value + ')">');
    var img_eliminar = $('<img src="../../Content/Resources/Actividad/ic_delete.png" width="24px" height="24px" onclick="eliminarImage(' + value + ')">');

    var img_op = $('<div id="img_opciones">').append(img_cambiar);
    if (value < 100) img_op.append(img_eliminar);

    img.append(img_op);

    span.append(img);

    var div = $('<div>');
    var p = $('<p>').text(value);

    var li = $('<li>').append(span).append(div).append(p);
    $(li).css('left', (max) + 'px');

    this.html = li;
}

Criterio.prototype.agregarIntervalo = function (val, res, id_res) {
    var value = parseInt(val);
    if (value <= 0 || value >= 100) return -1;

    var pos = -1;
    for (i in this.intervalos) {
        var next_pos = parseInt(i) + 1;
        if (value > this.intervalos[i].value && value < this.intervalos[next_pos].value) {
            var prev = this.intervalos[i].value;
            this.intervalos.splice(next_pos, 0, new Intervalo(prev, parseInt(value), res, id_res, null));

            pos = next_pos;

            break;
        }
    }

    return (pos != -1) ? this.intervalos[pos].html[0] : null;
}

Criterio.prototype.setImagen = function (val, src, f) {
    var value = parseInt(val);
    var pos = -1;

    for (i in this.intervalos) {
        var next_pos = parseInt(i) + 1;
        if (value == this.intervalos[i].value) {
            pos = i;
            break;
        }
    }

    if (Number(f))
        this.intervalos[pos].db_id = f;
    else 
        this.intervalos[pos].file = f;
    $(this.intervalos[pos].html).children('span').children('#panel_imagen').children('#img_foreground').attr('src', src);
}

Criterio.prototype.quitarIntervalo = function (val, res) {
    var value = parseInt(val);
    if (value <= 0 || value >= 100) return -1;

    var pos = -1;

    for (i in this.intervalos) {
        
        var next_pos = parseInt(i) + 1;
        if (value == this.intervalos[i].value) {
            var prev = this.intervalos[i].value;
            this.intervalos.splice(i, 1);
            return i;
        }
    }
}

Criterio.prototype.getIntervalo = function (pos) {
    return this.intervalos[pos];
}

Criterio.prototype.guardarCriterio = function () {
    this.nombre = $("#txt_nombre")[0].value;

    var fd = new FormData();
    fd.append('id', this.id);
    fd.append('nombre', this.nombre);
    fd.append('intervalos', JSON.stringify(this.intervalos));

    var in_array = new Array();
    for (i in this.intervalos) {
        if (this.intervalos[i].file != null)
            fd.append(this.intervalos[i].value, this.intervalos[i].file);
    }

    var criterio = this;

    var xhr = new XMLHttpRequest();
    xhr.open('post', '/Criterio/GuardarCriterio', true);
    xhr.send(fd);
    xhr.onreadystatechange = function () {
        if (this.readyState == 4 && this.status == 200) {
            var val = JSON.parse(xhr.responseText);
            var exists = 0 != $('select#select_criterio option[value=' + val + ']').length;
            if (!exists) {
                var option = $('<option value="' + val + '" >' + criterio.nombre + '</option>');
                $("select#select_criterio").append(option);
            }

            $("select#select_criterio")[0].value = val;
        }
    }
}

Criterio.prototype.recuperarCriterio = function (id) {
    this.id = id;

    var _criterio = this;
    $.post("/Criterio/GetCriterio", { id: id }, function (data) {
        var val = "0";
        var res = "";
        var i = 0;
        for (i in data.ids) {
            id_res = data.ids[i];
            val = data.values[i];
            res = data.src[i];

            var intervalo = _criterio.agregarIntervalo(val, res, id_res);
            if (intervalo != "-1") {
                $("#timeline_container > #timeline > ul").append(intervalo);
            }

            if (val == "100") {
                var ultimo_intervalo = _criterio.intervalos[_criterio.intervalos.length - 1];
                ultimo_intervalo.db_id = id_res;

                if (id_res == "-1")
                    res = "../../Content/Resources/Actividad/carita-feliz.png";
                else
                    res = res.replace("~", "../..");

                $(ultimo_intervalo.html[0]).children('span').children('#panel_imagen').children('#img_foreground').attr('src', res);
                $("#timeline_container > #timeline > ul").append(ultimo_intervalo.html[0]);
            }
        }



        $.each($("#timeline>ul>li>span"), function (key, value) {
            $(this).find("#img_opciones").css('display', 'none');
        });

    });
}

Criterio.prototype.nuevoCriterio = function () {
    var ultimo_intervalo = _criterio.intervalos[_criterio.intervalos.length - 1];
    var res = "../../Content/Resources/Actividad/carita-feliz.png";
    $(ultimo_intervalo.html[0]).children('span').children('#panel_imagen').children('#img_foreground').attr('src', res);
    $("#timeline_container > #timeline > ul").append(ultimo_intervalo.html[0]);

    $("select#select_criterio")[0].value = "0";
}