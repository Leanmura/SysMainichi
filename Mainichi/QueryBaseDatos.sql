create database DBSISTEMA_MAINICHIDEMO
go

USE DBSISTEMA_MAINICHIDEMO
GO

create table CATEGORIA(
IdCategoria int primary key identity,
Descripcion varchar(50),

)
GO

create table PRODUCTO(
IdProducto int primary key identity,
Nombre varchar(50),
Descripcion varchar(50),
PrecioVenta decimal(10,2),
PrecioCompra decimal(10,2),
IdCategoria int references CATEGORIA(IdCategoria),
Imagen varbinary(MAX),
)
GO

create table VENTA(
IdVenta int primary key identity,
Gastos decimal(10,2),
CambioAntiguo decimal(10,2),
CambioNuevo decimal(10,2),
Total decimal(10,2),
Efectivo decimal(10,2),
TMercadoPago decimal(10,2),
TOtro decimal(10,2),
Fecha dateTime default getdate()

)
GO

create table DETALLE_COMPRA(
IdDetalleCompra int primary key identity,
IdVenta int references VENTA(IdVenta),
IdProducto int references PRODUCTO(IdProducto),
PrecioCompra decimal(10,2),
Cantidad int,
Total decimal(10,2),
FormaDePago varchar(50),
)
GO

create table DETALLE_VENTA(
IdDetalleVenta int primary key identity,
IdVenta int references VENTA(IdVenta),
IdProducto int references PRODUCTO(IdProducto),
PrecioVenta decimal(10,2),
Cantidad int,
Total decimal(10,2),
FormaDePago varchar(50),
)
go

create table NEGOCIO(
IdNegocio int primary key,
Nombre varchar(60),
Telefono varchar(60),
Direccion varchar(60),
Logo varbinary(max)NULL)

insert into NEGOCIO(IdNegocio,Nombre,Telefono,Direccion) values (1, 'Mainichi', '11 5616-5554', 'Av. Espora 1699')

/*           */


/* PROCEDIMIENTO PARA GUARDAR CATEGORIA*/
go

CREATE PROC SP_RegistrarCategoria(
	@Descripcion varchar(50),
	@Resultado int output,
	@Mensaje varchar(500) output
)as
begin
	SET @Resultado = 0
	IF NOT EXISTS(SELECT * FROM CATEGORIA c WHERE c.Descripcion = @Descripcion)
	begin
		INSERT INTO CATEGORIA(Descripcion) VALUES(@Descripcion)
		SET @Resultado = SCOPE_IDENTITY() /* Devuelve el ultimo id generado por esa tabla*/
	end
	ELSE
		SET @Mensaje = 'No se puede repetir la descripcion de una categoria.'
end

go

CREATE PROCEDURE SP_EditarCategoria(
	@IdCategoria int ,
	@Descripcion varchar(50),
	@Resultado bit output,
	@Mensaje varchar(500) output
)as
begin
	SET @Resultado = 1
	IF NOT EXISTS(SELECT * FROM CATEGORIA c WHERE c.Descripcion = @Descripcion and c.IdCategoria != @IdCategoria)
	begin
		UPDATE CATEGORIA SET
		Descripcion = @Descripcion
		WHERE IdCategoria = @IdCategoria
	end
	ELSE
		SET @Resultado = 0
		SET @Mensaje = 'No se puede repetir la descripcion de una categoria.'
end

go

CREATE PROCEDURE SP_EliminarCategoria(
	@IdCategoria int ,
	@Resultado bit output,
	@Mensaje varchar(500) output
)as
begin
	SET @Resultado = 1
	IF NOT EXISTS(
		SELECT * FROM CATEGORIA c 
		INNER JOIN PRODUCTO p on p.IdCategoria = c.IdCategoria
		WHERE c.IdCategoria = @IdCategoria)
	begin
		DELETE top(1) FROM CATEGORIA WHERE IdCategoria = @IdCategoria
	end
	ELSE
		SET @Resultado = 0
		SET @Mensaje = 'La categoria se encuentra relacionada a un producto.'
end

go

/* PROCEDIMIENTO PARA GUARDAR PRODUCTOS*/

