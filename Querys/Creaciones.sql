
CREATE TABLE [GD2C2019].[S_QUERY].Usuario(
	usuario_codigo INT PRIMARY KEY,
	usuario_nombre VARCHAR(20) NOT NULL,  
	usuario_contraseña VARCHAR(256) NOT NULL,

)
GO

CREATE TABLE [GD2C2019].[S_QUERY].Rol(
	rol_codigo INT PRIMARY KEY,
	rol_nombre VARCHAR(20) NOT NULL,
	rol_estado CHAR(1) NOT NULL
)
GO

CREATE TABLE [GD2C2019].[S_QUERY].Direccion(	
	direc_codigo INT PRIMARY KEY,
	direc_localidad VARCHAR(255) NOT NULL,
	direc_calle VARCHAR(255) NOT NULL,
	direc_nro INT NOT NULL,
	direc_piso SMALLINT,
	direc_depto SMALLINT
)
GO

CREATE TABLE [GD2C2019].[S_QUERY].Funcionalidad(
	func_codigo INT PRIMARY KEY,
	func_nombre VARCHAR(32) NOT NULL
)
GO

CREATE TABLE [GD2C2019].[S_QUERY].Tipo_Pago(
	tipo_pago_codigo INT PRIMARY KEY,
	tipo_pago_nombre VARCHAR(20) NOT NULL
)
GO

CREATE TABLE [GD2C2019].[S_QUERY].Cliente(
	clie_codigo INT PRIMARY KEY,
	clie_nombre VARCHAR(20) NOT NULL,
	clie_apellido VARCHAR(20) NOT NULL,
	clie_dni CHAR(8) NOT NULL, /*unique?*/
	clie_mail VARCHAR(64),
	clie_telefono BIGINT,
	clie_fecha_nacimiento DATE NOT NULL,
	clie_saldo FLOAT,
	direc_codigo INT,
	usuario_codigo INT,
	FOREIGN KEY (direc_codigo) REFERENCES S_QUERY.Direccion(direc_codigo),
	FOREIGN KEY (usuario_codigo) REFERENCES S_QUERY.Usuario(usuario_codigo)
)
GO

CREATE TABLE [GD2C2019].[S_QUERY].Proovedor(
	prov_codigo INT PRIMARY KEY,
	prov_razon_social VARCHAR(255) NOT NULL,
	prov_cuit CHAR(11), /*unique?*/
	prov_mail VARCHAR(64),
	prov_ciudad VARCHAR(64) NOT NULL,
	prov_telefono BIGINT,
	prov_nombre_contacto VARCHAR(64),
	prov_habilitado CHAR(1) NOT NULL,
	direc_codigo INT,
	usuario_codigo INT,
	FOREIGN KEY (direc_codigo) REFERENCES S_QUERY.Direccion(direc_codigo),
	FOREIGN KEY (usuario_codigo) REFERENCES S_QUERY.Usuario(usuario_codigo)
)
GO

CREATE TABLE [GD2C2019].[S_QUERY].Tarjeta(
	tarjeta_numero INT PRIMARY KEY,
	clie_codigo INT,
	FOREIGN KEY (clie_codigo) REFERENCES S_QUERY.Cliente(clie_codigo)
)
GO

CREATE TABLE [GD2C2019].[S_QUERY].Carga(
	carga_codigo INT PRIMARY KEY,
	carga_fecha DATE,
	carga_monto FLOAT,
	clie_codigo INT,
	tarjeta_numero INT,
	tipo_pago_codigo INT,
	FOREIGN KEY (clie_codigo) REFERENCES S_QUERY.Cliente(clie_codigo),
	FOREIGN KEY (tarjeta_numero) REFERENCES S_QUERY.Tarjeta(tarjeta_numero),
	FOREIGN KEY (tipo_pago_codigo) REFERENCES S_QUERY.Tipo_Pago(tipo_pago_codigo)
	
)
GO

CREATE TABLE [GD2C2019].[S_QUERY].Oferta(
	oferta_codigo INT PRIMARY KEY,
	oferta_numero INT NOT NULL, 
	oferta_descripcion VARCHAR(255) NOT NULL,
	oferta_fecha DATE NOT NULL,
	oferta_fecha_vencimiento DATE NOT NULL,
	oferta_precio FLOAT NOT NULL,
	oferta_precio_lista FLOAT NOT NULL,
	oferta_cantidad_disponible INT NOT NULL,
	oferta_maximo_compra INT NOT NULL,
	prov_codigo INT,
	FOREIGN KEY (prov_codigo) REFERENCES S_QUERY.Proovedor(prov_codigo)
)
GO

CREATE TABLE [GD2C2019].[S_QUERY].Entrega(	
	entrega_codigo INT PRIMARY KEY,
	entrega_fecha DATE NOT NULL,
	cupon_codigo INT,
	FOREIGN KEY (cupon_codigo) REFERENCES S_QUERY.Cupon(cupon_codigo)
)
GO

CREATE TABLE [GD2C2019].[S_QUERY].Factura(	
	fact_tipo CHAR(1),
	fact_numero BIGINT NOT NULL,
	fact_fecha DATE NOT NULL,
	fact_periodo_inicio DATE NOT NULL,
	fact_periodo_fin DATE NOT NULL,
	fact_total FLOAT NOT NULL,
	prov_codigo INT,
	PRIMARY KEY(fact_tipo, fact_numero),
	FOREIGN KEY (prov_codigo) REFERENCES S_QUERY.Proovedor(prov_codigo)

)
GO

CREATE TABLE [GD2C2019].[S_QUERY].Cupon(
	cupon_codigo INT PRIMARY KEY,
	cupon_cantidad INT NOT NULL,
	cupon_fecha DATE NOT NULL,
	oferta_codigo INT,
	clie_codigo INT,
	FOREIGN KEY (oferta_codigo) REFERENCES S_QUERY.Oferta(oferta_codigo),
	FOREIGN KEY (clie_codigo) REFERENCES S_QUERY.Cliente(clie_codigo)
)
GO

CREATE TABLE [GD2C2019].[S_QUERY].FuncionalidadXRol(
	func_codigo INT,
	rol_codigo INT,
	PRIMARY KEY(func_codigo, rol_codigo),
	FOREIGN KEY (func_codigo) REFERENCES S_QUERY.Funcionalidad(func_codigo),
	FOREIGN KEY (rol_codigo) REFERENCES S_QUERY.Rol(rol_codigo)
)
GO

CREATE TABLE [GD2C2019].[S_QUERY].RolXUsuario(	
	rol_codigo INT,
	usuario_codigo INT,
	PRIMARY KEY(rol_codigo, usuario_codigo),
	FOREIGN KEY (rol_codigo) REFERENCES S_QUERY.Rol(rol_codigo),
	FOREIGN KEY (usuario_codigo) REFERENCES S_QUERY.Usuario(usuario_codigo)
)
GO
