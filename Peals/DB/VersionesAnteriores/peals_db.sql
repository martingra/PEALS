CREATE DATABASE  IF NOT EXISTS `peals` /*!40100 DEFAULT CHARACTER SET utf8 */;
USE `peals`;
-- MySQL dump 10.13  Distrib 5.5.16, for Win32 (x86)
--
-- Host: localhost    Database: peals
-- ------------------------------------------------------
-- Server version       5.5.28

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `actividad`
--

DROP TABLE IF EXISTS `actividad`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `actividad` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `nombre` varchar(150) DEFAULT NULL,
  `fecha_alta` date DEFAULT NULL,
  `privacidad` int(11) DEFAULT NULL,
  `texto` varchar(200) DEFAULT NULL,
  `deletreo` varchar(50) DEFAULT NULL,
  `tipo_actividad` int(11) DEFAULT NULL,
  `imagen_correcta` int(11) DEFAULT NULL,
  `docente` int(11) DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `fk_tipoActividad_actividad` (`tipo_actividad`),
  KEY `fk_docente_actividad` (`docente`),
  CONSTRAINT `fk_docente_actividad` FOREIGN KEY (`docente`) REFERENCES `usuario` (`id`),
  CONSTRAINT `fk_tipoActividad_actividad` FOREIGN KEY (`tipo_actividad`) REFERENCES `tipo_actividad` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `actividad`
--

