drop table `peals`.`solicitud_inscripcion`;

drop table `peals`.`estado_solicitud`;

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
	tipo_mensaje int
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

alter table peals.mensaje
add referencia int;

alter table peals.mensaje
modify titulo_mensaje varchar(150);