Create PROCedure SP_RegistrarProducto(
   @Nombre varchar(50),
   @Descripcion varchar(50),
   @IdCategoria int,
   @PrecioVenta decimal,
   @Imagen varBinary(MAX),
	 @Resultado int output,
   @Mensaje varchar(500) output
) as
begin
	SET @Resultado = 0
	IF NOT EXISTS(SELECT * FROM PRODUCTO p WHERE p.Nombre = @Nombre)
	begin
		INSERT INTO PRODUCTO(Nombre,Descripcion,IdCategoria,PrecioVenta,Imagen) VALUES(@Nombre,@Descripcion,@IdCategoria,@PrecioVenta,@Imagen)
		SET @Resultado = SCOPE_IDENTITY() /* Devuelve el ultimo id generado por esa tabla*/
	end
	ELSE
		SET @Mensaje = 'No se puede repetir el nombre de un Producto.'
end

go

CREATE PROCEDURE SP_EditarProducto(
	@IdProducto int ,
	@Nombre varchar(50),
	@Descripcion varchar(50),
	@PrecioVenta decimal,
	@PrecioCompra decimal,
	@IdCategoria int,
   @Imagen varBinary(MAX),
	@Resultado bit output,
	@Mensaje varchar(500) output
)as
begin
	SET @Resultado = 1
	IF NOT EXISTS(SELECT * FROM PRODUCTO p WHERE p.Nombre = @Nombre and p.IdProducto != @IdProducto)
	begin
		UPDATE PRODUCTO SET
		Nombre = @Nombre,
		Descripcion = @Descripcion,
		PrecioVenta = @PrecioVenta,
		PrecioCompra = @PrecioCompra,
		IdCategoria = @IdCategoria,
		Imagen = @Imagen
		WHERE IdProducto = @IdProducto
	end
	ELSE
		SET @Resultado = 0
		SET @Mensaje = 'No se puede repetir el nombre de un Producto.'
end

go

CREATE PROCEDURE SP_EliminarProducto(
	@IdProducto int ,
	@Resultado bit output,
	@Mensaje varchar(500) output
)as
begin
	SET @Resultado = 1
	SET @Mensaje = ''
	IF EXISTS(
		SELECT * FROM DETALLE_COMPRA d
		INNER JOIN PRODUCTO p on p.IdProducto = d.IdProducto
		WHERE p.IdProducto = @IdProducto)
	begin
		SET @Resultado = 0
		SET @Mensaje += 'El producto se encuentra relacionada a una compra.'
	end
	IF EXISTS(
		SELECT * FROM DETALLE_VENTA d
		INNER JOIN PRODUCTO p on p.IdProducto = d.IdProducto
		WHERE p.IdProducto = @IdProducto)
	begin
		SET @Resultado = 0
		SET @Mensaje += 'El producto se encuentra relacionada a una venta.'
	end
	IF(@Resultado = 1)
	begin
		DELETE top(1) FROM PRODUCTO WHERE IdProducto = @IdProducto
	end

end


/* Proceso para registrar venta */
go

create TYPE [dbo]. [EDetalle_Venta] AS TABLE(
     [IdProducto] int NULL,
     [PrecioVenta] decimal(10,2) NULL,
     [Cantidad] int NULL,
     [Total] decimal(10,2) NULL,
     [FormaDePago] varchar(50) NULL
	 )

go

create TYPE [dbo]. [EDetalle_Compra] AS TABLE(
     [IdProducto] int NULL,
     [PrecioCompra] decimal(10,2) NULL,
     [Cantidad] int NULL,
     [Total] decimal(10,2) NULL,
     [FormaDePago] varchar(50) NULL
	 )

GO

CREATE PROCEDURE SP_RegistrarVenta(
	@Gastos	decimal(10, 2),	
	@CambioAntiguo	decimal(10, 2),	
	@CambioNuevo	decimal(10, 2),
	@Total	decimal(10, 2),	
	@Efectivo	decimal(10, 2),	
	@TMercadoPago decimal(10, 2),	
	@TOtro decimal(10, 2),	
	@DetalleVenta [EDetalle_Venta] READONLY,
	@DetalleCompra [EDetalle_Compra] READONLY,
	@Fecha datetime,
	@Resultado bit output,
	@Mensaje varchar(500) output
) as
begin
     begin try
         declare @idVenta int=0
         set @Resultado = 1
         set @Mensaje = ''
         begin transaction registro /* si hay algun error en la transaccion, lo atrapa el catch y hace el rollback*/
			 insert into VENTA(Gastos,CambioAntiguo,CambioNuevo,Total, Efectivo, TMercadoPago, TOtro, Fecha)
			 values (@Gastos, @CambioAntiguo ,@CambioNuevo, @Total, @Efectivo, @TMercadoPago, @TOtro, @Fecha)
			 set @idVenta = SCOPE_IDENTITY()
			 insert into DETALLE_VENTA(IdVenta, IdProducto, PrecioVenta, Cantidad, Total, FormaDePago)
			 select @idVenta, IdProducto, PrecioVenta, Cantidad, Total, FormaDePago from @DetalleVenta
			 insert into DETALLE_COMPRA(IdVenta, IdProducto, PrecioCompra, Cantidad, Total, FormaDePago)
			 select @idVenta, IdProducto, PrecioCompra, Cantidad, Total, FormaDePago from @DetalleCompra
         commit transaction registro
     end try
     begin catch
		 set @Resultado = 0;
		 set @Mensaje = ERROR_MESSAGE()
         rollback transaction registro
     end catch
