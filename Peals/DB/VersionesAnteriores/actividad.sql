alter table actividad_x_recurso
add column pos_top varchar(6),
add column pos_left varchar(6);

alter table recurso
drop privacidad,
add column subido_por int,
add constraint fk_usuario_recurso foreign key (subido_por) references peals.usuario(id);

alter table actividad 
drop FOREIGN KEY fk_tipoActividad_actividad,
drop tipo_actividad,
change privacidad es_publica int,
change texto texto_solucion varchar (100),
add column descripcion varchar(1000);

drop table tipo_actividad;

create table texto (
	id INT AUTO_INCREMENT PRIMARY KEY,
	texto varchar(200),
	actividad int,
	pos_top varchar(6),
	pos_left varchar(6)
);

alter table texto
add constraint fk_actividad_text foreign key (actividad) references actividad(id);

create table recurso_compartido(
	id INT AUTO_INCREMENT PRIMARY KEY,
	recurso int,
	institucion int
);

alter table recurso_compartido
add constraint fk_recurso_rc foreign key (recurso) references recurso(id),
add constraint fk_institucion_rc foreign key (institucion) references institucion(id);