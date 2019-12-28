
INSERT INTO `especialidad` VALUES (1,'Discapacidad Intelectual'),
								  (2,'Sordos e Hipoacúsicos'),
								  (3,'Psicopedagogía'),
								  (4,'Psicomotricidad'),
								  (5,'Sociopedagogía');
								  
INSERT INTO `tipo_usuario` VALUES (1,'Administrador'),
								  (2,'Docente'),
								  (3,'Alumno');

INSERT INTO `estado_usuario` Values (1,'Esperando Confirmacion'),
									(2,'De Alta'),
									(3,'De Baja');

INSERT INTO `estado_mensaje` Values (1,'Pendiente'),
									(2,'Leido'),
									(3,'Aceptado'),
									(4,'Rechazado');
									
INSERT INTO `tipo_mensaje` Values (1,'Mensaje'),
								  (2,'Solicitud'),
								  (3,'Notificacion');

INSERT INTO `tipo_recurso` Values (1,'Imagen'),
								  (2,'Audio'),
								  (3,'Video');
									
INSERT INTO `turno` Values (1,'Mañana'),
						   (2,'Tarde'),
						   (3,'Noche');

INSERT INTO `nivel` VALUES (1,'Inicial','Nivel Inicial'),
						   (2,'Primario','Nivel Primario'),
						   (3,'Secundario','Nivel Secundario'),
						   (4,'Terciario','Nivel Terciario'),
						   (5,'Universitario','Nivel Universitario'),
						   (6,'Otro','Otro');

INSERT INTO `pais` VALUES (1,'Argentina'),
						  (2,'Bolivia'),
						  (3,'Brasil'),
						  (4,'Chile'),
						  (5,'Colombia'),
						  (6,'Ecuador'),
						  (7,'Guatemala'),
						  (8,'Paraguay'),
						  (9,'Peru'),
						  (10,'Uruguay'),
						  (11,'Venezuela'),
						  (12, 'Otro');

INSERT INTO `provincia` VALUES (1,'Buenos Aires',1), /* ARGENTINA */
							   (2,'Catamarca',1),
							   (3,'Chaco',1),
							   (4,'Chubut',1),
							   (5,'Cordoba',1),
							   (6,'Corrientes',1),
							   (7,'Entre Rios',1),
							   (8,'Formosa',1),
							   (9,'Jujuy',1),
							   (10,'La Pampa',1),
							   (11,'La Rioja',1),
							   (12,'Mendoza',1),
							   (13,'Misiones',1),
							   (14,'Neuquen',1),
							   (15,'Rio Negro',1),
							   (16,'Salta',1),
							   (17,'San Juan',1),
							   (18,'San Luis',1),
							   (19,'Santa Cruz',1),
							   (20,'Santa Fe',1),
							   (21,'Santiago Del Estero',1),
							   (22,'Tierra Del Fuego',1),
							   (23,'Tucuman',1);
							   

