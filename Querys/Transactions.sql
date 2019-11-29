
/*--------------------procedures----------------------*/




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

/*-----------------------------------------------------------ABM Cliente-----------------------------------------------------------------------*/

IF EXISTS (SELECT name FROM sysobjects WHERE name='eliminarCliente' AND type='p')
	DROP PROCEDURE S_QUERY.eliminarCliente
GO
CREATE PROCEDURE S_QUERY.eliminarCliente(@usuario_codigo_eliminar INT)
AS
	BEGIN
		DELETE FROM S_QUERY.RolXUsuario WHERE rol_codigo = (SELECT TOP 1 rol_codigo FROM S_QUERY.Rol WHERE rol_nombre = 'Cliente' ORDER BY rol_nombre) AND
			usuario_codigo = (SELECT TOP 1 usuario_codigo FROM S_QUERY.Cliente WHERE clie_codigo = @usuario_codigo_eliminar);

		UPDATE S_QUERY.Cupon 
		SET clie_codigo = null
		WHERE clie_codigo = @usuario_codigo_eliminar;

		DELETE FROM S_QUERY.Cliente WHERE clie_codigo = @usuario_codigo_eliminar;


	END
GO


IF EXISTS (SELECT name FROM sysobjects WHERE name='modificarCliente' AND type='p')
	DROP PROCEDURE S_QUERY.modificarCliente
GO
CREATE PROCEDURE S_QUERY.modificarCliente(@cliente_codigo_modif INT, @clie_nombre_modif NVARCHAR(255), @clie_apellido_modif NVARCHAR(255) , @clie_dni_modif NUMERIC(18,0), @clie_mail_modif NVARCHAR(255)
		, @clie_telefono_modif NUMERIC(18,0) , @clie_fecha_nac_modif DATETIME, @clie_habilitado BIT, @clie_calle_modif VARCHAR(255) , @clie_localidad_modif VARCHAR(255) , 
		@clie_nro_modif INT , @clie_depto_modif SMALLINT , @clie_piso_modif SMALLINT)
AS
	BEGIN
		DECLARE @codigo_direccion INT;

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
			direc_nro = @clie_nro_modif
			WHERE direc_codigo = @codigo_direccion;

		IF @clie_depto_modif != NULL
		BEGIN
			UPDATE S_QUERY.Direccion
				SET direc_depto = @clie_depto_modif, direc_piso = @clie_piso_modif
				WHERE direc_codigo = @codigo_direccion;
				 
		END


	END
GO


/*-----------------------------------------------------------ABM ROL-----------------------------------------------------------------------*/

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





/*-----------------------------------------------------------Creacion Ofertas-----------------------------------------------------------------------*/


IF EXISTS (SELECT name FROM sysobjects WHERE name='insertarOfertaNueva' AND type='p')
	DROP PROCEDURE S_QUERY.insertarOfertaNueva
GO
CREATE PROCEDURE S_QUERY.insertarOfertaNueva(@oferta_descripcion VARCHAR(255) , @oferta_fecha DATE , @oferta_fecha_vencimiento DATE  , @oferta_precio FLOAT , 
	@oferta_precio_lista FLOAT , @oferta_cantidad_disponible INT , @oferta_maximo_compra INT , @prov_codigo INT)
AS
	BEGIN 
		INSERT INTO S_QUERY.Oferta(oferta_descripcion , oferta_fecha , oferta_fecha_vencimiento, 
			oferta_precio , oferta_precio_lista, oferta_cantidad_disponible, oferta_maximo_compra, prov_codigo)
		VALUES(@oferta_descripcion , @oferta_fecha , @oferta_fecha_vencimiento , 
			@oferta_precio , @oferta_precio_lista , @oferta_cantidad_disponible, @oferta_maximo_compra,  @prov_codigo  )
	END
GO

/*-----------------------------------------------------------Nuevo Usuario-----------------------------------------------------------------------*/
/*----SE INSERTARAN CON SU USUARIO Y SU DIRECCION--*/

IF EXISTS (SELECT name FROM sysobjects WHERE name='insertarCliente' AND type='p')
	DROP PROCEDURE S_QUERY.insertarCliente
GO
CREATE PROCEDURE S_QUERY.insertarCliente(@usuario_nombre VARCHAR(20), @usuario_contraseña VARCHAR(256), @clie_nombre NVARCHAR(255),
		 @clie_apellido NVARCHAR(255), @clie_dni NUMERIC(18,0), @clie_mail NVARCHAR(255), @clie_telefono NUMERIC(18,0), @clie_fecha_nacimiento DATETIME, @clie_saldo FLOAT, @direc_codigo INT) 
