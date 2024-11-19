using Entities;

namespace Persistencia.Interface
{
    public interface IUsuarioRepository
    {
        Task<List<Usuario>> GetAllUsuariosAsync();
        Task<Usuario> GetUsuarioByIdAsync(string id);
        Task CreateUsuarioAsync(Usuario Usuario);
        Task<bool> UpdateUsuarioAsync(Usuario Usuario);
        Task<bool> DeleteUsuarioAsync(string id);
    }
}