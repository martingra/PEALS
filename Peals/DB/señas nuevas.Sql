INSERT INTO `peals`.`senia` (`id`, `clase`, `activo`, `ruta`) VALUES ('13', 'verdad', '1', '/Content/Resources/Senias/verdad.jpg');
INSERT INTO `peals`.`senia` (`id`, `clase`, `activo`, `ruta`) VALUES ('14', 'saber', '1', '/Content/Resources/Senias/saber.jpg');
INSERT INTO `peals`.`senia` (`id`, `clase`, `activo`, `ruta`) VALUES ('15', 'por', '1', '/Content/Resources/Senias/por.jpg');
INSERT INTO `peals`.`senia` (`id`, `clase`, `activo`, `ruta`) VALUES ('16', 'palabra', '1', '/Content/Resources/Senias/palabra.jpg');
INSERT INTO `peals`.`senia` (`id`, `clase`, `activo`, `ruta`) VALUES ('17', 'oracion', '1', '/Content/Resources/Senias/oracion.jpg');
INSERT INTO `peals`.`senia` (`id`, `clase`, `activo`, `ruta`) VALUES ('18', 'menos', '1', '/Content/Resources/Senias/menos.jpg');
INSERT INTO `peals`.`senia` (`id`, `clase`, `activo`, `ruta`) VALUES ('19', 'lenguaje', '1', '/Content/Resources/Senias/lenguaje.jpg');
INSERT INTO `peals`.`senia` (`id`, `clase`, `activo`, `ruta`) VALUES ('20', 'leer', '1', '/Content/Resources/Senias/leer.jpg');
INSERT INTO `peals`.`senia` (`id`, `clase`, `activo`, `ruta`) VALUES ('21', 'estudiar', '1', '/Content/Resources/Senias/estudiar.jpg');
INSERT INTO `peals`.`senia` (`id`, `clase`, `activo`, `ruta`) VALUES ('22', 'directora', '1', '/Content/Resources/Senias/directora.jpg');
INSERT INTO `peals`.`senia` (`id`, `clase`, `activo`, `ruta`) VALUES ('23', 'dificil', '1', '/Content/Resources/Senias/dificil.jpg');
INSERT INTO `peals`.`senia` (`id`, `clase`, `activo`, `ruta`) VALUES ('24', 'clase', '1', '/Content/Resources/Senias/clase.jpg');


ALTER TABLE `peals`.`senia` 
ADD COLUMN `esCara` TINYINT(1) NULL AFTER `ruta`;


UPDATE `peals`.`senia` SET `esCara`='0' WHERE `id`='0';
UPDATE `peals`.`senia` SET `esCara`='0' WHERE `id`='1';
UPDATE `peals`.`senia` SET `esCara`='0' WHERE `id`='2';
UPDATE `peals`.`senia` SET `esCara`='0' WHERE `id`='3';
UPDATE `peals`.`senia` SET `esCara`='0' WHERE `id`='4';
UPDATE `peals`.`senia` SET `esCara`='0' WHERE `id`='5';
UPDATE `peals`.`senia` SET `esCara`='0' WHERE `id`='6';
UPDATE `peals`.`senia` SET `esCara`='0' WHERE `id`='7';
UPDATE `peals`.`senia` SET `esCara`='0' WHERE `id`='8';
UPDATE `peals`.`senia` SET `esCara`='0' WHERE `id`='9';
UPDATE `peals`.`senia` SET `esCara`='0' WHERE `id`='10';
UPDATE `peals`.`senia` SET `esCara`='0' WHERE `id`='11';
UPDATE `peals`.`senia` SET `esCara`='0' WHERE `id`='12';
UPDATE `peals`.`senia` SET `esCara`='0' WHERE `id`='13';
UPDATE `peals`.`senia` SET `esCara`='0' WHERE `id`='14';
UPDATE `peals`.`senia` SET `esCara`='0' WHERE `id`='15';
UPDATE `peals`.`senia` SET `esCara`='0' WHERE `id`='16';
UPDATE `peals`.`senia` SET `esCara`='0' WHERE `id`='17';
UPDATE `peals`.`senia` SET `esCara`='0' WHERE `id`='18';
UPDATE `peals`.`senia` SET `esCara`='0' WHERE `id`='19';
UPDATE `peals`.`senia` SET `esCara`='0' WHERE `id`='20';
UPDATE `peals`.`senia` SET `esCara`='0' WHERE `id`='21';
UPDATE `peals`.`senia` SET `esCara`='0' WHERE `id`='22';
UPDATE `peals`.`senia` SET `esCara`='0' WHERE `id`='23';
UPDATE `peals`.`senia` SET `esCara`='0' WHERE `id`='24';


INSERT INTO `peals`.`senia` (`id`, `clase`, `activo`, `ruta`, `esCara`) VALUES ('25', 'e', '1', '/Content/Resources/Senias/e.jpg', '1');
INSERT INTO `peals`.`senia` (`id`, `clase`, `activo`, `ruta`, `esCara`) VALUES ('26', 'hablar', '1', '/Content/Resources/Senias/hablar.jpg', '1');
INSERT INTO `peals`.`senia` (`id`, `clase`, `activo`, `ruta`, `esCara`) VALUES ('27', 'mate', '1', '/Content/Resources/Senias/mate.jpg', '1');