AS
	BEGIN
		DECLARE @idUsuario INT
		DECLARE @idCliente int

		INSERT INTO S_QUERY.Usuario(usuario_nombre, usuario_contraseña, usuario_habilitado)
			VALUES (@usuario_nombre , @usuario_contraseña , '1')

		SELECT @idUsuario = SCOPE_IDENTITY()

		INSERT INTO S_QUERY.Cliente(clie_nombre, clie_apellido, clie_dni, clie_mail, clie_telefono, clie_fecha_nacimiento, clie_saldo, clie_habilitado, direc_codigo, usuario_codigo)
			VALUES(@clie_nombre, @clie_apellido, @clie_dni, @clie_mail, @clie_telefono, @clie_fecha_nacimiento, @clie_saldo, '1', @direc_codigo, @idUsuario)

	
		INSERT INTO S_QUERY.RolXUsuario(rol_codigo, usuario_codigo)
			VALUES( (SELECT rol_codigo FROM S_QUERY.Rol WHERE rol_nombre = 'Cliente') , @idUsuario)
	END
GO



IF EXISTS (SELECT name FROM sysobjects WHERE name='insertarProveedor' AND type='p')
	DROP PROCEDURE S_QUERY.insertarProveedor
GO
CREATE PROCEDURE S_QUERY.insertarProveedor(@usuario_nombre_prov VARCHAR(20), @usuario_contraseña_prov VARCHAR(256), @razon_social_prov NVARCHAR(255),
		 @cuit_prov NVARCHAR(20), @mail_prov NVARCHAR(255),@ciudad_prov VARCHAR(64) ,  @telefono_prov NUMERIC(18,0), @nombre_contacto_prov VARCHAR(64), @rubro_codigo_prov INT, @direc_codigo_prov INT) 
AS
	BEGIN
		DECLARE @idUsuario INT
		DECLARE @idProveedor int

		INSERT INTO S_QUERY.Usuario(usuario_nombre, usuario_contraseña, usuario_habilitado)
			VALUES (@usuario_nombre_prov , @usuario_contraseña_prov , '1')

		SELECT @idUsuario = SCOPE_IDENTITY()

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

IF EXISTS (SELECT name FROM sysobjects WHERE name='cargarCredito' AND type='p')
	DROP PROCEDURE S_QUERY.cargarCredito
GO
CREATE PROCEDURE S_QUERY.cargarCredito(@fecha_de_carga DATE , @monto numeric(18,2) , @clie_codigo_carga INT , @tarjeta_numero_carga INT , @tipo_pago_carga INT)
AS
	BEGIN
		
		IF NOT EXISTS (SELECT tarjeta_numero FROM S_QUERY.Tarjeta WHERE tarjeta_numero=@tarjeta_numero_carga AND clie_codigo= @clie_codigo_carga)
			BEGIN
				INSERT INTO S_QUERY.Tarjeta(tarjeta_numero, clie_codigo)
					VALUES(@tarjeta_numero_carga, @clie_codigo_carga)
			END

		INSERT INTO S_QUERY.Carga(carga_fecha, carga_monto, clie_codigo,  tarjeta_numero , tipo_pago_codigo)
		 VALUES(@fecha_de_carga , @monto, @clie_codigo_carga , @tarjeta_numero_carga, @tipo_pago_carga )

		UPDATE S_QUERY.Cliente
			SET clie_saldo += @monto
			WHERE clie_codigo = @clie_codigo_carga 

	END
GO

/*--------------------------------------------------LISTADO ESTADISTICO---------------------------------------------------*/
CREATE FUNCTION S_QUERY.TOP5_PROVEEDORES_MAYOR_PORCENTAJE_DESCUENTO_OFRECIDO(@ANIO INT, @MES INT) RETURNS TABLE
AS
RETURN 
(SELECT * FROM S_QUERY.Cliente)
GO

USE GD2C2019
CREATE FUNCTION S_QUERY.TOP5_PROVEEDORES_MAYOR_FACTURACION(@ANIO INT, @MES INT) RETURNS TABLE
AS

RETURN
(SELECT TOP 5 p.prov_codigo, p.prov_razon_social, SUM(f.fact_total) as [MONTO TOTAL]
FROM S_QUERY.Proveedor p
JOIN S_QUERY.Factura f ON f.prov_codigo = p.prov_codigo
WHERE YEAR(f.fact_periodo_fin) = @ANIO
AND (@MES = 1 AND MONTH(f.fact_periodo_fin) IN ('1', '2', '3', '4', '5', '6')) OR (@MES = 7 AND MONTH(f.fact_periodo_fin) IN ('7', '8', '9', '10', '11', '12'))
GROUP BY p.prov_codigo, p.prov_razon_social
ORDER BY SUM(f.fact_total))
GO

/*-------------------------------TRANSACTION-----------------------------*/

