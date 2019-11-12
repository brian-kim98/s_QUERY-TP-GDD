USE GD2C2019;

DROP TABLE S_QUERY.FuncionalidadXRol 
DROP TABLE S_QUERY.RolXUsuario
DROP TABLE S_QUERY.Funcionalidad
DROP TABLE S_QUERY.Rol
DROP TABLE S_QUERY.Carga
DROP TABLE S_QUERY.Tipo_Pago
DROP TABLE S_QUERY.Tarjeta
DROP TABLE S_QUERY.Entrega
DROP TABLE S_QUERY.Item_Factura
DROP TABLE S_QUERY.Cupon
DROP TABLE S_QUERY.Factura
DROP TABLE S_QUERY.Oferta
DROP TABLE S_QUERY.Proveedor
DROP TABLE S_QUERY.Cliente
DROP TABLE S_QUERY.Rubro
DROP TABLE S_QUERY.Direccion
DROP TABLE S_QUERY.Usuario

BEGIN TRANSACTION
		/*Rubro*/
		INSERT INTO S_QUERY.Rubro(rubro_nombre)
		SELECT DISTINCT Provee_Rubro FROM gd_esquema.Maestra WHERE
		Provee_Rubro IS NOT NULL

		INSERT INTO S_QUERY.Rol(rol_nombre, rol_estado)
		VALUES 
		('Cliente', 1),
		('Proveedor', 1),
		('Administrativo', 1)
		

		/*Proveedor*/
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

		/*Cliente*/
		INSERT INTO S_QUERY.Cliente (clie_nombre, clie_apellido, clie_dni, clie_mail, clie_telefono, clie_fecha_nacimiento, clie_saldo,
									 clie_habilitado)
			SELECT DISTINCT cli_nombre, 
				cli_apellido,cli_dni, cli_mail, Cli_Telefono, Cli_Fecha_Nac, 200.0, 1 FROM gd_esquema.Maestra

		/*Tipo_Pago*/
		INSERT INTO S_QUERY.Tipo_Pago (tipo_pago_nombre)
			SELECT DISTINCT Tipo_Pago_Desc FROM gd_esquema.Maestra WHERE
			Tipo_Pago_Desc IS NOT NULL

		/*Carga*/
		INSERT INTO S_QUERY.Carga(carga_fecha, carga_monto, clie_codigo, tipo_pago_codigo)
			SELECT Carga_Fecha, Carga_Credito,
				(SELECT DISTINCT clie_codigo FROM S_QUERY.Cliente
				WHERE clie_dni = Cli_Dni AND Cli_Dni IS NOT NULL),
				(SELECT DISTINCT tipo_pago_codigo FROM S_QUERY.Tipo_Pago
				WHERE tipo_pago_nombre = Tipo_Pago_Desc AND Tipo_Pago_Desc IS NOT NULL)
			FROM gd_esquema.Maestra
			WHERE Carga_Fecha IS NOT NULL AND Carga_Credito IS NOT NULL
		
		/*Ofertas*/
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

		/*Cupones*/
		INSERT INTO S_QUERY.Cupon(cupon_cantidad, cupon_fecha, oferta_codigo, clie_codigo)
					SELECT 1, compras.fecha,
						 (SELECT oferta_codigo FROM S_QUERY.Oferta WHERE oferta_codigo_viejo = compras.codigo), 
						(SELECT clie_codigo FROM S_QUERY.Cliente WHERE clie_dni = compras.dni)
					FROM (SELECT DISTINCT Oferta_Codigo as codigo, Oferta_Fecha_Compra as fecha, Cli_Dni  as dni
							FROM gd_esquema.Maestra
							WHERE Oferta_Entregado_Fecha IS NULL
							AND Factura_Nro IS NULL
							AND Oferta_Codigo IS NOT NULL
						) compras

		/*Entregas*/
		INSERT INTO S_QUERY.Entrega(entrega_fecha,cupon_codigo)
			SELECT

		/*Facturas*/
		INSERT INTO S_QUERY.Factura(fact_numero, fact_fecha)
			SELECT DISTINCT Factura_nro, Factura_fecha from gd_esquema.Maestra
			WHERE Factura_Nro IS NOT NULL

		/*Item_Factura*/
		INSERT INTO S_QUERY.Item_Factura(fact_numero,cupon_codigo,item_precio)
			SELECT Factura_Nro,
				   (SELECT cup.cupon_codigo 
				    FROM S_QUERY.Cupon cup 
					JOIN S_QUERY.Oferta ofe on cup.oferta_codigo = ofe.oferta_codigo
					JOIN S_QUERY.Cliente cli on cli.clie_codigo = cup.clie_codigo)
			FROM gd_esquema.Maestra v
			WHERE Factura_Nro IS NOT NULL

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

/*CANTIDAD ENTREGAS POR CODIGO*/
SELECT Oferta_Codigo, Oferta_Entregado_Fecha FROM gd_esquema.Maestra
WHERE Oferta_Codigo IS NOT NULL
AND Factura_Nro IS NULL
GROUP BY Oferta_Codigo, Oferta_Entregado_Fecha
ORDER BY Oferta_Codigo, Oferta_Entregado_Fecha

/*CANTIDAD DE ENTREGAS*/
SELECT COUNT(Oferta_Entregado_Fecha) FROM gd_esquema.Maestra
WHERE Oferta_Entregado_Fecha IS NOT NULL

/*CANTIDAD ENTREGAS POR CODIGO*/
SELECT Oferta_Codigo, COUNT(Oferta_Entregado_Fecha) FROM gd_esquema.Maestra
WHERE Oferta_Codigo IS NOT NULL
AND Factura_Nro IS NULL
GROUP BY Oferta_Codigo
ORDER BY Oferta_Codigo

/*CANTIDAD DE ENTREGAS*/
SELECT SUM(t.cantidad_entregas) FROM 
(SELECT Oferta_Codigo as codigo, COUNT(Oferta_Entregado_Fecha) as cantidad_entregas FROM gd_esquema.Maestra
WHERE Oferta_Codigo IS NOT NULL
AND Factura_Nro IS NULL
GROUP BY Oferta_Codigo
) t

/*Cupones*/
SELECT * FROM S_QUERY.Cupon



