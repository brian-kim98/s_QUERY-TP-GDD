CREATE TABLE DIRECCION 
(
dir_id int PRIMARY KEY,
dir_nombre_calle varchar(30) NOT NULL,
dir_numero_calle int NOT NULL,
dir_nro_piso int,
dir_departamento varchar(3),
dir_localidad varchar(20) NOT NULL
)
GO

CREATE TABLE CLIENTES
(
cli_nombreUsuario varchar(50) PRIMARY KEY,
cli_nombre varchar(50) NOT NULL,
cli_apellido varchar(50) NOT NULL,
clie_dni int NOT NULL,
clie_mail varchar(50) NOT NULL,
clie_fecha_nacimiento DATE NOT NULL,
clie_direccion_id int FOREIGN KEY references DIRECCION,
clie_codigo_postal int NOT NULL
)
GO

CREATE TABLE TELEFONOS 
(
tel_numero int PRIMARY KEY,
clie_telefono_id varchar(50) FOREIGN KEY references CLIENTES
)
GO

create table PROVEEDORES
(
prov_razon_social varchar(50),
prov_cuit char(11),
prov_nombreUsuario varchar(50) NOT NULL,
prov_mail varchar(50) NOT NULL,
prov_ciudad varchar(20) NOT NULL,
prov_rubro varchar(20) NOT NULL,
prov_telefono int FOREIGN KEY references TELEFONOS,
prov_fecha_nacimiento DATE NOT NULL,
prov_direccion_id int FOREIGN KEY references DIRECCION,
prov_codigo_postal int NOT NULL,
Primary Key (prov_razon_social, prov_cuit)
)
GO
