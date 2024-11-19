using Microsoft.EntityFrameworkCore;
using Persistencia.Data;
using Entities;
using Persistencia.Interface;

namespace Persistencia.Repository
{
    public class ReservaRepository : IReservaRepository
    {
        private readonly ApplicationDbContext _context;

        public ReservaRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Reserva>> GetAllReservasAsync()
        {
            return await _context.Reservas.ToListAsync();
        }

        public async Task<Reserva> GetReservaByIdAsync(int id)
        {
            return await _context.Reservas.FindAsync(id);
        }

        public async Task CreateReservaAsync(Reserva Reserva)
        {
            await _context.Reservas.AddAsync(Reserva);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> UpdateReservaAsync(Reserva Reserva)
        {
            _context.Reservas.Update(Reserva);
            var result = await _context.SaveChangesAsync();
            return result > 0;
        }

        public async Task<bool> DeleteReservaAsync(int id)
        {
            var Reserva = await _context.Reservas.FindAsync(id);
            if (Reserva == null)
                return false;

            _context.Reservas.Remove(Reserva);
            var result = await _context.SaveChangesAsync();
            return result > 0;
        }
    }
}