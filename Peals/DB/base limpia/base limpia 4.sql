-- phpMyAdmin SQL Dump
-- version 4.2.11
-- http://www.phpmyadmin.net
--
-- Servidor: 127.0.0.1
-- Tiempo de generación: 13-03-2016 a las 20:36:57
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
  `videoExplicacion` varchar(200) DEFAULT NULL
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8;

--
-- Volcado de datos para la tabla `actividad`
--

INSERT INTO `actividad` (`id`, `nombre`, `fecha_alta`, `es_publica`, `docente`, `descripcion`, `estado`, `criterio`, `videoExplicacion`) VALUES
(4, 'NUMEROS CON SEÑAS', '2016-03-07', NULL, 66, 'Te vamos a mostrar distintos números. Deberás realizar la seña correspondiente en cada caso.', 1, 1, NULL);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `actividad_x_curso`
--

CREATE TABLE IF NOT EXISTS `actividad_x_curso` (
`id` int(11) NOT NULL,
  `actividad` int(11) DEFAULT NULL,
  `curso` int(11) DEFAULT NULL,
  `fecha_apertura` datetime DEFAULT NULL
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8;

--
-- Volcado de datos para la tabla `actividad_x_curso`
--

INSERT INTO `actividad_x_curso` (`id`, `actividad`, `curso`, `fecha_apertura`) VALUES
(1, 4, 5, '2015-03-05 00:00:00'),
(2, 4, 6, '2016-03-06 00:00:00');

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
) ENGINE=InnoDB AUTO_INCREMENT=72 DEFAULT CHARSET=utf8;

--
-- Volcado de datos para la tabla `alumno_x_curso`
--

INSERT INTO `alumno_x_curso` (`id`, `alumno`, `curso`, `fecha_asignacion`) VALUES
(1, 126, 6, '2016-02-18'),
(2, 67, 1, '2016-02-18'),
(3, 68, 1, '2016-02-18'),
(4, 69, 1, '2016-02-18'),
(5, 70, 1, '2016-02-18'),
(6, 71, 1, '2016-02-18'),
(7, 72, 1, '2016-02-18'),
(8, 73, 1, '2016-02-18'),
(9, 74, 1, '2016-02-18'),
(10, 75, 1, '2016-02-18'),
(11, 76, 1, '2016-02-18'),
(12, 77, 2, '2016-02-18'),
(13, 78, 2, '2016-02-18'),
(14, 79, 2, '2016-02-18'),
(15, 80, 2, '2016-02-18'),
(16, 81, 2, '2016-02-18'),
(17, 82, 2, '2016-02-18'),
(18, 83, 2, '2016-02-18'),
(19, 84, 2, '2016-02-18'),
(20, 85, 2, '2016-02-18'),
(21, 86, 2, '2016-02-18'),
(22, 87, 3, '2016-02-18'),
(23, 88, 3, '2016-02-18'),
(24, 89, 3, '2016-02-18'),
(25, 90, 3, '2016-02-18'),
(26, 91, 3, '2016-02-18'),
(27, 92, 3, '2016-02-18'),
(28, 93, 3, '2016-02-18'),
(29, 94, 3, '2016-02-18'),
(30, 95, 3, '2016-02-18'),
(31, 96, 3, '2016-02-18'),
(32, 97, 4, '2016-02-18'),
(33, 98, 4, '2016-02-18'),
(34, 99, 4, '2016-02-18'),
(35, 100, 4, '2016-02-18'),
(36, 101, 4, '2016-02-18'),
(37, 102, 4, '2016-02-18'),
(38, 103, 4, '2016-02-18'),
(39, 104, 4, '2016-02-18'),
(40, 105, 4, '2016-02-18'),
(41, 106, 4, '2016-02-18'),
(42, 107, 5, '2016-02-18'),
(43, 108, 5, '2016-02-18'),
(44, 109, 5, '2016-02-18'),
(45, 110, 5, '2016-02-18'),
(46, 111, 5, '2016-02-18'),
(47, 112, 5, '2016-02-18'),
(48, 113, 5, '2016-02-18'),
(49, 114, 5, '2016-02-18'),
(50, 115, 5, '2016-02-18'),
(51, 116, 5, '2016-02-18'),
(52, 117, 6, '2016-02-18'),
(53, 118, 6, '2016-02-18'),
(54, 119, 6, '2016-02-18'),
(55, 120, 6, '2016-02-18'),
(56, 121, 6, '2016-02-18'),
(57, 122, 6, '2016-02-18'),
(58, 123, 6, '2016-02-18'),
(59, 124, 6, '2016-02-18'),
(60, 125, 6, '2016-02-18'),
(61, 127, 1, '2016-03-07'),
(62, 127, 9, '2016-03-07'),
(63, 166, 10, '2016-03-07'),
(64, 158, 11, '2016-03-13'),
(65, 159, 11, '2016-03-13'),
(66, 160, 11, '2016-03-13'),
(67, 161, 11, '2016-03-13'),
(68, 162, 11, '2016-03-13'),
(69, 163, 11, '2016-03-13'),
(70, 164, 12, '2016-03-13'),
(71, 165, 12, '2016-03-13');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `alumno_x_institucion`
--

CREATE TABLE IF NOT EXISTS `alumno_x_institucion` (
`id` int(11) NOT NULL,
  `alumno` int(11) DEFAULT NULL,
  `institucion` int(11) DEFAULT NULL,
  `fecha_alta` date DEFAULT NULL
) ENGINE=InnoDB AUTO_INCREMENT=72 DEFAULT CHARSET=utf8;

--
-- Volcado de datos para la tabla `alumno_x_institucion`
--

INSERT INTO `alumno_x_institucion` (`id`, `alumno`, `institucion`, `fecha_alta`) VALUES
(1, 126, 8, '2016-02-18'),
(2, 67, 8, '2016-02-18'),
(3, 68, 8, '2016-02-18'),
(4, 69, 8, '2016-02-18'),
(5, 70, 8, '2016-02-18'),
(6, 71, 8, '2016-02-18'),
(7, 72, 8, '2016-02-18'),
(8, 73, 8, '2016-02-18'),
(9, 74, 8, '2016-02-18'),
(10, 75, 8, '2016-02-18'),
(11, 76, 8, '2016-02-18'),
(12, 77, 8, '2016-02-18'),
(13, 78, 8, '2016-02-18'),
(14, 79, 8, '2016-02-18'),
(15, 80, 8, '2016-02-18'),
(16, 81, 8, '2016-02-18'),
(17, 82, 8, '2016-02-18'),
(18, 83, 8, '2016-02-18'),
(19, 84, 8, '2016-02-18'),
(20, 85, 8, '2016-02-18'),
(21, 86, 8, '2016-02-18'),
(22, 87, 8, '2016-02-18'),
(23, 88, 8, '2016-02-18'),
(24, 89, 8, '2016-02-18'),
(25, 90, 8, '2016-02-18'),
(26, 91, 8, '2016-02-18'),
(27, 92, 8, '2016-02-18'),
(28, 93, 8, '2016-02-18'),
(29, 94, 8, '2016-02-18'),
(30, 95, 8, '2016-02-18'),
(31, 96, 8, '2016-02-18'),
(32, 97, 8, '2016-02-18'),
(33, 98, 8, '2016-02-18'),
(34, 99, 8, '2016-02-18'),
(35, 100, 8, '2016-02-18'),
(36, 101, 8, '2016-02-18'),
(37, 102, 8, '2016-02-18'),
(38, 103, 8, '2016-02-18'),
(39, 104, 8, '2016-02-18'),
(40, 105, 8, '2016-02-18'),
(41, 106, 8, '2016-02-18'),
(42, 107, 8, '2016-02-18'),
(43, 108, 8, '2016-02-18'),
(44, 109, 8, '2016-02-18'),
(45, 110, 8, '2016-02-18'),
(46, 111, 8, '2016-02-18'),
(47, 112, 8, '2016-02-18'),
(48, 113, 8, '2016-02-18'),
(49, 114, 8, '2016-02-18'),
(50, 115, 8, '2016-02-18'),
(51, 116, 8, '2016-02-18'),
(52, 117, 8, '2016-02-18'),
(53, 118, 8, '2016-02-18'),
(54, 119, 8, '2016-02-18'),
(55, 120, 8, '2016-02-18'),
(56, 121, 8, '2016-02-18'),
(57, 122, 8, '2016-02-18'),
(58, 123, 8, '2016-02-18'),
(59, 124, 8, '2016-02-18'),
(60, 125, 8, '2016-02-18'),
(61, 127, 8, '2016-03-07'),
(62, 127, 9, '2016-03-07'),
(63, 166, 9, '2016-03-07'),
(64, 158, 10, '2016-03-13'),
(65, 159, 10, '2016-03-13'),
(66, 160, 10, '2016-03-13'),
(67, 161, 10, '2016-03-13'),
(68, 162, 10, '2016-03-13'),
(69, 163, 10, '2016-03-13'),
(70, 164, 10, '2016-03-13'),
(71, 165, 10, '2016-03-13');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `criterio_evaluacion`
--

CREATE TABLE IF NOT EXISTS `criterio_evaluacion` (
`id` int(11) NOT NULL,
  `docente` int(11) DEFAULT NULL,
  `nombre` varchar(100) DEFAULT NULL,
  `descripcion` varchar(600) DEFAULT NULL
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8;

--
-- Volcado de datos para la tabla `criterio_evaluacion`
--

INSERT INTO `criterio_evaluacion` (`id`, `docente`, `nombre`, `descripcion`) VALUES
(1, 66, 'Muy Bien', '<intervalos><intervalo value=''0''>-1</intervalo><intervalo value=''50''>-1</intervalo><intervalo value=''75''>-1</intervalo><intervalo value=''100''>-1</intervalo></intervalos>');

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
) ENGINE=InnoDB AUTO_INCREMENT=13 DEFAULT CHARSET=utf8;

--
-- Volcado de datos para la tabla `curso`
--

INSERT INTO `curso` (`id`, `turno`, `nivel`, `ano`, `division`, `docente`, `institucion`, `es_publico`, `nombre`, `descripcion`, `estado`) VALUES
(1, 2, 2, 1, 'A', 65, 8, NULL, '1A', 'Curso paralelo a primero A del único turno del nivel primario, en el módulo de Enseñanza de la Lengua Oral durante las tardes.', 1),
(2, 2, 2, 1, 'B', 65, 8, NULL, '1B', 'Curso paralelo a primero A del único turno del nivel primario, en el módulo de Enseñanza de la Lengua Oral durante las tardes.', 1),
(3, 2, 2, 2, 'A', 65, 8, NULL, '2A', 'Curso paralelo a segundo A del único turno del nivel primario, en el módulo de Enseñanza de la Lengua Oral durante las tardes.', 1),
(4, 2, 2, 2, 'B', 65, 8, NULL, '2B', 'Curso paralelo a segundo B del único turno del nivel primario, en el módulo de Enseñanza de la Lengua Oral durante las tardes.', 1),
(5, 2, 2, 3, 'A', 66, 8, NULL, '3A', 'Curso paralelo a tercero A del único turno del nivel primario, en el módulo de Enseñanza de la Lengua Oral durante las tardes.', 1),
(6, 2, 2, 3, 'B', 66, 8, NULL, '3B', 'Curso paralelo a tercero B del único turno del nivel primario, en el módulo de Enseñanza de la Lengua Oral durante las tardes.', 1),
(7, 2, 2, 4, 'A', NULL, 8, NULL, '4A', 'Curso paralelo a cuarto A del único turno del nivel primario, en el módulo de Enseñanza de la Lengua Oral durante las tardes.', 1),
(8, 2, 2, 4, 'B', NULL, 8, NULL, '4B', 'Curso paralelo a cuarto B del único turno del nivel primario, en el módulo de Enseñanza de la Lengua Oral durante las tardes.', 1),
(9, 1, 4, 1, 'A', 65, 9, NULL, 'Curso general básico', 'Curso inicial para capacitadores en lengua de seña.', 1),
(10, 1, 4, 2, 'A', 65, 9, NULL, 'Curso general avanzado', 'Curso avanzado para formadores de alumnos sordos.', 1),
(11, 3, 4, 1, 'G', 174, 10, NULL, 'Introducción al Lenguaje de Señas Argentino', 'Planteamos una introducción general al lenguaje de señas, con el fin de que los participantes tengan un primer contacto y una familiarización con los principios básicos de ésta tematica.', 1),
(12, 3, 4, 1, 'E', 175, 10, NULL, 'Letras y números', 'En este curso planteamos la incorporación de aquellas personas sin ningún conocimiento en el lenguaje de señas, para que comiencen su aprendizaje con letras y números', 1);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `diac`
--

CREATE TABLE IF NOT EXISTS `diac` (
`id` int(11) NOT NULL,
  `institucion` int(11) DEFAULT NULL,
  `activo` int(11) DEFAULT NULL
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8;

--
-- Volcado de datos para la tabla `diac`
--

INSERT INTO `diac` (`id`, `institucion`, `activo`) VALUES
(1, 8, 0),
(2, 8, 0),
(3, 8, 1),
(4, 10, 1);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `docente_x_institucion`
--

CREATE TABLE IF NOT EXISTS `docente_x_institucion` (
`id` int(11) NOT NULL,
  `docente` int(11) DEFAULT NULL,
  `institucion` int(11) DEFAULT NULL,
  `fecha_alta` date DEFAULT NULL
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8;

--
-- Volcado de datos para la tabla `docente_x_institucion`
--

INSERT INTO `docente_x_institucion` (`id`, `docente`, `institucion`, `fecha_alta`) VALUES
(1, 65, 8, '2016-02-16'),
(2, 66, 8, '2016-02-16'),
(3, 65, 9, '2016-03-07'),
(4, 174, 10, '2016-03-13'),
(5, 175, 10, '2016-03-13');

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
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8;

--
-- Volcado de datos para la tabla `ejercicio`
--

INSERT INTO `ejercicio` (`id`, `texto_solucion`, `deletreo`, `recurso_correcto`, `actividad`, `senia`) VALUES
(1, NULL, 0, NULL, 4, 3),
(2, NULL, 0, NULL, 4, 4),
(3, NULL, 0, NULL, 4, 5),
(4, NULL, 0, NULL, 4, 6),
(5, NULL, 0, NULL, 4, 7);

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
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8;

--
-- Volcado de datos para la tabla `ejercicio_x_recurso`
--

INSERT INTO `ejercicio_x_recurso` (`id`, `ejercicio`, `recurso`, `pos_top`, `pos_left`) VALUES
(1, 1, 1, '0px', '0px'),
(2, 2, 1, '0px', '0px'),
(3, 3, 1, '0px', '0px'),
(4, 4, 1, '0px', '0px'),
(5, 5, 1, '0px', '0px');

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
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8;

--
-- Volcado de datos para la tabla `historial_actividad`
--

INSERT INTO `historial_actividad` (`id`, `alumno`, `docente`, `curso`, `institucion`, `calificacion_docente`, `calificacion_sistema`, `fecha_realizacion`, `intentos`, `actividad`, `uso_ayuda_consigna`, `uso_ayuda_actividad`, `tiempo`, `ejerciciosNoResueltos`, `totalEjercicios`) VALUES
(1, 107, 66, 5, 8, 100, 70, '2016-03-07 19:43:44', 1, 4, 1, 1, '00:00:48', 0, 5);

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
) ENGINE=InnoDB AUTO_INCREMENT=11 DEFAULT CHARSET=utf8;

--
-- Volcado de datos para la tabla `informacion`
--

INSERT INTO `informacion` (`id`, `contenido`, `encabezado`, `introduccion`, `imagen`, `video`) VALUES
(8, 'Escuela Esp. Bilingüe Para Sordos (Ibis), pertenece a la educación pública estatal, Educación Especial, Educación Especial Nivel Inicial, Educación Especial Primaria, Estimulación Temprana, Ayuda a la Integración Escolar, Estimulación Temprana.\r<br />\r<br />Perfil del Alumnado:\r<br />\r<br /># Niños y jóvenes con discapacidades auditiva, sordos e hipoacúsicos.\r<br /># Niños y jóvenes con Trastornos Específicos del Lenguaje – TEL - Disfasia\r<br />\r<br />Metodología Educativa Bilingüe para la educación de la persona sorda\r<br />\r<br />1) Lengua de Señas: Lengua natural de la persona sorda, primera lengua.\r<br />2) Lengua Oral: Segunda lengua, necesaria para la integración a la comunidad mayoritaria\r<br />\r<br />Educación basada en sistemas aumentativos y alternativos de comunicación para personas con TEL:\r<br />1) Señas\r<br />2) Gestos – mímica\r<br />3) Dibujos – imágenes\r<br />4) Deletreo \r<br />\r<br />Propuesta pedagógica: \r<br /># Nivel Inicial: Jornada extendida\r<br /># Nivel Primario: \r<br />    - Alumnos con discapacidad auditiva: Jornada doble\r<br />         * Turno mañana: contenidos curriculares en Lengua de Señas Argentina\r<br />         * Turno tarde: enseñanza de la Lengua Oral \r<br />    - Alumnos con TEL: Jornada extendida\r<br />\r<br />#Nivel secundario: Jornada extendida', 'Esc. Esp. Bilingüe para Sordos (IBIS) Córdoba', 'En nuestra Escuela, son las manos las que dibujan en el aire los mensajes,...\r<br />los movimientos nuestras palabras... y el espacio nuestra pizarra.', '~/Content/Resources/Uploads/1502YYYY205012', NULL),
(9, 'La Escuela Municipal para niños Sordos e Hipoacúsicos "Dr. Ramón Carrillo", surgió como escuela integradora de niños con patología auditiva en el nivel Inicial y Primario , el día 5 de mayo de 1988.\r<br />Su creación responde a la inquietud de una mamá que se desempeñaba en la Dirección de Educación, llamado Franco Di Tommaso.\r<br />En sus inicios funcionó en la Casa de la Catequesis de Morón, con dos docentes, una fonoaudióloga y diez alumnos.\r<br />La metodología aplicada en la enseñanza era el oralismo.\r<br />Con el correr de los años, la escuela creció y debió mudarse; en el año 1991 al sindicato del Cuero, donde apenas permaneció alrededor de 12 meses.\r<br />Una vez más hicimos nuestras valijas, cargamos nuestros sueños y nos trasladamos a la Casa Habitación de la Escuela Nº14. Aquí nos quedamos hasta fines de 1996; cuando por última vez volvimos a juntar nuestras ilusiones, proyectos y ganas de tener "nuestra escuela" para mudarnos\r<br />a los Andes 2122 de Haedo, "nuestra casa" Estábamos tan felices que hicimos una gran fiesta, a la que vinieron autoridades muy importantes como ser el gobernador de la provincia de Bs. As., Dr. Eduardo Duhalde, la Sra. Ministra de Educación de la Prov. de Bs. As, Prof. Graciela Gianestasio, el señor Intendente Municipal, Juan Carlos Rousselot, la Directora de educación , Lic. Haidee Migliore, la Inspectora de DIEGEP la Sra. Maria Elena del Campo y otras autoridades del Municipio.\r<br />Nuestros alumnos festejaron con una sorpresa para todos, cantando la canción "Sueña" de Luis Miguel, pues nuestro sueño se había hecho realidad.\r<br />Así fue que desde el ciclo lectivo 1997 la Escuela Municipal para niños sordos e Hipoacúsicos "Dr. Ramón Carrillo", tiene su corazón en Haedo.\r<br />\r<br />Aquí nuestro proyecto pedagógico tomó un nuevo rumbo, ya que nos convertimos en "Escuela Bilingüe" (lengua oral-lengua de señas) afirmándonos en la declaración de la UNESCO en relación con el derecho de todo niño a educarse en su lengua natural', '20 años construyendo la educación de la persona sorda', '\r<br />    Atención temprana  del niño y niña sordo menor de3 años.\r<br />    Nivel Inicial (a partir de los 3 años).\r<br />    EP común y especial (enseñanza bilingüe en lengua oral y lengua de señas).\r<br />    Grupo de Reeducación del Lenguaje.\r<br />    Evaluación  a alumnos con Trastornos Específicos del Lenguaje.\r<br />    Integración Escolar de alumnos hipoacúsicos y con trastornos del lenguaje(Inicial, EP, Secundario y  Cap. Laboral).\r<br />    Equipo de Lengua Oral.\r<br />    equipo de Lengua de Señas.\r<br />    Educación Física.\r<br />    Natación.\r<br />    Musicoterapia.·\r<br />    Equipo Orientador Escolar.\r<br />    Taller de Lengua Escrita como segunda lengua.\r<br />    Taller Pre-Profesional con orientación a Gastronomía" Aula Taller de Cocicna"\r<br />    Taller de Improvisación Rítmica.\r<br />    Taller Literario.\r<br />    Taller de Computación ( en boxes individuales).\r<br />    Coro "Amigos" (interpretación de canciones en LSA)\r<br />    Taller de Lengua de Señas pa', '~/Content/Resources/Uploads/1303YYYY161816', NULL),
(10, 'Nuestra labor se centra fundamentalmente en:\r<br />\r<br />*la Carrera Oficial de Intérprete Técnico Superior de Lengua de Señas Argentina (A-1340), con título expedido por la Secretaría de Educación del Gobierno de la Ciudad de Buenos Aires y con reconocimiento a nivel nacional;\r<br />\r<br />*los Cursos de Lengua de Señas Argentina reconocidos por el Gobierno de la Ciudad de Buenos Aires (C-148) y también por el Gobierno de la Provincia de Buenos Aires (D4-000081), que otorgan a los docentes el puntaje correspondiente por cada nivel que realizan;\r<br />\r<br />*los Cursos de Lengua de Señas Argentina en las distintas provincias de nuestro país;\r<br />\r<br />*los Cursos especialmente diseñados para satisfacer las necesidades de instituciones y empresas ante cada solicitud;\r<br />\r<br />*la Cobertura de Intérpretes de LSA en todos los ámbitos donde se requiera su labor;\r<br />\r<br />*la capacitación y asesoramiento a instituciones y docentes de todas las áreas del sistema educativo para la puesta en marcha de proyectos bilingües en escuelas para sordos;\r<br />\r<br />*la orientación a padres, familiares, amigos, compañeros de trabajo de las personas sordas con el fin de dar respuesta a cada necesidad que presenten;\r<br />\r<br />*la investigación, difusión y concientización sobre los aspectos culturales, sociales y lingüísticos de la comunidad sorda;\r<br />\r<br />*la elaboración y edición de bibliografía especialmente diseñada para la formación de profesionales de alto nivel académico.\r<br />\r<br />El Instituto Villasoles está conformado por una importante cantidad de personas sordas pertenecientes a la comunidad de hablantes nativos de la lengua de señas argentina, reconocidos por su idoneidad lingüística  y cultural, que trabajan profesionalmente compartiendo la labor con profesores oyentes provenientes de diferentes áreas, con experiencia probada en este campo y formación académica de excelencia.\r<br />\r<br />De este modo, sordos y oyentes trabajamos día a día con el ', 'Instituto Superior Villasoles - Lengua de señas Argentina', 'Desde 1987, líderes en la formación de Intérpretes para Sordos.\r<br />\r<br />El Instituto Villasoles, pionero en esta temática, ha marcado el rumbo para que la formación de Intérpretes de Lengua de Señas Argentina sea una realidad en nuestro país y en el extranjero. Nuestra extensa trayectoria dedicada a la investigación, difusión, elaboración de bibliografía y enseñanza de la Lengua de Señas Argentina (LSA) hace que hoy la institución sea considerada líder por los aportes que ha realizado a favor de la comunidad sorda.', '~/Content/Resources/Uploads/1303YYYY153514', NULL);

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
) ENGINE=InnoDB AUTO_INCREMENT=11 DEFAULT CHARSET=utf8;

