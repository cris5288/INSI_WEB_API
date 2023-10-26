﻿using INSI_WEB_API.Models;
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


        [HttpGet]
        [Route("Lista")]

        public IActionResult Lista()
        {
            List<Tutores> lista = new List<Tutores>();

            try
            {
                lista = _dbcontext.Tutores.ToList();

                return StatusCode(StatusCodes.Status200OK, new { mensaje = "Lista de Tutores", response = lista });

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status200OK, new { mensaje = ex.Message, response = lista });
            }

        }

        [HttpGet]
        [Route("Obtener/{idTutores:int}")]
        public IActionResult Obtener(int idTutores)
        {
            try
            {
                Tutores oTutores = _dbcontext.Tutores.Find(idTutores);

                if (oTutores == null)
                {
                    return BadRequest("Tutor no encontrado");
                }

                return StatusCode(StatusCodes.Status200OK, new { mensaje = "Tutor encontrado", response = oTutores });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { mensaje = ex.Message });
            }
        }

        [HttpPost]
        [Route("Guardar")]

        public IActionResult Guardar([FromBody] Tutores objeto)
        {
            try
            {
                _dbcontext.Tutores.Add(objeto);
                _dbcontext.SaveChanges();

                return StatusCode(StatusCodes.Status200OK, new { mensaje = "Tutor Guardado Correctamente" });

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status200OK, new { mensaje = "❌ Los datos no son válidos ¡Por favor revise que los datos sean correctos!" });
            }
        }

        [HttpPut]
        [Route("Editar")]
        public IActionResult Editar([FromBody] Tutores objeto3)
        {

            Tutores oTutores = _dbcontext.Tutores.Find(objeto3.IdTutor);

            if (oTutores == null)
            {
                return BadRequest("Tutor no encontrado");
            }
            try
            {  
                oTutores.IdTutor = objeto3.IdTutor is null ? oTutores.IdTutor : objeto3.IdTutor;
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
                return StatusCode(StatusCodes.Status500InternalServerError, new { mensaje = "❌ Los datos no son válidos ¡Por favor revise que los datos sean correctos!" });
            }

        }

        [HttpDelete]
        [Route("Eliminar/{idTutores:int}")]
        public IActionResult Eliminar(int idTutores)
        {
            Tutores oTutores = _dbcontext.Tutores.Find(idTutores);
            if (oTutores == null)
            {
                return BadRequest("Tutor no encontrado");
            }

            try
            {
                _dbcontext.Tutores.Remove(oTutores);
                _dbcontext.SaveChanges();

                return StatusCode(StatusCodes.Status200OK, new { mensaje = "Tutor eliminado correctamente" });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status200OK, new { mensaje = ex.Message });
            }
        }
    }
}
