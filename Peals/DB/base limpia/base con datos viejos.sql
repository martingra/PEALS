-- phpMyAdmin SQL Dump
-- version 4.2.11
-- http://www.phpmyadmin.net
--
-- Servidor: 127.0.0.1
-- Tiempo de generación: 15-02-2016 a las 23:53:17
-- Versión del servidor: 5.6.21
-- Versión de PHP: 5.6.3

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;

--
-- Base de datos: `peals`
--

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `actividad`
--

CREATE TABLE IF NOT EXISTS `actividad` (
`id` int(11) NOT NULL,
  `nombre` varchar(150) DEFAULT NULL,
  `fecha_alta` date DEFAULT NULL,
  `es_publica` int(11) DEFAULT NULL,
  `docente` int(11) DEFAULT NULL,
  `descripcion` varchar(1000) DEFAULT NULL,
  `estado` int(11) DEFAULT NULL,
  `criterio` int(11) DEFAULT NULL,
  `videoExplicacion` varchar(45) DEFAULT NULL
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=utf8;

--
-- Volcado de datos para la tabla `actividad`
--

INSERT INTO `actividad` (`id`, `nombre`, `fecha_alta`, `es_publica`, `docente`, `descripcion`, `estado`, `criterio`, `videoExplicacion`) VALUES
(1, 'Test de señas', '2015-11-29', NULL, 6, 'Activiad para probar el uso de señas', 1, NULL, NULL),
(2, 'Test con texto', '2015-11-29', NULL, 6, 'Actividad prueba resolucion con texto', 1, NULL, NULL),
(3, 'Test señas y texto', '2015-12-24', NULL, 6, 'Actividad para probar que anda bien señas y texto juntos', 1, NULL, NULL),
(4, 'Test elegir recurso', '2015-12-24', NULL, 6, 'Actividad para probar elegir recurso', 1, NULL, NULL),
(5, 'borrar', '2015-12-24', NULL, 6, 'borrar', 1, NULL, NULL),
(6, 'borrar 2', '2015-12-24', NULL, 6, 'borrar', 1, NULL, NULL);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `actividad_x_curso`
--

CREATE TABLE IF NOT EXISTS `actividad_x_curso` (
`id` int(11) NOT NULL,
  `actividad` int(11) DEFAULT NULL,
  `curso` int(11) DEFAULT NULL,
  `fecha_apertura` datetime DEFAULT NULL
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8;

--
-- Volcado de datos para la tabla `actividad_x_curso`
--

INSERT INTO `actividad_x_curso` (`id`, `actividad`, `curso`, `fecha_apertura`) VALUES
(2, 2, 4, '2015-11-29 00:00:00'),
(3, 1, 4, '2015-11-29 00:00:00'),
(4, 3, 4, '2015-11-29 00:00:00'),
(5, 4, 4, '2015-11-29 00:00:00');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `adjuntos`
--

CREATE TABLE IF NOT EXISTS `adjuntos` (
`id` int(11) NOT NULL,
  `mensaje` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `alumno_x_curso`
--

CREATE TABLE IF NOT EXISTS `alumno_x_curso` (
`id` int(11) NOT NULL,
  `alumno` int(11) DEFAULT NULL,
  `curso` int(11) DEFAULT NULL,
  `fecha_asignacion` date DEFAULT NULL
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8;

--
-- Volcado de datos para la tabla `alumno_x_curso`
--

INSERT INTO `alumno_x_curso` (`id`, `alumno`, `curso`, `fecha_asignacion`) VALUES
(1, 16, 4, '2015-07-10'),
(2, 17, 8, '2016-01-05'),
(3, 16, 7, '2016-01-06');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `alumno_x_institucion`
--

CREATE TABLE IF NOT EXISTS `alumno_x_institucion` (
`id` int(11) NOT NULL,
  `alumno` int(11) DEFAULT NULL,
  `institucion` int(11) DEFAULT NULL,
  `fecha_alta` date DEFAULT NULL
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8;

--
-- Volcado de datos para la tabla `alumno_x_institucion`
--

INSERT INTO `alumno_x_institucion` (`id`, `alumno`, `institucion`, `fecha_alta`) VALUES
(1, 16, 1, '2016-01-06');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `criterio_evaluacion`
--

CREATE TABLE IF NOT EXISTS `criterio_evaluacion` (
`id` int(11) NOT NULL,
  `docente` int(11) DEFAULT NULL,
  `intervalo` int(11) DEFAULT NULL
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8;

--
-- Volcado de datos para la tabla `criterio_evaluacion`
--

INSERT INTO `criterio_evaluacion` (`id`, `docente`, `intervalo`) VALUES
(1, 5, 1),
(2, 5, 2);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `curso`
--

CREATE TABLE IF NOT EXISTS `curso` (
`id` int(11) NOT NULL,
  `turno` int(11) DEFAULT NULL,
  `nivel` int(11) DEFAULT NULL,
  `ano` int(11) DEFAULT NULL,
  `division` varchar(30) DEFAULT NULL,
  `docente` int(11) DEFAULT NULL,
  `institucion` int(11) DEFAULT NULL,
  `es_publico` tinyint(1) DEFAULT NULL,
  `nombre` varchar(45) DEFAULT NULL,
  `descripcion` varchar(200) DEFAULT NULL,
  `estado` int(11) DEFAULT NULL
) ENGINE=InnoDB AUTO_INCREMENT=10 DEFAULT CHARSET=utf8;

--
-- Volcado de datos para la tabla `curso`
--

INSERT INTO `curso` (`id`, `turno`, `nivel`, `ano`, `division`, `docente`, `institucion`, `es_publico`, `nombre`, `descripcion`, `estado`) VALUES
(1, 1, 2, 1, 'A', NULL, 1, NULL, 'Curso general 1A', 'Actividades generales para soporte a educación en el curso 1A.', 1),
(2, 1, 2, 1, 'B', NULL, 1, NULL, 'Curso general 1B', 'Actividades generales para el curso 1B', 1),
(3, 1, 2, 2, 'A', NULL, 1, NULL, 'Curso general 2A', 'Actividades generales para el curso 2A', 3),
(4, 1, 2, 2, 'B', 6, 1, NULL, 'Curso general 2B', 'Actividades generales 2B', 1),
(5, 1, 2, 3, 'A', 7, 1, NULL, 'Curso general 3A', 'Actividades generales para el curso 3A', 1),
(6, 1, 2, 3, 'B', NULL, 1, NULL, 'Curso general 3B', 'Actividades generales 3B', 1),
(7, 1, 2, 4, 'A', 6, 1, NULL, 'Curso general 4', 'Actividades generales 4A', 1),
(8, 1, 2, 5, 'A', 6, 1, NULL, 'Curso general 5', 'Actividades generales para 5to año', 1),
(9, 1, 2, 6, 'A', NULL, 1, NULL, 'Curso general 6', 'Actividades generales para el curso de 6to grado.', 3);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `diac`
--

CREATE TABLE IF NOT EXISTS `diac` (
`id` int(11) NOT NULL,
  `institucion` int(11) DEFAULT NULL,
  `activo` int(11) DEFAULT NULL
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8;

--
-- Volcado de datos para la tabla `diac`
--

INSERT INTO `diac` (`id`, `institucion`, `activo`) VALUES
(1, 1, 0),
(2, 1, 1);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `docente_x_institucion`
--

CREATE TABLE IF NOT EXISTS `docente_x_institucion` (
`id` int(11) NOT NULL,
  `docente` int(11) DEFAULT NULL,
  `institucion` int(11) DEFAULT NULL,
  `fecha_alta` date DEFAULT NULL
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8;

--
-- Volcado de datos para la tabla `docente_x_institucion`
--

INSERT INTO `docente_x_institucion` (`id`, `docente`, `institucion`, `fecha_alta`) VALUES
(1, 6, 1, '2015-10-13'),
(2, 7, 1, '2015-10-13'),
(3, 8, 1, '2015-10-13');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `ejercicio`
--

CREATE TABLE IF NOT EXISTS `ejercicio` (
`id` int(11) NOT NULL,
  `texto_solucion` varchar(200) DEFAULT NULL,
  `deletreo` int(11) DEFAULT NULL,
  `recurso_correcto` int(11) DEFAULT NULL,
  `actividad` int(11) DEFAULT NULL,
  `senia` int(11) DEFAULT NULL
) ENGINE=InnoDB AUTO_INCREMENT=12 DEFAULT CHARSET=utf8;

--
-- Volcado de datos para la tabla `ejercicio`
--

INSERT INTO `ejercicio` (`id`, `texto_solucion`, `deletreo`, `recurso_correcto`, `actividad`, `senia`) VALUES
(1, NULL, 1, NULL, 1, 1),
(2, NULL, 1, NULL, 1, 2),
(3, NULL, 1, NULL, 1, 3),
(4, 'Pato', 1, NULL, 2, 3),
(5, 'Gato', 1, NULL, 2, 3),
(6, NULL, 1, NULL, 3, 1),
(7, NULL, 1, NULL, 3, 2),
(8, NULL, 1, NULL, 3, 3),
(9, 'Pato', 1, NULL, 3, NULL),
(10, 'Gato', 1, NULL, 3, NULL),
(11, NULL, 1, 4, 4, NULL);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `ejercicio_x_recurso`
--

CREATE TABLE IF NOT EXISTS `ejercicio_x_recurso` (
`id` int(11) NOT NULL,
  `ejercicio` int(11) DEFAULT NULL,
  `recurso` int(11) DEFAULT NULL,
  `pos_top` varchar(6) DEFAULT NULL,
  `pos_left` varchar(6) DEFAULT NULL
) ENGINE=InnoDB AUTO_INCREMENT=14 DEFAULT CHARSET=utf8;

--
-- Volcado de datos para la tabla `ejercicio_x_recurso`
--

INSERT INTO `ejercicio_x_recurso` (`id`, `ejercicio`, `recurso`, `pos_top`, `pos_left`) VALUES
(1, 1, 1, '20', '70'),
(2, 1, 3, '20', '170'),
(3, 4, 4, '20', '50'),
(4, 5, 5, '20', '250'),
(5, 4, 6, '20', '350'),
(6, 6, 1, '20', '70'),
(7, 6, 3, '20', '170'),
(8, 9, 4, '20', '50'),
(9, 10, 5, '20', '250'),
(10, 9, 6, '20', '350'),
(11, 11, 3, '20', '10'),
(12, 11, 4, '20', '300'),
(13, 11, 5, '20', '500');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `especialidad`
--

CREATE TABLE IF NOT EXISTS `especialidad` (
`id` int(11) NOT NULL,
  `nombre` varchar(150) DEFAULT NULL
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8;

--
-- Volcado de datos para la tabla `especialidad`
--

INSERT INTO `especialidad` (`id`, `nombre`) VALUES
(1, 'Discapacidad Intelectual'),
(2, 'Sordos e Hipoacúsicos'),
(3, 'Psicopedagogía'),
(4, 'Psicomotricidad'),
(5, 'Sociopedagogía');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `estado_mensaje`
--

CREATE TABLE IF NOT EXISTS `estado_mensaje` (
`id` int(11) NOT NULL,
  `nombre` varchar(50) DEFAULT NULL
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=utf8;

--
-- Volcado de datos para la tabla `estado_mensaje`
--

INSERT INTO `estado_mensaje` (`id`, `nombre`) VALUES
(1, 'Pendiente'),
(2, 'Leido'),
(3, 'Aceptado'),
(4, 'Rechazado'),
(5, 'Desasignado'),
(6, 'Notificado');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `estado_usuario`
--

CREATE TABLE IF NOT EXISTS `estado_usuario` (
`id` int(11) NOT NULL,
  `nombre` varchar(50) DEFAULT NULL
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8;

--
-- Volcado de datos para la tabla `estado_usuario`
--

INSERT INTO `estado_usuario` (`id`, `nombre`) VALUES
(1, 'Esperando Confirmacion'),
(2, 'De Alta'),
(3, 'De Baja');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `historial_actividad`
--

CREATE TABLE IF NOT EXISTS `historial_actividad` (
`id` int(11) NOT NULL,
  `alumno` int(11) NOT NULL,
  `docente` int(11) NOT NULL,
  `curso` int(11) NOT NULL,
  `institucion` int(11) DEFAULT NULL,
  `calificacion_docente` int(11) DEFAULT NULL,
  `calificacion_sistema` int(11) DEFAULT NULL,
  `fecha_realizacion` datetime DEFAULT NULL,
  `intentos` int(11) DEFAULT NULL,
  `actividad` int(11) DEFAULT NULL,
  `uso_ayuda_consigna` tinyint(1) DEFAULT NULL,
  `uso_ayuda_actividad` tinyint(1) DEFAULT NULL,
  `tiempo` time DEFAULT NULL,
  `ejerciciosNoResueltos` int(11) DEFAULT NULL,
  `totalEjercicios` int(11) DEFAULT NULL
) ENGINE=InnoDB AUTO_INCREMENT=10 DEFAULT CHARSET=utf8;

--
-- Volcado de datos para la tabla `historial_actividad`
--

INSERT INTO `historial_actividad` (`id`, `alumno`, `docente`, `curso`, `institucion`, `calificacion_docente`, `calificacion_sistema`, `fecha_realizacion`, `intentos`, `actividad`, `uso_ayuda_consigna`, `uso_ayuda_actividad`, `tiempo`, `ejerciciosNoResueltos`, `totalEjercicios`) VALUES
(1, 16, 6, 4, 1, 85, 54, '2015-12-10 00:00:00', 1, 1, 1, 0, '00:00:26', 1, 3),
(2, 16, 6, 4, 1, 100, 100, '2015-12-11 00:00:00', 1, 1, 0, 0, '00:00:16', 0, 3),
(3, 16, 6, 4, 1, NULL, 67, '2015-12-14 00:00:00', 1, 1, 0, 0, '00:01:16', 1, 3),
(4, 16, 6, 4, 1, 95, 80, '2015-12-14 21:01:18', 1, 1, 1, 0, '00:00:22', 0, 3),
(5, 16, 6, 4, 1, NULL, 0, '2015-12-17 20:47:59', 1, 2, 0, 0, '00:00:00', 2, 2),
(6, 16, 6, 4, 1, NULL, 100, '2015-12-21 19:39:36', 1, 2, 0, 0, '00:00:14', 0, 2),
(7, 16, 6, 4, 1, 100, 80, '2015-12-24 18:14:36', 1, 3, 0, 0, '00:00:31', 1, 5),
(8, 16, 6, 4, 1, NULL, 100, '2015-12-24 20:02:22', 1, 4, 0, 0, '00:00:11', 0, 1),
(9, 16, 6, 4, 1, NULL, 90, '2015-12-24 20:04:01', 3, 4, 0, 0, '00:00:09', 0, 1);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `informacion`
--

CREATE TABLE IF NOT EXISTS `informacion` (
`id` int(11) NOT NULL,
  `contenido` varchar(2000) DEFAULT NULL,
  `encabezado` varchar(500) DEFAULT NULL,
  `introduccion` varchar(1000) DEFAULT NULL,
  `imagen` varchar(150) DEFAULT NULL,
  `video` varchar(150) DEFAULT NULL
) ENGINE=InnoDB AUTO_INCREMENT=8 DEFAULT CHARSET=utf8;

--
-- Volcado de datos para la tabla `informacion`
--

INSERT INTO `informacion` (`id`, `contenido`, `encabezado`, `introduccion`, `imagen`, `video`) VALUES
(1, 'De la mano de la Sra. Adelina Alegre de Duret y un esforzado equipo de trabajo, el día 24 de Marzo de 1961 nace el Instituto Remedios Escalada de San Martín. Acorde con las demandas y posibilidades del mercado laboral de los años sesenta, su surgimiento estuvo inspirado por la necesidad de capacitar a los jóvenes a través de carreras cortas con una rápida salida laboral. Las primeras carreras fueron Confección del Vestido, Bordado a Máquina y Estenomecanografía, luego se agregaron Práctica Comercial y Dibujo Publicitario. \r<br />Por esos años, era muy difícil sostener la escuela ya que carecía de aportes estatales y el dictado de clases dependía de la predisposición de los docentes, que cobrarían su sueldo recién cuando se lograra el reconocimiento oficial. Otra de las limitaciones era la imposibilidad de contar con un edificio propio, por lo tanto, la escuela se veía obligada a abandonar, año a año, las diferentes sedes que iba ocupando en calidad de préstamo.', 'La excelencia del aprendizaje', 'El IRESM concibe al hombre como un ser racional y responsable, capaz de realizar opciones libres a partir de su condición de persona única e irrepetible. Así mismo, es un sujeto activo capaz de formular un proyecto de vida integral que contemple todas las dimensiones de su ser: biológica, psicológica, social, cultural y trascendente.', '~/Content/Resources/Uploads/logo_1.jpg', ''),
(2, 'Unase a esta institucion y comencemos a trabajar juntos para reducir la brecha entre personas.', 'El mejor técnico dentro del mejor hombre', 'Instituto técnico orientado a brindar educación integral y especializada en el área técnica.', '~/Content/Resources/Uploads/CARTASPic2.jpg', ''),
(3, 'Invitamos al público  en general a participar de este curso y ayudarnos a crear un aula virtual interactiva de calidad avanzada. Gracias!', 'Instituto Bernardo D''Elia', 'Instituo de enseñanza general, con especialidad en ciencias sociales, naturales y gestión.', '~/Content/Resources/Uploads/bernardo.jpg', ''),
(4, '', NULL, '', NULL, NULL),
(5, 'pertenece a la educación pública estatal, Educación Especial, Educación Especial Nivel Inicial, Educación Especial Primaria, Estimulación Temprana, Ayuda a la Integración Escolar, Estimulación Temprana - dirección: Santa Rosa 340 Centro Barrio Centro - (CP: 5000) Córdoba Capital, Capital, provincia de Córdoba', 'Instituto IBiS', 'Somos una institución de la ciudad de córdoba dedicada a la enseñanza especial.', '~/Content/Resources/Uploads/ibis.jpg', NULL),
(6, 'Unite a nuestros cursos y ayudanos a crecer', 'Nacional VCP', 'Colegio publico de la ciudad de villa carlos paz', NULL, NULL),
(7, 'Dean Funes', 'Dean Funes', 'Dean Funes', '~/Content/Resources/Uploads/1510YYYY194821', NULL);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `institucion`
--

CREATE TABLE IF NOT EXISTS `institucion` (
`id` int(11) NOT NULL,
  `nombre` varchar(100) DEFAULT NULL,
  `telefono` mediumtext,
  `calle` varchar(50) DEFAULT NULL,
  `altura_calle` int(11) DEFAULT NULL,
  `piso` int(11) DEFAULT NULL,
  `departamento` char(1) DEFAULT NULL,
  `localidad` int(11) DEFAULT NULL,
  `administrador` int(11) DEFAULT NULL,
  `fecha_alta` date DEFAULT NULL,
  `informacion` int(11) DEFAULT NULL
) ENGINE=InnoDB AUTO_INCREMENT=8 DEFAULT CHARSET=utf8;

--
-- Volcado de datos para la tabla `institucion`
--

INSERT INTO `institucion` (`id`, `nombre`, `telefono`, `calle`, `altura_calle`, `piso`, `departamento`, `localidad`, `administrador`, `fecha_alta`, `informacion`) VALUES
(1, 'Remedios de Escalada de San Martín', '03541427681', 'Estrada', 280, NULL, NULL, 203, 56, '2015-06-23', 1),
(2, 'Instituto Industrial Cristo Obrero', '03541420832', 'Solis', 189, NULL, NULL, 145, 56, '2015-06-28', 2),
(3, 'Instituto Bernardo D''Elia', '425879', 'Asuncion', 204, NULL, NULL, 395, 56, '2015-06-30', 3),
(4, 'Cabred', '0351425789', 'Deodoro Roca', NULL, NULL, NULL, 203, 56, '2015-07-02', 4),
(5, 'Instituto Bilingüe para sordos IBiS', '4332351', 'Santa Rosa ', 340, NULL, NULL, 203, 1, '2015-07-09', 5),
(6, 'Escuela Nacional Arturo Illia', '4258789', 'Av Uruguay', 1568, NULL, NULL, 210, 1, '2015-10-15', 6),
(7, 'Dean Funes', '154789658', 'Dean Funes', 1294, NULL, NULL, 203, 1, '2015-10-15', 7);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `intervalo`
--

CREATE TABLE IF NOT EXISTS `intervalo` (
`id` int(11) NOT NULL,
  `desde` int(11) DEFAULT NULL,
  `hasta` int(11) DEFAULT NULL,
  `recurso` int(11) DEFAULT NULL
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8;

--
-- Volcado de datos para la tabla `intervalo`
--

INSERT INTO `intervalo` (`id`, `desde`, `hasta`, `recurso`) VALUES
(1, 0, 50, 3),
(2, 50, 100, 3);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `item`
--

CREATE TABLE IF NOT EXISTS `item` (
`id` int(11) NOT NULL,
  `descripcion` varchar(200) DEFAULT NULL,
  `grupo` varchar(200) DEFAULT NULL,
  `ordenGrupo` int(11) DEFAULT NULL,
  `ordenItem` int(11) DEFAULT NULL,
  `diac` int(11) DEFAULT NULL,
  `seguimiento` int(11) DEFAULT NULL,
  `tipoItem` int(11) DEFAULT NULL,
  `estado` int(11) DEFAULT NULL,
  `ayuda` varchar(2000) DEFAULT NULL
) ENGINE=InnoDB AUTO_INCREMENT=15 DEFAULT CHARSET=utf8;

--
-- Volcado de datos para la tabla `item`
--

INSERT INTO `item` (`id`, `descripcion`, `grupo`, `ordenGrupo`, `ordenItem`, `diac`, `seguimiento`, `tipoItem`, `estado`, `ayuda`) VALUES
(1, 'Sexo', 'Datos Personales', 1, 3, 1, NULL, 3, NULL, ''),
(2, 'Nombre', 'Datos Personales', 1, 1, 1, NULL, 1, NULL, ''),
(3, 'Apellido', 'Datos Personales', 1, 2, 1, NULL, 1, NULL, ''),
(4, 'Dirección', 'Datos Generales', 2, 1, 1, NULL, 1, NULL, ''),
(5, 'Fotocopia DNI', 'Datos Generales', 2, 2, 1, NULL, 4, NULL, ''),
(6, 'Sexo', 'Datos Personales', 1, 3, 2, NULL, 3, NULL, ''),
(7, 'Nombre', 'Datos Personales', 1, 1, 2, NULL, 1, NULL, ''),
(8, 'Apellido', 'Datos Personales', 1, 2, 2, NULL, 1, NULL, ''),
(9, 'Dirección', 'Datos Generales', 2, 1, 2, NULL, 2, NULL, ''),
(10, 'Fotocopia DNI', 'Datos Generales', 2, 2, 2, NULL, 4, NULL, ''),
(11, 'Sexo', 'Datos Generales', 1, 3, NULL, 1, 3, NULL, ''),
(12, 'Conducta', 'Particulares', 2, 1, NULL, 1, 3, NULL, ''),
(13, 'Nombre y apellido', 'Datos Generales', 1, 1, NULL, 1, 1, NULL, ''),
(14, 'Apodo', 'Datos Generales', 1, 2, NULL, 1, 1, NULL, '');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `llenadoseguimiento`
--

CREATE TABLE IF NOT EXISTS `llenadoseguimiento` (
`id` int(11) NOT NULL,
  `fecha` date DEFAULT NULL,
  `docente` int(11) DEFAULT NULL,
  `alumno` int(11) DEFAULT NULL,
  `curso` int(11) DEFAULT NULL,
  `diac` int(11) DEFAULT NULL,
  `seguimiento` int(11) DEFAULT NULL
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8;

--
-- Volcado de datos para la tabla `llenadoseguimiento`
--

INSERT INTO `llenadoseguimiento` (`id`, `fecha`, `docente`, `alumno`, `curso`, `diac`, `seguimiento`) VALUES
(1, '2016-01-06', 6, 16, 4, 1, NULL),
(2, '2016-01-06', 6, 17, 8, 1, NULL),
(3, '2016-01-06', 6, 16, 4, 2, NULL),
(4, '2016-01-11', 6, 16, 4, NULL, 1);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `llenadoseguimientodetalle`
--

CREATE TABLE IF NOT EXISTS `llenadoseguimientodetalle` (
`id` int(11) NOT NULL,
  `llenadoseguimiento` int(11) DEFAULT NULL,
  `item` int(11) DEFAULT NULL,
  `adjunto` varchar(200) DEFAULT NULL,
  `opcion` int(11) DEFAULT NULL,
  `respuesta` varchar(1000) DEFAULT NULL
) ENGINE=InnoDB AUTO_INCREMENT=20 DEFAULT CHARSET=utf8;

--
-- Volcado de datos para la tabla `llenadoseguimientodetalle`
--

INSERT INTO `llenadoseguimientodetalle` (`id`, `llenadoseguimiento`, `item`, `adjunto`, `opcion`, `respuesta`) VALUES
(1, 1, 2, NULL, NULL, 'Martin'),
(2, 1, 3, NULL, NULL, 'Gramatica'),
(3, 1, 1, NULL, 1, NULL),
(4, 1, 4, NULL, NULL, 'El Redentor'),
(5, 1, 5, 'cabred.png', NULL, NULL),
(6, 2, 2, NULL, NULL, 'jhnk'),
(7, 2, 3, NULL, NULL, ''),
(8, 2, 1, NULL, 1, NULL),
(9, 2, 4, NULL, NULL, ''),
(10, 2, 5, NULL, NULL, NULL),
(11, 3, 7, NULL, NULL, 'Martin'),
(12, 3, 8, NULL, NULL, 'Gramatica'),
(13, 3, 6, NULL, 3, NULL),
(14, 3, 9, NULL, NULL, 'Esto es una\r\nprueba'),
(15, 3, 10, NULL, NULL, NULL),
(16, 4, 13, NULL, NULL, 'Adrian Mondolo'),
(17, 4, 14, NULL, NULL, 'Mondy'),
(18, 4, 11, NULL, 5, NULL),
(19, 4, 12, NULL, 9, NULL);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `localidad`
--

CREATE TABLE IF NOT EXISTS `localidad` (
`id` int(11) NOT NULL,
  `nombre` varchar(50) DEFAULT NULL,
  `provincia` int(11) DEFAULT NULL
) ENGINE=InnoDB AUTO_INCREMENT=658 DEFAULT CHARSET=utf8;

--
-- Volcado de datos para la tabla `localidad`
--

INSERT INTO `localidad` (`id`, `nombre`, `provincia`) VALUES
(1, 'Azul', 1),
(2, 'Puan', 1),
(3, 'La Matanza', 1),
(4, 'Tigre', 1),
(5, '25 De Mayo', 1),
(6, 'Trenque Lauquen', 1),
(7, '9 de Julio', 1),
(8, 'Lanus', 1),
(9, 'La Plata', 1),
(10, 'Monte', 1),
(11, 'Pehuajo', 1),
(12, 'San Isidro', 1),
(13, 'Pergamino', 1),
(14, 'Alberti', 1),
(15, 'Chascomus', 1),
(16, 'Esteban Echeverria', 1),
(17, 'Mercedes', 1),
(18, 'Bahia Blanca', 1),
(19, 'Merlo', 1),
(20, 'Junin', 1),
(21, 'Guamini', 1),
(22, 'Lujan', 1),
(23, 'Leandro N. Alem', 1),
(24, 'Matanza', 1),
(25, 'General Paz', 1),
(26, 'San Vicente', 1),
(27, 'Cañuelas', 1),
(28, 'Almirante Brown', 1),
(29, 'Cnl. De Marina L. Rosales', 1),
(30, 'Baradero', 1),
(31, 'Saavedra', 1),
(32, 'Brandsen', 1),
(33, 'General Sarmiento', 1),
(34, 'Tapalque', 1),
(35, 'Saladillo', 1),
(36, 'Magdalena', 1),
(37, 'Gonzales Chaves', 1),
(38, 'General Pinto', 1),
(39, 'Navarro', 1),
(40, 'Daireaux', 1),
(41, 'Lobos', 1),
(42, 'Coronel Dorrego', 1),
(43, 'Adolfo Alsina', 1),
(44, 'Colon', 1),
(45, 'General Arenales', 1),
(46, 'Lincoln', 1),
(47, 'Villarino', 1),
(48, 'Vicente Lopez', 1),
(49, 'Bartolome Mitre', 1),
(50, 'Exaltacion De La Cruz', 1),
(51, 'Salto', 1),
(52, 'Bragado', 1),
(53, 'Zarate', 1),
(54, 'Avellaneda', 1),
(55, 'Ayacucho', 1),
(56, 'San Andres De Giles', 1),
(57, 'Tandil', 1),
(58, 'Rivadavia', 1),
(59, 'Patagones', 1),
(60, 'Grl. Viamonte', 1),
(61, 'Cnl. De Marina Leonardo Rosales', 1),
(62, 'Balcarse', 1),
(63, 'Tres Arroyos', 1),
(64, 'General Villegas', 1),
(65, 'Lomas De Zamora', 1),
(66, 'Berisso', 1),
(67, 'Juarez', 1),
(68, 'General Pueyrredon', 1),
(69, 'Coronel Suarez', 1),
(70, 'Escobar', 1),
(71, 'Carlos Caseres', 1),
(72, 'Chivilcoy', 1),
(73, 'Berazategui', 1),
(74, 'Quilmes', 1),
(75, 'Torquinst', 1),
(76, '3 De Febrero', 1),
(77, 'Olavarria', 1),
(78, 'Pellegrini', 1),
(79, 'General Belgrano', 1),
(80, 'Florencio Varela', 1),
(81, 'Salliquel', 1),
(82, 'Mar Chiquita', 1),
(83, 'Campana', 1),
(84, 'General Sarmiento', 1),
(85, 'Rojas', 1),
(86, 'Sarmiento', 1),
(87, 'Carmen De Areco', 1),
(88, 'Pilar', 1),
(89, 'Moron', 1),
(90, 'Castelli', 1),
(91, 'Chacabuco', 1),
(92, 'General Viamonte', 1),
(93, 'Rauch', 1),
(94, 'Necochea', 1),
(95, 'Marcos Paz', 1),
(96, 'Carlos Tejedor', 1),
(97, 'San Pedro', 1),
(98, 'General Alvarado', 1),
(99, 'San Nicolas', 1),
(100, 'Hipolito Yrigoyen', 1),
(101, 'Las Flores', 1),
(102, 'Coronel Pringles', 1),
(103, 'General San Martin', 1),
(104, 'Benito Juarez', 1),
(105, 'San Cayetano', 1),
(106, 'Dolores', 1),
(107, 'San Antonio', 1),
(108, 'Loberia', 1),
(109, 'Ramallo', 1),
(110, 'General Alvear', 1),
(111, 'Ensenada', 1),
(112, 'Tordillo', 1),
(113, 'General Guido', 1),
(114, 'General Las Heras', 1),
(115, 'General Juan Madariaga', 1),
(116, 'General La Madrid', 1),
(117, 'General Lavalle', 1),
(118, 'General Rodriguez', 1),
(119, 'General Villegas', 1),
(120, 'Bolivar', 1),
(121, 'San Fernando', 1),
(122, 'Capitan Sarmiento', 1),
(123, 'Roque Perez', 1),
(124, 'Moreno', 1),
(125, 'Laprida', 1),
(126, 'Maipu', 1),
(127, 'Suipacha', 1),
(128, 'San Antonio de Areco', 1),
(129, 'Berazategui', 1),
(130, 'Alsina', 1),
(131, 'Capital Federal', 1),
(132, 'La Plata', 1),
(133, 'Mar Del Plaza', 1),
(134, 'Otra', 1),
(135, 'Capayan', 2),
(136, 'Andalgala', 2),
(137, 'El Alto', 2),
(138, 'Santa Rosa', 2),
(139, 'Ancasti', 2),
(140, 'Paclin', 2),
(141, 'Santa Maria', 2),
(142, 'Tinogasta', 2),
(143, 'La Paz', 2),
(144, 'Valle Viejo', 2),
(145, 'Antofagasta De La Sierra', 2),
(146, 'Belen', 2),
(147, 'Capital', 2),
(148, 'Fray Mamerto Esquiu', 2),
(149, 'Poman', 2),
(150, 'Ambato', 2),
(151, 'Otra', 2),
(152, 'Independencia', 3),
(153, 'San Fernando', 3),
(154, 'Primero De Mayo', 3),
(155, 'Fray Justo Santa Maria de Oro', 3),
(156, 'Sargento Cabral', 3),
(157, 'General Guemes', 3),
(158, 'Tapenaga', 3),
(159, 'Chacabuco', 3),
(160, 'Libertador Gral. San Martin', 3),
(161, '25 De Mayo', 3),
(162, '12 De Octubre', 3),
(163, 'Comandante Fernandez', 3),
(164, 'Quitilipi', 3),
(165, 'Mayor Luis J. Fontana', 3),
(166, 'Libertad', 3),
(167, 'Bermejo', 3),
(168, 'Almirante Brown', 3),
(169, 'General Belgrano', 3),
(170, 'General Donovan', 3),
(171, 'San Lorenzo', 3),
(172, 'Maipu', 3),
(173, 'Resistencia', 3),
(174, 'O Higgins', 3),
(175, '9 De Julio', 3),
(176, 'Otra', 3),
(177, 'Rio Senguer', 4),
(178, 'Martires', 4),
(179, 'Escalante', 4),
(180, 'Gaiman', 4),
(181, 'Sarmiento', 4),
(182, 'Cushamen', 4),
(183, 'Florentino Ameghino', 4),
(184, 'Paso De Indios', 4),
(185, 'Telsen', 4),
(186, 'Languiñeo', 4),
(187, 'Gastre', 4),
(188, 'Futaleufu', 4),
(189, 'Tehuelches', 4),
(190, 'Rawson', 4),
(191, 'Biedma', 4),
(192, 'Otra', 4),
(193, 'Rio Cuarto', 5),
(194, 'Totoral', 5),
(195, 'Colon', 5),
(196, 'Minas', 5),
(197, 'Punilla', 5),
(198, 'Juarez Celman', 5),
(199, 'Marcos Juarez', 5),
(200, 'San Justo', 5),
(201, 'Tercero Arriba', 5),
(202, 'Rio Seco', 5),
(203, 'Capital', 5),
(205, 'Santa Maria', 5),
(206, 'Sal Alberto', 5),
(207, 'Union', 5),
(208, 'Pocho', 5),
(209, 'Calamuchita', 5),
(210, 'General San Martin', 5),
(211, 'Rio Primero', 5),
(212, 'Cruz Del Eje', 5),
(213, 'Gral. Roca', 5),
(214, 'Sobremonte', 5),
(215, 'Rio Segundo', 5),
(216, 'Rio Tercero', 5),
(217, 'Tulumba', 5),
(218, 'San Javier', 5),
(219, 'Presidente Roque Saenz Peña', 5),
(220, 'Coronel Pringles', 5),
(221, 'Otra', 5),
(222, 'San Roque', 6),
(223, 'Monte Caseros', 6),
(224, 'General Alvear', 6),
(225, 'Curuzu Cuatia', 6),
(226, 'San Martin', 6),
(227, 'Mercedes', 6),
(228, 'Saladas', 6),
(229, 'Ituzaingo', 6),
(230, 'Beron De Astrada', 6),
(231, 'Bella Vista', 6),
(232, 'San Luis Del Palmar', 6),
(233, 'Capital', 6),
(234, 'Lavalle', 6),
(235, 'Paso De Los Libres', 6),
(236, 'Goya', 6),
(237, 'Empedrado', 6),
(238, 'Sauce', 6),
(239, 'General Paz', 6),
(240, 'Santo Tome', 6),
(241, 'San Miguel', 6),
(242, 'Concepcion', 6),
(243, 'Esquina', 6),
(244, 'San Cosme', 6),
(245, 'Itati', 6),
(246, 'Burucuya', 6),
(247, 'Otra', 6),
(248, 'Uruguay', 7),
(249, 'Nogoya', 7),
(250, 'Tala', 7),
(251, 'Gualeguay', 7),
(252, 'Diamante', 7),
(253, 'Parana', 7),
(254, 'Gualeguaychu', 7),
(255, 'Colon', 7),
(256, 'Victoria', 7),
(257, 'Villaguay', 7),
(258, 'Feliciano', 7),
(259, 'Concordia', 7),
(260, 'La Paz', 7),
(261, 'Federacion', 7),
(262, 'Federal', 7),
(263, 'Castellanos', 7),
(264, 'Otra', 7),
(265, 'Pillagas', 8),
(266, 'Patiño', 8),
(267, 'Pilcomayo', 8),
(268, 'Bermejo', 8),
(269, 'Pirane', 8),
(270, 'Formosa', 8),
(271, 'Matagos', 8),
(272, 'Ramon Lista', 8),
(273, 'Pillagas', 8),
(274, 'Laishi', 8),
(275, 'Otra', 8),
(276, 'Ledesma', 9),
(277, 'Cochinoca', 9),
(278, 'El Carmen', 9),
(279, 'Tumbaya', 9),
(280, 'Capital', 9),
(281, 'Yavi', 9),
(282, 'Humahuaca', 9),
(283, 'Rinconada', 9),
(284, 'Valle Grande', 9),
(285, 'Susques', 9),
(286, 'Santa Catalina', 9),
(287, 'San Antonio', 9),
(288, 'Santa Barbara', 9),
(289, 'San Pedro', 9),
(290, 'Tilcara', 9),
(291, 'Otra', 9),
(292, 'Hucal', 10),
(293, 'Realico', 10),
(294, 'Mara Co', 10),
(295, 'Quemuquemu', 10),
(296, 'Chical Co', 10),
(297, 'Guatrache', 10),
(298, 'Capital', 10),
(299, 'Caleucaleu', 10),
(300, 'Trenel', 10),
(301, 'Ultracan', 10),
(302, 'Atreuco', 10),
(303, 'Toay', 10),
(304, 'Chapadleufu', 10),
(305, 'Conelo', 10),
(306, 'Puelen', 10),
(307, 'Rancul', 10),
(308, 'Loventue', 10),
(309, 'Conhelo', 10),
(310, 'Catrilo', 10),
(311, 'Chalileo', 10),
(312, 'Lihuel Calel', 10),
(313, 'Maraco', 10),
(314, 'Curaco', 10),
(315, 'Limay Mahuida', 10),
(316, 'Otra', 10),
(317, 'Castro Barros', 11),
(318, 'General San Martin', 11),
(319, 'General Lavalle', 11),
(320, 'Arauco', 11),
(321, 'Gral. Angel V. Peñolaza', 11),
(322, 'San Blas De Los Sauces', 11),
(323, 'Independencia', 11),
(324, 'General Ocampo', 11),
(325, 'Chilecito', 11),
(326, 'Famatina', 11),
(327, 'Gral. Juan Facundo Quiroga', 11),
(328, 'Gral. Belgrano', 11),
(329, 'Gral. Sarmiento', 11),
(330, 'Capital', 11),
(331, 'Gobernador Gordillo', 11),
(332, 'Rosario Vera Peñaloza', 11),
(333, 'Gral. La Madrid', 11),
(334, 'Gral. Juan Facundo Quiroga', 11),
(335, 'Sanagasta', 11),
(336, 'Otra', 11),
(337, 'San Rafael', 12),
(338, 'Lujan', 12),
(339, 'Malargue', 12),
(340, 'Guaymallen', 12),
(341, 'Lavalle', 12),
(342, 'Junin', 12),
(343, 'Tupungato', 12),
(344, 'Rivadavia', 12),
(345, 'Maipu', 12),
(346, 'Godoy Cruz', 12),
(347, 'General Alvear', 12),
(348, 'La Paz', 12),
(349, 'Tunuyan', 12),
(350, 'San Carlos', 12),
(351, 'Las Heras', 12),
(352, 'Lujan De Cuyo', 12),
(353, 'San Martin', 12),
(354, 'Santa Rosa', 12),
(355, 'Capital', 12),
(356, 'Otra', 12),
(357, '25 De Mayo', 13),
(358, 'Iguazu', 13),
(359, 'El Dorado', 13),
(360, 'Leando N. Alem', 13),
(361, 'Apostoles', 13),
(362, 'Cainguas', 13),
(363, 'Concepcion', 13),
(364, 'San Pedro', 13),
(365, 'Candelaria', 13),
(366, 'Gral. Manuel Belgrano', 13),
(367, 'Obera', 13),
(368, 'Libertador Gral. San Martin', 13),
(369, 'San Ignacio', 13),
(370, 'Montecarlo', 13),
(371, 'El Guarani', 13),
(372, 'Capital', 13),
(373, 'Guarani', 13),
(374, 'San Javier', 13),
(375, 'Otra', 13),
(376, 'Collon Cura', 14),
(377, 'Alumine', 14),
(378, 'Minas', 14),
(379, 'Añelo', 14),
(380, 'Confluencia', 14),
(381, 'Chos Malal', 14),
(382, 'Picunches', 14),
(383, 'Norquin', 14),
(384, 'Pehuenches', 14),
(385, 'Loncopue', 14),
(386, 'Huiliches', 14),
(387, 'Zapala', 14),
(388, 'Catan Lil', 14),
(389, 'Los Lagos', 14),
(390, 'Picun Leufu', 14),
(391, 'Lacar', 14),
(392, 'Otra', 14),
(393, 'Valcheta', 15),
(394, '25 De Mayo', 15),
(395, 'El Cuy', 15),
(396, 'Ñorquinco', 15),
(397, 'General Roca', 15),
(398, 'Avellaneda', 15),
(399, 'Conesa', 15),
(400, 'Pichi Mahuida', 15),
(401, 'San Antonio', 15),
(402, 'Pilcaniyeu', 15),
(403, '9 De Julio', 15),
(404, 'Adolfo Alsina', 15),
(405, 'Bariloche', 15),
(406, 'Otra', 15),
(407, 'La Viña', 16),
(408, 'San Martin', 16),
(409, 'Oran', 16),
(410, 'Anta', 16),
(411, 'Gral. Jose De San Martin', 16),
(412, 'Guachipas', 16),
(413, 'Rosario De La Frontera', 16),
(414, 'Rivadavia', 16),
(415, 'Metan', 16),
(416, 'San Carlos', 16),
(417, 'Gral. Guemes', 16),
(418, 'Cachi', 16),
(419, 'Rosario De Lerma', 16),
(420, 'Cafayate', 16),
(421, 'Los Andes', 16),
(422, 'Capital', 16),
(423, 'Cerrillos', 16),
(424, 'Chicoana', 16),
(425, 'La Poma', 16),
(426, 'Candelaria', 16),
(427, 'Rosario', 16),
(428, 'Iruya', 16),
(429, 'La Caldera', 16),
(430, 'Molinos', 16),
(431, 'Santa Victoria', 16),
(432, 'Otra', 16),
(433, '9 De Julio', 17),
(434, 'Jachal', 17),
(435, 'Albardon', 17),
(436, '25 De Mayo', 17),
(437, 'Santa Lucia', 17),
(438, 'Angaco', 17),
(439, 'Iglesia', 17),
(440, 'Valle Fertil', 17),
(441, 'Calingasta', 17),
(442, 'Rivadavia', 17),
(443, 'Caucete', 17),
(444, 'Sarmiento', 17),
(445, 'Pocito', 17),
(446, 'San Martin', 17),
(447, 'Chimbas', 17),
(448, 'Ullun', 17),
(449, 'Rawson', 17),
(450, 'Capital', 17),
(451, 'Zonda', 17),
(452, 'Otra', 17),
(453, 'Belgrano', 18),
(454, 'Chacabuco', 18),
(455, 'Capital', 18),
(456, 'Gobernador Dupuy', 18),
(457, 'Gral. Pedernera', 18),
(458, 'Ayacucho', 18),
(459, 'Junin', 18),
(460, 'Coronel Pringles', 18),
(461, 'Gobernador Duval', 18),
(462, 'Iglesia', 18),
(463, 'Libertador Gral. San Martin', 18),
(464, 'Caucete', 18),
(465, 'Otra', 18),
(466, 'Guer Aike', 19),
(467, 'Deseado', 19),
(468, 'Rio Chico', 19),
(469, 'Magallanes', 19),
(470, 'Lago Argentino', 19),
(471, 'Corpen Aike', 19),
(472, 'Lago Buenos Aires', 19),
(473, 'Otra', 19),
(474, 'General Lopez', 20),
(475, 'Rosario', 20),
(476, 'General Obligado', 20),
(477, 'Constitucion', 20),
(478, 'San Lorenzo', 20),
(479, 'San Javier', 20),
(480, 'Capital', 20),
(481, 'San Cristobal', 20),
(482, 'Iriondo', 20),
(483, 'Castellanos', 20),
(484, '9 De Julio', 20),
(485, 'Caseros', 20),
(486, 'San Jeronimo', 20),
(487, 'Belgrano', 20),
(488, 'San Justo', 20),
(489, 'Gral. Vera', 20),
(490, 'San Martin', 20),
(491, 'Las Colonias', 20),
(492, 'Garay', 20),
(493, 'Las Colinas', 20),
(494, 'Otra', 20),
(495, 'Banda', 21),
(496, 'Moreno', 21),
(497, 'Alberdi', 21),
(498, 'Pellegrini', 21),
(499, 'Ojo De Agua', 21),
(501, 'Rio Hondo', 21),
(502, 'General Taboada', 21),
(503, 'Choya', 21),
(504, 'Capital', 21),
(505, 'Aguirre', 21),
(506, 'Silipica', 21),
(507, 'Belgrano', 21),
(508, 'Figueroa', 21),
(509, 'Salavina', 21),
(510, 'Quebrachos', 21),
(511, 'Robles', 21),
(512, 'Avellaneda', 21),
(513, 'Jimenez', 21),
(514, 'Atamisqui', 21),
(515, 'San Martin', 21),
(516, 'Matara', 21),
(517, 'Salayina', 21),
(518, 'Gusayan', 21),
(519, 'Copo', 21),
(520, 'Brigadier Juan Felipe Ibarra', 21),
(521, 'Dobles', 21),
(522, 'Sarmiento', 21),
(523, 'Loreto', 21),
(524, 'Mitre', 21),
(525, 'Rivadavia', 21),
(526, 'Otra', 21),
(527, 'Ushuaia', 22),
(528, 'Islas Del Atlantico Sur', 22),
(529, 'Sector Antartico Argentino', 22),
(530, 'Rio Grande', 22),
(531, 'Is. Del Atlantico Sur e Is. Malvinas', 22),
(532, 'Antartida Argentina', 22),
(533, 'Otra', 22),
(534, 'Burruyacu', 23),
(535, 'Trancas', 23),
(536, 'Monteros', 23),
(537, 'Leales', 23),
(538, 'Cruz Alta', 23),
(539, 'Rio Chico', 23),
(540, 'Chicligasta', 23),
(541, 'Tafi', 23),
(542, 'Graneros', 23),
(543, 'Famailla', 23),
(544, 'Capital', 23),
(545, 'Otra', 23),
(546, 'Otra', 24),
(547, 'Otra', 25),
(548, 'Otra', 26),
(549, 'Otra', 27),
(550, 'Otra', 28),
(551, 'Otra', 29),
(552, 'Otra', 30),
(554, 'Otra', 31),
(555, 'Otra', 32),
(556, 'Otra', 33),
(557, 'Otra', 34),
(558, 'Otra', 35),
(559, 'Otra', 36),
(560, 'Otra', 37),
(561, 'Otra', 38),
(562, 'Otra', 39),
(564, 'Otra', 40),
(565, 'Otra', 41),
(566, 'Otra', 42),
(567, 'Otra', 43),
(568, 'Otra', 44),
(569, 'Otra', 45),
(570, 'Otra', 46),
(571, 'Otra', 47),
(572, 'Otra', 48),
(573, 'Otra', 49),
(574, 'Otra', 50),
(575, 'Otra', 51),
(576, 'Otra', 52),
(577, 'Otra', 53),
(578, 'Otra', 54),
(579, 'Otra', 55),
(580, 'Otra', 56),
(581, 'Otra', 57),
(582, 'Otra', 58),
(583, 'Otra', 59),
(584, 'Otra', 60),
(585, 'Otra', 61),
(586, 'Otra', 62),
(587, 'Otra', 63),
(588, 'Otra', 64),
(589, 'Otra', 65),
(590, 'Otra', 66),
(591, 'Otra', 67),
(592, 'Otra', 68),
(593, 'Otra', 69),
(594, 'Otra', 70),
(595, 'Otra', 71),
(596, 'Otra', 72),
(597, 'Otra', 73),
(598, 'Otra', 74),
(599, 'Otra', 75),
(600, 'Otra', 76),
(601, 'Otra', 77),
(602, 'Otra', 78),
(603, 'Otra', 79),
(604, 'Otra', 80),
(605, 'Otra', 81),
(606, 'Otra', 82),
(607, 'Otra', 83),
(608, 'Otra', 84),
(609, 'Otra', 85),
(610, 'Otra', 86),
(611, 'Otra', 87),
(612, 'Otra', 88),
(613, 'Otra', 89),
(614, 'Otra', 90),
(615, 'Otra', 91),
(616, 'Otra', 92),
(617, 'Otra', 93),
(618, 'Otra', 94),
(619, 'Otra', 95),
(620, 'Otra', 96),
(621, 'Otra', 97),
(622, 'Otra', 98),
(623, 'Otra', 99),
(624, 'Otra', 100),
(625, 'Otra', 101),
(626, 'Otra', 102),
(627, 'Otra', 103),
(628, 'Otra', 104),
(629, 'Otra', 105),
(630, 'Otra', 106),
(631, 'Otra', 107),
(632, 'Otra', 108),
(633, 'Otra', 109),
(634, 'Otra', 110),
(635, 'Otra', 111),
(636, 'Otra', 112),
(637, 'Otra', 113),
(638, 'Otra', 114),
(639, 'Otra', 115),
(640, 'Otra', 116),
(641, 'Otra', 117),
(642, 'Otra', 118),
(643, 'Otra', 119),
(644, 'Otra', 120),
(645, 'Otra', 121),
(646, 'Otra', 122),
(647, 'Otra', 123),
(648, 'Otra', 124),
(649, 'Otra', 125),
(650, 'Otra', 126),
(651, 'Otra', 127),
(652, 'Otra', 128),
(653, 'Otra', 129),
(654, 'Otra', 130),
(655, 'Otra', 131),
(656, 'Otra', 132),
(657, 'Otra', 133);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `mensaje`
--

CREATE TABLE IF NOT EXISTS `mensaje` (
`id` int(11) NOT NULL,
  `fecha_mensaje` datetime DEFAULT NULL,
  `titulo_mensaje` varchar(150) DEFAULT NULL,
  `mensaje` varchar(2000) DEFAULT NULL,
  `emisor_mensaje` int(11) DEFAULT NULL,
  `estado_mensaje` int(11) DEFAULT NULL,
  `tipo_mensaje` int(11) DEFAULT NULL,
  `referencia` int(11) DEFAULT NULL,
  `tipo_solicitud` int(11) DEFAULT NULL
) ENGINE=InnoDB AUTO_INCREMENT=72 DEFAULT CHARSET=utf8;

--
-- Volcado de datos para la tabla `mensaje`
--

INSERT INTO `mensaje` (`id`, `fecha_mensaje`, `titulo_mensaje`, `mensaje`, `emisor_mensaje`, `estado_mensaje`, `tipo_mensaje`, `referencia`, `tipo_solicitud`) VALUES
(3, '2015-07-12 15:42:52', 'Solicitud a docente para formar parte de la institución Remedios de Escalada de San Martín', 'Hola Gabriel. \r\n\r\nTe envío la solicitud para que empecemos a trabajar en la institución tal como acordamos en la reunión del fin de semestre.\r\n\r\nSaludos\r\n\r\nMartín', 56, 3, 2, 1, 3),
(4, '2015-07-12 15:43:28', 'Solicitud a docente para formar parte de la institución Remedios de Escalada de San Martín', 'Elizabeth,\r\n\r\nte envío la solicitud para empezar a trabajar en la plataforma tal lo acordado con anterioridad.', 56, 3, 2, 1, 3),
(5, '2015-07-12 15:43:45', 'Solicitud a docente para formar parte de la institución Remedios de Escalada de San Martín', 'Ignacio,\r\n\r\nte envío la solicitud para empezar a trabajar en la plataforma tal lo acordado con anterioridad.', 56, 1, 2, 1, 3),
(6, '2015-07-12 15:45:21', '[ACEPTADO] Respuesta a Solicitud a docente para formar parte de la institución Remedios de Escalada de San Martín', 'Hola Martín,\r\n\r\nMuchas gracias! empezaremos a ver de que se trata todo esto.\r\n\r\nSaludos', 7, 2, 3, 1, NULL),
(7, '2015-07-12 15:46:19', 'Solicitud del Administrador para que usted dirija el curso: Curso general 1A', 'Liz, te asigno los primeros años así conservamos la distribución real que tenemos. Igual, la idea es trabajar mancomunadamente.', 56, 3, 2, 1, 4),
(8, '2015-07-12 15:46:34', 'Solicitud del Administrador para que usted dirija el curso: Curso general 1B', 'El otro primero', 56, 3, 2, 2, 4),
(9, '2015-07-12 15:49:22', '[ACEPTADO] Respuesta a Solicitud del Administrador para que usted dirija el curso: Curso general 1A', 'Ok! dale, buenisimo', 7, 2, 3, 1, NULL),
(10, '2015-07-12 15:49:31', '[ACEPTADO] Respuesta a Solicitud del Administrador para que usted dirija el curso: Curso general 1B', 'Perfecto', 7, 2, 3, 2, NULL),
(11, '2015-07-12 15:50:42', 'Solicitud del Administrador para que usted dirija el curso: Curso general 2A', '', 56, 3, 2, 3, 4),
(12, '2015-07-12 15:50:51', '[ACEPTADO] Respuesta a Solicitud del Administrador para que usted dirija el curso: Curso general 2A', '', 7, 2, 3, 3, NULL),
(13, '2015-07-12 15:51:01', '[DESVINCULACION] El docente docente2@peals.com se ha desvinculado del curso Curso general 2A', 'El docente Elizabeth Rivarola ha decidido dejar de dirigir el curso Curso general 2A de la institución Remedios de Escalada de San Martín. Si usted cree que esto es un error, comuniquese con el usuario respondiendo este mensaje o enviando uno nueva al usuario docente2@peals.com', 7, 2, 3, 3, NULL),
(14, '2015-07-12 15:51:53', '<DESVINCULACION> El docente docente2@peals.com se desvinculó de la institución Remedios de Escalada de San Martín', 'El docente docente2@peals.com ha decidido desvincularse de la institución Remedios de Escalada de San Martín. Esto implica que los cursos ''Curso general 1A, Curso general 1B'' quedan sin docente asignado. Si considera que esto es un error, responda este correo al docente o envíele un nuevo mensaje al usuario docente2@peals.com', 7, 6, 3, 1, NULL),
(15, '2015-07-12 16:03:31', '[ACEPTADO] Respuesta a Solicitud a docente para formar parte de la institución Remedios de Escalada de San Martín', 'ok perfecto. Muchas gracias', 6, 6, 3, 1, NULL),
(16, '2015-07-12 16:04:07', 'Solicitud del Administrador para que usted dirija el curso: Curso general 1A', 'Gaby, te asigno los primeros años ya que Liz se va a hacer cargo de los segundos.Saludos', 56, 2, 2, 1, 4),
(17, '2015-07-16 12:08:12', 'Solicitud del Administrador para que usted dirija el curso: Curso general 1B', '', 56, 3, 2, 2, 4),
(18, '2015-07-16 12:08:19', 'Solicitud del Administrador para que usted dirija el curso: Curso general 2A', '', 56, 3, 2, 3, 4),
(19, '2015-07-16 12:08:29', 'Solicitud del Administrador para que usted dirija el curso: Curso general 2B', '', 56, 3, 2, 4, 4),
(20, '2015-07-16 12:08:51', '[ACEPTADO] Respuesta a Solicitud del Administrador para que usted dirija el curso: Curso general 2B', '', 6, 6, 3, 4, NULL),
(21, '2015-07-16 12:09:09', '[ACEPTADO] Respuesta a Solicitud del Administrador para que usted dirija el curso: Curso general 2A', '', 6, 6, 3, 3, NULL),
(22, '2015-07-16 12:09:16', '[ACEPTADO] Respuesta a Solicitud del Administrador para que usted dirija el curso: Curso general 1B', '', 6, 6, 3, 2, NULL),
(23, '2015-07-16 18:28:41', '<DESVINCULACION> El docente docente@peals.com ha decidido desvincularse del curso Curso general 2B', 'El docente ''docente@peals.com'' ha decidido dejar de dirigir el curso ''Curso general 2B'' de la institución ''Remedios de Escalada de San Martín''. Si usted considera que esto es un error, por favor responda este correo o escriba un mensaje al usuario docente@peals.com', 6, 2, 3, 4, NULL),
(24, '2015-07-16 18:34:58', '<DESVINCULACION> El docente docente@peals.com ha decidido desvincularse de la institución Remedios de Escalada de San Martín', 'El docente ''docente@peals.com'' ha decidido dejar de participar en la institución ''Remedios de Escalada de San Martín'' Esto implica que el docente dejará de dirigir los cursos ''Curso general 1B, Curso general 2A''. Si usted considera que esto es un error, por favor responda este correo o escriba un mensaje al usuario  docente@peals.com', 6, 2, 3, 1, NULL),
(25, '2015-07-16 18:36:38', 'Solicitud a docente para formar parte de la institución Remedios de Escalada de San Martín', 'unite!', 56, 3, 2, 1, 3),
(26, '2015-07-16 18:36:56', '[ACEPTADO] Respuesta a Solicitud a docente para formar parte de la institución Remedios de Escalada de San Martín', 'dale', 7, 6, 3, 1, NULL),
(27, '2015-07-16 18:37:10', 'Solicitud del Administrador para que usted dirija el curso: Curso general 1B', 'curso 1b', 56, 3, 2, 2, 4),
(28, '2015-07-16 18:37:18', 'Solicitud del Administrador para que usted dirija el curso: Curso general 2A', '2a', 56, 3, 2, 3, 4),
(29, '2015-07-16 18:37:25', 'Solicitud del Administrador para que usted dirija el curso: Curso general 2B', '2b', 56, 3, 2, 4, 4),
(30, '2015-07-16 18:37:33', 'Solicitud del Administrador para que usted dirija el curso: Curso general 3A', '3a', 56, 3, 2, 5, 4),
(31, '2015-07-16 18:37:50', '[ACEPTADO] Respuesta a Solicitud del Administrador para que usted dirija el curso: Curso general 1B', 'sii', 7, 6, 3, 2, NULL),
(32, '2015-07-16 18:37:57', '[ACEPTADO] Respuesta a Solicitud del Administrador para que usted dirija el curso: Curso general 2A', 'as', 7, 6, 3, 3, NULL),
(33, '2015-07-16 18:38:04', '[ACEPTADO] Respuesta a Solicitud del Administrador para que usted dirija el curso: Curso general 2B', 'sa', 7, 6, 3, 4, NULL),
(34, '2015-07-16 18:38:11', '[ACEPTADO] Respuesta a Solicitud del Administrador para que usted dirija el curso: Curso general 3A', 'sa', 7, 6, 3, 5, NULL),
(35, '2015-07-16 18:39:19', '<DESVINCULACION> El docente docente2@peals.com ha decidido desvincularse del curso Curso general 2B', 'El docente ''docente2@peals.com'' ha decidido dejar de dirigir el curso ''Curso general 2B'' de la institución ''Remedios de Escalada de San Martín''. Si usted considera que esto es un error, por favor responda este correo o escriba un mensaje al usuario docente2@peals.com', 7, 6, 3, 4, NULL),
(36, '2015-07-16 18:39:34', '<DESVINCULACION> El docente docente2@peals.com ha decidido desvincularse de la institución Remedios de Escalada de San Martín', 'El docente ''docente2@peals.com'' ha decidido dejar de participar en la institución ''Remedios de Escalada de San Martín'' Esto implica que el docente dejará de dirigir los cursos ''Curso general 1B, Curso general 2A, Curso general 3A''. Si usted considera que esto es un error, por favor responda este correo o escriba un mensaje al usuario  docente2@peals.com', 7, 6, 3, 1, NULL),
(37, '2015-10-13 20:38:06', 'Solicitud a docente para formar parte de la institución Remedios de Escalada de San Martín', 'Unite gaby!', 56, 3, 2, 1, 3),
(38, '2015-10-13 20:38:20', 'Solicitud a docente para formar parte de la institución Remedios de Escalada de San Martín', 'Unite!', 56, 3, 2, 1, 3),
(39, '2015-10-13 20:38:30', 'Solicitud a docente para formar parte de la institución Remedios de Escalada de San Martín', 'unite!!', 56, 1, 2, 1, 3),
(40, '2015-10-13 20:38:53', '[ACEPTADO] Respuesta a Solicitud a docente para formar parte de la institución Remedios de Escalada de San Martín', 'Dale', 6, 6, 3, 1, NULL),
(41, '2015-10-13 20:39:07', '[ACEPTADO] Respuesta a Solicitud a docente para formar parte de la institución Remedios de Escalada de San Martín', 'dale', 7, 6, 1, 1, NULL),
(42, '2015-10-13 20:39:23', '[ACEPTADO] Respuesta a Solicitud a docente para formar parte de la institución Remedios de Escalada de San Martín', 'ok', 8, 6, 3, 1, NULL),
(43, '2015-10-14 19:36:04', 'Solicitud del Administrador para que usted dirija el curso: Curso general 2B', 'dale', 56, 3, 2, 4, 4),
(44, '2015-10-14 19:36:27', '[ACEPTADO] Respuesta a Solicitud del Administrador para que usted dirija el curso: Curso general 2B', 'ok', 6, 2, 3, 4, NULL),
(45, '2015-10-23 19:59:36', 'Solicitud a docente para formar parte de la institución Remedios de Escalada de San Martín', 'Queres participar????', 56, 2, 2, 1, 3),
(46, '2015-10-24 16:00:27', 'Solicitud a docente para formar parte de la institución Remedios de Escalada de San Martín', 'hola mundo', 56, 6, 2, 1, 3),
(47, '2015-10-24 18:18:42', 'Solicitud a docente para formar parte de la institución Remedios de Escalada de San Martín', 'queres participar?', 56, 1, 2, 1, 3),
(48, '2015-12-15 19:06:57', ' Corrección Actividad', 'Te avisamos que el docente ha resulto la actividad Test de señas. La calificación del docente es: 100', 6, 6, 3, 2, NULL),
(49, '2015-12-15 19:18:51', ' Corrección Actividad', 'Te avisamos que el docente ha resulto la actividad Test de señas, resuelta el 14/12/2015 9:01:18 p. m.. La calificación del docente es: 95. El Docente te Dejo el siguiente mensaje: Hola! muy bien resuelto! gracias por participar!!!', 6, 6, 3, 4, NULL),
(50, '2015-12-24 18:15:32', 'Resolucion actividad', 'Hola profe!! estuvo reee dificil resolve el ejercicio! me gustaria que nos juntemos y me muestre como son los ejercicios que no pude resolver. \r<br />\r<br />Saludos!', 16, 1, 1, NULL, NULL),
(51, '2015-12-24 18:17:07', ' Corrección Actividad', 'Te avisamos que el docente ha resulto la actividad Test señas y texto, resuelta el 24/12/2015 6:14:36 p. m.. La calificación del docente es: 100. El Docente te Dejo el siguiente mensaje: Muy bien adrian! me alegra mucho que estes progresando tanto! te mando un saludo muy grande con mucho afecto! Los ejercicios eran muy dificiles y que hayas podido resolverlos como los resolviste es excelente! ', 6, 6, 3, 7, NULL),
(52, '2016-01-05 17:45:38', 'Solicitud del Administrador para que usted dirija el curso: Curso general 5', 'Hacete cargo de esto', 56, 3, 2, 8, 4),
(53, '2016-01-05 17:46:25', '[ACEPTADO] Respuesta a Solicitud del Administrador para que usted dirija el curso: Curso general 5', 'Ok', 6, 2, 3, 8, NULL),
(54, '2016-01-05 17:53:52', 'Solicitud de inscripción al curso Curso general 5', 'Hola, quiero participar de este curso! gracias!', 17, 3, 2, 8, 1),
(55, '2016-01-05 17:54:18', '[ACEPTADO] Respuesta a Solicitud de inscripción al curso Curso general 5', 'Ok', 6, 6, 3, 8, NULL),
(56, '2016-01-06 17:59:07', 'Solicitud del Administrador para que usted dirija el curso: Curso general 4', 'porfi', 56, 3, 2, 7, 4),
(57, '2016-01-06 17:59:27', '[ACEPTADO] Respuesta a Solicitud del Administrador para que usted dirija el curso: Curso general 4', 'ok', 6, 6, 3, 7, NULL),
(58, '2016-01-06 21:55:47', 'Solicitud de inscripción al curso Curso general 4', 'Quiero participar', 16, 3, 2, 7, 1),
(59, '2016-01-06 22:09:17', '[ACEPTADO] Respuesta a Solicitud de inscripción al curso Curso general 4', 'ok', 6, 6, 3, 7, NULL),
(60, '2016-01-12 18:55:12', 'Probando mail', 'probando mails', 16, 1, 1, NULL, NULL),
(61, '2016-01-12 18:58:40', 'Probando enviar a un curso y al alumno 5', 'Probando probando probando', 16, 1, 1, NULL, NULL),
(62, '2016-01-12 19:01:23', 'probando curso mas persona', 'Probando el curso mas la persona', 16, 6, 1, NULL, NULL),
(63, '2016-01-12 19:03:36', 'asdas', 'asdasd', 16, 6, 1, NULL, NULL),
(64, '2016-01-12 19:10:06', 'Probando posta', 'Poooosta posta', 6, 6, 1, NULL, NULL),
(65, '2016-01-12 19:10:57', 'Probando posta', 'Poooosta posta', 6, 6, 1, NULL, NULL),
(66, '2016-01-12 19:15:39', 'Solicitud del Administrador para que usted dirija el curso: Curso general 3A', 'Probando envio de mensajes en lo que es solicitudes', 56, 3, 2, 5, 4),
(67, '2016-01-12 19:17:00', '[ACEPTADO] Respuesta a Solicitud del Administrador para que usted dirija el curso: Curso general 3A', 'Solicitud anda! solo falta probar notificaciones!!!!', 7, 6, 3, 5, NULL),
(68, '2016-01-12 19:22:53', 'Prueba', 'Probando el envio a casillas posta', 56, 6, 1, NULL, NULL),
(69, '2016-01-12 19:26:29', 'Hola martu', 'Hola culiau! toddo bien?', 56, 6, 1, NULL, NULL),
(70, '2016-01-18 17:46:45', 'Solicitud del Administrador para que usted dirija el curso: Curso general 3B', 'Querés participar?', 56, 1, 2, 6, 4),
(71, '2016-01-18 17:46:49', 'Solicitud del Administrador para que usted dirija el curso: Curso general 3B', 'Querés participar?', 56, 1, 2, 6, 4);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `mensaje_x_destinatario`
--

CREATE TABLE IF NOT EXISTS `mensaje_x_destinatario` (
`id` int(11) NOT NULL,
  `mensaje` int(11) DEFAULT NULL,
  `destinatario` int(11) DEFAULT NULL
) ENGINE=InnoDB AUTO_INCREMENT=77 DEFAULT CHARSET=utf8;

--
-- Volcado de datos para la tabla `mensaje_x_destinatario`
--

INSERT INTO `mensaje_x_destinatario` (`id`, `mensaje`, `destinatario`) VALUES
(3, 3, 6),
(4, 4, 7),
(5, 5, 8),
(6, 6, 56),
(7, 7, 7),
(8, 8, 7),
(9, 9, 56),
(10, 10, 56),
(11, 11, 7),
(12, 12, 56),
(13, 13, 56),
(14, 14, 56),
(15, 15, 56),
(16, 16, 6),
(17, 17, 6),
(18, 18, 6),
(19, 19, 6),
(20, 20, 56),
(21, 21, 56),
(22, 22, 56),
(23, 23, 56),
(24, 24, 56),
(25, 25, 7),
(26, 26, 56),
(27, 27, 7),
(28, 28, 7),
(29, 29, 7),
(30, 30, 7),
(31, 31, 56),
(32, 32, 56),
(33, 33, 56),
(34, 34, 56),
(35, 35, 56),
(36, 36, 56),
(37, 37, 6),
(38, 38, 7),
(39, 39, 8),
(40, 40, 56),
(41, 41, 56),
(42, 42, 56),
(43, 43, 6),
(44, 44, 56),
(45, 45, 9),
(46, 46, 9),
(47, 47, 10),
(48, 48, 16),
(49, 49, 16),
(50, 50, 59),
(51, 51, 16),
(52, 52, 6),
(53, 53, 56),
(54, 54, 6),
(55, 55, 17),
(56, 56, 6),
(57, 57, 56),
(58, 58, 6),
(59, 59, 16),
(60, 60, 20),
(61, 60, 19),
(62, 61, 20),
(63, 62, 6),
(64, 62, 6),
(65, 63, 6),
(66, 63, 60),
(67, 64, 16),
(68, 64, 61),
(69, 65, 16),
(70, 65, 62),
(71, 66, 7),
(72, 67, 56),
(73, 68, 63),
(74, 69, 63),
(75, 70, 8),
(76, 71, 8);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `nivel`
--

CREATE TABLE IF NOT EXISTS `nivel` (
`id` int(11) NOT NULL,
  `nombre` varchar(50) DEFAULT NULL,
  `descripcion` varchar(150) DEFAULT NULL
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=utf8;

--
-- Volcado de datos para la tabla `nivel`
--

INSERT INTO `nivel` (`id`, `nombre`, `descripcion`) VALUES
(1, 'Inicial', 'Nivel Inicial'),
(2, 'Primario', 'Nivel Primario'),
(3, 'Secundario', 'Nivel Secundario'),
(4, 'Terciario', 'Nivel Terciario'),
(5, 'Universitario', 'Nivel Universitario'),
(6, 'Otro', 'Otro');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `opcion`
--

CREATE TABLE IF NOT EXISTS `opcion` (
`id` int(11) NOT NULL,
  `item` int(11) DEFAULT NULL,
  `descripcion` varchar(200) DEFAULT NULL
) ENGINE=InnoDB AUTO_INCREMENT=12 DEFAULT CHARSET=utf8;

--
-- Volcado de datos para la tabla `opcion`
--

INSERT INTO `opcion` (`id`, `item`, `descripcion`) VALUES
(1, 1, 'Masculino'),
(2, 1, 'Femenino'),
(3, 6, 'Masculino'),
(4, 6, 'Femenino'),
(5, 11, 'Masculino'),
(6, 11, 'Femenino'),
(7, 12, 'MALA'),
(8, 12, 'REGULAR'),
(9, 12, 'ACEPTABLE'),
(10, 12, 'BUENA'),
(11, 12, 'MUY BUENA');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `pais`
--

CREATE TABLE IF NOT EXISTS `pais` (
`id` int(11) NOT NULL,
  `nombre` varchar(50) DEFAULT NULL
) ENGINE=InnoDB AUTO_INCREMENT=13 DEFAULT CHARSET=utf8;

--
-- Volcado de datos para la tabla `pais`
--

INSERT INTO `pais` (`id`, `nombre`) VALUES
(1, 'Argentina'),
(2, 'Bolivia'),
(3, 'Brasil'),
(4, 'Chile'),
(5, 'Colombia'),
(6, 'Ecuador'),
(7, 'Guatemala'),
(8, 'Paraguay'),
(9, 'Peru'),
(10, 'Uruguay'),
(11, 'Venezuela'),
(12, 'Otro');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `provincia`
--

CREATE TABLE IF NOT EXISTS `provincia` (
`id` int(11) NOT NULL,
  `nombre` varchar(50) DEFAULT NULL,
  `pais` int(11) DEFAULT NULL
) ENGINE=InnoDB AUTO_INCREMENT=134 DEFAULT CHARSET=utf8;

--
-- Volcado de datos para la tabla `provincia`
--

INSERT INTO `provincia` (`id`, `nombre`, `pais`) VALUES
(1, 'Buenos Aires', 1),
(2, 'Catamarca', 1),
(3, 'Chaco', 1),
(4, 'Chubut', 1),
(5, 'Cordoba', 1),
(6, 'Corrientes', 1),
(7, 'Entre Rios', 1),
(8, 'Formosa', 1),
(9, 'Jujuy', 1),
(10, 'La Pampa', 1),
(11, 'La Rioja', 1),
(12, 'Mendoza', 1),
(13, 'Misiones', 1),
(14, 'Neuquen', 1),
(15, 'Rio Negro', 1),
(16, 'Salta', 1),
(17, 'San Juan', 1),
(18, 'San Luis', 1),
(19, 'Santa Cruz', 1),
(20, 'Santa Fe', 1),
(21, 'Santiago Del Estero', 1),
(22, 'Tierra Del Fuego', 1),
(23, 'Tucuman', 1),
(24, 'Santa Cruz De La Sierra', 2),
(25, 'La Paz', 2),
(26, 'El Alto', 2),
(27, 'Cochabamba', 2),
(28, 'Oruro', 2),
(29, 'Sucre', 2),
(30, 'Potosi', 2),
(31, 'Tarija', 2),
(32, 'Otra', 2),
(33, 'Sao Paulo', 3),
(34, 'Rio De Janeiro', 3),
(35, 'Salvador', 3),
(36, 'Belo Horizonte', 3),
(37, 'Fortaleza', 3),
(38, 'Brasilia', 3),
(39, 'Recife', 3),
(40, 'Porto Alegre', 3),
(41, 'Campinas', 3),
(42, 'Campo Grande', 3),
(43, 'Santo Andre', 3),
(44, 'Porto Velho', 3),
(45, 'Florianopolis', 3),
(46, 'Santa Maria', 3),
(47, 'Otra', 3),
(48, 'Santiago De Chile', 4),
(49, 'Viña Del Mar', 4),
(50, 'Valparaiso', 4),
(51, 'Talcahuano', 4),
(52, 'San Bernardo', 4),
(53, 'Concepcion', 4),
(54, 'Valdivia', 4),
(55, 'Otra', 4),
(56, 'Santa Fe De Bogota', 5),
(57, 'Cali', 5),
(58, 'Medellin', 5),
(59, 'Cartagena', 5),
(60, 'Bello', 5),
(61, 'Villavicencio', 5),
(62, 'Buenaventura', 5),
(63, 'Floridablanca', 5),
(64, 'Dos Quebradas', 5),
(65, 'Cartago', 5),
(66, 'Florencia', 5),
(67, 'Giron', 5),
(68, 'Otra', 5),
(69, 'Guayaquil', 6),
(70, 'Quito', 6),
(71, 'Cuenca', 6),
(72, 'Portoviejo', 6),
(73, 'Ambato', 6),
(74, 'Duran', 6),
(75, 'Quevedo', 6),
(76, 'Milagro', 6),
(77, 'Loja', 6),
(78, 'Riobamba', 6),
(79, 'Esmeraldas', 6),
(80, 'Otra', 6),
(81, 'Ciudad de Guatemala', 7),
(82, 'Mixco', 7),
(83, 'Villa Nueva', 7),
(84, 'Quetzaltenango', 7),
(85, 'Otra', 7),
(86, 'Asuncion', 8),
(87, 'Ciudad Del Este', 8),
(88, 'San Lorenzo', 8),
(89, 'Lambare', 8),
(90, 'Fernando De La Mora', 8),
(91, 'Otra', 8),
(92, 'Lima', 9),
(93, 'Arequipa', 9),
(94, 'Chiclayo', 9),
(95, 'Callao', 9),
(96, 'Iquitos', 9),
(97, 'Huancayo', 9),
(98, 'Piura', 9),
(99, 'Juliaca', 9),
(100, 'Huanuco', 9),
(101, 'Ayacucho', 9),
(102, 'Puno', 9),
(103, 'Castilla', 9),
(104, 'Otra', 9),
(105, 'Montevideo', 10),
(106, 'Maldonado', 10),
(107, 'La Valleja', 10),
(108, 'Rocha', 10),
(109, 'San Jose', 10),
(110, 'Colonia', 10),
(111, 'Florida', 10),
(112, 'Durazno', 10),
(113, 'Rio Negro', 10),
(114, 'Cerro Largo', 10),
(115, 'Otra', 10),
(116, 'Caracas', 11),
(117, 'Maracaibo', 11),
(118, 'Barquisimeto', 11),
(119, 'Valencia', 11),
(120, 'Ciudad Guayana', 11),
(121, 'Maracay', 11),
(122, 'San Cristobal', 11),
(123, 'Ciudad Bolivar', 11),
(124, 'Merida', 11),
(125, 'Puerto Cabello', 11),
(126, 'Santa Ana De Coro', 11),
(127, 'El Tigre', 11),
(128, 'San Felipe', 11),
(129, 'San Fernando de Apure', 11),
(130, 'Valle De La Pascua', 11),
(131, 'El Limon', 11),
(132, 'Otra', 11),
(133, 'Otra', 12);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `recurso`
--

CREATE TABLE IF NOT EXISTS `recurso` (
`id` int(11) NOT NULL,
  `nombre` varchar(100) DEFAULT NULL,
  `ruta` varchar(200) DEFAULT NULL,
  `tipo_recurso` int(11) DEFAULT NULL,
  `subido_por` int(11) DEFAULT NULL,
  `estado` int(11) DEFAULT NULL
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=utf8;

--
-- Volcado de datos para la tabla `recurso`
--

INSERT INTO `recurso` (`id`, `nombre`, `ruta`, `tipo_recurso`, `subido_por`, `estado`) VALUES
(1, 'Prueba 1', NULL, 4, NULL, 1),
(2, 'Prueba 2', NULL, 4, NULL, 1),
(3, 'Sarasa', '/Content/Resources/Uploads/sin_imagen.jpg', 1, NULL, 1),
(4, 'Pato', '/Content/Resources/Uploads/pato.jpg', 1, NULL, 1),
(5, 'Gato', '/Content/Resources/Uploads/gato.jpg', 1, NULL, 1),
(6, 'Es un ave pero no vuela', NULL, 4, NULL, 1);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `recurso_compartido`
--

CREATE TABLE IF NOT EXISTS `recurso_compartido` (
`id` int(11) NOT NULL,
  `recurso` int(11) DEFAULT NULL,
  `institucion` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `seguimiento`
--

CREATE TABLE IF NOT EXISTS `seguimiento` (
`id` int(11) NOT NULL,
  `curso` int(11) DEFAULT NULL,
  `activo` int(11) DEFAULT NULL
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8;

--
-- Volcado de datos para la tabla `seguimiento`
--

INSERT INTO `seguimiento` (`id`, `curso`, `activo`) VALUES
(1, 4, 1);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `senia`
--

CREATE TABLE IF NOT EXISTS `senia` (
  `id` int(11) NOT NULL,
  `clase` varchar(45) DEFAULT NULL,
  `activo` tinyint(1) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1 COMMENT='	';

--
-- Volcado de datos para la tabla `senia`
--

INSERT INTO `senia` (`id`, `clase`, `activo`) VALUES
(1, 'a', 1),
(2, 'b', 1),
(3, 'c', 1);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `texto`
--

CREATE TABLE IF NOT EXISTS `texto` (
`id` int(11) NOT NULL,
  `texto` varchar(200) DEFAULT NULL,
  `actividad` int(11) DEFAULT NULL,
  `pos_top` varchar(6) DEFAULT NULL,
  `pos_left` varchar(6) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `tipo_mensaje`
--

CREATE TABLE IF NOT EXISTS `tipo_mensaje` (
`id` int(11) NOT NULL,
  `nombre` varchar(50) DEFAULT NULL
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8;

--
-- Volcado de datos para la tabla `tipo_mensaje`
--

INSERT INTO `tipo_mensaje` (`id`, `nombre`) VALUES
(1, 'Mensaje'),
(2, 'Solicitud'),
(3, 'Notificacion');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `tipo_recurso`
--

CREATE TABLE IF NOT EXISTS `tipo_recurso` (
`id` int(11) NOT NULL,
  `nombre` varchar(50) DEFAULT NULL
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8;

--
-- Volcado de datos para la tabla `tipo_recurso`
--

INSERT INTO `tipo_recurso` (`id`, `nombre`) VALUES
(1, 'Imagen'),
(2, 'Audio'),
(3, 'Video'),
(4, 'Senias');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `tipo_usuario`
--

CREATE TABLE IF NOT EXISTS `tipo_usuario` (
`id` int(11) NOT NULL,
  `nombre` varchar(50) DEFAULT NULL
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8;

--
-- Volcado de datos para la tabla `tipo_usuario`
--

INSERT INTO `tipo_usuario` (`id`, `nombre`) VALUES
(1, 'Administrador'),
(2, 'Docente'),
(3, 'Alumno');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `turno`
--

CREATE TABLE IF NOT EXISTS `turno` (
`id` int(11) NOT NULL,
  `nombre` varchar(50) DEFAULT NULL
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8;

--
-- Volcado de datos para la tabla `turno`
--

INSERT INTO `turno` (`id`, `nombre`) VALUES
(1, 'Mañana'),
(2, 'Tarde'),
(3, 'Noche');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `usuario`
--

CREATE TABLE IF NOT EXISTS `usuario` (
`id` int(11) NOT NULL,
  `mail` varchar(50) DEFAULT NULL,
  `contrasena` varchar(64) DEFAULT NULL,
  `nombre` varchar(50) DEFAULT NULL,
  `apellido` varchar(50) DEFAULT NULL,
  `fecha_nacimiento` date DEFAULT NULL,
  `localidad` int(11) DEFAULT NULL,
  `fecha_alta` datetime DEFAULT NULL,
  `fecha_baja` datetime DEFAULT NULL,
  `tipo_usuario` int(11) DEFAULT NULL,
  `especialidad` int(11) DEFAULT NULL,
  `estado_usuario` int(11) DEFAULT NULL
) ENGINE=InnoDB AUTO_INCREMENT=64 DEFAULT CHARSET=utf8;

--
-- Volcado de datos para la tabla `usuario`
--

INSERT INTO `usuario` (`id`, `mail`, `contrasena`, `nombre`, `apellido`, `fecha_nacimiento`, `localidad`, `fecha_alta`, `fecha_baja`, `tipo_usuario`, `especialidad`, `estado_usuario`) VALUES
(1, 'admin@peals.com', '6367C48DD193D56EA7B0BAAD25B19455E529F5EE', 'Martin', 'Gramatica', '1988-01-11', 203, '1988-01-11 00:00:00', NULL, 1, NULL, 2),
(2, 'admin2@peals.com', '6367C48DD193D56EA7B0BAAD25B19455E529F5EE', 'Paola', 'Gonzalez', '1988-01-11', 203, '1980-01-11 00:00:00', NULL, 1, NULL, 2),
(3, 'admin3@peals.com', '6367C48DD193D56EA7B0BAAD25B19455E529F5EE', 'Juan', 'Pretti', '1988-01-11', 215, '1979-01-11 00:00:00', NULL, 1, NULL, 2),
(4, 'admin4@peals.com', '6367C48DD193D56EA7B0BAAD25B19455E529F5EE', 'Jonatan', 'Camileti', '1988-01-11', 215, '1988-01-11 00:00:00', NULL, 1, NULL, 1),
(5, 'admin5@peals.com', '6367C48DD193D56EA7B0BAAD25B19455E529F5EE', 'Adrian', 'Gramatica', '1988-01-11', 216, '1979-01-11 00:00:00', '2014-01-11 00:00:00', 1, NULL, 3),
(6, 'docente@peals.com', '6367C48DD193D56EA7B0BAAD25B19455E529F5EE', 'Gabriel', 'Freisz', '1989-01-24', 203, '2013-07-06 05:46:56', NULL, 2, 1, 2),
(7, 'docente2@peals.com', '6367C48DD193D56EA7B0BAAD25B19455E529F5EE', 'Elizabeth', 'Rivarola', '1989-01-24', 203, '2013-07-06 05:46:56', NULL, 2, 1, 2),
(8, 'docente3@peals.com', '6367C48DD193D56EA7B0BAAD25B19455E529F5EE', 'Ignacio', 'Gaudio', '1989-01-24', 203, '2013-07-06 05:46:56', NULL, 2, 1, 2),
(9, 'docente4@peals.com', '6367C48DD193D56EA7B0BAAD25B19455E529F5EE', 'Valeria', 'Andrada', '1989-01-24', 203, '2013-07-06 05:46:56', NULL, 2, 1, 3),
(10, 'docente5@peals.com', '6367C48DD193D56EA7B0BAAD25B19455E529F5EE', 'Andres', 'Mondolo', '1989-01-24', 203, '2013-07-06 05:46:56', NULL, 2, 1, 2),
(11, 'docente6@peals.com', '6367C48DD193D56EA7B0BAAD25B19455E529F5EE', 'Lorena', 'Alvarez', '1989-01-24', 203, '2013-07-06 05:46:56', NULL, 2, 1, 2),
(12, 'docente7@peals.com', '6367C48DD193D56EA7B0BAAD25B19455E529F5EE', 'Maria', 'Dominguez', '1989-01-24', 215, '2013-07-06 05:46:56', NULL, 2, 1, 2),
(13, 'docente8@peals.com', '6367C48DD193D56EA7B0BAAD25B19455E529F5EE', 'Matias', 'Padial', '1989-01-24', 215, '2013-07-06 05:46:56', NULL, 2, 1, 2),
(14, 'docente9@peals.com', '6367C48DD193D56EA7B0BAAD25B19455E529F5EE', 'Gerardo', 'Olmos', '1989-01-24', 215, '2013-07-06 05:46:56', NULL, 2, 1, 1),
(15, 'docente10@peals.com', '6367C48DD193D56EA7B0BAAD25B19455E529F5EE', 'Ariel', 'Freisz10', '1989-01-24', 203, '2013-07-06 05:46:56', '2014-01-11 00:00:00', 2, 1, 3),
(16, 'alumno@peals.com', '6367C48DD193D56EA7B0BAAD25B19455E529F5EE', 'Adrian', 'Mondolo', '1988-08-11', 203, '2013-07-06 05:49:27', NULL, 3, NULL, 2),
(17, 'alumno2@peals.com', '6367C48DD193D56EA7B0BAAD25B19455E529F5EE', 'Julieta', 'Curdi', '1988-08-11', 203, '2013-07-06 05:49:27', NULL, 3, NULL, 2),
(18, 'alumno3@peals.com', '6367C48DD193D56EA7B0BAAD25B19455E529F5EE', 'Claudio', 'Mazzaglia', '1988-08-11', 203, '2013-07-06 05:49:27', NULL, 3, NULL, 2),
(19, 'alumno4@peals.com', '6367C48DD193D56EA7B0BAAD25B19455E529F5EE', 'Heber', 'Parrucci', '1988-08-11', 203, '2013-07-06 05:49:27', NULL, 3, NULL, 2),
(20, 'alumno5@peals.com', '6367C48DD193D56EA7B0BAAD25B19455E529F5EE', 'Valeria', 'Gerez', '1988-08-11', 203, '2013-07-06 05:49:27', NULL, 3, NULL, 2),
(21, 'alumno6@peals.com', '6367C48DD193D56EA7B0BAAD25B19455E529F5EE', 'Emmanuel', 'Ferreyra', '1988-08-11', 203, '2013-07-06 05:49:27', NULL, 3, NULL, 2),
(22, 'alumno7@peals.com', '6367C48DD193D56EA7B0BAAD25B19455E529F5EE', 'Marilina', 'Ferreri', '1988-08-11', 203, '2013-07-06 05:49:27', NULL, 3, NULL, 2),
(23, 'alumno8@peals.com', '6367C48DD193D56EA7B0BAAD25B19455E529F5EE', 'Marcelo', 'Perea', '1988-08-11', 203, '2013-07-06 05:49:27', NULL, 3, NULL, 2),
(24, 'alumno9@peals.com', '6367C48DD193D56EA7B0BAAD25B19455E529F5EE', 'Candelaria', 'Funes', '1988-08-11', 203, '2013-07-06 05:49:27', NULL, 3, NULL, 2),
(25, 'alumno10@peals.com', '6367C48DD193D56EA7B0BAAD25B19455E529F5EE', 'Joel', 'Monti', '1988-08-11', 203, '2013-07-06 05:49:27', NULL, 3, NULL, 2),
(26, 'alumno11@peals.com', '6367C48DD193D56EA7B0BAAD25B19455E529F5EE', 'Soledad', 'Diaz', '1988-08-11', 203, '2013-07-06 05:49:27', NULL, 3, NULL, 2),
(27, 'alumno12@peals.com', '6367C48DD193D56EA7B0BAAD25B19455E529F5EE', 'Luci', 'Borgi', '1988-08-11', 203, '2013-07-06 05:49:27', NULL, 3, NULL, 2),
(28, 'alumno13@peals.com', '6367C48DD193D56EA7B0BAAD25B19455E529F5EE', 'Patricio', 'Del Boca', '1988-08-11', 203, '2013-07-06 05:49:27', NULL, 3, NULL, 2),
(29, 'alumno14@peals.com', '6367C48DD193D56EA7B0BAAD25B19455E529F5EE', 'Adrian', 'Gonzalo', '1988-08-11', 203, '2013-07-06 05:49:27', NULL, 3, NULL, 2),
(30, 'alumno15@peals.com', '6367C48DD193D56EA7B0BAAD25B19455E529F5EE', 'Silvia', 'Muñoz', '1988-08-11', 203, '2013-07-06 05:49:27', NULL, 3, NULL, 2),
(31, 'alumno16@peals.com', '6367C48DD193D56EA7B0BAAD25B19455E529F5EE', 'Alexis', 'Voisard', '1988-08-11', 203, '2013-07-06 05:49:27', NULL, 3, NULL, 2),
(32, 'alumno17@peals.com', '6367C48DD193D56EA7B0BAAD25B19455E529F5EE', 'Mauro', 'Bornoroni', '1988-08-11', 203, '2013-07-06 05:49:27', NULL, 3, NULL, 2),
(33, 'alumno18@peals.com', '6367C48DD193D56EA7B0BAAD25B19455E529F5EE', 'Florencia', 'Blanco', '1988-08-11', 203, '2013-07-06 05:49:27', NULL, 3, NULL, 2),
(34, 'alumno19@peals.com', '6367C48DD193D56EA7B0BAAD25B19455E529F5EE', 'Ana', 'Bernardi', '1988-08-11', 203, '2013-07-06 05:49:27', NULL, 3, NULL, 2),
(35, 'alumno20@peals.com', '6367C48DD193D56EA7B0BAAD25B19455E529F5EE', 'Belen', 'Montenegro', '1988-08-11', 203, '2013-07-06 05:49:27', NULL, 3, NULL, 2),
(36, 'alumno21@peals.com', '6367C48DD193D56EA7B0BAAD25B19455E529F5EE', 'Roberto', 'Gazzera', '1988-08-11', 203, '2013-07-06 05:49:27', NULL, 3, NULL, 2),
(37, 'alumno22@peals.com', '6367C48DD193D56EA7B0BAAD25B19455E529F5EE', 'Luciano', 'Dominguez', '1988-08-11', 203, '2013-07-06 05:49:27', NULL, 3, NULL, 2),
(38, 'alumno23@peals.com', '6367C48DD193D56EA7B0BAAD25B19455E529F5EE', 'Marcos', 'Quintana', '1988-08-11', 203, '2013-07-06 05:49:27', NULL, 3, NULL, 2),
(39, 'alumno24@peals.com', '6367C48DD193D56EA7B0BAAD25B19455E529F5EE', 'Leandro', 'Pighi', '1988-08-11', 203, '2013-07-06 05:49:27', NULL, 3, NULL, 2),
(40, 'alumno25@peals.com', '6367C48DD193D56EA7B0BAAD25B19455E529F5EE', 'Federico', 'Alvarez', '1988-08-11', 203, '2013-07-06 05:49:27', NULL, 3, NULL, 2),
(41, 'alumno26@peals.com', '6367C48DD193D56EA7B0BAAD25B19455E529F5EE', 'Angeles', 'Baez', '1988-08-11', 203, '2013-07-06 05:49:27', NULL, 3, NULL, 2),
(42, 'alumno27@peals.com', '6367C48DD193D56EA7B0BAAD25B19455E529F5EE', 'Cristian', 'Panella', '1988-08-11', 203, '2013-07-06 05:49:27', NULL, 3, NULL, 2),
(43, 'alumno28@peals.com', '6367C48DD193D56EA7B0BAAD25B19455E529F5EE', 'Laura', 'Gomez', '1988-08-11', 203, '2013-07-06 05:49:27', NULL, 3, NULL, 2),
(44, 'alumno29@peals.com', '6367C48DD193D56EA7B0BAAD25B19455E529F5EE', 'Nicolas', 'Rosales', '1988-08-11', 203, '2013-07-06 05:49:27', NULL, 3, NULL, 2),
(45, 'alumno30@peals.com', '6367C48DD193D56EA7B0BAAD25B19455E529F5EE', 'Ignacio', 'Costa', '1988-08-11', 203, '2013-07-06 05:49:27', NULL, 3, NULL, 2),
(46, 'alumno31@peals.com', '6367C48DD193D56EA7B0BAAD25B19455E529F5EE', 'Carmen', 'Garcia', '1988-08-11', 203, '2013-07-06 05:49:27', NULL, 3, NULL, 2),
(47, 'alumno32@peals.com', '6367C48DD193D56EA7B0BAAD25B19455E529F5EE', 'Emilia', 'Camps', '1988-08-11', 215, '2013-07-06 05:49:27', NULL, 3, NULL, 2),
(48, 'alumno33@peals.com', '6367C48DD193D56EA7B0BAAD25B19455E529F5EE', 'Maxi', 'Zoppini', '1988-08-11', 215, '2013-07-06 05:49:27', NULL, 3, NULL, 2),
(49, 'alumno34@peals.com', '6367C48DD193D56EA7B0BAAD25B19455E529F5EE', 'Santiago', 'Patarca', '1988-08-11', 215, '2013-07-06 05:49:27', NULL, 3, NULL, 2),
(50, 'alumno35@peals.com', '6367C48DD193D56EA7B0BAAD25B19455E529F5EE', 'Santiago', 'Miño', '1988-08-11', 215, '2013-07-06 05:49:27', NULL, 3, NULL, 2),
(51, 'alumno36@peals.com', '6367C48DD193D56EA7B0BAAD25B19455E529F5EE', 'Alejandro', 'Alvarez', '1988-08-11', 215, '2013-07-06 05:49:27', NULL, 3, NULL, 2),
(52, 'alumno37@peals.com', '6367C48DD193D56EA7B0BAAD25B19455E529F5EE', 'Emmanuel', 'Bello', '1988-08-11', 203, '2013-07-06 05:49:27', NULL, 3, NULL, 2),
(53, 'alumno38@peals.com', '6367C48DD193D56EA7B0BAAD25B19455E529F5EE', 'Facundo', 'Ludueña', '1988-08-11', 203, '2013-07-06 05:49:27', NULL, 3, NULL, 2),
(54, 'alumno39@peals.com', '6367C48DD193D56EA7B0BAAD25B19455E529F5EE', 'Melani', 'Boore', '1988-08-11', 203, '2013-07-06 05:49:27', NULL, 3, NULL, 1),
(55, 'alumno40@peals.com', '6367C48DD193D56EA7B0BAAD25B19455E529F5EE', 'Alumno', 'Alumno', '1988-08-11', 203, '2013-07-06 05:49:27', '2014-01-11 00:00:00', 3, NULL, 3),
(56, 'martin@peals.com', '7C4A8D09CA3762AF61E59520943DC26494F8941B', 'Martín', 'Arebalo', '1983-06-11', 221, '2015-06-23 19:16:49', NULL, 1, NULL, NULL),
(57, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL),
(58, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL),
(59, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL),
(60, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL),
(61, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL),
(62, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL),
(63, 'martingra@gmail.com', '6367C48DD193D56EA7B0BAAD25B19455E529F5EE', 'Martin', 'Grama', '1988-11-01', 209, '2016-01-12 19:22:08', NULL, 1, NULL, NULL);

--
-- Índices para tablas volcadas
--

--
-- Indices de la tabla `actividad`
--
ALTER TABLE `actividad`
 ADD PRIMARY KEY (`id`), ADD KEY `fk_docente_actividad` (`docente`), ADD KEY `fk_actividad_criterio` (`criterio`);

--
-- Indices de la tabla `actividad_x_curso`
--
ALTER TABLE `actividad_x_curso`
 ADD PRIMARY KEY (`id`), ADD KEY `fk_actividad_actividadXcurso` (`actividad`), ADD KEY `fk_curso_actividadXcurso` (`curso`);

--
-- Indices de la tabla `adjuntos`
--
ALTER TABLE `adjuntos`
 ADD PRIMARY KEY (`id`), ADD KEY `fk_adjuntos` (`mensaje`);

--
-- Indices de la tabla `alumno_x_curso`
--
ALTER TABLE `alumno_x_curso`
 ADD PRIMARY KEY (`id`), ADD KEY `fk_alumno_alumnoXcurso` (`alumno`), ADD KEY `fk_curso_alumnoXcurso` (`curso`);

--
-- Indices de la tabla `alumno_x_institucion`
--
ALTER TABLE `alumno_x_institucion`
 ADD PRIMARY KEY (`id`), ADD KEY `fk_alumno_alumnoXinstitucion` (`alumno`), ADD KEY `fk_institucion_alumnoXinstitucion` (`institucion`);

--
-- Indices de la tabla `criterio_evaluacion`
--
ALTER TABLE `criterio_evaluacion`
 ADD PRIMARY KEY (`id`), ADD KEY `fk_criterio_intervalo` (`intervalo`);

--
-- Indices de la tabla `curso`
--
ALTER TABLE `curso`
 ADD PRIMARY KEY (`id`), ADD KEY `fk_turno_curso` (`turno`), ADD KEY `fk_nivel_curso` (`nivel`), ADD KEY `fk_docente_curso` (`docente`), ADD KEY `fk_institucion_curso` (`institucion`);

--
-- Indices de la tabla `diac`
--
ALTER TABLE `diac`
 ADD PRIMARY KEY (`id`), ADD KEY `fk_diac_institucion` (`institucion`);

--
-- Indices de la tabla `docente_x_institucion`
--
ALTER TABLE `docente_x_institucion`
 ADD PRIMARY KEY (`id`), ADD KEY `fk_docente_docenteXinstitucion` (`docente`), ADD KEY `fk_institucion_docenteXinstitucion` (`institucion`);

--
-- Indices de la tabla `ejercicio`
--
ALTER TABLE `ejercicio`
 ADD PRIMARY KEY (`id`), ADD KEY `fk_actividad_ejercicio` (`actividad`), ADD KEY `fk_actividad_senia_idx` (`senia`);

--
-- Indices de la tabla `ejercicio_x_recurso`
--
ALTER TABLE `ejercicio_x_recurso`
 ADD PRIMARY KEY (`id`), ADD KEY `fk_actividad_actividadXrecurso` (`ejercicio`), ADD KEY `fk_recurso_actividadXrecurso` (`recurso`);

--
-- Indices de la tabla `especialidad`
--
ALTER TABLE `especialidad`
 ADD PRIMARY KEY (`id`);

--
-- Indices de la tabla `estado_mensaje`
--
ALTER TABLE `estado_mensaje`
 ADD PRIMARY KEY (`id`);

--
-- Indices de la tabla `estado_usuario`
--
ALTER TABLE `estado_usuario`
 ADD PRIMARY KEY (`id`);

--
-- Indices de la tabla `historial_actividad`
--
ALTER TABLE `historial_actividad`
 ADD PRIMARY KEY (`id`), ADD KEY `fk_actividad_historialActividad` (`actividad`), ADD KEY `fk_alumno_historialActividad` (`alumno`), ADD KEY `fk_historial_actividad_institucion` (`institucion`);

--
-- Indices de la tabla `informacion`
--
ALTER TABLE `informacion`
 ADD PRIMARY KEY (`id`);

--
-- Indices de la tabla `institucion`
--
ALTER TABLE `institucion`
 ADD PRIMARY KEY (`id`), ADD KEY `fk_localidad_institucion` (`localidad`), ADD KEY `fk_administrador_institucion` (`administrador`), ADD KEY `fk_informacion_institucion` (`informacion`);

--
-- Indices de la tabla `intervalo`
--
ALTER TABLE `intervalo`
 ADD PRIMARY KEY (`id`), ADD KEY `fk_intervalo_recurso` (`recurso`);

--
-- Indices de la tabla `item`
--
ALTER TABLE `item`
 ADD PRIMARY KEY (`id`), ADD KEY `FK_ITEM_DIAC` (`diac`), ADD KEY `FK_ITEM_SEGUIMIENTO` (`seguimiento`);

--
-- Indices de la tabla `llenadoseguimiento`
--
ALTER TABLE `llenadoseguimiento`
 ADD PRIMARY KEY (`id`), ADD KEY `FK_LLENADO_DOCENTE` (`docente`), ADD KEY `FK_LLENADO_ALUMNO` (`alumno`), ADD KEY `FK_LLENADO_DIAC` (`diac`), ADD KEY `FK_LLENADO_SEGUIMIENTO` (`seguimiento`), ADD KEY `FK_LLENADO_CURSO` (`curso`);

--
-- Indices de la tabla `llenadoseguimientodetalle`
--
ALTER TABLE `llenadoseguimientodetalle`
 ADD PRIMARY KEY (`id`), ADD KEY `FK_LS_ITEM` (`item`), ADD KEY `FK_LS_ADJUNTO` (`adjunto`), ADD KEY `FK_LS_OPCION` (`opcion`), ADD KEY `FK_LS_LLENADOSEGUIMIENTO` (`llenadoseguimiento`);

--
-- Indices de la tabla `localidad`
--
ALTER TABLE `localidad`
 ADD PRIMARY KEY (`id`), ADD KEY `fk_provincia_localidad` (`provincia`);

--
-- Indices de la tabla `mensaje`
--
ALTER TABLE `mensaje`
 ADD PRIMARY KEY (`id`), ADD KEY `fk_mensaje_tipo_mensaje` (`tipo_mensaje`), ADD KEY `fk_mensaje_estado_mensaje` (`estado_mensaje`);

--
-- Indices de la tabla `mensaje_x_destinatario`
--
ALTER TABLE `mensaje_x_destinatario`
 ADD PRIMARY KEY (`id`), ADD KEY `fk_mensaje_x_destinatario_mensaje` (`mensaje`), ADD KEY `fk_mensaje_x_destinatario_destinatario` (`destinatario`);

--
-- Indices de la tabla `nivel`
--
ALTER TABLE `nivel`
 ADD PRIMARY KEY (`id`);

--
-- Indices de la tabla `opcion`
--
ALTER TABLE `opcion`
 ADD PRIMARY KEY (`id`), ADD KEY `FK_OPCION_ITEM` (`item`);

--
-- Indices de la tabla `pais`
--
ALTER TABLE `pais`
 ADD PRIMARY KEY (`id`);

--
-- Indices de la tabla `provincia`
--
ALTER TABLE `provincia`
 ADD PRIMARY KEY (`id`), ADD KEY `fk_pais_provincia` (`pais`);

--
-- Indices de la tabla `recurso`
--
ALTER TABLE `recurso`
 ADD PRIMARY KEY (`id`), ADD KEY `fk_tipoRecurso_recurso` (`tipo_recurso`), ADD KEY `fk_usuario_recurso` (`subido_por`);

--
-- Indices de la tabla `recurso_compartido`
--
ALTER TABLE `recurso_compartido`
 ADD PRIMARY KEY (`id`), ADD KEY `fk_recurso_rc` (`recurso`), ADD KEY `fk_institucion_rc` (`institucion`);

--
-- Indices de la tabla `seguimiento`
--
ALTER TABLE `seguimiento`
 ADD PRIMARY KEY (`id`), ADD KEY `fk_seguimiento_curso` (`curso`);

--
-- Indices de la tabla `senia`
--
ALTER TABLE `senia`
 ADD PRIMARY KEY (`id`);

--
-- Indices de la tabla `texto`
--
ALTER TABLE `texto`
 ADD PRIMARY KEY (`id`), ADD KEY `fk_actividad_text` (`actividad`);

--
-- Indices de la tabla `tipo_mensaje`
--
ALTER TABLE `tipo_mensaje`
 ADD PRIMARY KEY (`id`);

--
-- Indices de la tabla `tipo_recurso`
--
ALTER TABLE `tipo_recurso`
 ADD PRIMARY KEY (`id`);

--
-- Indices de la tabla `tipo_usuario`
--
ALTER TABLE `tipo_usuario`
 ADD PRIMARY KEY (`id`);

--
-- Indices de la tabla `turno`
--
ALTER TABLE `turno`
 ADD PRIMARY KEY (`id`);

--
-- Indices de la tabla `usuario`
--
ALTER TABLE `usuario`
 ADD PRIMARY KEY (`id`), ADD KEY `fk_localidad_usuario` (`localidad`), ADD KEY `fk_tipoUsuario_usuario` (`tipo_usuario`), ADD KEY `fk_especialidad_docente` (`especialidad`), ADD KEY `fk_estadoUsuario_usuario` (`estado_usuario`);

--
-- AUTO_INCREMENT de las tablas volcadas
--

--
-- AUTO_INCREMENT de la tabla `actividad`
--
ALTER TABLE `actividad`
MODIFY `id` int(11) NOT NULL AUTO_INCREMENT,AUTO_INCREMENT=7;
--
-- AUTO_INCREMENT de la tabla `actividad_x_curso`
--
ALTER TABLE `actividad_x_curso`
MODIFY `id` int(11) NOT NULL AUTO_INCREMENT,AUTO_INCREMENT=6;
--
-- AUTO_INCREMENT de la tabla `adjuntos`
--
ALTER TABLE `adjuntos`
MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;
--
-- AUTO_INCREMENT de la tabla `alumno_x_curso`
--
ALTER TABLE `alumno_x_curso`
MODIFY `id` int(11) NOT NULL AUTO_INCREMENT,AUTO_INCREMENT=4;
--
-- AUTO_INCREMENT de la tabla `alumno_x_institucion`
--
ALTER TABLE `alumno_x_institucion`
MODIFY `id` int(11) NOT NULL AUTO_INCREMENT,AUTO_INCREMENT=2;
--
-- AUTO_INCREMENT de la tabla `criterio_evaluacion`
--
ALTER TABLE `criterio_evaluacion`
MODIFY `id` int(11) NOT NULL AUTO_INCREMENT,AUTO_INCREMENT=3;
--
-- AUTO_INCREMENT de la tabla `curso`
--
ALTER TABLE `curso`
MODIFY `id` int(11) NOT NULL AUTO_INCREMENT,AUTO_INCREMENT=10;
--
-- AUTO_INCREMENT de la tabla `diac`
--
ALTER TABLE `diac`
MODIFY `id` int(11) NOT NULL AUTO_INCREMENT,AUTO_INCREMENT=3;
--
-- AUTO_INCREMENT de la tabla `docente_x_institucion`
--
ALTER TABLE `docente_x_institucion`
MODIFY `id` int(11) NOT NULL AUTO_INCREMENT,AUTO_INCREMENT=4;
--
-- AUTO_INCREMENT de la tabla `ejercicio`
--
ALTER TABLE `ejercicio`
MODIFY `id` int(11) NOT NULL AUTO_INCREMENT,AUTO_INCREMENT=12;
--
-- AUTO_INCREMENT de la tabla `ejercicio_x_recurso`
--
ALTER TABLE `ejercicio_x_recurso`
MODIFY `id` int(11) NOT NULL AUTO_INCREMENT,AUTO_INCREMENT=14;
--
-- AUTO_INCREMENT de la tabla `especialidad`
--
ALTER TABLE `especialidad`
MODIFY `id` int(11) NOT NULL AUTO_INCREMENT,AUTO_INCREMENT=6;
--
-- AUTO_INCREMENT de la tabla `estado_mensaje`
--
ALTER TABLE `estado_mensaje`
MODIFY `id` int(11) NOT NULL AUTO_INCREMENT,AUTO_INCREMENT=7;
--
-- AUTO_INCREMENT de la tabla `estado_usuario`
--
ALTER TABLE `estado_usuario`
MODIFY `id` int(11) NOT NULL AUTO_INCREMENT,AUTO_INCREMENT=4;
--
-- AUTO_INCREMENT de la tabla `historial_actividad`
--
ALTER TABLE `historial_actividad`
MODIFY `id` int(11) NOT NULL AUTO_INCREMENT,AUTO_INCREMENT=10;
--
-- AUTO_INCREMENT de la tabla `informacion`
--
ALTER TABLE `informacion`
MODIFY `id` int(11) NOT NULL AUTO_INCREMENT,AUTO_INCREMENT=8;
--
-- AUTO_INCREMENT de la tabla `institucion`
--
ALTER TABLE `institucion`
MODIFY `id` int(11) NOT NULL AUTO_INCREMENT,AUTO_INCREMENT=8;
--
-- AUTO_INCREMENT de la tabla `intervalo`
--
ALTER TABLE `intervalo`
MODIFY `id` int(11) NOT NULL AUTO_INCREMENT,AUTO_INCREMENT=3;
--
-- AUTO_INCREMENT de la tabla `item`
--
ALTER TABLE `item`
MODIFY `id` int(11) NOT NULL AUTO_INCREMENT,AUTO_INCREMENT=15;
--
-- AUTO_INCREMENT de la tabla `llenadoseguimiento`
--
ALTER TABLE `llenadoseguimiento`
MODIFY `id` int(11) NOT NULL AUTO_INCREMENT,AUTO_INCREMENT=5;
--
-- AUTO_INCREMENT de la tabla `llenadoseguimientodetalle`
--
ALTER TABLE `llenadoseguimientodetalle`
MODIFY `id` int(11) NOT NULL AUTO_INCREMENT,AUTO_INCREMENT=20;
--
-- AUTO_INCREMENT de la tabla `localidad`
--
ALTER TABLE `localidad`
MODIFY `id` int(11) NOT NULL AUTO_INCREMENT,AUTO_INCREMENT=658;
--
-- AUTO_INCREMENT de la tabla `mensaje`
--
ALTER TABLE `mensaje`
MODIFY `id` int(11) NOT NULL AUTO_INCREMENT,AUTO_INCREMENT=72;
--
-- AUTO_INCREMENT de la tabla `mensaje_x_destinatario`
--
ALTER TABLE `mensaje_x_destinatario`
MODIFY `id` int(11) NOT NULL AUTO_INCREMENT,AUTO_INCREMENT=77;
--
-- AUTO_INCREMENT de la tabla `nivel`
--
ALTER TABLE `nivel`
MODIFY `id` int(11) NOT NULL AUTO_INCREMENT,AUTO_INCREMENT=7;
--
-- AUTO_INCREMENT de la tabla `opcion`
--
ALTER TABLE `opcion`
MODIFY `id` int(11) NOT NULL AUTO_INCREMENT,AUTO_INCREMENT=12;
--
-- AUTO_INCREMENT de la tabla `pais`
--
ALTER TABLE `pais`
MODIFY `id` int(11) NOT NULL AUTO_INCREMENT,AUTO_INCREMENT=13;
--
-- AUTO_INCREMENT de la tabla `provincia`
--
ALTER TABLE `provincia`
MODIFY `id` int(11) NOT NULL AUTO_INCREMENT,AUTO_INCREMENT=134;
--
-- AUTO_INCREMENT de la tabla `recurso`
--
ALTER TABLE `recurso`
MODIFY `id` int(11) NOT NULL AUTO_INCREMENT,AUTO_INCREMENT=7;
--
-- AUTO_INCREMENT de la tabla `recurso_compartido`
--
ALTER TABLE `recurso_compartido`
MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;
--
-- AUTO_INCREMENT de la tabla `seguimiento`
--
ALTER TABLE `seguimiento`
MODIFY `id` int(11) NOT NULL AUTO_INCREMENT,AUTO_INCREMENT=2;
--
-- AUTO_INCREMENT de la tabla `texto`
--
ALTER TABLE `texto`
MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;
--
-- AUTO_INCREMENT de la tabla `tipo_mensaje`
--
ALTER TABLE `tipo_mensaje`
MODIFY `id` int(11) NOT NULL AUTO_INCREMENT,AUTO_INCREMENT=4;
--
-- AUTO_INCREMENT de la tabla `tipo_recurso`
--
ALTER TABLE `tipo_recurso`
MODIFY `id` int(11) NOT NULL AUTO_INCREMENT,AUTO_INCREMENT=5;
--
-- AUTO_INCREMENT de la tabla `tipo_usuario`
--
ALTER TABLE `tipo_usuario`
MODIFY `id` int(11) NOT NULL AUTO_INCREMENT,AUTO_INCREMENT=4;
--
-- AUTO_INCREMENT de la tabla `turno`
--
ALTER TABLE `turno`
MODIFY `id` int(11) NOT NULL AUTO_INCREMENT,AUTO_INCREMENT=4;
--
-- AUTO_INCREMENT de la tabla `usuario`
--
ALTER TABLE `usuario`
MODIFY `id` int(11) NOT NULL AUTO_INCREMENT,AUTO_INCREMENT=64;
--
-- Restricciones para tablas volcadas
--

--
-- Filtros para la tabla `actividad`
--
ALTER TABLE `actividad`
ADD CONSTRAINT `fk_actividad_criterio` FOREIGN KEY (`criterio`) REFERENCES `criterio_evaluacion` (`id`),
ADD CONSTRAINT `fk_docente_actividad` FOREIGN KEY (`docente`) REFERENCES `usuario` (`id`);

--
-- Filtros para la tabla `actividad_x_curso`
--
ALTER TABLE `actividad_x_curso`
ADD CONSTRAINT `fk_actividad_actividadXcurso` FOREIGN KEY (`actividad`) REFERENCES `actividad` (`id`),
ADD CONSTRAINT `fk_curso_actividadXcurso` FOREIGN KEY (`curso`) REFERENCES `curso` (`id`);

--
-- Filtros para la tabla `adjuntos`
--
ALTER TABLE `adjuntos`
ADD CONSTRAINT `fk_adjuntos` FOREIGN KEY (`mensaje`) REFERENCES `mensaje` (`id`);

--
-- Filtros para la tabla `alumno_x_curso`
--
ALTER TABLE `alumno_x_curso`
ADD CONSTRAINT `fk_alumno_alumnoXcurso` FOREIGN KEY (`alumno`) REFERENCES `usuario` (`id`),
ADD CONSTRAINT `fk_curso_alumnoXcurso` FOREIGN KEY (`curso`) REFERENCES `curso` (`id`);

--
-- Filtros para la tabla `alumno_x_institucion`
--
ALTER TABLE `alumno_x_institucion`
ADD CONSTRAINT `fk_alumno_alumnoXinstitucion` FOREIGN KEY (`alumno`) REFERENCES `usuario` (`id`),
ADD CONSTRAINT `fk_institucion_alumnoXinstitucion` FOREIGN KEY (`institucion`) REFERENCES `institucion` (`id`);

--
-- Filtros para la tabla `criterio_evaluacion`
--
ALTER TABLE `criterio_evaluacion`
ADD CONSTRAINT `fk_criterio_intervalo` FOREIGN KEY (`intervalo`) REFERENCES `intervalo` (`id`);

--
-- Filtros para la tabla `curso`
--
ALTER TABLE `curso`
ADD CONSTRAINT `fk_docente_curso` FOREIGN KEY (`docente`) REFERENCES `usuario` (`id`),
ADD CONSTRAINT `fk_institucion_curso` FOREIGN KEY (`institucion`) REFERENCES `institucion` (`id`),
ADD CONSTRAINT `fk_nivel_curso` FOREIGN KEY (`nivel`) REFERENCES `nivel` (`id`),
ADD CONSTRAINT `fk_turno_curso` FOREIGN KEY (`turno`) REFERENCES `turno` (`id`);

--
-- Filtros para la tabla `diac`
--
ALTER TABLE `diac`
ADD CONSTRAINT `fk_diac_institucion` FOREIGN KEY (`institucion`) REFERENCES `institucion` (`id`);

--
-- Filtros para la tabla `docente_x_institucion`
--
ALTER TABLE `docente_x_institucion`
ADD CONSTRAINT `fk_docente_docenteXinstitucion` FOREIGN KEY (`docente`) REFERENCES `usuario` (`id`),
ADD CONSTRAINT `fk_institucion_docenteXinstitucion` FOREIGN KEY (`institucion`) REFERENCES `institucion` (`id`);

--
-- Filtros para la tabla `ejercicio`
--
ALTER TABLE `ejercicio`
ADD CONSTRAINT `fk_actividad_ejercicio` FOREIGN KEY (`actividad`) REFERENCES `actividad` (`id`),
ADD CONSTRAINT `fk_actividad_senia` FOREIGN KEY (`senia`) REFERENCES `senia` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION;

--
-- Filtros para la tabla `ejercicio_x_recurso`
--
ALTER TABLE `ejercicio_x_recurso`
ADD CONSTRAINT `fk_ejercicio_ejercicioXrecurso` FOREIGN KEY (`ejercicio`) REFERENCES `ejercicio` (`id`),
ADD CONSTRAINT `fk_recurso_ejercicioXrecurso` FOREIGN KEY (`recurso`) REFERENCES `recurso` (`id`);

--
-- Filtros para la tabla `historial_actividad`
--
ALTER TABLE `historial_actividad`
ADD CONSTRAINT `fk_actividad_historialActividad` FOREIGN KEY (`actividad`) REFERENCES `actividad` (`id`),
ADD CONSTRAINT `fk_alumno_historialActividad` FOREIGN KEY (`alumno`) REFERENCES `usuario` (`id`),
ADD CONSTRAINT `fk_historial_actividad_institucion` FOREIGN KEY (`institucion`) REFERENCES `institucion` (`id`);

--
-- Filtros para la tabla `institucion`
--
ALTER TABLE `institucion`
ADD CONSTRAINT `fk_administrador_institucion` FOREIGN KEY (`administrador`) REFERENCES `usuario` (`id`),
ADD CONSTRAINT `fk_informacion_institucion` FOREIGN KEY (`informacion`) REFERENCES `informacion` (`id`),
ADD CONSTRAINT `fk_localidad_institucion` FOREIGN KEY (`localidad`) REFERENCES `localidad` (`id`);

--
-- Filtros para la tabla `intervalo`
--
ALTER TABLE `intervalo`
ADD CONSTRAINT `fk_intervalo_recurso` FOREIGN KEY (`recurso`) REFERENCES `recurso` (`id`);

--
-- Filtros para la tabla `item`
--
ALTER TABLE `item`
ADD CONSTRAINT `FK_ITEM_DIAC` FOREIGN KEY (`diac`) REFERENCES `diac` (`id`),
ADD CONSTRAINT `FK_ITEM_SEGUIMIENTO` FOREIGN KEY (`seguimiento`) REFERENCES `seguimiento` (`id`);

--
-- Filtros para la tabla `llenadoseguimiento`
--
ALTER TABLE `llenadoseguimiento`
ADD CONSTRAINT `FK_LLENADO_ALUMNO` FOREIGN KEY (`alumno`) REFERENCES `usuario` (`id`),
ADD CONSTRAINT `FK_LLENADO_CURSO` FOREIGN KEY (`curso`) REFERENCES `curso` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
ADD CONSTRAINT `FK_LLENADO_DIAC` FOREIGN KEY (`diac`) REFERENCES `diac` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
ADD CONSTRAINT `FK_LLENADO_DOCENTE` FOREIGN KEY (`docente`) REFERENCES `usuario` (`id`),
ADD CONSTRAINT `FK_LLENADO_SEGUIMIENTO` FOREIGN KEY (`seguimiento`) REFERENCES `seguimiento` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION;

--
-- Filtros para la tabla `llenadoseguimientodetalle`
--
ALTER TABLE `llenadoseguimientodetalle`
ADD CONSTRAINT `FK_LS_ITEM` FOREIGN KEY (`item`) REFERENCES `item` (`id`),
ADD CONSTRAINT `FK_LS_LLENADOSEGUIMIENTO` FOREIGN KEY (`llenadoseguimiento`) REFERENCES `llenadoseguimiento` (`id`),
ADD CONSTRAINT `FK_LS_OPCION` FOREIGN KEY (`opcion`) REFERENCES `opcion` (`id`);

--
-- Filtros para la tabla `localidad`
--
ALTER TABLE `localidad`
ADD CONSTRAINT `fk_provincia_localidad` FOREIGN KEY (`provincia`) REFERENCES `provincia` (`id`);

--
-- Filtros para la tabla `mensaje`
--
ALTER TABLE `mensaje`
ADD CONSTRAINT `fk_mensaje_estado_mensaje` FOREIGN KEY (`estado_mensaje`) REFERENCES `estado_mensaje` (`id`),
ADD CONSTRAINT `fk_mensaje_tipo_mensaje` FOREIGN KEY (`tipo_mensaje`) REFERENCES `tipo_mensaje` (`id`);

--
-- Filtros para la tabla `mensaje_x_destinatario`
--
ALTER TABLE `mensaje_x_destinatario`
ADD CONSTRAINT `fk_mensaje_x_destinatario_destinatario` FOREIGN KEY (`destinatario`) REFERENCES `usuario` (`id`),
ADD CONSTRAINT `fk_mensaje_x_destinatario_mensaje` FOREIGN KEY (`mensaje`) REFERENCES `mensaje` (`id`);

--
-- Filtros para la tabla `opcion`
--
ALTER TABLE `opcion`
ADD CONSTRAINT `FK_OPCION_ITEM` FOREIGN KEY (`item`) REFERENCES `item` (`id`);

--
-- Filtros para la tabla `provincia`
--
ALTER TABLE `provincia`
ADD CONSTRAINT `fk_pais_provincia` FOREIGN KEY (`pais`) REFERENCES `pais` (`id`);

--
-- Filtros para la tabla `recurso`
--
ALTER TABLE `recurso`
ADD CONSTRAINT `fk_tipoRecurso_recurso` FOREIGN KEY (`tipo_recurso`) REFERENCES `tipo_recurso` (`id`),
ADD CONSTRAINT `fk_usuario_recurso` FOREIGN KEY (`subido_por`) REFERENCES `usuario` (`id`);

--
-- Filtros para la tabla `recurso_compartido`
--
ALTER TABLE `recurso_compartido`
ADD CONSTRAINT `fk_institucion_rc` FOREIGN KEY (`institucion`) REFERENCES `institucion` (`id`),
ADD CONSTRAINT `fk_recurso_rc` FOREIGN KEY (`recurso`) REFERENCES `recurso` (`id`);

--
-- Filtros para la tabla `seguimiento`
--
ALTER TABLE `seguimiento`
ADD CONSTRAINT `fk_seguimiento_curso` FOREIGN KEY (`curso`) REFERENCES `curso` (`id`);

--
-- Filtros para la tabla `texto`
--
ALTER TABLE `texto`
ADD CONSTRAINT `fk_actividad_text` FOREIGN KEY (`actividad`) REFERENCES `actividad` (`id`);

--
-- Filtros para la tabla `usuario`
--
ALTER TABLE `usuario`
ADD CONSTRAINT `fk_especialidad_docente` FOREIGN KEY (`especialidad`) REFERENCES `especialidad` (`id`),
ADD CONSTRAINT `fk_estadoUsuario_usuario` FOREIGN KEY (`estado_usuario`) REFERENCES `estado_usuario` (`id`),
ADD CONSTRAINT `fk_localidad_usuario` FOREIGN KEY (`localidad`) REFERENCES `localidad` (`id`),
ADD CONSTRAINT `fk_tipoUsuario_usuario` FOREIGN KEY (`tipo_usuario`) REFERENCES `tipo_usuario` (`id`);

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
