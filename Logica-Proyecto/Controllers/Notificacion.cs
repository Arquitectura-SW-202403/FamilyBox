using Microsoft.AspNetCore.Mvc;
using Entities;
using Serivicios.Services;

namespace Serivicios.Controller
{


    [ApiController]
    [Route("api/[controller]")]
    public class NotificacionController : ControllerBase
    {
        private readonly NotificacionService _NotificacionService;

        public NotificacionController(NotificacionService NotificacionService)
        {
            _NotificacionService = NotificacionService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var Notificacions = await _NotificacionService.GetAllNotificacionsAsync();
            return Ok(Notificacions);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var Notificacion = await _NotificacionService.GetNotificacionByIdAsync(id);
            if (Notificacion == null)
                return NotFound();
            return Ok(Notificacion);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Notificacion Notificacion)
        {
            await _NotificacionService.CreateNotificacionAsync(Notificacion);
            return CreatedAtAction(nameof(GetById), new { id = Notificacion.NotificacionId }, Notificacion);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Notificacion Notificacion)
        {
            if (id != Notificacion.NotificacionId)
                return BadRequest();

            var updated = await _NotificacionService.UpdateNotificacionAsync(Notificacion);
            if (!updated)
                return NotFound();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _NotificacionService.DeleteNotificacionAsync(id);
            if (!deleted)
                return NotFound();

            return NoContent();
        }
    }

}