--
-- Volcado de datos para la tabla `institucion`
--

INSERT INTO `institucion` (`id`, `nombre`, `telefono`, `calle`, `altura_calle`, `piso`, `departamento`, `localidad`, `administrador`, `fecha_alta`, `informacion`) VALUES
(8, 'IBIS Córdoba', '03514332351', 'Santa Rosa', 340, NULL, NULL, 203, 64, '2016-02-15', 8),
(9, 'Escuela Municipal para sordos e hipoacusicos "Dr. Ramón Carrillo"', '01148546364', 'Los Andes ', 2122, NULL, NULL, 131, 167, '2016-03-07', 9),
(10, 'Villasoles Asociación Civil', '01148546364', 'Gurruchaga ', 568, NULL, NULL, 131, 64, '2016-03-13', 10);

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
) ENGINE=InnoDB AUTO_INCREMENT=100 DEFAULT CHARSET=utf8;

--
-- Volcado de datos para la tabla `item`
--

INSERT INTO `item` (`id`, `descripcion`, `grupo`, `ordenGrupo`, `ordenItem`, `diac`, `seguimiento`, `tipoItem`, `estado`, `ayuda`) VALUES
(1, 'Sexo', 'Datos de Identificación', 1, 3, 1, NULL, 3, NULL, ''),
(2, 'Nivel socioafectivo y lingüístico', 'Datos Personales', 2, 3, 1, NULL, 3, NULL, ''),
(3, 'Nivel económico', 'Datos Familiares', 3, 1, 1, NULL, 3, NULL, ''),
(4, 'Nivel cultural', 'Datos Familiares', 3, 2, 1, NULL, 3, NULL, ''),
(5, 'Comprende mensajes  y responde a ellos oralmente ', 'Comunicación y representación', 4, 1, 1, NULL, 3, NULL, ''),
(6, 'Aumenta  su capacidad  de atención y de escucha ', 'Comunicación y representación', 4, 2, 1, NULL, 3, NULL, ''),
(7, 'Realiza imitaciones del adulto a través de juegos y  canciones ', 'Comunicación y representación', 4, 3, 1, NULL, 3, NULL, ''),
(8, 'Aumenta el vocabulario con respecto a su edad ', 'Comunicación y representación', 4, 4, 1, NULL, 3, NULL, ''),
(9, 'Pronuncia  mayoría de los fonemas', 'Comunicación y representación', 4, 5, 1, NULL, 3, NULL, ''),
(10, 'Conoce las vocales', 'Lectura', 5, 1, 1, NULL, 3, NULL, ''),
(11, 'Conoce las consonantes', 'Lectura', 5, 2, 1, NULL, 3, NULL, ''),
(12, 'Lee sílabas directas ', 'Lectura', 5, 3, 1, NULL, 3, NULL, ''),
(13, 'Lee sílabas inversas ', 'Lectura', 5, 4, 1, NULL, 3, NULL, ''),
(14, 'Posee un trazo gráfico adecuado ', 'Escritura', 6, 1, 1, NULL, 3, NULL, ''),
(15, 'Realiza correctamente las vocales', 'Escritura', 6, 2, 1, NULL, 3, NULL, ''),
(16, 'Realiza correctamente las consonantes', 'Escritura', 6, 3, 1, NULL, 3, NULL, ''),
(17, 'Realiza dictados de palabra', 'Escritura', 6, 4, 1, NULL, 3, NULL, ''),
(18, 'Nombre y Apellido', 'Datos de Identificación', 1, 1, 1, NULL, 1, NULL, ''),
(19, 'Dirección', 'Datos de Identificación', 1, 2, 1, NULL, 1, NULL, ''),
(20, 'DNI', 'Datos de Identificación', 1, 4, 1, NULL, 1, NULL, ''),
(21, 'Fotocopia DNI', 'Datos de Identificación', 1, 5, 1, NULL, 1, NULL, ''),
(22, 'Variables cognitivas', 'Datos Personales', 2, 1, 1, NULL, 2, NULL, ''),
(23, 'Vaiables motrices', 'Datos Personales', 2, 2, 1, NULL, 2, NULL, ''),
(24, 'Datos médicos y biológicos', 'Datos Personales', 2, 4, 1, NULL, 2, NULL, ''),
(25, 'Sexo', 'Datos de Identificación', 1, 3, 2, NULL, 3, NULL, ''),
(26, 'Nivel socioafectivo y lingüístico', 'Datos Personales', 2, 3, 2, NULL, 3, NULL, ''),
(27, 'Nivel económico', 'Datos Familiares', 3, 1, 2, NULL, 3, NULL, ''),
(28, 'Nivel cultural', 'Datos Familiares', 3, 2, 2, NULL, 3, NULL, ''),
(29, 'Comprende mensajes  y responde a ellos oralmente ', 'Comunicación y representación', 4, 1, 2, NULL, 3, NULL, ''),
(30, 'Aumenta  su capacidad  de atención y de escucha ', 'Comunicación y representación', 4, 2, 2, NULL, 3, NULL, ''),
(31, 'Realiza imitaciones del adulto a través de juegos y  canciones ', 'Comunicación y representación', 4, 3, 2, NULL, 3, NULL, ''),
(32, 'Aumenta el vocabulario con respecto a su edad ', 'Comunicación y representación', 4, 4, 2, NULL, 3, NULL, ''),
(33, 'Pronuncia  mayoría de los fonemas', 'Comunicación y representación', 4, 5, 2, NULL, 3, NULL, ''),
(34, 'Conoce las vocales', 'Lectura', 5, 1, 2, NULL, 3, NULL, ''),
(35, 'Conoce las consonantes', 'Lectura', 5, 2, 2, NULL, 3, NULL, ''),
(36, 'Lee sílabas directas ', 'Lectura', 5, 3, 2, NULL, 3, NULL, ''),
(37, 'Lee sílabas inversas ', 'Lectura', 5, 4, 2, NULL, 3, NULL, ''),
(38, 'Posee un trazo gráfico adecuado ', 'Escritura', 6, 1, 2, NULL, 3, NULL, ''),
(39, 'Realiza correctamente las vocales', 'Escritura', 6, 2, 2, NULL, 3, NULL, ''),
(40, 'Realiza correctamente las consonantes', 'Escritura', 6, 3, 2, NULL, 3, NULL, ''),
(41, 'Realiza dictados de palabra', 'Escritura', 6, 4, 2, NULL, 3, NULL, ''),
(42, 'Nombre y Apellido', 'Datos de Identificación', 1, 1, 2, NULL, 1, NULL, 'Respetar orden: Nombre Apellido'),
(43, 'Dirección', 'Datos de Identificación', 1, 2, 2, NULL, 1, NULL, 'Incluir calle + nro + Localidad + Provincia'),
(44, 'DNI', 'Datos de Identificación', 1, 4, 2, NULL, 1, NULL, ''),
(45, 'Fotocopia DNI', 'Datos de Identificación', 1, 5, 2, NULL, 1, NULL, 'Ingresamos la fotocopia del DNI para poder llevar un registro fehaciente de nuestros alumnos'),
(46, 'Variables cognitivas', 'Datos Personales', 2, 1, 2, NULL, 2, NULL, ''),
(47, 'Vaiables motrices', 'Datos Personales', 2, 2, 2, NULL, 2, NULL, ''),
(48, 'Datos médicos y biológicos', 'Datos Personales', 2, 4, 2, NULL, 2, NULL, ''),
(49, 'Sexo', 'Datos de Identificación', 1, 3, 3, NULL, 3, NULL, ''),
(50, 'Nivel socioafectivo y lingüístico', 'Datos Personales', 2, 3, 3, NULL, 3, NULL, 'Por favor, respetar este dato ya que es muy importante para agilizar tiempos'),
(51, 'Nivel económico', 'Datos Familiares', 3, 1, 3, NULL, 3, NULL, ''),
(52, 'Nivel cultural', 'Datos Familiares', 3, 2, 3, NULL, 3, NULL, ''),
(53, 'Comprende mensajes  y responde a ellos oralmente ', 'Comunicación y representación', 4, 1, 3, NULL, 3, NULL, ''),
(54, 'Aumenta  su capacidad  de atención y de escucha ', 'Comunicación y representación', 4, 2, 3, NULL, 3, NULL, ''),
(55, 'Realiza imitaciones del adulto a través de juegos y  canciones ', 'Comunicación y representación', 4, 3, 3, NULL, 3, NULL, ''),
(56, 'Aumenta el vocabulario con respecto a su edad ', 'Comunicación y representación', 4, 4, 3, NULL, 3, NULL, ''),
(57, 'Pronuncia  mayoría de los fonemas', 'Comunicación y representación', 4, 5, 3, NULL, 3, NULL, ''),
(58, 'Conoce las vocales', 'Lectura', 5, 1, 3, NULL, 3, NULL, ''),
(59, 'Conoce las consonantes', 'Lectura', 5, 2, 3, NULL, 3, NULL, ''),
(60, 'Lee sílabas directas ', 'Lectura', 5, 3, 3, NULL, 3, NULL, ''),
(61, 'Lee sílabas inversas ', 'Lectura', 5, 4, 3, NULL, 3, NULL, ''),
(62, 'Posee un trazo gráfico adecuado ', 'Escritura', 6, 1, 3, NULL, 3, NULL, ''),
(63, 'Realiza correctamente las vocales', 'Escritura', 6, 2, 3, NULL, 3, NULL, ''),
(64, 'Realiza correctamente las consonantes', 'Escritura', 6, 3, 3, NULL, 3, NULL, ''),
(65, 'Realiza dictados de palabra', 'Escritura', 6, 4, 3, NULL, 3, NULL, ''),
(66, 'Nombre y Apellido', 'Datos de Identificación', 1, 1, 3, NULL, 1, NULL, 'Respetar orden: Nombre Apellido'),
(67, 'Dirección', 'Datos de Identificación', 1, 2, 3, NULL, 1, NULL, 'Incluir calle + nro + Localidad + Provincia'),
(68, 'DNI', 'Datos de Identificación', 1, 4, 3, NULL, 1, NULL, ''),
(69, 'Fotocopia DNI', 'Datos de Identificación', 1, 5, 3, NULL, 4, NULL, 'Ingresamos la fotocopia del DNI para poder llevar un registro fehaciente de nuestros alumnos'),
(70, 'Variables cognitivas', 'Datos Personales', 2, 1, 3, NULL, 2, NULL, ''),
(71, 'Vaiables motrices', 'Datos Personales', 2, 2, 3, NULL, 2, NULL, ''),
(72, 'Datos médicos y biológicos', 'Datos Personales', 2, 4, 3, NULL, 2, NULL, ''),
(73, 'Compañerismo', 'Desempeño', 1, 1, NULL, 1, 3, NULL, ''),
(74, 'Lectura', 'Desempeño', 1, 2, NULL, 1, 3, NULL, ''),
(75, 'Escritura', 'Desempeño', 1, 3, NULL, 1, 3, NULL, ''),
(76, 'Participación', 'Desempeño', 1, 4, NULL, 1, 3, NULL, ''),
(77, 'Comunicación', 'Desempeño', 1, 5, NULL, 1, 3, NULL, ''),
(78, 'Compañerismo', 'Desempeño', 1, 1, NULL, 2, 3, NULL, 'Participación e interacción con otros compañeros'),
(79, 'Lectura', 'Desempeño', 1, 2, NULL, 2, 3, NULL, ''),
(80, 'Escritura', 'Desempeño', 1, 3, NULL, 2, 3, NULL, ''),
(81, 'Participación', 'Desempeño', 1, 4, NULL, 2, 3, NULL, ''),
(82, 'Comunicación', 'Desempeño', 1, 5, NULL, 2, 3, NULL, ''),
(83, 'Compañerismo', 'Desempeño', 1, 1, NULL, 3, 3, NULL, 'Participación e interacción con otros compañeros'),
(84, 'Lectura', 'Desempeño', 1, 2, NULL, 3, 3, NULL, ''),
(85, 'Escritura', 'Desempeño', 1, 3, NULL, 3, 3, NULL, ''),
(86, 'Participación', 'Desempeño', 1, 4, NULL, 3, 3, NULL, ''),
(87, 'Comunicación', 'Desempeño', 1, 5, NULL, 3, 3, NULL, ''),
(88, 'Sexo', 'Datos del Alumno', 1, 3, 4, NULL, 3, NULL, ''),
(89, 'Lengua oral', 'Datos de aprendizaje', 2, 1, 4, NULL, 3, NULL, ''),
(90, 'Lengua escrita', 'Datos de aprendizaje', 2, 2, 4, NULL, 3, NULL, ''),
(91, 'Señas', 'Datos de aprendizaje', 2, 3, 4, NULL, 3, NULL, ''),
(92, 'Nombre y apellido', 'Datos del Alumno', 1, 1, 4, NULL, 1, NULL, ''),
(93, 'DNI', 'Datos del Alumno', 1, 2, 4, NULL, 1, NULL, ''),
(94, 'Direccion', 'Datos del Alumno', 1, 4, 4, NULL, 2, NULL, ''),
(95, 'Lectura', 'Evaluacion', 1, 1, NULL, 4, 1, NULL, 'Valor entre 1 - 10 que indica el nivel del alumno en el tema correspondiente, sin tener en cuenta sus capacidades especiales.'),
(96, 'Habla', 'Evaluacion', 1, 2, NULL, 4, 1, NULL, 'Valor entre 1 - 10 que indica el nivel del alumno en el tema correspondiente, sin tener en cuenta sus capacidades especiales.'),
(97, 'Identificación de objetos', 'Evaluacion', 1, 3, NULL, 4, 1, NULL, 'Valor entre 1 - 10 que indica el nivel del alumno en el tema correspondiente, sin tener en cuenta sus capacidades especiales.'),
(98, 'Ortografía', 'Evaluacion', 1, 4, NULL, 4, 1, NULL, 'Valor entre 1 - 10 que indica el nivel del alumno en el tema correspondiente, sin tener en cuenta sus capacidades especiales.'),
(99, 'Coeficiente de exigencia', 'Evaluacion', 1, 5, NULL, 4, 1, NULL, 'Valor entre 1 - 10 que indique el grado de capacidad que tiene el alumno de adquirir conocimientos en relación a su capacidad diferente. Mientras más grande este valor, mayor capacidad de aprendizaje y mayor exigencia sobre el alumno');

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
) ENGINE=InnoDB AUTO_INCREMENT=27 DEFAULT CHARSET=utf8;

--
-- Volcado de datos para la tabla `llenadoseguimiento`
--

INSERT INTO `llenadoseguimiento` (`id`, `fecha`, `docente`, `alumno`, `curso`, `diac`, `seguimiento`) VALUES
(1, '2016-02-19', 65, 67, 1, 3, NULL),
(2, '2016-02-19', 65, 68, 1, 3, NULL),
(3, '2016-02-19', 65, 69, 1, 3, NULL),
(4, '2016-02-19', 65, 70, 1, 3, NULL),
(5, '2016-02-19', 65, 71, 1, 3, NULL),
(6, '2016-02-19', 65, 72, 1, 3, NULL),
(7, '2016-02-19', 65, 73, 1, 3, NULL),
(8, '2016-02-19', 65, 74, 1, 3, NULL),
(9, '2016-02-19', 65, 75, 1, 3, NULL),
(10, '2016-02-19', 65, 76, 1, 3, NULL),
(11, '2016-02-19', 65, 67, 1, NULL, 2),
(12, '2016-02-19', 65, 68, 1, NULL, 2),
(13, '2016-02-19', 65, 69, 1, NULL, 2),
(14, '2016-02-19', 65, 70, 1, NULL, 2),
(15, '2016-02-19', 65, 71, 1, NULL, 2),
(16, '2016-02-19', 65, 72, 1, NULL, 2),
(17, '2016-02-19', 65, 73, 1, NULL, 2),
(18, '2016-02-19', 65, 74, 1, NULL, 2),
(19, '2016-02-19', 65, 75, 1, NULL, 2),
(20, '2016-02-19', 65, 76, 1, NULL, 2),
(21, '2016-03-13', 174, 158, 11, NULL, 4),
(22, '2016-03-13', 174, 159, 11, NULL, 4),
(23, '2016-03-13', 174, 160, 11, NULL, 4),
(24, '2016-03-13', 174, 161, 11, NULL, 4),
(25, '2016-03-13', 174, 162, 11, NULL, 4),
(26, '2016-03-13', 174, 163, 11, NULL, 4);

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
) ENGINE=InnoDB AUTO_INCREMENT=321 DEFAULT CHARSET=utf8;

--
-- Volcado de datos para la tabla `llenadoseguimientodetalle`
--

