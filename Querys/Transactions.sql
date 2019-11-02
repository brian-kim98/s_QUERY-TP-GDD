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
		INSERT INTO S_QUERY.Cliente (clie_nombre, clie_apellido, clie_dni, clie_mail, clie_telefono, clie_fecha_nacimiento, clie_saldo)
			SELECT DISTINCT cli_nombre, 
				cli_apellido,cli_dni, cli_mail, Cli_Telefono, Cli_Fecha_Nac, 200.0 FROM gd_esquema.Maestra

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
			SELECT codigo,t.Oferta_Descripcion, t.Oferta_Fecha, t.Oferta_Fecha_Venc, t.Oferta_Precio, t.Oferta_Precio_Ficticio,0,t.Oferta_Cantidad,
				   (SELECT prov_codigo FROM S_QUERY.Proveedor WHERE prov_cuit = t.Provee_CUIT)
			FROM 
				(SELECT DISTINCT SUBSTRING(Oferta_Codigo,1,10) as codigo,
						Provee_CUIT,Oferta_Descripcion,Oferta_Fecha,Oferta_Fecha_Venc,Oferta_Precio,Oferta_Precio_Ficticio,Oferta_Cantidad
				 FROM gd_esquema.Maestra
				 WHERE Oferta_Codigo IS NOT NULL AND Oferta_Descripcion IS NOT NULL AND Oferta_Fecha IS NOT NULL AND
					   Oferta_Fecha_Venc IS NOT NULL AND Oferta_Precio IS NOT NULL AND Oferta_Precio_Ficticio IS NOT NULL AND Oferta_Cantidad IS NOT NULL	
				) t

		/*Cupones*/
		INSERT INTO S_QUERY.Cupon(cupon_cantidad, cupon_fecha, oferta_codigo, clie_codigo)
			SELECT CONVERT(INT,SUBSTRING(v.Oferta_codigo, 11,LEN(v.Oferta_codigo))),
				   v.Oferta_Fecha_Compra,
				   (SELECT nueva.oferta_codigo 
				    FROM S_QUERY.Oferta nueva
				    WHERE nueva.oferta_codigo_viejo = SUBSTRING(v.Oferta_Codigo, 1, 10)
			       ) as 'nuevo codigo',
			       (SELECT nueva.clie_codigo FROM S_QUERY.Cliente nueva WHERE nueva.clie_dni = v.Cli_Dni) as 'codigo cliente'
			FROM gd_esquema.Maestra v
			WHERE v.Oferta_Codigo IS NOT NULL AND v.Oferta_Fecha_Compra IS NOT NULL  AND v.Oferta_Entregado_Fecha IS NULL AND
				  v.Factura_Nro IS NULL AND v.Factura_Fecha IS NULL

		/*Entregas*/
		INSERT INTO S_QUERY.Entrega(entrega_fecha,cupon_codigo)
			SELECT v.Oferta_Entregado_Fecha,
				   (SELECT c.cupon_codigo
				    FROM S_QUERY.Cupon c 
					JOIN S_QUERY.Oferta o ON c.oferta_codigo = o.oferta_codigo
					JOIN S_QUERY.Cliente clie ON clie.clie_codigo = c.clie_codigo
					WHERE SUBSTRING(v.Oferta_Codigo,1,10) = o.oferta_codigo_viejo AND 
						  c.cupon_fecha = v.Oferta_Fecha_Compra AND
						  clie.clie_dni = v.Cli_Dni AND
						  v.Oferta_Fecha = o.oferta_fecha AND
						  CONVERT(INT,SUBSTRING(v.Oferta_codigo, 11,LEN(v.Oferta_codigo))) = c.cupon_cantidad
					)
			FROM gd_esquema.Maestra v
			WHERE v.Oferta_Entregado_Fecha IS NOT NULL AND v.Factura_Nro IS NULL
			ORDER BY 1 ASC

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

SELECT DISTINCT Provee_CUIT FROM gd_esquema.Maestra
WHERE Provee_CUIT IS NOT NULL

SELECT * FROM S_QUERY.Cliente;

SELECT * FROM S_QUERY.Proveedor;

SELECT * FROM S_QUERY.Rubro;

SELECT * FROM S_QUERY.Tipo_Pago

SELECT * FROM S_QUERY.Carga

SELECT Oferta_codigo, Oferta_Entregado_Fecha FROM gd_esquema.Maestra
WHERE Oferta_Entregado_Fecha IS NOT NULL
ORDER BY Oferta_Codigo ASC

SELECT * FROM gd_esquema.Maestra
WHERE Oferta_Entregado_Fecha IS NOT NULL
ORDER BY Oferta_Entregado_Fecha ASC

/*entregas*/
SELECT v.Oferta_Entregado_Fecha,
	   v.Cli_Nombre,
	   v.Cli_Apellido,
				   (SELECT c.cupon_codigo
				    FROM S_QUERY.Cupon c 
					JOIN S_QUERY.Oferta o ON c.oferta_codigo = o.oferta_codigo
					JOIN S_QUERY.Cliente clie ON clie.clie_codigo = c.clie_codigo
					WHERE SUBSTRING(v.Oferta_Codigo,1,10) = o.oferta_codigo_viejo AND 
						  c.cupon_fecha = v.Oferta_Fecha_Compra AND
						  clie.clie_dni = v.Cli_Dni AND
						  v.Oferta_Fecha = o.oferta_fecha AND
						  CONVERT(INT,SUBSTRING(v.Oferta_codigo, 11,LEN(v.Oferta_codigo))) = c.cupon_cantidad
					)
			FROM gd_esquema.Maestra v
			WHERE v.Oferta_Entregado_Fecha IS NOT NULL AND v.Factura_Nro IS NULL
			ORDER BY 1 ASC

SELECT Factura_Nro, Factura_Fecha FROM gd_esquema.Maestra
WHERE Factura_Nro IS NOT NULL
GROUP BY Factura_Nro,Factura_Fecha
ORDER BY Factura_Nro


SELECT * FROM S_QUERY.Funcionalidad