ALTER TABLE intervalo DROP FOREIGN KEY fk_intervalo_recurso;
ALTER TABLE criterio_evaluacion DROP FOREIGN KEY fk_criterio_intervalo;
DROP TABLE intervalo;

ALTER TABLE criterio_evaluacion DROP COLUMN intervalo;
ALTER TABLE criterio_evaluacion ADD COLUMN nombre varchar(100);
ALTER TABLE criterio_evaluacion ADD COLUMN descripcion varchar(600);