LOCK TABLES `actividad` WRITE;
/*!40000 ALTER TABLE `actividad` DISABLE KEYS */;
/*!40000 ALTER TABLE `actividad` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `actividad_x_curso`
--

DROP TABLE IF EXISTS `actividad_x_curso`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `actividad_x_curso` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `actividad` int(11) DEFAULT NULL,
  `curso` int(11) DEFAULT NULL,
  `fecha_apertura` datetime DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `fk_actividad_actividadXcurso` (`actividad`),
  KEY `fk_curso_actividadXcurso` (`curso`),
  CONSTRAINT `fk_actividad_actividadXcurso` FOREIGN KEY (`actividad`) REFERENCES `actividad` (`id`),
  CONSTRAINT `fk_curso_actividadXcurso` FOREIGN KEY (`curso`) REFERENCES `curso` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `actividad_x_curso`
--

LOCK TABLES `actividad_x_curso` WRITE;
/*!40000 ALTER TABLE `actividad_x_curso` DISABLE KEYS */;
/*!40000 ALTER TABLE `actividad_x_curso` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `actividad_x_recurso`
--

DROP TABLE IF EXISTS `actividad_x_recurso`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `actividad_x_recurso` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `actividad` int(11) DEFAULT NULL,
  `recurso` int(11) DEFAULT NULL,
  `pos_top` varchar(6),
  `pos_left` varchar(6),
  PRIMARY KEY (`id`),
  KEY `fk_actividad_actividadXrecurso` (`actividad`),
  KEY `fk_recurso_actividadXrecurso` (`recurso`),
  CONSTRAINT `fk_actividad_actividadXrecurso` FOREIGN KEY (`actividad`) REFERENCES `actividad` (`id`),
  CONSTRAINT `fk_recurso_actividadXrecurso` FOREIGN KEY (`recurso`) REFERENCES `recurso` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `actividad_x_recurso`
--

LOCK TABLES `actividad_x_recurso` WRITE;
/*!40000 ALTER TABLE `actividad_x_recurso` DISABLE KEYS */;
/*!40000 ALTER TABLE `actividad_x_recurso` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `alumno_x_curso`
--

DROP TABLE IF EXISTS `alumno_x_curso`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `alumno_x_curso` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `alumno` int(11) DEFAULT NULL,
  `curso` int(11) DEFAULT NULL,
  `fecha_asignacion` date DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `fk_alumno_alumnoXcurso` (`alumno`),
  KEY `fk_curso_alumnoXcurso` (`curso`),
  CONSTRAINT `fk_alumno_alumnoXcurso` FOREIGN KEY (`alumno`) REFERENCES `usuario` (`id`),
  CONSTRAINT `fk_curso_alumnoXcurso` FOREIGN KEY (`curso`) REFERENCES `curso` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `alumno_x_curso`
--

LOCK TABLES `alumno_x_curso` WRITE;
/*!40000 ALTER TABLE `alumno_x_curso` DISABLE KEYS */;
INSERT INTO `alumno_x_curso` VALUES (1, 3, 1, "2013-08-12");
/*!40000 ALTER TABLE `alumno_x_curso` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `alumno_x_institucion`
--

DROP TABLE IF EXISTS `alumno_x_institucion`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `alumno_x_institucion` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `alumno` int(11) DEFAULT NULL,
  `institucion` int(11) DEFAULT NULL,
  `fecha_alta` date DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `fk_alumno_alumnoXinstitucion` (`alumno`),
  KEY `fk_institucion_alumnoXinstitucion` (`institucion`),
  CONSTRAINT `fk_alumno_alumnoXinstitucion` FOREIGN KEY (`alumno`) REFERENCES `usuario` (`id`),
  CONSTRAINT `fk_institucion_alumnoXinstitucion` FOREIGN KEY (`institucion`) REFERENCES `institucion` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `alumno_x_institucion`
--

LOCK TABLES `alumno_x_institucion` WRITE;
/*!40000 ALTER TABLE `alumno_x_institucion` DISABLE KEYS */;
INSERT INTO `alumno_x_institucion` VALUES (1, 3, 1, "2013-08-12");
/*!40000 ALTER TABLE `alumno_x_institucion` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `apreciacion_docente`
--

DROP TABLE IF EXISTS `apreciacion_docente`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `apreciacion_docente` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `puntaje` int(11) DEFAULT NULL,
  `historial_actividad` int(11) DEFAULT NULL,
  `criterio_evaluacion` int(11) DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `fk_historialActividad_apreciacionDocente` (`historial_actividad`),
  KEY `fk_criterioEvaluacion_apreciacionDocente` (`criterio_evaluacion`),
  CONSTRAINT `fk_criterioEvaluacion_apreciacionDocente` FOREIGN KEY (`criterio_evaluacion`) REFERENCES `criterio_evaluacion` (`id`),
  CONSTRAINT `fk_historialActividad_apreciacionDocente` FOREIGN KEY (`historial_actividad`) REFERENCES `historial_actividad` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `apreciacion_docente`
--

LOCK TABLES `apreciacion_docente` WRITE;
/*!40000 ALTER TABLE `apreciacion_docente` DISABLE KEYS */;
/*!40000 ALTER TABLE `apreciacion_docente` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `criterio_evaluacion`
--

DROP TABLE IF EXISTS `criterio_evaluacion`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `criterio_evaluacion` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `nombre` varchar(200) DEFAULT NULL,
  `docente` int(11) DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `fk_docente_criterioEvaluacion` (`docente`),
  CONSTRAINT `fk_docente_criterioEvaluacion` FOREIGN KEY (`docente`) REFERENCES `usuario` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `criterio_evaluacion`
--

LOCK TABLES `criterio_evaluacion` WRITE;
/*!40000 ALTER TABLE `criterio_evaluacion` DISABLE KEYS */;
/*!40000 ALTER TABLE `criterio_evaluacion` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `curso`
--

DROP TABLE IF EXISTS `curso`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `curso` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `turno` int(11) DEFAULT NULL,
  `nivel` int(11) DEFAULT NULL,
  `ano` int(11) DEFAULT NULL,
  `division` varchar(30) DEFAULT NULL,
  `docente` int(11) DEFAULT NULL,
  `institucion` int(11) DEFAULT NULL,
  `es_publico` tinyint(1) DEFAULT NULL,
  `nombre` varchar(45) DEFAULT NULL,
  `descripcion` varchar(200) DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `fk_turno_curso` (`turno`),
  KEY `fk_nivel_curso` (`nivel`),
  KEY `fk_docente_curso` (`docente`),
  KEY `fk_institucion_curso` (`institucion`),
  CONSTRAINT `fk_docente_curso` FOREIGN KEY (`docente`) REFERENCES `usuario` (`id`),
  CONSTRAINT `fk_institucion_curso` FOREIGN KEY (`institucion`) REFERENCES `institucion` (`id`),
  CONSTRAINT `fk_nivel_curso` FOREIGN KEY (`nivel`) REFERENCES `nivel` (`id`),
  CONSTRAINT `fk_turno_curso` FOREIGN KEY (`turno`) REFERENCES `turno` (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=12 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `curso`
--

LOCK TABLES `curso` WRITE;
/*!40000 ALTER TABLE `curso` DISABLE KEYS */;
INSERT INTO `curso` VALUES (1,1,1,1,'B',2,1,0,'Aprender con colores','Curso donde aprenderemos a escribir y nombrar los colores'),(2,2,1,2,'A',2,1,0,'Las señas nuestro lenguaje','Curso donde se introduce a la escritura en base a señas'),(3,3,1,3,'C',2,1,0,'Letras','Aprenderemos el abecedarios'),(4,2,1,2,'A',2,1,0,'Numeros','Aprenderemos todos los numeros'),(5,2,1,3,'B',2,1,0,'Aprender jugando','Curso para reforzar el area del habla');
/*!40000 ALTER TABLE `curso` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `docente_x_institucion`
--

DROP TABLE IF EXISTS `docente_x_institucion`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `docente_x_institucion` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `docente` int(11) DEFAULT NULL,
  `institucion` int(11) DEFAULT NULL,
  `fecha_alta` date DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `fk_docente_docenteXinstitucion` (`docente`),
  KEY `fk_institucion_docenteXinstitucion` (`institucion`),
  CONSTRAINT `fk_docente_docenteXinstitucion` FOREIGN KEY (`docente`) REFERENCES `usuario` (`id`),
  CONSTRAINT `fk_institucion_docenteXinstitucion` FOREIGN KEY (`institucion`) REFERENCES `institucion` (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `docente_x_institucion`
--

LOCK TABLES `docente_x_institucion` WRITE;
/*!40000 ALTER TABLE `docente_x_institucion` DISABLE KEYS */;
INSERT INTO `docente_x_institucion` VALUES (1,2,1,"2013-06-25");
/*!40000 ALTER TABLE `docente_x_institucion` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `especialidad`
--

DROP TABLE IF EXISTS `especialidad`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `especialidad` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `nombre` varchar(150) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=10 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `especialidad`
--

LOCK TABLES `especialidad` WRITE;
/*!40000 ALTER TABLE `especialidad` DISABLE KEYS */;
INSERT INTO `especialidad` VALUES (1,'Discapacidad Intelectual'),(2,'Sordos e Hipoacúsicos'),(3,'Psicopedagogía'),(4,'Psicomotricidad'),(5,'Sociopedagogía');
/*!40000 ALTER TABLE `especialidad` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `historial_actividad`
--

DROP TABLE IF EXISTS `historial_actividad`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `historial_actividad` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `alumno` int(11) NOT NULL,
  `docente` int(11) NOT NULL,
  `curso` int(11) NOT NULL,
  `calificacion_docente` int(11) DEFAULT NULL,
  `calificacion_sistema` int(11) DEFAULT NULL,
  `fecha_realizacion` datetime DEFAULT NULL,
  `intentos` int(11) DEFAULT NULL,
  `actividad` int(11) DEFAULT NULL,
  `uso_ayuda_consigna` tinyint(1) DEFAULT NULL,
  `uso_ayuda_actividad` tinyint(1) DEFAULT NULL,
  `tiempo` time DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `fk_actividad_historialActividad` (`actividad`),
  KEY `fk_alumno_historialActividad` (`alumno`),
  CONSTRAINT `fk_actividad_historialActividad` FOREIGN KEY (`actividad`) REFERENCES `actividad` (`id`),
  CONSTRAINT `fk_alumno_historialActividad` FOREIGN KEY (`alumno`) REFERENCES `usuario` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `historial_actividad`
--

LOCK TABLES `historial_actividad` WRITE;
/*!40000 ALTER TABLE `historial_actividad` DISABLE KEYS */;
/*!40000 ALTER TABLE `historial_actividad` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `informacion`
--

DROP TABLE IF EXISTS `informacion`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `informacion` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `contenido` varchar(2000) DEFAULT NULL,
  `encabezado` varchar(500) DEFAULT NULL,
  `introduccion` varchar(1000) DEFAULT NULL,
  `imagen` varchar(150) DEFAULT NULL,
  `video` varchar(150) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=11 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `institucion`
--

DROP TABLE IF EXISTS `institucion`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `institucion` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `nombre` varchar(100) DEFAULT NULL,
  `telefono` mediumtext,
  `calle` varchar(50) DEFAULT NULL,
  `altura_calle` int(11) DEFAULT NULL,
  `piso` int(11) DEFAULT NULL,
  `departamento` char(1) DEFAULT NULL,
  `localidad` int(11) DEFAULT NULL,
  `administrador` int(11) DEFAULT NULL,
  `fecha_alta` date DEFAULT NULL,
  `informacion` int(11) DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `fk_localidad_institucion` (`localidad`),
  KEY `fk_administrador_institucion` (`administrador`),
  KEY `fk_informacion_institucion` (`informacion`),
  CONSTRAINT `fk_administrador_institucion` FOREIGN KEY (`administrador`) REFERENCES `usuario` (`id`),
  CONSTRAINT `fk_informacion_institucion` FOREIGN KEY (`informacion`) REFERENCES `informacion` (`id`),
  CONSTRAINT `fk_localidad_institucion` FOREIGN KEY (`localidad`) REFERENCES `localidad` (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `institucion`
--

LOCK TABLES `institucion` WRITE;
/*!40000 ALTER TABLE `institucion` DISABLE KEYS */;
INSERT INTO `institucion` VALUES (1,'Escuela Esp. Bilingüe Para Sordos (Ibis)','4332351','Santa Rosa',340,NULL,NULL,1,1,"2013-06-25",NULL);
/*!40000 ALTER TABLE `institucion` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `localidad`
--

DROP TABLE IF EXISTS `localidad`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `localidad` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `nombre` varchar(50) DEFAULT NULL,
  `provincia` int(11) DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `fk_provincia_localidad` (`provincia`),
  CONSTRAINT `fk_provincia_localidad` FOREIGN KEY (`provincia`) REFERENCES `provincia` (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `localidad`
--

LOCK TABLES `localidad` WRITE;
/*!40000 ALTER TABLE `localidad` DISABLE KEYS */;

