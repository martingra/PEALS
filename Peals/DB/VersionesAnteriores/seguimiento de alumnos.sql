CREATE TABLE peals.diac (
   id INT AUTO_INCREMENT PRIMARY KEY,
   institucion INT,
   activo INT,
  CONSTRAINT fk_diac_institucion FOREIGN KEY (institucion) REFERENCES peals.institucion (id) ON UPDATE RESTRICT ON DELETE RESTRICT
);


CREATE TABLE peals.seguimiento (
   id INT AUTO_INCREMENT PRIMARY KEY,
   curso INT,
   activo INT,
  CONSTRAINT fk_seguimiento_curso FOREIGN KEY (curso) REFERENCES peals.curso (id) ON UPDATE RESTRICT ON DELETE RESTRICT
);

CREATE TABLE peals.opcion (
   id INT AUTO_INCREMENT PRIMARY KEY,
   item INT,
   descripcion VARCHAR(200),
  CONSTRAINT FK_OPCION_ITEM FOREIGN KEY (item) REFERENCES peals.item (id) ON UPDATE RESTRICT ON DELETE RESTRICT
  );

CREATE TABLE peals.item (
   id INT AUTO_INCREMENT PRIMARY KEY,
   descripcion VARCHAR(200),
   grupo VARCHAR(200),
   ordenGrupo INT,
   ordenItem INT,
   diac INT,
   seguimiento INT,
   tipoItem INT,
   estado INT,
   ayuda VARCHAR(2000),
   CONSTRAINT FK_ITEM_DIAC FOREIGN KEY (diac) REFERENCES peals.diac (id) ON UPDATE RESTRICT ON DELETE RESTRICT,
   CONSTRAINT FK_ITEM_SEGUIMIENTO FOREIGN KEY (seguimiento) REFERENCES peals.seguimiento (id) ON UPDATE RESTRICT ON DELETE RESTRICT
);

CREATE TABLE peals.llenadoSeguimiento (
   id INT AUTO_INCREMENT PRIMARY KEY,
   item INT,
   adjunto INT,
   opcion INT,
   respuesta VARCHAR(2000),
   fecha DATE,
   docente INT,
   alumno INT,
  CONSTRAINT FK_LLENADO_ADJUNTO FOREIGN KEY (adjunto) REFERENCES peals.adjuntos (id) ON UPDATE RESTRICT ON DELETE RESTRICT,
  CONSTRAINT FK_LLENADO_OPCION FOREIGN KEY (opcion) REFERENCES peals.opcion (id) ON UPDATE RESTRICT ON DELETE RESTRICT,
  CONSTRAINT FK_LLENADO_DOCENTE FOREIGN KEY (docente) REFERENCES peals.usuario (id) ON UPDATE RESTRICT ON DELETE RESTRICT,
  CONSTRAINT FK_LLENADO_ALUMNO FOREIGN KEY (alumno) REFERENCES peals.usuario (id) ON UPDATE RESTRICT ON DELETE RESTRICT
);


ALTER TABLE llenadoseguimiento
 DROP item,
 DROP adjunto,
 DROP opcion,
 DROP respuesta,
 ADD diac INT AFTER curso,
 ADD seguimiento INT;
ALTER TABLE llenadoseguimiento
 ADD CONSTRAINT FK_LLENADO_DIAC FOREIGN KEY (diac) REFERENCES diac (id) ON UPDATE RESTRICT ON DELETE RESTRICT,
 ADD CONSTRAINT FK_LLENADO_SEGUIMIENTO FOREIGN KEY (seguimiento) REFERENCES seguimiento (id) ON UPDATE RESTRICT ON DELETE RESTRICT,
 ADD CONSTRAINT FK_LLENADO_ALUMNO FOREIGN KEY (alumno) REFERENCES usuario (id) ON UPDATE RESTRICT ON DELETE RESTRICT,
 ADD CONSTRAINT FK_LLENADO_DOCENTE FOREIGN KEY (docente) REFERENCES usuario (id) ON UPDATE RESTRICT ON DELETE RESTRICT,
 ADD CONSTRAINT FK_LLENADO_CURSO FOREIGN KEY (curso) REFERENCES curso (id) ON UPDATE RESTRICT ON DELETE RESTRICT;

 
 
 
 CREATE TABLE llenadoseguimientodetalle (
   id INT AUTO_INCREMENT PRIMARY KEY,
   llenadoseguimiento INT,
   item INT,
   adjunto INT,
   opcion INT,
   respuesta VARCHAR(1000),
  CONSTRAINT FK_LS_ITEM FOREIGN KEY (item) REFERENCES item (id) ON UPDATE RESTRICT ON DELETE RESTRICT,
  CONSTRAINT FK_LS_OPCION FOREIGN KEY (opcion) REFERENCES opcion (id) ON UPDATE RESTRICT ON DELETE RESTRICT,
  CONSTRAINT FK_LS_LLENADOSEGUIMIENTO FOREIGN KEY (llenadoseguimiento) REFERENCES llenadoseguimiento (id) ON UPDATE RESTRICT ON DELETE RESTRICT
) ENGINE = InnoDB ROW_FORMAT = DEFAULT;
 

ALTER TABLE llenadoseguimientodetalle
 CHANGE adjunto adjunto VARCHAR(200); 
 
ALTER TABLE llenadoseguimientodetalle
 DROP FOREIGN KEY FK_LS_ADJUNTO
 