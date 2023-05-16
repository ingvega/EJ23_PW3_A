using System;
using System.Collections.Generic;

namespace APIWebNWind.Models;

public partial class Cambiosdeprecio
{
    public int Id { get; set; }

    public int IdProducto { get; set; }

    public double PrecioOriginal { get; set; }

    public double PrecioNuevo { get; set; }

    public DateTime Fecha { get; set; }
}
