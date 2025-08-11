using Microsoft.AspNetCore.Mvc;
using GestionAcademica.Services;
using GestionAcademica.DTOs;
using GestionAcademica.Domain;
using GestionAcademica.DataAccess;

namespace GestionAcademica.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly UsuarioService _usuarioService = new UsuarioService();

        [HttpGet("{id}")]
        public ActionResult<UsuarioDto> Get(int id)
        {
            var usuario = _usuarioService.Get(id);
            if (usuario == null)
                return NotFound();

            var dto = new UsuarioDto
            {
                ID = usuario.ID,
                Clave = usuario.Clave,
                Email = usuario.Email,
                Nombre = usuario.Nombre,
                Apellido = usuario.Apellido,
                NombreUsuario = usuario.NombreUsuario,
                Habilitado = usuario.Habilitado
            };
            return Ok(dto);
        }

        [HttpGet]
        public ActionResult<IEnumerable<UsuarioDto>> GetAll()
        {
            var usuarios = _usuarioService.GetAll();
            var dtos = usuarios.Select(u => new UsuarioDto
            {
                ID = u.ID,
                Clave = u.Clave,
                Email = u.Email,
                Nombre = u.Nombre,
                Apellido = u.Apellido,
                NombreUsuario = u.NombreUsuario,
                Habilitado = u.Habilitado
            });
            return Ok(dtos);
        }

        [HttpPost]
        public ActionResult<UsuarioDto> Add(UsuarioDto dto)
        {
            try
            {
                var usuario = new Usuario(dto.ID, dto.Clave, dto.Email, dto.Nombre, dto.Apellido, dto.NombreUsuario, dto.Habilitado);
                usuario.State = States.New;
                _usuarioService.Save(usuario);

                dto.ID = usuario.ID;
                return CreatedAtAction(nameof(Get), new { id = dto.ID }, dto);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }

        [HttpPut]
        public IActionResult Update(UsuarioDto dto)
        {
            try
            {
                var usuario = new Usuario(dto.ID, dto.Clave, dto.Email, dto.Nombre, dto.Apellido, dto.NombreUsuario, dto.Habilitado);
                
                usuario.State = States.Modified;
                var updated = _usuarioService.Save(usuario);
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
            var usuarioToDelete = UsuarioInMemory.Usuarios.Find(x => x.ID == id);
            usuarioToDelete.State = States.Deleted;
            var deleted = _usuarioService.Save(usuarioToDelete);
            if (!deleted)
                return NotFound();
            return NoContent();
        }
    }
}
