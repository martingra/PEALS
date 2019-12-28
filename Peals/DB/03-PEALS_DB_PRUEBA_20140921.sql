
/* ADMINISTRADORES */
INSERT INTO `usuario` VALUES 
/* id, mail, contraseña, nombre, apellido, fecha nacimiento, localidad, fecha alta, fecha baja, tipo usuario, especialidad, estado usuario  */
(1,'admin@peals.com','6367C48DD193D56EA7B0BAAD25B19455E529F5EE','Martin','Gramatica','1988-01-11',203,'1988-01-11 00:00:00',NULL,1,NULL, 2),
(2,'admin2@peals.com','6367C48DD193D56EA7B0BAAD25B19455E529F5EE','Paola','Gonzalez','1988-01-11',203,'1980-01-11 00:00:00',NULL,1,NULL, 2),
(3,'admin3@peals.com','6367C48DD193D56EA7B0BAAD25B19455E529F5EE','Juan','Pretti','1988-01-11',215,'1979-01-11 00:00:00',NULL,1,NULL, 2),
(4,'admin4@peals.com','6367C48DD193D56EA7B0BAAD25B19455E529F5EE','Jonatan','Camileti','1988-01-11',215,'1988-01-11 00:00:00',NULL,1,NULL, 1), /* Esperando Confirmación */
(5,'admin5@peals.com','6367C48DD193D56EA7B0BAAD25B19455E529F5EE','Adrian','Gramatica','1988-01-11',216,'1979-01-11 00:00:00','2014-01-11 00:00:00',1,NULL, 3); /* Dado de Baja */

/* DOCENTES */
INSERT INTO `usuario` VALUES 
/* id, mail, contraseña, nombre, apellido, fecha nacimiento, localidad, fecha alta, fecha baja, tipo usuario, especialidad, estado usuario  */
(6,'docente@peals.com', '6367C48DD193D56EA7B0BAAD25B19455E529F5EE', 'Gabriel', 'Freisz', '1989-01-24', 203, '2013-07-06 05:46:56',NULL, 2, 1, 2),
(7,'docente2@peals.com', '6367C48DD193D56EA7B0BAAD25B19455E529F5EE', 'Elizabeth', 'Rivarola', '1989-01-24', 203, '2013-07-06 05:46:56',NULL, 2, 1, 2),
(8,'docente3@peals.com', '6367C48DD193D56EA7B0BAAD25B19455E529F5EE', 'Ignacio', 'Gaudio', '1989-01-24', 203, '2013-07-06 05:46:56',NULL, 2, 1, 2),
(9,'docente4@peals.com', '6367C48DD193D56EA7B0BAAD25B19455E529F5EE', 'Valeria', 'Andrada', '1989-01-24', 203, '2013-07-06 05:46:56',NULL, 2, 1, 2),
(10,'docente5@peals.com', '6367C48DD193D56EA7B0BAAD25B19455E529F5EE', 'Andres', 'Mondolo', '1989-01-24', 203, '2013-07-06 05:46:56',NULL, 2, 1, 2),
(11,'docente6@peals.com', '6367C48DD193D56EA7B0BAAD25B19455E529F5EE', 'Lorena', 'Alvarez', '1989-01-24', 203, '2013-07-06 05:46:56',NULL, 2, 1, 2),
(12,'docente7@peals.com', '6367C48DD193D56EA7B0BAAD25B19455E529F5EE', 'Maria', 'Dominguez', '1989-01-24', 215, '2013-07-06 05:46:56',NULL, 2, 1, 2),
(13,'docente8@peals.com', '6367C48DD193D56EA7B0BAAD25B19455E529F5EE', 'Matias', 'Padial', '1989-01-24', 215, '2013-07-06 05:46:56',NULL, 2, 1, 2), /* no esta asignado a ninguna institucion */
(14,'docente9@peals.com', '6367C48DD193D56EA7B0BAAD25B19455E529F5EE', 'Gerardo', 'Olmos', '1989-01-24', 215, '2013-07-06 05:46:56',NULL, 2, 1, 1), /* Esperando Confirmación */
(15,'docente10@peals.com', '6367C48DD193D56EA7B0BAAD25B19455E529F5EE', 'Ariel', 'Freisz10', '1989-01-24', 203, '2013-07-06 05:46:56','2014-01-11 00:00:00', 2, 1, 3); /* Dado de Baja */

