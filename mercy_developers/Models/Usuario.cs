using System;
using System.Collections.Generic;

namespace mercy_developers.Models;

public partial class Usuario
{
    public int Rut { get; set; }

    public string? Nombre { get; set; }

    public string? Apellido { get; set; }

    public string? Pais { get; set; }

    public string? Ciudad { get; set; }

    public string? Telefono { get; set; }

    public string? Correo { get; set; }

    public string? Password { get; set; }

    public DateTime? Fechahora { get; set; }

    public string? Usuarioscol { get; set; }

    public virtual ICollection<UsuariosServicio> UsuariosServicios { get; set; } = new List<UsuariosServicio>();
}
