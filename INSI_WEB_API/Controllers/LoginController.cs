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

           
            return Ok(new { mensaje = "Inicio de sesión exitoso" });
        }

        private bool VerifyPassword(string password, byte[]? encryptedPassword)
        {
            
            using (var sha256 = SHA256.Create())
            {
                var hashBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));

                var hashedPassword = BitConverter.ToString(hashBytes).Replace("-", "").ToLower();

                return hashedPassword.Equals(BitConverter.ToString(encryptedPassword).Replace("-", "").ToLower());
            }
        }



    }

}





