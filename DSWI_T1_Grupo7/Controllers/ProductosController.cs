using DSWI_T1_Grupo7.Models;
using DSWI_T1_Grupo7.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DSWI_T1_Grupo7.Controllers;

public class ProductosController : Controller
{
    private readonly IProductoService _service;

    public ProductosController(IProductoService service)
    {
        _service = service;
    }

    public async Task<IActionResult> Index()
    {
        return View(await _service.ObtenerTodos());
    }

    public IActionResult Crear()
    {
        return View(new Producto());
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Crear(Producto producto)
    {
        if (!ModelState.IsValid) return View(producto);
        await _service.Crear(producto);
        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Editar(int id)
    {
        var producto = await _service.ObtenerPorId(id);
        if (producto == null) return NotFound();
        return View(producto);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Editar(int id, Producto producto)
    {
        if (id != producto.ProductoId) return BadRequest();
        if (!ModelState.IsValid) return View(producto);
        if (await _service.ObtenerPorId(id) == null) return NotFound();
        await _service.Editar(producto);
        return RedirectToAction(nameof(Index));
    }
}
