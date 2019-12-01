BEGIN TRANSACTION
CREATE TABLE [GD2C2019].[S_QUERY].Usuario(
	usuario_codigo INT IDENTITY(1,1) PRIMARY KEY,
	usuario_nombre VARCHAR(20) UNIQUE NOT NULL,  
	usuario_contraseña VARCHAR(256) NOT NULL,
	usuario_habilitado BIT NOT NULL,
	usuario_intentos_posibles SMALLINT DEFAULT 3
)
GO

CREATE TABLE [GD2C2019].[S_QUERY].Rubro(
	rubro_codigo INT IDENTITY(1,1) PRIMARY KEY,
	rubro_nombre NVARCHAR(100) NOT NULL
)
GO

CREATE TABLE [GD2C2019].[S_QUERY].Rol(
	rol_codigo INT IDENTITY PRIMARY KEY,
	rol_nombre VARCHAR(50) NOT NULL,
	rol_estado BIT NOT NULL DEFAULT 1
)
GO

CREATE TABLE [GD2C2019].[S_QUERY].Direccion(	
	direc_codigo INT IDENTITY(1,1) PRIMARY KEY,
	direc_localidad VARCHAR(255) NOT NULL,
	direc_calle VARCHAR(255) NOT NULL,
	direc_nro INT NOT NULL,
	direc_piso SMALLINT,
	direc_depto SMALLINT
)
GO

CREATE TABLE [GD2C2019].[S_QUERY].Funcionalidad(
	func_codigo INT IDENTITY(1,1) PRIMARY KEY,
	func_nombre VARCHAR(40) NOT NULL
)
GO

CREATE TABLE [GD2C2019].[S_QUERY].Tipo_Pago(
	tipo_pago_codigo INT IDENTITY(1,1) PRIMARY KEY,
	tipo_pago_nombre NVARCHAR(100) NOT NULL
)
GO

CREATE TABLE [GD2C2019].[S_QUERY].Cliente(
	clie_codigo INT IDENTITY(1,1) PRIMARY KEY,
	clie_nombre NVARCHAR(255) NOT NULL,
	clie_apellido NVARCHAR(255) NOT NULL,
	clie_dni NUMERIC(18,0) NOT NULL, /*unique?*/
	clie_mail NVARCHAR(255),
	clie_telefono NUMERIC(18, 0 ),
	clie_fecha_nacimiento DATETIME NOT NULL,
	clie_saldo FLOAT,
	clie_habilitado BIT NOT NULL,
	direc_codigo INT,
	usuario_codigo INT,
	FOREIGN KEY (direc_codigo) REFERENCES S_QUERY.Direccion(direc_codigo),
	FOREIGN KEY (usuario_codigo) REFERENCES S_QUERY.Usuario(usuario_codigo)
)
GO

CREATE TABLE [GD2C2019].[S_QUERY].Proveedor(
	prov_codigo INT IDENTITY(1,1) PRIMARY KEY,
	prov_razon_social NVARCHAR(255) NOT NULL,
	prov_cuit NVARCHAR(20), /*unique?*/
	prov_mail NVARCHAR(255),
	prov_ciudad VARCHAR(64) NOT NULL,
	prov_telefono NUMERIC(18,0),
	prov_nombre_contacto VARCHAR(64),
	prov_habilitado BIT NOT NULL,
	rubro_codigo INT,
	direc_codigo INT,
	usuario_codigo INT,
	FOREIGN KEY (direc_codigo) REFERENCES S_QUERY.Direccion(direc_codigo),
	FOREIGN KEY (usuario_codigo) REFERENCES S_QUERY.Usuario(usuario_codigo),
	FOREIGN KEY (rubro_codigo) REFERENCES S_QUERY.Rubro(rubro_codigo)
)
GO

CREATE TABLE [GD2C2019].[S_QUERY].Tarjeta(
	tarjeta_numero INT PRIMARY KEY,
	clie_codigo INT,
	FOREIGN KEY (clie_codigo) REFERENCES S_QUERY.Cliente(clie_codigo)
)
GO

CREATE TABLE [GD2C2019].[S_QUERY].Carga(
	carga_codigo INT IDENTITY(1,1) PRIMARY KEY,
	carga_fecha DATE,
	carga_monto numeric(18,2),
	clie_codigo INT,
	tarjeta_numero INT,
	tipo_pago_codigo INT,
	FOREIGN KEY (clie_codigo) REFERENCES S_QUERY.Cliente(clie_codigo),
	FOREIGN KEY (tarjeta_numero) REFERENCES S_QUERY.Tarjeta(tarjeta_numero),
	FOREIGN KEY (tipo_pago_codigo) REFERENCES S_QUERY.Tipo_Pago(tipo_pago_codigo)
	
)
GO

CREATE TABLE [GD2C2019].[S_QUERY].Oferta(
	oferta_codigo INT IDENTITY(1, 1) PRIMARY KEY,
	oferta_descripcion VARCHAR(255) NOT NULL,
	oferta_fecha DATE NOT NULL,
	oferta_fecha_vencimiento DATE NOT NULL,
	oferta_precio FLOAT NOT NULL,
	oferta_precio_lista FLOAT NOT NULL,
	oferta_cantidad_disponible INT NOT NULL,
	oferta_maximo_compra INT NOT NULL,
	oferta_codigo_viejo nvarchar(50),
	prov_codigo INT,
	FOREIGN KEY (prov_codigo) REFERENCES S_QUERY.Proveedor(prov_codigo)
)
GO

CREATE TABLE [GD2C2019].[S_QUERY].Factura(	
	fact_numero BIGINT NOT NULL,
	fact_fecha DATE NOT NULL,
	fact_periodo_inicio DATE,
	fact_periodo_fin DATE,
	fact_total FLOAT,
	prov_codigo INT,
	PRIMARY KEY(fact_numero),
	FOREIGN KEY (prov_codigo) REFERENCES S_QUERY.Proveedor(prov_codigo)

)
GO

CREATE TABLE [GD2C2019].[S_QUERY].Cupon(
	cupon_codigo INT IDENTITY(1,1) PRIMARY KEY,
	cupon_cantidad INT NOT NULL,
	cupon_fecha DATE NOT NULL,
	oferta_codigo INT,
	clie_codigo INT,
	fact_numero BIGINT,
	FOREIGN KEY (oferta_codigo) REFERENCES S_QUERY.Oferta(oferta_codigo),
	FOREIGN KEY (clie_codigo) REFERENCES S_QUERY.Cliente(clie_codigo),
	FOREIGN KEY (fact_numero) REFERENCES S_QUERY.Factura(fact_numero)
)
GO

CREATE TABLE [GD2C2019].[S_QUERY].Entrega(	
	entrega_codigo INT IDENTITY(1,1) PRIMARY KEY,
	entrega_fecha DATETIME NOT NULL,
	cupon_codigo INT,
	FOREIGN KEY (cupon_codigo) REFERENCES S_QUERY.Cupon(cupon_codigo)
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

COMMIT
