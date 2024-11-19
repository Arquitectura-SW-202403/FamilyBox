using Microsoft.AspNetCore.Mvc;
using Entities;
using Persistencia.Interface;

namespace Persistencia.controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioRepository _UsuarioRepository;

        public UsuarioController(IUsuarioRepository UsuarioRepository)
        {
            _UsuarioRepository = UsuarioRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUsuarios()
        {
            var Usuarios = await _UsuarioRepository.GetAllUsuariosAsync();
            return Ok(Usuarios);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUsuarioById(string id)
        {
            var Usuario = await _UsuarioRepository.GetUsuarioByIdAsync(id);
            if (Usuario == null)
                return NotFound();
            return Ok(Usuario);
        }

        [HttpPost]
        public async Task<IActionResult> CreateUsuario(Usuario Usuario)
        {
            await _UsuarioRepository.CreateUsuarioAsync(Usuario);
            return CreatedAtAction(nameof(GetUsuarioById), new { id = Usuario.UsuarioId }, Usuario);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUsuario(string id, Usuario Usuario)
        {
            if (id != Usuario.UsuarioId)
                return BadRequest();

            var updated = await _UsuarioRepository.UpdateUsuarioAsync(Usuario);
            if (!updated)
                return NotFound();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUsuario(string id)
        {
            var deleted = await _UsuarioRepository.DeleteUsuarioAsync(id);
            if (!deleted)
                return NotFound();

            return NoContent();
        }
    }
}