/* Ciudades de Cordoba*/
INSERT INTO `localidad` VALUES (1,'Cordoba',1),(2,'San Francisco',1),(3,'Villa Carlos Paz',1),(4,'Villa Dolores',1),(5,'Villa Maria',1);
/* Ciudades de Piura-Peru*/
INSERT INTO `localidad` VALUES (6,'Mancora',4),(7,'Tumbes',4);
/*!40000 ALTER TABLE `localidad` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `nivel`
--

DROP TABLE IF EXISTS `nivel`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `nivel` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `nombre` varchar(50) DEFAULT NULL,
  `descripcion` varchar(150) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `nivel`
--

LOCK TABLES `nivel` WRITE;
/*!40000 ALTER TABLE `nivel` DISABLE KEYS */;
INSERT INTO `nivel` VALUES (1,'Inicial','Primer nivel');
INSERT INTO `nivel` VALUES (2,'Primario','Primer nivel');
/*!40000 ALTER TABLE `nivel` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `pais`
--

DROP TABLE IF EXISTS `pais`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `pais` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `nombre` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=8 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `pais`
--

LOCK TABLES `pais` WRITE;
/*!40000 ALTER TABLE `pais` DISABLE KEYS */;
INSERT INTO `pais` VALUES (1,'Argentina'),(2,'Brasil'),(3,'Chile'),(4,'Colombia'),(5,'Peru'),(6,'Venezuela'),(7,'Bolivia');
/*!40000 ALTER TABLE `pais` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `provincia`
--

DROP TABLE IF EXISTS `provincia`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `provincia` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `nombre` varchar(50) DEFAULT NULL,
  `pais` int(11) DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `fk_pais_provincia` (`pais`),
  CONSTRAINT `fk_pais_provincia` FOREIGN KEY (`pais`) REFERENCES `pais` (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `provincia`
--

LOCK TABLES `provincia` WRITE;
/*!40000 ALTER TABLE `provincia` DISABLE KEYS */;
INSERT INTO `provincia` VALUES (1,'Cordoba',1),(2,'Santa Rosa',3),(3,'Colon',2),(4,'Piura',5),(5,'Cusco',5);
/*!40000 ALTER TABLE `provincia` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `recurso`
--

DROP TABLE IF EXISTS `recurso`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `recurso` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `nombre` varchar(100) DEFAULT NULL,
  `ruta` varchar(200) DEFAULT NULL,
  `tipo_recurso` int(11) DEFAULT NULL,
  `privacidad` int(11) DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `fk_tipoRecurso_recurso` (`tipo_recurso`),
  CONSTRAINT `fk_tipoRecurso_recurso` FOREIGN KEY (`tipo_recurso`) REFERENCES `tipo_recurso` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `recurso`
--

LOCK TABLES `recurso` WRITE;
/*!40000 ALTER TABLE `recurso` DISABLE KEYS */;
/*!40000 ALTER TABLE `recurso` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tipo_actividad`
--

DROP TABLE IF EXISTS `tipo_actividad`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `tipo_actividad` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `nombre` varchar(100) DEFAULT NULL,
  `descripcion` varchar(200) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tipo_actividad`
--

LOCK TABLES `tipo_actividad` WRITE;
/*!40000 ALTER TABLE `tipo_actividad` DISABLE KEYS */;
INSERT INTO `tipo_actividad` VALUES (1,'Imitacion de Sonidos',"Se le hará escuchar un sonido al alumno, y éste deberá imitarlo.");
INSERT INTO `tipo_actividad` VALUES (2,'Reconocimiento de Sonidos',"Se le hará escuchar un sonido al alumno y éste deberá reconocer lo que se esta escuchando.");
INSERT INTO `tipo_actividad` VALUES (3,'Escribir lo visto en una Imagen',"Se le presentará una imagen al alumno y deberá escribir lo que ve.");
INSERT INTO `tipo_actividad` VALUES (4,'Interpretacion con señas',"El alumno interpretara un texto o imágen a travez del uso de señas.");
INSERT INTO `tipo_actividad` VALUES (5,'Lectura de señas',"Se presentará un video o una imágen con señas, y el alumno deberá escribir lo que ve.");
/*!40000 ALTER TABLE `tipo_actividad` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tipo_recurso`
--

DROP TABLE IF EXISTS `tipo_recurso`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `tipo_recurso` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `nombre` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tipo_recurso`
--

LOCK TABLES `tipo_recurso` WRITE;
/*!40000 ALTER TABLE `tipo_recurso` DISABLE KEYS */;
/*!40000 ALTER TABLE `tipo_recurso` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tipo_usuario`
--

DROP TABLE IF EXISTS `tipo_usuario`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `tipo_usuario` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `nombre` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tipo_usuario`
--

LOCK TABLES `tipo_usuario` WRITE;
/*!40000 ALTER TABLE `tipo_usuario` DISABLE KEYS */;
INSERT INTO `tipo_usuario` VALUES (1,'Administrador'),(2,'Docente'),(3,'Alumno');
/*!40000 ALTER TABLE `tipo_usuario` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `turno`
--

DROP TABLE IF EXISTS `turno`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `turno` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `nombre` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `turno`
--

LOCK TABLES `turno` WRITE;
/*!40000 ALTER TABLE `turno` DISABLE KEYS */;
INSERT INTO `turno` VALUES (1,'Mañana'),(2,'Tarde'),(3,'Noche');
/*!40000 ALTER TABLE `turno` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `estado_usuario`
--

DROP TABLE IF EXISTS `estado_usuario`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `estado_usuario`(
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `nombre` varchar(50),
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `turno`
--

LOCK TABLES `estado_usuario` WRITE;
/*!40000 ALTER TABLE `estado_usuario` DISABLE KEYS */;
INSERT INTO `estado_usuario` VALUES (1,'Esperando Confirmacion'),(2,'De alta'),(3,'De baja');
/*!40000 ALTER TABLE `estado_usuario` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `usuario`
--

DROP TABLE IF EXISTS `usuario`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `usuario` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `mail` varchar(50) DEFAULT NULL,
  `contrasena` varchar(64) DEFAULT NULL,
  `nombre` varchar(50) DEFAULT NULL,
  `apellido` varchar(50) DEFAULT NULL,
  `fecha_nacimiento` date DEFAULT NULL,
  `localidad` int(11) DEFAULT NULL,
  `fecha_alta` datetime DEFAULT NULL,
  `tipo_usuario` int(11) DEFAULT NULL,
  `especialidad` int(11) DEFAULT NULL,
  `estado_usuario` int(11) DEFAULT NULL,        
  PRIMARY KEY (`id`),
  KEY `fk_localidad_usuario` (`localidad`),
  KEY `fk_tipoUsuario_usuario` (`tipo_usuario`),
  KEY `fk_especialidad_docente` (`especialidad`),
  KEY `fk_estadoUsuario_usuario` (`estado_usuario`),
  CONSTRAINT `fk_especialidad_docente` FOREIGN KEY (`especialidad`) REFERENCES `especialidad` (`id`),
  CONSTRAINT `fk_localidad_usuario` FOREIGN KEY (`localidad`) REFERENCES `localidad` (`id`),
  CONSTRAINT `fk_tipoUsuario_usuario` FOREIGN KEY (`tipo_usuario`) REFERENCES `tipo_usuario` (`id`),
  CONSTRAINT `fk_estadoUsuario_usuario` FOREIGN KEY (`estado_usuario`) REFERENCES `estado_usuario` (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=18 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `usuario`
--

LOCK TABLES `usuario` WRITE;
/*!40000 ALTER TABLE `usuario` DISABLE KEYS */;
INSERT INTO `usuario` VALUES 
        (1,'admin@peals.com','6CA13D52CA70C883E0F0BB101E425A89E8624DE51DB2D2392593AF6A84118090','Martin','Gramatica','1988-01-11',1,'2012-01-11 00:00:00',1,NULL, NULL),
        (2,'docente@peals.com', '6CA13D52CA70C883E0F0BB101E425A89E8624DE51DB2D2392593AF6A84118090', 'gabriel', 'freisz', '1989-01-24', 1, '2013-07-06 05:46:56', 2, 1, NULL),
        (3,'alumno@peals.com', '6CA13D52CA70C883E0F0BB101E425A89E8624DE51DB2D2392593AF6A84118090', 'adrian', 'mondolo', '1988-08-11', 1, '2013-07-06 05:49:27', 3, NULL, NULL);
