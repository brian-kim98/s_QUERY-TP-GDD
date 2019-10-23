USE GD2C2019;

BEGIN TRANSACTION 
	declare @nombre nvarchar(255)
	declare @fecha_nacimiento datetime
	declare @apellido nvarchar(255)
	declare @dni numeric(18,0)
	declare @email nvarchar(255)
	declare @telefono numeric(18, 0)
	--declare @saldo     falta esto brooo  
	declare cli_cursor CURSOR 
		FOR SELECT DISTINCT Cli_Nombre, Cli_Apellido, Cli_Dni, Cli_Fecha_Nac, Cli_Mail, Cli_Telefono
			FROM GD2C2019.gd_esquema.Maestra
	OPEN cli_cursor
		FETCH cli_cursor INTO @nombre, @apellido, @dni, @fecha_nacimiento, @email, @telefono
			WHILE @@FETCH_STATUS = 0
		BEGIN 
			INSERT INTO S_QUERY.Cliente (clie_nombre, clie_apellido, clie_dni, clie_fecha_nacimiento, clie_mail, clie_telefono, clie_saldo)
				VALUES( @nombre, @apellido,@dni,@fecha_nacimiento, @email, @telefono, 200.00)
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
	declare @habilitado bit
	SET @habilitado = 1

	BEGIN TRANSACTION

		declare rubro_cursor CURSOR FOR
			SELECT DISTINCT Provee_rubro FROM GD2C2019.gd_esquema.Maestra
			WHERE Provee_Rubro IS NOT NULL

		OPEN rubro_cursor
			FETCH rubro_cursor INTO @prov_rubro
				WHILE @@FETCH_STATUS = 0
				BEGIN 
					INSERT INTO S_QUERY.Rubro(rubro_nombre)
						VALUES(@prov_rubro)
					FETCH rubro_cursor INTO @prov_rubro
				END
			CLOSE rubro_cursor
		DEALLOCATE rubro_cursor
	COMMIT

	declare prov_cursor CURSOR FOR
		SELECT DISTINCT Provee_RS, Provee_Rubro, Provee_Telefono, Provee_CUIT, Provee_Ciudad FROM GD2C2019.gd_esquema.Maestra
		WHERE Provee_RS IS NOT NUll 
		AND Provee_Rubro IS NOT NULL 
		AND Provee_Telefono IS NOT NULL 
		AND Provee_CUIT IS NOT NULL
		AND Provee_Dom IS NOT NULL 
		AND Provee_Ciudad IS NOT NULL
	OPEN prov_cursor 
		FETCH prov_cursor INTO @prov_razonsocial, @prov_rubro ,@prov_telefono, @prov_CUIT, @prov_ciudad
			WHILE @@FETCH_STATUS = 0
		BEGIN
			INSERT INTO S_QUERY.Proveedor (prov_razon_social , prov_telefono, prov_cuit, rubro_codigo, prov_ciudad, prov_habilitado)
				VALUES( @prov_razonsocial, @prov_telefono, @prov_CUIT, (SELECT rubro_codigo FROM S_QUERY.Rubro WHERE rubro_nombre = @prov_rubro),
						@prov_ciudad, @habilitado)
			FETCH prov_cursor INTO @prov_razonsocial, @prov_rubro, @prov_telefono, @prov_CUIT, @prov_ciudad
		END
	CLOSE prov_cursor
	DEALLOCATE prov_cursor
COMMIT

SELECT * FROM S_QUERY.Cliente;

SELECT * FROM S_QUERY.Proveedor;

SELECT * FROM S_QUERY.Rubro;

SELECT * FROM gd_esquema.Maestra