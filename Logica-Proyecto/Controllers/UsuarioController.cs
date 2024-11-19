using Microsoft.AspNetCore.Mvc;
using Entities;
using Serivicios.Services;

namespace Serivicios.Controller
{


    [ApiController]
    [Route("api/[controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly UsuarioService _UsuarioService;

        public UsuarioController(UsuarioService UsuarioService)
        {
            _UsuarioService = UsuarioService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var Usuarios = await _UsuarioService.GetAllUsuariosAsync();
            return Ok(Usuarios);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            var Usuario = await _UsuarioService.GetUsuarioByIdAsync(id);
            if (Usuario == null)
                return NotFound();
            return Ok(Usuario);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Usuario Usuario)
        {
            await _UsuarioService.CreateUsuarioAsync(Usuario);
            return CreatedAtAction(nameof(GetById), new { id = Usuario.UsuarioId }, Usuario);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(string id, Usuario Usuario)
        {
            if (id != Usuario.UsuarioId)
                return BadRequest();

            var updated = await _UsuarioService.UpdateUsuarioAsync(Usuario);
            if (!updated)
                return NotFound();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var deleted = await _UsuarioService.DeleteUsuarioAsync(id);
            if (!deleted)
                return NotFound();

            return NoContent();
        }
    }

}