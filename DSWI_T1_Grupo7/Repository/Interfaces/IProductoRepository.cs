
using DSWI_T1_Grupo7.Models;

namespace DSWI_T1_Grupo7.Repository.Interfaces
{
    public interface IProductoRepository
    {
        Task<IEnumerable<Producto>> ObtenerTodos();
        Task<Producto?> ObtenerPorId(int id);
    }
}
