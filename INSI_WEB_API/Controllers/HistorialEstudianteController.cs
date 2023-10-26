using INSI_WEB_API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace INSI_WEB_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HistorialEstudianteController : ControllerBase
    {

        public readonly BdInsiContext _dbcontext;

        public HistorialEstudianteController(BdInsiContext _context)
        {
            _dbcontext = _context;
        }

        [HttpGet]
        [Route("Lista")]

        public IActionResult Lista()
        {
            List<HistorialEstudiante> lista = new List<HistorialEstudiante>();

            try
            {

                lista = _dbcontext.HistorialEstudiantes.ToList();

                return StatusCode(StatusCodes.Status200OK, new { mensaje = "Lista de Historial de Estudiantes", response = lista });

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status200OK, new { mensaje = ex.Message, response = lista });
            }

        }
    }
}
