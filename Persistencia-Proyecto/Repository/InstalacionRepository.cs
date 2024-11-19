using Microsoft.EntityFrameworkCore;
using Persistencia.Data;
using Entities;
using Persistencia.Interface;

namespace Persistencia.Repository
{
    public class InstalacionRepository : IInstalacionRepository
    {
        private readonly ApplicationDbContext _context;

        public InstalacionRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Instalacion>> GetAllInstalacionsAsync()
        {
            return await _context.Instalaciones.ToListAsync();
        }

        public async Task<Instalacion> GetInstalacionByIdAsync(int id)
        {
            return await _context.Instalaciones.FindAsync(id);
        }

        public async Task CreateInstalacionAsync(Instalacion Instalacion)
        {
            await _context.Instalaciones.AddAsync(Instalacion);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> UpdateInstalacionAsync(Instalacion Instalacion)
        {
            _context.Instalaciones.Update(Instalacion);
            var result = await _context.SaveChangesAsync();
            return result > 0;
        }

        public async Task<bool> DeleteInstalacionAsync(int id)
        {
            var Instalacion = await _context.Instalaciones.FindAsync(id);
            if (Instalacion == null)
                return false;

            _context.Instalaciones.Remove(Instalacion);
            var result = await _context.SaveChangesAsync();
            return result > 0;
        }
    }
}