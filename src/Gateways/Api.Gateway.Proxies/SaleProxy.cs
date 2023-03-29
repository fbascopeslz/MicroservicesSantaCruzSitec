using Api.Gateway.Models.Sale.Commands;
using Api.Gateway.Models.Sale.DTOs;
using Api.Gateway.Proxies.Interfaces;
using Microsoft.Extensions.Options;
using System.Text;
using System.Text.Json;

namespace Api.Gateway.Proxies
{
    public class SaleProxy : ISaleProxy
    {
        private readonly ApiUrls _apiUrls;
        private readonly HttpClient _httpClient;

        public SaleProxy(HttpClient httpClient, IOptions<ApiUrls> apiUrls)
        {           
            _httpClient = httpClient;
            _apiUrls = apiUrls.Value;
        }

        public async Task<List<SaleDto>> GetAllAsync()
        {
            var request = await _httpClient.GetAsync($"{_apiUrls.SaleUrl}sales");
            request.EnsureSuccessStatusCode();

            return JsonSerializer.Deserialize<List<SaleDto>>(
                await request.Content.ReadAsStringAsync(),
                new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                }
            );
        }        

        public async Task Create(SaleCreateCommand command)
        {
            var content = new StringContent(
                JsonSerializer.Serialize(command),
                Encoding.UTF8,
                "application/json"
            );

            var request = await _httpClient.PostAsync($"{_apiUrls.SaleUrl}sales", content);
            request.EnsureSuccessStatusCode();
        }

        public async Task ChangeSaleStatusDelivered(int id)
        {            
            var request = await _httpClient.PutAsync($"{_apiUrls.SaleUrl}sales/changeSaleStatusDelivered/{id}", null);
            request.EnsureSuccessStatusCode();
        }
    }
}