--...................................DROPS POR SI EXISTEN LAS TABLAS.....................................--
if exists (select * from sys.schemas where name = 'S_QUERY')
	BEGIN
		if exists(select * from sys.tables where object_name(object_id)='FuncionalidadXRol'and schema_name(schema_id)='S_QUERY')
			drop table  S_QUERY.FuncionalidadXRol
		if exists(select * from sys.tables where object_name(object_id)='RolXUsuario'and schema_name(schema_id)='S_QUERY')
			drop table  S_QUERY.RolXUsuario
		if exists(select * from sys.tables where object_name(object_id)='Funcionalidad'and schema_name(schema_id)='S_QUERY')
			drop table  S_QUERY.Funcionalidad
		if exists(select * from sys.tables where object_name(object_id)='Rol'and schema_name(schema_id)='S_QUERY')
			drop table  S_QUERY.Rol
		if exists(select * from sys.tables where object_name(object_id)='Carga'and schema_name(schema_id)='S_QUERY')
			drop table  S_QUERY.Carga
		if exists(select * from sys.tables where object_name(object_id)='Tipo_Pago'and schema_name(schema_id)='S_QUERY')
			drop table  S_QUERY.Tipo_Pago
		if exists(select * from sys.tables where object_name(object_id)='Tarjeta'and schema_name(schema_id)='S_QUERY')
			drop table  S_QUERY.Tarjeta
		if exists(select * from sys.tables where object_name(object_id)='Entrega'and schema_name(schema_id)='S_QUERY')
			drop table  S_QUERY.Entrega
		if exists(select * from sys.tables where object_name(object_id)='Cupon'and schema_name(schema_id)='S_QUERY')
			drop table  S_QUERY.Cupon
		if exists(select * from sys.tables where object_name(object_id)='Factura'and schema_name(schema_id)='S_QUERY')
			drop table  S_QUERY.Factura
		if exists(select * from sys.tables where object_name(object_id)='Oferta'and schema_name(schema_id)='S_QUERY')
			drop table  S_QUERY.Oferta
		if exists(select * from sys.tables where object_name(object_id)='Proveedor'and schema_name(schema_id)='S_QUERY')
			drop table  S_QUERY.Proveedor
		if exists(select * from sys.tables where object_name(object_id)='Cliente'and schema_name(schema_id)='S_QUERY')
			drop table  S_QUERY.Cliente
		if exists(select * from sys.tables where object_name(object_id)='Rubro'and schema_name(schema_id)='S_QUERY')
			drop table  S_QUERY.Rubro
		if exists(select * from sys.tables where object_name(object_id)='Direccion'and schema_name(schema_id)='S_QUERY')
			drop table  S_QUERY.Direccion
		if exists(select * from sys.tables where object_name(object_id)='Usuario'and schema_name(schema_id)='S_QUERY')
			drop table  S_QUERY.Usuario
	END
ELSE
	BEGIN
		exec('create schema S_QUERY authorization [gdCupon2019]')
		print 'Esquema S_QUERY creado'
	END
GO

--..............................................CREACION DE TABLAS..................................................--
BEGIN TRANSACTION
CREATE TABLE [GD2C2019].[S_QUERY].Usuario(
	usuario_codigo INT IDENTITY(1,1) PRIMARY KEY,
	usuario_nombre VARCHAR(20) UNIQUE NOT NULL,  
	usuario_contraseña VARCHAR(256) NOT NULL,
	usuario_habilitado BIT NOT NULL,
	usuario_intentos_posibles SMALLINT DEFAULT 3,
	usuario_baja_logica CHAR DEFAULT 'N'
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
	rol_habilitado BIT DEFAULT 1,
	PRIMARY KEY(rol_codigo, usuario_codigo),
	FOREIGN KEY (rol_codigo) REFERENCES S_QUERY.Rol(rol_codigo),
	FOREIGN KEY (usuario_codigo) REFERENCES S_QUERY.Usuario(usuario_codigo)
)
GO

COMMIT


--................................................INSERTS...............................................--

USE GD2C2019
BEGIN TRANSACTION

/*-------------------------------------------Rubros-----------------------------------------------------------*/
		INSERT INTO S_QUERY.Rubro(rubro_nombre)
		SELECT DISTINCT Provee_Rubro FROM gd_esquema.Maestra WHERE
		Provee_Rubro IS NOT NULL

		INSERT INTO S_QUERY.Rol(rol_nombre)
		VALUES 
		('Cliente'),
		('Proveedor'),
		('Administrativo')
		

/*-------------------------------------------Proveedores-------------------------------------------------------*/
		INSERT INTO S_QUERY.Proveedor (prov_razon_social , prov_telefono, prov_cuit, rubro_codigo, prov_ciudad, prov_habilitado)
			SELECT DISTINCT Provee_RS, 
			Provee_Telefono , Provee_CUIT,
			(SELECT rubro_codigo FROM S_QUERY.Rubro WHERE rubro_nombre = Provee_Rubro ),
			 Provee_Ciudad, 1 FROM GD2C2019.gd_esquema.Maestra
			WHERE Provee_RS IS NOT NUll 
			AND Provee_Rubro IS NOT NULL 
			AND Provee_Telefono IS NOT NULL 
			AND Provee_CUIT IS NOT NULL
			AND Provee_Dom IS NOT NULL 
			AND Provee_Ciudad IS NOT NULL
		BEGIN

			DECLARE @cuit as NVARCHAR(20)
			DECLARE @direccion as NVARCHAR(100)
			DECLARE @numero as NVARCHAR(4)
			DECLARE @localidad as NVARCHAR(255)
			DECLARE @idDireccion as INT
			DECLARE @idUsuario as INT
			DECLARE @rolProv as INT
			SET @rolProv = (SELECT rol_codigo FROM S_QUERY.Rol WHERE rol_nombre = 'Proveedor')
			DECLARE cursor_proveedor CURSOR FOR			
			SELECT g.cuit as documento,g.localidad,
				substring(g.direc,1,
				len(g.direc) - 5 + charindex(' ',substring(g.direc,len(g.direc) - 3,4)) 
				) as direccion,
				substring(g.direc, len(g.direc) - 3 + charindex(' ',substring(g.direc,len(g.direc) - 3,4)),4) as numero
			FROM 
				(SELECT DISTINCT Provee_CUIT as cuit, Provee_Dom as direc, Provee_Ciudad as localidad FROM gd_esquema.Maestra WHERE Provee_CUIT IS NOT NULL) g 
			OPEN cursor_proveedor
			FETCH NEXT FROM cursor_proveedor INTO @cuit, @localidad, @direccion, @numero
			WHILE @@fetch_status = 0
			BEGIN
				INSERT INTO S_QUERY.Direccion(direc_localidad, direc_calle, direc_nro)
					VALUES(@localidad, @direccion, @numero)
				SELECT @idDireccion = SCOPE_IDENTITY()
				UPDATE S_QUERY.Proveedor
					SET direc_codigo = @idDireccion
					WHERE prov_cuit = @cuit

				INSERT INTO S_QUERY.Usuario(usuario_nombre,usuario_contraseña, usuario_habilitado)
					VALUES(@cuit, lower(convert(varchar(256),HASHBYTES('SHA2_256',@cuit),2)),1)
				 SELECT @idUsuario = SCOPE_IDENTITY()
				 UPDATE S_QUERY.Proveedor
					SET usuario_codigo = @idUsuario
					WHERE prov_cuit = @cuit

				INSERT INTO S_QUERY.RolXUsuario(rol_codigo,usuario_codigo)
					VALUES(@rolProv,@idUsuario)

				FETCH NEXT FROM cursor_proveedor INTO @cuit,@localidad, @direccion, @numero
			END
			CLOSE cursor_proveedor
			DEALLOCATE cursor_proveedor

		END


