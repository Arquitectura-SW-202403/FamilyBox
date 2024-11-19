using Microsoft.AspNetCore.Mvc;
using Entities;
using Serivicios.Services;

namespace Serivicios.Controller
{


    [ApiController]
    [Route("api/[controller]")]
    public class InstalacionController : ControllerBase
    {
        private readonly InstalacionService _InstalacionService;

        public InstalacionController(InstalacionService InstalacionService)
        {
            _InstalacionService = InstalacionService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var Instalacions = await _InstalacionService.GetAllInstalacionsAsync();
            return Ok(Instalacions);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var Instalacion = await _InstalacionService.GetInstalacionByIdAsync(id);
            if (Instalacion == null)
                return NotFound();
            return Ok(Instalacion);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Instalacion Instalacion)
        {
            await _InstalacionService.CreateInstalacionAsync(Instalacion);
            return CreatedAtAction(nameof(GetById), new { id = Instalacion.InstalacionId }, Instalacion);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Instalacion Instalacion)
        {
            if (id != Instalacion.InstalacionId)
                return BadRequest();

            var updated = await _InstalacionService.UpdateInstalacionAsync(Instalacion);
            if (!updated)
                return NotFound();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _InstalacionService.DeleteInstalacionAsync(id);
            if (!deleted)
                return NotFound();

            return NoContent();
        }
    }

}