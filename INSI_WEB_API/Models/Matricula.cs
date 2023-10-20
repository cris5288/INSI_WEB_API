using System;
using System.Collections.Generic;

namespace INSI_WEB_API.Models;

public partial class Matricula
{
    public int? IdMatricula { get; set; }

    public int? IdEstudiante { get; set; } = null!;

    public int? IdTutor { get; set; } = null!;

    public DateTime? FechaMatricula { get; set; } = null!;

    public string? EstadoMatricula { get; set; } = null!;

    public string? GradoSolicitado { get; set; } = null!;

    public virtual Estudiante? oEstudiante { get; set; }

    public virtual Tutores? oTutores { get; set; }
}
