SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0;
SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0;
SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='TRADITIONAL,ALLOW_INVALID_DATES';

DROP SCHEMA IF EXISTS `peals` ;
CREATE SCHEMA IF NOT EXISTS `peals` DEFAULT CHARACTER SET utf8 ;
USE `peals` ;

-- -----------------------------------------------------
-- Table `peals`.`especialidad`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `peals`.`especialidad` ;

CREATE  TABLE IF NOT EXISTS `peals`.`especialidad` (
  `id` INT(11) NOT NULL AUTO_INCREMENT ,
  `nombre` VARCHAR(150) NULL DEFAULT NULL ,
  PRIMARY KEY (`id`) )
ENGINE = InnoDB
AUTO_INCREMENT = 10
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Table `peals`.`estado_usuario`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `peals`.`estado_usuario` ;

CREATE  TABLE IF NOT EXISTS `peals`.`estado_usuario` (
  `id` INT(11) NOT NULL AUTO_INCREMENT ,
  `nombre` VARCHAR(50) NULL DEFAULT NULL ,
  PRIMARY KEY (`id`) )
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Table `peals`.`pais`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `peals`.`pais` ;

CREATE  TABLE IF NOT EXISTS `peals`.`pais` (
  `id` INT(11) NOT NULL AUTO_INCREMENT ,
  `nombre` VARCHAR(50) NULL DEFAULT NULL ,
  PRIMARY KEY (`id`) )
ENGINE = InnoDB
AUTO_INCREMENT = 8
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Table `peals`.`provincia`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `peals`.`provincia` ;

CREATE  TABLE IF NOT EXISTS `peals`.`provincia` (
  `id` INT(11) NOT NULL AUTO_INCREMENT ,
  `nombre` VARCHAR(50) NULL DEFAULT NULL ,
  `pais` INT(11) NULL DEFAULT NULL ,
  PRIMARY KEY (`id`) ,
  INDEX `fk_pais_provincia` (`pais` ASC) ,
  CONSTRAINT `fk_pais_provincia`
    FOREIGN KEY (`pais` )
    REFERENCES `peals`.`pais` (`id` ))
ENGINE = InnoDB
AUTO_INCREMENT = 6
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Table `peals`.`localidad`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `peals`.`localidad` ;

CREATE  TABLE IF NOT EXISTS `peals`.`localidad` (
  `id` INT(11) NOT NULL AUTO_INCREMENT ,
  `nombre` VARCHAR(50) NULL DEFAULT NULL ,
  `provincia` INT(11) NULL DEFAULT NULL ,
  PRIMARY KEY (`id`) ,
  INDEX `fk_provincia_localidad` (`provincia` ASC) ,
  CONSTRAINT `fk_provincia_localidad`
    FOREIGN KEY (`provincia` )
    REFERENCES `peals`.`provincia` (`id` ))
ENGINE = InnoDB
AUTO_INCREMENT = 4
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Table `peals`.`tipo_usuario`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `peals`.`tipo_usuario` ;

CREATE  TABLE IF NOT EXISTS `peals`.`tipo_usuario` (
  `id` INT(11) NOT NULL AUTO_INCREMENT ,
  `nombre` VARCHAR(50) NULL DEFAULT NULL ,
  PRIMARY KEY (`id`) )
ENGINE = InnoDB
AUTO_INCREMENT = 4
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Table `peals`.`usuario`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `peals`.`usuario` ;

