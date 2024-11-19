using Microsoft.AspNetCore.Mvc;
using Entities;
using Persistencia.Interface;

namespace Persistencia.controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class PagoController : ControllerBase
    {
        private readonly IPagoRepository _PagoRepository;

        public PagoController(IPagoRepository PagoRepository)
        {
            _PagoRepository = PagoRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllPagos()
        {
            var Pagos = await _PagoRepository.GetAllPagosAsync();
            return Ok(Pagos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPagoById(int id)
        {
            var Pago = await _PagoRepository.GetPagoByIdAsync(id);
            if (Pago == null)
                return NotFound();
            return Ok(Pago);
        }

        [HttpPost]
        public async Task<IActionResult> CreatePago(Pago Pago)
        {
            await _PagoRepository.CreatePagoAsync(Pago);
            return CreatedAtAction(nameof(GetPagoById), new { id = Pago.PagoId }, Pago);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePago(int id, Pago Pago)
        {
            if (id != Pago.PagoId)
                return BadRequest();

            var updated = await _PagoRepository.UpdatePagoAsync(Pago);
            if (!updated)
                return NotFound();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePago(int id)
        {
            var deleted = await _PagoRepository.DeletePagoAsync(id);
            if (!deleted)
                return NotFound();

            return NoContent();
        }
    }
}
