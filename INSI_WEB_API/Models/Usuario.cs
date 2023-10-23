using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography;

namespace INSI_WEB_API.Models;

public partial class Usuario
{
    
    public int ?UsuarioId { get; set; }

    public string? Email { get; set; }

    public string ?Contraseña { get; set; }
    public byte[] ?ContraseñaEncriptada { get; set; }

    public void EncriptarContraseña()
    {
        using (SHA256 sha256 = SHA256.Create())
        {
            byte[] contraseñaBytes = Encoding.UTF8.GetBytes(Contraseña);
            ContraseñaEncriptada = sha256.ComputeHash(contraseñaBytes);
        }
    }
}
