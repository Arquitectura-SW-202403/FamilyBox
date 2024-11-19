using Microsoft.AspNetCore.Mvc;
using Entities;
using Serivicios.Services;

namespace Serivicios.Controller
{


    [ApiController]
    [Route("api/[controller]")]
    public class PagoController : ControllerBase
    {
        private readonly PagoService _PagoService;

        public PagoController(PagoService PagoService)
        {
            _PagoService = PagoService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var Pagos = await _PagoService.GetAllPagosAsync();
            return Ok(Pagos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var Pago = await _PagoService.GetPagoByIdAsync(id);
            if (Pago == null)
                return NotFound();
            return Ok(Pago);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Pago Pago)
        {
            await _PagoService.CreatePagoAsync(Pago);
            return CreatedAtAction(nameof(GetById), new { id = Pago.PagoId }, Pago);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Pago Pago)
        {
            if (id != Pago.PagoId)
                return BadRequest();

            var updated = await _PagoService.UpdatePagoAsync(Pago);
            if (!updated)
                return NotFound();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _PagoService.DeletePagoAsync(id);
            if (!deleted)
                return NotFound();

            return NoContent();
        }
    }

}