/*!40000 ALTER TABLE `usuario` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2013-06-20 22:18:07

create table peals.tipo_mensaje (
	id INT AUTO_INCREMENT PRIMARY KEY,
	nombre varchar(50)
);

create table peals.estado_mensaje (
	id INT AUTO_INCREMENT PRIMARY KEY,
	nombre varchar(50)
);

create table peals.adjuntos (
	id INT AUTO_INCREMENT PRIMARY KEY,
	mensaje int
);

create table peals.mensaje (
	id INT AUTO_INCREMENT PRIMARY KEY,
	fecha_mensaje DATETIME,
	titulo_mensaje varchar(150),
	mensaje varchar (2000),
	emisor_mensaje int,
	estado_mensaje int,
	tipo_mensaje int,
	referencia int
);

create table peals.mensaje_x_destinatario(
	id INT AUTO_INCREMENT PRIMARY KEY,
	mensaje int,
	destinatario int
);

alter table peals.mensaje_x_destinatario
add constraint fk_mensaje_x_destinatario_mensaje
foreign key (mensaje)
references peals.mensaje(id);

alter table peals.mensaje_x_destinatario
add constraint fk_mensaje_x_destinatario_destinatario
foreign key (destinatario)
references peals.usuario(id);

alter table peals.adjuntos
add constraint fk_adjuntos
foreign key (mensaje)
references peals.mensaje(id);

alter table peals.mensaje
add constraint fk_mensaje_tipo_mensaje
foreign key (tipo_mensaje)
references peals.tipo_mensaje(id);

alter table peals.mensaje
add constraint fk_mensaje_estado_mensaje
foreign key (estado_mensaje)
references peals.estado_mensaje(id);
