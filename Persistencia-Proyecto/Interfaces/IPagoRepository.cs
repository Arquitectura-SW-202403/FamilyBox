using Entities;

namespace Persistencia.Interface
{
    public interface IPagoRepository
    {
        Task<List<Pago>> GetAllPagosAsync();
        Task<Pago> GetPagoByIdAsync(int id);
        Task CreatePagoAsync(Pago Pago);
        Task<bool> UpdatePagoAsync(Pago Pago);
        Task<bool> DeletePagoAsync(int id);
    }
}