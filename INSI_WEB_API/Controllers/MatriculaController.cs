using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using INSI_WEB_API.Models;
using AutoMapper;

namespace INSI_WEB_API.Controllers
    
{

    [Route("api/[controller]")]
    [ApiController]
    public class MatriculaController : ControllerBase
    {
        public readonly BdInsiContext _dbcontext;

        public MatriculaController(BdInsiContext _context)
        {
            _dbcontext = _context;
        }

        [HttpGet]
        [Route("Lista")]

        public IActionResult Lista()
        {
            List<Matricula> lista = new List<Matricula>();

            try
            {
                lista = _dbcontext.Matriculas.Include(e => e.oEstudiante).ToList();
                lista = _dbcontext.Matriculas.Include(t => t.oTutores).ToList();

                return StatusCode(StatusCodes.Status200OK, new { mensaje = "Lista de Matricula de estudiantes", response = lista });

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status200OK, new { mensaje = ex.Message, response = lista });
            }

        }
        [HttpGet]
        [Route("Obtener/{idMatricula:int}")]
        public IActionResult Obtener(int idMatricula)
        {
            Matricula oMatricula = _dbcontext.Matriculas.Find(idMatricula);

            if (oMatricula == null)
            {
                return BadRequest(" Matricula de Estudiante no encontrada");
            }

            try
            {
              oMatricula=_dbcontext.Matriculas.Include(e => e.oEstudiante).Where(m => m.IdMatricula == idMatricula).FirstOrDefault();
              oMatricula=_dbcontext.Matriculas.Include(t => t.oTutores).Where(m => m.IdMatricula == idMatricula).FirstOrDefault();




                return StatusCode(StatusCodes.Status200OK, new { mensaje = " Matricula de Estudiante encontrada", response = oMatricula });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { mensaje = ex.Message });
            }
        }


        [HttpPost]
        [Route("Guardar")]

        public IActionResult Guardar([FromBody] Matricula objeto)
        {
            try
            {
                _dbcontext.Matriculas.Add(objeto);
                _dbcontext.SaveChanges();

                return StatusCode(StatusCodes.Status200OK, new { mensaje = " Matricula del Estudiante Guardada Correctamente" });

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status200OK, new { mensaje = ex.Message });
            }
        }

        [HttpPut]
        [Route("Editar")]
        public IActionResult Editar([FromBody] Matricula objeto)
        {
            Matricula oMatricula = _dbcontext.Matriculas.Find(objeto.IdMatricula);

            if (oMatricula == null)
            {
                return BadRequest("Matricula de Estudiante no encontrada");
            }
            try
            {

                oMatricula.IdMatricula = objeto.IdMatricula is null ? oMatricula.IdMatricula : objeto.IdMatricula;
                oMatricula.IdEstudiante = objeto.IdEstudiante is null ? oMatricula.IdEstudiante : objeto.IdEstudiante;
                oMatricula.IdTutor = objeto.IdTutor is null ? oMatricula.IdTutor : objeto.IdTutor;
                oMatricula.FechaMatricula = objeto.FechaMatricula is null ? oMatricula.FechaMatricula : objeto.FechaMatricula;
                oMatricula.FechaMatricula = objeto.FechaMatricula is null ? oMatricula.FechaMatricula : objeto.FechaMatricula;
                oMatricula.FechaMatricula = objeto.FechaMatricula is null ? oMatricula.FechaMatricula : objeto.FechaMatricula;
                oMatricula.EstadoMatricula = objeto.EstadoMatricula is null ? oMatricula.EstadoMatricula : objeto.EstadoMatricula;
                oMatricula.GradoSolicitado = objeto.GradoSolicitado is null ? oMatricula.GradoSolicitado : objeto.GradoSolicitado;
               
                _dbcontext.Matriculas.Update(oMatricula);              
                _dbcontext.SaveChanges();

                return StatusCode(StatusCodes.Status200OK, new { mensaje = "Matricula de Estudiante editada correctamente" });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { mensaje = ex.Message });
            }
        }

        [HttpDelete]
        [Route("Eliminar/{idMatricula:int}")]
        public IActionResult Eliminar(int idMatricula)
        {
            Matricula oMatricula = _dbcontext.Matriculas.Find(idMatricula);
            if (oMatricula == null)
            {
                return BadRequest("Estudiante no encontrado");
            }

            try
            {
                oMatricula = _dbcontext.Matriculas
                    .Include(e => e.oEstudiante)
                    .Include(t => t.oTutores)
                    .SingleOrDefault(m => m.IdMatricula == idMatricula);

                _dbcontext.RemoveRange(oMatricula.oTutores);
                _dbcontext.Remove(oMatricula.oEstudiante);
                _dbcontext.Remove(oMatricula);
                _dbcontext.SaveChanges();

                return StatusCode(StatusCodes.Status200OK, new { mensaje = "Matricula del Estudiante eliminada correctamente" });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status200OK, new { mensaje = ex.Message });
            }
        }




    }
}
