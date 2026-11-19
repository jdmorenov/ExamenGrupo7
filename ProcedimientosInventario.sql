USE InventarioBD;
GO

CREATE OR ALTER PROCEDURE dbo.usp_Productos_Listar
AS
BEGIN
    SET NOCOUNT ON;
    SELECT ProductoID, Nombre, Categoria
    FROM dbo.Productos
    ORDER BY ProductoID;
END;
GO

CREATE OR ALTER PROCEDURE dbo.usp_Productos_ObtenerPorId
    @ProductoID INT
AS
BEGIN
    SET NOCOUNT ON;
    SELECT ProductoID, Nombre, Categoria
    FROM dbo.Productos
    WHERE ProductoID = @ProductoID;
END;
GO

CREATE OR ALTER PROCEDURE dbo.usp_Productos_Crear
    @Nombre NVARCHAR(100),
    @Categoria NVARCHAR(50)
AS
BEGIN
    SET NOCOUNT ON;
    INSERT INTO dbo.Productos (Nombre, Categoria)
    VALUES (@Nombre, @Categoria);
END;
GO

CREATE OR ALTER PROCEDURE dbo.usp_Productos_Editar
    @ProductoID INT,
    @Nombre NVARCHAR(100),
    @Categoria NVARCHAR(50)
AS
BEGIN
    SET NOCOUNT ON;
    UPDATE dbo.Productos
    SET Nombre = @Nombre,
        Categoria = @Categoria
    WHERE ProductoID = @ProductoID;
END;
GO

CREATE OR ALTER PROCEDURE dbo.usp_Inventario_Listar
AS
BEGIN
    SET NOCOUNT ON;
    SELECT InventarioID, FechaIngreso, Cantidad, Ubicacion, Estado, ProductoID
    FROM dbo.Inventario
    ORDER BY InventarioID;
END;
GO

CREATE OR ALTER PROCEDURE dbo.usp_Inventario_ObtenerPorId
    @InventarioID INT
AS
BEGIN
    SET NOCOUNT ON;
    SELECT InventarioID, FechaIngreso, Cantidad, Ubicacion, Estado, ProductoID
    FROM dbo.Inventario
    WHERE InventarioID = @InventarioID;
END;
GO

CREATE OR ALTER PROCEDURE dbo.usp_Inventario_Crear
    @FechaIngreso DATE,
    @Cantidad INT,
    @Ubicacion NVARCHAR(100),
    @Estado NVARCHAR(50),
    @ProductoID INT
AS
BEGIN
    SET NOCOUNT ON;
    INSERT INTO dbo.Inventario (FechaIngreso, Cantidad, Ubicacion, Estado, ProductoID)
    VALUES (@FechaIngreso, @Cantidad, @Ubicacion, @Estado, @ProductoID);
END;
GO

CREATE OR ALTER PROCEDURE dbo.usp_Inventario_Editar
    @InventarioID INT,
    @FechaIngreso DATE,
    @Cantidad INT,
    @Ubicacion NVARCHAR(100),
    @Estado NVARCHAR(50),
    @ProductoID INT
AS
BEGIN
    SET NOCOUNT ON;
    UPDATE dbo.Inventario
    SET FechaIngreso = @FechaIngreso,
        Cantidad = @Cantidad,
        Ubicacion = @Ubicacion,
        Estado = @Estado,
        ProductoID = @ProductoID
    WHERE InventarioID = @InventarioID;
END;
GO
