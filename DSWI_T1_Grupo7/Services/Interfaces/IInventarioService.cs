using DSWI_T1_Grupo7.Models;

namespace DSWI_T1_Grupo7.Services.Interfaces;

public interface IInventarioService
{
    Task<IEnumerable<Inventario>> ObtenerTodos();
    Task<Inventario?> ObtenerPorId(int id);
    Task Crear(Inventario inventario);
    Task Editar(Inventario inventario);
}