/*-------------------------------------------Clientes-------------------------------------------------------*/
		INSERT INTO S_QUERY.Cliente (clie_nombre, clie_apellido, clie_dni, clie_mail, clie_telefono, clie_fecha_nacimiento, clie_saldo,
									 clie_habilitado)
			SELECT DISTINCT cli_nombre, 
				cli_apellido,cli_dni, cli_mail, Cli_Telefono, Cli_Fecha_Nac, 200.0, 1 FROM gd_esquema.Maestra
			
		BEGIN
			
			DECLARE @dni as Numeric(18,0)
			DECLARE @direccion_cliente as NVARCHAR(255)
			DECLARE @numero_cliente as NVARCHAR(4)
			DECLARE @localidad_cliente as NVARCHAR(255)
			DECLARE @idDireccion_cliente as INT
			DECLARE @idUsuarioC as INT
			DECLARE @rolCli as INT
			SET @rolCli = (SELECT rol_codigo FROM S_QUERY.Rol WHERE rol_nombre = 'Cliente')
			DECLARE cursor_cliente CURSOR FOR			
			SELECT g.dni as documento,g.localidad,
				substring(g.direc,1,
				len(g.direc) - 5 + charindex(' ',substring(g.direc,len(g.direc) - 3,4)) 
				) as direccion,
				substring(g.direc, len(g.direc) - 3 + charindex(' ',substring(g.direc,len(g.direc) - 3,4)),4) as numero
			FROM 
				(SELECT DISTINCT Cli_Dni as dni, Cli_Direccion as direc, Cli_Ciudad as localidad FROM gd_esquema.Maestra WHERE Cli_Dni IS NOT NULL) g 
			OPEN cursor_cliente	
			FETCH NEXT FROM cursor_cliente INTO @dni, @localidad_cliente, @direccion_cliente, @numero_cliente
			WHILE @@fetch_status = 0
			BEGIN
				INSERT INTO S_QUERY.Direccion(direc_localidad, direc_calle, direc_nro)
					VALUES(@localidad_cliente, @direccion_cliente, @numero_cliente)
				SELECT @idDireccion_cliente = SCOPE_IDENTITY()
				UPDATE S_QUERY.Cliente
					SET direc_codigo = @idDireccion_cliente
					WHERE clie_dni = @dni
				INSERT INTO S_QUERY.Usuario(usuario_nombre,usuario_contraseña, usuario_habilitado)
					VALUES(@dni, lower(convert(varchar(256),HASHBYTES('SHA2_256',convert(varchar,@dni)),2)),1)
				 SELECT @idUsuarioC = SCOPE_IDENTITY()
				 UPDATE S_QUERY.Cliente
					SET usuario_codigo = @idUsuarioC
					WHERE clie_dni = @dni

				INSERT INTO S_QUERY.RolXUsuario(rol_codigo, usuario_codigo)
					VALUES(@rolCli,@idUsuarioC)

				FETCH NEXT FROM cursor_cliente INTO @dni,@localidad_cliente, @direccion_cliente, @numero_cliente
			END
			CLOSE cursor_cliente
			DEALLOCATE cursor_cliente

		END


/*-------------------------------------------Tipo de Pago-------------------------------------------------------*/
		INSERT INTO S_QUERY.Tipo_Pago (tipo_pago_nombre)
			SELECT DISTINCT Tipo_Pago_Desc FROM gd_esquema.Maestra WHERE
			Tipo_Pago_Desc IS NOT NULL


/*-------------------------------------------Cargas-------------------------------------------------------*/
		INSERT INTO S_QUERY.Carga(carga_fecha, carga_monto, clie_codigo, tipo_pago_codigo)
			SELECT Carga_Fecha, Carga_Credito,
				(SELECT DISTINCT clie_codigo FROM S_QUERY.Cliente
				WHERE clie_dni = Cli_Dni AND Cli_Dni IS NOT NULL),
				(SELECT DISTINCT tipo_pago_codigo FROM S_QUERY.Tipo_Pago
				WHERE tipo_pago_nombre = Tipo_Pago_Desc AND Tipo_Pago_Desc IS NOT NULL)
			FROM gd_esquema.Maestra
			WHERE Carga_Fecha IS NOT NULL AND Carga_Credito IS NOT NULL
		

/*-------------------------------------------Ofertas-------------------------------------------------------*/
		INSERT INTO S_QUERY.Oferta(oferta_codigo_viejo, oferta_descripcion, oferta_fecha, oferta_fecha_vencimiento, oferta_precio,
									oferta_precio_lista, oferta_cantidad_disponible, oferta_maximo_compra, prov_codigo)
			SELECT DISTINCT Oferta_Codigo, Oferta_Descripcion, Oferta_Fecha, Oferta_Fecha_Venc, Oferta_Precio,
							Oferta_Precio_Ficticio, Oferta_Cantidad /*habiamos puesto 0 antes*/, Oferta_Cantidad,
							(SELECT prov_codigo FROM S_QUERY.Proveedor
							 WHERE prov_cuit = Provee_CUIT)
			FROM gd_esquema.Maestra
			WHERE Oferta_Entregado_Fecha IS NULL
			AND Factura_Nro IS NULL
			AND Oferta_Codigo IS NOT NULL
			ORDER BY Oferta_Codigo ASC
			/*oferta cantidad maxima y oferta cantidad (stock) las pusimos como iguales*/

/*-------------------------------------------Facturas-------------------------------------------------------*/
		INSERT INTO S_QUERY.Factura(fact_numero, fact_fecha, prov_codigo, fact_total)
			SELECT DISTINCT m.Factura_Nro, m.Factura_Fecha,
				 (SELECT prov_codigo FROM S_QUERY.Proveedor
				  WHERE prov_cuit = m.Provee_CUIT AND prov_razon_social = m.Provee_RS
				 ) as 'Codigo Proveedor',
				 (SELECT SUM(k.Oferta_Precio) as 'Total'
					FROM gd_esquema.Maestra k
					WHERE Factura_Nro IS NOT NULL
					AND k.Factura_Nro = m.Factura_Nro
					)  as 'total'
				FROM gd_esquema.Maestra m
				WHERE Factura_Nro IS NOT NULL
				ORDER BY Factura_Nro


