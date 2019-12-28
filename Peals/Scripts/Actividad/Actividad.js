function Actividad()
{
    this.nombre = "";
    this.explicacion = "";
    this.video = "";
    this.ejercicios = new Array();
    this.siguienteID = 0;
}

Actividad.prototype.agregarEjercicio = function () {
    var id = ++this.siguienteID;
    var ejercicio = new Ejercicio(id);
    this.ejercicios.push(ejercicio);
    return ejercicio;
}

Actividad.prototype.getEjercicio = function (id) {
    var pos = -1;
    for (i in this.ejercicios) {
        if (this.ejercicios[i].id == id) {
            pos = i;
            break;
        }
    }

    if (pos != -1) {
        return this.ejercicios[pos];
    }

    return null;
}

Actividad.prototype.eliminarEjercicio = function (id) {
    var pos = -1;
    for (i in this.ejercicios) {
        if (this.ejercicios[i].id == id) {
            pos = i;
            break;
        }
    }

    if (pos != -1) {
        $(this.ejercicios[pos].html).remove();
        this.ejercicios.splice(pos, 1);
        return true;
    }

    return false;
}

Actividad.prototype.sonEjerciciosBienFormulados = function () {
    var ret = true;
    for (i in this.ejercicios) {
        if (this.ejercicios[i].recursos == 0 || this.ejercicios[i].solucion.tipo == 0 || 
          (this.ejercicios[i].solucion.tipo != 0 && !this.ejercicios[i].solucion.respuesta))
        {
            ret = false;
            break;
        }
    }

    return ret;
}