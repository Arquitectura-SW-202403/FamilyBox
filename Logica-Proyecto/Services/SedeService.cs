
using System.Net.Http.Headers;
using System.Text;
using Newtonsoft.Json;
using Entities;


namespace Serivicios.Services{
    public class SedeService
{
    private readonly HttpClient _httpClient;
    private readonly string _dataURL;

    public SedeService(HttpClient httpClient)
    {
        _httpClient = httpClient;
        _dataURL = Environment.GetEnvironmentVariable("DATA_URL")!;
    }

    public async Task<List<Sede>> GetAllSedesAsync()
    {
        var response = await _httpClient.GetAsync($"{_dataURL}/api/Sede");
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadFromJsonAsync<List<Sede>>();
    }

    public async Task<Sede> GetSedeByIdAsync(int id)
    {
        var response = await _httpClient.GetAsync($"{_dataURL}/api/Sede/{id}");
        if (response.IsSuccessStatusCode)
            return await response.Content.ReadFromJsonAsync<Sede>();
        return null;
    }

     public async Task CreateSedeAsync(Sede sede)
    {
        var url = $"{_dataURL}/api/Sede";
        var contenidoJson = JsonConvert.SerializeObject(sede);
        
        var content = new StringContent(contenidoJson, Encoding.UTF8, "application/json");

        // Usando el objeto MediaTypeHeaderValue para establecer el tipo de contenido correctamente
        content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

        var response = await _httpClient.PostAsync(url, content);

        response.EnsureSuccessStatusCode();
    }

    public async Task<bool> UpdateSedeAsync(Sede sede)
    {
        var url = $"{_dataURL}/api/Sede/{sede.SedeId}";  // URL de la API con el ID de la sede

        var contenidoJson = JsonConvert.SerializeObject(sede);  // Serializamos el objeto Entity a JSON
        var content = new StringContent(contenidoJson, Encoding.UTF8, "application/json");  // Creamos el StringContent

        // Usamos el objeto MediaTypeHeaderValue para establecer el tipo de contenido
        content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

        // Realizamos la solicitud PUT para actualizar la sede
        var response = await _httpClient.PutAsync(url, content);

        if (response.IsSuccessStatusCode)
        {
            return true;  // Actualización exitosa
        }
        return false;  // Si algo salió mal, retornamos false
    }

    public async Task<bool> DeleteSedeAsync(int id)
    {
        var response = await _httpClient.DeleteAsync($"{_dataURL}/api/Sede/{id}");
        return response.IsSuccessStatusCode;
    }
}

  
}