using Entities;

namespace Persistencia.Interface
{
    public interface IReservaRepository
    {
        Task<List<Reserva>> GetAllReservasAsync();
        Task<Reserva> GetReservaByIdAsync(int id);
        Task CreateReservaAsync(Reserva Reserva);
        Task<bool> UpdateReservaAsync(Reserva Reserva);
        Task<bool> DeleteReservaAsync(int id);
    }
}