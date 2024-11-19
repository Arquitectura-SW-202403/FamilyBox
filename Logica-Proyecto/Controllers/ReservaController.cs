using Microsoft.AspNetCore.Mvc;
using Entities;
using Serivicios.Services;

namespace Serivicios.Controller
{


    [ApiController]
    [Route("api/[controller]")]
    public class ReservaController : ControllerBase
    {
        private readonly ReservaService _ReservaService;

        public ReservaController(ReservaService ReservaService)
        {
            _ReservaService = ReservaService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var Reservas = await _ReservaService.GetAllReservasAsync();
            return Ok(Reservas);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var Reserva = await _ReservaService.GetReservaByIdAsync(id);
            if (Reserva == null)
                return NotFound();
            return Ok(Reserva);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Reserva Reserva)
        {
            await _ReservaService.CreateReservaAsync(Reserva);
            return CreatedAtAction(nameof(GetById), new { id = Reserva.ReservaId }, Reserva);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Reserva Reserva)
        {
            if (id != Reserva.ReservaId)
                return BadRequest();

            var updated = await _ReservaService.UpdateReservaAsync(Reserva);
            if (!updated)
                return NotFound();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _ReservaService.DeleteReservaAsync(id);
            if (!deleted)
                return NotFound();

            return NoContent();
        }
    }

}