/* ALUMNOS */
INSERT INTO `usuario` VALUES 
/* id, mail, contraseña, nombre, apellido, fecha nacimiento, localidad, fecha alta, fecha baja, tipo usuario, especialidad, estado usuario  */
(16,'alumno@peals.com', '6367C48DD193D56EA7B0BAAD25B19455E529F5EE', 'Adrian', 'Mondolo', '1988-08-11', 203, '2013-07-06 05:49:27',NULL, 3, NULL, 2),
(17,'alumno2@peals.com', '6367C48DD193D56EA7B0BAAD25B19455E529F5EE', 'Julieta', 'Curdi', '1988-08-11', 203, '2013-07-06 05:49:27',NULL, 3, NULL, 2),
(18,'alumno3@peals.com', '6367C48DD193D56EA7B0BAAD25B19455E529F5EE', 'Claudio', 'Mazzaglia', '1988-08-11', 203, '2013-07-06 05:49:27',NULL, 3, NULL, 2),
(19,'alumno4@peals.com', '6367C48DD193D56EA7B0BAAD25B19455E529F5EE', 'Heber', 'Parrucci', '1988-08-11', 203, '2013-07-06 05:49:27',NULL, 3, NULL, 2),
(20,'alumno5@peals.com', '6367C48DD193D56EA7B0BAAD25B19455E529F5EE', 'Valeria', 'Gerez', '1988-08-11', 203, '2013-07-06 05:49:27',NULL, 3, NULL, 2),
(21,'alumno6@peals.com', '6367C48DD193D56EA7B0BAAD25B19455E529F5EE', 'Emmanuel', 'Ferreyra', '1988-08-11', 203, '2013-07-06 05:49:27',NULL, 3, NULL, 2),
(22,'alumno7@peals.com', '6367C48DD193D56EA7B0BAAD25B19455E529F5EE', 'Marilina', 'Ferreri', '1988-08-11', 203, '2013-07-06 05:49:27',NULL, 3, NULL, 2),
(23,'alumno8@peals.com', '6367C48DD193D56EA7B0BAAD25B19455E529F5EE', 'Marcelo', 'Perea', '1988-08-11', 203, '2013-07-06 05:49:27',NULL, 3, NULL, 2),
(24,'alumno9@peals.com', '6367C48DD193D56EA7B0BAAD25B19455E529F5EE', 'Candelaria', 'Funes', '1988-08-11', 203, '2013-07-06 05:49:27',NULL, 3, NULL, 2),
(25,'alumno10@peals.com', '6367C48DD193D56EA7B0BAAD25B19455E529F5EE', 'Joel', 'Monti', '1988-08-11', 203, '2013-07-06 05:49:27',NULL, 3, NULL, 2),
(26,'alumno11@peals.com', '6367C48DD193D56EA7B0BAAD25B19455E529F5EE', 'Soledad', 'Diaz', '1988-08-11', 203, '2013-07-06 05:49:27',NULL, 3, NULL, 2),
(27,'alumno12@peals.com', '6367C48DD193D56EA7B0BAAD25B19455E529F5EE', 'Luci', 'Borgi', '1988-08-11', 203, '2013-07-06 05:49:27',NULL, 3, NULL, 2),
(28,'alumno13@peals.com', '6367C48DD193D56EA7B0BAAD25B19455E529F5EE', 'Patricio', 'Del Boca', '1988-08-11', 203, '2013-07-06 05:49:27',NULL, 3, NULL, 2),
(29,'alumno14@peals.com', '6367C48DD193D56EA7B0BAAD25B19455E529F5EE', 'Adrian', 'Gonzalo', '1988-08-11', 203, '2013-07-06 05:49:27',NULL, 3, NULL, 2),
(30,'alumno15@peals.com', '6367C48DD193D56EA7B0BAAD25B19455E529F5EE', 'Silvia', 'Muñoz', '1988-08-11', 203, '2013-07-06 05:49:27',NULL, 3, NULL, 2),
(31,'alumno16@peals.com', '6367C48DD193D56EA7B0BAAD25B19455E529F5EE', 'Alexis', 'Voisard', '1988-08-11', 203, '2013-07-06 05:49:27',NULL, 3, NULL, 2),
(32,'alumno17@peals.com', '6367C48DD193D56EA7B0BAAD25B19455E529F5EE', 'Mauro', 'Bornoroni', '1988-08-11', 203, '2013-07-06 05:49:27',NULL, 3, NULL, 2),
(33,'alumno18@peals.com', '6367C48DD193D56EA7B0BAAD25B19455E529F5EE', 'Florencia', 'Blanco', '1988-08-11', 203, '2013-07-06 05:49:27',NULL, 3, NULL, 2),
(34,'alumno19@peals.com', '6367C48DD193D56EA7B0BAAD25B19455E529F5EE', 'Ana', 'Bernardi', '1988-08-11', 203, '2013-07-06 05:49:27',NULL, 3, NULL, 2),
(35,'alumno20@peals.com', '6367C48DD193D56EA7B0BAAD25B19455E529F5EE', 'Belen', 'Montenegro', '1988-08-11', 203, '2013-07-06 05:49:27',NULL, 3, NULL, 2),
(36,'alumno21@peals.com', '6367C48DD193D56EA7B0BAAD25B19455E529F5EE', 'Roberto', 'Gazzera', '1988-08-11', 203, '2013-07-06 05:49:27',NULL, 3, NULL, 2),
(37,'alumno22@peals.com', '6367C48DD193D56EA7B0BAAD25B19455E529F5EE', 'Luciano', 'Dominguez', '1988-08-11', 203, '2013-07-06 05:49:27',NULL, 3, NULL, 2),
(38,'alumno23@peals.com', '6367C48DD193D56EA7B0BAAD25B19455E529F5EE', 'Marcos', 'Quintana', '1988-08-11', 203, '2013-07-06 05:49:27',NULL, 3, NULL, 2),
(39,'alumno24@peals.com', '6367C48DD193D56EA7B0BAAD25B19455E529F5EE', 'Leandro', 'Pighi', '1988-08-11', 203, '2013-07-06 05:49:27',NULL, 3, NULL, 2),
(40,'alumno25@peals.com', '6367C48DD193D56EA7B0BAAD25B19455E529F5EE', 'Federico', 'Alvarez', '1988-08-11', 203, '2013-07-06 05:49:27',NULL, 3, NULL, 2),
(41,'alumno26@peals.com', '6367C48DD193D56EA7B0BAAD25B19455E529F5EE', 'Angeles', 'Baez', '1988-08-11', 203, '2013-07-06 05:49:27',NULL, 3, NULL, 2),
(42,'alumno27@peals.com', '6367C48DD193D56EA7B0BAAD25B19455E529F5EE', 'Cristian', 'Panella', '1988-08-11', 203, '2013-07-06 05:49:27',NULL, 3, NULL, 2),
(43,'alumno28@peals.com', '6367C48DD193D56EA7B0BAAD25B19455E529F5EE', 'Laura', 'Gomez', '1988-08-11', 203, '2013-07-06 05:49:27',NULL, 3, NULL, 2),
(44,'alumno29@peals.com', '6367C48DD193D56EA7B0BAAD25B19455E529F5EE', 'Nicolas', 'Rosales', '1988-08-11', 203, '2013-07-06 05:49:27',NULL, 3, NULL, 2),
(45,'alumno30@peals.com', '6367C48DD193D56EA7B0BAAD25B19455E529F5EE', 'Ignacio', 'Costa', '1988-08-11', 203, '2013-07-06 05:49:27',NULL, 3, NULL, 2),
(46,'alumno31@peals.com', '6367C48DD193D56EA7B0BAAD25B19455E529F5EE', 'Carmen', 'Garcia', '1988-08-11', 203, '2013-07-06 05:49:27',NULL, 3, NULL, 2),
(47,'alumno32@peals.com', '6367C48DD193D56EA7B0BAAD25B19455E529F5EE', 'Emilia', 'Camps', '1988-08-11', 215, '2013-07-06 05:49:27',NULL, 3, NULL, 2),
(48,'alumno33@peals.com', '6367C48DD193D56EA7B0BAAD25B19455E529F5EE', 'Maxi', 'Zoppini', '1988-08-11', 215, '2013-07-06 05:49:27',NULL, 3, NULL, 2),
(49,'alumno34@peals.com', '6367C48DD193D56EA7B0BAAD25B19455E529F5EE', 'Santiago', 'Patarca', '1988-08-11', 215, '2013-07-06 05:49:27',NULL, 3, NULL, 2),
(50,'alumno35@peals.com', '6367C48DD193D56EA7B0BAAD25B19455E529F5EE', 'Santiago', 'Miño', '1988-08-11', 215, '2013-07-06 05:49:27',NULL, 3, NULL, 2),
(51,'alumno36@peals.com', '6367C48DD193D56EA7B0BAAD25B19455E529F5EE', 'Alejandro', 'Alvarez', '1988-08-11', 215, '2013-07-06 05:49:27',NULL, 3, NULL, 2), /* no esta asignado a ninguna institucion */
(52,'alumno37@peals.com', '6367C48DD193D56EA7B0BAAD25B19455E529F5EE', 'Emmanuel', 'Bello', '1988-08-11', 203, '2013-07-06 05:49:27',NULL, 3, NULL, 2), /* no esta asignado a ninguna institucion */
(53,'alumno38@peals.com', '6367C48DD193D56EA7B0BAAD25B19455E529F5EE', 'Facundo', 'Ludueña', '1988-08-11', 203, '2013-07-06 05:49:27',NULL, 3, NULL, 2), /* no esta asignado a ninguna institucion */
(54,'alumno39@peals.com', '6367C48DD193D56EA7B0BAAD25B19455E529F5EE', 'Melani', 'Boore', '1988-08-11', 203, '2013-07-06 05:49:27',NULL, 3, NULL, 1), /* Esperando Confirmación */
(55,'alumno40@peals.com', '6367C48DD193D56EA7B0BAAD25B19455E529F5EE', 'Alumno', 'Alumno', '1988-08-11', 203, '2013-07-06 05:49:27','2014-01-11 00:00:00', 3, NULL, 3); /* Dado de Baja */

