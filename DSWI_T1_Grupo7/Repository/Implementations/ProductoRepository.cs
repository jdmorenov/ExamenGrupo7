using DSWI_T1_Grupo7.Data;
using DSWI_T1_Grupo7.Models;
using DSWI_T1_Grupo7.Repository.Interfaces;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace DSWI_T1_Grupo7.Repository.Implementations;

public class ProductoRepository : IProductoRepository
{
    private readonly InventarioContext _context;

    public ProductoRepository(InventarioContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Producto>> ObtenerTodos()
    {
        return await _context.Productos
            .FromSqlRaw("EXEC dbo.usp_Productos_Listar")
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<Producto?> ObtenerPorId(int id)
    {
        var parametro = new SqlParameter("@ProductoID", SqlDbType.Int) { Value = id };
        var resultado = await _context.Productos
            .FromSqlRaw("EXEC dbo.usp_Productos_ObtenerPorId @ProductoID", parametro)
            .AsNoTracking()
            .ToListAsync();
        return resultado.FirstOrDefault();
    }

    public async Task Crear(Producto producto)
    {
        var nombre = new SqlParameter("@Nombre", SqlDbType.NVarChar, 100)
        { Value = (object?)producto.Nombre ?? DBNull.Value };
        var categoria = new SqlParameter("@Categoria", SqlDbType.NVarChar, 50)
        { Value = (object?)producto.Categoria ?? DBNull.Value };

        await _context.Database.ExecuteSqlRawAsync(
            "EXEC dbo.usp_Productos_Crear @Nombre, @Categoria", nombre, categoria);
    }

    public async Task Editar(Producto producto)
    {
        var id = new SqlParameter("@ProductoID", SqlDbType.Int) { Value = producto.ProductoId };
        var nombre = new SqlParameter("@Nombre", SqlDbType.NVarChar, 100)
        { Value = (object?)producto.Nombre ?? DBNull.Value };
        var categoria = new SqlParameter("@Categoria", SqlDbType.NVarChar, 50)
        { Value = (object?)producto.Categoria ?? DBNull.Value };

        await _context.Database.ExecuteSqlRawAsync(
            "EXEC dbo.usp_Productos_Editar @ProductoID, @Nombre, @Categoria", id, nombre, categoria);
    }
}