/*-------------------------------------------Cupones-------------------------------------------------------*/
		INSERT INTO S_QUERY.Cupon(cupon_cantidad, cupon_fecha, oferta_codigo, clie_codigo, fact_numero)
					SELECT 1, compras.fecha,
						(SELECT oferta_codigo FROM S_QUERY.Oferta WHERE oferta_codigo_viejo = compras.codigo), 
						(SELECT clie_codigo FROM S_QUERY.Cliente WHERE clie_dni = compras.dni)
						,(SELECT t.Factura_Nro FROM gd_esquema.Maestra t
						 WHERE t.Oferta_Codigo = codigo AND 
						       t.Oferta_Fecha_Compra = fecha AND
							   t.Cli_Dni = dni AND
							   t.Factura_Nro IS NOT NULL
						)
					FROM (SELECT DISTINCT Oferta_Codigo as codigo, Oferta_Fecha_Compra as fecha, Cli_Dni  as dni
							FROM gd_esquema.Maestra
							WHERE Oferta_Entregado_Fecha IS NULL
							AND Factura_Nro IS NULL
							AND Oferta_Codigo IS NOT NULL
						) compras


/*-------------------------------------------Entregas-------------------------------------------------------*/

		INSERT INTO S_QUERY.Entrega(entrega_fecha, cupon_codigo)
			SELECT Oferta_Entregado_Fecha,
			(SELECT c.cupon_codigo
			FROM S_QUERY.Cupon c JOIN S_QUERY.Oferta o on c.oferta_codigo = o.oferta_codigo
			WHERE o.oferta_codigo_viejo = maestra.Oferta_Codigo AND c.cupon_fecha = maestra.Oferta_Fecha_Compra)
			FROM gd_esquema.Maestra maestra
			WHERE Oferta_Entregado_Fecha IS NOT NULL

/*-------------------------------------------Funcionalidad-------------------------------------------------------*/
		INSERT INTO S_QUERY.Funcionalidad(func_nombre)
			VALUES ('Login y Seguridad'), 
			('ABM de Rol'),
			('Registro de Usuario'),
			('ABM de Cliente'),
			('ABM de Proveedor'),
			('Cargar Credito'),
			('Confeccion y publicacion de Ofertas'),
			('Comprar Oferta'),
			('Entrega/Consumo de Oferta'),
			('Facturacion a Proveedor'),
			('Listado Estadistico')


/*-------------------------------------------FuncionalidadXRol-------------------------------------------------------*/
		INSERT INTO S_QUERY.FuncionalidadXRol(func_codigo, rol_codigo)
			VALUES
				('2' , (SELECT TOP 1 rol_codigo FROM S_QUERY.Rol WHERE rol_nombre = 'Administrativo' )),
				('3' , (SELECT TOP 1 rol_codigo FROM S_QUERY.Rol WHERE rol_nombre = 'Administrativo' )),
				('5' , (SELECT TOP 1 rol_codigo FROM S_QUERY.Rol WHERE rol_nombre = 'Administrativo' )),
				('8' , (SELECT TOP 1 rol_codigo FROM S_QUERY.Rol WHERE rol_nombre = 'Cliente' )),
				('6' , (SELECT TOP 1 rol_codigo FROM S_QUERY.Rol WHERE rol_nombre = 'Cliente' )),
				('4' , (SELECT TOP 1 rol_codigo FROM S_QUERY.Rol WHERE rol_nombre = 'Administrativo' )),
				('7' , (SELECT TOP 1 rol_codigo FROM S_QUERY.Rol WHERE rol_nombre = 'Proveedor' )),
				('9' , (SELECT TOP 1 rol_codigo FROM S_QUERY.Rol WHERE rol_nombre = 'Proveedor' )),	
				('10' , (SELECT TOP 1 rol_codigo FROM S_QUERY.Rol WHERE rol_nombre = 'Administrativo' )),			
				('11' , (SELECT TOP 1 rol_codigo FROM S_QUERY.Rol WHERE rol_nombre = 'Administrativo' ))

		INSERT INTO S_QUERY.Usuario(usuario_nombre,usuario_contraseña, usuario_habilitado)
		VALUES('admin',lower(convert(varchar(256),HASHBYTES('SHA2_256',convert(varchar,'admin')),2)),1)
		
		INSERT INTO S_QUERY.RolXUsuario(rol_codigo,usuario_codigo)
		VALUES((SELECT rol_codigo FROM S_QUERY.Rol WHERE rol_nombre = 'Administrativo'), 
			   (SELECT usuario_codigo FROM S_QUERY.Usuario WHERE usuario_nombre = 'admin'))	
COMMIT


/*-----------------------------------------------------------------------------------------------------------*/
/*----------------------------------------------Procedures---------------------------------------------------*/
/*-----------------------------------------------------------------------------------------------------------*/
USE GD2C2019
IF EXISTS (SELECT name FROM sysobjects WHERE name='crearDireccion' AND type='p')
	DROP PROCEDURE S_QUERY.crearDireccion
GO
CREATE PROCEDURE S_QUERY.crearDireccion(@direc_localidad VARCHAR(255), @direc_calle VARCHAR(255), @direc_nro INT, @direc_piso SMALLINT, @direc_depto SMALLINT)
AS
	BEGIN
		DECLARE @idDireccion int
		INSERT INTO S_QUERY.Direccion(direc_localidad, direc_calle, direc_nro, direc_piso, direc_depto)
		VALUES(@direc_localidad, @direc_calle, @direc_nro, @direc_piso, @direc_depto)
		SELECT @idDireccion = SCOPE_IDENTITY()

		RETURN @idDireccion
	END
GO

/************************************************************LOGIN Y SEGURIDAD********************************************************************/
USE GD2C2019
IF EXISTS (SELECT name FROM sysobjects WHERE name='loginYSeguridad' AND type='p')
	DROP PROCEDURE S_QUERY.loginYSeguridad
