using SisPDV.Application.DTOs.Cnpj;
using SisPDV.Application.ExternalInterfaces;
using System.Net.Http.Json;

namespace SisPDV.Application.ExternalServices
{
    public class CnpjService : ICnpjService
    {
        private readonly HttpClient _httpClient = new HttpClient();
        public async Task<CnpjResponseDTO?> GetCNPJAsync(string cnpj)
        {
            var response = await _httpClient.GetAsync($"https://receitaws.com.br/v1/cnpj/{cnpj}");

            if (!response.IsSuccessStatusCode) return null;

            return await response.Content.ReadFromJsonAsync<CnpjResponseDTO?>();
        }
    }
}
