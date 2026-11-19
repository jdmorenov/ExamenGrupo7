using DSWI_T1_Grupo7.Models;
using DSWI_T1_Grupo7.Repository.Interfaces;
using DSWI_T1_Grupo7.Services.Interfaces;

namespace DSWI_T1_Grupo7.Services.Implementations;

public class InventarioService : IInventarioService
{
    private readonly IInventarioRepository _repository;

    public InventarioService(IInventarioRepository repository)
    {
        _repository = repository;
    }

    public Task<IEnumerable<Inventario>> ObtenerTodos() => _repository.ObtenerTodos();
    public Task<Inventario?> ObtenerPorId(int id) => _repository.ObtenerPorId(id);
    public Task Crear(Inventario inventario) => _repository.Crear(inventario);
    public Task Editar(Inventario inventario) => _repository.Editar(inventario);
}
