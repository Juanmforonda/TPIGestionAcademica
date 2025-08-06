using Microsoft.AspNetCore.Mvc;
using GestionAcademica.Services;
using GestionAcademica.DTOs;
using GestionAcademica.Domain;

namespace GestionAcademica.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AlumnoController : ControllerBase
    {
        private readonly AlumnoService _alumnoService = new AlumnoService();

        [HttpGet("{id}")]
        public ActionResult<AlumnoDto> Get(int id)
        {
            var alumno = _alumnoService.Get(id);
            if (alumno == null)
                return NotFound();

            var dto = new AlumnoDto
            {
                Id = alumno.Id,
                Nombre = alumno.Nombre,
                Apellido = alumno.Apellido,
                Legajo = alumno.Legajo,
                Email = alumno.Email,
                FechaNacimiento = alumno.FechaNacimiento
            };
            return Ok(dto);
        }

        [HttpGet]
        public ActionResult<IEnumerable<AlumnoDto>> GetAll()
        {
            var alumnos = _alumnoService.GetAll();
            var dtos = alumnos.Select(a => new AlumnoDto
            {
                Id = a.Id,
                Nombre = a.Nombre,
                Apellido = a.Apellido,
                Legajo = a.Legajo,
                Email = a.Email,
                FechaNacimiento = a.FechaNacimiento
            });
            return Ok(dtos);
        }

        [HttpPost]
        public ActionResult<AlumnoDto> Add(AlumnoDto dto)
        {
            try
            {
                var alumno = new Alumno(dto.Id, dto.Nombre, dto.Apellido, dto.Legajo, dto.Email, dto.FechaNacimiento);
                _alumnoService.Add(alumno);

                dto.Id = alumno.Id;
                return CreatedAtAction(nameof(Get), new { id = dto.Id }, dto);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }

        [HttpPut]
        public IActionResult Update(AlumnoDto dto)
        {
            try
            {
                var alumno = new Alumno(dto.Id, dto.Nombre, dto.Apellido, dto.Legajo, dto.Email, dto.FechaNacimiento);
                var updated = _alumnoService.Update(alumno);
                if (!updated)
                    return NotFound();
                return NoContent();
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var deleted = _alumnoService.Delete(id);
            if (!deleted)
                return NotFound();
            return NoContent();
        }
    }
}