CREATE  TABLE IF NOT EXISTS `peals`.`usuario` (
  `id` INT(11) NOT NULL AUTO_INCREMENT ,
  `mail` VARCHAR(50) NULL DEFAULT NULL ,
  `contrasena` VARCHAR(64) NULL DEFAULT NULL ,
  `nombre` VARCHAR(50) NULL DEFAULT NULL ,
  `apellido` VARCHAR(50) NULL DEFAULT NULL ,
  `fecha_nacimiento` DATE NULL DEFAULT NULL ,
  `localidad` INT(11) NULL DEFAULT NULL ,
  `fecha_alta` DATETIME NULL DEFAULT NULL ,
  `fecha_baja` DATETIME NULL DEFAULT NULL ,
  `tipo_usuario` INT(11) NULL DEFAULT NULL ,
  `especialidad` INT(11) NULL DEFAULT NULL ,
  `estado_usuario` INT(11) NULL DEFAULT NULL ,
  PRIMARY KEY (`id`) ,
  INDEX `fk_localidad_usuario` (`localidad` ASC) ,
  INDEX `fk_tipoUsuario_usuario` (`tipo_usuario` ASC) ,
  INDEX `fk_especialidad_docente` (`especialidad` ASC) ,
  INDEX `fk_estadoUsuario_usuario` (`estado_usuario` ASC) ,
  CONSTRAINT `fk_especialidad_docente`
    FOREIGN KEY (`especialidad` )
    REFERENCES `peals`.`especialidad` (`id` ),
  CONSTRAINT `fk_estadoUsuario_usuario`
    FOREIGN KEY (`estado_usuario` )
    REFERENCES `peals`.`estado_usuario` (`id` ),
  CONSTRAINT `fk_localidad_usuario`
    FOREIGN KEY (`localidad` )
    REFERENCES `peals`.`localidad` (`id` ),
  CONSTRAINT `fk_tipoUsuario_usuario`
    FOREIGN KEY (`tipo_usuario` )
    REFERENCES `peals`.`tipo_usuario` (`id` ))
ENGINE = InnoDB
AUTO_INCREMENT = 18
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Table `peals`.`tipo_recurso`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `peals`.`tipo_recurso` ;

CREATE  TABLE IF NOT EXISTS `peals`.`tipo_recurso` (
  `id` INT(11) NOT NULL AUTO_INCREMENT ,
  `nombre` VARCHAR(50) NULL DEFAULT NULL ,
  PRIMARY KEY (`id`) )
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Table `peals`.`recurso`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `peals`.`recurso` ;

CREATE  TABLE IF NOT EXISTS `peals`.`recurso` (
  `id` INT(11) NOT NULL AUTO_INCREMENT ,
  `nombre` VARCHAR(100) NULL DEFAULT NULL ,
  `ruta` VARCHAR(200) NULL DEFAULT NULL ,
  `tipo_recurso` INT(11) NULL DEFAULT NULL ,
  `subido_por` INT(11) NULL DEFAULT NULL ,
  `estado` INT(11) NULL DEFAULT NULL ,
  PRIMARY KEY (`id`) ,
  INDEX `fk_tipoRecurso_recurso` (`tipo_recurso` ASC) ,
  INDEX `fk_usuario_recurso` (`subido_por` ASC) ,
  CONSTRAINT `fk_tipoRecurso_recurso`
    FOREIGN KEY (`tipo_recurso` )
    REFERENCES `peals`.`tipo_recurso` (`id` ),
  CONSTRAINT `fk_usuario_recurso`
    FOREIGN KEY (`subido_por` )
    REFERENCES `peals`.`usuario` (`id` ))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Table `peals`.`intervalo`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `peals`.`intervalo` ;

CREATE  TABLE IF NOT EXISTS `peals`.`intervalo` (
  `id` INT(11) NOT NULL AUTO_INCREMENT ,
  `desde` INT(11) NULL DEFAULT NULL ,
  `hasta` INT(11) NULL DEFAULT NULL ,
  `recurso` INT(11) NULL DEFAULT NULL ,
  PRIMARY KEY (`id`) ,
  INDEX `fk_intervalo_recurso` (`recurso` ASC) ,
  CONSTRAINT `fk_intervalo_recurso`
    FOREIGN KEY (`recurso` )
    REFERENCES `peals`.`recurso` (`id` ))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Table `peals`.`criterio_evaluacion`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `peals`.`criterio_evaluacion` ;

CREATE  TABLE IF NOT EXISTS `peals`.`criterio_evaluacion` (
  `id` INT(11) NOT NULL AUTO_INCREMENT ,
  `docente` INT(11) NULL DEFAULT NULL ,
  `intervalo` INT(11) NULL DEFAULT NULL ,
  PRIMARY KEY (`id`) ,
  INDEX `fk_criterio_intervalo` (`intervalo` ASC) ,
  CONSTRAINT `fk_criterio_intervalo`
    FOREIGN KEY (`intervalo` )
    REFERENCES `peals`.`intervalo` (`id` ))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Table `peals`.`actividad`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `peals`.`actividad` ;

