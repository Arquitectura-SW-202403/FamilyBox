using Microsoft.EntityFrameworkCore;
using Persistencia.Data;
using Entities;
using Persistencia.Interface;

namespace Persistencia.Repository
{
    public class ProgramaDepRepository : IProgramaDepRepository
    {
        private readonly ApplicationDbContext _context;

        public ProgramaDepRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<ProgramaDep>> GetAllProgramaDepsAsync()
        {
            return await _context.ProgramasDep.ToListAsync();
        }

        public async Task<ProgramaDep> GetProgramaDepByIdAsync(int id)
        {
            return await _context.ProgramasDep.FindAsync(id);
        }

        public async Task CreateProgramaDepAsync(ProgramaDep ProgramaDep)
        {
            await _context.ProgramasDep.AddAsync(ProgramaDep);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> UpdateProgramaDepAsync(ProgramaDep ProgramaDep)
        {
            _context.ProgramasDep.Update(ProgramaDep);
            var result = await _context.SaveChangesAsync();
            return result > 0;
        }

        public async Task<bool> DeleteProgramaDepAsync(int id)
        {
            var ProgramaDep = await _context.ProgramasDep.FindAsync(id);
            if (ProgramaDep == null)
                return false;

            _context.ProgramasDep.Remove(ProgramaDep);
            var result = await _context.SaveChangesAsync();
            return result > 0;
        }
    }
}