/* INSTITUCIONES */
INSERT INTO `institucion` VALUES 
/* id, nombre, teléfono, calle, altura_calle, piso, departamento, localidad, administrador, fecha_alta, información */
(1,'Instituto Bilingüe Para Sordos (IBIS)','4332351','Santa Rosa',340,NULL,NULL,203,1,"2013-06-25",NULL),
(2,'Instituto del Lenguaje y La Audición Córdoba (ILAC)','4332353','Maestro Marcelo Lopez',340,NULL,NULL,203,2,"2013-06-25",NULL),
(3,'Instituto de Lenguas de Señas Argentina (ILSA)','4332352','Viamonte',2367,NULL,NULL,215,3,"2013-06-25",NULL);

/* CURSOS */
INSERT INTO `curso` VALUES /* IBIS, TURNO MAÑANA */
/* id, turno, nivel, año, division, docente, institución, es público, nombre, descripción */ 
(1,1,1,1,'A',6,1,0,'Aprender con colores','Curso donde aprenderemos a escribir y nombrar los colores',1), 
(2,1,2,1,'A',6,1,0,'Las señas nuestro lenguaje','Curso donde se introduce a la escritura en base a señas',1),
(3,1,2,1,'B',6,1,0,'Letras','Aprenderemos el abecedarios',1),
(4,1,2,2,'A',6,1,0,'Numeros','Aprenderemos todos los numeros',1),
(5,1,3,1,'A',7,1,0,'Aprender jugando','Curso para reforzar el area del habla',1),
(6,1,3,1,'B',7,1,0,'Aprender con colores','Curso donde aprenderemos a escribir y nombrar los colores',1),
(7,1,3,2,'A',7,1,0,'Letras','Aprenderemos el abecedarios',1);

INSERT INTO `curso` VALUES /* ILAC, TURNO TARDE */
/* id, turno, nivel, año, division, docente, institución, es público, nombre, descripción */ 
(8,2,1,1,'A',8,2,0,'Aprender con colores','Curso donde aprenderemos a escribir y nombrar los colores',1), 
(9,2,2,1,'A',8,2,0,'Letras','Aprenderemos el abecedarios',1),
(10,2,2,1,'B',8,2,0,'Las señas nuestro lenguaje','Curso donde se introduce a la escritura en base a señas',1),
(11,2,2,2,'A',8,2,0,'Letras','Aprenderemos el abecedarios',1),
(12,2,3,1,'A',9,2,0,'Numeros','Aprenderemos todos los numeros',1),
(13,2,3,1,'B',9,2,0,'Aprender jugando','Curso para reforzar el area del habla',1),
(14,2,3,2,'A',9,2,0,'Letras','Aprenderemos el abecedarios',1);

INSERT INTO `curso` VALUES /* ILSA, TURNO NOCHE */
/* id, turno, nivel, año, division, docente, institución, es público, nombre, descripción */ 
(15,3,1,1,'A',10,3,0,'Aprender con colores','Curso donde aprenderemos a escribir y nombrar los colores',1), 
(16,3,2,1,'A',10,3,0,'Letras','Aprenderemos el abecedarios',1),
(17,3,2,1,'B',10,3,0,'Las señas nuestro lenguaje','Curso donde se introduce a la escritura en base a señas',1),
(18,3,2,2,'A',10,3,0,'Letras','Aprenderemos el abecedarios',1),
(19,3,3,1,'A',11,3,0,'Numeros','Aprenderemos todos los numeros',1),
(20,3,3,1,'B',11,3,0,'Aprender jugando','Curso para reforzar el area del habla',1),
(21,3,3,2,'A',11,3,0,'Letras','Aprenderemos el abecedarios',1);

INSERT INTO `curso` VALUES /* VARIOS CURSOS CON DOCENTES EN VARIAS INSTITUCIONES */
/* id, turno, nivel, año, division, docente, institución, es público, nombre, descripción */ 
(22,1,1,2,'B',6,3,0,'Aprender con colores','Curso donde aprenderemos a escribir y nombrar los colores',1), 
(23,1,2,3,'A',7,3,0,'Letras','Aprenderemos el abecedarios',1),
(24,1,2,3,'B',6,3,0,'Las señas nuestro lenguaje','Curso donde se introduce a la escritura en base a señas',1),
(25,1,2,4,'A',8,1,0,'Letras','Aprenderemos el abecedarios',1),
(26,1,3,3,'A',9,1,0,'Numeros','Aprenderemos todos los numeros',1),
(27,1,3,3,'B',10,2,0,'Aprender jugando','Curso para reforzar el area del habla',1),
(28,1,3,4,'A',11,2,0,'Letras','Aprenderemos el abecedarios',1);

INSERT INTO `curso` VALUES /* VARIOS CURSOS CON DOCENTES EN VARIAS INSTITUCIONES y PUBLICOS */
/* id, turno, nivel, año, division, docente, institución, es público, nombre, descripción */ 
(29,1,1,2,'B',6,3,1,'Aprender con colores: PUBLICO','Curso donde aprenderemos a escribir y nombrar los colores',1), 
(30,1,2,3,'A',7,3,1,'Letras: PUBLICO','Aprenderemos el abecedarios',1),
(31,1,2,3,'B',6,3,1,'Las señas nuestro lenguaje: PUBLICO','Curso donde se introduce a la escritura en base a señas',1),
(32,1,2,4,'A',8,1,1,'Letras: PUBLICO','Aprenderemos el abecedarios',1),
(33,1,3,3,'A',9,1,1,'Numeros: PUBLICO','Aprenderemos todos los numeros',1),
(34,1,3,3,'B',10,2,1,'Aprender jugando: PUBLICO','Curso para reforzar el area del habla',1),
(35,1,3,4,'A',11,2,1,'Letras: PUBLICO','Aprenderemos el abecedarios',1);

