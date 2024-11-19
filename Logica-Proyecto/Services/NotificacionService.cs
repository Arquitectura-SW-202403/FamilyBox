using System.Net.Http.Headers;
using System.Text;
using Newtonsoft.Json;
using Entities;

namespace Serivicios.Services{
    public class NotificacionService {
        
        private readonly HttpClient _httpClient;

        public NotificacionService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Notificacion>> GetAllNotificacionsAsync()
        {
            var response = await _httpClient.GetAsync("http://localhost:8080/api/Notificacion");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<List<Notificacion>>();
        }

        public async Task<Notificacion> GetNotificacionByIdAsync(int id)
        {
            var response = await _httpClient.GetAsync($"http://localhost:8080/api/Notificacion/{id}");
            if (response.IsSuccessStatusCode)
                return await response.Content.ReadFromJsonAsync<Notificacion>();
            return null;
        }

        public async Task CreateNotificacionAsync(Notificacion Notificacion)
        {
            var url = "http://localhost:8080/api/Notificacion";
            var contenidoJson = JsonConvert.SerializeObject(Notificacion);

            var content = new StringContent(contenidoJson, Encoding.UTF8, "application/json");

            // Usando el objeto MediaTypeHeaderValue para establecer el tipo de contenido correctamente
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var response = await _httpClient.PostAsync(url, content);

            response.EnsureSuccessStatusCode();
        }

        public async Task<bool> UpdateNotificacionAsync(Notificacion Notificacion)
        {
            var url = $"http://localhost:8080/api/Notificacion/{Notificacion.NotificacionId}";  // URL de la API con el ID de la Notificacion

            var contenidoJson = JsonConvert.SerializeObject(Notificacion);  // Serializamos el objeto Entity a JSON
            var content = new StringContent(contenidoJson, Encoding.UTF8, "application/json");  // Creamos el StringContent

            // Usamos el objeto MediaTypeHeaderValue para establecer el tipo de contenido
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            // Realizamos la solicitud PUT para actualizar la Notificacion
            var response = await _httpClient.PutAsync(url, content);

            if (response.IsSuccessStatusCode)
            {
                return true;  // Actualización exitosa
            }
            return false;  // Si algo salió mal, retornamos false
        }

        public async Task<bool> DeleteNotificacionAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"http://localhost:8080/api/Notificacion/{id}");
            return response.IsSuccessStatusCode;
        }
    }
}