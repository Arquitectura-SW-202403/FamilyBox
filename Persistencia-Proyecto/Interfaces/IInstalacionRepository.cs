using Entities;

namespace Persistencia.Interface
{
    public interface IInstalacionRepository
    {
        Task<List<Instalacion>> GetAllInstalacionsAsync();
        Task<Instalacion> GetInstalacionByIdAsync(int id);
        Task CreateInstalacionAsync(Instalacion Instalacion);
        Task<bool> UpdateInstalacionAsync(Instalacion Instalacion);
        Task<bool> DeleteInstalacionAsync(int id);
    }
}