/* Estos insert son para poder insertar actividades. */
INSERT INTO recurso (id) VALUES (1);
INSERT INTO intervalo VALUES (1, 1, 1, 1);
INSERT INTO criterio_evaluacion VALUES (1, 1, 1);
/* ACTIVIDADES */
INSERT INTO `actividad` VALUES
/* id, nombre, fecha alta, es pública, texto solución, deletreo, imagen correcta, docente, descripción */
(1, 'Actividad Prueba 1', "2013-06-25", 0, NULL, NULL, NULL, 6, 'Descripcion Prueba 1',1,1),
(2, 'Actividad Prueba 2', "2013-06-25", 0, NULL, NULL, NULL, 6, 'Descripcion Prueba 2',1,1),
(3, 'Actividad Prueba 3', "2013-06-25", 0, NULL, NULL, NULL, 6, 'Descripcion Prueba 3',1,1),
(4, 'Actividad Prueba 4', "2013-06-25", 0, NULL, NULL, NULL, 6, 'Descripcion Prueba 4',1,1),
(5, 'Actividad Prueba 5', "2013-06-25", 0, NULL, NULL, NULL, 6, 'Descripcion Prueba 5',1,1),
(6, 'Actividad Prueba 6', "2013-06-25", 0, NULL, NULL, NULL, 6, 'Descripcion Prueba 6',1,1),
(7, 'Actividad Prueba 7', "2013-06-25", 0, NULL, NULL, NULL, 6, 'Descripcion Prueba 7',1,1),
(8, 'Actividad Prueba 8', "2013-06-25", 0, NULL, NULL, NULL, 7, 'Descripcion Prueba 8',1,1),
(9, 'Actividad Prueba 9', "2013-06-25", 0, NULL, NULL, NULL, 7, 'Descripcion Prueba 9',1,1),
(10, 'Actividad Prueba 10', "2013-06-25", 0, NULL, NULL, NULL, 7, 'Descripcion Prueba 10',1,1),
(11, 'Actividad Prueba 11', "2013-06-25", 0, NULL, NULL, NULL, 7, 'Descripcion Prueba 11',1,1),
(12, 'Actividad Prueba 12', "2013-06-25", 0, NULL, NULL, NULL, 7, 'Descripcion Prueba 12',1,1),
(13, 'Actividad Prueba 13', "2013-06-25", 0, NULL, NULL, NULL, 7, 'Descripcion Prueba 13',1,1),
(14, 'Actividad Prueba 14', "2013-06-25", 0, NULL, NULL, NULL, 7, 'Descripcion Prueba 14',1,1),
(15, 'Actividad Prueba 15', "2013-06-25", 0, NULL, NULL, NULL, 8, 'Descripcion Prueba 15',1,1),
(16, 'Actividad Prueba 16', "2013-06-25", 0, NULL, NULL, NULL, 8, 'Descripcion Prueba 16',1,1),
(17, 'Actividad Prueba 17', "2013-06-25", 0, NULL, NULL, NULL, 8, 'Descripcion Prueba 17',1,1),
(18, 'Actividad Prueba 18', "2013-06-25", 0, NULL, NULL, NULL, 8, 'Descripcion Prueba 18',1,1),
(19, 'Actividad Prueba 19', "2013-06-25", 0, NULL, NULL, NULL, 8, 'Descripcion Prueba 19',1,1),
(20, 'Actividad Prueba 20', "2013-06-25", 0, NULL, NULL, NULL, 8, 'Descripcion Prueba 20',1,1),
(21, 'Actividad Prueba 21', "2013-06-25", 0, NULL, NULL, NULL, 8, 'Descripcion Prueba 21',1,1),
(22, 'Actividad Prueba 22', "2013-06-25", 0, NULL, NULL, NULL, 9, 'Descripcion Prueba 22',1,1),
(23, 'Actividad Prueba 23', "2013-06-25", 0, NULL, NULL, NULL, 9, 'Descripcion Prueba 23',1,1),
(24, 'Actividad Prueba 24', "2013-06-25", 0, NULL, NULL, NULL, 9, 'Descripcion Prueba 24',1,1),
(25, 'Actividad Prueba 25', "2013-06-25", 0, NULL, NULL, NULL, 9, 'Descripcion Prueba 25',1,1),
(26, 'Actividad Prueba 26', "2013-06-25", 0, NULL, NULL, NULL, 9, 'Descripcion Prueba 26',1,1),
(27, 'Actividad Prueba 27', "2013-06-25", 0, NULL, NULL, NULL, 9, 'Descripcion Prueba 27',1,1),
(28, 'Actividad Prueba 28', "2013-06-25", 0, NULL, NULL, NULL, 9, 'Descripcion Prueba 28',1,1),
(29, 'Actividad Prueba 29', "2013-06-25", 0, NULL, NULL, NULL, 10, 'Descripcion Prueba 29',1,1),
(30, 'Actividad Prueba 30', "2013-06-25", 0, NULL, NULL, NULL, 10, 'Descripcion Prueba 30',1,1),
(31, 'Actividad Prueba 31', "2013-06-25", 0, NULL, NULL, NULL, 10, 'Descripcion Prueba 31',1,1),
(32, 'Actividad Prueba 32', "2013-06-25", 0, NULL, NULL, NULL, 10, 'Descripcion Prueba 32',1,1),
(33, 'Actividad Prueba 33', "2013-06-25", 0, NULL, NULL, NULL, 10, 'Descripcion Prueba 33',1,1),
(34, 'Actividad Prueba 34', "2013-06-25", 0, NULL, NULL, NULL, 10, 'Descripcion Prueba 34',1,1),
(35, 'Actividad Prueba 35', "2013-06-25", 0, NULL, NULL, NULL, 11, 'Descripcion Prueba 35',1,1),
(36, 'Actividad Prueba 36', "2013-06-25", 0, NULL, NULL, NULL, 11, 'Descripcion Prueba 36',1,1),
(37, 'Actividad Prueba 37', "2013-06-25", 0, NULL, NULL, NULL, 11, 'Descripcion Prueba 37',1,1),
(38, 'Actividad Prueba 38', "2013-06-25", 0, NULL, NULL, NULL, 11, 'Descripcion Prueba 38',1,1),
(39, 'Actividad Prueba 39', "2013-06-25", 0, NULL, NULL, NULL, 11, 'Descripcion Prueba 39',1,1),
(40, 'Actividad Prueba 40', "2013-06-25", 0, NULL, NULL, NULL, 11, 'Descripcion Prueba 40',1,1);

INSERT INTO `actividad` VALUES /* PUBLICAS */
/* id, nombre, fecha alta, es pública, texto solución, deletreo, imagen correcta, docente, descripción */
(41, 'Actividad Prueba 41', "2013-06-25", 1, NULL, NULL, NULL, 6, 'Descripcion Prueba 41',1,1),
(42, 'Actividad Prueba 42', "2013-06-25", 1, NULL, NULL, NULL, 7, 'Descripcion Prueba 42',1,1),
(43, 'Actividad Prueba 43', "2013-06-25", 1, NULL, NULL, NULL, 8, 'Descripcion Prueba 43',1,1),
(44, 'Actividad Prueba 44', "2013-06-25", 1, NULL, NULL, NULL, 9, 'Descripcion Prueba 44',1,1),
(45, 'Actividad Prueba 45', "2013-06-25", 1, NULL, NULL, NULL, 10, 'Descripcion Prueba 45',1,1),
(46, 'Actividad Prueba 46', "2013-06-25", 1, NULL, NULL, NULL, 11, 'Descripcion Prueba 46',1,1);

