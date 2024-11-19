using Microsoft.EntityFrameworkCore;
using Persistencia.Data;
using Entities;
using Persistencia.Interface;

namespace Persistencia.Repository
{
    public class NotificacionRepository : INotificacionRepository
    {
        private readonly ApplicationDbContext _context;

        public NotificacionRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Notificacion>> GetAllNotificacionsAsync()
        {
            return await _context.Notificaciones.ToListAsync();
        }

        public async Task<Notificacion> GetNotificacionByIdAsync(int id)
        {
            return await _context.Notificaciones.FindAsync(id);
        }

        public async Task CreateNotificacionAsync(Notificacion Notificacion)
        {
            await _context.Notificaciones.AddAsync(Notificacion);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> UpdateNotificacionAsync(Notificacion Notificacion)
        {
            _context.Notificaciones.Update(Notificacion);
            var result = await _context.SaveChangesAsync();
            return result > 0;
        }

        public async Task<bool> DeleteNotificacionAsync(int id)
        {
            var Notificacion = await _context.Notificaciones.FindAsync(id);
            if (Notificacion == null)
                return false;

            _context.Notificaciones.Remove(Notificacion);
            var result = await _context.SaveChangesAsync();
            return result > 0;
        }
    }
}