INSERT INTO `localidad` VALUES (1,'Azul',1), /* Buenos Aires */
							   (2,'Puan',1),
							   (3,'La Matanza',1),
							   (4,'Tigre',1),
							   (5,'25 De Mayo',1),
							   (6,'Trenque Lauquen',1),
							   (7,'9 de Julio',1),
							   (8,'Lanus',1),
							   (9,'La Plata',1),
							   (10,'Monte',1),
							   (11,'Pehuajo',1),
							   (12,'San Isidro',1),
							   (13,'Pergamino',1),
							   (14,'Alberti',1),
							   (15,'Chascomus',1),
							   (16,'Esteban Echeverria',1),
							   (17,'Mercedes',1),
							   (18,'Bahia Blanca',1),
							   (19,'Merlo',1),
							   (20,'Junin',1),
							   (21,'Guamini',1),
							   (22,'Lujan',1),
							   (23,'Leandro N. Alem',1),
							   (24,'Matanza',1),
							   (25,'General Paz',1),
							   (26,'San Vicente',1),
							   (27,'Cañuelas',1),
							   (28,'Almirante Brown',1),
							   (29,'Cnl. De Marina L. Rosales',1),
							   (30,'Baradero',1),
							   (31,'Saavedra',1),
							   (32,'Brandsen',1),
							   (33,'General Sarmiento',1),
							   (34,'Tapalque',1),
							   (35,'Saladillo',1),
							   (36,'Magdalena',1),
							   (37,'Gonzales Chaves',1),
							   (38,'General Pinto',1),
							   (39,'Navarro',1),
							   (40,'Daireaux',1),
							   (41,'Lobos',1),
							   (42,'Coronel Dorrego',1),
							   (43,'Adolfo Alsina',1),
							   (44,'Colon',1),
							   (45,'General Arenales',1),
							   (46,'Lincoln',1),
							   (47,'Villarino',1),
							   (48,'Vicente Lopez',1),
							   (49,'Bartolome Mitre',1),
							   (50,'Exaltacion De La Cruz',1),
							   (51,'Salto',1),
							   (52,'Bragado',1),
							   (53,'Zarate',1),
							   (54,'Avellaneda',1),
							   (55,'Ayacucho',1),
							   (56,'San Andres De Giles',1),
							   (57,'Tandil',1),
							   (58,'Rivadavia',1),
							   (59,'Patagones',1),
							   (60,'Grl. Viamonte',1),
							   (61,'Cnl. De Marina Leonardo Rosales',1),
							   (62,'Balcarse',1),
							   (63,'Tres Arroyos',1),
							   (64,'General Villegas',1),
							   (65,'Lomas De Zamora',1),
							   (66,'Berisso',1),
							   (67,'Juarez',1),
							   (68,'General Pueyrredon',1),
							   (69,'Coronel Suarez',1),
							   (70,'Escobar',1),
							   (71,'Carlos Caseres',1),
							   (72,'Chivilcoy',1),
							   (73,'Berazategui',1),
							   (74,'Quilmes',1),
							   (75,'Torquinst',1),
							   (76,'3 De Febrero',1),
							   (77,'Olavarria',1),
							   (78,'Pellegrini',1),
							   (79,'General Belgrano',1),
							   (80,'Florencio Varela',1),
							   (81,'Salliquel',1),
							   (82,'Mar Chiquita',1),
							   (83,'Campana',1),
							   (84,'General Sarmiento',1),
							   (85,'Rojas',1),
							   (86,'Sarmiento',1),
							   (87,'Carmen De Areco',1),
							   (88,'Pilar',1),
							   (89,'Moron',1),
							   (90,'Castelli',1),
							   (91,'Chacabuco',1),
							   (92,'General Viamonte',1),
							   (93,'Rauch',1),
							   (94,'Necochea',1),
							   (95,'Marcos Paz',1),
							   (96,'Carlos Tejedor',1),
							   (97,'San Pedro',1),
							   (98,'General Alvarado',1),
							   (99,'San Nicolas',1),
							   (100,'Hipolito Yrigoyen',1),
							   (101,'Las Flores',1),
							   (102,'Coronel Pringles',1),
							   (103,'General San Martin',1),
							   (104,'Benito Juarez',1),
							   (105,'San Cayetano',1),
							   (106,'Dolores',1),
							   (107,'San Antonio',1),
							   (108,'Loberia',1),
							   (109,'Ramallo',1),
							   (110,'General Alvear',1),
							   (111,'Ensenada',1),
							   (112,'Tordillo',1),
							   (113,'General Guido',1),
							   (114,'General Las Heras',1),
							   (115,'General Juan Madariaga',1),
							   (116,'General La Madrid',1),
							   (117,'General Lavalle',1),
							   (118,'General Rodriguez',1),
							   (119,'General Villegas',1),
							   (120,'Bolivar',1),
							   (121,'San Fernando',1),
							   (122,'Capitan Sarmiento',1),
							   (123,'Roque Perez',1),
							   (124,'Moreno',1),
							   (125,'Laprida',1),
							   (126,'Maipu',1),
							   (127,'Suipacha',1),
							   (128,'San Antonio de Areco',1),
							   (129,'Berazategui',1),
							   (130,'Alsina',1),
							   (131,'Capital Federal',1),
							   (132,'La Plata',1),
							   (133,'Mar Del Plaza',1),
							   (134,'Otra',1);
							   
INSERT INTO `localidad` VALUES (135,'Capayan',2), /* CATAMARCA */
							   (136,'Andalgala',2),
							   (137,'El Alto',2),
							   (138,'Santa Rosa',2),
							   (139,'Ancasti',2),
							   (140,'Paclin',2),
							   (141,'Santa Maria',2),
							   (142,'Tinogasta',2),
							   (143,'La Paz',2),
							   (144,'Valle Viejo',2),
							   (145,'Antofagasta De La Sierra',2),
							   (146,'Belen',2),
							   (147,'Capital',2),
							   (148,'Fray Mamerto Esquiu',2),
							   (149,'Poman',2),
							   (150,'Ambato',2),
							   (151,'Otra',2);

INSERT INTO `localidad` VALUES (152,'Independencia',3), /* CHACO */
							   (153,'San Fernando',3),
							   (154,'Primero De Mayo',3),
							   (155,'Fray Justo Santa Maria de Oro',3),
							   (156,'Sargento Cabral',3),
							   (157,'General Guemes',3),
							   (158,'Tapenaga',3),
							   (159,'Chacabuco',3),
							   (160,'Libertador Gral. San Martin',3),
							   (161,'25 De Mayo',3),
							   (162,'12 De Octubre',3),
							   (163,'Comandante Fernandez',3),
							   (164,'Quitilipi',3),
							   (165,'Mayor Luis J. Fontana',3),
							   (166,'Libertad',3),
							   (167,'Bermejo',3),
							   (168,'Almirante Brown',3),
							   (169,'General Belgrano',3),
							   (170,'General Donovan',3),
							   (171,'San Lorenzo',3),
							   (172,'Maipu',3),
							   (173,'Resistencia',3),
							   (174,'O Higgins',3),
							   (175,'9 De Julio',3),
							   (176,'Otra',3);
							   