/* ACTIVIDADES */
INSERT INTO `actividad` VALUES  /* MAS ACTIVIDADES */
/* id, nombre, fecha alta, es pública, texto solución, deletreo, imagen correcta, docente, descripción */
(47, 'Actividad Prueba 47', "2013-06-25", 0, NULL, NULL, NULL, 6, 'Descripcion Prueba 47',1,1),
(48, 'Actividad Prueba 48', "2013-06-25", 0, NULL, NULL, NULL, 6, 'Descripcion Prueba 48',1,1),
(49, 'Actividad Prueba 49', "2013-06-25", 0, NULL, NULL, NULL, 6, 'Descripcion Prueba 49',1,1),
(50, 'Actividad Prueba 50', "2013-06-25", 0, NULL, NULL, NULL, 7, 'Descripcion Prueba 50',1,1),
(51, 'Actividad Prueba 51', "2013-06-25", 0, NULL, NULL, NULL, 7, 'Descripcion Prueba 51',1,1),
(52, 'Actividad Prueba 52', "2013-06-25", 0, NULL, NULL, NULL, 7, 'Descripcion Prueba 52',1,1),
(53, 'Actividad Prueba 53', "2013-06-25", 0, NULL, NULL, NULL, 8, 'Descripcion Prueba 53',1,1),
(54, 'Actividad Prueba 54', "2013-06-25", 0, NULL, NULL, NULL, 8, 'Descripcion Prueba 54',1,1),
(55, 'Actividad Prueba 55', "2013-06-25", 0, NULL, NULL, NULL, 8, 'Descripcion Prueba 55',1,1),
(56, 'Actividad Prueba 56', "2013-06-25", 0, NULL, NULL, NULL, 9, 'Descripcion Prueba 56',1,1),
(57, 'Actividad Prueba 57', "2013-06-25", 0, NULL, NULL, NULL, 9, 'Descripcion Prueba 57',1,1),
(58, 'Actividad Prueba 58', "2013-06-25", 0, NULL, NULL, NULL, 9, 'Descripcion Prueba 58',1,1),
(59, 'Actividad Prueba 59', "2013-06-25", 0, NULL, NULL, NULL, 10, 'Descripcion Prueba 59',1,1),
(60, 'Actividad Prueba 60', "2013-06-25", 0, NULL, NULL, NULL, 10, 'Descripcion Prueba 60',1,1),
(61, 'Actividad Prueba 61', "2013-06-25", 0, NULL, NULL, NULL, 10, 'Descripcion Prueba 61',1,1),
(62, 'Actividad Prueba 62', "2013-06-25", 0, NULL, NULL, NULL, 10, 'Descripcion Prueba 62',1,1),
(63, 'Actividad Prueba 63', "2013-06-25", 0, NULL, NULL, NULL, 11, 'Descripcion Prueba 63',1,1),
(64, 'Actividad Prueba 64', "2013-06-25", 0, NULL, NULL, NULL, 11, 'Descripcion Prueba 64',1,1),
(65, 'Actividad Prueba 65', "2013-06-25", 0, NULL, NULL, NULL, 11, 'Descripcion Prueba 65',1,1),
(66, 'Actividad Prueba 66', "2013-06-25", 0, NULL, NULL, NULL, 11, 'Descripcion Prueba 66',1,1);

/* TEXTO */
INSERT INTO `texto` VALUES
/* id, texto, actividad, pos_top, pos_left */
(1, 'Prueba Texto 1', 1, '220px', '100px');

INSERT INTO `docente_x_institucion` VALUES 
/* id, docente, institución, fecha alta*/ /*8 docentes de alta(6 - 13), 3 instituciones */
(1,6,1,"2013-06-25"),
(2,6,2,"2013-06-25"),
(3,6,3,"2013-06-25"),
(4,7,1,"2013-06-25"),
(5,7,2,"2013-06-25"),
(6,7,3,"2013-06-25"),
(7,8,1,"2013-06-25"),
(8,8,2,"2013-06-25"),
(9,8,3,"2013-06-25"),
(10,9,1,"2013-06-25"),
(11,9,2,"2013-06-25"),
(12,10,2,"2013-06-25"),
(13,10,3,"2013-06-25"),
(14,11,2,"2013-06-25"),
(15,11,3,"2013-06-25"),
(16,12,1,"2013-06-25");

INSERT INTO `alumno_x_institucion` VALUES
/* id, alumno, institución, fecha alta*/ /*40 alumnos de alta(16 - 53), 3 instituciones */
(1, 16, 1, "2013-08-12"),
(2, 16, 2, "2013-08-12"),
(3, 16, 3, "2013-08-12"),
(4, 17, 1, "2013-08-12"),
(5, 17, 2, "2013-08-12"),
(6, 17, 3, "2013-08-12"),
(7, 18, 1, "2013-08-12"),
(8, 18, 2, "2013-08-12"),
(9, 19, 1, "2013-08-12"),
(10, 19, 2, "2013-08-12"),
(11, 20, 1, "2013-08-12"),
(12, 20, 3, "2013-08-12"),
(13, 21, 1, "2013-08-12"),
(14, 21, 3, "2013-08-12"),
(15, 22, 2, "2013-08-12"),
(16, 22, 3, "2013-08-12"),
(17, 23, 2, "2013-08-12"),
(18, 23, 3, "2013-08-12"),
(19, 24, 1, "2013-08-12"),
(20, 25, 2, "2013-08-12"),
(21, 26, 3, "2013-08-12"),
(22, 27, 1, "2013-08-12"),
(23, 28, 2, "2013-08-12"),
(24, 29, 3, "2013-08-12"),
(25, 30, 1, "2013-08-12"),
(26, 31, 2, "2013-08-12"),
(27, 32, 3, "2013-08-12"),
(28, 33, 1, "2013-08-12"),
(29, 34, 2, "2013-08-12"),
(30, 35, 3, "2013-08-12"),
(31, 36, 1, "2013-08-12"),
(32, 37, 2, "2013-08-12"),
(33, 38, 3, "2013-08-12"),
(34, 39, 1, "2013-08-12"),
(35, 40, 2, "2013-08-12"),
(36, 41, 3, "2013-08-12"),
(37, 42, 1, "2013-08-12"),
(38, 43, 2, "2013-08-12"),
(39, 44, 3, "2013-08-12"),
(40, 45, 1, "2013-08-12"),
(41, 46, 2, "2013-08-12"),
(42, 47, 3, "2013-08-12"),
(43, 48, 1, "2013-08-12"),
(44, 49, 2, "2013-08-12"),
(45, 50, 3, "2013-08-12");


