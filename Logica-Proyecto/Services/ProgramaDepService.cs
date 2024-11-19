using System.Net.Http.Headers;
using System.Text;
using Newtonsoft.Json;
using Entities;

namespace Serivicios.Services
{
    public class ProgramaDepService
    {

        private readonly HttpClient _httpClient;

        public ProgramaDepService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<ProgramaDep>> GetAllProgramaDepsAsync()
        {
            var response = await _httpClient.GetAsync("http://localhost:8080/api/ProgramaDep");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<List<ProgramaDep>>();
        }

        public async Task<ProgramaDep> GetProgramaDepByIdAsync(int id)
        {
            var response = await _httpClient.GetAsync($"http://localhost:8080/api/ProgramaDep/{id}");
            if (response.IsSuccessStatusCode)
                return await response.Content.ReadFromJsonAsync<ProgramaDep>();
            return null;
        }

        public async Task CreateProgramaDepAsync(ProgramaDep ProgramaDep)
        {
            var url = "http://localhost:8080/api/ProgramaDep";
            var contenidoJson = JsonConvert.SerializeObject(ProgramaDep);

            var content = new StringContent(contenidoJson, Encoding.UTF8, "application/json");

            // Usando el objeto MediaTypeHeaderValue para establecer el tipo de contenido correctamente
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var response = await _httpClient.PostAsync(url, content);

            response.EnsureSuccessStatusCode();
        }

        public async Task<bool> UpdateProgramaDepAsync(ProgramaDep ProgramaDep)
        {
            var url = $"http://localhost:8080/api/ProgramaDep/{ProgramaDep.ProgramaId}";  // URL de la API con el ID de la ProgramaDep

            var contenidoJson = JsonConvert.SerializeObject(ProgramaDep);  // Serializamos el objeto Entity a JSON
            var content = new StringContent(contenidoJson, Encoding.UTF8, "application/json");  // Creamos el StringContent

            // Usamos el objeto MediaTypeHeaderValue para establecer el tipo de contenido
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            // Realizamos la solicitud PUT para actualizar la ProgramaDep
            var response = await _httpClient.PutAsync(url, content);

            if (response.IsSuccessStatusCode)
            {
                return true;  // Actualización exitosa
            }
            return false;  // Si algo salió mal, retornamos false
        }

        public async Task<bool> DeleteProgramaDepAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"http://localhost:8080/api/ProgramaDep/{id}");
            return response.IsSuccessStatusCode;
        }
    }
}