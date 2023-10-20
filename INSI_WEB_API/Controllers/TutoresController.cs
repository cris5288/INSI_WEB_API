using INSI_WEB_API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace INSI_WEB_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TutoresController : ControllerBase
    {
        public readonly BdInsiContext _dbcontext;

        public TutoresController(BdInsiContext _context)
        {
            _dbcontext = _context;
        }
        [HttpPut]
        [Route("Editar")]
        public IActionResult Editar([FromBody] Tutores objeto3)
        {

            Tutores oTutores = _dbcontext.Tutores.Find(objeto3.IdTutor);

            if (oTutores == null)
            {
                return BadRequest("Tutor  no encontrado");
            }
            try
            {  
                oTutores.IdTutor = objeto3.IdTutor is null ? oTutores.IdTutor : objeto3.IdTutor;
                oTutores.IdEstudiante = objeto3.IdEstudiante is null ? oTutores.IdEstudiante : objeto3.IdEstudiante;
                oTutores.Nombre = objeto3.Nombre is null ? oTutores.Nombre : objeto3.Nombre;
                oTutores.Apellido = objeto3.Apellido is null ? oTutores.Apellido : objeto3.Apellido;
                oTutores.Direccion = objeto3.Direccion is null ? oTutores.Direccion : objeto3.Direccion;
                oTutores.Telefono = objeto3.Telefono is null ? oTutores.Telefono : objeto3.Telefono;
                oTutores.RelacionConEstudiante = objeto3.RelacionConEstudiante is null ? oTutores.RelacionConEstudiante : objeto3.RelacionConEstudiante;

                _dbcontext.Tutores.Update(oTutores);
                _dbcontext.SaveChanges();

                return StatusCode(StatusCodes.Status200OK, new { mensaje = "Datos de Tutor editados correctamente" });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { mensaje = ex.Message });
            }

        }
    }
}