INSERT INTO `alumno_x_curso` VALUES 
/* id, alumno, curso, fecha asignación*/ /*40 alumnos de alta(16 - 53), 28 cursos privados (1 - 28), 7 cursos públicos (29 - 35) */
(1, 16, 1, "2013-08-12"),        /* cursos  1 -  4, docente  6,  institución 1 */
(2, 17, 1, "2013-08-12"),        /* cursos  5 -  7, docente  7,  institución 1 */
(3, 18, 1, "2013-08-12"),        /* cursos  8 - 11, docente  8,  institución 2 */
(4, 19, 1, "2013-08-12"),        /* cursos 12 - 14, docente  9,  institución 2 */
(5, 20, 1, "2013-08-12"),        /* cursos 15 - 18, docente 10,  institución 3 */
(6, 21, 1, "2013-08-12"),        /* cursos 19 - 21, docente 11,  institución 3 */
(7, 24, 1, "2013-08-12"),        /* curso  22,      docente  6,  institución 3 */
(8, 27, 1, "2013-08-12"),        /* curso  23,      docente  7,  institución 3 */
(9, 30, 1, "2013-08-12"),        /* curso  24,      docente  6,  institución 3 */
(10, 33, 1, "2013-08-12"),       /* curso  25,      docente  8,  institución 1 */
(11, 16, 5, "2013-08-12"),       /* curso  26,      docente  9,  institución 1 */
(12, 17, 5, "2013-08-12"),       /* curso  27,      docente 10,  institución 2 */
(13, 18, 5, "2013-08-12"),       /* curso  28,      docente 11,  institución 2 */
(14, 19, 5, "2013-08-12"),       /* curso  29,      docente  6,  institución 3 */
(15, 20, 5, "2013-08-12"),       /* curso  30,      docente  7,  institución 3 */
(16, 21, 5, "2013-08-12"),       /* curso  31,      docente  6,  institución 3 */
(17, 24, 5, "2013-08-12"),       /* curso  32,      docente  8,  institución 1 */
(18, 27, 5, "2013-08-12"),       /* curso  33,	    docente  9,  institución 1 */
(19, 30, 5, "2013-08-12"),       /* curso  34,  	docente 10,  institución 2 */
(20, 33, 5, "2013-08-12"),       /* curso  35,  	docente 11,  institución 2 */
(21, 16, 8, "2013-08-12"),
(22, 17, 8, "2013-08-12"),       /* alumno 16,		institución 1, 2, 3 */		/* docente  6,	institución 1, 2, 3 */
(23, 18, 8, "2013-08-12"),       /* alumno 17,		institución 1, 2, 3 */		/* docente  7,	institución 1, 2, 3 */
(24, 19, 8, "2013-08-12"),       /* alumno 18,		institución 1, 2    */		/* docente  8,	institución 1, 2, 3 */
(25, 22, 8, "2013-08-12"),       /* alumno 19,		institución 1, 2    */		/* docente  9,	institución 1, 2    */
(26, 23, 8, "2013-08-12"),       /* alumno 20,		institución 1, 3    */		/* docente 10,	institución 2, 3	*/
(27, 25, 8, "2013-08-12"),       /* alumno 21,		institución 1, 3    */		/* docente 11,	institución 2, 3	*/
(28, 28, 8, "2013-08-12"),       /* alumno 22,		institución 2, 3    */		/* docente 12,	institución 1		*/
(29, 31, 8, "2013-08-12"),       /* alumno 23,		institución 2, 3    */
(30, 34, 8, "2013-08-12"),       /* alumno 24,		institución 1       */
(31, 16, 12, "2013-08-12"),      /* alumno 25,		institución 2       */
(32, 17, 12, "2013-08-12"),      /* alumno 26,		institución 3       */
(33, 18, 12, "2013-08-12"),      /* alumno 27,		institución 1       */
(34, 19, 12, "2013-08-12"),      /* alumno 28,		institución 2       */
(35, 22, 12, "2013-08-12"),      /* alumno 29,		institución 3       */
(36, 23, 12, "2013-08-12"),      /* alumno 30,		institución 1       */
(37, 25, 12, "2013-08-12"),      /* alumno 31,		institución 2		*/
(38, 28, 12, "2013-08-12"),      /* alumno 32,		institución 3		*/
(39, 31, 12, "2013-08-12"),      /* alumno 33,		institución 1		*/
(40, 34, 12, "2013-08-12"),      /* alumno 34,		institución 2		*/
(41, 16, 15, "2013-08-12"),      /* alumno 35,		institución 3		*/
(42, 17, 15, "2013-08-12"),      /* alumno 36,		institución 1		*/
(43, 20, 15, "2013-08-12"),      /* alumno 37,		institución 2		*/
(44, 21, 15, "2013-08-12"),      /* alumno 38,		institución 3		*/
(45, 22, 15, "2013-08-12"),      /* alumno 39,		institución 1		*/
(46, 23, 15, "2013-08-12"),      /* alumno 40,		institución 2		*/
(47, 26, 15, "2013-08-12"),      /* alumno 41,		institución 3		*/
(48, 29, 15, "2013-08-12"),      /* alumno 42,		institución 1		*/
(49, 32, 15, "2013-08-12"),      /* alumno 43,		institución 2		*/
(50, 35, 15, "2013-08-12"),      /* alumno 44,		institución 3		*/
(51, 16, 19, "2013-08-12"),      /* alumno 45,		institución 1		*/
(52, 17, 19, "2013-08-12"),      /* alumno 46,		institución 2		*/
(53, 20, 19, "2013-08-12"),      /* alumno 47,		institución 3		*/
(54, 21, 19, "2013-08-12"),      /* alumno 48,		institución 1		*/
(55, 22, 19, "2013-08-12"),      /* alumno 49,		institución 2		*/
(56, 23, 19, "2013-08-12"),      /* alumno 50,		institución 3		*/
(57, 26, 19, "2013-08-12"),
(58, 29, 19, "2013-08-12"),
(59, 32, 19, "2013-08-12"),
(60, 35, 19, "2013-08-12"),

