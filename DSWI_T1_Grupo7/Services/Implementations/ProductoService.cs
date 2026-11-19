using DSWI_T1_Grupo7.Models;
using DSWI_T1_Grupo7.Repository.Interfaces;
using DSWI_T1_Grupo7.Services.Interfaces;

namespace DSWI_T1_Grupo7.Services.Implementations;

public class ProductoService : IProductoService
{
    private readonly IProductoRepository _repository;

    public ProductoService(IProductoRepository repository)
    {
        _repository = repository;
    }

    public Task<IEnumerable<Producto>> ObtenerTodos() => _repository.ObtenerTodos();
    public Task<Producto?> ObtenerPorId(int id) => _repository.ObtenerPorId(id);
    public Task Crear(Producto producto) => _repository.Crear(producto);
    public Task Editar(Producto producto) => _repository.Editar(producto);
}
