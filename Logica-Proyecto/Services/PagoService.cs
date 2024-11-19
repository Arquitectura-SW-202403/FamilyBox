using System.Net.Http.Headers;
using System.Text;
using Newtonsoft.Json;
using Entities;

namespace Serivicios.Services
{
    public class PagoService
    {

        private readonly HttpClient _httpClient;

        public PagoService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Pago>> GetAllPagosAsync()
        {
            var response = await _httpClient.GetAsync("http://localhost:8080/api/Pago");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<List<Pago>>();
        }

        public async Task<Pago> GetPagoByIdAsync(int id)
        {
            var response = await _httpClient.GetAsync($"http://localhost:8080/api/Pago/{id}");
            if (response.IsSuccessStatusCode)
                return await response.Content.ReadFromJsonAsync<Pago>();
            return null;
        }

        public async Task CreatePagoAsync(Pago Pago)
        {
            var url = "http://localhost:8080/api/Pago";
            var contenidoJson = JsonConvert.SerializeObject(Pago);

            var content = new StringContent(contenidoJson, Encoding.UTF8, "application/json");

            // Usando el objeto MediaTypeHeaderValue para establecer el tipo de contenido correctamente
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var response = await _httpClient.PostAsync(url, content);

            response.EnsureSuccessStatusCode();
        }

        public async Task<bool> UpdatePagoAsync(Pago Pago)
        {
            var url = $"http://localhost:8080/api/Pago/{Pago.PagoId}";  // URL de la API con el ID de la Pago

            var contenidoJson = JsonConvert.SerializeObject(Pago);  // Serializamos el objeto Entity a JSON
            var content = new StringContent(contenidoJson, Encoding.UTF8, "application/json");  // Creamos el StringContent

            // Usamos el objeto MediaTypeHeaderValue para establecer el tipo de contenido
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            // Realizamos la solicitud PUT para actualizar la Pago
            var response = await _httpClient.PutAsync(url, content);

            if (response.IsSuccessStatusCode)
            {
                return true;  // Actualización exitosa
            }
            return false;  // Si algo salió mal, retornamos false
        }

        public async Task<bool> DeletePagoAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"http://localhost:8080/api/Pago/{id}");
            return response.IsSuccessStatusCode;
        }
    }
}