(61, 16, 22, "2013-08-12"),      /* cursos  1 -  4, docente  6,  institución 1 */
(62, 17, 22, "2013-08-12"),      /* cursos  5 -  7, docente  7,  institución 1 */
(63, 20, 22, "2013-08-12"),      /* cursos  8 - 11, docente  8,  institución 2 */
(64, 21, 22, "2013-08-12"),      /* cursos 12 - 14, docente  9,  institución 2 */
(65, 22, 22, "2013-08-12"),      /* cursos 15 - 18, docente 10,  institución 3 */
(66, 16, 23, "2013-08-12"),      /* cursos 19 - 21, docente 11,  institución 3 */
(67, 17, 23, "2013-08-12"),      /* curso  22,      docente  6,  institución 3 */
(68, 20, 23, "2013-08-12"),      /* curso  23,      docente  7,  institución 3 */
(69, 21, 23, "2013-08-12"),      /* curso  24,      docente  6,  institución 3 */
(70, 22, 23, "2013-08-12"),      /* curso  25,      docente  8,  institución 1 */
(71, 26, 24, "2013-08-12"),      /* curso  26,      docente  9,  institución 1 */
(72, 29, 24, "2013-08-12"),      /* curso  27,      docente 10,  institución 2 */
(73, 32, 24, "2013-08-12"),      /* curso  28,      docente 11,  institución 2 */
(74, 35, 24, "2013-08-12"),      /* curso  29,      docente  6,  institución 3 */
(75, 38, 24, "2013-08-12"),      /* curso  30,      docente  7,  institución 3 */
(76, 16, 25, "2013-08-12"),      /* curso  31,      docente  6,  institución 3 */
(77, 17, 25, "2013-08-12"),      /* curso  32,      docente  8,  institución 1 */
(78, 18, 25, "2013-08-12"),      /* curso  33,	    docente  9,  institución 1 */
(79, 19, 25, "2013-08-12"),      /* curso  34,  	docente 10,  institución 2 */
(80, 20, 25, "2013-08-12"),      /* curso  35,  	docente 11,  institución 2 */
(81, 21, 26, "2013-08-12"),
(82, 24, 26, "2013-08-12"),      /* alumno 16,		institución 1, 2, 3 */		/* docente  6,	institución 1, 2, 3 */
(83, 27, 26, "2013-08-12"),      /* alumno 17,		institución 1, 2, 3 */		/* docente  7,	institución 1, 2, 3 */
(84, 30, 26, "2013-08-12"),      /* alumno 18,		institución 1, 2    */		/* docente  8,	institución 1, 2, 3 */
(85, 33, 26, "2013-08-12"),      /* alumno 19,		institución 1, 2    */		/* docente  9,	institución 1, 2    */
(86, 16, 27, "2013-08-12"),      /* alumno 20,		institución 1, 3    */		/* docente 10,	institución 2, 3	*/
(87, 17, 27, "2013-08-12"),      /* alumno 21,		institución 1, 3    */		/* docente 11,	institución 2, 3	*/
(88, 18, 27, "2013-08-12"),      /* alumno 22,		institución 2, 3    */		/* docente 12,	institución 1		*/
(89, 19, 27, "2013-08-12"),      /* alumno 23,		institución 2, 3    */
(90, 22, 27, "2013-08-12"),      /* alumno 24,		institución 1       */
(91, 23, 28, "2013-08-12"),      /* alumno 25,		institución 2       */
(92, 25, 28, "2013-08-12"),      /* alumno 26,		institución 3       */
(93, 28, 28, "2013-08-12"),      /* alumno 27,		institución 1       */
(94, 31, 28, "2013-08-12"),      /* alumno 28,		institución 2       */
(95, 34, 28, "2013-08-12");      /* alumno 29,		institución 3       */
/*(96, 23, 12, "2013-08-12"),*/  /* alumno 30,		institución 1       */
/*(97, 25, 12, "2013-08-12"),*/  /* alumno 31,		institución 2		*/
/*(98, 28, 12, "2013-08-12"),*/  /* alumno 32,		institución 3		*/
/*(99, 31, 12, "2013-08-12"),*/  /* alumno 33,		institución 1		*/
/*(100, 34, 12, "2013-08-12"),*/ /* alumno 34,		institución 2		*/
/*(101, 16, 15, "2013-08-12"),*/ /* alumno 35,		institución 3		*/
/*(102, 17, 15, "2013-08-12"),*/ /* alumno 36,		institución 1		*/
/*(103, 20, 15, "2013-08-12"),*/ /* alumno 37,		institución 2		*/
/*(104, 21, 15, "2013-08-12"),*/ /* alumno 38,		institución 3		*/
/*(105, 22, 15, "2013-08-12"),*/ /* alumno 39,		institución 1		*/
/*(106, 23, 15, "2013-08-12"),*/ /* alumno 40,		institución 2		*/
/*(107, 26, 15, "2013-08-12"),*/ /* alumno 41,		institución 3		*/
/*(108, 29, 15, "2013-08-12"),*/ /* alumno 42,		institución 1		*/
/*(109, 32, 15, "2013-08-12"),*/ /* alumno 43,		institución 2		*/
/*(110, 35, 15, "2013-08-12"),*/ /* alumno 44,		institución 3		*/
/*(111, 16, 19, "2013-08-12"),*/ /* alumno 45,		institución 1		*/
/*(112, 17, 19, "2013-08-12"),*/ /* alumno 46,		institución 2		*/
/*(113, 20, 19, "2013-08-12"),*/ /* alumno 47,		institución 3		*/
/*(114, 21, 19, "2013-08-12"),*/ /* alumno 48,		institución 1		*/
/*(115, 22, 19, "2013-08-12"),*/ /* alumno 49,		institución 2		*/
/*(116, 23, 19, "2013-08-12"),*/ /* alumno 50,		institución 3		*/


