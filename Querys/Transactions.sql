BEGIN TRANSACTION 
	declare @nombre nvarchar(255)
	declare @fecha_nacimiento datetime
	declare @apellido nvarchar(255)
	declare @dni numeric(18,0)
	declare @email nvarchar(255)
	declare @telefono numeric(18, 0)
	--declare @saldo     falta esto brooo  
	declare cli_cursor CURSOR 
		FOR SELECT Cli_Nombre, Cli_Apellido, Cli_Dni, Cli_Fecha_Nac, Cli_Mail, Cli_Telefono FROM gd_esquema.Maestra 
		GROUP BY Cli_Nombre, Cli_Apellido, Cli_Dni, Cli_Fecha_Nac, Cli_Mail, Cli_Telefono
	OPEN cli_cursor
		FETCH cli_cursor INTO @nombre, @apellido, @dni, @fecha_nacimiento, @email, @telefono
			WHILE @@FETCH_STATUS = 0
		BEGIN 
			INSERT INTO S_QUERY.Cliente ( clie_nombre, clie_apellido, clie_dni, clie_fecha_nacimiento, clie_mail, clie_telefono)
				VALUES( isnull(@nombre, 'Desconocido'), isnull(@apellido, 'Desconocido'), isnull(@dni, '0000') , isnull(@fecha_nacimiento, '01-01-01 00:00:01 AM' ),
				 isnull(@email, 'Desconocido'), isnull(@telefono, '0000000'))
			FETCH cli_cursor INTO @nombre, @apellido, @dni, @fecha_nacimiento, @email, @telefono
		END
	CLOSE cli_cursor
	DEALLOCATE cli_cursor
COMMIT

BEGIN TRANSACTION 
	declare @prov_razonsocial nvarchar(255)
	declare @prov_telefono numeric(18, 0)
	declare @prov_CUIT nvarchar(20)
	declare @prov_rubro nvarchar(100)
	declare @prov_ciudad nvarchar(255)
	declare prov_cursor CURSOR FOR
		SELECT Provee_RS , Provee_Telefono, Provee_CUIT, Provee_Rubro, Provee_Ciudad FROM gd_esquema.Maestra
		WHERE Provee_RS IS NOT NULL
		GROUP BY Provee_RS, Provee_Telefono, Provee_CUIT, Provee_Rubro, Provee_Ciudad
	OPEN prov_cursor 
		FETCH prov_cursor INTO @prov_razonsocial, @prov_telefono, @prov_CUIT, @prov_rubro, @prov_ciudad
			WHILE @@FETCH_STATUS = 0
		BEGIN
			INSERT INTO S_QUERY.Proveedor (prov_razon_social , prov_telefono, prov_cuit, prov_rubro, prov_ciudad, prov_habilitado)
				VALUES( ISNULL(@prov_razonsocial, 'Desconocido') , ISNULL(@prov_telefono, '0000') , ISNULL(@prov_CUIT, 'Desconocido') , ISNULL(@prov_rubro, 'Desconocido') , 
					ISNULL(@prov_ciudad, 'Desconocido') , '1' )
			FETCH prov_cursor INTO @prov_razonsocial, @prov_telefono, @prov_CUIT, @prov_rubro, @prov_ciudad
		END
	CLOSE prov_cursor
	DEALLOCATE prov_cursor
COMMIT

SELECT * FROM gd_esquema.Maestra

IF OBJECT_ID('[GD2C2019].[S_QUERY].Cliente') IS NOT NULL
DROP TABLE S_QUERY.Proveedor

SELECT * from S_QUERY.Proveedor