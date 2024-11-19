using Microsoft.EntityFrameworkCore;
using Persistencia.Data;
using Entities;
using Persistencia.Interface;

namespace Persistencia.Repository
{
    public class PagoRepository : IPagoRepository
    {
        private readonly ApplicationDbContext _context;

        public PagoRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Pago>> GetAllPagosAsync()
        {
            return await _context.Pagos.ToListAsync();
        }

        public async Task<Pago> GetPagoByIdAsync(int id)
        {
            return await _context.Pagos.FindAsync(id);
        }

        public async Task CreatePagoAsync(Pago Pago)
        {
            await _context.Pagos.AddAsync(Pago);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> UpdatePagoAsync(Pago Pago)
        {
            _context.Pagos.Update(Pago);
            var result = await _context.SaveChangesAsync();
            return result > 0;
        }

        public async Task<bool> DeletePagoAsync(int id)
        {
            var Pago = await _context.Pagos.FindAsync(id);
            if (Pago == null)
                return false;

            _context.Pagos.Remove(Pago);
            var result = await _context.SaveChangesAsync();
            return result > 0;
        }
    }
}