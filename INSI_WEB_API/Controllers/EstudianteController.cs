﻿using INSI_WEB_API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace INSI_WEB_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstudianteController : ControllerBase
    {


        public readonly BdInsiContext _dbcontext;

        public EstudianteController(BdInsiContext _context)
        {
            _dbcontext = _context;
        }


        [HttpGet]
        [Route("Lista")]

        public IActionResult Lista()
        {
            List<Estudiante> lista = new List<Estudiante>();

            try
            {
                lista = _dbcontext.Estudiantes.ToList();

                return StatusCode(StatusCodes.Status200OK, new { mensaje = "Lista de estudiantes", response = lista });

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status200OK, new { mensaje = ex.Message, response = lista });
            }

        }

        [HttpGet]
        [Route("Obtener/{idEstudiante:int}")]
        public IActionResult Obtener(int idEstudiante)
        {
            try
            {
                Estudiante oEstudiante = _dbcontext.Estudiantes.Find(idEstudiante);

                if (oEstudiante == null)
                {
                    return BadRequest("Estudiante no encontrado");
                }

                return StatusCode(StatusCodes.Status200OK, new { mensaje = "Estudiante encontrado", response = oEstudiante });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { mensaje = ex.Message });
            }
        }

        [HttpPost]
        [Route("Guardar")]

        public IActionResult Guardar([FromBody] Estudiante objeto)
        {
            try
            {
                _dbcontext.Estudiantes.Add(objeto);
                _dbcontext.SaveChanges();

                return StatusCode(StatusCodes.Status200OK, new { mensaje = "Estudiante Guardado Correctamente" });

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status200OK, new { mensaje = "❌ Los datos no son válidos ¡Por favor revise que los datos sean correctos!" });
            }
        }



        
        [HttpPut]
        [Route("Editar")]
        public IActionResult Editar([FromBody] Estudiante objeto2)
        {

            Estudiante oEstudiante = _dbcontext.Estudiantes.Find(objeto2.IdEstudiante);

            if (oEstudiante == null)
            {
                return BadRequest("Estudiante no encontrado");
            }
            try
            {
                oEstudiante.IdEstudiante = objeto2.IdEstudiante is null ? oEstudiante.IdEstudiante : objeto2.IdEstudiante;
                oEstudiante.IdTutor = objeto2.IdTutor is null ? oEstudiante.IdTutor : objeto2.IdTutor;
                oEstudiante.Nombre = objeto2.Nombre is null ? oEstudiante.Nombre : objeto2.Nombre;
                oEstudiante.Apellido = objeto2.Apellido is null ? oEstudiante.Apellido : objeto2.Apellido;
                oEstudiante.FechaNacimiento = objeto2.FechaNacimiento is null ? oEstudiante.FechaNacimiento : objeto2.FechaNacimiento;
                oEstudiante.LugarNacimiento = objeto2.LugarNacimiento is null ? oEstudiante.LugarNacimiento : objeto2.LugarNacimiento;
                oEstudiante.ZonaRecidencial = objeto2.ZonaRecidencial is null ? oEstudiante.ZonaRecidencial : objeto2.ZonaRecidencial;
                oEstudiante.PartidaNacimiento = objeto2.PartidaNacimiento is null ? oEstudiante.PartidaNacimiento : objeto2.PartidaNacimiento;
                oEstudiante.Edad = objeto2.Edad is null ? oEstudiante.Edad : objeto2.Edad;
                oEstudiante.Genero = objeto2.Genero is null ? oEstudiante.Genero : objeto2.Genero;
                oEstudiante.Direccion = objeto2.Direccion is null ? oEstudiante.Direccion : objeto2.Direccion;
                oEstudiante.Telefono = objeto2.Telefono is null ? oEstudiante.Telefono : objeto2.Telefono;
                oEstudiante.UltimoGradoAprobado = objeto2.UltimoGradoAprobado is null ? oEstudiante.UltimoGradoAprobado : objeto2.UltimoGradoAprobado;
                oEstudiante.EstaRepitiendoGrado = objeto2.EstaRepitiendoGrado is null ? oEstudiante.EstaRepitiendoGrado : objeto2.EstaRepitiendoGrado;

                _dbcontext.Estudiantes.Update(oEstudiante);
                _dbcontext.SaveChanges();

                return StatusCode(StatusCodes.Status200OK, new { mensaje = "Datos de Estudiante editados correctamente" });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { mensaje = "❌ Los datos no son válidos ¡Por favor revise que los datos sean correctos!" });
            }

        }


        [HttpDelete]
        [Route("Eliminar/{idEstudiante:int}")]
        public IActionResult Eliminar(int idEstudiante)
        {
            Estudiante oEstudiante = _dbcontext.Estudiantes.Find(idEstudiante);
            if (oEstudiante == null)
            {
                return BadRequest("Estudiante no encontrado");
            }

            try
            {
                _dbcontext.Estudiantes.Remove(oEstudiante);
                _dbcontext.SaveChanges();

                return StatusCode(StatusCodes.Status200OK, new { mensaje = "Estudiante eliminado correctamente" });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status200OK, new { mensaje = ex.Message });
            }
        }


    }
}