GO
CREATE PROCEDURE S_QUERY.loginYSeguridad(@usuario varchar(20), @contraseña_ingresada varchar(256))
AS
	BEGIN
		DECLARE @intentos_posibles smallint
		DECLARE @contra_hasheada varchar(256)
		DECLARE @contra_real varchar(256)
		DECLARE @valor_retorno smallint
		DECLARE @habilitado bit

		SET @intentos_posibles = (select usuario_intentos_posibles from S_QUERY.Usuario where usuario_nombre = @usuario)
		SET @contra_hasheada = lower(convert(varchar(256),HASHBYTES('SHA2_256',@contraseña_ingresada),2))
		SET @contra_real = (select usuario_contraseña from S_QUERY.Usuario where usuario_nombre = @usuario)
		SET @habilitado = (select usuario_habilitado from S_QUERY.Usuario where usuario_nombre = @usuario)

		IF NOT EXISTS(select 1 from S_QUERY.Usuario where usuario_nombre = @usuario /*AND usuario_habilitado = 1*/)
			SET @valor_retorno = -2

		ELSE IF (@intentos_posibles > 0 and @habilitado = 1)
			BEGIN
				IF(@contra_real = @contra_hasheada)
					BEGIN
						SET @valor_retorno = 1
						UPDATE S_QUERY.Usuario
							SET usuario_intentos_posibles = 3
							WHERE usuario_nombre = @usuario
					END
				ELSE
					BEGIN
						SET @valor_retorno = 0
						UPDATE S_QUERY.Usuario
							SET usuario_intentos_posibles = usuario_intentos_posibles - 1
							WHERE usuario_nombre = @usuario
					END
			END
		ELSE
			BEGIN
				UPDATE S_QUERY.Usuario
				SET usuario_habilitado = 0
				WHERE usuario_nombre = @usuario
				SET @valor_retorno = -1
			END
	END
	RETURN @valor_retorno
GO

/************************************************************REGISTRO USUARIO*********************************************************************/

USE GD2C2019
IF EXISTS (SELECT name FROM sysobjects WHERE name='verificarUsuario' )
	DROP FUNCTION S_QUERY.verificarUsuario
GO
CREATE FUNCTION S_QUERY.verificarUsuario(@usuario varchar(20)) RETURNS INT
AS
	BEGIN
		DECLARE @valor_retorno int
	
	BEGIN
		IF EXISTS(SELECT 1 FROM S_QUERY.Usuario WHERE usuario_nombre = @usuario)
			SET @valor_retorno = 1
		ELSE
			SET @valor_retorno = 0
	END

	
	RETURN @valor_retorno
	END
GO
USE GD2C2019
IF EXISTS (SELECT name FROM sysobjects WHERE name='sosUsuarioAdministrador' )
	DROP FUNCTION S_QUERY.sosUsuarioAdministrador
GO
CREATE FUNCTION S_QUERY.sosUsuarioAdministrador(@usuario_codigo int) RETURNS INT
AS
	BEGIN
		DECLARE @valor_retorno INT

	BEGIN
		IF EXISTS
		(
		SELECT 1 FROM S_QUERY.RolXUsuario rxu
		JOIN Rol r ON r.rol_codigo = rxu.rol_codigo
		WHERE usuario_codigo = @usuario_codigo AND r.rol_nombre = 'Administrativo'
		)
			SET @valor_retorno = 1
		
		ELSE
			SET @valor_retorno = -1
	END
	
	RETURN @valor_retorno

	END
GO
		


/*-----------------------------------------------------------ABM Proveedor-----------------------------------------------------------------------*/


USE GD2C2019
IF EXISTS (SELECT name FROM sysobjects WHERE name='bajaLogicaProveedor' AND type='p')
	DROP PROCEDURE S_QUERY.bajaLogicaProveedor
GO
CREATE PROCEDURE S_QUERY.bajaLogicaProveedor(@usuario_codigo_bajaproveedor INT)
AS
	BEGIN

		DECLARE @codigo_rol_proveedor INT
		SET @codigo_rol_proveedor = (SELECT TOP 1 rol_codigo FROM S_QUERY.Rol WHERE rol_nombre = 'Proveedor' )

		UPDATE S_QUERY.Proveedor
		SET prov_habilitado = 0
		WHERE prov_codigo = @usuario_codigo_bajaproveedor

		UPDATE S_QUERY.RolXUsuario
		SET rol_habilitado = 0
		WHERE usuario_codigo = @usuario_codigo_bajaproveedor
		AND rol_codigo = @codigo_rol_proveedor


	END
GO


USE GD2C2019
IF EXISTS (SELECT name FROM sysobjects WHERE name='modificarProveedor' AND type='p')
	DROP PROCEDURE S_QUERY.modificarProveedor
GO
CREATE PROCEDURE S_QUERY.modificarProveedor(@prov_codigo_modif INT, @prov_razon_social_modif NVARCHAR(255), @prov_cuit_modif NVARCHAR(20), @prov_mail_modif NVARCHAR(255)
		, @prov_telefono_modif NUMERIC(18,0) , @prov_nombre_contacto_modif VARCHAR(64), @prov_habilitado_modif BIT, @prov_calle_modif VARCHAR(255) , @prov_localidad_modif VARCHAR(255) , 
		@prov_nro_modif INT , @prov_depto_modif SMALLINT , @prov_piso_modif SMALLINT)
AS
	BEGIN
		DECLARE @codigo_direccion INT;

		
		DECLARE @usuario_proveedor_modif INT
		SET @usuario_proveedor_modif = (SELECT TOP 1 usuario_codigo FROM S_QUERY.Proveedor WHERE  prov_codigo = @prov_codigo_modif)

		DECLARE @codigo_rol_proveedor_modif INT
		SET @codigo_rol_proveedor_modif = (SELECT TOP 1 rol_codigo FROM S_QUERY.Rol WHERE rol_nombre = 'Proveedor' )

		UPDATE S_QUERY.RolXUsuario
		SET rol_habilitado = @prov_habilitado_modif 
		WHERE usuario_codigo = @usuario_proveedor_modif
		AND rol_codigo = @codigo_rol_proveedor_modif

		UPDATE S_QUERY.Proveedor 
			SET prov_razon_social = @prov_razon_social_modif, 
			prov_cuit = @prov_cuit_modif,
			prov_mail = @prov_mail_modif,
			prov_telefono= @prov_telefono_modif,
			prov_habilitado = @prov_habilitado_modif,
			prov_nombre_contacto = @prov_nombre_contacto_modif 
			WHERE prov_codigo = @prov_codigo_modif;

		SET @codigo_direccion = (SELECT TOP 1 direc_codigo FROM S_QUERY.Proveedor WHERE prov_codigo = @prov_codigo_modif);

		UPDATE S_QUERY.Direccion
			SET direc_calle = @prov_calle_modif,
			direc_localidad = @prov_localidad_modif,
			direc_nro = @prov_nro_modif,
			direc_piso = @prov_piso_modif,
			direc_depto=  @prov_depto_modif
			WHERE direc_codigo = @codigo_direccion;


	END
GO

/*-----------------------------------------------------------ABM Cliente-----------------------------------------------------------------------*/
USE GD2C2019
IF EXISTS (SELECT name FROM sysobjects WHERE name='bajaLogicaCliente' AND type='p')
	DROP PROCEDURE S_QUERY.bajaLogicaCliente