INSERT INTO `localidad` VALUES (177,'Rio Senguer',4), /* CHUBUT */
							   (178,'Martires',4),
							   (179,'Escalante',4),
							   (180,'Gaiman',4),
							   (181,'Sarmiento',4),
							   (182,'Cushamen',4),
							   (183,'Florentino Ameghino',4),
							   (184,'Paso De Indios',4),
							   (185,'Telsen',4),
							   (186,'Languiñeo',4),
							   (187,'Gastre',4),
							   (188,'Futaleufu',4),
							   (189,'Tehuelches',4),
							   (190,'Rawson',4),
							   (191,'Biedma',4),
							   (192,'Otra',4);
							   
INSERT INTO `localidad` VALUES (193,'Rio Cuarto',5), /* CORDOBA */
							   (194,'Totoral',5),
							   (195,'Colon',5),
							   (196,'Minas',5),
							   (197,'Punilla',5),
							   (198,'Juarez Celman',5),
							   (199,'Marcos Juarez',5),
							   (200,'San Justo',5),
							   (201,'Tercero Arriba',5),
							   (202,'Rio Seco',5),
							   (203,'Capital',5),
							   (205,'Santa Maria',5),
							   (206,'Sal Alberto',5),
							   (207,'Union',5),
							   (208,'Pocho',5),
							   (209,'Calamuchita',5),
							   (210,'General San Martin',5),
							   (211,'Rio Primero',5),
							   (212,'Cruz Del Eje',5),
							   (213,'Gral. Roca',5),
							   (214,'Sobremonte',5),
							   (215,'Rio Segundo',5),
							   (216,'Rio Tercero',5),
							   (217,'Tulumba',5),
							   (218,'San Javier',5),
							   (219,'Presidente Roque Saenz Peña',5),
							   (220,'Coronel Pringles',5),
							   (221,'Otra',5);
		
INSERT INTO `localidad` VALUES (222,'San Roque',6), /* CORRIENTES */
							   (223,'Monte Caseros',6),
							   (224,'General Alvear',6),
							   (225,'Curuzu Cuatia',6),
							   (226,'San Martin',6),
							   (227,'Mercedes',6),
							   (228,'Saladas',6),
							   (229,'Ituzaingo',6),
							   (230,'Beron De Astrada',6),
							   (231,'Bella Vista',6),
							   (232,'San Luis Del Palmar',6),
							   (233,'Capital',6),
							   (234,'Lavalle',6),
							   (235,'Paso De Los Libres',6),
							   (236,'Goya',6),
							   (237,'Empedrado',6),
							   (238,'Sauce',6),
							   (239,'General Paz',6),
							   (240,'Santo Tome',6),
							   (241,'San Miguel',6),
							   (242,'Concepcion',6),
							   (243,'Esquina',6),
							   (244,'San Cosme',6),
							   (245,'Itati',6),
							   (246,'Burucuya',6),
							   (247,'Otra',6);

INSERT INTO `localidad` VALUES (248,'Uruguay',7), /* ENTRE RIOS */
							   (249,'Nogoya',7),
							   (250,'Tala',7),
							   (251,'Gualeguay',7),
							   (252,'Diamante',7),
							   (253,'Parana',7),
							   (254,'Gualeguaychu',7),
							   (255,'Colon',7),
							   (256,'Victoria',7),
							   (257,'Villaguay',7),
							   (258,'Feliciano',7),
							   (259,'Concordia',7),
							   (260,'La Paz',7),
							   (261,'Federacion',7),
							   (262,'Federal',7),
							   (263,'Castellanos',7),
							   (264,'Otra',7);

INSERT INTO `localidad` VALUES (265,'Pillagas',8), /* FORMOSA */
							   (266,'Patiño',8),
							   (267,'Pilcomayo',8),
							   (268,'Bermejo',8),
							   (269,'Pirane',8),
							   (270,'Formosa',8),
							   (271,'Matagos',8),
							   (272,'Ramon Lista',8),
							   (273,'Pillagas',8),
							   (274,'Laishi',8),
							   (275,'Otra',8);

INSERT INTO `localidad` VALUES (276,'Ledesma',9), /* JUJUY */							   
							   (277,'Cochinoca',9),
							   (278,'El Carmen',9),
							   (279,'Tumbaya',9),
							   (280,'Capital',9),
							   (281,'Yavi',9),
							   (282,'Humahuaca',9),
							   (283,'Rinconada',9),
							   (284,'Valle Grande',9),
							   (285,'Susques',9),
							   (286,'Santa Catalina',9),
							   (287,'San Antonio',9),
							   (288,'Santa Barbara',9),
							   (289,'San Pedro',9),
							   (290,'Tilcara',9),
							   (291,'Otra',9);
							   
