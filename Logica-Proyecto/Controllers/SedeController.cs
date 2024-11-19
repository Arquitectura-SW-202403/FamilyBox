using Microsoft.AspNetCore.Mvc;
using Entities;
using Serivicios.Services;

namespace Serivicios.Controller
{


    [ApiController]
    [Route("api/[controller]")]
    public class SedeController : ControllerBase
    {
        private readonly SedeService _sedeService;

        public SedeController(SedeService sedeService)
        {
            _sedeService = sedeService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var sedes = await _sedeService.GetAllSedesAsync();
            return Ok(sedes);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var sede = await _sedeService.GetSedeByIdAsync(id);
            if (sede == null)
                return NotFound();
            return Ok(sede);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Sede sede)
        {
            await _sedeService.CreateSedeAsync(sede);
            return CreatedAtAction(nameof(GetById), new { id = sede.SedeId }, sede);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Sede sede)
        {
            if (id != sede.SedeId)
                return BadRequest();

            var updated = await _sedeService.UpdateSedeAsync(sede);
            if (!updated)
                return NotFound();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _sedeService.DeleteSedeAsync(id);
            if (!deleted)
                return NotFound();

            return NoContent();
        }
    }

}