GO
CREATE PROCEDURE S_QUERY.bajaLogicaCliente(@usuario_codigo_bajacliente INT)
AS
	BEGIN

		DECLARE @codigo_rol_cliente INT
		SET @codigo_rol_cliente = (SELECT TOP 1 rol_codigo FROM S_QUERY.Rol WHERE rol_nombre = 'Cliente' )

		UPDATE S_QUERY.RolXUsuario
		SET rol_habilitado = 0
		WHERE usuario_codigo = @usuario_codigo_bajacliente
		AND rol_codigo = @codigo_rol_cliente


		UPDATE S_QUERY.Cliente
		SET clie_habilitado = 0
		WHERE clie_codigo = @usuario_codigo_bajacliente

	END
GO



USE GD2C2019
IF EXISTS (SELECT name FROM sysobjects WHERE name='modificarCliente' AND type='p')
	DROP PROCEDURE S_QUERY.modificarCliente
GO
CREATE PROCEDURE S_QUERY.modificarCliente(@cliente_codigo_modif INT, @clie_nombre_modif NVARCHAR(255), @clie_apellido_modif NVARCHAR(255) , @clie_dni_modif NUMERIC(18,0), @clie_mail_modif NVARCHAR(255)
		, @clie_telefono_modif NUMERIC(18,0) , @clie_fecha_nac_modif DATETIME, @clie_habilitado BIT, @clie_calle_modif VARCHAR(255) , @clie_localidad_modif VARCHAR(255) , 
		@clie_nro_modif INT , @clie_depto_modif SMALLINT , @clie_piso_modif SMALLINT)
AS
	BEGIN
		DECLARE @codigo_direccion INT

		DECLARE @usuario_cliente_modif INT
		SET @usuario_cliente_modif = (SELECT TOP 1 usuario_codigo FROM S_QUERY.Cliente WHERE clie_codigo = @cliente_codigo_modif)

		DECLARE @codigo_rol_cliente_modif INT
		SET @codigo_rol_cliente_modif = (SELECT TOP 1 rol_codigo FROM S_QUERY.Rol WHERE rol_nombre = 'Cliente' )

		UPDATE S_QUERY.RolXUsuario
		SET rol_habilitado = @clie_habilitado
		WHERE usuario_codigo = @usuario_cliente_modif
		AND rol_codigo = @codigo_rol_cliente_modif


		UPDATE S_QUERY.Cliente 
			SET clie_apellido = @clie_apellido_modif, 
			clie_nombre = @clie_nombre_modif,
			clie_dni = @clie_dni_modif,
			clie_fecha_nacimiento= @clie_fecha_nac_modif,
			clie_habilitado = @clie_habilitado,
			clie_mail = @clie_mail_modif, 
			clie_telefono = @clie_telefono_modif
			WHERE clie_codigo = @cliente_codigo_modif;

		SET @codigo_direccion = (SELECT TOP 1 direc_codigo FROM S_QUERY.Cliente WHERE clie_codigo = @cliente_codigo_modif);

		UPDATE S_QUERY.Direccion
			SET direc_calle = @clie_calle_modif,
			direc_localidad = @clie_localidad_modif,
			direc_nro = @clie_nro_modif,
			direc_piso = @clie_piso_modif,
			direc_depto=  @clie_depto_modif
			WHERE direc_codigo = @codigo_direccion;


	END
GO


/*-----------------------------------------------------------ABM ROL-----------------------------------------------------------------------*/
USE GD2C2019
IF EXISTS (SELECT name FROM sysobjects WHERE name='insertarRolNuevo' AND type='p')
	DROP PROCEDURE S_QUERY.insertarRolNuevo
GO
CREATE PROCEDURE S_QUERY.insertarRolNuevo(@rol_nombre VARCHAR(50))
AS
	BEGIN
		DECLARE @idRol NUMERIC(18,0)
		INSERT INTO S_QUERY.Rol(rol_nombre)	VALUES(@rol_nombre)
		SELECT @idRol = SCOPE_IDENTITY()
		RETURN @idRol

	END
GO

USE GD2C2019
IF EXISTS (SELECT name FROM sysobjects WHERE name='eliminarRol' AND type='p')
	DROP PROCEDURE S_QUERY.eliminarRol
GO
CREATE PROCEDURE S_QUERY.eliminarRol(@codigo_rol_eliminar INT)
AS
	BEGIN

		DELETE FROM S_QUERY.RolXUsuario
		WHERE rol_codigo = @codigo_rol_eliminar

		UPDATE S_QUERY.Rol
		SET rol_estado = 0
		WHERE rol_codigo = @codigo_rol_eliminar

	END
GO


USE GD2C2019
IF EXISTS (SELECT name FROM sysobjects WHERE name='insertarFuncionalidadPorRol' AND type='p')
	DROP PROCEDURE S_QUERY.insertarFuncionalidadPorRol
GO
CREATE PROCEDURE S_QUERY.insertarFuncionalidadPorRol(@func_codigo INT, @rol_codigo INT)
AS
	BEGIN
		INSERT INTO S_QUERY.FuncionalidadXRol(func_codigo, rol_codigo)
		VALUES(@func_codigo, @rol_codigo)
	END
GO

USE GD2C2019
IF EXISTS (SELECT name FROM sysobjects WHERE name='elimininacionRol')
	DROP TRIGGER S_QUERY.elimininacionRol
GO
CREATE TRIGGER S_QUERY.elimininacionRol ON S_QUERY.Rol
INSTEAD OF UPDATE
AS
	BEGIN
		DECLARE @rol_id INT
		DECLARE @rol_estado BIT
		DECLARE @rol_nombre varchar(50)
		
		DECLARE C_ROL CURSOR FOR
		SELECT ins.rol_codigo, ins.rol_estado, ins.rol_nombre FROM inserted ins

		OPEN C_ROL
		FETCH NEXT FROM C_ROL INTO @rol_id, @rol_estado, @rol_nombre
		
		WHILE @@FETCH_STATUS = 0
			BEGIN
				IF(@rol_estado = 0)
					BEGIN
						DELETE S_QUERY.RolXUsuario
						WHERE rol_codigo = @rol_id
					END
				UPDATE S_QUERY.Rol
				SET rol_estado = @rol_estado, rol_nombre = @rol_nombre
				WHERE rol_codigo = @rol_id
		
				FETCH NEXT FROM C_ROL INTO @rol_id, @rol_estado, @rol_nombre
			END
	CLOSE C_ROL
	DEALLOCATE C_ROL
	END					
GO


/*-----------------------------------------------------------Creacion Ofertas-----------------------------------------------------------------------*/

USE GD2C2019
IF EXISTS (SELECT name FROM sysobjects WHERE name='insertarOfertaNueva' AND type='p')
	DROP PROCEDURE S_QUERY.insertarOfertaNueva
