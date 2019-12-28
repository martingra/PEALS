CREATE TABLE `peals`.`senia` (
  `id` INT NOT NULL,
  `clase` VARCHAR(45) NULL,
  `activo` TINYINT(1) NULL,
  PRIMARY KEY (`id`));
  
  
  ALTER TABLE `peals`.`ejercicio` 
ADD COLUMN `senia` INT NULL AFTER `actividad`,
ADD INDEX `fk_actividad_senia_idx` (`senia` ASC);
ALTER TABLE `peals`.`ejercicio` 
ADD CONSTRAINT `fk_actividad_senia`
  FOREIGN KEY (`senia`)
  REFERENCES `peals`.`senia` (`id`)
  ON DELETE NO ACTION
  ON UPDATE NO ACTION;

  
  
  ALTER TABLE `peals`.`historial_actividad` 
ADD COLUMN `ejerciciosNoResueltos` INT NULL AFTER `tiempo`,
ADD COLUMN `totalEjercicios` INT NULL AFTER `ejerciciosNoResueltos`;
