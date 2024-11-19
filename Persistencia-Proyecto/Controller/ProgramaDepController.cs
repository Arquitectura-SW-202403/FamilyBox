using Microsoft.AspNetCore.Mvc;
using Entities;
using Persistencia.Interface;

namespace Persistencia.controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProgramaDepController : ControllerBase
    {
        private readonly IProgramaDepRepository _ProgramaDepRepository;

        public ProgramaDepController(IProgramaDepRepository ProgramaDepRepository)
        {
            _ProgramaDepRepository = ProgramaDepRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProgramaDeps()
        {
            var ProgramaDeps = await _ProgramaDepRepository.GetAllProgramaDepsAsync();
            return Ok(ProgramaDeps);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProgramaDepById(int id)
        {
            var ProgramaDep = await _ProgramaDepRepository.GetProgramaDepByIdAsync(id);
            if (ProgramaDep == null)
                return NotFound();
            return Ok(ProgramaDep);
        }

        [HttpPost]
        public async Task<IActionResult> CreateProgramaDep(ProgramaDep ProgramaDep)
        {
            await _ProgramaDepRepository.CreateProgramaDepAsync(ProgramaDep);
            return CreatedAtAction(nameof(GetProgramaDepById), new { id = ProgramaDep.ProgramaId }, ProgramaDep);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProgramaDep(int id, ProgramaDep ProgramaDep)
        {
            if (id != ProgramaDep.ProgramaId)
                return BadRequest();

            var updated = await _ProgramaDepRepository.UpdateProgramaDepAsync(ProgramaDep);
            if (!updated)
                return NotFound();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProgramaDep(int id)
        {
            var deleted = await _ProgramaDepRepository.DeleteProgramaDepAsync(id);
            if (!deleted)
                return NotFound();

            return NoContent();
        }
    }
}
