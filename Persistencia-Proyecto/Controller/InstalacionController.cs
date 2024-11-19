using Microsoft.AspNetCore.Mvc;
using Entities;
using Persistencia.Interface;

namespace Persistencia.controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class InstalacionController : ControllerBase
    {
        private readonly IInstalacionRepository _InstalacionRepository;

        public InstalacionController(IInstalacionRepository InstalacionRepository)
        {
            _InstalacionRepository = InstalacionRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllInstalacions()
        {
            var Instalacions = await _InstalacionRepository.GetAllInstalacionsAsync();
            return Ok(Instalacions);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetInstalacionById(int id)
        {
            var Instalacion = await _InstalacionRepository.GetInstalacionByIdAsync(id);
            if (Instalacion == null)
                return NotFound();
            return Ok(Instalacion);
        }

        [HttpPost]
        public async Task<IActionResult> CreateInstalacion(Instalacion Instalacion)
        {
            await _InstalacionRepository.CreateInstalacionAsync(Instalacion);
            return CreatedAtAction(nameof(GetInstalacionById), new { id = Instalacion.InstalacionId }, Instalacion);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateInstalacion(int id, Instalacion Instalacion)
        {
            if (id != Instalacion.InstalacionId)
                return BadRequest();

            var updated = await _InstalacionRepository.UpdateInstalacionAsync(Instalacion);
            if (!updated)
                return NotFound();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInstalacion(int id)
        {
            var deleted = await _InstalacionRepository.DeleteInstalacionAsync(id);
            if (!deleted)
                return NotFound();

            return NoContent();
        }
    }
}