INSERT INTO `llenadoseguimientodetalle` (`id`, `llenadoseguimiento`, `item`, `adjunto`, `opcion`, `respuesta`) VALUES
(1, 1, 66, NULL, NULL, 'Rafael Zabala'),
(2, 1, 67, NULL, NULL, 'La tablada 202, Cordoba'),
(3, 1, 49, NULL, 81, NULL),
(4, 1, 68, NULL, NULL, '43.254.256'),
(5, 1, 69, 'dni.jpg', NULL, NULL),
(6, 1, 70, NULL, NULL, 'Muy buen desempeño durante el año. Muestra superación constante acompañada por sus capacidades y entusiasmo.'),
(7, 1, 71, NULL, NULL, 'Dificultades severas como consecuencia de su condición, superada por su entusiasmo y empeño.'),
(8, 1, 50, NULL, 85, NULL),
(9, 1, 72, NULL, NULL, 'Hipoacusia severa'),
(10, 1, 51, NULL, 88, NULL),
(11, 1, 52, NULL, 92, NULL),
(12, 1, 53, NULL, 95, NULL),
(13, 1, 54, NULL, 97, NULL),
(14, 1, 55, NULL, 100, NULL),
(15, 1, 56, NULL, 102, NULL),
(16, 1, 57, NULL, 103, NULL),
(17, 1, 58, NULL, 105, NULL),
(18, 1, 59, NULL, 108, NULL),
(19, 1, 60, NULL, 109, NULL),
(20, 1, 61, NULL, 112, NULL),
(21, 1, 62, NULL, 113, NULL),
(22, 1, 63, NULL, 116, NULL),
(23, 1, 64, NULL, 118, NULL),
(24, 1, 65, NULL, 120, NULL),
(25, 2, 66, NULL, NULL, 'Carlos Herrador'),
(26, 2, 67, NULL, NULL, 'Las moras 1042, Córdoba'),
(27, 2, 49, NULL, 81, NULL),
(28, 2, 68, NULL, NULL, '47.259.987'),
(29, 2, 69, 'dni.jpg', NULL, NULL),
(30, 2, 70, NULL, NULL, 'Aceptable. Notorias dificultades de aprendizaje.'),
(31, 2, 71, NULL, NULL, 'No presentan mayores obstaculos'),
(32, 2, 50, NULL, 83, NULL),
(33, 2, 72, NULL, NULL, 'Hipoacucia severa.'),
(34, 2, 51, NULL, 89, NULL),
(35, 2, 52, NULL, 93, NULL),
(36, 2, 53, NULL, 95, NULL),
(37, 2, 54, NULL, 97, NULL),
(38, 2, 55, NULL, 100, NULL),
(39, 2, 56, NULL, 102, NULL),
(40, 2, 57, NULL, 104, NULL),
(41, 2, 58, NULL, 105, NULL),
(42, 2, 59, NULL, 108, NULL),
(43, 2, 60, NULL, 110, NULL),
(44, 2, 61, NULL, 112, NULL),
(45, 2, 62, NULL, 113, NULL),
(46, 2, 63, NULL, 116, NULL),
(47, 2, 64, NULL, 118, NULL),
(48, 2, 65, NULL, 120, NULL),
(49, 3, 66, NULL, NULL, ' Mariana Gallardo'),
(50, 3, 67, NULL, NULL, 'Los serros 29, Córdoba'),
(51, 3, 49, NULL, 82, NULL),
(52, 3, 68, NULL, NULL, '47.289.714'),
(53, 3, 69, 'dni.jpg', NULL, NULL),
(54, 3, 70, NULL, NULL, 'Alta capacidad de aprendizaje, limitada por la discapacidad hipoacucica.'),
(55, 3, 71, NULL, NULL, 'No presenta problemas.'),
(56, 3, 50, NULL, 84, NULL),
(57, 3, 72, NULL, NULL, 'Hipoacucia.'),
(58, 3, 51, NULL, 88, NULL),
(59, 3, 52, NULL, 93, NULL),
(60, 3, 53, NULL, 95, NULL),
(61, 3, 54, NULL, 97, NULL),
(62, 3, 55, NULL, 99, NULL),
(63, 3, 56, NULL, 101, NULL),
(64, 3, 57, NULL, 103, NULL),
(65, 3, 58, NULL, 105, NULL),
(66, 3, 59, NULL, 107, NULL),
(67, 3, 60, NULL, 109, NULL),
(68, 3, 61, NULL, 112, NULL),
(69, 3, 62, NULL, 113, NULL),
(70, 3, 63, NULL, 115, NULL),
(71, 3, 64, NULL, 118, NULL),
(72, 3, 65, NULL, 120, NULL),
(73, 4, 66, NULL, NULL, 'Enrique Garrido'),
(74, 4, 67, NULL, NULL, 'Los condores, 521'),
(75, 4, 49, NULL, 81, NULL),
(76, 4, 68, NULL, NULL, '43.912.573'),
(77, 4, 69, 'dni.jpg', NULL, NULL),
(78, 4, 70, NULL, NULL, 'Responde a las expectativas normales.'),
(79, 4, 71, NULL, NULL, 'No presenta problemas.'),
(80, 4, 50, NULL, 85, NULL),
(81, 4, 72, NULL, NULL, 'Hipoacucia'),
(82, 4, 51, NULL, 88, NULL),
(83, 4, 52, NULL, 92, NULL),
(84, 4, 53, NULL, 95, NULL),
(85, 4, 54, NULL, 97, NULL),
(86, 4, 55, NULL, 99, NULL),
(87, 4, 56, NULL, 101, NULL),
(88, 4, 57, NULL, 103, NULL),
(89, 4, 58, NULL, 105, NULL),
(90, 4, 59, NULL, 107, NULL),
(91, 4, 60, NULL, 109, NULL),
(92, 4, 61, NULL, 111, NULL),
(93, 4, 62, NULL, 113, NULL),
(94, 4, 63, NULL, 115, NULL),
(95, 4, 64, NULL, 117, NULL),
(96, 4, 65, NULL, 119, NULL),
(97, 5, 66, NULL, NULL, 'Jaime Diaz'),
(98, 5, 67, NULL, NULL, 'El Redentor 212, Villa Carlos Paz'),
(99, 5, 49, NULL, 81, NULL),
(100, 5, 68, NULL, NULL, '48.249.687'),
(101, 5, 69, 'dni.jpg', NULL, NULL),
(102, 5, 70, NULL, NULL, 'Avances significativos pero limitados.'),
(103, 5, 71, NULL, NULL, 'No presenta dificultades'),
(104, 5, 50, NULL, 84, NULL),
(105, 5, 72, NULL, NULL, 'Hipoacucia'),
(106, 5, 51, NULL, 88, NULL),
(107, 5, 52, NULL, 92, NULL),
(108, 5, 53, NULL, 95, NULL),
(109, 5, 54, NULL, 97, NULL),
(110, 5, 55, NULL, 99, NULL),
(111, 5, 56, NULL, 101, NULL),
(112, 5, 57, NULL, 103, NULL),
(113, 5, 58, NULL, 105, NULL),
(114, 5, 59, NULL, 107, NULL),
(115, 5, 60, NULL, 109, NULL),
(116, 5, 61, NULL, 111, NULL),
(117, 5, 62, NULL, 113, NULL),
(118, 5, 63, NULL, 115, NULL),
(119, 5, 64, NULL, 117, NULL),
(120, 5, 65, NULL, 119, NULL),
(121, 6, 66, NULL, NULL, 'Antonio Sanchez'),
(122, 6, 67, NULL, NULL, 'Los Ceibos, 202, Córdoba'),
(123, 6, 49, NULL, 81, NULL),
(124, 6, 68, NULL, NULL, '45.687.159'),
(125, 6, 69, 'dni.jpg', NULL, NULL),
(126, 6, 70, NULL, NULL, 'Todos los indicadores son correctos, pero presenta dificultades puntuales en el área de escritura.'),
(127, 6, 71, NULL, NULL, 'No presenta dificultades notorias.'),
(128, 6, 50, NULL, 84, NULL),
(129, 6, 72, NULL, NULL, 'Hipoacucia'),
(130, 6, 51, NULL, 89, NULL),
(131, 6, 52, NULL, 92, NULL),
(132, 6, 53, NULL, 95, NULL),
(133, 6, 54, NULL, 97, NULL),
(134, 6, 55, NULL, 99, NULL),
(135, 6, 56, NULL, 102, NULL),
(136, 6, 57, NULL, 104, NULL),
(137, 6, 58, NULL, 105, NULL),
(138, 6, 59, NULL, 107, NULL),
(139, 6, 60, NULL, 109, NULL),
(140, 6, 61, NULL, 112, NULL),
(141, 6, 62, NULL, 114, NULL),
(142, 6, 63, NULL, 116, NULL),
(143, 6, 64, NULL, 118, NULL),
(144, 6, 65, NULL, 120, NULL),
(145, 7, 66, NULL, NULL, 'Pilar Martin'),
(146, 7, 67, NULL, NULL, 'Santa Rosa 4021'),
(147, 7, 49, NULL, 82, NULL),
(148, 7, 68, NULL, NULL, '41.127.893'),
(149, 7, 69, 'dni.jpg', NULL, NULL),
(150, 7, 70, NULL, NULL, 'Alta capacidad de aprendizaje, pero problemas concretos en atención y dedicación.'),
(151, 7, 71, NULL, NULL, 'Se presentan dificultades motrices leves que no afectan la conducta y aprendizaje del alumno'),
(152, 7, 50, NULL, 84, NULL),
(153, 7, 72, NULL, NULL, 'Hipoacucia'),
(154, 7, 51, NULL, 89, NULL),
(155, 7, 52, NULL, 92, NULL),
(156, 7, 53, NULL, 95, NULL),
(157, 7, 54, NULL, 97, NULL),
(158, 7, 55, NULL, 100, NULL),
(159, 7, 56, NULL, 101, NULL),
(160, 7, 57, NULL, 103, NULL),
(161, 7, 58, NULL, 105, NULL),
(162, 7, 59, NULL, 107, NULL),
(163, 7, 60, NULL, 110, NULL),
(164, 7, 61, NULL, 112, NULL),
(165, 7, 62, NULL, 113, NULL),
(166, 7, 63, NULL, 116, NULL),
(167, 7, 64, NULL, 118, NULL),
(168, 7, 65, NULL, 120, NULL),
(169, 8, 66, NULL, NULL, 'Dolores Rodenas'),
(170, 8, 67, NULL, NULL, 'San Martin 100, Villa Carlos Paz'),
(171, 8, 49, NULL, 82, NULL),
(172, 8, 68, NULL, NULL, '41.127.298'),
(173, 8, 69, 'dni.jpg', NULL, NULL),
(174, 8, 70, NULL, NULL, 'Problema para aprendizaje de lectura y escritura'),
(175, 8, 71, NULL, NULL, 'No presenta problemas puntuales'),
(176, 8, 50, NULL, 83, NULL),
(177, 8, 72, NULL, NULL, 'Hipoacucia'),
(178, 8, 51, NULL, 87, NULL),
(179, 8, 52, NULL, 92, NULL),
(180, 8, 53, NULL, 95, NULL),
(181, 8, 54, NULL, 97, NULL),
(182, 8, 55, NULL, 99, NULL),
(183, 8, 56, NULL, 102, NULL),
(184, 8, 57, NULL, 104, NULL),
(185, 8, 58, NULL, 105, NULL),
(186, 8, 59, NULL, 107, NULL),
(187, 8, 60, NULL, 110, NULL),
(188, 8, 61, NULL, 112, NULL),
(189, 8, 62, NULL, 113, NULL),
(190, 8, 63, NULL, 116, NULL),
(191, 8, 64, NULL, 117, NULL),
(192, 8, 65, NULL, 120, NULL),
(193, 9, 66, NULL, NULL, 'Ana Maria Navarro'),
(194, 9, 67, NULL, NULL, 'Río Paraná 1020, Villa Carlos Paz'),
(195, 9, 49, NULL, 82, NULL),
(196, 9, 68, NULL, NULL, '41.289.586'),
(197, 9, 69, 'dni.jpg', NULL, NULL),
(198, 9, 70, NULL, NULL, 'Presenta dificultades puntuales en diversos indicadores de aprendizaje, pero compensa con su predisposición y entusiasmo.'),
(199, 9, 71, NULL, NULL, 'No presenta sintomas.'),
(200, 9, 50, NULL, 84, NULL),
(201, 9, 72, NULL, NULL, 'Hipoacucia'),
(202, 9, 51, NULL, 88, NULL),
(203, 9, 52, NULL, 92, NULL),
(204, 9, 53, NULL, 95, NULL),
(205, 9, 54, NULL, 97, NULL),
(206, 9, 55, NULL, 99, NULL),
(207, 9, 56, NULL, 102, NULL),
(208, 9, 57, NULL, 104, NULL),
(209, 9, 58, NULL, 105, NULL),
(210, 9, 59, NULL, 107, NULL),
(211, 9, 60, NULL, 110, NULL),
(212, 9, 61, NULL, 112, NULL),
(213, 9, 62, NULL, 113, NULL),
(214, 9, 63, NULL, 115, NULL),
(215, 9, 64, NULL, 118, NULL),
(216, 9, 65, NULL, 120, NULL),
(217, 10, 66, NULL, NULL, 'Juan Gonzalez'),
(218, 10, 67, NULL, NULL, 'Sarmiento 1234, Villa Carlos Paz, Córdoba'),
(219, 10, 49, NULL, 81, NULL),
(220, 10, 68, NULL, NULL, '47.239.548'),
(221, 10, 69, 'dni.jpg', NULL, NULL),
(222, 10, 70, NULL, NULL, 'Sin dificultades para lo esperado en este nivel.'),
(223, 10, 71, NULL, NULL, 'Sin dificultades'),
(224, 10, 50, NULL, 84, NULL),
(225, 10, 72, NULL, NULL, 'Hipoacucia'),
(226, 10, 51, NULL, 88, NULL),
(227, 10, 52, NULL, 92, NULL),
(228, 10, 53, NULL, 95, NULL),
(229, 10, 54, NULL, 97, NULL),
(230, 10, 55, NULL, 100, NULL),
(231, 10, 56, NULL, 102, NULL),
(232, 10, 57, NULL, 104, NULL),
(233, 10, 58, NULL, 105, NULL),
(234, 10, 59, NULL, 107, NULL),
(235, 10, 60, NULL, 110, NULL),
(236, 10, 61, NULL, 112, NULL),
(237, 10, 62, NULL, 113, NULL),
(238, 10, 63, NULL, 115, NULL),
(239, 10, 64, NULL, 117, NULL),
(240, 10, 65, NULL, 120, NULL),
(241, 11, 78, NULL, 137, NULL),
(242, 11, 79, NULL, 140, NULL),
(243, 11, 80, NULL, 142, NULL),
(244, 11, 81, NULL, 145, NULL),
(245, 11, 82, NULL, 149, NULL),
(246, 12, 78, NULL, 138, NULL),
(247, 12, 79, NULL, 140, NULL),
(248, 12, 80, NULL, 143, NULL),
(249, 12, 81, NULL, 146, NULL),
(250, 12, 82, NULL, 148, NULL),
(251, 13, 78, NULL, 137, NULL),
(252, 13, 79, NULL, 141, NULL),
(253, 13, 80, NULL, 142, NULL),
(254, 13, 81, NULL, 146, NULL),
(255, 13, 82, NULL, 150, NULL),
(256, 14, 78, NULL, 137, NULL),
(257, 14, 79, NULL, 139, NULL),
(258, 14, 80, NULL, 144, NULL),
(259, 14, 81, NULL, 146, NULL),
(260, 14, 82, NULL, 149, NULL),
(261, 15, 78, NULL, 138, NULL),
(262, 15, 79, NULL, 140, NULL),
(263, 15, 80, NULL, 143, NULL),
(264, 15, 81, NULL, 145, NULL),
(265, 15, 82, NULL, 148, NULL),
(266, 16, 78, NULL, 138, NULL),
(267, 16, 79, NULL, 140, NULL),
(268, 16, 80, NULL, 144, NULL),
(269, 16, 81, NULL, 147, NULL),
(270, 16, 82, NULL, 150, NULL),
(271, 17, 78, NULL, 138, NULL),
(272, 17, 79, NULL, 140, NULL),
(273, 17, 80, NULL, 142, NULL),
(274, 17, 81, NULL, 147, NULL),
(275, 17, 82, NULL, 149, NULL),
(276, 18, 78, NULL, 138, NULL),
(277, 18, 79, NULL, 140, NULL),
(278, 18, 80, NULL, 143, NULL),
(279, 18, 81, NULL, 146, NULL),
(280, 18, 82, NULL, 150, NULL),
(281, 19, 78, NULL, 136, NULL),
(282, 19, 79, NULL, 140, NULL),
(283, 19, 80, NULL, 143, NULL),
(284, 19, 81, NULL, 147, NULL),
(285, 19, 82, NULL, 150, NULL),
(286, 20, 78, NULL, 137, NULL),
(287, 20, 79, NULL, 140, NULL),
(288, 20, 80, NULL, 144, NULL),
(289, 20, 81, NULL, 145, NULL),
(290, 20, 82, NULL, 149, NULL),
(291, 21, 95, NULL, NULL, '5'),
(292, 21, 96, NULL, NULL, '2'),
(293, 21, 97, NULL, NULL, '4'),
(294, 21, 98, NULL, NULL, '2'),
(295, 21, 99, NULL, NULL, '3'),
(296, 22, 95, NULL, NULL, '6'),
(297, 22, 96, NULL, NULL, '4'),
(298, 22, 97, NULL, NULL, '8'),
(299, 22, 98, NULL, NULL, '4'),
(300, 22, 99, NULL, NULL, '5'),
(301, 23, 95, NULL, NULL, '8'),
(302, 23, 96, NULL, NULL, '8'),
(303, 23, 97, NULL, NULL, '8'),
(304, 23, 98, NULL, NULL, '8'),
(305, 23, 99, NULL, NULL, '7'),
(306, 24, 95, NULL, NULL, '6'),
(307, 24, 96, NULL, NULL, '8'),
(308, 24, 97, NULL, NULL, '4'),
(309, 24, 98, NULL, NULL, '6'),
(310, 24, 99, NULL, NULL, '5'),
(311, 25, 95, NULL, NULL, '2'),
(312, 25, 96, NULL, NULL, '3'),
(313, 25, 97, NULL, NULL, '2'),
(314, 25, 98, NULL, NULL, '3'),
(315, 25, 99, NULL, NULL, '1'),
(316, 26, 95, NULL, NULL, '5'),
(317, 26, 96, NULL, NULL, '4'),
(318, 26, 97, NULL, NULL, '6'),
(319, 26, 98, NULL, NULL, '4'),
(320, 26, 99, NULL, NULL, '5');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `localidad`
--

CREATE TABLE IF NOT EXISTS `localidad` (
`id` int(11) NOT NULL,
  `nombre` varchar(50) DEFAULT NULL,
  `provincia` int(11) DEFAULT NULL
) ENGINE=InnoDB AUTO_INCREMENT=659 DEFAULT CHARSET=utf8;

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
(657, 'Otra', 133),
(658, 'Villa Carlos Paz', 5);

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
) ENGINE=InnoDB AUTO_INCREMENT=194 DEFAULT CHARSET=utf8;

--
-- Volcado de datos para la tabla `mensaje`
--