USE GD2C2019
BEGIN TRANSACTION
		/*Rubro ready*/
		INSERT INTO S_QUERY.Rubro(rubro_nombre)
		SELECT DISTINCT Provee_Rubro FROM gd_esquema.Maestra WHERE
		Provee_Rubro IS NOT NULL

		INSERT INTO S_QUERY.Rol(rol_nombre)
		VALUES 
		('Cliente'),
		('Proveedor'),
		('Administrativo')
		

		/*Proveedor ready*/
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
		/*Cliente ready*/
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

		/*Tipo_Pago ready*/
		INSERT INTO S_QUERY.Tipo_Pago (tipo_pago_nombre)
			SELECT DISTINCT Tipo_Pago_Desc FROM gd_esquema.Maestra WHERE
			Tipo_Pago_Desc IS NOT NULL

		/*Carga ready*/
		INSERT INTO S_QUERY.Carga(carga_fecha, carga_monto, clie_codigo, tipo_pago_codigo)
			SELECT Carga_Fecha, Carga_Credito,
				(SELECT DISTINCT clie_codigo FROM S_QUERY.Cliente
				WHERE clie_dni = Cli_Dni AND Cli_Dni IS NOT NULL),
				(SELECT DISTINCT tipo_pago_codigo FROM S_QUERY.Tipo_Pago
				WHERE tipo_pago_nombre = Tipo_Pago_Desc AND Tipo_Pago_Desc IS NOT NULL)
			FROM gd_esquema.Maestra
			WHERE Carga_Fecha IS NOT NULL AND Carga_Credito IS NOT NULL
		
		/*Ofertas ready*/
		INSERT INTO S_QUERY.Oferta(oferta_codigo_viejo, oferta_descripcion, oferta_fecha, oferta_fecha_vencimiento, oferta_precio,
									oferta_precio_lista, oferta_cantidad_disponible, oferta_maximo_compra, prov_codigo)
			SELECT DISTINCT Oferta_Codigo, Oferta_Descripcion, Oferta_Fecha, Oferta_Fecha_Venc, Oferta_Precio,
							Oferta_Precio_Ficticio, 0, Oferta_Cantidad,
							(SELECT prov_codigo FROM S_QUERY.Proveedor
							 WHERE prov_cuit = Provee_CUIT)
			FROM gd_esquema.Maestra
			WHERE Oferta_Entregado_Fecha IS NULL
			AND Factura_Nro IS NULL
			AND Oferta_Codigo IS NOT NULL
			ORDER BY Oferta_Codigo ASC

		/*Facturas READY(ver mas abajo precio total)*/
		INSERT INTO S_QUERY.Factura(fact_numero, fact_fecha, prov_codigo, fact_total)
			SELECT DISTINCT m.Factura_Nro, m.Factura_Fecha,
				 (SELECT prov_codigo FROM S_QUERY.Proveedor
				  WHERE prov_cuit = m.Provee_CUIT
				 ) as 'Codigo Proveedor',
				 (SELECT SUM(k.Oferta_Precio) as 'Total'
					FROM gd_esquema.Maestra k
					WHERE Factura_Nro IS NOT NULL
					AND k.Factura_Nro = m.Factura_Nro
					)  as 'total'
				FROM gd_esquema.Maestra m
				WHERE Factura_Nro IS NOT NULL
				ORDER BY Factura_Nro

		/*Cupones ready*/
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

		/*Entregas ready*/
		INSERT INTO S_QUERY.Entrega(entrega_fecha, cupon_codigo)
			SELECT Oferta_Entregado_Fecha,
			(SELECT c.cupon_codigo
			FROM S_QUERY.Cupon c JOIN S_QUERY.Oferta o on c.oferta_codigo = o.oferta_codigo
			WHERE o.oferta_codigo_viejo = maestra.Oferta_Codigo AND c.cupon_fecha = maestra.Oferta_Fecha_Compra)
			FROM gd_esquema.Maestra maestra
			WHERE Oferta_Entregado_Fecha IS NOT NULL

		/*Funcionalidad*/
		INSERT INTO S_QUERY.Funcionalidad(func_nombre)
			VALUES ('Login y Seguridad'), 
			('ABM de Rol'),
			('Registro de Usuario'),
			('ABM de Cliente'),
			('ABM de Proveedor'),
			('Cargar Credito'),
			('Comprar Oferta'),
			('Confeccion y publicacion de Ofertas'),
			('Facturacion a Proveedor'),
			('Listado Estadistico')

		INSERT INTO S_QUERY.FuncionalidadXRol(func_codigo, rol_codigo)
			VALUES('5' , (SELECT TOP 1 rol_codigo FROM S_QUERY.Rol WHERE rol_nombre = 'Proveedor' )),
				('8' , (SELECT TOP 1 rol_codigo FROM S_QUERY.Rol WHERE rol_nombre = 'Proveedor' )),
				('6' , (SELECT TOP 1 rol_codigo FROM S_QUERY.Rol WHERE rol_nombre = 'Cliente' )),
				('4' , (SELECT TOP 1 rol_codigo FROM S_QUERY.Rol WHERE rol_nombre = 'Cliente' )),
				('7' , (SELECT TOP 1 rol_codigo FROM S_QUERY.Rol WHERE rol_nombre = 'Cliente' ))
					
							
COMMIT


