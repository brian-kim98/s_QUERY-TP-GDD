USE GD2C2019;

DROP TABLE S_QUERY.FuncionalidadXRol 
DROP TABLE S_QUERY.RolXUsuario
DROP TABLE S_QUERY.Funcionalidad
DROP TABLE S_QUERY.Rol
DROP TABLE S_QUERY.Carga
DROP TABLE S_QUERY.Tipo_Pago
DROP TABLE S_QUERY.Tarjeta
DROP TABLE S_QUERY.Entrega
/*DROP TABLE S_QUERY.Item_Factura*/
DROP TABLE S_QUERY.Cupon
DROP TABLE S_QUERY.Factura
DROP TABLE S_QUERY.Oferta
DROP TABLE S_QUERY.Proveedor
DROP TABLE S_QUERY.Cliente
DROP TABLE S_QUERY.Rubro
DROP TABLE S_QUERY.Direccion
DROP TABLE S_QUERY.Usuario

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

		/*Cliente ready*/
		INSERT INTO S_QUERY.Cliente (clie_nombre, clie_apellido, clie_dni, clie_mail, clie_telefono, clie_fecha_nacimiento, clie_saldo,
									 clie_habilitado)
			SELECT DISTINCT cli_nombre, 
				cli_apellido,cli_dni, cli_mail, Cli_Telefono, Cli_Fecha_Nac, 200.0, 1 FROM gd_esquema.Maestra

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

			
COMMIT

/*Facturas*/

/* COMENTADO POR LAS DUDIÑAS, PERIODO INICIO Y FIN EN MAESTRA
SELECT DISTINCT m.Factura_Nro, m.Factura_Fecha,
	   (SELECT MIN(m1.Oferta_Fecha_Compra)
	    FROM gd_esquema.Maestra m1
		WHERE m1.Factura_Nro = m.Factura_Nro
	   ) as 'Periodo inicio',
	   (SELECT MAX(m2.Oferta_Fecha_Compra)
	    FROM gd_esquema.Maestra m2
		WHERE m2.Factura_Nro = m.Factura_Nro
	   ) as 'Periodo Fin',
	   (SELECT prov_codigo FROM S_QUERY.Proveedor
		WHERE prov_cuit = m.Provee_CUIT
	   ) as 'Codigo Proveedor'
FROM gd_esquema.Maestra m
WHERE Factura_Nro IS NOT NULL
ORDER BY Factura_Nro
*/

/*cantidad de cupones facturados MIGRADOS*/
SELECT * FROM S_QUERY.Cupon
WHERE fact_numero IS NOT NULL
ORDER BY fact_numero ASC

/*cantidad de cupones a migrar*/
SELECT * FROM gd_esquema.Maestra
WHERE Factura_Nro IS NOT NULL
ORDER BY Factura_Nro ASC

/*facturas distintas*/
SELECT DISTINCT  Factura_Nro, Factura_Fecha, Provee_CUIT FROM gd_esquema.Maestra
WHERE Factura_Nro IS NOT NULL
Order BY Factura_Nro

/*Ofertas GDD_MAESTRA*/
SELECT DISTINCT Oferta_Codigo, Oferta_Descripcion, Oferta_Fecha, Oferta_Fecha_Venc, Oferta_Precio,
							Oferta_Precio_Ficticio, 0, Oferta_Cantidad,
							(SELECT prov_codigo FROM S_QUERY.Proveedor
							 WHERE prov_cuit = Provee_CUIT)
			FROM gd_esquema.Maestra
			WHERE Oferta_Entregado_Fecha IS NULL
			AND Factura_Nro IS NULL
			AND Oferta_Codigo IS NOT NULL
			ORDER BY Oferta_Codigo ASC

/*Compras GDD_MAESTRA*/
SELECT * FROM gd_esquema.Maestra
WHERE Oferta_Codigo IS NOT NULL
AND Oferta_Entregado_Fecha IS NULL
AND Factura_Nro IS NULL
ORDER BY Cli_Dni, Oferta_Codigo ASC

/*Entregas GDD_MAESTRA*/