CREATE  TABLE IF NOT EXISTS `peals`.`actividad` (
  `id` INT(11) NOT NULL AUTO_INCREMENT ,
  `nombre` VARCHAR(150) NULL DEFAULT NULL ,
  `fecha_alta` DATE NULL DEFAULT NULL ,
  `es_publica` INT(11) NULL DEFAULT NULL ,
  `texto_solucion` VARCHAR(100) NULL DEFAULT NULL ,
  `deletreo` VARCHAR(50) NULL DEFAULT NULL ,
  `imagen_correcta` INT(11) NULL DEFAULT NULL ,
  `docente` INT(11) NULL DEFAULT NULL ,
  `descripcion` VARCHAR(1000) NULL DEFAULT NULL ,
  `estado` INT(11) NULL DEFAULT NULL ,
  `criterio` INT(11) NULL DEFAULT NULL ,
  PRIMARY KEY (`id`) ,
  INDEX `fk_docente_actividad` (`docente` ASC) ,
  INDEX `fk_actividad_criterio` (`criterio` ASC) ,
  CONSTRAINT `fk_docente_actividad`
    FOREIGN KEY (`docente` )
    REFERENCES `peals`.`usuario` (`id` ),
  CONSTRAINT `fk_actividad_criterio`
    FOREIGN KEY (`criterio` )
    REFERENCES `peals`.`criterio_evaluacion` (`id` ))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Table `peals`.`informacion`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `peals`.`informacion` ;

CREATE  TABLE IF NOT EXISTS `peals`.`informacion` (
  `id` INT(11) NOT NULL AUTO_INCREMENT ,
  `contenido` VARCHAR(2000) NULL DEFAULT NULL ,
  `encabezado` VARCHAR(500) NULL DEFAULT NULL ,
  `introduccion` VARCHAR(1000) NULL DEFAULT NULL ,
  `imagen` VARCHAR(150) NULL DEFAULT NULL ,
  `video` VARCHAR(150) NULL DEFAULT NULL ,
  PRIMARY KEY (`id`) )
ENGINE = InnoDB
AUTO_INCREMENT = 11
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Table `peals`.`institucion`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `peals`.`institucion` ;

CREATE  TABLE IF NOT EXISTS `peals`.`institucion` (
  `id` INT(11) NOT NULL AUTO_INCREMENT ,
  `nombre` VARCHAR(100) NULL DEFAULT NULL ,
  `telefono` MEDIUMTEXT NULL DEFAULT NULL ,
  `calle` VARCHAR(50) NULL DEFAULT NULL ,
  `altura_calle` INT(11) NULL DEFAULT NULL ,
  `piso` INT(11) NULL DEFAULT NULL ,
  `departamento` CHAR(1) NULL DEFAULT NULL ,
  `localidad` INT(11) NULL DEFAULT NULL ,
  `administrador` INT(11) NULL DEFAULT NULL ,
  `fecha_alta` DATE NULL DEFAULT NULL ,
  `informacion` INT(11) NULL DEFAULT NULL ,
  PRIMARY KEY (`id`) ,
  INDEX `fk_localidad_institucion` (`localidad` ASC) ,
  INDEX `fk_administrador_institucion` (`administrador` ASC) ,
  INDEX `fk_informacion_institucion` (`informacion` ASC) ,
  CONSTRAINT `fk_administrador_institucion`
    FOREIGN KEY (`administrador` )
    REFERENCES `peals`.`usuario` (`id` ),
  CONSTRAINT `fk_informacion_institucion`
    FOREIGN KEY (`informacion` )
    REFERENCES `peals`.`informacion` (`id` ),
  CONSTRAINT `fk_localidad_institucion`
    FOREIGN KEY (`localidad` )
    REFERENCES `peals`.`localidad` (`id` ))
ENGINE = InnoDB
AUTO_INCREMENT = 7
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Table `peals`.`nivel`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `peals`.`nivel` ;

CREATE  TABLE IF NOT EXISTS `peals`.`nivel` (
  `id` INT(11) NOT NULL AUTO_INCREMENT ,
  `nombre` VARCHAR(50) NULL DEFAULT NULL ,
  `descripcion` VARCHAR(150) NULL DEFAULT NULL ,
  PRIMARY KEY (`id`) )
ENGINE = InnoDB
AUTO_INCREMENT = 2
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Table `peals`.`turno`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `peals`.`turno` ;

