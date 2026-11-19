using DSWI_T1_Grupo7.Models;
using DSWI_T1_Grupo7.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DSWI_T1_Grupo7.Controllers;

public class InventariosController : Controller
{
    private readonly IInventarioService _inventarioService;
    private readonly IProductoService _productoService;

    public InventariosController(IInventarioService inventarioService, IProductoService productoService)
    {
        _inventarioService = inventarioService;
        _productoService = productoService;
    }

    public async Task<IActionResult> Index()
    {
        var inventarios = await _inventarioService.ObtenerTodos();
        var productos = await _productoService.ObtenerTodos();
        var nombres = productos.ToDictionary(p => p.ProductoId, p => p.Nombre ?? "(Sin nombre)");
        ViewBag.NombresProductos = nombres;
        return View(inventarios);
    }

    public async Task<IActionResult> Crear()
    {
        await CargarProductos();
        return View(new Inventario { FechaIngreso = DateOnly.FromDateTime(DateTime.Today) });
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Crear(Inventario inventario)
    {
        if (!ModelState.IsValid)
        {
            await CargarProductos(inventario.ProductoId);
            return View(inventario);
        }
        await _inventarioService.Crear(inventario);
        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Editar(int id)
    {
        var inventario = await _inventarioService.ObtenerPorId(id);
        if (inventario == null) return NotFound();
        await CargarProductos(inventario.ProductoId);
        return View(inventario);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Editar(int id, Inventario inventario)
    {
        if (id != inventario.InventarioId) return BadRequest();
        if (!ModelState.IsValid)
        {
            await CargarProductos(inventario.ProductoId);
            return View(inventario);
        }
        if (await _inventarioService.ObtenerPorId(id) == null) return NotFound();
        await _inventarioService.Editar(inventario);
        return RedirectToAction(nameof(Index));
    }

    private async Task CargarProductos(int? seleccionado = null)
    {
        var productos = await _productoService.ObtenerTodos();
        ViewBag.Productos = new SelectList(productos, "ProductoId", "Nombre", seleccionado);
    }
}
