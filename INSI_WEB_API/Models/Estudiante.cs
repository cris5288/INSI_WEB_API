﻿using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace INSI_WEB_API.Models;

public partial class Estudiante
{
    
    public int? IdEstudiante { get; set; }

    public string? Nombre { get; set; } = null!;

    public string? Apellido { get; set; } = null!;

    public DateTime? FechaNacimiento { get; set; } = null!;

    public string? LugarNacimiento { get; set; } = null!;

    public string? ZonaRecidencial { get; set; } = null!;

    public string? PartidaNacimiento { get; set; } = null!;

    public int? Edad { get; set; } = null!;

    public string? Genero { get; set; } = null!;

    public string? Direccion { get; set; } = null!;

    public string? Telefono { get; set; } = null!;

    public string? UltimoGradoAprobado { get; set; } = null!;

    public string? EstaRepitiendoGrado { get; set; } = null!;

    [JsonIgnore]
    public virtual ICollection<Matricula> Matriculas { get; set; } = new List<Matricula>();
    [JsonIgnore]
    public virtual ICollection<Tutores> Tutores { get; set; } = new List<Tutores>();
}