CREATE  TABLE IF NOT EXISTS `peals`.`turno` (
  `id` INT(11) NOT NULL AUTO_INCREMENT ,
  `nombre` VARCHAR(50) NULL DEFAULT NULL ,
  PRIMARY KEY (`id`) )
ENGINE = InnoDB
AUTO_INCREMENT = 4
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Table `peals`.`curso`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `peals`.`curso` ;

CREATE  TABLE IF NOT EXISTS `peals`.`curso` (
  `id` INT(11) NOT NULL AUTO_INCREMENT ,
  `turno` INT(11) NULL DEFAULT NULL ,
  `nivel` INT(11) NULL DEFAULT NULL ,
  `ano` INT(11) NULL DEFAULT NULL ,
  `division` VARCHAR(30) NULL DEFAULT NULL ,
  `docente` INT(11) NULL DEFAULT NULL ,
  `institucion` INT(11) NULL DEFAULT NULL ,
  `es_publico` TINYINT(1) NULL DEFAULT NULL ,
  `nombre` VARCHAR(45) NULL DEFAULT NULL ,
  `descripcion` VARCHAR(200) NULL DEFAULT NULL ,
  `estado` INT(11) NULL DEFAULT NULL ,
  PRIMARY KEY (`id`) ,
  INDEX `fk_turno_curso` (`turno` ASC) ,
  INDEX `fk_nivel_curso` (`nivel` ASC) ,
  INDEX `fk_docente_curso` (`docente` ASC) ,
  INDEX `fk_institucion_curso` (`institucion` ASC) ,
  CONSTRAINT `fk_docente_curso`
    FOREIGN KEY (`docente` )
    REFERENCES `peals`.`usuario` (`id` ),
  CONSTRAINT `fk_institucion_curso`
    FOREIGN KEY (`institucion` )
    REFERENCES `peals`.`institucion` (`id` ),
  CONSTRAINT `fk_nivel_curso`
    FOREIGN KEY (`nivel` )
    REFERENCES `peals`.`nivel` (`id` ),
  CONSTRAINT `fk_turno_curso`
    FOREIGN KEY (`turno` )
    REFERENCES `peals`.`turno` (`id` ))
ENGINE = InnoDB
AUTO_INCREMENT = 12
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Table `peals`.`actividad_x_curso`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `peals`.`actividad_x_curso` ;

CREATE  TABLE IF NOT EXISTS `peals`.`actividad_x_curso` (
  `id` INT(11) NOT NULL AUTO_INCREMENT ,
  `actividad` INT(11) NULL DEFAULT NULL ,
  `curso` INT(11) NULL DEFAULT NULL ,
  `fecha_apertura` DATETIME NULL DEFAULT NULL ,
  PRIMARY KEY (`id`) ,
  INDEX `fk_actividad_actividadXcurso` (`actividad` ASC) ,
  INDEX `fk_curso_actividadXcurso` (`curso` ASC) ,
  CONSTRAINT `fk_actividad_actividadXcurso`
    FOREIGN KEY (`actividad` )
    REFERENCES `peals`.`actividad` (`id` ),
  CONSTRAINT `fk_curso_actividadXcurso`
    FOREIGN KEY (`curso` )
    REFERENCES `peals`.`curso` (`id` ))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Table `peals`.`actividad_x_recurso`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `peals`.`actividad_x_recurso` ;

CREATE  TABLE IF NOT EXISTS `peals`.`actividad_x_recurso` (
  `id` INT(11) NOT NULL AUTO_INCREMENT ,
  `actividad` INT(11) NULL DEFAULT NULL ,
  `recurso` INT(11) NULL DEFAULT NULL ,
  `pos_top` VARCHAR(6) NULL DEFAULT NULL ,
  `pos_left` VARCHAR(6) NULL DEFAULT NULL ,
  PRIMARY KEY (`id`) ,
  INDEX `fk_actividad_actividadXrecurso` (`actividad` ASC) ,
  INDEX `fk_recurso_actividadXrecurso` (`recurso` ASC) ,
  CONSTRAINT `fk_actividad_actividadXrecurso`
    FOREIGN KEY (`actividad` )
    REFERENCES `peals`.`actividad` (`id` ),
  CONSTRAINT `fk_recurso_actividadXrecurso`
    FOREIGN KEY (`recurso` )
    REFERENCES `peals`.`recurso` (`id` ))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Table `peals`.`estado_mensaje`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `peals`.`estado_mensaje` ;

