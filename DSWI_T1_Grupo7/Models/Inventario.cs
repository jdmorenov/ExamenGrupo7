using System;
using System.Collections.Generic;

namespace DSWI_T1_Grupo7.Models;

public partial class Inventario
{
    public int InventarioId { get; set; }

    public DateOnly? FechaIngreso { get; set; }

    public int? Cantidad { get; set; }

    public string? Ubicacion { get; set; }

    public string? Estado { get; set; }

    public int? ProductoId { get; set; }

    public virtual Producto? Producto { get; set; }
}
