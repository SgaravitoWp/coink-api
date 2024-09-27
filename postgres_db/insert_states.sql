\c userregistration;

DO $$
BEGIN
    -- Verifica si existen registros en la tabla 'states'
    IF EXISTS (SELECT 1 FROM states) THEN
        -- Elimina todos los registros de la tabla 'states'
        DELETE FROM states; 
    END IF;
END $$;

-- Inserta nuevos registros en la tabla 'states'
INSERT INTO states (id, name, country_id)
VALUES
('5','Antioquia','CO'),
('8','Atlantico','CO'),
('11','Bogota. d.c.','CO'),
('13','Bolivar','CO'),
('15','Boyaca','CO'),
('17','Caldas','CO'),
('18','Caqueta','CO'),
('19','Cauca','CO'),
('20','Cesar','CO'),
('23','Cordoba','CO'),
('25','Cundinamarca','CO'),
('27','Choco','CO'),
('41','Huila','CO'),
('44','La Guajira','CO'),
('47','Magdalena','CO'),
('50','Meta','CO'),
('52','Narino','CO'),
('54','Norte de Santander','CO'),
('63','Quindio','CO'),
('66','Risaralda','CO'),
('68','Santander','CO'),
('70','Sucre','CO'),
('73','Tolima','CO'),
('76','Valle del Cauca','CO'),
('81','Arauca','CO'),
('85','Casanare','CO'),
('86','Putumayo','CO'),
('88','Archipielago de San Andres. Providencia y Santa Catalina','CO'),
('91','Amazonas','CO'),
('94','Guainia','CO'),
('95','Guaviare','CO'),
('97','Vaupes','CO'),
('99','Vichada','CO'),
('101','Madrid','ES'),
('103','Barcelona','ES');