delete from actividad_x_recurso where id > 0;
delete from actividad_x_curso where id > -1;
delete from actividad where id > -1;

alter table actividad_x_recurso
drop FOREIGN KEY fk_actividad_actividadXrecurso,
drop FOREIGN KEY fk_recurso_actividadXrecurso,
change actividad ejercicio int;

rename table actividad_x_recurso to ejercicio_x_recurso;

alter table actividad
drop texto_solucion, 
drop deletreo, 
drop imagen_correcta;

create table ejercicio(
	id int AUTO_INCREMENT PRIMARY KEY,
	texto_solucion varchar(200),
	deletreo varchar(50),
	recurso_correcto int,
	actividad int
);

alter table ejercicio
add constraint fk_actividad_ejercicio foreign key (actividad) references actividad(id);

alter table ejercicio_x_recurso
add constraint fk_recurso_ejercicioXrecurso foreign key (recurso) references recurso(id),
add constraint fk_ejercicio_ejercicioXrecurso foreign key (ejercicio) references ejercicio(id);