INSERT INTO `mensaje` (`id`, `fecha_mensaje`, `titulo_mensaje`, `mensaje`, `emisor_mensaje`, `estado_mensaje`, `tipo_mensaje`, `referencia`, `tipo_solicitud`) VALUES
(1, '2016-02-16 17:58:25', 'Solicitud a docente para formar parte de la institución IBIS Córdoba', 'Hola Guillermo, cómo estás?\r\n\r\nTe escribo para invitarte a participar de la plataforma virtual de enseñanza presentada en la última reunión docente, con la  expectativa de que te sumes a esta iniciativa y puedas montar los cursos virtuales para apoyar la educación de los cursos que manejas en la institución.\r\n\r\nDesde ya muchas gracias, quedo a la espera de tu respuesta,\r\n\r\nMariana', 64, 3, 2, 8, 3),
(2, '2016-02-16 17:58:40', 'Solicitud a docente para formar parte de la institución IBIS Córdoba', 'Hola Natalia, cómo estás?\r\n\r\nTe escribo para invitarte a participar de la plataforma virtual de enseñanza presentada en la última reunión docente, con la  expectativa de que te sumes a esta iniciativa y puedas montar los cursos virtuales para apoyar la educación de los cursos que manejas en la institución.\r\n\r\nDesde ya muchas gracias, quedo a la espera de tu respuesta,\r\n\r\nMariana', 64, 4, 2, 8, 3),
(3, '2016-02-16 18:30:46', '[ACEPTADO] Respuesta a Solicitud a docente para formar parte de la institución IBIS Córdoba', 'Hola Mariana, por supuesto que me sumo al proyecto!\r\n\r\nSaludos cordiales!\r\n\r\nGuillermo', 65, 2, 3, 8, NULL),
(4, '2016-02-16 18:34:56', '[RECHAZADO] Respuesta a Solicitud a docente para formar parte de la institución IBIS Córdoba', 'Por ahora no, gracias!', 66, 2, 3, 8, NULL),
(5, '2016-02-16 18:41:01', 'Solicitud de inscripción a la institución IBIS Córdoba', 'Hola Mariana, te pido mil disculpas pero me equivoqué al rechazar la participación en la institución Ibis. Te envío entonces mi solicitud de participación en la institución.\r\n\r\nGracias, saludos!\r\n\r\nNatalia', 66, 3, 2, 8, 2),
(6, '2016-02-16 18:42:39', '[ACEPTADO] Respuesta a Solicitud de inscripción a la institución IBIS Córdoba', 'Ok Natalia, muchas gracias!\r\n\r\nMariana', 64, 2, 3, 8, NULL),
(7, '2016-02-16 18:43:49', 'Solicitud del Administrador para que usted dirija el curso: 2A', 'Solicitud del administrador para que dirija el curso', 64, 3, 2, 3, 4),
(8, '2016-02-16 18:52:15', 'Solicitud del Administrador para que usted dirija el curso: 1A', 'Hola, te asigno el curso correspondiente. Gracias! Saludos! Mariana', 64, 3, 2, 1, 4),
(9, '2016-02-16 18:54:31', 'Solicitud del Administrador para que usted dirija el curso: 1B', 'Hola, te asigno los cursos correspondiente. Gracias! Saludos! Mariana', 64, 3, 2, 2, 4),
(10, '2016-02-16 18:54:34', 'Solicitud del Administrador para que usted dirija el curso: 2B', 'Hola, te asigno los cursos correspondiente. Gracias! Saludos! Mariana', 64, 3, 2, 4, 4),
(11, '2016-02-16 18:54:54', 'Solicitud del Administrador para que usted dirija el curso: 3A', 'Hola, te asigno el curso correspondiente. Gracias! Saludos! Mariana', 64, 3, 2, 5, 4),
(12, '2016-02-16 18:54:57', 'Solicitud del Administrador para que usted dirija el curso: 3B', 'Hola, te asigno el curso correspondiente. Gracias! Saludos! Mariana', 64, 4, 2, 6, 4),
(13, '2016-02-16 18:55:42', '[ACEPTADO] Respuesta a Solicitud del Administrador para que usted dirija el curso: 2A', 'Ok, muchas gracias! Saludos!', 65, 2, 3, 3, NULL),
(14, '2016-02-16 18:55:59', '[ACEPTADO] Respuesta a Solicitud del Administrador para que usted dirija el curso: 1A', 'Ok, muchas gracias! Saludos!', 65, 2, 3, 1, NULL),
(15, '2016-02-16 18:56:10', '[ACEPTADO] Respuesta a Solicitud del Administrador para que usted dirija el curso: 2B', 'Ok, muchas gracias! Saludos!', 65, 2, 3, 4, NULL),
(16, '2016-02-16 18:56:22', '[ACEPTADO] Respuesta a Solicitud del Administrador para que usted dirija el curso: 2B', 'Ok, muchas gracias! Saludos!', 65, 2, 3, 4, NULL),
(17, '2016-02-16 18:56:40', '[ACEPTADO] Respuesta a Solicitud del Administrador para que usted dirija el curso: 1B', 'Ok, muchas gracias! Saludos!', 65, 2, 3, 2, NULL),
(18, '2016-02-16 18:57:18', '[ACEPTADO] Respuesta a Solicitud del Administrador para que usted dirija el curso: 3A', 'Ok, muchas gracias! Saludos!', 66, 2, 3, 5, NULL),
(19, '2016-02-16 18:59:14', '[RECHAZADO] Respuesta a Solicitud del Administrador para que usted dirija el curso: 3B', 'Perdon, por el momento no!', 66, 2, 3, 6, NULL),
(20, '2016-02-16 19:01:53', 'Solicitud del Administrador para que usted dirija el curso: 3B', 'Ahora si aceptame la participación al curso. Perdón por no haberte avisado antes. Saludos! Mariana', 64, 3, 2, 6, 4),
(21, '2016-02-16 19:02:32', '[ACEPTADO] Respuesta a Solicitud del Administrador para que usted dirija el curso: 3B', 'Perdón, no sabía nada. Saludos', 66, 2, 3, 6, NULL),
(22, '2016-02-18 18:36:37', 'Solicitud a alumno para formar parte del curso 1A', 'Hola! Cómo estás? Te envio la solicitud para que participes del curso así podemos trabajar juntos y aprender de una forma diferente! En clases hablamos mejor de esto. Muchas gracias!!! Saludos', 65, 3, 2, 1, 5),
(23, '2016-02-18 18:37:09', 'Solicitud a alumno para formar parte del curso 1A', 'Hola! Cómo estás? Te envio la solicitud para que participes del curso así podemos trabajar juntos y aprender de una forma diferente! En clases hablamos mejor de esto. Muchas gracias!!! Saludos', 65, 3, 2, 1, 5),
(24, '2016-02-18 18:37:25', 'Solicitud a alumno para formar parte del curso 1A', 'Hola! Cómo estás? Te envio la solicitud para que participes del curso así podemos trabajar juntos y aprender de una forma diferente! En clases hablamos mejor de esto. Muchas gracias!!! Saludos', 65, 3, 2, 1, 5),
(25, '2016-02-18 18:37:39', 'Solicitud a alumno para formar parte del curso 1A', 'Hola! Cómo estás? Te envio la solicitud para que participes del curso así podemos trabajar juntos y aprender de una forma diferente! En clases hablamos mejor de esto. Muchas gracias!!! Saludos', 65, 3, 2, 1, 5),
(26, '2016-02-18 18:38:22', 'Solicitud a alumno para formar parte del curso 1A', 'Hola! Cómo estás? Te envio la solicitud para que participes del curso así podemos trabajar juntos y aprender de una forma diferente! En clases hablamos mejor de esto. Muchas gracias!!! Saludos', 65, 3, 2, 1, 5),
(27, '2016-02-18 18:38:37', 'Solicitud a alumno para formar parte del curso 1A', 'Hola! Cómo estás? Te envio la solicitud para que participes del curso así podemos trabajar juntos y aprender de una forma diferente! En clases hablamos mejor de esto. Muchas gracias!!! Saludos', 65, 3, 2, 1, 5),
(28, '2016-02-18 18:39:04', 'Solicitud a alumno para formar parte del curso 1A', 'Hola! Cómo estás? Te envio la solicitud para que participes del curso así podemos trabajar juntos y aprender de una forma diferente! En clases hablamos mejor de esto. Muchas gracias!!! Saludos', 65, 3, 2, 1, 5),
(29, '2016-02-18 18:39:23', 'Solicitud a alumno para formar parte del curso 1A', 'Hola! Cómo estás? Te envio la solicitud para que participes del curso así podemos trabajar juntos y aprender de una forma diferente! En clases hablamos mejor de esto. Muchas gracias!!! Saludos', 65, 3, 2, 1, 5),
(30, '2016-02-18 18:39:44', 'Solicitud a alumno para formar parte del curso 1A', 'Hola! Cómo estás? Te envio la solicitud para que participes del curso así podemos trabajar juntos y aprender de una forma diferente! En clases hablamos mejor de esto. Muchas gracias!!! Saludos', 65, 3, 2, 1, 5),
(31, '2016-02-18 18:41:42', 'Solicitud a alumno para formar parte del curso 1A', 'Hola! Cómo estás? Te envio la solicitud para que participes del curso así podemos trabajar juntos y aprender de una forma diferente! En clases hablamos mejor de esto. Muchas gracias!!! Saludos', 65, 3, 2, 1, 5),
(32, '2016-02-18 18:43:38', 'Solicitud a alumno para formar parte del curso 1B', 'Hola! Cómo estás? Te envio la solicitud para que participes del curso así podemos trabajar juntos y aprender de una forma diferente! En clases hablamos mejor de esto. Muchas gracias!!! Saludos', 65, 3, 2, 2, 5),
(33, '2016-02-18 18:43:50', 'Solicitud a alumno para formar parte del curso 1B', 'Hola! Cómo estás? Te envio la solicitud para que participes del curso así podemos trabajar juntos y aprender de una forma diferente! En clases hablamos mejor de esto. Muchas gracias!!! Saludos', 65, 3, 2, 2, 5),
(34, '2016-02-18 18:44:40', 'Solicitud a alumno para formar parte del curso 1B', 'Hola! Cómo estás? Te envio la solicitud para que participes del curso así podemos trabajar juntos y aprender de una forma diferente! En clases hablamos mejor de esto. Muchas gracias!!! Saludos', 65, 3, 2, 2, 5),
(35, '2016-02-18 18:44:54', 'Solicitud a alumno para formar parte del curso 1B', 'Hola! Cómo estás? Te envio la solicitud para que participes del curso así podemos trabajar juntos y aprender de una forma diferente! En clases hablamos mejor de esto. Muchas gracias!!! Saludos', 65, 3, 2, 2, 5),
(36, '2016-02-18 18:45:10', 'Solicitud a alumno para formar parte del curso 1B', 'Hola! Cómo estás? Te envio la solicitud para que participes del curso así podemos trabajar juntos y aprender de una forma diferente! En clases hablamos mejor de esto. Muchas gracias!!! Saludos', 65, 3, 2, 2, 5),
(37, '2016-02-18 18:45:21', 'Solicitud a alumno para formar parte del curso 1B', 'Hola! Cómo estás? Te envio la solicitud para que participes del curso así podemos trabajar juntos y aprender de una forma diferente! En clases hablamos mejor de esto. Muchas gracias!!! Saludos', 65, 3, 2, 2, 5),
(38, '2016-02-18 18:45:38', 'Solicitud a alumno para formar parte del curso 1B', 'Hola! Cómo estás? Te envio la solicitud para que participes del curso así podemos trabajar juntos y aprender de una forma diferente! En clases hablamos mejor de esto. Muchas gracias!!! Saludos', 65, 3, 2, 2, 5),
(39, '2016-02-18 18:45:50', 'Solicitud a alumno para formar parte del curso 1B', 'Hola! Cómo estás? Te envio la solicitud para que participes del curso así podemos trabajar juntos y aprender de una forma diferente! En clases hablamos mejor de esto. Muchas gracias!!! Saludos', 65, 3, 2, 2, 5),
(42, '2016-02-18 18:47:06', 'Solicitud a alumno para formar parte del curso 1B', 'Hola! Cómo estás? Te envio la solicitud para que participes del curso así podemos trabajar juntos y aprender de una forma diferente! En clases hablamos mejor de esto. Muchas gracias!!! Saludos', 65, 3, 2, 2, 5),
(44, '2016-02-18 18:49:53', 'Solicitud a alumno para formar parte del curso 1B', 'Hola! Cómo estás? Te envio la solicitud para que participes del curso así podemos trabajar juntos y aprender de una forma diferente! En clases hablamos mejor de esto. Muchas gracias!!! Saludos', 65, 3, 2, 2, 5),
(45, '2016-02-18 20:05:04', 'Solicitud a alumno para formar parte del curso 2A', 'Hola! Cómo estás? Te envio la solicitud para que participes del curso así podemos trabajar juntos y aprender de una forma diferente! En clases hablamos mejor de esto. Muchas gracias!!! Saludos', 65, 3, 2, 3, 5),
(46, '2016-02-18 20:05:18', 'Solicitud a alumno para formar parte del curso 2A', 'Hola! Cómo estás? Te envio la solicitud para que participes del curso así podemos trabajar juntos y aprender de una forma diferente! En clases hablamos mejor de esto. Muchas gracias!!! Saludos', 65, 3, 2, 3, 5),
(47, '2016-02-18 20:05:37', 'Solicitud a alumno para formar parte del curso 2A', 'Hola! Cómo estás? Te envio la solicitud para que participes del curso así podemos trabajar juntos y aprender de una forma diferente! En clases hablamos mejor de esto. Muchas gracias!!! Saludos', 65, 3, 2, 3, 5),
(48, '2016-02-18 20:05:53', 'Solicitud a alumno para formar parte del curso 2A', 'Hola! Cómo estás? Te envio la solicitud para que participes del curso así podemos trabajar juntos y aprender de una forma diferente! En clases hablamos mejor de esto. Muchas gracias!!! Saludos', 65, 3, 2, 3, 5),
(49, '2016-02-18 20:06:05', 'Solicitud a alumno para formar parte del curso 2A', 'Hola! Cómo estás? Te envio la solicitud para que participes del curso así podemos trabajar juntos y aprender de una forma diferente! En clases hablamos mejor de esto. Muchas gracias!!! Saludos', 65, 3, 2, 3, 5),
(50, '2016-02-18 20:06:17', 'Solicitud a alumno para formar parte del curso 2A', 'Hola! Cómo estás? Te envio la solicitud para que participes del curso así podemos trabajar juntos y aprender de una forma diferente! En clases hablamos mejor de esto. Muchas gracias!!! Saludos', 65, 3, 2, 3, 5),
(52, '2016-02-18 20:06:42', 'Solicitud a alumno para formar parte del curso 2A', 'Hola! Cómo estás? Te envio la solicitud para que participes del curso así podemos trabajar juntos y aprender de una forma diferente! En clases hablamos mejor de esto. Muchas gracias!!! Saludos', 65, 3, 2, 3, 5),
(53, '2016-02-18 20:06:58', 'Solicitud a alumno para formar parte del curso 2A', 'Hola! Cómo estás? Te envio la solicitud para que participes del curso así podemos trabajar juntos y aprender de una forma diferente! En clases hablamos mejor de esto. Muchas gracias!!! Saludos', 65, 3, 2, 3, 5),
(54, '2016-02-18 20:07:10', 'Solicitud a alumno para formar parte del curso 2A', 'Hola! Cómo estás? Te envio la solicitud para que participes del curso así podemos trabajar juntos y aprender de una forma diferente! En clases hablamos mejor de esto. Muchas gracias!!! Saludos', 65, 3, 2, 3, 5),
(55, '2016-02-18 20:07:23', 'Solicitud a alumno para formar parte del curso 2A', 'Hola! Cómo estás? Te envio la solicitud para que participes del curso así podemos trabajar juntos y aprender de una forma diferente! En clases hablamos mejor de esto. Muchas gracias!!! Saludos', 65, 3, 2, 3, 5),
(56, '2016-02-18 20:07:54', 'Solicitud a alumno para formar parte del curso 2B', 'Hola! Cómo estás? Te envio la solicitud para que participes del curso así podemos trabajar juntos y aprender de una forma diferente! En clases hablamos mejor de esto. Muchas gracias!!! Saludos', 65, 3, 2, 4, 5),
(57, '2016-02-18 20:08:07', 'Solicitud a alumno para formar parte del curso 2B', 'Hola! Cómo estás? Te envio la solicitud para que participes del curso así podemos trabajar juntos y aprender de una forma diferente! En clases hablamos mejor de esto. Muchas gracias!!! Saludos', 65, 3, 2, 4, 5),
(58, '2016-02-18 20:08:23', 'Solicitud a alumno para formar parte del curso 2B', 'Hola! Cómo estás? Te envio la solicitud para que participes del curso así podemos trabajar juntos y aprender de una forma diferente! En clases hablamos mejor de esto. Muchas gracias!!! Saludos', 65, 3, 2, 4, 5),
(59, '2016-02-18 20:08:39', 'Solicitud a alumno para formar parte del curso 2B', 'Hola! Cómo estás? Te envio la solicitud para que participes del curso así podemos trabajar juntos y aprender de una forma diferente! En clases hablamos mejor de esto. Muchas gracias!!! Saludos', 65, 3, 2, 4, 5),
(60, '2016-02-18 20:08:51', 'Solicitud a alumno para formar parte del curso 2B', 'Hola! Cómo estás? Te envio la solicitud para que participes del curso así podemos trabajar juntos y aprender de una forma diferente! En clases hablamos mejor de esto. Muchas gracias!!! Saludos', 65, 3, 2, 4, 5),
(61, '2016-02-18 20:09:05', 'Solicitud a alumno para formar parte del curso 2B', 'Hola! Cómo estás? Te envio la solicitud para que participes del curso así podemos trabajar juntos y aprender de una forma diferente! En clases hablamos mejor de esto. Muchas gracias!!! Saludos', 65, 3, 2, 4, 5),
(62, '2016-02-18 20:09:16', 'Solicitud a alumno para formar parte del curso 2B', 'Hola! Cómo estás? Te envio la solicitud para que participes del curso así podemos trabajar juntos y aprender de una forma diferente! En clases hablamos mejor de esto. Muchas gracias!!! Saludos', 65, 3, 2, 4, 5),
(63, '2016-02-18 20:09:30', 'Solicitud a alumno para formar parte del curso 2B', 'Hola! Cómo estás? Te envio la solicitud para que participes del curso así podemos trabajar juntos y aprender de una forma diferente! En clases hablamos mejor de esto. Muchas gracias!!! Saludos', 65, 3, 2, 4, 5),
(64, '2016-02-18 20:09:42', 'Solicitud a alumno para formar parte del curso 2B', 'Hola! Cómo estás? Te envio la solicitud para que participes del curso así podemos trabajar juntos y aprender de una forma diferente! En clases hablamos mejor de esto. Muchas gracias!!! Saludos', 65, 3, 2, 4, 5),
(65, '2016-02-18 20:09:53', 'Solicitud a alumno para formar parte del curso 2B', 'Hola! Cómo estás? Te envio la solicitud para que participes del curso así podemos trabajar juntos y aprender de una forma diferente! En clases hablamos mejor de esto. Muchas gracias!!! Saludos', 65, 3, 2, 4, 5),
(66, '2016-02-18 20:10:19', 'Solicitud a alumno para formar parte del curso 3A', 'Hola! Cómo estás? Te envio la solicitud para que participes del curso así podemos trabajar juntos y aprender de una forma diferente! En clases hablamos mejor de esto. Muchas gracias!!! Saludos', 66, 3, 2, 5, 5),
(67, '2016-02-18 20:10:31', 'Solicitud a alumno para formar parte del curso 3A', 'Hola! Cómo estás? Te envio la solicitud para que participes del curso así podemos trabajar juntos y aprender de una forma diferente! En clases hablamos mejor de esto. Muchas gracias!!! Saludos', 66, 3, 2, 5, 5),
(68, '2016-02-18 20:10:44', 'Solicitud a alumno para formar parte del curso 3A', 'Hola! Cómo estás? Te envio la solicitud para que participes del curso así podemos trabajar juntos y aprender de una forma diferente! En clases hablamos mejor de esto. Muchas gracias!!! Saludos', 66, 3, 2, 5, 5),
(69, '2016-02-18 20:10:55', 'Solicitud a alumno para formar parte del curso 3A', 'Hola! Cómo estás? Te envio la solicitud para que participes del curso así podemos trabajar juntos y aprender de una forma diferente! En clases hablamos mejor de esto. Muchas gracias!!! Saludos', 66, 3, 2, 5, 5),
(70, '2016-02-18 20:11:08', 'Solicitud a alumno para formar parte del curso 3A', 'Hola! Cómo estás? Te envio la solicitud para que participes del curso así podemos trabajar juntos y aprender de una forma diferente! En clases hablamos mejor de esto. Muchas gracias!!! Saludos', 66, 3, 2, 5, 5),
(71, '2016-02-18 20:11:24', 'Solicitud a alumno para formar parte del curso 3A', 'Hola! Cómo estás? Te envio la solicitud para que participes del curso así podemos trabajar juntos y aprender de una forma diferente! En clases hablamos mejor de esto. Muchas gracias!!! Saludos', 66, 3, 2, 5, 5),
(72, '2016-02-18 20:11:37', 'Solicitud a alumno para formar parte del curso 3A', 'Hola! Cómo estás? Te envio la solicitud para que participes del curso así podemos trabajar juntos y aprender de una forma diferente! En clases hablamos mejor de esto. Muchas gracias!!! Saludos', 66, 3, 2, 5, 5),
(73, '2016-02-18 20:11:49', 'Solicitud a alumno para formar parte del curso 3A', 'Hola! Cómo estás? Te envio la solicitud para que participes del curso así podemos trabajar juntos y aprender de una forma diferente! En clases hablamos mejor de esto. Muchas gracias!!! Saludos', 66, 3, 2, 5, 5),
(74, '2016-02-18 20:12:05', 'Solicitud a alumno para formar parte del curso 3A', 'Hola! Cómo estás? Te envio la solicitud para que participes del curso así podemos trabajar juntos y aprender de una forma diferente! En clases hablamos mejor de esto. Muchas gracias!!! Saludos', 66, 3, 2, 5, 5),
(75, '2016-02-18 20:12:17', 'Solicitud a alumno para formar parte del curso 3A', 'Hola! Cómo estás? Te envio la solicitud para que participes del curso así podemos trabajar juntos y aprender de una forma diferente! En clases hablamos mejor de esto. Muchas gracias!!! Saludos', 66, 3, 2, 5, 5),
(76, '2016-02-18 20:13:36', 'Solicitud a alumno para formar parte del curso 3B', 'Hola! Cómo estás? Te envio la solicitud para que participes del curso así podemos trabajar juntos y aprender de una forma diferente! En clases hablamos mejor de esto. Muchas gracias!!! Saludos', 66, 3, 2, 6, 5),
(77, '2016-02-18 20:13:51', 'Solicitud a alumno para formar parte del curso 3B', 'Hola! Cómo estás? Te envio la solicitud para que participes del curso así podemos trabajar juntos y aprender de una forma diferente! En clases hablamos mejor de esto. Muchas gracias!!! Saludos', 66, 3, 2, 6, 5),
(78, '2016-02-18 20:14:03', 'Solicitud a alumno para formar parte del curso 3B', 'Hola! Cómo estás? Te envio la solicitud para que participes del curso así podemos trabajar juntos y aprender de una forma diferente! En clases hablamos mejor de esto. Muchas gracias!!! Saludos', 66, 3, 2, 6, 5),
(79, '2016-02-18 20:14:19', 'Solicitud a alumno para formar parte del curso 3B', 'Hola! Cómo estás? Te envio la solicitud para que participes del curso así podemos trabajar juntos y aprender de una forma diferente! En clases hablamos mejor de esto. Muchas gracias!!! Saludos', 66, 3, 2, 6, 5),
(80, '2016-02-18 20:14:32', 'Solicitud a alumno para formar parte del curso 3B', 'Hola! Cómo estás? Te envio la solicitud para que participes del curso así podemos trabajar juntos y aprender de una forma diferente! En clases hablamos mejor de esto. Muchas gracias!!! Saludos', 66, 3, 2, 6, 5),
(81, '2016-02-18 20:15:00', 'Solicitud a alumno para formar parte del curso 3B', 'Hola! Cómo estás? Te envio la solicitud para que participes del curso así podemos trabajar juntos y aprender de una forma diferente! En clases hablamos mejor de esto. Muchas gracias!!! Saludos', 66, 3, 2, 6, 5),
(82, '2016-02-18 20:15:14', 'Solicitud a alumno para formar parte del curso 3B', 'Hola! Cómo estás? Te envio la solicitud para que participes del curso así podemos trabajar juntos y aprender de una forma diferente! En clases hablamos mejor de esto. Muchas gracias!!! Saludos', 66, 3, 2, 6, 5),
(83, '2016-02-18 20:15:29', 'Solicitud a alumno para formar parte del curso 3B', 'Hola! Cómo estás? Te envio la solicitud para que participes del curso así podemos trabajar juntos y aprender de una forma diferente! En clases hablamos mejor de esto. Muchas gracias!!! Saludos', 66, 3, 2, 6, 5),
(84, '2016-02-18 20:15:41', 'Solicitud a alumno para formar parte del curso 3B', 'Hola! Cómo estás? Te envio la solicitud para que participes del curso así podemos trabajar juntos y aprender de una forma diferente! En clases hablamos mejor de esto. Muchas gracias!!! Saludos', 66, 3, 2, 6, 5),
(85, '2016-02-18 20:16:58', 'Solicitud de inscripción al curso 3B', 'Hola, me gustaría participar de este curso! Muchas gracias desde ya!!', 126, 3, 2, 6, 1),
(86, '2016-02-18 20:25:44', '[ACEPTADO] Respuesta a Solicitud de inscripción al curso 3B', 'Por supuesto! muchas gracias por sumarte', 66, 2, 3, 6, NULL),
(87, '2016-02-18 20:27:59', '[ACEPTADO] Respuesta a Solicitud a alumno para formar parte del curso 1A', 'Hola! Muchas gracias por permitirme participar! Saludos!', 67, 2, 3, 1, NULL),
(88, '2016-02-18 20:28:36', '[ACEPTADO] Respuesta a Solicitud a alumno para formar parte del curso 1A', 'Hola profe, muchas gracias por permitirme participar! Saludos!', 68, 2, 3, 1, NULL),
(89, '2016-02-18 20:30:00', '[ACEPTADO] Respuesta a Solicitud a alumno para formar parte del curso 1A', 'Hola profe! muchisimas gracias por permitirme participar de este curso. Saludos!', 69, 2, 3, 1, NULL),
(90, '2016-02-18 20:30:21', '[ACEPTADO] Respuesta a Solicitud a alumno para formar parte del curso 1A', 'Hola profe! muchisimas gracias por permitirme participar de este curso. Saludos!', 70, 2, 3, 1, NULL),
(91, '2016-02-18 20:30:45', '[ACEPTADO] Respuesta a Solicitud a alumno para formar parte del curso 1A', 'Hola profe! muchisimas gracias por permitirme participar de este curso. Saludos!', 71, 2, 3, 1, NULL),
(92, '2016-02-18 20:31:06', '[ACEPTADO] Respuesta a Solicitud a alumno para formar parte del curso 1A', 'Hola profe! muchisimas gracias por permitirme participar de este curso. Saludos!', 72, 2, 3, 1, NULL),
(93, '2016-02-18 20:31:28', '[ACEPTADO] Respuesta a Solicitud a alumno para formar parte del curso 1A', 'Hola profe! muchisimas gracias por permitirme participar de este curso. Saludos!', 73, 2, 3, 1, NULL),
(94, '2016-02-18 20:31:50', '[ACEPTADO] Respuesta a Solicitud a alumno para formar parte del curso 1A', 'Hola profe! muchisimas gracias por permitirme participar de este curso. Saludos!', 74, 2, 3, 1, NULL),
(95, '2016-02-18 20:32:09', '[ACEPTADO] Respuesta a Solicitud a alumno para formar parte del curso 1A', 'Hola profe! muchisimas gracias por permitirme participar de este curso. Saludos!', 75, 2, 3, 1, NULL),
(96, '2016-02-18 20:32:34', '[ACEPTADO] Respuesta a Solicitud a alumno para formar parte del curso 1A', 'Hola profe! muchisimas gracias por permitirme participar de este curso. Saludos!', 76, 2, 3, 1, NULL),
(97, '2016-02-18 20:33:05', '[ACEPTADO] Respuesta a Solicitud a alumno para formar parte del curso 1B', 'Hola profe! muchisimas gracias por permitirme participar de este curso. Saludos!', 77, 2, 3, 2, NULL),
(98, '2016-02-18 20:33:28', '[ACEPTADO] Respuesta a Solicitud a alumno para formar parte del curso 1B', 'Hola profe! muchisimas gracias por permitirme participar de este curso. Saludos!', 78, 2, 3, 2, NULL),
(99, '2016-02-18 20:33:55', '[ACEPTADO] Respuesta a Solicitud a alumno para formar parte del curso 1B', 'Hola profe! muchisimas gracias por permitirme participar de este curso. Saludos!', 79, 2, 3, 2, NULL),
(100, '2016-02-18 20:34:21', '[ACEPTADO] Respuesta a Solicitud a alumno para formar parte del curso 1B', 'Hola profe! muchisimas gracias por permitirme participar de este curso. Saludos!', 80, 2, 3, 2, NULL),
(101, '2016-02-18 20:34:45', '[ACEPTADO] Respuesta a Solicitud a alumno para formar parte del curso 1B', 'Hola profe! muchisimas gracias por permitirme participar de este curso. Saludos!', 81, 2, 3, 2, NULL),
(102, '2016-02-18 20:35:16', '[ACEPTADO] Respuesta a Solicitud a alumno para formar parte del curso 1B', 'Hola profe! muchisimas gracias por permitirme participar de este curso. Saludos!', 82, 2, 3, 2, NULL),
(103, '2016-02-18 20:35:42', '[ACEPTADO] Respuesta a Solicitud a alumno para formar parte del curso 1B', 'Hola profe! muchisimas gracias por permitirme participar de este curso. Saludos!', 83, 2, 3, 2, NULL),
(104, '2016-02-18 20:36:08', '[ACEPTADO] Respuesta a Solicitud a alumno para formar parte del curso 1B', 'Hola profe! muchisimas gracias por permitirme participar de este curso. Saludos!', 84, 2, 3, 2, NULL),
(105, '2016-02-18 20:36:32', '[ACEPTADO] Respuesta a Solicitud a alumno para formar parte del curso 1B', 'Hola profe! muchisimas gracias por permitirme participar de este curso. Saludos!', 85, 2, 3, 2, NULL),
(106, '2016-02-18 20:36:55', '[ACEPTADO] Respuesta a Solicitud a alumno para formar parte del curso 1B', 'Hola profe! muchisimas gracias por permitirme participar de este curso. Saludos!', 86, 2, 3, 2, NULL),
(107, '2016-02-18 20:37:22', '[ACEPTADO] Respuesta a Solicitud a alumno para formar parte del curso 2A', 'Hola profe! muchisimas gracias por permitirme participar de este curso. Saludos!', 87, 2, 3, 3, NULL),
(108, '2016-02-18 20:37:45', '[ACEPTADO] Respuesta a Solicitud a alumno para formar parte del curso 2A', 'Hola profe! muchisimas gracias por permitirme participar de este curso. Saludos!', 88, 2, 3, 3, NULL),
(109, '2016-02-18 20:38:06', '[ACEPTADO] Respuesta a Solicitud a alumno para formar parte del curso 2A', 'Hola profe! muchisimas gracias por permitirme participar de este curso. Saludos!', 89, 2, 3, 3, NULL),
(110, '2016-02-18 20:38:36', '[ACEPTADO] Respuesta a Solicitud a alumno para formar parte del curso 2A', 'Hola profe! muchisimas gracias por permitirme participar de este curso. Saludos!', 90, 2, 3, 3, NULL),
(111, '2016-02-18 20:38:59', '[ACEPTADO] Respuesta a Solicitud a alumno para formar parte del curso 2A', 'Hola profe! muchisimas gracias por permitirme participar de este curso. Saludos!', 91, 2, 3, 3, NULL),
(112, '2016-02-18 20:39:26', '[ACEPTADO] Respuesta a Solicitud a alumno para formar parte del curso 2A', 'Hola profe! muchisimas gracias por permitirme participar de este curso. Saludos!', 92, 2, 3, 3, NULL),
(113, '2016-02-18 20:39:49', '[ACEPTADO] Respuesta a Solicitud a alumno para formar parte del curso 2A', 'Hola profe! muchisimas gracias por permitirme participar de este curso. Saludos!', 93, 2, 3, 3, NULL),
(114, '2016-02-18 20:40:18', '[ACEPTADO] Respuesta a Solicitud a alumno para formar parte del curso 2A', 'Hola profe! muchisimas gracias por permitirme participar de este curso. Saludos!', 94, 2, 3, 3, NULL),
(115, '2016-02-18 20:40:50', '[ACEPTADO] Respuesta a Solicitud a alumno para formar parte del curso 2A', 'Hola profe! muchisimas gracias por permitirme participar de este curso. Saludos!', 95, 2, 3, 3, NULL),
(116, '2016-02-18 20:41:15', '[ACEPTADO] Respuesta a Solicitud a alumno para formar parte del curso 2A', 'Hola profe! muchisimas gracias por permitirme participar de este curso. Saludos!', 96, 2, 3, 3, NULL),
(117, '2016-02-18 20:41:56', '[ACEPTADO] Respuesta a Solicitud a alumno para formar parte del curso 2B', 'Hola profe! muchisimas gracias por permitirme participar de este curso. Saludos!', 97, 2, 3, 4, NULL),
(118, '2016-02-18 20:42:23', '[ACEPTADO] Respuesta a Solicitud a alumno para formar parte del curso 2B', 'Hola profe! muchisimas gracias por permitirme participar de este curso. Saludos!', 98, 2, 3, 4, NULL),
(119, '2016-02-18 20:42:49', '[ACEPTADO] Respuesta a Solicitud a alumno para formar parte del curso 2B', 'Hola profe! muchisimas gracias por permitirme participar de este curso. Saludos!', 99, 2, 3, 4, NULL),
(120, '2016-02-18 20:43:13', '[ACEPTADO] Respuesta a Solicitud a alumno para formar parte del curso 2B', 'Hola profe! muchisimas gracias por permitirme participar de este curso. Saludos!', 100, 2, 3, 4, NULL),
(121, '2016-02-18 20:43:33', '[ACEPTADO] Respuesta a Solicitud a alumno para formar parte del curso 2B', 'Hola profe! muchisimas gracias por permitirme participar de este curso. Saludos!', 101, 2, 3, 4, NULL),
(122, '2016-02-18 20:43:54', '[ACEPTADO] Respuesta a Solicitud a alumno para formar parte del curso 2B', 'Hola profe! muchisimas gracias por permitirme participar de este curso. Saludos!', 102, 2, 3, 4, NULL),
(123, '2016-02-18 20:44:14', '[ACEPTADO] Respuesta a Solicitud a alumno para formar parte del curso 2B', 'Hola profe! muchisimas gracias por permitirme participar de este curso. Saludos!', 103, 2, 3, 4, NULL),
(124, '2016-02-18 20:44:32', '[ACEPTADO] Respuesta a Solicitud a alumno para formar parte del curso 2B', 'Hola profe! muchisimas gracias por permitirme participar de este curso. Saludos!', 104, 2, 3, 4, NULL),
(125, '2016-02-18 20:44:55', '[ACEPTADO] Respuesta a Solicitud a alumno para formar parte del curso 2B', 'Hola profe! muchisimas gracias por permitirme participar de este curso. Saludos!', 105, 2, 3, 4, NULL),
(126, '2016-02-18 20:45:19', '[ACEPTADO] Respuesta a Solicitud a alumno para formar parte del curso 2B', 'Hola profe! muchisimas gracias por permitirme participar de este curso. Saludos!', 106, 2, 3, 4, NULL),
(127, '2016-02-18 20:45:44', '[ACEPTADO] Respuesta a Solicitud a alumno para formar parte del curso 3A', 'Hola profe! muchisimas gracias por permitirme participar de este curso. Saludos!', 107, 2, 3, 5, NULL),
(128, '2016-02-18 20:46:05', '[ACEPTADO] Respuesta a Solicitud a alumno para formar parte del curso 3A', 'Hola profe! muchisimas gracias por permitirme participar de este curso. Saludos!', 108, 2, 3, 5, NULL),
(129, '2016-02-18 20:46:25', '[ACEPTADO] Respuesta a Solicitud a alumno para formar parte del curso 3A', 'Hola profe! muchisimas gracias por permitirme participar de este curso. Saludos!', 109, 2, 3, 5, NULL),
(130, '2016-02-18 20:46:47', '[ACEPTADO] Respuesta a Solicitud a alumno para formar parte del curso 3A', 'Hola profe! muchisimas gracias por permitirme participar de este curso. Saludos!', 110, 2, 3, 5, NULL),
(131, '2016-02-18 20:47:06', '[ACEPTADO] Respuesta a Solicitud a alumno para formar parte del curso 3A', 'Hola profe! muchisimas gracias por permitirme participar de este curso. Saludos!', 111, 2, 3, 5, NULL),
(132, '2016-02-18 20:47:23', '[ACEPTADO] Respuesta a Solicitud a alumno para formar parte del curso 3A', 'Hola profe! muchisimas gracias por permitirme participar de este curso. Saludos!', 112, 2, 3, 5, NULL),
(133, '2016-02-18 20:47:43', '[ACEPTADO] Respuesta a Solicitud a alumno para formar parte del curso 3A', 'Hola profe! muchisimas gracias por permitirme participar de este curso. Saludos!', 113, 2, 3, 5, NULL),
(134, '2016-02-18 20:48:01', '[ACEPTADO] Respuesta a Solicitud a alumno para formar parte del curso 3A', 'Hola profe! muchisimas gracias por permitirme participar de este curso. Saludos!', 114, 2, 3, 5, NULL),
(135, '2016-02-18 20:48:31', '[ACEPTADO] Respuesta a Solicitud a alumno para formar parte del curso 3A', 'Hola profe! muchisimas gracias por permitirme participar de este curso. Saludos!', 115, 2, 3, 5, NULL),
(136, '2016-02-18 20:48:58', '[ACEPTADO] Respuesta a Solicitud a alumno para formar parte del curso 3A', 'Hola profe! muchisimas gracias por permitirme participar de este curso. Saludos!', 116, 2, 3, 5, NULL),
(137, '2016-02-18 20:49:34', '[ACEPTADO] Respuesta a Solicitud a alumno para formar parte del curso 3B', 'Hola profe! muchisimas gracias por permitirme participar de este curso. Saludos!', 117, 2, 3, 6, NULL),
(138, '2016-02-18 20:49:53', '[ACEPTADO] Respuesta a Solicitud a alumno para formar parte del curso 3B', 'Hola profe! muchisimas gracias por permitirme participar de este curso. Saludos!', 118, 2, 3, 6, NULL),
(139, '2016-02-18 20:50:13', '[ACEPTADO] Respuesta a Solicitud a alumno para formar parte del curso 3B', 'Hola profe! muchisimas gracias por permitirme participar de este curso. Saludos!', 119, 2, 3, 6, NULL),
(140, '2016-02-18 20:50:33', '[ACEPTADO] Respuesta a Solicitud a alumno para formar parte del curso 3B', 'Hola profe! muchisimas gracias por permitirme participar de este curso. Saludos!', 120, 2, 3, 6, NULL),
(141, '2016-02-18 20:50:53', '[ACEPTADO] Respuesta a Solicitud a alumno para formar parte del curso 3B', 'Hola profe! muchisimas gracias por permitirme participar de este curso. Saludos!', 121, 2, 3, 6, NULL),
(142, '2016-02-18 20:51:12', '[ACEPTADO] Respuesta a Solicitud a alumno para formar parte del curso 3B', 'Hola profe! muchisimas gracias por permitirme participar de este curso. Saludos!', 122, 2, 3, 6, NULL),
(143, '2016-02-18 20:51:38', '[ACEPTADO] Respuesta a Solicitud a alumno para formar parte del curso 3B', 'Hola profe! muchisimas gracias por permitirme participar de este curso. Saludos!', 123, 2, 3, 6, NULL),
(144, '2016-02-18 20:51:59', '[ACEPTADO] Respuesta a Solicitud a alumno para formar parte del curso 3B', 'Hola profe! muchisimas gracias por permitirme participar de este curso. Saludos!', 124, 2, 3, 6, NULL),
(145, '2016-02-18 20:52:21', '[ACEPTADO] Respuesta a Solicitud a alumno para formar parte del curso 3B', 'Hola profe! muchisimas gracias por permitirme participar de este curso. Saludos!', 125, 2, 3, 6, NULL),
(146, '2016-02-23 19:43:21', 'Solicitud a alumno para formar parte del curso 1A', 'Hola! Me gustaría que te unas a nuestro curso para que puedas participar de nuestras actividades y nuestro completo plan de estudios. Saludos!', 65, 3, 2, 1, 5),
(147, '2016-03-07 17:35:07', 'Solicitud a docente para formar parte de la institución LSA Argentina', 'Hola Guillermo, te gustaría participar en nuestra insitución? Muchas gracias desde ya! Rodolfo', 167, 3, 2, 9, 3),
(148, '2016-03-07 17:36:28', '[ACEPTADO] Respuesta a Solicitud a docente para formar parte de la institución LSA Argentina', 'Va a ser un honor! Muchas gracias por tomarme en cuenta!', 65, 6, 3, 9, NULL),
(149, '2016-03-07 17:37:05', 'Solicitud del Administrador para que usted dirija el curso: Curso general básico', 'Voy a asignarte nuestros dos cursos para que puedas trabajar en ellos. Muchas gracias nuevamente por tu colaboración!', 167, 3, 2, 9, 4),
(150, '2016-03-07 17:37:09', 'Solicitud del Administrador para que usted dirija el curso: Curso general avanzado', 'Voy a asignarte nuestros dos cursos para que puedas trabajar en ellos. Muchas gracias nuevamente por tu colaboración!', 167, 3, 2, 10, 4),
(151, '2016-03-07 17:37:33', '[ACEPTADO] Respuesta a Solicitud del Administrador para que usted dirija el curso: Curso general avanzado', 'Gracias! ', 65, 6, 3, 10, NULL),
(152, '2016-03-07 17:37:57', '[ACEPTADO] Respuesta a Solicitud del Administrador para que usted dirija el curso: Curso general básico', 'Gracias! esto es un verdadero desafio!', 65, 6, 3, 9, NULL),
(153, '2016-03-07 17:39:52', 'Solicitud a alumno para formar parte del curso Curso general básico', 'Hola Dolores, querés sumarte a este curso para que nos ayudes a crear nuestras actividades? Muchas gracias!', 65, 3, 2, 9, 5),
(154, '2016-03-07 17:40:33', '[ACEPTADO] Respuesta a Solicitud a alumno para formar parte del curso 1A', 'Si, por supuesto!', 127, 6, 3, 1, NULL),
(155, '2016-03-07 17:40:55', '[ACEPTADO] Respuesta a Solicitud a alumno para formar parte del curso Curso general básico', 'Por supuesto!', 127, 6, 3, 9, NULL),
(156, '2016-03-07 17:42:19', 'Solicitud a alumno para formar parte del curso Curso general avanzado', 'Hola Juana! te querés sumar a nuestro proyecto?', 65, 3, 2, 10, 5),
(157, '2016-03-07 17:42:45', '[ACEPTADO] Respuesta a Solicitud a alumno para formar parte del curso Curso general avanzado', 'Si! muchas gracias!', 166, 6, 3, 10, NULL),
(163, '2016-03-07 20:10:22', 'Resolucion actividad', 'Me fue bien en todos los ejercicios! :)', 107, 2, 1, NULL, NULL),
(164, '2016-03-07 20:25:21', 'Resolucion actividad', 'Muy bien! te felicito!', 66, 6, 1, NULL, NULL),
(165, '2016-03-07 20:25:26', ' Corrección Actividad', 'Te avisamos que el docente ha resulto la actividad NUMEROS CON SEÑAS, resuelta el 7/3/2016 7:43:44 p. m.. La calificación del docente es: 100. El Docente te Dejo el siguiente mensaje: Que el alumno haya resuelto todas las actividades en menos de un minuto y sin errores, me da la certeza de que ha adquirido los conocimientos de forma excelente.', 66, 6, 3, 1, NULL),
(166, '2016-03-13 15:40:32', 'Solicitud a docente para formar parte de la institución Villasoles Asociación Civil', 'Hola Oscar, cómo te va?\r\n\r\nTal como se trató en la reunión de coordinadores del pasado Lunes, comenzamos a utilizar PEALS para dar soporte a nuestros cursos. Por favor, aceptá esta solicitud para comenzar a trabajar con esta herramienta.\r\n\r\nMuchas gracias por tu participación y colaboración.\r\n\r\nSaludos!', 64, 3, 2, 10, 3),
(167, '2016-03-13 15:41:45', '[ACEPTADO] Respuesta a Solicitud a docente para formar parte de la institución Villasoles Asociación Civil', 'Hola, perfecto! Estoy viendo la página y está muy buena. Estoy ansioso por empezar a trabajar. Saludos!', 174, 6, 3, 10, NULL),
(168, '2016-03-13 15:42:38', 'Solicitud del Administrador para que usted dirija el curso: Introducción al Lenguaje de Señas Argentino', 'Solicitud del administrador para que dirija el curso', 64, 3, 2, 11, 4),
(169, '2016-03-13 15:43:04', '[ACEPTADO] Respuesta a Solicitud del Administrador para que usted dirija el curso: Introducción al Lenguaje de Señas Argentino', 'Por supuesto. Muchas gracias', 174, 6, 3, 11, NULL),
(170, '2016-03-13 15:46:11', 'Solicitud a docente para formar parte de la institución Villasoles Asociación Civil', 'Hola Elva, como hablamos hoy a la mañana, te asigno el curso de inducción. Saludos y gracias por tu participación', 64, 3, 2, 10, 3),
(171, '2016-03-13 15:46:38', '[ACEPTADO] Respuesta a Solicitud a docente para formar parte de la institución Villasoles Asociación Civil', 'Por supuesto. Muchas gracias', 175, 6, 3, 10, NULL),
(172, '2016-03-13 15:46:59', 'Solicitud del Administrador para que usted dirija el curso: Letras y números', 'Solicitud del administrador para que dirija el curso', 64, 3, 2, 12, 4),
(173, '2016-03-13 15:47:29', '[ACEPTADO] Respuesta a Solicitud del Administrador para que usted dirija el curso: Letras y números', 'Por supuesto. Saludos', 175, 6, 3, 12, NULL),
(174, '2016-03-13 16:00:54', 'Solicitud a alumno para formar parte del curso Introducción al Lenguaje de Señas Argentino', 'Hola Francisco,\r\n\r\nTe invitamos a este proyecto que nos llena de orgullo, para que participes y puedas sacar provecho de la herramienta PEALS y nuestro equipo docente.\r\n\r\nEsperamos contar con vos en nuestros cursos.\r\n\r\nSaludos\r\n\r\nOscar', 174, 4, 2, 11, 5),
(175, '2016-03-13 16:01:10', 'Solicitud a alumno para formar parte del curso Introducción al Lenguaje de Señas Argentino', 'Hola Manuel,\r\n\r\nTe invitamos a este proyecto que nos llena de orgullo, para que participes y puedas sacar provecho de la herramienta PEALS y nuestro equipo docente.\r\n\r\nEsperamos contar con vos en nuestros cursos.\r\n\r\nSaludos\r\n\r\nOscar', 174, 4, 2, 11, 5),
(176, '2016-03-13 16:01:26', 'Solicitud a alumno para formar parte del curso Introducción al Lenguaje de Señas Argentino', 'Hola Luis,\r\n\r\nTe invitamos a este proyecto que nos llena de orgullo, para que participes y puedas sacar provecho de la herramienta PEALS y nuestro equipo docente.\r\n\r\nEsperamos contar con vos en nuestros cursos.\r\n\r\nSaludos\r\n\r\nOscar', 174, 3, 2, 11, 5),
(177, '2016-03-13 16:01:45', 'Solicitud a alumno para formar parte del curso Introducción al Lenguaje de Señas Argentino', 'Hola Manuela,\r\n\r\nTe invitamos a este proyecto que nos llena de orgullo, para que participes y puedas sacar provecho de la herramienta PEALS y nuestro equipo docente.\r\n\r\nEsperamos contar con vos en nuestros cursos.\r\n\r\nSaludos\r\n\r\nOscar', 174, 3, 2, 11, 5),
(178, '2016-03-13 16:02:07', 'Solicitud a alumno para formar parte del curso Introducción al Lenguaje de Señas Argentino', 'Hola Marcela,\r\n\r\nTe invitamos a este proyecto que nos llena de orgullo, para que participes y puedas sacar provecho de la herramienta PEALS y nuestro equipo docente.\r\n\r\nEsperamos contar con vos en nuestros cursos.\r\n\r\nSaludos\r\n\r\nOscar', 174, 3, 2, 11, 5),
(179, '2016-03-13 16:02:28', 'Solicitud a alumno para formar parte del curso Introducción al Lenguaje de Señas Argentino', 'Hola Mariano,\r\n\r\nTe invitamos a este proyecto que nos llena de orgullo, para que participes y puedas sacar provecho de la herramienta PEALS y nuestro equipo docente.\r\n\r\nEsperamos contar con vos en nuestros cursos.\r\n\r\nSaludos\r\n\r\nOscar', 174, 3, 2, 11, 5),
(180, '2016-03-13 16:02:44', 'Solicitud a alumno para formar parte del curso Introducción al Lenguaje de Señas Argentino', 'Hola Margarita,\r\n\r\nTe invitamos a este proyecto que nos llena de orgullo, para que participes y puedas sacar provecho de la herramienta PEALS y nuestro equipo docente.\r\n\r\nEsperamos contar con vos en nuestros cursos.\r\n\r\nSaludos\r\n\r\nOscar', 174, 3, 2, 11, 5),
(181, '2016-03-13 16:04:08', 'Solicitud de inscripción al curso Introducción al Lenguaje de Señas Argentino', 'Hola, me gustaría participar de este curso.\r\n\r\nMuchas gracias desde ya!', 158, 3, 2, 11, 1),
(182, '2016-03-13 16:05:01', '[ACEPTADO] Respuesta a Solicitud de inscripción al curso Introducción al Lenguaje de Señas Argentino', 'Por supuesto! queremos llegar a la mayor cantidad posible de alumnos. Si conoces a alguien que pueda interesarle, no dudes en comentarle e invitarlo a participar.\r\n\r\nSaludos!', 174, 1, 3, 11, NULL),
(183, '2016-03-13 16:05:50', '[ACEPTADO] Respuesta a Solicitud a alumno para formar parte del curso Introducción al Lenguaje de Señas Argentino', 'Muchas gracias por tenerme en cuenta!', 159, 6, 3, 11, NULL),
(184, '2016-03-13 16:06:29', '[ACEPTADO] Respuesta a Solicitud a alumno para formar parte del curso Introducción al Lenguaje de Señas Argentino', 'Muchas gracias! Me gusta mucho este curso!', 160, 6, 3, 11, NULL),
(185, '2016-03-13 16:06:52', '[ACEPTADO] Respuesta a Solicitud a alumno para formar parte del curso Introducción al Lenguaje de Señas Argentino', 'Si! quiero participar!', 161, 6, 3, 11, NULL),
(186, '2016-03-13 16:07:11', '[ACEPTADO] Respuesta a Solicitud a alumno para formar parte del curso Introducción al Lenguaje de Señas Argentino', 'Esto ansioso por empezar ', 162, 6, 3, 11, NULL),
(187, '2016-03-13 16:07:39', '[ACEPTADO] Respuesta a Solicitud a alumno para formar parte del curso Introducción al Lenguaje de Señas Argentino', 'Si, me encantaría. Saludos!', 163, 6, 3, 11, NULL),
(188, '2016-03-13 16:08:04', '[RECHAZADO] Respuesta a Solicitud a alumno para formar parte del curso Introducción al Lenguaje de Señas Argentino', 'Le agradezco, pero por el momento no quiero participar', 164, 6, 3, 11, NULL),
(189, '2016-03-13 16:08:25', '[RECHAZADO] Respuesta a Solicitud a alumno para formar parte del curso Introducción al Lenguaje de Señas Argentino', 'No, gracias', 165, 6, 3, 11, NULL),
(190, '2016-03-13 16:09:16', 'Solicitud a alumno para formar parte del curso Letras y números', 'Estamos haciendo un curso de apoyo para el lenguaje de señas. Me gustaría que te sumes y nos ayudes a mejorar nuestras actividades.\r\n\r\nSaludos\r\n\r\nElva', 175, 3, 2, 12, 5),
(191, '2016-03-13 16:09:34', 'Solicitud a alumno para formar parte del curso Letras y números', 'Estamos haciendo un curso de apoyo para el lenguaje de señas. Me gustaría que te sumes y nos ayudes a mejorar nuestras actividades.\r\n\r\nSaludos\r\n\r\nElva', 175, 3, 2, 12, 5),
(192, '2016-03-13 16:10:01', '[ACEPTADO] Respuesta a Solicitud a alumno para formar parte del curso Letras y números', 'Por supuesto! me encantaría', 164, 1, 3, 12, NULL),
(193, '2016-03-13 16:10:24', '[ACEPTADO] Respuesta a Solicitud a alumno para formar parte del curso Letras y números', 'Es justo lo que necesito. Gracias!', 165, 1, 3, 12, NULL);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `mensaje_x_destinatario`
--