INSERT INTO `localidad` VALUES (292,'Hucal',10), /* LA PAMPA */
							   (293,'Realico',10),
							   (294,'Mara Co',10),
							   (295,'Quemuquemu',10),
							   (296,'Chical Co',10),
							   (297,'Guatrache',10),
							   (298,'Capital',10),
							   (299,'Caleucaleu',10),
							   (300,'Trenel',10),
							   (301,'Ultracan',10),
							   (302,'Atreuco',10),
							   (303,'Toay',10),
							   (304,'Chapadleufu',10),
							   (305,'Conelo',10),
							   (306,'Puelen',10),
							   (307,'Rancul',10),
							   (308,'Loventue',10),
							   (309,'Conhelo',10),
							   (310,'Catrilo',10),
							   (311,'Chalileo',10),
							   (312,'Lihuel Calel',10),
							   (313,'Maraco',10),
							   (314,'Curaco',10),
							   (315,'Limay Mahuida',10),
							   (316,'Otra',10);

INSERT INTO `localidad` VALUES (317,'Castro Barros',11), /* LA RIOJA */
							   (318,'General San Martin',11),
							   (319,'General Lavalle',11),
							   (320,'Arauco',11),
							   (321,'Gral. Angel V. Peñolaza',11),
							   (322,'San Blas De Los Sauces',11),
							   (323,'Independencia',11),
							   (324,'General Ocampo',11),
							   (325,'Chilecito',11),
							   (326,'Famatina',11),
							   (327,'Gral. Juan Facundo Quiroga',11),
							   (328,'Gral. Belgrano',11),
							   (329,'Gral. Sarmiento',11),
							   (330,'Capital',11),
							   (331,'Gobernador Gordillo',11),
							   (332,'Rosario Vera Peñaloza',11),
							   (333,'Gral. La Madrid',11),
							   (334,'Gral. Juan Facundo Quiroga',11),
							   (335,'Sanagasta',11),
							   (336,'Otra',11);

INSERT INTO `localidad` VALUES (337,'San Rafael',12), /* MENDOZA */
							   (338,'Lujan',12),
							   (339,'Malargue',12),
							   (340,'Guaymallen',12),
							   (341,'Lavalle',12),
							   (342,'Junin',12),
							   (343,'Tupungato',12),
							   (344,'Rivadavia',12),
							   (345,'Maipu',12),
							   (346,'Godoy Cruz',12),
							   (347,'General Alvear',12),
							   (348,'La Paz',12),
							   (349,'Tunuyan',12),
							   (350,'San Carlos',12),
							   (351,'Las Heras',12),
							   (352,'Lujan De Cuyo',12),
							   (353,'San Martin',12),
							   (354,'Santa Rosa',12),
							   (355,'Capital',12),
							   (356,'Otra',12);

INSERT INTO `localidad` VALUES (357,'25 De Mayo',13), /* MISIONES */
							   (358,'Iguazu',13),
							   (359,'El Dorado',13),
							   (360,'Leando N. Alem',13),
							   (361,'Apostoles',13),
							   (362,'Cainguas',13),
							   (363,'Concepcion',13),
							   (364,'San Pedro',13),
							   (365,'Candelaria',13),
							   (366,'Gral. Manuel Belgrano',13),
							   (367,'Obera',13),
							   (368,'Libertador Gral. San Martin',13),
							   (369,'San Ignacio',13),
							   (370,'Montecarlo',13),
							   (371,'El Guarani',13),
							   (372,'Capital',13),
							   (373,'Guarani',13),
							   (374,'San Javier',13),
							   (375,'Otra',13);

INSERT INTO `localidad` VALUES (376,'Collon Cura',14), /* NEUQUEN */
							   (377,'Alumine',14),
							   (378,'Minas',14),
							   (379,'Añelo',14),
							   (380,'Confluencia',14),
							   (381,'Chos Malal',14),
							   (382,'Picunches',14),
							   (383,'Norquin',14),
							   (384,'Pehuenches',14),
							   (385,'Loncopue',14),
							   (386,'Huiliches',14),
							   (387,'Zapala',14),
							   (388,'Catan Lil',14),
							   (389,'Los Lagos',14),
							   (390,'Picun Leufu',14),
							   (391,'Lacar',14),
							   (392,'Otra',14);

INSERT INTO `localidad` VALUES (393,'Valcheta',15), /* RIO NEGRO */
							   (394,'25 De Mayo',15),
							   (395,'El Cuy',15),
							   (396,'Ñorquinco',15),
							   (397,'General Roca',15),
							   (398,'Avellaneda',15),
							   (399,'Conesa',15),
							   (400,'Pichi Mahuida',15),
							   (401,'San Antonio',15),
							   (402,'Pilcaniyeu',15),
							   (403,'9 De Julio',15),
							   (404,'Adolfo Alsina',15),
							   (405,'Bariloche',15),
							   (406,'Otra',15);
								

INSERT INTO `localidad` VALUES (407,'La Viña',16), /* SALTA */
							   (408,'San Martin',16),
							   (409,'Oran',16),
							   (410,'Anta',16),
							   (411,'Gral. Jose De San Martin',16),
							   (412,'Guachipas',16),
							   (413,'Rosario De La Frontera',16),
							   (414,'Rivadavia',16),
							   (415,'Metan',16),
							   (416,'San Carlos',16),
							   (417,'Gral. Guemes',16),
							   (418,'Cachi',16),
							   (419,'Rosario De Lerma',16),
							   (420,'Cafayate',16),
							   (421,'Los Andes',16),
							   (422,'Capital',16),
							   (423,'Cerrillos',16),
							   (424,'Chicoana',16),
							   (425,'La Poma',16),
							   (426,'Candelaria',16),
							   (427,'Rosario',16),
							   (428,'Iruya',16),
							   (429,'La Caldera',16),
							   (430,'Molinos',16),
							   (431,'Santa Victoria',16),
							   (432,'Otra',16);

