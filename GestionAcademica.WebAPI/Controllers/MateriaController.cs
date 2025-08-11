using GestionAcademica.DataAccess;
using GestionAcademica.Domain;
using GestionAcademica.DTOs;
using GestionAcademica.Services;
using Microsoft.AspNetCore.Mvc;

namespace GestionAcademica.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MateriaController : ControllerBase
    {
        private readonly MateriaService _materiaService = new MateriaService();

        [HttpGet("{id}")]
        public ActionResult<MateriaDto> Get(int id)
        {
            var materia = _materiaService.Get(id);
            if (materia == null)
                return NotFound();

            var dto = new MateriaDto
            {
                ID = materia.ID,
                Descripcion = materia.Descripcion,
                HSSemanales = materia.HSSemanales,
                HSTotales = materia.HSTotales,
                IDPlan = materia.IDPlan
            };
            return Ok(dto);
        }

        [HttpGet]
        public ActionResult<IEnumerable<MateriaDto>> GetAll()
        {
            var materias = _materiaService.GetAll();
            var dtos = materias.Select(m => new MateriaDto
            {
                ID = m.ID,
                Descripcion = m.Descripcion,
                HSSemanales = m.HSSemanales,
                HSTotales = m.HSTotales,
                IDPlan = m.IDPlan
            });
            return Ok(dtos);
        }

        [HttpPost]
        public ActionResult<MateriaDto> Add(MateriaDto dto)
        {
            try
            {
                var materia = new Materia(dto.ID, dto.Descripcion, dto.HSSemanales, dto.HSTotales, dto.IDPlan);
                materia.State = States.New;
                _materiaService.Save(materia);

                dto.ID = materia.ID;
                return CreatedAtAction(nameof(Get), new { id = dto.ID }, dto);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }

        [HttpPut]
        public IActionResult Update(MateriaDto dto)
        {
            try
            {
                var materia = new Materia(dto.ID, dto.Descripcion, dto.HSSemanales, dto.HSTotales, dto.IDPlan);
                materia.State = States.Modified;
                var updated = _materiaService.Save(materia);
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
            var materiaToDelete = MateriaInMemory.Materias.Find(x => x.ID == id);
            materiaToDelete.State = States.Deleted;
            var deleted = _materiaService.Save(materiaToDelete);
            if (!deleted)
                return NotFound();
            return NoContent();
        }
    }
}
