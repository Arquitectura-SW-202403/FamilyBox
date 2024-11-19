using System.Net.Http.Headers;
using System.Text;
using Newtonsoft.Json;
using Entities;

namespace Serivicios.Services
{
    public class InstalacionService
    {

        private readonly HttpClient _httpClient;

        public InstalacionService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Instalacion>> GetAllInstalacionsAsync()
        {
            var response = await _httpClient.GetAsync("http://localhost:8080/api/Instalacion");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<List<Instalacion>>();
        }

        public async Task<Instalacion> GetInstalacionByIdAsync(int id)
        {
            var response = await _httpClient.GetAsync($"http://localhost:8080/api/Instalacion/{id}");
            if (response.IsSuccessStatusCode)
                return await response.Content.ReadFromJsonAsync<Instalacion>();
            return null;
        }

        public async Task CreateInstalacionAsync(Instalacion Instalacion)
        {
            var url = "http://localhost:8080/api/Instalacion";
            var contenidoJson = JsonConvert.SerializeObject(Instalacion);

            var content = new StringContent(contenidoJson, Encoding.UTF8, "application/json");

            // Usando el objeto MediaTypeHeaderValue para establecer el tipo de contenido correctamente
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var response = await _httpClient.PostAsync(url, content);

            response.EnsureSuccessStatusCode();
        }

        public async Task<bool> UpdateInstalacionAsync(Instalacion Instalacion)
        {
            var url = $"http://localhost:8080/api/Instalacion/{Instalacion.InstalacionId}";  // URL de la API con el ID de la Instalacion

            var contenidoJson = JsonConvert.SerializeObject(Instalacion);  // Serializamos el objeto Entity a JSON
            var content = new StringContent(contenidoJson, Encoding.UTF8, "application/json");  // Creamos el StringContent

            // Usamos el objeto MediaTypeHeaderValue para establecer el tipo de contenido
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            // Realizamos la solicitud PUT para actualizar la Instalacion
            var response = await _httpClient.PutAsync(url, content);

            if (response.IsSuccessStatusCode)
            {
                return true;  // Actualización exitosa
            }
            return false;  // Si algo salió mal, retornamos false
        }

        public async Task<bool> DeleteInstalacionAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"http://localhost:8080/api/Instalacion/{id}");
            return response.IsSuccessStatusCode;
        }
    }
}