INSERT INTO `localidad` VALUES (433,'9 De Julio',17), /* SAN JUAN */
							   (434,'Jachal',17),
							   (435,'Albardon',17),
							   (436,'25 De Mayo',17),
							   (437,'Santa Lucia',17),
							   (438,'Angaco',17),
							   (439,'Iglesia',17),
							   (440,'Valle Fertil',17),
							   (441,'Calingasta',17),
							   (442,'Rivadavia',17),
							   (443,'Caucete',17),
							   (444,'Sarmiento',17),
							   (445,'Pocito',17),
							   (446,'San Martin',17),
							   (447,'Chimbas',17),
							   (448,'Ullun',17),
							   (449,'Rawson',17),
							   (450,'Capital',17),
							   (451,'Zonda',17),
							   (452,'Otra',17);


INSERT INTO `localidad` VALUES (453,'Belgrano',18), /* SAN LUIS */
							   (454,'Chacabuco',18),
							   (455,'Capital',18),
							   (456,'Gobernador Dupuy',18),
							   (457,'Gral. Pedernera',18),
							   (458,'Ayacucho',18),
							   (459,'Junin',18),
							   (460,'Coronel Pringles',18),
							   (461,'Gobernador Duval',18),
							   (462,'Iglesia',18),
							   (463,'Libertador Gral. San Martin',18),
							   (464,'Caucete',18),
							   (465,'Otra',18);

INSERT INTO `localidad` VALUES (466,'Guer Aike',19), /* SANTA CRUZ */
							   (467,'Deseado',19),
							   (468,'Rio Chico',19),
							   (469,'Magallanes',19),
							   (470,'Lago Argentino',19),
							   (471,'Corpen Aike',19),
							   (472,'Lago Buenos Aires',19),
							   (473,'Otra',19);

INSERT INTO `localidad` VALUES (474,'General Lopez',20), /* SANTA FE */
							   (475,'Rosario',20),
							   (476,'General Obligado',20),
							   (477,'Constitucion',20),
							   (478,'San Lorenzo',20),
							   (479,'San Javier',20),
							   (480,'Capital',20),
							   (481,'San Cristobal',20),
							   (482,'Iriondo',20),
							   (483,'Castellanos',20),
							   (484,'9 De Julio',20),
							   (485,'Caseros',20),
							   (486,'San Jeronimo',20),
							   (487,'Belgrano',20),
							   (488,'San Justo',20),
							   (489,'Gral. Vera',20),
							   (490,'San Martin',20),
							   (491,'Las Colonias',20),
							   (492,'Garay',20),
							   (493,'Las Colinas',20),
							   (494,'Otra',20);
								
INSERT INTO `localidad` VALUES (495,'Banda',21), /* SANTIAGO DEL ESTERO */
							   (496,'Moreno',21),
							   (497,'Alberdi',21),
							   (498,'Pellegrini',21),
							   (499,'Ojo De Agua',21),
							   (501,'Rio Hondo',21),
							   (502,'General Taboada',21),
							   (503,'Choya',21),
							   (504,'Capital',21),
							   (505,'Aguirre',21),
							   (506,'Silipica',21),
							   (507,'Belgrano',21),
							   (508,'Figueroa',21),
							   (509,'Salavina',21),
							   (510,'Quebrachos',21),
							   (511,'Robles',21),
							   (512,'Avellaneda',21),
							   (513,'Jimenez',21),
							   (514,'Atamisqui',21),
							   (515,'San Martin',21),
							   (516,'Matara',21),
							   (517,'Salayina',21),
							   (518,'Gusayan',21),
							   (519,'Copo',21),
							   (520,'Brigadier Juan Felipe Ibarra',21),
							   (521,'Dobles',21),
							   (522,'Sarmiento',21),
							   (523,'Loreto',21),
							   (524,'Mitre',21),
							   (525,'Rivadavia',21),
							   (526,'Otra',21);

INSERT INTO `localidad` VALUES (527,'Ushuaia',22), /* TIERRA DEL FUEGO */
							   (528,'Islas Del Atlantico Sur',22),
							   (529,'Sector Antartico Argentino',22),
							   (530,'Rio Grande',22),
							   (531,'Is. Del Atlantico Sur e Is. Malvinas',22),
							   (532,'Antartida Argentina',22),
							   (533,'Otra',22);

INSERT INTO `localidad` VALUES (534,'Burruyacu',23), /* TUCUMAN */
							   (535,'Trancas',23),
							   (536,'Monteros',23),
							   (537,'Leales',23),
							   (538,'Cruz Alta',23),
							   (539,'Rio Chico',23),
							   (540,'Chicligasta',23),
							   (541,'Tafi',23),
							   (542,'Graneros',23),
							   (543,'Famailla',23),
							   (544,'Capital',23),
							   (545,'Otra',23);
							   

