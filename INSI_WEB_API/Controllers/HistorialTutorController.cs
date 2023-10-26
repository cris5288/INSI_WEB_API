using INSI_WEB_API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace INSI_WEB_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HistorialTutorController : ControllerBase
    {

        public readonly BdInsiContext _dbcontext;

        public HistorialTutorController(BdInsiContext _context)
        {
            _dbcontext = _context;
        }

        [HttpGet]
        [Route("Lista")]

        public IActionResult Lista()
        {
            List<HistorialTutor> lista = new List<HistorialTutor>();

            try
            {

                lista = _dbcontext.HistorialTutors.ToList();

                return StatusCode(StatusCodes.Status200OK, new { mensaje = "Lista de Historial de Tutores", response = lista });

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status200OK, new { mensaje = ex.Message, response = lista });
            }

        }
    }
}
