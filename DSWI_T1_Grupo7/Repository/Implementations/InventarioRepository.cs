using DSWI_T1_Grupo7.Data;
using DSWI_T1_Grupo7.Models;
using DSWI_T1_Grupo7.Repository.Interfaces;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace DSWI_T1_Grupo7.Repository.Implementations;

public class InventarioRepository : IInventarioRepository
{
    private readonly InventarioContext _context;

    public InventarioRepository(InventarioContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Inventario>> ObtenerTodos()
    {
        return await _context.Inventarios
            .FromSqlRaw("EXEC dbo.usp_Inventario_Listar")
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<Inventario?> ObtenerPorId(int id)
    {
        var parametro = new SqlParameter("@InventarioID", SqlDbType.Int) { Value = id };
        var resultado = await _context.Inventarios
            .FromSqlRaw("EXEC dbo.usp_Inventario_ObtenerPorId @InventarioID", parametro)
            .AsNoTracking()
            .ToListAsync();
        return resultado.FirstOrDefault();
    }

    public async Task Crear(Inventario inventario)
    {
        var fecha = new SqlParameter("@FechaIngreso", SqlDbType.Date)
        { Value = (object?)inventario.FechaIngreso?.ToDateTime(TimeOnly.MinValue) ?? DBNull.Value };
        var cantidad = new SqlParameter("@Cantidad", SqlDbType.Int)
        { Value = (object?)inventario.Cantidad ?? DBNull.Value };
        var ubicacion = new SqlParameter("@Ubicacion", SqlDbType.NVarChar, 100)
        { Value = (object?)inventario.Ubicacion ?? DBNull.Value };
        var estado = new SqlParameter("@Estado", SqlDbType.NVarChar, 50)
        { Value = (object?)inventario.Estado ?? DBNull.Value };
        var productoId = new SqlParameter("@ProductoID", SqlDbType.Int)
        { Value = (object?)inventario.ProductoId ?? DBNull.Value };

        await _context.Database.ExecuteSqlRawAsync(
            "EXEC dbo.usp_Inventario_Crear @FechaIngreso, @Cantidad, @Ubicacion, @Estado, @ProductoID",
            fecha, cantidad, ubicacion, estado, productoId);
    }

    public async Task Editar(Inventario inventario)
    {
        var id = new SqlParameter("@InventarioID", SqlDbType.Int) { Value = inventario.InventarioId };
        var fecha = new SqlParameter("@FechaIngreso", SqlDbType.Date)
        { Value = (object?)inventario.FechaIngreso?.ToDateTime(TimeOnly.MinValue) ?? DBNull.Value };
        var cantidad = new SqlParameter("@Cantidad", SqlDbType.Int)
        { Value = (object?)inventario.Cantidad ?? DBNull.Value };
        var ubicacion = new SqlParameter("@Ubicacion", SqlDbType.NVarChar, 100)
        { Value = (object?)inventario.Ubicacion ?? DBNull.Value };
        var estado = new SqlParameter("@Estado", SqlDbType.NVarChar, 50)
        { Value = (object?)inventario.Estado ?? DBNull.Value };
        var productoId = new SqlParameter("@ProductoID", SqlDbType.Int)
        { Value = (object?)inventario.ProductoId ?? DBNull.Value };

        await _context.Database.ExecuteSqlRawAsync(
            "EXEC dbo.usp_Inventario_Editar @InventarioID, @FechaIngreso, @Cantidad, @Ubicacion, @Estado, @ProductoID",
            id, fecha, cantidad, ubicacion, estado, productoId);
    }
}
