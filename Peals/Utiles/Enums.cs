public enum TipoDeUsuario
{
    Administrador = 1, 
    Docente = 2, 
    Alumno = 3
}

public enum TipoDeRecurso
{
    Imagen = 1,
    Audio = 2,
    Video = 3,
    Texto = 4
}

public enum EstadoUsuario
{
    EsperandoConfirmacion = 1,
    DeAlta = 2,
    DeBaja = 3
}

public enum TipoSolicitud
{
    inscripcionCurso = 1,
    inscripcionInstitucion = 2,
    inscripcionDocente = 3,
    asignarDocenteACurso = 4,
    asignarAlumnoACurso = 5
}

public enum TipoDiac
{
    unaLinea = 1,
    multiplesLineas = 2,
    conOpciones = 3,
    conAdjunto = 4
}

public enum EstadoActividad
{
    Alta = 1,
    ConHistorial = 2,
    Baja = 3
}

public enum EstadoRecurso
{
    Alta = 1,
    ConHistorial = 2,
    Baja = 3
}

public enum EstadoCurso
{
    Alta = 1,
    Baja = 3
}

public enum SolucionActividad
{
    Opciones = 1,
    Escribir = 2,
    Senias = 3
}