end

go

CREATE PROCEDURE SP_EditarVenta(
	@Gastos	decimal(10, 2),	
	@CambioAntiguo	decimal(10, 2),	
	@CambioNuevo	decimal(10, 2),
	@Total	decimal(10, 2),	
	@Efectivo	decimal(10, 2),	
	@TMercadoPago decimal(10, 2),	
	@TOtro decimal(10, 2),	
	@DetalleVenta [EDetalle_Venta] READONLY,
	@DetalleCompra [EDetalle_Compra] READONLY,
	@Fecha datetime,
	@Resultado bit output,
	@Mensaje varchar(500) output
)as
begin
    declare @idVenta int =0
	SET @Resultado = 1
    set @Mensaje = ''
	set @idVenta = (select idVenta from VENTA where CONVERT(char(10), Fecha,105) = CONVERT(char(10), @Fecha,105))

	begin try
		begin transaction registro /* si hay algun error en la transaccion, lo atrapa el catch y hace el rollback*/
			delete from DETALLE_COMPRA 
			FROM DETALLE_COMPRA dv 
			INNER JOIN VENTA v on v.IdVenta = dv.IdVenta 
			where CONVERT(char(10), v.Fecha,105) = CONVERT(char(10), @Fecha,105)

			delete from DETALLE_VENTA 
			FROM DETALLE_VENTA dv 
			INNER JOIN VENTA v on v.IdVenta = dv.IdVenta 
			where CONVERT(char(10), v.Fecha,105) = CONVERT(char(10), @Fecha,105)

			update VENTA set Gastos = @Gastos, CambioAntiguo = @CambioAntiguo, CambioNuevo = @CambioNuevo, 
				Total =@Total, Efectivo = @Efectivo, TMercadoPago = @TMercadoPago, TOtro = @TOtro
				where CONVERT(char(10), Fecha,105) = CONVERT(char(10), @Fecha,105)
			 insert into DETALLE_VENTA(IdVenta, IdProducto, PrecioVenta, Cantidad, Total, FormaDePago)
			 select @idVenta, IdProducto, PrecioVenta, Cantidad, Total, FormaDePago from @DetalleVenta
			 insert into DETALLE_COMPRA(IdVenta, IdProducto, PrecioCompra, Cantidad, Total, FormaDePago)
			 select @idVenta, IdProducto, PrecioCompra, Cantidad, Total, FormaDePago from @DetalleCompra
         commit transaction registro
     end try
     begin catch
		 set @Resultado = 0;
		 set @Mensaje = ERROR_MESSAGE()
         rollback transaction registro
     end catch

end

go

create PROCEDURE SP_TotalPorCategoria(
	@Categoria varchar(50) ,
	@Fecha dateTime
)AS
begin

	SELECT SUM(dv.Total)[TOTAL] FROM VENTA v
	inner join DETALLE_VENTA dv on dv.IdVenta = v.IdVenta
	inner join PRODUCTO p on p.IdProducto = dv.IdProducto
	inner join CATEGORIA c on c.IdCategoria = p.IdCategoria
	WHERE  c.Descripcion = @Categoria and 
	CONVERT(char(10), v.Fecha, 105) = CONVERT(char(10), @Fecha, 105)
end

go
INSERT INTO CATEGORIA(Descripcion) VALUES('BEBIDA')

go
INSERT INTO CATEGORIA(Descripcion) VALUES('COMIDA')

go
INSERT INTO CATEGORIA(Descripcion) VALUES('CANCHA')

go