CREATE TABLE IF NOT EXISTS `mensaje_x_destinatario` (
`id` int(11) NOT NULL,
  `mensaje` int(11) DEFAULT NULL,
  `destinatario` int(11) DEFAULT NULL
) ENGINE=InnoDB AUTO_INCREMENT=194 DEFAULT CHARSET=utf8;

--
-- Volcado de datos para la tabla `mensaje_x_destinatario`
--

INSERT INTO `mensaje_x_destinatario` (`id`, `mensaje`, `destinatario`) VALUES
(1, 1, 65),
(2, 2, 66),
(3, 3, 64),
(4, 4, 64),
(5, 5, 64),
(6, 6, 66),
(7, 7, 65),
(8, 8, 65),
(9, 9, 65),
(10, 10, 65),
(11, 11, 66),
(12, 12, 66),
(13, 13, 64),
(14, 14, 64),
(15, 15, 64),
(16, 16, 64),
(17, 17, 64),
(18, 18, 64),
(19, 19, 64),
(20, 20, 66),
(21, 21, 64),
(22, 22, 67),
(23, 23, 68),
(24, 24, 69),
(25, 25, 70),
(26, 26, 71),
(27, 27, 72),
(28, 28, 73),
(29, 29, 74),
(30, 30, 76),
(31, 31, 75),
(32, 32, 77),
(33, 33, 78),
(34, 34, 79),
(35, 35, 80),
(36, 36, 81),
(37, 37, 82),
(38, 38, 83),
(39, 39, 84),
(42, 42, 85),
(44, 44, 86),
(45, 45, 87),
(46, 46, 88),
(47, 47, 89),
(48, 48, 90),
(49, 49, 91),
(50, 50, 92),
(52, 52, 93),
(53, 53, 94),
(54, 54, 95),
(55, 55, 96),
(56, 56, 97),
(57, 57, 98),
(58, 58, 99),
(59, 59, 100),
(60, 60, 101),
(61, 61, 102),
(62, 62, 103),
(63, 63, 104),
(64, 64, 105),
(65, 65, 106),
(66, 66, 107),
(67, 67, 108),
(68, 68, 109),
(69, 69, 110),
(70, 70, 111),
(71, 71, 112),
(72, 72, 113),
(73, 73, 114),
(74, 74, 115),
(75, 75, 116),
(76, 76, 117),
(77, 77, 118),
(78, 78, 119),
(79, 79, 120),
(80, 80, 121),
(81, 81, 122),
(82, 82, 123),
(83, 83, 124),
(84, 84, 125),
(85, 85, 66),
(86, 86, 126),
(87, 87, 65),
(88, 88, 65),
(89, 89, 65),
(90, 90, 65),
(91, 91, 65),
(92, 92, 65),
(93, 93, 65),
(94, 94, 65),
(95, 95, 65),
(96, 96, 65),
(97, 97, 65),
(98, 98, 65),
(99, 99, 65),
(100, 100, 65),
(101, 101, 65),
(102, 102, 65),
(103, 103, 65),
(104, 104, 65),
(105, 105, 65),
(106, 106, 65),
(107, 107, 65),
(108, 108, 65),
(109, 109, 65),
(110, 110, 65),
(111, 111, 65),
(112, 112, 65),
(113, 113, 65),
(114, 114, 65),
(115, 115, 65),
(116, 116, 65),
(117, 117, 65),
(118, 118, 65),
(119, 119, 65),
(120, 120, 65),
(121, 121, 65),
(122, 122, 65),
(123, 123, 65),
(124, 124, 65),
(125, 125, 65),
(126, 126, 65),
(127, 127, 66),
(128, 128, 66),
(129, 129, 66),
(130, 130, 66),
(131, 131, 66),
(132, 132, 66),
(133, 133, 66),
(134, 134, 66),
(135, 135, 66),
(136, 136, 66),
(137, 137, 66),
(138, 138, 66),
(139, 139, 66),
(140, 140, 66),
(141, 141, 66),
(142, 142, 66),
(143, 143, 66),
(144, 144, 66),
(145, 145, 66),
(146, 146, 127),
(147, 147, 65),
(148, 148, 167),
(149, 149, 65),
(150, 150, 65),
(151, 151, 167),
(152, 152, 167),
(153, 153, 127),
(154, 154, 65),
(155, 155, 65),
(156, 156, 166),
(157, 157, 65),
(163, 163, 66),
(164, 164, 107),
(165, 165, 107),
(166, 166, 174),
(167, 167, 64),
(168, 168, 174),
(169, 169, 64),
(170, 170, 175),
(171, 171, 64),
(172, 172, 175),
(173, 173, 64),
(174, 174, 165),
(175, 175, 164),
(176, 176, 163),
(177, 177, 162),
(178, 178, 161),
(179, 179, 160),
(180, 180, 159),
(181, 181, 174),
(182, 182, 158),
(183, 183, 174),
(184, 184, 174),
(185, 185, 174),
(186, 186, 174),
(187, 187, 174),
(188, 188, 174),
(189, 189, 174),
(190, 190, 164),
(191, 191, 165),
(192, 192, 175),
(193, 193, 175);

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
) ENGINE=InnoDB AUTO_INCREMENT=177 DEFAULT CHARSET=utf8;

