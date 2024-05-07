using System;
using System.Collections.Generic;

namespace mercy_developers.Models;

public partial class UsuariosServicio
{
    public int UsuariosRut { get; set; }

    public int ServiciosIdServ { get; set; }

    public string? Estado { get; set; }

    public string? Duracion { get; set; }

    public string? NombreTecnico { get; set; }

    public DateTime? FechaRegistro { get; set; }

    public TimeOnly? HoraInicio { get; set; }

    public TimeOnly? HoraTermino { get; set; }

    public virtual Servicio ServiciosIdServNavigation { get; set; } = null!;

    public virtual Usuario UsuariosRutNavigation { get; set; } = null!;
}
