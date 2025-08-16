using GestionAcademica.DataAccess;
using GestionAcademica.Domain;
using GestionAcademica.DTOs;
using GestionAcademica.Services;
using Microsoft.AspNetCore.Mvc;

namespace GestionAcademica.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EspecialidadController : ControllerBase
    {
        private readonly EspecialidadService _especialidadService = new EspecialidadService();

        [HttpGet("{id}")]
        public ActionResult<EspecialidadDto> Get(int id)
        {
            var especialidad = _especialidadService.Get(id);
            if (especialidad == null)
                return NotFound();

            var dto = new EspecialidadDto
            {
                ID = especialidad.ID,
                Descripcion = especialidad.Descripcion
            };
            return Ok(dto);
        }

        [HttpGet]
        public ActionResult<IEnumerable<EspecialidadDto>> GetAll()
        {
            var especialidades = _especialidadService.GetAll();
            var dtos = especialidades.Select(e => new EspecialidadDto
            {
                ID = e.ID,
                Descripcion = e.Descripcion
            });
            return Ok(dtos);
        }

        [HttpPost]
        public ActionResult<EspecialidadDto> Add(EspecialidadDto dto)
        {
            try
            {
                var especialidad = new Especialidad(dto.ID, dto.Descripcion);
                especialidad.State = States.New;
                _especialidadService.Save(especialidad);

                dto.ID = especialidad.ID;
                return CreatedAtAction(nameof(Get), new { id = dto.ID }, dto);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }

        [HttpPut]
        public IActionResult Update(EspecialidadDto dto)
        {
            try
            {
                var especialidad = new Especialidad(dto.ID, dto.Descripcion);
                especialidad.State = States.Modified;
                var updated = _especialidadService.Save(especialidad);
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
            var especialidadToDelete = EspecialidadInMemory.Especialidades.Find(x => x.ID == id);
            especialidadToDelete.State = States.Deleted;
            var deleted = _especialidadService.Save(especialidadToDelete);
            if (!deleted)
                return NotFound();
            return NoContent();
        }
    }
}