CREATE  TABLE IF NOT EXISTS `peals`.`estado_mensaje` (
  `id` INT(11) NOT NULL AUTO_INCREMENT ,
  `nombre` VARCHAR(50) NULL DEFAULT NULL ,
  PRIMARY KEY (`id`) )
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Table `peals`.`tipo_mensaje`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `peals`.`tipo_mensaje` ;

CREATE  TABLE IF NOT EXISTS `peals`.`tipo_mensaje` (
  `id` INT(11) NOT NULL AUTO_INCREMENT ,
  `nombre` VARCHAR(50) NULL DEFAULT NULL ,
  PRIMARY KEY (`id`) )
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Table `peals`.`mensaje`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `peals`.`mensaje` ;

CREATE  TABLE IF NOT EXISTS `peals`.`mensaje` (
  `id` INT(11) NOT NULL AUTO_INCREMENT ,
  `fecha_mensaje` DATETIME NULL DEFAULT NULL ,
  `titulo_mensaje` VARCHAR(150) NULL DEFAULT NULL ,
  `mensaje` VARCHAR(2000) NULL DEFAULT NULL ,
  `emisor_mensaje` INT(11) NULL DEFAULT NULL ,
  `estado_mensaje` INT(11) NULL DEFAULT NULL ,
  `tipo_mensaje` INT(11) NULL DEFAULT NULL ,
  `referencia` INT(11) NULL DEFAULT NULL ,
  `tipo_solicitud` INT(11) NULL DEFAULT NULL ,
  PRIMARY KEY (`id`) ,
  INDEX `fk_mensaje_tipo_mensaje` (`tipo_mensaje` ASC) ,
  INDEX `fk_mensaje_estado_mensaje` (`estado_mensaje` ASC) ,
  CONSTRAINT `fk_mensaje_estado_mensaje`
    FOREIGN KEY (`estado_mensaje` )
    REFERENCES `peals`.`estado_mensaje` (`id` ),
  CONSTRAINT `fk_mensaje_tipo_mensaje`
    FOREIGN KEY (`tipo_mensaje` )
    REFERENCES `peals`.`tipo_mensaje` (`id` ))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Table `peals`.`adjuntos`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `peals`.`adjuntos` ;

CREATE  TABLE IF NOT EXISTS `peals`.`adjuntos` (
  `id` INT(11) NOT NULL AUTO_INCREMENT ,
  `mensaje` INT(11) NULL DEFAULT NULL ,
  PRIMARY KEY (`id`) ,
  INDEX `fk_adjuntos` (`mensaje` ASC) ,
  CONSTRAINT `fk_adjuntos`
    FOREIGN KEY (`mensaje` )
    REFERENCES `peals`.`mensaje` (`id` ))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Table `peals`.`alumno_x_curso`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `peals`.`alumno_x_curso` ;

CREATE  TABLE IF NOT EXISTS `peals`.`alumno_x_curso` (
  `id` INT(11) NOT NULL AUTO_INCREMENT ,
  `alumno` INT(11) NULL DEFAULT NULL ,
  `curso` INT(11) NULL DEFAULT NULL ,
  `fecha_asignacion` DATE NULL DEFAULT NULL ,
  PRIMARY KEY (`id`) ,
  INDEX `fk_alumno_alumnoXcurso` (`alumno` ASC) ,
  INDEX `fk_curso_alumnoXcurso` (`curso` ASC) ,
  CONSTRAINT `fk_alumno_alumnoXcurso`
    FOREIGN KEY (`alumno` )
    REFERENCES `peals`.`usuario` (`id` ),
  CONSTRAINT `fk_curso_alumnoXcurso`
    FOREIGN KEY (`curso` )
    REFERENCES `peals`.`curso` (`id` ))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Table `peals`.`alumno_x_institucion`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `peals`.`alumno_x_institucion` ;

CREATE  TABLE IF NOT EXISTS `peals`.`alumno_x_institucion` (
  `id` INT(11) NOT NULL AUTO_INCREMENT ,
  `alumno` INT(11) NULL DEFAULT NULL ,
  `institucion` INT(11) NULL DEFAULT NULL ,
  `fecha_alta` DATE NULL DEFAULT NULL ,
  PRIMARY KEY (`id`) ,
  INDEX `fk_alumno_alumnoXinstitucion` (`alumno` ASC) ,
  INDEX `fk_institucion_alumnoXinstitucion` (`institucion` ASC) ,
  CONSTRAINT `fk_alumno_alumnoXinstitucion`
    FOREIGN KEY (`alumno` )
    REFERENCES `peals`.`usuario` (`id` ),
  CONSTRAINT `fk_institucion_alumnoXinstitucion`
    FOREIGN KEY (`institucion` )
    REFERENCES `peals`.`institucion` (`id` ))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Table `peals`.`diac`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `peals`.`diac` ;

