﻿using System;
using System.Collections.Generic;

namespace INSI_WEB_API.Models;

public partial class HistorialEstudiante
{
    public DateTime? Fecha { get; set; }

    public string? Descripcion { get; set; }

    public string? Usuario { get; set; }

    public int? IdEstudiante { get; set; }
}
