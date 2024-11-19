using Microsoft.EntityFrameworkCore;
using Persistencia.Data;
using Entities;
using Persistencia.Interface;

namespace Persistencia.Repository
{
    public class EventoRepository : IEventoRepository
    {
        private readonly ApplicationDbContext _context;

        public EventoRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Evento>> GetAllEventosAsync()
        {
            return await _context.Eventos.ToListAsync();
        }

        public async Task<Evento> GetEventoByIdAsync(int id)
        {
            return await _context.Eventos.FindAsync(id);
        }

        public async Task CreateEventoAsync(Evento evento)
        {
            await _context.Eventos.AddAsync(evento);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> UpdateEventoAsync(Evento evento)
        {
            _context.Eventos.Update(evento);
            var result = await _context.SaveChangesAsync();
            return result > 0;
        }

        public async Task<bool> DeleteEventoAsync(int id)
        {
            var evento = await _context.Eventos.FindAsync(id);
            if (evento == null)
                return false;

            _context.Eventos.Remove(evento);
            var result = await _context.SaveChangesAsync();
            return result > 0;
        }
    }
}