using Microsoft.AspNetCore.Mvc;
using Entities;
using Persistencia.Interface;

namespace Persistencia.controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventoController : ControllerBase
    {
        private readonly IEventoRepository _eventoRepository;

        public EventoController(IEventoRepository eventoRepository)
        {
            _eventoRepository = eventoRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllEventos()
        {
            var eventos = await _eventoRepository.GetAllEventosAsync();
            return Ok(eventos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetEventoById(int id)
        {
            var evento = await _eventoRepository.GetEventoByIdAsync(id);
            if (evento == null)
                return NotFound();
            return Ok(evento);
        }

        [HttpPost]
        public async Task<IActionResult> CreateEvento(Evento evento)
        {
            await _eventoRepository.CreateEventoAsync(evento);
            return CreatedAtAction(nameof(GetEventoById), new { id = evento.EventoId }, evento);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEvento(int id, Evento evento)
        {
            if (id != evento.EventoId)
                return BadRequest();

            var updated = await _eventoRepository.UpdateEventoAsync(evento);
            if (!updated)
                return NotFound();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEvento(int id)
        {
            var deleted = await _eventoRepository.DeleteEventoAsync(id);
            if (!deleted)
                return NotFound();

            return NoContent();
        }
    }
}