--
-- Volcado de datos para la tabla `opcion`
--

INSERT INTO `opcion` (`id`, `item`, `descripcion`) VALUES
(1, 1, 'Masculino'),
(2, 1, 'Femenino'),
(3, 2, 'Bajo'),
(4, 2, 'Medio'),
(5, 2, 'Alto'),
(6, 2, 'Muy Alto'),
(7, 3, 'Alto'),
(8, 3, 'Normal'),
(9, 3, 'Bajo'),
(10, 3, 'Muy bajo'),
(11, 4, 'Alto'),
(12, 4, 'Normal'),
(13, 4, 'Bajo'),
(14, 4, 'Muy bajo'),
(15, 5, 'Si'),
(16, 5, 'No'),
(17, 6, 'Si'),
(18, 6, 'No'),
(19, 7, 'Si'),
(20, 7, 'No'),
(21, 8, 'Si'),
(22, 8, 'No'),
(23, 9, 'Si'),
(24, 9, 'No'),
(25, 10, 'Si'),
(26, 10, 'No'),
(27, 11, 'Si'),
(28, 11, 'No'),
(29, 12, 'Si'),
(30, 12, 'No'),
(31, 13, 'Si'),
(32, 13, 'No'),
(33, 14, 'Si'),
(34, 14, 'No'),
(35, 15, 'Si'),
(36, 15, 'No'),
(37, 16, 'Si'),
(38, 16, 'No'),
(39, 17, 'Si'),
(40, 17, 'No'),
(41, 25, 'Masculino'),
(42, 25, 'Femenino'),
(43, 26, 'Bajo'),
(44, 26, 'Medio'),
(45, 26, 'Alto'),
(46, 26, 'Muy Alto'),
(47, 27, 'Alto'),
(48, 27, 'Normal'),
(49, 27, 'Bajo'),
(50, 27, 'Muy bajo'),
(51, 28, 'Alto'),
(52, 28, 'Normal'),
(53, 28, 'Bajo'),
(54, 28, 'Muy bajo'),
(55, 29, 'Si'),
(56, 29, 'No'),
(57, 30, 'Si'),
(58, 30, 'No'),
(59, 31, 'Si'),
(60, 31, 'No'),
(61, 32, 'Si'),
(62, 32, 'No'),
(63, 33, 'Si'),
(64, 33, 'No'),
(65, 34, 'Si'),
(66, 34, 'No'),
(67, 35, 'Si'),
(68, 35, 'No'),
(69, 36, 'Si'),
(70, 36, 'No'),
(71, 37, 'Si'),
(72, 37, 'No'),
(73, 38, 'Si'),
(74, 38, 'No'),
(75, 39, 'Si'),
(76, 39, 'No'),
(77, 40, 'Si'),
(78, 40, 'No'),
(79, 41, 'Si'),
(80, 41, 'No'),
(81, 49, 'Masculino'),
(82, 49, 'Femenino'),
(83, 50, 'Bajo'),
(84, 50, 'Medio'),
(85, 50, 'Alto'),
(86, 50, 'Muy Alto'),
(87, 51, 'Alto'),
(88, 51, 'Normal'),
(89, 51, 'Bajo'),
(90, 51, 'Muy bajo'),
(91, 52, 'Alto'),
(92, 52, 'Normal'),
(93, 52, 'Bajo'),
(94, 52, 'Muy bajo'),
(95, 53, 'Si'),
(96, 53, 'No'),
(97, 54, 'Si'),
(98, 54, 'No'),
(99, 55, 'Si'),
(100, 55, 'No'),
(101, 56, 'Si'),
(102, 56, 'No'),
(103, 57, 'Si'),
(104, 57, 'No'),
(105, 58, 'Si'),
(106, 58, 'No'),
(107, 59, 'Si'),
(108, 59, 'No'),
(109, 60, 'Si'),
(110, 60, 'No'),
(111, 61, 'Si'),
(112, 61, 'No'),
(113, 62, 'Si'),
(114, 62, 'No'),
(115, 63, 'Si'),
(116, 63, 'No'),
(117, 64, 'Si'),
(118, 64, 'No'),
(119, 65, 'Si'),
(120, 65, 'No'),
(121, 73, 'Regular'),
(122, 73, 'Normal'),
(123, 73, 'Destacado'),
(124, 74, 'Regular'),
(125, 74, 'Normal'),
(126, 74, 'Alto'),
(127, 75, 'Regular'),
(128, 75, 'Normal'),
(129, 75, 'Destacadp'),
(130, 76, 'Regular'),
(131, 76, 'Normal'),
(132, 76, 'Destacado'),
(133, 77, 'Regular'),
(134, 77, 'Normal'),
(135, 77, 'Destacado'),
(136, 78, 'Regular'),
(137, 78, 'Normal'),
(138, 78, 'Destacado'),
(139, 79, 'Regular'),
(140, 79, 'Normal'),
(141, 79, 'Alto'),
(142, 80, 'Regular'),
(143, 80, 'Normal'),
(144, 80, 'Destacadp'),
(145, 81, 'Regular'),
(146, 81, 'Normal'),
(147, 81, 'Destacado'),
(148, 82, 'Regular'),
(149, 82, 'Normal'),
(150, 82, 'Destacado'),
(151, 83, 'Regular'),
(152, 83, 'Normal'),
(153, 83, 'Destacado'),
(154, 84, 'Regular'),
(155, 84, 'Normal'),
(156, 84, 'Alto'),
(157, 85, 'Regular'),
(158, 85, 'Normal'),
(159, 85, 'Destacado'),
(160, 86, 'Regular'),
(161, 86, 'Normal'),
(162, 86, 'Destacado'),
(163, 87, 'Regular'),
(164, 87, 'Normal'),
(165, 87, 'Destacado'),
(166, 88, 'Masculino'),
(167, 88, 'Femenino'),
(168, 89, 'Bien'),
(169, 89, 'Muy bien'),
(170, 89, 'Excelente'),
(171, 90, 'Bien'),
(172, 90, 'Muy bien'),
(173, 90, 'Excelente'),
(174, 91, 'Bien'),
(175, 91, 'Muy bien'),
(176, 91, 'Excelente');

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
) ENGINE=InnoDB AUTO_INCREMENT=19 DEFAULT CHARSET=utf8;