SELECT * FROM gd_esquema.Maestra
WHERE Oferta_Codigo IS NOT NULL
AND Factura_Nro IS NULL
ORDER BY Oferta_Codigo,Oferta_Entregado_Fecha

/*CANTIDAD DE ENTREGAS*/
SELECT COUNT(Oferta_Entregado_Fecha) FROM gd_esquema.Maestra
WHERE Oferta_Entregado_Fecha IS NOT NULL

SELECT SUM(t.cantidad_entregas) FROM 
(SELECT Oferta_Codigo as codigo, COUNT(Oferta_Entregado_Fecha) as cantidad_entregas FROM gd_esquema.Maestra
WHERE Oferta_Codigo IS NOT NULL
AND Factura_Nro IS NULL
GROUP BY Oferta_Codigo
) t

/*CANTIDAD ENTREGAS POR CODIGO*/
SELECT Oferta_Codigo, COUNT(Oferta_Entregado_Fecha) FROM gd_esquema.Maestra
WHERE Oferta_Codigo IS NOT NULL
AND Factura_Nro IS NULL
GROUP BY Oferta_Codigo
ORDER BY Oferta_Codigo

SELECT Oferta_Codigo, Oferta_Entregado_Fecha FROM gd_esquema.Maestra
WHERE Oferta_Codigo IS NOT NULL
AND Factura_Nro IS NULL
GROUP BY Oferta_Codigo, Oferta_Entregado_Fecha
ORDER BY Oferta_Codigo, Oferta_Entregado_Fecha

/*Cupones*/
SELECT * FROM S_QUERY.Cupon


/*Entrega - cupon*/
SELECT Oferta_Entregado_Fecha,
			(SELECT c.cupon_codigo
			FROM S_QUERY.Cupon c JOIN S_QUERY.Oferta o on c.oferta_codigo = o.oferta_codigo
			WHERE o.oferta_codigo_viejo = maestra.Oferta_Codigo AND c.cupon_fecha = maestra.Oferta_Fecha_Compra)
			FROM gd_esquema.Maestra maestra
			WHERE Oferta_Entregado_Fecha IS NOT NULL
			
SELECT * FROM gd_esquema.Maestra
WHERE Oferta_Entregado_Fecha IS NOT NULL


/*--------------------procedures----------------------*/
CREATE PROCEDURE S_QUERY.insertarCliente(@clie_nombre NVARCHAR(255), @clie_apellido NVARCHAR(255), @clie_dni NUMERIC(18,0), @clie_mail NVARCHAR(255), @clie_telefono NUMERIC(18,0), @clie_fecha_nacimiento DATETIME, @clie_saldo FLOAT,
									 @clie_habilitado BIT, @direc_codigo INT, @usuario_codigo INT) 
AS
	BEGIN
		DECLARE @idCliente int
		INSERT INTO S_QUERY.Cliente(clie_nombre, clie_apellido, clie_dni, clie_mail, clie_telefono, clie_fecha_nacimiento, clie_saldo, clie_habilitado, direc_codigo, usuario_codigo)
		VALUES(@clie_nombre, @clie_apellido, @clie_dni, @clie_mail, @clie_telefono, @clie_fecha_nacimiento, @clie_saldo, @clie_habilitado, @direc_codigo, @usuario_codigo)
		SELECT @idCliente = SCOPE_IDENTITY()

		RETURN @idCliente
	END
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

/*-----------------------------------------------------------ABM ROL-----------------------------------------------------------------------*/
DROP PROCEDURE S_QUERY.insertarRolNuevo
CREATE PROCEDURE S_QUERY.insertarRolNuevo(@rol_nombre VARCHAR(50))
AS
	BEGIN
		DECLARE @idRol NUMERIC(18,0)
		INSERT INTO S_QUERY.Rol(rol_nombre)	VALUES(@rol_nombre)
		SELECT @idRol = SCOPE_IDENTITY()
		RETURN @idRol

	END
GO

CREATE PROCEDURE S_QUERY.insertarFuncionalidadPorRol(@func_codigo INT, @rol_codigo INT)
AS
	BEGIN
		INSERT INTO S_QUERY.FuncionalidadXRol(func_codigo, rol_codigo)
		VALUES(@func_codigo, @rol_codigo)
	END
GO