CREATE  TABLE IF NOT EXISTS `peals`.`diac` (
  `id` INT(11) NOT NULL AUTO_INCREMENT ,
  `institucion` INT(11) NULL DEFAULT NULL ,
  `activo` INT(11) NULL DEFAULT NULL ,
  PRIMARY KEY (`id`) ,
  INDEX `fk_diac_institucion` (`institucion` ASC) ,
  CONSTRAINT `fk_diac_institucion`
    FOREIGN KEY (`institucion` )
    REFERENCES `peals`.`institucion` (`id` ))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Table `peals`.`docente_x_institucion`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `peals`.`docente_x_institucion` ;

CREATE  TABLE IF NOT EXISTS `peals`.`docente_x_institucion` (
  `id` INT(11) NOT NULL AUTO_INCREMENT ,
  `docente` INT(11) NULL DEFAULT NULL ,
  `institucion` INT(11) NULL DEFAULT NULL ,
  `fecha_alta` DATE NULL DEFAULT NULL ,
  PRIMARY KEY (`id`) ,
  INDEX `fk_docente_docenteXinstitucion` (`docente` ASC) ,
  INDEX `fk_institucion_docenteXinstitucion` (`institucion` ASC) ,
  CONSTRAINT `fk_docente_docenteXinstitucion`
    FOREIGN KEY (`docente` )
    REFERENCES `peals`.`usuario` (`id` ),
  CONSTRAINT `fk_institucion_docenteXinstitucion`
    FOREIGN KEY (`institucion` )
    REFERENCES `peals`.`institucion` (`id` ))
ENGINE = InnoDB
AUTO_INCREMENT = 3
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Table `peals`.`historial_actividad`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `peals`.`historial_actividad` ;

CREATE  TABLE IF NOT EXISTS `peals`.`historial_actividad` (
  `id` INT(11) NOT NULL AUTO_INCREMENT ,
  `alumno` INT(11) NOT NULL ,
  `docente` INT(11) NOT NULL ,
  `curso` INT(11) NOT NULL ,
  `institucion` INT(11) NULL DEFAULT NULL ,
  `calificacion_docente` INT(11) NULL DEFAULT NULL ,
  `calificacion_sistema` INT(11) NULL DEFAULT NULL ,
  `fecha_realizacion` DATETIME NULL DEFAULT NULL ,
  `intentos` INT(11) NULL DEFAULT NULL ,
  `actividad` INT(11) NULL DEFAULT NULL ,
  `uso_ayuda_consigna` TINYINT(1) NULL DEFAULT NULL ,
  `uso_ayuda_actividad` TINYINT(1) NULL DEFAULT NULL ,
  `tiempo` TIME NULL DEFAULT NULL ,
  PRIMARY KEY (`id`) ,
  INDEX `fk_actividad_historialActividad` (`actividad` ASC) ,
  INDEX `fk_alumno_historialActividad` (`alumno` ASC) ,
  INDEX `fk_historial_actividad_institucion` (`institucion` ASC) ,
  CONSTRAINT `fk_actividad_historialActividad`
    FOREIGN KEY (`actividad` )
    REFERENCES `peals`.`actividad` (`id` ),
  CONSTRAINT `fk_alumno_historialActividad`
    FOREIGN KEY (`alumno` )
    REFERENCES `peals`.`usuario` (`id` ),
  CONSTRAINT `fk_historial_actividad_institucion`
    FOREIGN KEY (`institucion` )
    REFERENCES `peals`.`institucion` (`id` ))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Table `peals`.`seguimiento`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `peals`.`seguimiento` ;

