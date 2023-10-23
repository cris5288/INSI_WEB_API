using INSI_WEB_API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text;
using System.Security.Cryptography;




namespace INSI_WEB_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly BdInsiContext _dbContext;

        public LoginController(BdInsiContext dbContext)
        {
            _dbContext = dbContext;
        }


        //[HttpPost]
        //[Route("Registrarse")]
        //public IActionResult Registrar([FromBody] Usuario nuevoUsuario)
        //{
        //    // Verificar si el email ya está registrado
        //    var usuarioExistente = _dbContext.Usuarios.FirstOrDefault(u => u.Email == nuevoUsuario.Email);
        //    if (usuarioExistente != null)
        //    {
        //        return BadRequest(new { mensaje = "El email ya está registrado" });
        //    }

        //    // Encriptar la contraseña antes de guardarla
        //    nuevoUsuario.ContraseñaEncriptada = EncryptPassword(nuevoUsuario.Contraseña);

        //    // Guardar el nuevo usuario en la base de datos
        //    _dbContext.Usuarios.Add(nuevoUsuario);
        //    _dbContext.SaveChanges();

        //    return Ok(new { mensaje = "Usuario creado exitosamente" });
        //}

        //private byte[] EncryptPassword(string password)
        //{
        //    // Aquí debes implementar la lógica para encriptar la contraseña antes de guardarla en la base de datos
        //    // Utiliza técnicas adecuadas de encriptación, como hashing con sal

        //    // Ejemplo de implementación básica utilizando hashing con SHA-256
        //    using (var sha256 = SHA256.Create())
        //    {
        //        var hashBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
        //        return hashBytes;
        //    }
        //}


        [HttpPost]
        [Route("login")]
        public IActionResult Login([FromBody] Usuario login)
        {
            var usuario = _dbContext.Usuarios.FirstOrDefault(u => u.Email == login.Email);

            if (usuario == null)
            {
                return Unauthorized(new { mensaje = "Credenciales incorrectas" });
            }

            if (!VerifyPassword(login.Contraseña, usuario.ContraseñaEncriptada))
            {
                return Unauthorized(new { mensaje = "Credenciales incorrectas" });
            }

            // Autenticación exitosa, puedes generar un token de autenticación si es necesario

            // Por ejemplo, aquí retornamos un objeto JSON con un mensaje de éxito
            return Ok(new { mensaje = "Inicio de sesión exitoso" });
        }

        private bool VerifyPassword(string password, byte[]? encryptedPassword)
        {
            // Aquí debes implementar la lógica para verificar si la contraseña coincide con la contraseña encriptada
            // Utiliza técnicas adecuadas de encriptación, como hashing con sal, en lugar de comparar en texto plano

            // Ejemplo de implementación básica utilizando hashing
            using (var sha256 = SHA256.Create())
            {
                var hashBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));

                // Convertir los bytes en una cadena hexadecimal
                var hashedPassword = BitConverter.ToString(hashBytes).Replace("-", "").ToLower();

                // Verificar si el hash coincide con la contraseña encriptada
                return hashedPassword.Equals(BitConverter.ToString(encryptedPassword).Replace("-", "").ToLower());
            }
        }



    }

}





