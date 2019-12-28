
function cargarProvincias(){
    var accion = "/Domicilio/ProvinciaPorPais";
    fillCombo("usuario_provincia", $("#usuario_pais").val(), accion);
}

function cargarLocalidades(){
    var accion = "/Domicilio/LocalidadPorProvincia";
    fillCombo("usuario_localidad", $("#usuario_provincia").val(), accion);
}

/** Limpia los valores del combo box pasado por parámetro y agrega una opción
  * por defecto en la posición 0.
  * Parameters:
  *     - updateId: Str. Combo a limpiar.
  */
function cleanCombo(updateId) {
    $("#" + updateId).empty();
    $("#" + updateId).append("<option value=''>Seleccionar " + updateId.substring(8, updateId.length) + "</option>");
}

// toma los datos y pone los datos en el combo q le indicas por parametro (updateId)
function fillCombo(updateId, value, accion) {
    $.getJSON(accion
        + "/" + value,
        function (data) {
            cleanCombo(updateId);
            $.each(data, function (i, item) {
                $("#" + updateId).append("<option value='"
                    + item.Value + "'>" + item.Text
                    + "</option>");
            });
        });
}

$(document).ready(function () {
    //al seleccionar otro pais                  
    $("#usuario_pais").change(function () {
        if ($("#usuario_pais").val() == '') //osea "Seleccionar Pais"... antes estaba con selectedIndex y value y devolvian un valor "undefined".. si hay problemas, tener en cuenta esto
        {
            // Si se selecciona la opcion "Seleccionar Pais" (opción 0), limpio los combos de provincias y localidades.
            cleanCombo("usuario_localidad");
            cleanCombo("usuario_provincia");
        }
        else {
            cargarProvincias();
        }
    });

    //al seleccionar otra provincia
    $("#usuario_provincia").change(function () {
        if ($("#usuario_provincia").val() == '') //osea "Seleccionar Provincia"
        {
            cleanCombo("usuario_localidad");
        }
        else {
            cargarLocalidades();
        }
    });
});