CREATE  TABLE IF NOT EXISTS `peals`.`seguimiento` (
  `id` INT(11) NOT NULL AUTO_INCREMENT ,
  `curso` INT(11) NULL DEFAULT NULL ,
  `activo` INT(11) NULL DEFAULT NULL ,
  PRIMARY KEY (`id`) ,
  INDEX `fk_seguimiento_curso` (`curso` ASC) ,
  CONSTRAINT `fk_seguimiento_curso`
    FOREIGN KEY (`curso` )
    REFERENCES `peals`.`curso` (`id` ))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Table `peals`.`item`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `peals`.`item` ;

CREATE  TABLE IF NOT EXISTS `peals`.`item` (
  `id` INT(11) NOT NULL AUTO_INCREMENT ,
  `descripcion` VARCHAR(200) NULL DEFAULT NULL ,
  `grupo` VARCHAR(200) NULL DEFAULT NULL ,
  `ordenGrupo` INT(11) NULL DEFAULT NULL ,
  `ordenItem` INT(11) NULL DEFAULT NULL ,
  `diac` INT(11) NULL DEFAULT NULL ,
  `seguimiento` INT(11) NULL DEFAULT NULL ,
  `tipoItem` INT(11) NULL DEFAULT NULL ,
  `estado` INT(11) NULL DEFAULT NULL ,
  `ayuda` VARCHAR(2000) NULL DEFAULT NULL ,
  PRIMARY KEY (`id`) ,
  INDEX `FK_ITEM_DIAC` (`diac` ASC) ,
  INDEX `FK_ITEM_SEGUIMIENTO` (`seguimiento` ASC) ,
  CONSTRAINT `FK_ITEM_DIAC`
    FOREIGN KEY (`diac` )
    REFERENCES `peals`.`diac` (`id` ),
  CONSTRAINT `FK_ITEM_SEGUIMIENTO`
    FOREIGN KEY (`seguimiento` )
    REFERENCES `peals`.`seguimiento` (`id` ))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Table `peals`.`llenadoseguimiento`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `peals`.`llenadoseguimiento` ;

