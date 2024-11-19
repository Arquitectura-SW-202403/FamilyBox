using Microsoft.EntityFrameworkCore;
using Persistencia.Data;
using Entities;
using Persistencia.Interface;

namespace Persistencia.Repository
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly ApplicationDbContext _context;

        public UsuarioRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Usuario>> GetAllUsuariosAsync()
        {
            return await _context.Usuarios.ToListAsync();
        }

        public async Task<Usuario> GetUsuarioByIdAsync(string id)
        {
            return await _context.Usuarios.FindAsync(id);
        }

        public async Task CreateUsuarioAsync(Usuario Usuario)
        {
            await _context.Usuarios.AddAsync(Usuario);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> UpdateUsuarioAsync(Usuario Usuario)
        {
            _context.Usuarios.Update(Usuario);
            var result = await _context.SaveChangesAsync();
            return result > 0;
        }

        public async Task<bool> DeleteUsuarioAsync(string id)
        {
            var Usuario = await _context.Usuarios.FindAsync(id);
            if (Usuario == null)
                return false;

            _context.Usuarios.Remove(Usuario);
            var result = await _context.SaveChangesAsync();
            return result > 0;
        }
    }
}