using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;


namespace INSI_WEB_API.Models;

public partial class Matricula
{

   
    public int ?IdMatricula { get; set; }
    
    public int ?IdEstudiante { get; set; }
    
    public int? IdTutor { get; set; }

    public DateTime ?FechaMatricula { get; set; } = null!;

    public string? EstadoMatricula { get; set; } = null!;

    public string ?GradoSolicitado { get; set; } = null!;

    public virtual Estudiante? oEstudiante { get; set; } 

    public virtual Tutores? oTutores { get; set; }

}