INSERT INTO `provincia` VALUES (24,'Santa Cruz De La Sierra',2), /* BOLIVIA */
							   (25,'La Paz',2),
							   (26,'El Alto',2),
							   (27,'Cochabamba',2),
							   (28,'Oruro',2),
							   (29,'Sucre',2),
							   (30,'Potosi',2),
							   (31,'Tarija',2),
							   (32,'Otra',2);
							   
INSERT INTO `localidad` VALUES (546,'Otra',24); /* SANTA CRUZ DE LA SIERRA */
INSERT INTO `localidad` VALUES (547,'Otra',25); /* LA PAZ */
INSERT INTO `localidad` VALUES (548,'Otra',26); /* EL ALTO */
INSERT INTO `localidad` VALUES (549,'Otra',27); /* COCHABAMBA */
INSERT INTO `localidad` VALUES (550,'Otra',28); /* ORURO */
INSERT INTO `localidad` VALUES (551,'Otra',29); /* SUCRE */
INSERT INTO `localidad` VALUES (552,'Otra',30); /* POTOSI */
INSERT INTO `localidad` VALUES (554,'Otra',31); /* TARIJA */				   
INSERT INTO `localidad` VALUES (555,'Otra',32); /* OTRA */				   


INSERT INTO `provincia` VALUES (33,'Sao Paulo',3), /* BRASIL */
							   (34,'Rio De Janeiro',3),
							   (35,'Salvador',3),
							   (36,'Belo Horizonte',3),
							   (37,'Fortaleza',3),
							   (38,'Brasilia',3),
							   (39,'Recife',3),
							   (40,'Porto Alegre',3),
							   (41,'Campinas',3),
							   (42,'Campo Grande',3),
							   (43,'Santo Andre',3),
							   (44,'Porto Velho',3),
							   (45,'Florianopolis',3),
							   (46,'Santa Maria',3),
							   (47,'Otra',3);

INSERT INTO `localidad` VALUES (556,'Otra',33); /* SAO PAULO */
INSERT INTO `localidad` VALUES (557,'Otra',34); /* RIO DE JANEIRO */
INSERT INTO `localidad` VALUES (558,'Otra',35); /* SALVADOR */
INSERT INTO `localidad` VALUES (559,'Otra',36); /* BELO HORIZONTE */
INSERT INTO `localidad` VALUES (560,'Otra',37); /* FORTALEZA */
INSERT INTO `localidad` VALUES (561,'Otra',38); /* BRASILIA */
INSERT INTO `localidad` VALUES (562,'Otra',39); /* RECIFE */
INSERT INTO `localidad` VALUES (564,'Otra',40); /* PORTO ALEGRE */
INSERT INTO `localidad` VALUES (565,'Otra',41); /* CAMPINAS */				   
INSERT INTO `localidad` VALUES (566,'Otra',42); /* CAMPO GRANDE */
INSERT INTO `localidad` VALUES (567,'Otra',43); /* SANTO ANDRE */
INSERT INTO `localidad` VALUES (568,'Otra',44); /* PORTO VELHO */
INSERT INTO `localidad` VALUES (569,'Otra',45); /* FLORIANOPOLIS */
INSERT INTO `localidad` VALUES (570,'Otra',46); /* SANTA MARIA */
INSERT INTO `localidad` VALUES (571,'Otra',47); /* OTRA */




INSERT INTO `provincia` VALUES (48,'Santiago De Chile',4), /* CHILE */
							   (49,'Viña Del Mar',4),
							   (50,'Valparaiso',4),
							   (51,'Talcahuano',4),
							   (52,'San Bernardo',4),
							   (53,'Concepcion',4),
							   (54,'Valdivia',4),
							   (55,'Otra',4);

INSERT INTO `localidad` VALUES (572,'Otra',48); /* SANTIAGO DE CHILE */
INSERT INTO `localidad` VALUES (573,'Otra',49); /* VIÑA DEL MAR */
INSERT INTO `localidad` VALUES (574,'Otra',50); /* VALPARAISO */
INSERT INTO `localidad` VALUES (575,'Otra',51); /* TALCAHUANO */
INSERT INTO `localidad` VALUES (576,'Otra',52); /* SAN BERNARDO */
INSERT INTO `localidad` VALUES (577,'Otra',53); /* CONCEPCION */
INSERT INTO `localidad` VALUES (578,'Otra',54); /* VALDIVIA */
INSERT INTO `localidad` VALUES (579,'Otra',55); /* OTRA */


INSERT INTO `provincia` VALUES (56,'Santa Fe De Bogota',5), /* COLOMBIA */
							   (57,'Cali',5),
							   (58,'Medellin',5),
							   (59,'Cartagena',5),
							   (60,'Bello',5),
							   (61,'Villavicencio',5),
							   (62,'Buenaventura',5),
							   (63,'Floridablanca',5),
							   (64,'Dos Quebradas',5),
							   (65,'Cartago',5),
							   (66,'Florencia',5),
							   (67,'Giron',5),
							   (68,'Otra',5);
							   
