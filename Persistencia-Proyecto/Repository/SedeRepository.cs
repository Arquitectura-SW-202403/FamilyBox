using Microsoft.EntityFrameworkCore;
using Persistencia.Data;
using Entities;
using Persistencia.Interface;

namespace Persistencia.Repository
{
    public class SedeRepository : ISedeRepository
    {
        private readonly ApplicationDbContext _context;

        public SedeRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Sede>> GetAllSedesAsync()
        {
            return await _context.Sedes.ToListAsync();
        }

        public async Task<Sede> GetSedeByIdAsync(int id)
        {
            return await _context.Sedes.FindAsync(id);
        }

        public async Task CreateSedeAsync(Sede Sede)
        {
            await _context.Sedes.AddAsync(Sede);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> UpdateSedeAsync(Sede Sede)
        {
            _context.Sedes.Update(Sede);
            var result = await _context.SaveChangesAsync();
            return result > 0;
        }

        public async Task<bool> DeleteSedeAsync(int id)
        {
            var Sede = await _context.Sedes.FindAsync(id);
            if (Sede == null)
                return false;

            _context.Sedes.Remove(Sede);
            var result = await _context.SaveChangesAsync();
            return result > 0;
        }
    }
}