--
-- Volcado de datos para la tabla `recurso`
--

INSERT INTO `recurso` (`id`, `nombre`, `ruta`, `tipo_recurso`, `subido_por`, `estado`) VALUES
(1, 'Tren.jpg', '~/Content/Resources/Uploads/Recursos/65_Tren.jpg', 1, 65, 1),
(2, 'Examen.jpg', '~/Content/Resources/Uploads/Recursos/65_Examen.jpg', 1, 65, 1),
(3, 'Universidad.png', '~/Content/Resources/Uploads/Recursos/65_Universidad.png', 1, 65, 1),
(4, '1.gif', '~/Content/Resources/Uploads/Recursos/65_1.gif', 1, 65, 1),
(5, '2.jpg', '~/Content/Resources/Uploads/Recursos/65_2.jpg', 1, 65, 1),
(6, '3.jpg', '~/Content/Resources/Uploads/Recursos/65_3.jpg', 1, 65, 1),
(7, '4.jpg', '~/Content/Resources/Uploads/Recursos/65_4.jpg', 1, 65, 1),
(8, '5.jpg', '~/Content/Resources/Uploads/Recursos/65_5.jpg', 1, 65, 1),
(9, 'a.jpg', '~/Content/Resources/Uploads/Recursos/65_a.jpg', 1, 65, 1),
(10, 'b.jpeg', '~/Content/Resources/Uploads/Recursos/65_b.jpeg', 1, 65, 1),
(11, 'c.jpg', '~/Content/Resources/Uploads/Recursos/65_c.jpg', 1, 65, 1),
(13, 'Perro.mp3', '~/Content/Resources/Uploads/Recursos/65_Perro.mp3', 2, 65, 1),
(14, 'Tren.mp3', '~/Content/Resources/Uploads/Recursos/65_Tren.mp3', 2, 65, 1),
(15, 'Gato.mp3', '~/Content/Resources/Uploads/Recursos/65_Gato.mp3', 2, 65, 1),
(16, 'Pato.mp3', '~/Content/Resources/Uploads/Recursos/65_Pato.mp3', 2, 65, 1),
(17, 'tren.mp4', '~/Content/Resources/Uploads/Recursos/65_tren.mp4', 3, 65, 1),
(18, 'helicoptero.mp4', '~/Content/Resources/Uploads/Recursos/65_helicoptero.mp4', 3, 65, 1);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `recurso_compartido`
--

