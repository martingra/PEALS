ALTER TABLE peals.ejercicio_x_recurso
ADD COLUMN width VARCHAR(10) NULL AFTER `pos_left`;

ALTER TABLE peals.ejercicio_x_recurso
ADD COLUMN height VARCHAR(10) NULL AFTER `pos_left`;

ALTER TABLE peals.ejercicio
ADD COLUMN zoom VARCHAR(10) NULL AFTER `senia`;