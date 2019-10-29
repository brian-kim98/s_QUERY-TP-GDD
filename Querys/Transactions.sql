USE GD2C2019;

DROP TABLE S_QUERY.FuncionalidadXRol 
DROP TABLE S_QUERY.RolXUsuario
DROP TABLE S_QUERY.Funcionalidad
DROP TABLE S_QUERY.Rol
DROP TABLE S_QUERY.Carga
DROP TABLE S_QUERY.Tipo_Pago
DROP TABLE S_QUERY.Tarjeta
DROP TABLE S_QUERY.Entrega
DROP TABLE S_QUERY.Cupon
DROP TABLE S_QUERY.Factura
DROP TABLE S_QUERY.Oferta
DROP TABLE S_QUERY.Proveedor
DROP TABLE S_QUERY.Cliente
DROP TABLE S_QUERY.Rubro
DROP TABLE S_QUERY.Direccion
DROP TABLE S_QUERY.Usuario

BEGIN TRANSACTION
		
		INSERT INTO S_QUERY.Rubro(rubro_nombre)
		SELECT DISTINCT Provee_Rubro FROM gd_esquema.Maestra WHERE
		Provee_Rubro IS NOT NULL
		
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
		
		INSERT INTO S_QUERY.Cliente (clie_nombre, clie_apellido, clie_dni, clie_mail, clie_telefono, clie_fecha_nacimiento, clie_saldo)
			SELECT DISTINCT cli_nombre, 
				cli_apellido,cli_dni, cli_mail, Cli_Telefono, Cli_Fecha_Nac, 200.0 FROM gd_esquema.Maestra
		
		INSERT INTO S_QUERY.Tipo_Pago (tipo_pago_nombre)
			SELECT DISTINCT Tipo_Pago_Desc FROM gd_esquema.Maestra WHERE
			Tipo_Pago_Desc IS NOT NULL
		
		INSERT INTO S_QUERY.Carga(carga_fecha, carga_monto, clie_codigo, tipo_pago_codigo)
			SELECT Carga_Fecha, Carga_Credito,
				(SELECT DISTINCT clie_codigo FROM S_QUERY.Cliente
				WHERE clie_dni = Cli_Dni AND Cli_Dni IS NOT NULL),
				(SELECT DISTINCT tipo_pago_codigo FROM S_QUERY.Tipo_Pago
				WHERE tipo_pago_nombre = Tipo_Pago_Desc AND Tipo_Pago_Desc IS NOT NULL)
			FROM gd_esquema.Maestra
			WHERE Carga_Fecha IS NOT NULL AND Carga_Credito IS NOT NULL
		
		
		INSERT INTO S_QUERY.Oferta(oferta_descripcion, oferta_fecha, oferta_fecha_vencimiento, oferta_precio,
		oferta_precio_lista, oferta_cantidad_disponible, oferta_maximo_compra, prov_codigo)
			SELECT DISTINCT Oferta_Descripcion, Oferta_Fecha, Oferta_Fecha_Venc, Oferta_Precio, Oferta_Precio_Ficticio,
			0, Oferta_Cantidad, 
			(SELECT prov_codigo FROM S_QUERY.Proveedor WHERE prov_cuit = Provee_CUIT)			
			FROM gd_esquema.Maestra
			WHERE Oferta_Descripcion IS NOT NULL AND Oferta_Fecha IS NOT NULL AND Oferta_Fecha_Venc IS NOT NULL 
			AND Oferta_Precio IS NOT NULL AND Oferta_Precio_Ficticio IS NOT NULL AND Oferta_Cantidad IS NOT NULL
		
COMMIT


SELECT * FROM S_QUERY.Cliente;

SELECT * FROM S_QUERY.Proveedor;

SELECT * FROM S_QUERY.Rubro;

SELECT * FROM S_QUERY.Tipo_Pago

SELECT * FROM S_QUERY.Carga

SELECT * FROM S_QUERY.Oferta

SELECT COUNT(Carga_Credito) FROM gd_esquema.Maestra

SELECT Cli_Nombre,Provee_RS, Oferta_Descripcion, Oferta_Cantidad, Oferta_Codigo, Oferta_Fecha, Oferta_Fecha_Venc FROM gd_esquema.Maestra
WHERE Oferta_Descripcion IS NOT NULL AND Oferta_Cantidad = 5
ORDER BY Provee_RS,Oferta_Descripcion, Oferta_Fecha_Venc ASC

SELECT * FROM gd_esquema.Maestra 
WHERE Oferta_Codigo IS NOT NULL
ORDER BY Oferta_Codigo

SELECT DISTINCT Cli_Nombre FROM gd_esquema.Maestra
WHERE Carga_Credito IS NOT NULL AND Cli_Nombre IS NOT NULL

SELECT * FROM gd_esquema.Maestra
WHERE Oferta_Codigo IS NOT NULL
ORDER BY Oferta_Codigo DESC

Select SUBSTRING(Oferta_Codigo, 1, 10), COUNT(SUBSTRING(Oferta_Codigo, 1, 10)) FROM gd_esquema.Maestra
WHERE Oferta_Codigo IS NOT NULL
GROUP BY SUBSTRING(Oferta_Codigo, 1, 10)
ORDER BY 1

SELECT Oferta_Descripcion, Oferta_Fecha, Oferta_Fecha_Venc, Oferta_Precio, Oferta_Precio_Ficticio,
			0, Oferta_Cantidad
FROM gd_esquema.Maestra
WHERE Oferta_Descripcion IS NOT NULL AND Oferta_Fecha IS NOT NULL AND Oferta_Fecha_Venc IS NOT NULL 
			AND Oferta_Precio IS NOT NULL AND Oferta_Precio_Ficticio IS NOT NULL AND Oferta_Cantidad IS NOT NULL
GROUP BY Oferta_Descripcion, Oferta_Fecha, Oferta_Fecha_Venc, Oferta_Precio, Oferta_Precio_Ficticio,
		 Oferta_Cantidad
ORDER BY Oferta_Fecha ASC