CREATE TABLE IF NOT EXISTS `recurso_compartido` (
`id` int(11) NOT NULL,
  `recurso` int(11) DEFAULT NULL,
  `institucion` int(11) DEFAULT NULL
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8;

--
-- Volcado de datos para la tabla `recurso_compartido`
--

INSERT INTO `recurso_compartido` (`id`, `recurso`, `institucion`) VALUES
(1, 1, 8),
(2, 14, 8),
(3, 15, 9);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `seguimiento`
--

CREATE TABLE IF NOT EXISTS `seguimiento` (
`id` int(11) NOT NULL,
  `curso` int(11) DEFAULT NULL,
  `activo` int(11) DEFAULT NULL
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8;

--
-- Volcado de datos para la tabla `seguimiento`
--

INSERT INTO `seguimiento` (`id`, `curso`, `activo`) VALUES
(1, 1, 0),
(2, 1, 0),
(3, 1, 1),
(4, 11, 1);

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
(0, 'a', 1),
(1, 'b', 1),
(2, 'c', 1),
(3, '1', 1),
(4, '2', 1),
(5, '3', 1),
(6, '4', 1),
(7, '5', 1),
(8, 'universidad', 1),
(9, 'examen', 1),
(10, 'poco', 1),
(11, 'tren', 1),
(12, 'mas', 1);

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
) ENGINE=InnoDB AUTO_INCREMENT=176 DEFAULT CHARSET=utf8;

--
-- Volcado de datos para la tabla `usuario`
--

INSERT INTO `usuario` (`id`, `mail`, `contrasena`, `nombre`, `apellido`, `fecha_nacimiento`, `localidad`, `fecha_alta`, `fecha_baja`, `tipo_usuario`, `especialidad`, `estado_usuario`) VALUES
(64, 'marubusse@gmail.com', '6367C48DD193D56EA7B0BAAD25B19455E529F5EE', 'Mariana', 'Busse', '1987-09-27', 141, '2016-02-15 20:09:26', NULL, 1, NULL, NULL),
(65, 'guillefontao@peals.com', '6367C48DD193D56EA7B0BAAD25B19455E529F5EE', 'Guillermo', 'Fontao', '1981-12-23', 658, '2016-02-16 17:55:48', NULL, 2, 2, NULL),
(66, 'nataliagramatica@peals.com', '6367C48DD193D56EA7B0BAAD25B19455E529F5EE', 'Natalia', 'Gramática', '1983-12-08', 658, '2016-02-16 17:56:26', NULL, 2, 2, NULL),
(67, 'rafael.zabala@peals.com', '6367C48DD193D56EA7B0BAAD25B19455E529F5EE', 'Rafael', 'Zabala', '1999-02-04', 658, '2015-02-18 00:00:00', NULL, 3, NULL, 2),
(68, 'carlos.herrador@peals.com', '6367C48DD193D56EA7B0BAAD25B19455E529F5EE', 'Carlos', 'Herrador', '2010-01-26', 658, '2015-02-18 00:00:00', NULL, 3, NULL, 2),
(69, 'mariana.gallardo@peals.com', '6367C48DD193D56EA7B0BAAD25B19455E529F5EE', 'Mariana', 'Gallardo', '2006-07-08', 658, '2015-02-18 00:00:00', NULL, 3, NULL, 2),
(70, 'enrique.garrido@peals.com', '6367C48DD193D56EA7B0BAAD25B19455E529F5EE', 'Enrique', 'Garrido', '1995-03-16', 658, '2015-02-18 00:00:00', NULL, 3, NULL, 2),
(71, 'jaime.diaz@peals.com', '6367C48DD193D56EA7B0BAAD25B19455E529F5EE', 'Jaime', 'Diaz', '2003-08-08', 658, '2015-02-18 00:00:00', NULL, 3, NULL, 2),
(72, 'antonio.sanchez@peals.com', '6367C48DD193D56EA7B0BAAD25B19455E529F5EE', 'Antonio', 'Sanchez', '1995-02-22', 658, '2015-02-18 00:00:00', NULL, 3, NULL, 2),
(73, 'pilar.martin@peals.com', '6367C48DD193D56EA7B0BAAD25B19455E529F5EE', 'Pilar', 'Martin', '2001-06-07', 658, '2015-02-18 00:00:00', NULL, 3, NULL, 2),
(74, 'dolores.rodenas@peals.com', '6367C48DD193D56EA7B0BAAD25B19455E529F5EE', 'Dolores', 'Rodenas', '2003-08-22', 658, '2015-02-18 00:00:00', NULL, 3, NULL, 2),
(75, 'ana.maria.navarro@peals.com', '6367C48DD193D56EA7B0BAAD25B19455E529F5EE', 'Ana Maria', 'Navarro', '2005-03-08', 658, '2015-02-18 00:00:00', NULL, 3, NULL, 2),
(76, 'juan.gonzalez@peals.com', '6367C48DD193D56EA7B0BAAD25B19455E529F5EE', 'Juan', 'Gonzalez', '2002-01-21', 658, '2015-02-18 00:00:00', NULL, 3, NULL, 2),
(77, 'amadeo.hernandez@peals.com', '6367C48DD193D56EA7B0BAAD25B19455E529F5EE', 'Amadeo', 'Hernandez', '2008-06-03', 658, '2015-02-18 00:00:00', NULL, 3, NULL, 2),
(78, 'jorge.morata@peals.com', '6367C48DD193D56EA7B0BAAD25B19455E529F5EE', 'Jorge', 'Morata', '2006-07-29', 658, '2015-02-18 00:00:00', NULL, 3, NULL, 2),
(79, 'juan.carlos.castro@peals.com', '6367C48DD193D56EA7B0BAAD25B19455E529F5EE', 'Juan Carlos', 'Castro', '2000-07-25', 658, '2015-02-18 00:00:00', NULL, 3, NULL, 2),
(80, 'manuel.taboada@peals.com', '6367C48DD193D56EA7B0BAAD25B19455E529F5EE', 'Manuel', 'Taboada', '2007-09-15', 658, '2015-02-18 00:00:00', NULL, 3, NULL, 2),
(81, 'maria.ayuso@peals.com', '6367C48DD193D56EA7B0BAAD25B19455E529F5EE', 'Maria', 'Ayuso', '1997-09-13', 658, '2015-02-18 00:00:00', NULL, 3, NULL, 2),
(82, 'jesus.sanchez@peals.com', '6367C48DD193D56EA7B0BAAD25B19455E529F5EE', 'Jesus', 'Sanchez', '2010-01-04', 658, '2015-02-18 00:00:00', NULL, 3, NULL, 2),
(83, 'bartolome.hernandez@peals.com', '6367C48DD193D56EA7B0BAAD25B19455E529F5EE', 'Bartolome', 'Hernandez', '1998-09-09', 658, '2015-02-18 00:00:00', NULL, 3, NULL, 2),
(84, 'carmela.cazas@peals.com', '6367C48DD193D56EA7B0BAAD25B19455E529F5EE', 'Carmela', 'Cazas', '2004-04-13', 658, '2015-02-18 00:00:00', NULL, 3, NULL, 2),
(85, 'alberto.garcia@peals.com', '6367C48DD193D56EA7B0BAAD25B19455E529F5EE', 'Alberto', 'Garcia', '1998-11-24', 658, '2015-02-18 00:00:00', NULL, 3, NULL, 2),
(86, 'jonas.morales@peals.com', '6367C48DD193D56EA7B0BAAD25B19455E529F5EE', 'Jonas', 'Morales', '2009-08-02', 658, '2015-02-18 00:00:00', NULL, 3, NULL, 2),
(87, 'javier.gil@peals.com', '6367C48DD193D56EA7B0BAAD25B19455E529F5EE', 'Javier', 'Gil', '2005-02-02', 658, '2015-02-18 00:00:00', NULL, 3, NULL, 2),
(88, 'fernando.funes@peals.com', '6367C48DD193D56EA7B0BAAD25B19455E529F5EE', 'Fernando', 'Funes', '2009-11-03', 658, '2015-02-18 00:00:00', NULL, 3, NULL, 2),
(89, 'anibal.rodriguez@peals.com', '6367C48DD193D56EA7B0BAAD25B19455E529F5EE', 'Anibal', 'Rodriguez', '1998-06-03', 658, '2015-02-18 00:00:00', NULL, 3, NULL, 2),
(90, 'manuel.perez@peals.com', '6367C48DD193D56EA7B0BAAD25B19455E529F5EE', 'Manuel', 'Perez', '1996-10-29', 658, '2015-02-18 00:00:00', NULL, 3, NULL, 2),
(91, 'anai.abad@peals.com', '6367C48DD193D56EA7B0BAAD25B19455E529F5EE', 'Anai', 'Abad', '2007-06-23', 658, '2015-02-18 00:00:00', NULL, 3, NULL, 2),
(92, 'marina.martinez@peals.com', '6367C48DD193D56EA7B0BAAD25B19455E529F5EE', 'Marina', 'Martinez', '1999-11-03', 658, '2015-02-18 00:00:00', NULL, 3, NULL, 2),
(93, 'teresa.lopez@peals.com', '6367C48DD193D56EA7B0BAAD25B19455E529F5EE', 'Teresa', 'Lopez', '2010-11-19', 658, '2015-02-18 00:00:00', NULL, 3, NULL, 2),
(94, 'antonio.marengo@peals.com', '6367C48DD193D56EA7B0BAAD25B19455E529F5EE', 'Antonio', 'Marengo', '2006-09-17', 658, '2015-02-18 00:00:00', NULL, 3, NULL, 2),
(95, 'romina.romero@peals.com', '6367C48DD193D56EA7B0BAAD25B19455E529F5EE', 'Romina', 'Romero', '2000-12-18', 658, '2015-02-18 00:00:00', NULL, 3, NULL, 2),
(96, 'alejandro.escribano@peals.com', '6367C48DD193D56EA7B0BAAD25B19455E529F5EE', 'Alejandro', 'Escribano', '2000-12-24', 658, '2015-02-18 00:00:00', NULL, 3, NULL, 2),
(97, 'concepcion.baena@peals.com', '6367C48DD193D56EA7B0BAAD25B19455E529F5EE', 'Concepcion', 'Baena', '1999-02-06', 658, '2015-02-18 00:00:00', NULL, 3, NULL, 2),
(98, 'alfonso.fernandez@peals.com', '6367C48DD193D56EA7B0BAAD25B19455E529F5EE', 'Alfonso', 'Fernandez', '1997-04-22', 658, '2015-02-18 00:00:00', NULL, 3, NULL, 2),
(99, 'isabel.riquelme@peals.com', '6367C48DD193D56EA7B0BAAD25B19455E529F5EE', 'Isabel', 'Riquelme', '2000-11-18', 658, '2015-02-18 00:00:00', NULL, 3, NULL, 2),
(100, 'marcela.barquen@peals.com', '6367C48DD193D56EA7B0BAAD25B19455E529F5EE', 'Marcela', 'Barquen', '2001-02-12', 658, '2015-02-18 00:00:00', NULL, 3, NULL, 2),
(101, 'candela.martos@peals.com', '6367C48DD193D56EA7B0BAAD25B19455E529F5EE', 'Candela', 'Martos', '2004-12-30', 658, '2015-02-18 00:00:00', NULL, 3, NULL, 2),
(102, 'julian.vidal@peals.com', '6367C48DD193D56EA7B0BAAD25B19455E529F5EE', 'Julian', 'Vidal', '1999-09-14', 658, '2015-02-18 00:00:00', NULL, 3, NULL, 2),
(103, 'cristina.vidal@peals.com', '6367C48DD193D56EA7B0BAAD25B19455E529F5EE', 'Cristina', 'Vidal', '1997-09-28', 658, '2015-02-18 00:00:00', NULL, 3, NULL, 2),
(104, 'pilar.cabal@peals.com', '6367C48DD193D56EA7B0BAAD25B19455E529F5EE', 'Pilar', 'Cabal', '2000-11-19', 658, '2015-02-18 00:00:00', NULL, 3, NULL, 2),
(105, 'beatriz.salmon@peals.com', '6367C48DD193D56EA7B0BAAD25B19455E529F5EE', 'Beatriz', 'Salmon', '2001-03-29', 658, '2015-02-18 00:00:00', NULL, 3, NULL, 2),
(106, 'marta.velasco@peals.com', '6367C48DD193D56EA7B0BAAD25B19455E529F5EE', 'Marta', 'Velasco', '1996-08-29', 658, '2015-02-18 00:00:00', NULL, 3, NULL, 2),
(107, 'guillermo.vega@peals.com', '6367C48DD193D56EA7B0BAAD25B19455E529F5EE', 'Guillermo', 'Vega', '2005-11-03', 658, '2015-02-18 00:00:00', NULL, 3, NULL, 2),
(108, 'marcos.luna@peals.com', '6367C48DD193D56EA7B0BAAD25B19455E529F5EE', 'Marcos', 'Luna', '2010-09-17', 658, '2015-02-18 00:00:00', NULL, 3, NULL, 2),
(109, 'andres.alba@peals.com', '6367C48DD193D56EA7B0BAAD25B19455E529F5EE', 'Andres', 'Alba', '1995-05-27', 658, '2015-02-18 00:00:00', NULL, 3, NULL, 2),
(110, 'benito.vidal@peals.com', '6367C48DD193D56EA7B0BAAD25B19455E529F5EE', 'Benito', 'Vidal', '2010-06-30', 658, '2015-02-18 00:00:00', NULL, 3, NULL, 2),
(111, 'pedro.lago@peals.com', '6367C48DD193D56EA7B0BAAD25B19455E529F5EE', 'Pedro', 'Lago', '1997-04-25', 658, '2015-02-18 00:00:00', NULL, 3, NULL, 2),
(112, 'david.jordan@peals.com', '6367C48DD193D56EA7B0BAAD25B19455E529F5EE', 'David', 'Jordan', '2000-08-16', 658, '2015-02-18 00:00:00', NULL, 3, NULL, 2),
(113, 'santino.oliver@peals.com', '6367C48DD193D56EA7B0BAAD25B19455E529F5EE', 'Santino', 'Oliver', '2000-01-12', 658, '2015-02-18 00:00:00', NULL, 3, NULL, 2),
(114, 'manuel.iglesias@peals.com', '6367C48DD193D56EA7B0BAAD25B19455E529F5EE', 'Manuel', 'Iglesias', '1995-03-30', 658, '2015-02-18 00:00:00', NULL, 3, NULL, 2),
(115, 'bautista.sanchez@peals.com', '6367C48DD193D56EA7B0BAAD25B19455E529F5EE', 'Bautista', 'Sanchez', '2004-09-26', 658, '2015-02-18 00:00:00', NULL, 3, NULL, 2),
(116, 'paula.mora@peals.com', '6367C48DD193D56EA7B0BAAD25B19455E529F5EE', 'Paula', 'Mora', '2004-03-09', 658, '2015-02-18 00:00:00', NULL, 3, NULL, 2),
(117, 'martin.medina@peals.com', '6367C48DD193D56EA7B0BAAD25B19455E529F5EE', 'Martin', 'Medina', '2006-10-17', 658, '2015-02-18 00:00:00', NULL, 3, NULL, 2),
(118, 'yolanda.barbero@peals.com', '6367C48DD193D56EA7B0BAAD25B19455E529F5EE', 'Yolanda', 'Barbero', '2004-05-27', 658, '2015-02-18 00:00:00', NULL, 3, NULL, 2),
(119, 'carlos.escalona@peals.com', '6367C48DD193D56EA7B0BAAD25B19455E529F5EE', 'Carlos', 'Escalona', '2009-08-26', 658, '2015-02-18 00:00:00', NULL, 3, NULL, 2),
(120, 'adrian.hurtado@peals.com', '6367C48DD193D56EA7B0BAAD25B19455E529F5EE', 'Adrian', 'Hurtado', '2009-11-02', 658, '2015-02-18 00:00:00', NULL, 3, NULL, 2),
(121, 'rafael.villar@peals.com', '6367C48DD193D56EA7B0BAAD25B19455E529F5EE', 'Rafael', 'Villar', '1998-05-21', 658, '2015-02-18 00:00:00', NULL, 3, NULL, 2),
(122, 'victoria.calamaro@peals.com', '6367C48DD193D56EA7B0BAAD25B19455E529F5EE', 'Victoria', 'Calamaro', '1998-12-25', 658, '2015-02-18 00:00:00', NULL, 3, NULL, 2),
(123, 'emiliano.herrero@peals.com', '6367C48DD193D56EA7B0BAAD25B19455E529F5EE', 'Emiliano', 'Herrero', '2000-11-14', 658, '2015-02-18 00:00:00', NULL, 3, NULL, 2),
(124, 'francisco.franco@peals.com', '6367C48DD193D56EA7B0BAAD25B19455E529F5EE', 'Francisco', 'Franco', '1999-12-31', 658, '2015-02-18 00:00:00', NULL, 3, NULL, 2),
(125, 'alberto.hernando@peals.com', '6367C48DD193D56EA7B0BAAD25B19455E529F5EE', 'Alberto', 'Hernando', '2001-07-07', 658, '2015-02-18 00:00:00', NULL, 3, NULL, 2),
(126, 'antonio.ramos@peals.com', '6367C48DD193D56EA7B0BAAD25B19455E529F5EE', 'Antonio', 'Ramos', '1999-11-08', 658, '2015-02-18 00:00:00', NULL, 3, NULL, 2),
(127, 'dolores.reyes@peals.com', '6367C48DD193D56EA7B0BAAD25B19455E529F5EE', 'Dolores', 'Reyes', '1999-06-01', 658, '2015-02-18 00:00:00', NULL, 3, NULL, 2),
(128, 'cristina.serrano@peals.com', '6367C48DD193D56EA7B0BAAD25B19455E529F5EE', 'Cristina', 'Serrano', '1998-08-27', 658, '2015-02-18 00:00:00', NULL, 3, NULL, 2),
(129, 'jaime.santos@peals.com', '6367C48DD193D56EA7B0BAAD25B19455E529F5EE', 'Jaime', 'Santos', '1997-10-24', 658, '2015-02-18 00:00:00', NULL, 3, NULL, 2),
(130, 'nelson.pereyra@peals.com', '6367C48DD193D56EA7B0BAAD25B19455E529F5EE', 'Nelson', 'Pereyra', '2011-06-08', 658, '2015-02-18 00:00:00', NULL, 3, NULL, 2),
(131, 'pablo.fernandez@peals.com', '6367C48DD193D56EA7B0BAAD25B19455E529F5EE', 'Pablo', 'Fernandez', '2000-10-21', 658, '2015-02-18 00:00:00', NULL, 3, NULL, 2),
(132, 'josefa.garcena@peals.com', '6367C48DD193D56EA7B0BAAD25B19455E529F5EE', 'Josefa', 'Garcena', '2009-03-11', 658, '2015-02-18 00:00:00', NULL, 3, NULL, 2),
(133, 'laura.gallego@peals.com', '6367C48DD193D56EA7B0BAAD25B19455E529F5EE', 'Laura', 'Gallego', '2010-01-23', 658, '2015-02-18 00:00:00', NULL, 3, NULL, 2),
(134, 'natalia.vilchez@peals.com', '6367C48DD193D56EA7B0BAAD25B19455E529F5EE', 'Natalia', 'Vilchez', '2010-10-03', 658, '2015-02-18 00:00:00', NULL, 3, NULL, 2),
(135, 'antonio.dominguez@peals.com', '6367C48DD193D56EA7B0BAAD25B19455E529F5EE', 'Antonio', 'Dominguez', '2001-01-13', 658, '2015-02-18 00:00:00', NULL, 3, NULL, 2),
(136, 'laura.martin@peals.com', '6367C48DD193D56EA7B0BAAD25B19455E529F5EE', 'Laura', 'Martin', '1995-09-30', 658, '2015-02-18 00:00:00', NULL, 3, NULL, 2),
(137, 'alejandro.sanabria@peals.com', '6367C48DD193D56EA7B0BAAD25B19455E529F5EE', 'Alejandro', 'Sanabria', '2005-10-05', 658, '2015-02-18 00:00:00', NULL, 3, NULL, 2),
(138, 'juan.aguado@peals.com', '6367C48DD193D56EA7B0BAAD25B19455E529F5EE', 'Juan', 'Aguado', '2008-08-07', 658, '2015-02-18 00:00:00', NULL, 3, NULL, 2),
(139, 'david.puerto@peals.com', '6367C48DD193D56EA7B0BAAD25B19455E529F5EE', 'David', 'Puerto', '1995-04-27', 658, '2015-02-18 00:00:00', NULL, 3, NULL, 2),
(140, 'pilar.gil@peals.com', '6367C48DD193D56EA7B0BAAD25B19455E529F5EE', 'Pilar', 'Gil', '2004-11-05', 658, '2015-02-18 00:00:00', NULL, 3, NULL, 2),
(141, 'mercedes.muniz@peals.com', '6367C48DD193D56EA7B0BAAD25B19455E529F5EE', 'Mercedes', 'Muniz', '2007-08-14', 658, '2015-02-18 00:00:00', NULL, 3, NULL, 2),
(142, 'gabriela.paez@peals.com', '6367C48DD193D56EA7B0BAAD25B19455E529F5EE', 'Gabriela', 'Paez', '1995-07-03', 658, '2015-02-18 00:00:00', NULL, 3, NULL, 2),
(143, 'angel.salas@peals.com', '6367C48DD193D56EA7B0BAAD25B19455E529F5EE', 'Angel', 'Salas', '1997-04-29', 658, '2015-02-18 00:00:00', NULL, 3, NULL, 2),
(144, 'antonio.torres@peals.com', '6367C48DD193D56EA7B0BAAD25B19455E529F5EE', 'Antonio', 'Torres', '2006-04-30', 658, '2015-02-18 00:00:00', NULL, 3, NULL, 2),
(145, 'angela.gil@peals.com', '6367C48DD193D56EA7B0BAAD25B19455E529F5EE', 'Angela', 'Gil', '2008-11-16', 658, '2015-02-18 00:00:00', NULL, 3, NULL, 2),
(146, 'josefa.picazo@peals.com', '6367C48DD193D56EA7B0BAAD25B19455E529F5EE', 'Josefa', 'Picazo', '2004-04-25', 658, '2015-02-18 00:00:00', NULL, 3, NULL, 2),
(147, 'manuel.martin@peals.com', '6367C48DD193D56EA7B0BAAD25B19455E529F5EE', 'Manuel', 'Martin', '2002-05-10', 658, '2015-02-18 00:00:00', NULL, 3, NULL, 2),
(148, 'marta.mauri@peals.com', '6367C48DD193D56EA7B0BAAD25B19455E529F5EE', 'Marta', 'Mauri', '2010-03-29', 658, '2015-02-18 00:00:00', NULL, 3, NULL, 2),
(149, 'marcelo.perea@peals.com', '6367C48DD193D56EA7B0BAAD25B19455E529F5EE', 'Marcelo', 'Perea', '2008-04-10', 658, '2015-02-18 00:00:00', NULL, 3, NULL, 2),
(150, 'sonia.padilla@peals.com', '6367C48DD193D56EA7B0BAAD25B19455E529F5EE', 'Sonia', 'Padilla', '2008-06-17', 658, '2015-02-18 00:00:00', NULL, 3, NULL, 2),
(151, 'silvia.vera@peals.com', '6367C48DD193D56EA7B0BAAD25B19455E529F5EE', 'Silvia', 'Vera', '1998-02-06', 658, '2015-02-18 00:00:00', NULL, 3, NULL, 2),
(152, 'isabel.cornero@peals.com', '6367C48DD193D56EA7B0BAAD25B19455E529F5EE', 'Isabel', 'Cornero', '2001-05-25', 658, '2015-02-18 00:00:00', NULL, 3, NULL, 2),
(153, 'luis.esteve@peals.com', '6367C48DD193D56EA7B0BAAD25B19455E529F5EE', 'Luis', 'Esteve', '2009-10-21', 658, '2015-02-18 00:00:00', NULL, 3, NULL, 2),
(154, 'carmen.serrano@peals.com', '6367C48DD193D56EA7B0BAAD25B19455E529F5EE', 'Carmen', 'Serrano', '1995-02-25', 658, '2015-02-18 00:00:00', NULL, 3, NULL, 2),
(155, 'josefa.castro@peals.com', '6367C48DD193D56EA7B0BAAD25B19455E529F5EE', 'Josefa', 'Castro', '1999-04-12', 658, '2015-02-18 00:00:00', NULL, 3, NULL, 2),
(156, 'daniel.castro@peals.com', '6367C48DD193D56EA7B0BAAD25B19455E529F5EE', 'Daniel', 'Castro', '1996-10-28', 658, '2015-02-18 00:00:00', NULL, 3, NULL, 2),
(157, 'carmen.villalobos@peals.com', '6367C48DD193D56EA7B0BAAD25B19455E529F5EE', 'Carmen', 'Villalobos', '2000-09-28', 658, '2015-02-18 00:00:00', NULL, 3, NULL, 2),
(158, 'juan.amengual@peals.com', '6367C48DD193D56EA7B0BAAD25B19455E529F5EE', 'Juan', 'Amengual', '2001-07-09', 658, '2015-02-18 00:00:00', NULL, 3, NULL, 2),
(159, 'margarita.montin@peals.com', '6367C48DD193D56EA7B0BAAD25B19455E529F5EE', 'Margarita', 'Montin', '2006-11-08', 658, '2015-02-18 00:00:00', NULL, 3, NULL, 2),
(160, 'mariano.hernandez@peals.com', '6367C48DD193D56EA7B0BAAD25B19455E529F5EE', 'Mariano', 'Hernandez', '2005-06-11', 658, '2015-02-18 00:00:00', NULL, 3, NULL, 2),
(161, 'marcela.ortiz@peals.com', '6367C48DD193D56EA7B0BAAD25B19455E529F5EE', 'Marcela', 'Ortiz', '1996-12-02', 658, '2015-02-18 00:00:00', NULL, 3, NULL, 2),
(162, 'manuela.suarez@peals.com', '6367C48DD193D56EA7B0BAAD25B19455E529F5EE', 'Manuela', 'Suarez', '2008-07-07', 658, '2015-02-18 00:00:00', NULL, 3, NULL, 2),
(163, 'luis.lopez@peals.com', '6367C48DD193D56EA7B0BAAD25B19455E529F5EE', 'Luis', 'Lopez', '1995-08-16', 658, '2015-02-18 00:00:00', NULL, 3, NULL, 2),
(164, 'manuel.delgado@peals.com', '6367C48DD193D56EA7B0BAAD25B19455E529F5EE', 'Manuel', 'Delgado', '1998-07-28', 658, '2015-02-18 00:00:00', NULL, 3, NULL, 2),
(165, 'francisco.delgado@peals.com', '6367C48DD193D56EA7B0BAAD25B19455E529F5EE', 'Francisco', 'Delgado', '2005-06-29', 658, '2015-02-18 00:00:00', NULL, 3, NULL, 2),
(166, 'juana.vianco@peals.com', '6367C48DD193D56EA7B0BAAD25B19455E529F5EE', 'Juana', 'Vianco', '2002-12-17', 658, '2015-02-18 00:00:00', NULL, 3, NULL, 2),
(167, 'rodolfobusse@peals.com', '6367C48DD193D56EA7B0BAAD25B19455E529F5EE', 'Rodolfo', 'Busse', '1987-09-27', 141, '2016-03-07 17:30:52', NULL, 1, NULL, NULL),
(168, 'gabrielabusse@peals.com', '6367C48DD193D56EA7B0BAAD25B19455E529F5EE', 'Gabriela', 'Busse', '1987-09-27', 141, '2016-03-07 17:44:04', NULL, 1, NULL, NULL),
(169, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL),
(170, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL),
(171, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL),
(172, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL),
(173, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL),
(174, 'oscargramatica@peals.com', '6367C48DD193D56EA7B0BAAD25B19455E529F5EE', 'Oscar Alfredo', 'Gramática', '1952-05-08', 658, '2016-03-13 15:36:44', NULL, 2, 2, NULL),
(175, 'elvalauret@peals.com', '6367C48DD193D56EA7B0BAAD25B19455E529F5EE', 'Elva', 'Lauret', '1955-10-28', 658, '2016-03-13 15:37:28', NULL, 2, 3, NULL);

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
 ADD PRIMARY KEY (`id`);

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
MODIFY `id` int(11) NOT NULL AUTO_INCREMENT,AUTO_INCREMENT=5;
--
-- AUTO_INCREMENT de la tabla `actividad_x_curso`
--
ALTER TABLE `actividad_x_curso`
MODIFY `id` int(11) NOT NULL AUTO_INCREMENT,AUTO_INCREMENT=3;
--
-- AUTO_INCREMENT de la tabla `adjuntos`
--
ALTER TABLE `adjuntos`
MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;
--
-- AUTO_INCREMENT de la tabla `alumno_x_curso`
--
ALTER TABLE `alumno_x_curso`
MODIFY `id` int(11) NOT NULL AUTO_INCREMENT,AUTO_INCREMENT=72;
--
-- AUTO_INCREMENT de la tabla `alumno_x_institucion`
--
ALTER TABLE `alumno_x_institucion`
MODIFY `id` int(11) NOT NULL AUTO_INCREMENT,AUTO_INCREMENT=72;
--
-- AUTO_INCREMENT de la tabla `criterio_evaluacion`
--
ALTER TABLE `criterio_evaluacion`
MODIFY `id` int(11) NOT NULL AUTO_INCREMENT,AUTO_INCREMENT=2;
--
-- AUTO_INCREMENT de la tabla `curso`
--
ALTER TABLE `curso`
MODIFY `id` int(11) NOT NULL AUTO_INCREMENT,AUTO_INCREMENT=13;
--
-- AUTO_INCREMENT de la tabla `diac`
--
ALTER TABLE `diac`
MODIFY `id` int(11) NOT NULL AUTO_INCREMENT,AUTO_INCREMENT=5;
--
-- AUTO_INCREMENT de la tabla `docente_x_institucion`
--
ALTER TABLE `docente_x_institucion`
MODIFY `id` int(11) NOT NULL AUTO_INCREMENT,AUTO_INCREMENT=6;
--
-- AUTO_INCREMENT de la tabla `ejercicio`
--
ALTER TABLE `ejercicio`
MODIFY `id` int(11) NOT NULL AUTO_INCREMENT,AUTO_INCREMENT=6;
--
-- AUTO_INCREMENT de la tabla `ejercicio_x_recurso`
--
ALTER TABLE `ejercicio_x_recurso`
MODIFY `id` int(11) NOT NULL AUTO_INCREMENT,AUTO_INCREMENT=6;
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
MODIFY `id` int(11) NOT NULL AUTO_INCREMENT,AUTO_INCREMENT=2;
--
-- AUTO_INCREMENT de la tabla `informacion`
--
ALTER TABLE `informacion`
MODIFY `id` int(11) NOT NULL AUTO_INCREMENT,AUTO_INCREMENT=11;
--
-- AUTO_INCREMENT de la tabla `institucion`
--
ALTER TABLE `institucion`
MODIFY `id` int(11) NOT NULL AUTO_INCREMENT,AUTO_INCREMENT=11;
--
-- AUTO_INCREMENT de la tabla `item`
--
ALTER TABLE `item`
MODIFY `id` int(11) NOT NULL AUTO_INCREMENT,AUTO_INCREMENT=100;
--
-- AUTO_INCREMENT de la tabla `llenadoseguimiento`
--
ALTER TABLE `llenadoseguimiento`
MODIFY `id` int(11) NOT NULL AUTO_INCREMENT,AUTO_INCREMENT=27;
--
-- AUTO_INCREMENT de la tabla `llenadoseguimientodetalle`
--
ALTER TABLE `llenadoseguimientodetalle`
MODIFY `id` int(11) NOT NULL AUTO_INCREMENT,AUTO_INCREMENT=321;
--
-- AUTO_INCREMENT de la tabla `localidad`
--
ALTER TABLE `localidad`
MODIFY `id` int(11) NOT NULL AUTO_INCREMENT,AUTO_INCREMENT=659;
--
-- AUTO_INCREMENT de la tabla `mensaje`
--
ALTER TABLE `mensaje`
MODIFY `id` int(11) NOT NULL AUTO_INCREMENT,AUTO_INCREMENT=194;
--
-- AUTO_INCREMENT de la tabla `mensaje_x_destinatario`
--
ALTER TABLE `mensaje_x_destinatario`
MODIFY `id` int(11) NOT NULL AUTO_INCREMENT,AUTO_INCREMENT=194;
--
-- AUTO_INCREMENT de la tabla `nivel`
--
ALTER TABLE `nivel`
MODIFY `id` int(11) NOT NULL AUTO_INCREMENT,AUTO_INCREMENT=7;
--
-- AUTO_INCREMENT de la tabla `opcion`
--
ALTER TABLE `opcion`
MODIFY `id` int(11) NOT NULL AUTO_INCREMENT,AUTO_INCREMENT=177;
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
MODIFY `id` int(11) NOT NULL AUTO_INCREMENT,AUTO_INCREMENT=19;
--
-- AUTO_INCREMENT de la tabla `recurso_compartido`
--
ALTER TABLE `recurso_compartido`
MODIFY `id` int(11) NOT NULL AUTO_INCREMENT,AUTO_INCREMENT=4;
--
-- AUTO_INCREMENT de la tabla `seguimiento`
--
ALTER TABLE `seguimiento`
MODIFY `id` int(11) NOT NULL AUTO_INCREMENT,AUTO_INCREMENT=5;
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
MODIFY `id` int(11) NOT NULL AUTO_INCREMENT,AUTO_INCREMENT=176;
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

ALTER TABLE peals.ejercicio_x_recurso
ADD COLUMN width VARCHAR(10) NULL AFTER `pos_left`;

ALTER TABLE peals.ejercicio_x_recurso
ADD COLUMN height VARCHAR(10) NULL AFTER `pos_left`;

ALTER TABLE peals.ejercicio
ADD COLUMN zoom VARCHAR(10) NULL AFTER `senia`;

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
