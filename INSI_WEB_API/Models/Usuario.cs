using System;
using System.Collections.Generic;

namespace INSI_WEB_API.Models;

public partial class Usuario
{
    public int? UsuarioId { get; set; }

    public string? Email { get; set; }

    public byte[]? ContraseñaEncriptada { get; set; }
}
