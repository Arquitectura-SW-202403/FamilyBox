using Microsoft.AspNetCore.Mvc;
using Entities;
using Persistencia.Interface;

namespace Persistencia.controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class NotificacionController : ControllerBase
    {
        private readonly INotificacionRepository _NotificacionRepository;

        public NotificacionController(INotificacionRepository NotificacionRepository)
        {
            _NotificacionRepository = NotificacionRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllNotificacions()
        {
            var Notificacions = await _NotificacionRepository.GetAllNotificacionsAsync();
            return Ok(Notificacions);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetNotificacionById(int id)
        {
            var Notificacion = await _NotificacionRepository.GetNotificacionByIdAsync(id);
            if (Notificacion == null)
                return NotFound();
            return Ok(Notificacion);
        }

        [HttpPost]
        public async Task<IActionResult> CreateNotificacion(Notificacion Notificacion)
        {
            await _NotificacionRepository.CreateNotificacionAsync(Notificacion);
            return CreatedAtAction(nameof(GetNotificacionById), new { id = Notificacion.NotificacionId }, Notificacion);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateNotificacion(int id, Notificacion Notificacion)
        {
            if (id != Notificacion.NotificacionId)
                return BadRequest();

            var updated = await _NotificacionRepository.UpdateNotificacionAsync(Notificacion);
            if (!updated)
                return NotFound();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteNotificacion(int id)
        {
            var deleted = await _NotificacionRepository.DeleteNotificacionAsync(id);
            if (!deleted)
                return NotFound();

            return NoContent();
        }
    }
}
