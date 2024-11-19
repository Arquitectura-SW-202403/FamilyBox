using Entities;

namespace Persistencia.Interface
{
    public interface ISedeRepository
    {
        Task<List<Sede>> GetAllSedesAsync();
        Task<Sede> GetSedeByIdAsync(int id);
        Task CreateSedeAsync(Sede Sede);
        Task<bool> UpdateSedeAsync(Sede Sede);
        Task<bool> DeleteSedeAsync(int id);
    }
}