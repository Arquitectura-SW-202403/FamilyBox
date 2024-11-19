using Microsoft.AspNetCore.Mvc;
using Entities;
using Persistencia.Interface;

namespace Persistencia.controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class SedeController : ControllerBase
    {
        private readonly ISedeRepository _SedeRepository;

        public SedeController(ISedeRepository SedeRepository)
        {
            _SedeRepository = SedeRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllSedes()
        {
            var Sedes = await _SedeRepository.GetAllSedesAsync();
            return Ok(Sedes);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSedeById(int id)
        {
            var Sede = await _SedeRepository.GetSedeByIdAsync(id);
            if (Sede == null)
                return NotFound();
            return Ok(Sede);
        }

        [HttpPost]
        public async Task<IActionResult> CreateSede(Sede Sede)
        {
            await _SedeRepository.CreateSedeAsync(Sede);
            return CreatedAtAction(nameof(GetSedeById), new { id = Sede.SedeId }, Sede);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateSede(int id, Sede Sede)
        {
            if (id != Sede.SedeId)
                return BadRequest();

            var updated = await _SedeRepository.UpdateSedeAsync(Sede);
            if (!updated)
                return NotFound();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSede(int id)
        {
            var deleted = await _SedeRepository.DeleteSedeAsync(id);
            if (!deleted)
                return NotFound();

            return NoContent();
        }
    }
}
