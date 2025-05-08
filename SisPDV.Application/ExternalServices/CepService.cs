using SisPDV.Application.DTOs.Cep;
using SisPDV.Application.ExternalInterfaces;
using System.Net.Http.Json;

namespace SisPDV.Application.ExternalServices
{
    
    public class CepService : ICepService
    {
        private readonly HttpClient _httpClient = new HttpClient();

        public async Task<CepResponseDto?> GetCepsync(string cep)
        {
            var response = await _httpClient.GetAsync($"https://viacep.com.br/ws/{cep}/json/");

            if (!response.IsSuccessStatusCode) return null;

            return await response.Content.ReadFromJsonAsync<CepResponseDto>();
        }
    }
}
