using Microsoft.AspNetCore.Mvc;
using Entities;
using Serivicios.Services;

namespace Serivicios.Controller
{


    [ApiController]
    [Route("api/[controller]")]
    public class ProgramaDepController : ControllerBase
    {
        private readonly ProgramaDepService _ProgramaDepService;

        public ProgramaDepController(ProgramaDepService ProgramaDepService)
        {
            _ProgramaDepService = ProgramaDepService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var ProgramaDeps = await _ProgramaDepService.GetAllProgramaDepsAsync();
            return Ok(ProgramaDeps);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var ProgramaDep = await _ProgramaDepService.GetProgramaDepByIdAsync(id);
            if (ProgramaDep == null)
                return NotFound();
            return Ok(ProgramaDep);
        }

        [HttpPost]
        public async Task<IActionResult> Create(ProgramaDep ProgramaDep)
        {
            await _ProgramaDepService.CreateProgramaDepAsync(ProgramaDep);
            return CreatedAtAction(nameof(GetById), new { id = ProgramaDep.ProgramaId }, ProgramaDep);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, ProgramaDep ProgramaDep)
        {
            if (id != ProgramaDep.ProgramaId)
                return BadRequest();

            var updated = await _ProgramaDepService.UpdateProgramaDepAsync(ProgramaDep);
            if (!updated)
                return NotFound();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _ProgramaDepService.DeleteProgramaDepAsync(id);
            if (!deleted)
                return NotFound();

            return NoContent();
        }
    }

}