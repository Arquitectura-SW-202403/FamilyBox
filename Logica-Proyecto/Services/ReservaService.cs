using System.Net.Http.Headers;
using System.Text;
using Newtonsoft.Json;
using Entities;

namespace Serivicios.Services
{
    public class ReservaService
    {

        private readonly HttpClient _httpClient;

        public ReservaService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Reserva>> GetAllReservasAsync()
        {
            var response = await _httpClient.GetAsync("http://localhost:8080/api/Reserva");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<List<Reserva>>();
        }

        public async Task<Reserva> GetReservaByIdAsync(int id)
        {
            var response = await _httpClient.GetAsync($"http://localhost:8080/api/Reserva/{id}");
            if (response.IsSuccessStatusCode)
                return await response.Content.ReadFromJsonAsync<Reserva>();
            return null;
        }

        public async Task CreateReservaAsync(Reserva Reserva)
        {
            var url = "http://localhost:8080/api/Reserva";
            var contenidoJson = JsonConvert.SerializeObject(Reserva);

            var content = new StringContent(contenidoJson, Encoding.UTF8, "application/json");

            // Usando el objeto MediaTypeHeaderValue para establecer el tipo de contenido correctamente
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var response = await _httpClient.PostAsync(url, content);

            response.EnsureSuccessStatusCode();
        }

        public async Task<bool> UpdateReservaAsync(Reserva Reserva)
        {
            var url = $"http://localhost:8080/api/Reserva/{Reserva.ReservaId}";  // URL de la API con el ID de la Reserva

            var contenidoJson = JsonConvert.SerializeObject(Reserva);  // Serializamos el objeto Entity a JSON
            var content = new StringContent(contenidoJson, Encoding.UTF8, "application/json");  // Creamos el StringContent

            // Usamos el objeto MediaTypeHeaderValue para establecer el tipo de contenido
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            // Realizamos la solicitud PUT para actualizar la Reserva
            var response = await _httpClient.PutAsync(url, content);

            if (response.IsSuccessStatusCode)
            {
                return true;  // Actualización exitosa
            }
            return false;  // Si algo salió mal, retornamos false
        }

        public async Task<bool> DeleteReservaAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"http://localhost:8080/api/Reserva/{id}");
            return response.IsSuccessStatusCode;
        }
    }
}