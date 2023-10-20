using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace INSI_WEB_API.Models;

public partial class Tutores
{
    
    public int ?IdTutor { get; set; }
    
    public int? IdEstudiante { get; set; } = null!;

    public string? Nombre { get; set; } = null!;

    public string? Apellido { get; set; } = null!;

    public string? Direccion { get; set; } = null!;

    public string? Telefono { get; set; } = null!;

    public string? RelacionConEstudiante { get; set; } = null!;
    [JsonIgnore]
    public virtual Estudiante? oEstudiante { get; set; }
    [JsonIgnore]
    public virtual ICollection<Matricula> Matriculas { get; set; } = new List<Matricula>();
}