INSERT INTO `localidad` VALUES (580,'Otra',56); /* SANTA FE DE BOGOTA */
INSERT INTO `localidad` VALUES (581,'Otra',57); /* CALI */
INSERT INTO `localidad` VALUES (582,'Otra',58); /* MEDELLIN */
INSERT INTO `localidad` VALUES (583,'Otra',59); /* CARTAGENA */
INSERT INTO `localidad` VALUES (584,'Otra',60); /* BELLO */
INSERT INTO `localidad` VALUES (585,'Otra',61); /* VILLAVICENCIO */
INSERT INTO `localidad` VALUES (586,'Otra',62); /* BUENAVENTURA */
INSERT INTO `localidad` VALUES (587,'Otra',63); /* FLORIDABLANCA */
INSERT INTO `localidad` VALUES (588,'Otra',64); /* DOS QUEBRADAS */
INSERT INTO `localidad` VALUES (589,'Otra',65); /* CARTAGO */
INSERT INTO `localidad` VALUES (590,'Otra',66); /* FLORENCIA */
INSERT INTO `localidad` VALUES (591,'Otra',67); /* GIRON */
INSERT INTO `localidad` VALUES (592,'Otra',68); /* OTRA */


INSERT INTO `provincia` VALUES (69,'Guayaquil',6), /* ECUADOR */
							   (70,'Quito',6),
							   (71,'Cuenca',6),
							   (72,'Portoviejo',6),
							   (73,'Ambato',6),
							   (74,'Duran',6),
							   (75,'Quevedo',6),
							   (76,'Milagro',6),
							   (77,'Loja',6),
							   (78,'Riobamba',6),
							   (79,'Esmeraldas',6),
							   (80,'Otra',6);

INSERT INTO `localidad` VALUES (593,'Otra',69); /* GUAYAQUIL */
INSERT INTO `localidad` VALUES (594,'Otra',70); /* QUITO */
INSERT INTO `localidad` VALUES (595,'Otra',71); /* CUENCA */
INSERT INTO `localidad` VALUES (596,'Otra',72); /* PORTOVIEJO */
INSERT INTO `localidad` VALUES (597,'Otra',73); /* AMBATO */
INSERT INTO `localidad` VALUES (598,'Otra',74); /* DURAN */
INSERT INTO `localidad` VALUES (599,'Otra',75); /* QUEVEDO */
INSERT INTO `localidad` VALUES (600,'Otra',76); /* MILAGRO */
INSERT INTO `localidad` VALUES (601,'Otra',77); /* LOJA */
INSERT INTO `localidad` VALUES (602,'Otra',78); /* RIOBAMBA */
INSERT INTO `localidad` VALUES (603,'Otra',79); /* ESMERALDAS */
INSERT INTO `localidad` VALUES (604,'Otra',80); /* OTRA */

INSERT INTO `provincia` VALUES (81,'Ciudad de Guatemala',7), /* GUATEMALA */
							   (82,'Mixco',7),
							   (83,'Villa Nueva',7),
							   (84,'Quetzaltenango',7),
							   (85,'Otra',7);

INSERT INTO `localidad` VALUES (605,'Otra',81); /* CIUDAD DE GUATEMALA */
INSERT INTO `localidad` VALUES (606,'Otra',82); /* MIXCO */
INSERT INTO `localidad` VALUES (607,'Otra',83); /* VILLA NUEVA */
INSERT INTO `localidad` VALUES (608,'Otra',84); /* QUETZALTENANGO */
INSERT INTO `localidad` VALUES (609,'Otra',85); /* OTRA */

INSERT INTO `provincia` VALUES (86,'Asuncion',8), /* PARAGUAY */
							   (87,'Ciudad Del Este',8),
							   (88,'San Lorenzo',8),
							   (89,'Lambare',8),
							   (90,'Fernando De La Mora',8),
							   (91,'Otra',8);

INSERT INTO `localidad` VALUES (610,'Otra',86); /* ASUNCION */
INSERT INTO `localidad` VALUES (611,'Otra',87); /* CIUDAD DEL ESTE */
INSERT INTO `localidad` VALUES (612,'Otra',88); /* SAN LORENZO */
INSERT INTO `localidad` VALUES (613,'Otra',89); /* LAMBARE */
INSERT INTO `localidad` VALUES (614,'Otra',90); /* FERNANDO DE LA MORA */
INSERT INTO `localidad` VALUES (615,'Otra',91); /* OTRA */


INSERT INTO `provincia` VALUES (92,'Lima',9), /* PERU */
							   (93,'Arequipa',9),
							   (94,'Chiclayo',9),
							   (95,'Callao',9),
							   (96,'Iquitos',9),
							   (97,'Huancayo',9),
							   (98,'Piura',9),
							   (99,'Juliaca',9),
							   (100,'Huanuco',9),
							   (101,'Ayacucho',9),
							   (102,'Puno',9),
							   (103,'Castilla',9),
							   (104,'Otra',9);
							   