INSERT INTO `actividad_x_curso` VALUES 
/* id, actividad, curso, fecha asignación*/ /*40 actividades privadas(1 - 40), 28 cursos privados (1 - 28), 7 cursos públicos (29 - 35) */
(1, 1, 1, "2013-08-12"),         /* cursos  1 -  4, docente  6,  institución 1 */
(2, 2, 1, "2013-08-12"),         /* cursos  5 -  7, docente  7,  institución 1 */
(3, 3, 1, "2013-08-12"),         /* cursos  8 - 11, docente  8,  institución 2 */
(4, 4, 1, "2013-08-12"),         /* cursos 12 - 14, docente  9,  institución 2 */
(5, 5, 1, "2013-08-12"),         /* cursos 15 - 18, docente 10,  institución 3 */
(6, 6, 1, "2013-08-12"),         /* cursos 19 - 21, docente 11,  institución 3 */
(7, 7, 1, "2013-08-12"),         /* curso  22,      docente  6,  institución 3 */
(8, 47, 1, "2013-08-12"),        /* curso  23,      docente  7,  institución 3 */
(9, 8, 5, "2013-08-12"),         /* curso  24,      docente  6,  institución 3 */
(10, 9, 5, "2013-08-12"),        /* curso  25,      docente  8,  institución 1 */
(11, 10, 5, "2013-08-12"),       /* curso  26,      docente  9,  institución 1 */
(12, 11, 5, "2013-08-12"),       /* curso  27,      docente 10,  institución 2 */
(13, 12, 5, "2013-08-12"),       /* curso  28,      docente 11,  institución 2 */
(14, 13, 5, "2013-08-12"),       /* curso  29,      docente  6,  institución 3 */
(15, 14, 5, "2013-08-12"),       /* curso  30,      docente  7,  institución 3 */
(16, 53, 5, "2013-08-12"),       /* curso  31,      docente  6,  institución 3 */
(17, 15, 8, "2013-08-12"),       /* curso  32,      docente  8,  institución 1 */
(18, 16, 8, "2013-08-12"),       /* curso  33,	   docente  9,  institución 1 */
(19, 17, 8, "2013-08-12"),       /* curso  34,  	   docente 10,  institución 2 */
(20, 18, 8, "2013-08-12"),       /* curso  35,      docente 11,  institución 2 */
(21, 19, 8, "2013-08-12"),
(22, 20, 8, "2013-08-12"),       /* docente  6,		actividad   1 -  7, 41, 47 - 49,     institución 1, 2, 3 */
(23, 21, 8, "2013-08-12"),       /* docente  7,		actividad   8 - 14, 42, 50 - 52,     institución 1, 2, 3 */
(24, 53, 8, "2013-08-12"),       /* docente  8,		actividad  15 - 21, 43, 53 - 55,     institución 1, 2, 3 */
(25, 22, 12, "2013-08-12"),      /* docente  9,		actividad  22 - 28, 44, 56 - 58,     institución 1, 2    */
(26, 23, 12, "2013-08-12"),      /* docente 10,		actividad  29 - 34, 45, 59 - 62,     institución 2, 3	 */
(27, 24, 12, "2013-08-12"),      /* docente 11,		actividad  35 - 40, 46, 63 - 66,     institución 2, 3    */
(28, 25, 12, "2013-08-12"),       
(29, 26, 12, "2013-08-12"),       
(30, 27, 12, "2013-08-12"),       
(31, 28, 12, "2013-08-12"),      
(32, 56, 12, "2013-08-12"),      
(33, 29, 15, "2013-08-12"),      
(34, 30, 15, "2013-08-12"),      
(35, 31, 15, "2013-08-12"),      
(36, 32, 15, "2013-08-12"),      
(37, 33, 15, "2013-08-12"),      
(38, 34, 15, "2013-08-12"),      
(39, 59, 15, "2013-08-12"),      
(40, 60, 15, "2013-08-12"),      
(41, 35, 19, "2013-08-12"),      
(42, 36, 19, "2013-08-12"),      
(43, 37, 19, "2013-08-12"),      
(44, 38, 19, "2013-08-12"),      
(45, 39, 19, "2013-08-12"),      
(46, 40, 19, "2013-08-12"),      
(47, 63, 19, "2013-08-12"),      
(48, 64, 19, "2013-08-12"),      
(49, 1, 22, "2013-08-12"),      
(50, 2, 22, "2013-08-12"),       /* cursos  1 -  4, docente  6,  institución 1 */
(51, 3, 22, "2013-08-12"),       /* cursos  5 -  7, docente  7,  institución 1 */
(52, 4, 22, "2013-08-12"),       /* cursos  8 - 11, docente  8,  institución 2 */
(53, 8, 23, "2013-08-12"),       /* cursos 12 - 14, docente  9,  institución 2 */
(54, 9, 23, "2013-08-12"),       /* cursos 15 - 18, docente 10,  institución 3 */
(55, 10, 23, "2013-08-12"),      /* cursos 19 - 21, docente 11,  institución 3 */
(56, 11, 23, "2013-08-12"),      /* curso  22,      docente  6,  institución 3 */
(57, 1, 24, "2013-08-12"),       /* curso  23,      docente  7,  institución 3 */
(58, 2, 24, "2013-08-12"),       /* curso  24,      docente  6,  institución 3 */
(59, 3, 24, "2013-08-12"),       /* curso  25,      docente  8,  institución 1 */
(60, 4, 24, "2013-08-12"),       /* curso  26,      docente  9,  institución 1 */
(61, 15, 25, "2013-08-12"),      /* curso  27,      docente 10,  institución 2 */     
(62, 16, 25, "2013-08-12"),      /* curso  28,      docente 11,  institución 2 */      
(63, 17, 25, "2013-08-12"),      /* curso  29,      docente  6,  institución 3 */      
(64, 18, 25, "2013-08-12"),      /* curso  30,      docente  7,  institución 3 */      
(65, 22, 26, "2013-08-12"),      /* curso  31,      docente  6,  institución 3 */      
(66, 23, 26, "2013-08-12"),      /* curso  32,      docente  8,  institución 1 */
(67, 24, 26, "2013-08-12"),      /* curso  33,	    docente  9,  institución 1 */
(68, 25, 26, "2013-08-12"),      /* curso  34,  	docente 10,  institución 2 */
(69, 29, 27, "2013-08-12"),      /* curso  35,  	docente 11,  institución 2 */
(70, 30, 27, "2013-08-12"),
(71, 31, 27, "2013-08-12"),      /* docente  6,		actividad   1 -  7, 41, 47 - 49,     institución 1, 2, 3 */
(72, 32, 27, "2013-08-12"),      /* docente  7,		actividad   8 - 14, 42, 50 - 52,     institución 1, 2, 3 */
(73, 35, 28, "2013-08-12"),      /* docente  8,		actividad  15 - 21, 43, 53 - 55,     institución 1, 2, 3 */
(74, 36, 28, "2013-08-12"),      /* docente  9,		actividad  22 - 28, 44, 56 - 58,     institución 1, 2    */
(75, 37, 28, "2013-08-12"),      /* docente 10,		actividad  29 - 34, 45, 59 - 62,     institución 2, 3	 */
(76, 38, 28, "2013-08-12");      /* docente 11,		actividad  35 - 40, 46, 63 - 66,     institución 2, 3    */

INSERT INTO `actividad_x_curso` VALUES /* AGREGO PARA MAS PRUEBAS PARA LA BAJA DE ADMINISTRADOR */
/* id, actividad, curso, fecha asignación*/ /*40 actividades privadas(1 - 40), 28 cursos privados (1 - 28), 7 cursos públicos (29 - 35) */
(77, 2, 2, "2013-08-12"),
(78, 3, 2, "2013-08-12");

INSERT INTO `historial_actividad` VALUES 
/* id, alumno, docente, curso, institución, calificación docente, calificación sistema, fecha realización */
/* intentos, actividad, usó ayuda consigna, usó ayuda actividad, tiempo */
(1, 16, 6, 1, 1, null, null, null, null, 1, null, null, null),
(2, 17, 6, 1, 1, null, null, null, null, 1, null, null, null),
(3, 18, 6, 1, 1, null, null, null, null, 1, null, null, null),
(4, 19, 7, 5, 1, null, null, null, null, 8, null, null, null),
(5, 20, 7, 5, 1, null, null, null, null, 8, null, null, null),
(6, 21, 7, 5, 1, null, null, null, null, 8, null, null, null),
(7, 16, 8, 8, 2, null, null, null, null, 15, null, null, null),
(8, 17, 8, 8, 2, null, null, null, null, 15, null, null, null),
(9, 18, 8, 8, 2, null, null, null, null, 15, null, null, null),
(10, 19, 9, 12, 2, null, null, null, null, 22, null, null, null),
(11, 22, 9, 12, 2, null, null, null, null, 22, null, null, null),
(12, 23, 9, 12, 2, null, null, null, null, 22, null, null, null),
(13, 16, 10, 15, 3, null, null, null, null, 29, null, null, null),
(14, 17, 10, 15, 3, null, null, null, null, 29, null, null, null),
(15, 20, 10, 15, 3, null, null, null, null, 29, null, null, null),
(16, 21, 11, 19, 3, null, null, null, null, 35, null, null, null),
(17, 22, 11, 19, 3, null, null, null, null, 35, null, null, null),
(18, 23, 11, 19, 3, null, null, null, null, 35, null, null, null);

INSERT INTO `historial_actividad` VALUES 
/* id, alumno, docente, curso, institución, calificación docente, calificación sistema, fecha realización */
/* intentos, actividad, usó ayuda consigna, usó ayuda actividad, tiempo */
(19, 16, 6, 1, 1, null, null, null, null, 49, null, null, null);