GO
CREATE PROCEDURE S_QUERY.insertarOfertaNueva(@oferta_descripcion VARCHAR(255) , @oferta_fecha DATE , @oferta_fecha_vencimiento DATE  , @oferta_precio FLOAT , 
	@oferta_precio_lista FLOAT , @oferta_cantidad_disponible INT , @oferta_maximo_compra INT , @user_codigo INT)
AS
	BEGIN 
		DECLARE @codigo_prov INT
		SET @codigo_prov = (SELECT S_QUERY.obtenerCodigoProveedor(@user_codigo) )
		INSERT INTO S_QUERY.Oferta(oferta_descripcion , oferta_fecha , oferta_fecha_vencimiento, 
			oferta_precio , oferta_precio_lista, oferta_cantidad_disponible, oferta_maximo_compra, prov_codigo)
		VALUES(@oferta_descripcion , @oferta_fecha , @oferta_fecha_vencimiento , 
			@oferta_precio , @oferta_precio_lista , @oferta_cantidad_disponible, @oferta_maximo_compra, @codigo_prov  )
	END
GO

/*-----------------------------------------------------------Nuevo Usuario-----------------------------------------------------------------------*/
/*----SE INSERTARAN CON SU USUARIO Y SU DIRECCION--*/

USE GD2C2019
IF EXISTS (SELECT name FROM sysobjects WHERE name='insertarCliente' AND type='p')
	DROP PROCEDURE S_QUERY.insertarCliente
GO
CREATE PROCEDURE S_QUERY.insertarCliente(@usuario_nombre VARCHAR(20), @usuario_contraseña VARCHAR(256), @clie_nombre NVARCHAR(255),
		 @clie_apellido NVARCHAR(255), @clie_dni NUMERIC(18,0), @clie_mail NVARCHAR(255), @clie_telefono NUMERIC(18,0), @clie_fecha_nacimiento DATETIME, @clie_saldo FLOAT, @direc_codigo INT) 
AS
	BEGIN
		DECLARE @idUsuario INT
		DECLARE @idCliente int
		
		SET @idUsuario = (SELECT TOP 1 usuario_codigo FROM S_QUERY.Usuario  WHERE usuario_nombre = @usuario_nombre AND usuario_contraseña= @usuario_contraseña);

		IF @idUsuario IS NULL
		BEGIN 
			INSERT INTO S_QUERY.Usuario(usuario_nombre, usuario_contraseña, usuario_habilitado)
				VALUES (@usuario_nombre , @usuario_contraseña , '1')

			SELECT @idUsuario = SCOPE_IDENTITY()
		END

		INSERT INTO S_QUERY.Cliente(clie_nombre, clie_apellido, clie_dni, clie_mail, clie_telefono, clie_fecha_nacimiento, clie_saldo, clie_habilitado, direc_codigo, usuario_codigo)
			VALUES(@clie_nombre, @clie_apellido, @clie_dni, @clie_mail, @clie_telefono, @clie_fecha_nacimiento, @clie_saldo, '1', @direc_codigo, @idUsuario)

	
		INSERT INTO S_QUERY.RolXUsuario(rol_codigo, usuario_codigo)
			VALUES( (SELECT rol_codigo FROM S_QUERY.Rol WHERE rol_nombre = 'Cliente') , @idUsuario)
	END
GO


USE GD2C2019
IF EXISTS (SELECT name FROM sysobjects WHERE name='insertarProveedor' AND type='p')
	DROP PROCEDURE S_QUERY.insertarProveedor
GO
CREATE PROCEDURE S_QUERY.insertarProveedor(@usuario_nombre_prov VARCHAR(20), @usuario_contraseña_prov VARCHAR(256), @razon_social_prov NVARCHAR(255),
		 @cuit_prov NVARCHAR(20), @mail_prov NVARCHAR(255),@ciudad_prov VARCHAR(64) ,  @telefono_prov NUMERIC(18,0), @nombre_contacto_prov VARCHAR(64), @rubro_codigo_prov INT, @direc_codigo_prov INT) 
AS
	BEGIN
		DECLARE @idUsuario INT
		DECLARE @idProveedor int

		
		SET @idUsuario = (SELECT TOP 1 usuario_codigo FROM S_QUERY.Usuario  WHERE usuario_nombre = @usuario_nombre_prov AND usuario_contraseña= @usuario_contraseña_prov);

		IF @idUsuario IS NULL
		BEGIN 
			INSERT INTO S_QUERY.Usuario(usuario_nombre, usuario_contraseña, usuario_habilitado)
				VALUES (@usuario_nombre_prov , @usuario_contraseña_prov , '1')

			SELECT @idUsuario = SCOPE_IDENTITY()
		END

		INSERT INTO S_QUERY.Proveedor(prov_razon_social, prov_cuit, prov_mail, prov_ciudad, prov_telefono, prov_nombre_contacto, prov_habilitado, rubro_codigo, direc_codigo, usuario_codigo)
			VALUES(@razon_social_prov, @cuit_prov, @mail_prov, @ciudad_prov, @telefono_prov, @nombre_contacto_prov, '1', @rubro_codigo_prov, @direc_codigo_prov, @idUsuario)

		INSERT INTO S_QUERY.RolXUsuario(rol_codigo, usuario_codigo)
			VALUES( (SELECT rol_codigo FROM S_QUERY.Rol WHERE rol_nombre = 'Proveedor') , @idUsuario)
	END
GO


/*IF EXISTS (SELECT name FROM sysobjects WHERE name='ingresarUsuarioNuevo' AND type='p')
	DROP PROCEDURE S_QUERY.ingresarUsuarioNuevo
GO
CREATE PROCEDURE S_QUERY.ingresarUsuarioNuevo(@usuario_nombre VARCHAR(20), @usuario_contraseña VARCHAR(256))
AS
	BEGIN 
		DECLARE @codigo_usuario INT
		INSERT INTO S_QUERY.Usuario(usuario_nombre, usuario_contraseña, usuario_habilitado)
			VALUES (@usuario_nombre , @usuario_contraseña , '1')
		SELECT @codigo_usuario = SCOPE_IDENTITY()
		RETURN @codigo_usuario

	END
GO*/

/*-----------------------------------------------------------Carga Credito-----------------------------------------------------------------------*/
USE GD2C2019
IF EXISTS (SELECT name FROM sysobjects WHERE name='cargarCredito' AND type='p')
	DROP PROCEDURE S_QUERY.cargarCredito