INSERT INTO `localidad` VALUES (616,'Otra',92); /* LIMA */
INSERT INTO `localidad` VALUES (617,'Otra',93); /* AREQUIPA */
INSERT INTO `localidad` VALUES (618,'Otra',94); /* CHICLAYO */
INSERT INTO `localidad` VALUES (619,'Otra',95); /* CALLAO */
INSERT INTO `localidad` VALUES (620,'Otra',96); /* IQUITOS */
INSERT INTO `localidad` VALUES (621,'Otra',97); /* HUANCAYO */
INSERT INTO `localidad` VALUES (622,'Otra',98); /* PIURA */
INSERT INTO `localidad` VALUES (623,'Otra',99); /* JULIACA */
INSERT INTO `localidad` VALUES (624,'Otra',100); /* HUANUCO */
INSERT INTO `localidad` VALUES (625,'Otra',101); /* AYACUCHO */
INSERT INTO `localidad` VALUES (626,'Otra',102); /* PUNO */
INSERT INTO `localidad` VALUES (627,'Otra',103); /* CASTILLA */
INSERT INTO `localidad` VALUES (628,'Otra',104); /* OTRA */
							   

INSERT INTO `provincia` VALUES (105,'Montevideo',10), /* URUGUAY */
							   (106,'Maldonado',10),
							   (107,'La Valleja',10),
							   (108,'Rocha',10),
							   (109,'San Jose',10),
							   (110,'Colonia',10),
							   (111,'Florida',10),
							   (112,'Durazno',10),
							   (113,'Rio Negro',10),
							   (114,'Cerro Largo',10),
							   (115,'Otra',10);

INSERT INTO `localidad` VALUES (629,'Otra',105); /* MONTEVIDEO */
INSERT INTO `localidad` VALUES (630,'Otra',106); /* MALDONADO */
INSERT INTO `localidad` VALUES (631,'Otra',107); /* LA VALLEJA */
INSERT INTO `localidad` VALUES (632,'Otra',108); /* ROCHA */
INSERT INTO `localidad` VALUES (633,'Otra',109); /* SAN JOSE */
INSERT INTO `localidad` VALUES (634,'Otra',110); /* COLONIA */
INSERT INTO `localidad` VALUES (635,'Otra',111); /* FLORIDA */
INSERT INTO `localidad` VALUES (636,'Otra',112); /* DURAZNO */
INSERT INTO `localidad` VALUES (637,'Otra',113); /* RIO NEGRO */
INSERT INTO `localidad` VALUES (638,'Otra',114); /* CERRO LARGO */
INSERT INTO `localidad` VALUES (639,'Otra',115); /* OTRA */


INSERT INTO `provincia` VALUES (116,'Caracas',11), /* VENEZUELA */
							   (117,'Maracaibo',11),
							   (118,'Barquisimeto',11),
							   (119,'Valencia',11),
							   (120,'Ciudad Guayana',11),
							   (121,'Maracay',11),
							   (122,'San Cristobal',11),
							   (123,'Ciudad Bolivar',11),
							   (124,'Merida',11),
							   (125,'Puerto Cabello',11),
							   (126,'Santa Ana De Coro',11),
							   (127,'El Tigre',11),
							   (128,'San Felipe',11),
							   (129,'San Fernando de Apure',11),
							   (130,'Valle De La Pascua',11),
							   (131,'El Limon',11),
							   (132,'Otra',11);
							   
INSERT INTO `localidad` VALUES (640,'Otra',116); /* CARACAS */
INSERT INTO `localidad` VALUES (641,'Otra',117); /* MARACAIBO */
INSERT INTO `localidad` VALUES (642,'Otra',118); /* BARQUISIMETO */
INSERT INTO `localidad` VALUES (643,'Otra',119); /* VALENCIA */
INSERT INTO `localidad` VALUES (644,'Otra',120); /* CIUDAD GUAYANA */
INSERT INTO `localidad` VALUES (645,'Otra',121); /* MARACAY */
INSERT INTO `localidad` VALUES (646,'Otra',122); /* SAN CRISTOBAL */
INSERT INTO `localidad` VALUES (647,'Otra',123); /* CIUDAD BOLIVAR */
INSERT INTO `localidad` VALUES (648,'Otra',124); /* MERIDA */
INSERT INTO `localidad` VALUES (649,'Otra',125); /* PUERTO CABELLO */
INSERT INTO `localidad` VALUES (650,'Otra',126); /* SANTA ANA DE CORO */
INSERT INTO `localidad` VALUES (651,'Otra',127); /* EL TIGRE */
INSERT INTO `localidad` VALUES (652,'Otra',128); /* SAN FELIPE */
INSERT INTO `localidad` VALUES (653,'Otra',129); /* SAN FERNANDO DE APURE */
INSERT INTO `localidad` VALUES (654,'Otra',130); /* VALLE DE LA PASCUA */
INSERT INTO `localidad` VALUES (655,'Otra',131); /* EL LIMON */
INSERT INTO `localidad` VALUES (656,'Otra',132); /* OTRA */
							   
INSERT INTO `provincia` VALUES (133,'Otra',12); /* OTRA */

INSERT INTO `localidad` VALUES (657,'Otra',133); /* OTRA */