CREATE  TABLE IF NOT EXISTS `peals`.`llenadoseguimiento` (
  `id` INT(11) NOT NULL AUTO_INCREMENT ,
  `fecha` DATE NULL DEFAULT NULL ,
  `docente` INT(11) NULL DEFAULT NULL ,
  `alumno` INT(11) NULL DEFAULT NULL ,
  `curso` INT(11) NULL DEFAULT NULL ,
  `diac` INT(11) NULL DEFAULT NULL ,
  `seguimiento` INT(11) NULL DEFAULT NULL ,
  PRIMARY KEY (`id`) ,
  INDEX `FK_LLENADO_DOCENTE` (`docente` ASC) ,
  INDEX `FK_LLENADO_ALUMNO` (`alumno` ASC) ,
  INDEX `FK_LLENADO_DIAC` (`diac` ASC) ,
  INDEX `FK_LLENADO_SEGUIMIENTO` (`seguimiento` ASC) ,
  INDEX `FK_LLENADO_CURSO` (`curso` ASC) ,
  CONSTRAINT `FK_LLENADO_ALUMNO`
    FOREIGN KEY (`alumno` )
    REFERENCES `peals`.`usuario` (`id` ),
  CONSTRAINT `FK_LLENADO_DOCENTE`
    FOREIGN KEY (`docente` )
    REFERENCES `peals`.`usuario` (`id` ),
  CONSTRAINT `FK_LLENADO_DIAC`
    FOREIGN KEY (`diac` )
    REFERENCES `peals`.`diac` (`id` )
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `FK_LLENADO_SEGUIMIENTO`
    FOREIGN KEY (`seguimiento` )
    REFERENCES `peals`.`seguimiento` (`id` )
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `FK_LLENADO_CURSO`
    FOREIGN KEY (`curso` )
    REFERENCES `peals`.`curso` (`id` )
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Table `peals`.`opcion`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `peals`.`opcion` ;

CREATE  TABLE IF NOT EXISTS `peals`.`opcion` (
  `id` INT(11) NOT NULL AUTO_INCREMENT ,
  `item` INT(11) NULL DEFAULT NULL ,
  `descripcion` VARCHAR(200) NULL DEFAULT NULL ,
  PRIMARY KEY (`id`) ,
  INDEX `FK_OPCION_ITEM` (`item` ASC) ,
  CONSTRAINT `FK_OPCION_ITEM`
    FOREIGN KEY (`item` )
    REFERENCES `peals`.`item` (`id` ))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Table `peals`.`llenadoseguimientodetalle`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `peals`.`llenadoseguimientodetalle` ;

CREATE  TABLE IF NOT EXISTS `peals`.`llenadoseguimientodetalle` (
  `id` INT(11) NOT NULL AUTO_INCREMENT ,
  `llenadoseguimiento` INT(11) NULL DEFAULT NULL ,
  `item` INT(11) NULL DEFAULT NULL ,
  `adjunto` varchar(200) NULL DEFAULT NULL ,
  `opcion` INT(11) NULL DEFAULT NULL ,
  `respuesta` VARCHAR(1000) NULL DEFAULT NULL ,
  PRIMARY KEY (`id`) ,
  INDEX `FK_LS_ITEM` (`item` ASC) ,
  INDEX `FK_LS_ADJUNTO` (`adjunto` ASC) ,
  INDEX `FK_LS_OPCION` (`opcion` ASC) ,
  INDEX `FK_LS_LLENADOSEGUIMIENTO` (`llenadoseguimiento` ASC) ,
  CONSTRAINT `FK_LS_ITEM`
    FOREIGN KEY (`item` )
    REFERENCES `peals`.`item` (`id` ),
  CONSTRAINT `FK_LS_OPCION`
    FOREIGN KEY (`opcion` )
    REFERENCES `peals`.`opcion` (`id` ),
  CONSTRAINT `FK_LS_LLENADOSEGUIMIENTO`
    FOREIGN KEY (`llenadoseguimiento` )
    REFERENCES `peals`.`llenadoseguimiento` (`id` ))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Table `peals`.`mensaje_x_destinatario`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `peals`.`mensaje_x_destinatario` ;

CREATE  TABLE IF NOT EXISTS `peals`.`mensaje_x_destinatario` (
  `id` INT(11) NOT NULL AUTO_INCREMENT ,
  `mensaje` INT(11) NULL DEFAULT NULL ,
  `destinatario` INT(11) NULL DEFAULT NULL ,
  PRIMARY KEY (`id`) ,
  INDEX `fk_mensaje_x_destinatario_mensaje` (`mensaje` ASC) ,
  INDEX `fk_mensaje_x_destinatario_destinatario` (`destinatario` ASC) ,
  CONSTRAINT `fk_mensaje_x_destinatario_mensaje`
    FOREIGN KEY (`mensaje` )
    REFERENCES `peals`.`mensaje` (`id` ),
  CONSTRAINT `fk_mensaje_x_destinatario_destinatario`
    FOREIGN KEY (`destinatario` )
    REFERENCES `peals`.`usuario` (`id` ))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Table `peals`.`recurso_compartido`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `peals`.`recurso_compartido` ;

CREATE  TABLE IF NOT EXISTS `peals`.`recurso_compartido` (
  `id` INT(11) NOT NULL AUTO_INCREMENT ,
  `recurso` INT(11) NULL DEFAULT NULL ,
  `institucion` INT(11) NULL DEFAULT NULL ,
  PRIMARY KEY (`id`) ,
  INDEX `fk_recurso_rc` (`recurso` ASC) ,
  INDEX `fk_institucion_rc` (`institucion` ASC) ,
  CONSTRAINT `fk_recurso_rc`
    FOREIGN KEY (`recurso` )
    REFERENCES `peals`.`recurso` (`id` ),
  CONSTRAINT `fk_institucion_rc`
    FOREIGN KEY (`institucion` )
    REFERENCES `peals`.`institucion` (`id` ))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Table `peals`.`texto`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `peals`.`texto` ;

CREATE  TABLE IF NOT EXISTS `peals`.`texto` (
  `id` INT(11) NOT NULL AUTO_INCREMENT ,
  `texto` VARCHAR(200) NULL DEFAULT NULL ,
  `actividad` INT(11) NULL DEFAULT NULL ,
  `pos_top` VARCHAR(6) NULL DEFAULT NULL ,
  `pos_left` VARCHAR(6) NULL DEFAULT NULL ,
  PRIMARY KEY (`id`) ,
  INDEX `fk_actividad_text` (`actividad` ASC) ,
  CONSTRAINT `fk_actividad_text`
    FOREIGN KEY (`actividad` )
    REFERENCES `peals`.`actividad` (`id` ))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;

USE `peals` ;


SET SQL_MODE=@OLD_SQL_MODE;
SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS;
SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS;