GO
CREATE PROCEDURE S_QUERY.cargarCredito(@fecha_de_carga DATE , @monto numeric(18,2) , @clie_codigo_carga INT , @tarjeta_numero_carga INT , @tipo_pago_carga INT)
AS
	BEGIN
		
		IF @tipo_pago_carga = 2
			BEGIN
				IF NOT EXISTS (SELECT tarjeta_numero FROM S_QUERY.Tarjeta WHERE tarjeta_numero=@tarjeta_numero_carga AND clie_codigo= @clie_codigo_carga)
					BEGIN
						INSERT INTO S_QUERY.Tarjeta(tarjeta_numero, clie_codigo)
							VALUES(@tarjeta_numero_carga, @clie_codigo_carga)
					END

				INSERT INTO S_QUERY.Carga(carga_fecha, carga_monto, clie_codigo, tarjeta_numero , tipo_pago_codigo)
				 VALUES(@fecha_de_carga , @monto, @clie_codigo_carga , @tarjeta_numero_carga, @tipo_pago_carga )

				UPDATE S_QUERY.Cliente
					SET clie_saldo += @monto
					WHERE clie_codigo = @clie_codigo_carga 
			END
		ELSE
			BEGIN
				
				INSERT INTO S_QUERY.Carga(cargA_fecha,carga_monto,clie_codigo,tipo_pago_codigo)
				VALUES(@fecha_de_carga,@monto,@clie_codigo_carga,@tipo_pago_carga)
				
				UPDATE S_QUERY.Cliente
				SET clie_saldo += @monto
				WHERE clie_codigo = @clie_codigo_carga 

			END

	END
GO

/***************************************************CONSUMO OFERTA*********************************************************/
USE GD2C2019;
IF EXISTS (SELECT name FROM sysobjects WHERE name='ingresarEntregaOferta' AND type='p')
	DROP PROCEDURE S_QUERY.ingresarEntregaOferta
GO

CREATE PROCEDURE S_QUERY.ingresarEntregaOferta(@entrega_fecha DATETIME, @cupon_codigo INT, @usuario_codigo INT)

AS
	BEGIN
		
		DECLARE @output INT
		DECLARE @cup_codigo INT
		DECLARE @cupon_fecha_vencimiento DATE
		DECLARE @cupon_entrega INT
		DECLARE @oferta_prov_codigo INT

		DECLARE @prov_codigo INT
		SET @prov_codigo = (SELECT S_QUERY.obtenerCodigoProveedor(@usuario_codigo))

		SELECT @cup_codigo = cup.cupon_codigo, @cupon_fecha_vencimiento = ofer.oferta_fecha_vencimiento,
			   @cupon_entrega = entr.entrega_codigo, @oferta_prov_codigo = ofer.prov_codigo
		FROM S_QUERY.Cupon cup
		JOIN S_QUERY.Oferta ofer on ofer.oferta_codigo = cup.oferta_codigo
		LEFT JOIN S_QUERY.Entrega entr on entr.cupon_codigo = cup.cupon_codigo
		WHERE cup.cupon_codigo = @cupon_codigo

		IF (@cup_codigo IS NOT NULL AND @oferta_prov_codigo = @prov_codigo)
			BEGIN
				IF @cupon_fecha_vencimiento >= @entrega_fecha
					BEGIN
						IF @cupon_entrega IS NULL
							BEGIN
								INSERT INTO S_QUERY.Entrega(entrega_fecha, cupon_codigo)
								VALUES(@entrega_fecha, @cupon_codigo)

								SET @output = 1
							END
						ELSE
							BEGIN
								SET @output = 2
								/*NO SE PUEDE CONSUMIR 2 VECES*/
							END
					END
				ELSE
					BEGIN
						SET @output = 3
						/*esta vencido ese cupon*/
					END
			END
		ELSE
			BEGIN
				SET @output = 4
				/*No existe el cupon o no le pertenece al proveedor*/
			END
		RETURN @output
	END
GO

USE GD2C2019
IF EXISTS (SELECT name FROM sysobjects WHERE name='obtenerCodigoProveedor' )
	DROP FUNCTION S_QUERY.obtenerCodigoProveedor
GO
CREATE FUNCTION S_QUERY.obtenerCodigoProveedor(@usuario_id INT) RETURNS INT
AS
	BEGIN
		DECLARE @RESULTADO INT
		SET @RESULTADO = (SELECT prov_codigo FROM S_QUERY.Proveedor WHERE usuario_codigo = @usuario_id)
		RETURN @RESULTADO
	END

GO

/***************************************************FACTURACION PROVEEDOR**************************************************/
USE GD2C2019
IF EXISTS (SELECT name FROM sysobjects WHERE name='FACTURACION_PROVEEDOR' )
	DROP FUNCTION S_QUERY.FACTURACION_PROVEEDOR
GO
CREATE FUNCTION S_QUERY.FACTURACION_PROVEEDOR(@PROVEEDOR INT, @INICIO DATETIME, @FIN DATETIME) RETURNS TABLE
AS
	RETURN
		(SELECT cup.cupon_codigo, cl.clie_nombre, cl.clie_apellido FROM S_QUERY.Cupon cup
		JOIN S_QUERY.Cliente cl ON cl.clie_codigo = cup.clie_codigo
		JOIN S_QUERY.Oferta ofer ON ofer.oferta_codigo = cup.oferta_codigo
		WHERE (cup.cupon_fecha BETWEEN @INICIO AND @FIN) AND ofer.prov_codigo = @PROVEEDOR AND
		cup.fact_numero IS NULL ) 
GO

USE GD2C2019
IF EXISTS (SELECT name FROM sysobjects WHERE name='GENERAR_FACTURACION' AND type='p')
	DROP PROCEDURE S_QUERY.GENERAR_FACTURACION
GO
CREATE PROCEDURE S_QUERY.GENERAR_FACTURACION(@FECHA DATETIME, @INICIO DATETIME, @FIN DATETIME, @PROVEEDOR INT)
AS
	BEGIN
		
		DECLARE @cupones_facturado TABLE( cupon_codigo_facturado INT)
		DECLARE @fact_nueva_numero INT

		DECLARE @TOTAL FLOAT
		SET @TOTAL = 
			ISNULL((
				SELECT SUM(ofer.oferta_precio * cup.cupon_cantidad) FROM S_QUERY.Cupon cup
				JOIN S_QUERY.Oferta ofer ON cup.oferta_codigo = ofer.oferta_codigo
				WHERE (cup.cupon_fecha BETWEEN @INICIO AND @FIN) AND ofer.prov_codigo = @PROVEEDOR AND
				cup.fact_numero IS NULL
			),0)
				
		INSERT INTO @cupones_facturado(cupon_codigo_facturado)
			SELECT cup.cupon_codigo FROM S_QUERY.Cupon cup
			JOIN S_QUERY.Oferta ofer ON cup.oferta_codigo = ofer.oferta_codigo
			WHERE (cup.cupon_fecha BETWEEN @INICIO AND @FIN) AND ofer.prov_codigo = @PROVEEDOR AND
			cup.fact_numero IS NULL
		
		SET @fact_nueva_numero = (SELECT TOP 1 fact_numero FROM S_QUERY.Factura ORDER BY fact_numero DESC) + 1
			
		INSERT INTO S_QUERY.Factura(fact_numero, fact_fecha, fact_periodo_inicio, fact_periodo_fin, fact_total, prov_codigo)
		VALUES(@fact_nueva_numero,@FECHA, @INICIO, @FIN, @TOTAL, @PROVEEDOR)

		UPDATE S_QUERY.Cupon
		SET fact_numero = @fact_nueva_numero
		WHERE EXISTS (SELECT 1 FROM @cupones_facturado WHERE cupon_codigo_facturado = cupon_codigo)
 END
