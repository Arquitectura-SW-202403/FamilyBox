using Entities;

namespace Persistencia.Interface
{
    public interface INotificacionRepository
    {
        Task<List<Notificacion>> GetAllNotificacionsAsync();
        Task<Notificacion> GetNotificacionByIdAsync(int id);
        Task CreateNotificacionAsync(Notificacion Notificacion);
        Task<bool> UpdateNotificacionAsync(Notificacion Notificacion);
        Task<bool> DeleteNotificacionAsync(int id);
    }
}