using System;
using System.Collections.Generic;

namespace mercy_developers.Models;

public partial class Servicio
{
    public int IdServ { get; set; }

    public string? TipoServicio { get; set; }

    public string? Precio { get; set; }

    public string? Disponibilidad { get; set; }

    public string? Estado { get; set; }

    public DateTime? FechaIngreso { get; set; }

    public virtual ICollection<UsuariosServicio> UsuariosServicios { get; set; } = new List<UsuariosServicio>();
}
