/*---direcciones---*/
SELECT substring(g.direc,1,
		len(g.direc) - 5 + charindex(' ',substring(g.direc,len(g.direc) - 3,4)) 
		) as direccion,
		substring(g.direc, len(g.direc) - 3 + charindex(' ',substring(g.direc,len(g.direc) - 3,4)),4) as numero
		
FROM 
(SELECT DISTINCT Cli_Dni as dni, Cli_Direccion as direc FROM gd_esquema.Maestra WHERE Cli_Dni IS NOT NULL) g


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



