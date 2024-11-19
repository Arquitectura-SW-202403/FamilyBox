using Entities;

namespace Persistencia.Interface
{
    public interface IEventoRepository
    {
        Task<List<Evento>> GetAllEventosAsync();
        Task<Evento> GetEventoByIdAsync(int id);
        Task CreateEventoAsync(Evento evento);
        Task<bool> UpdateEventoAsync(Evento evento);
        Task<bool> DeleteEventoAsync(int id);
    }
}