using Microsoft.AspNetCore.Mvc;
using Entities;
using Serivicios.Services;

namespace Serivicios.Controller
{


    [ApiController]
    [Route("api/[controller]")]
    public class EventoController : ControllerBase
    {
        private readonly EventoService _EventoService;

        public EventoController(EventoService EventoService)
        {
            _EventoService = EventoService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var Eventos = await _EventoService.GetAllEventosAsync();
            return Ok(Eventos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var Evento = await _EventoService.GetEventoByIdAsync(id);
            if (Evento == null)
                return NotFound();
            return Ok(Evento);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Evento Evento)
        {
            await _EventoService.CreateEventoAsync(Evento);
            return CreatedAtAction(nameof(GetById), new { id = Evento.EventoId }, Evento);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Evento Evento)
        {
            if (id != Evento.EventoId)
                return BadRequest();

            var updated = await _EventoService.UpdateEventoAsync(Evento);
            if (!updated)
                return NotFound();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _EventoService.DeleteEventoAsync(id);
            if (!deleted)
                return NotFound();

            return NoContent();
        }
    }

}