GO

/*--------------------------------------------------LISTADO ESTADISTICO---------------------------------------------------*/
USE GD2C2019
IF EXISTS (SELECT name FROM sysobjects WHERE name='TOP5_PROVEEDORES_MAYOR_FACTURACION' )
	DROP FUNCTION S_QUERY.TOP5_PROVEEDORES_MAYOR_FACTURACION
GO
CREATE FUNCTION S_QUERY.TOP5_PROVEEDORES_MAYOR_FACTURACION(@ANIO INT, @MES INT) RETURNS TABLE
AS
RETURN
	(SELECT TOP 5 p.prov_codigo, p.prov_razon_social, SUM(f.fact_total) as [MONTO TOTAL]
	FROM S_QUERY.Proveedor p
	JOIN S_QUERY.Factura f ON f.prov_codigo = p.prov_codigo
	WHERE YEAR(f.fact_fecha) = @ANIO
	AND (@MES = 1 AND MONTH(f.fact_fecha) IN ('1', '2', '3', '4', '5', '6')) OR (@MES = 7 AND MONTH(f.fact_fecha) IN ('7', '8', '9', '10', '11', '12'))
	GROUP BY p.prov_codigo, p.prov_razon_social
	ORDER BY SUM(f.fact_total) DESC) 
GO



USE GD2C2019
IF EXISTS (SELECT name FROM sysobjects WHERE name='TOP5_PROVEEDORES_MAYOR_DESCUENTO_OFRECIDO_EN_OFERTAS' )
	DROP FUNCTION S_QUERY.TOP5_PROVEEDORES_MAYOR_DESCUENTO_OFRECIDO_EN_OFERTAS
GO
CREATE FUNCTION S_QUERY.TOP5_PROVEEDORES_MAYOR_DESCUENTO_OFRECIDO_EN_OFERTAS(@ANIO INT, @MES INT) RETURNS TABLE
AS
RETURN
(
	SELECT TOP 5 
		p.prov_codigo [Codigo], 
		p.prov_razon_social as [Razon social], 
		(select (CAST((min(o1.oferta_precio/o1.oferta_precio_lista) * 100) as varchar(80)) + '%')
			from S_QUERY.Oferta o1 where o1.prov_codigo = p.prov_codigo) as Porcentaje
		FROM S_QUERY.Proveedor p
		JOIN S_QUERY.Oferta o ON o.prov_codigo = p.prov_codigo
		WHERE YEAR(o.oferta_fecha) = @ANIO
		AND ((@MES = 1 AND MONTH(o.oferta_fecha) IN ('1', '2', '3', '4', '5', '6')) OR (@MES = 7 AND MONTH(o.oferta_fecha) IN ('7', '8', '9', '10', '11', '12')))
		GROUP BY p.prov_codigo, p.prov_razon_social
		ORDER BY 3 DESC
)
GO

/*----------------------------------------------------administracion usuarios------------------------------------------------*/
USE GD2C2019
IF EXISTS (SELECT name FROM sysobjects WHERE name='cambiarContraseniaUsuario' AND type='p')
	DROP PROCEDURE S_QUERY.cambiarContraseniaUsuario
GO
CREATE PROCEDURE S_QUERY.cambiarContraseniaUsuario(@usuario_id INT, @usuario_nueva_contrasenia varchar(256))
AS
	BEGIN
		UPDATE S_QUERY.Usuario
		SET usuario_contraseña = lower(convert(varchar(256),HASHBYTES('SHA2_256',@usuario_nueva_contrasenia),2))
		WHERE usuario_codigo = @usuario_id
	END
GO

/*--------------------------------------------------modificar contrasenia--------------------------------------------------*/
USE GD2C2019
IF EXISTS (SELECT name FROM sysobjects WHERE name='compararContrasenias' )
	DROP FUNCTION S_QUERY.compararContrasenias
GO
CREATE FUNCTION S_QUERY.compararContrasenias(@usuario_id int, @contrasenia_prevista varchar(256)) RETURNS INT
AS
	BEGIN
		DECLARE @contrasenia_prevista_hasheada VARCHAR(256)
		DECLARE @retorno INT

		SET @contrasenia_prevista_hasheada = lower(convert(varchar(256),HASHBYTES('SHA2_256',@contrasenia_prevista),2))

		IF((SELECT usuario_contraseña FROM S_QUERY.Usuario WHERE usuario_codigo = @usuario_id) = @contrasenia_prevista_hasheada)
			SET @retorno = 1
		ELSE
			SET @retorno = 0

	RETURN @retorno
	END
	
GO

/*--------------------------------------------------comprar oferta--------------------------------------------------*/
USE GD2C2019
IF EXISTS (SELECT name FROM sysobjects WHERE name='comprarOferta' AND type='p')
    DROP PROCEDURE S_QUERY.comprarOferta
GO
CREATE PROCEDURE S_QUERY.comprarOferta(@cupon_fecha_compra DATE , @cupon_cantidad_compra INT,@clie_codigo_compra INT ,  @oferta_codigo_compra INT)
AS
    BEGIN

		DECLARE @Codigo_comprado INT

		UPDATE S_QUERY.Oferta 
		SET oferta_cantidad_disponible -= @cupon_cantidad_compra
		WHERE oferta_codigo = @oferta_codigo_compra
		
        INSERT INTO S_QUERY.Cupon(cupon_fecha, cupon_cantidad, clie_codigo, oferta_codigo)
            VALUES (@cupon_fecha_compra, @cupon_cantidad_compra, @clie_codigo_compra, @oferta_codigo_compra)

		SELECT @Codigo_comprado = SCOPE_IDENTITY()

		UPDATE S_QUERY.Cliente
		SET clie_saldo -= (SELECT (@cupon_cantidad_compra * oferta_precio) FROM S_QUERY.Oferta WHERE oferta_codigo = @oferta_codigo_compra)

		RETURN @Codigo_comprado

    END
GO

/*-------------------------------------------------DAR DE BAJA USUARIO------------------------------------------*/
USE GD2C2019
IF EXISTS (SELECT name FROM sysobjects WHERE name='darDeBajaUsuario')
    DROP PROCEDURE S_QUERY.darDeBajaUsuario
GO

CREATE PROCEDURE S_QUERY.darDeBajaUsuario(@usuario_id INT)
AS
	BEGIN
		UPDATE S_QUERY.Usuario
		SET usuario_baja_logica = 'S'
		WHERE usuario_codigo = @usuario_id
	END
GO