using Api.Gateway.Models.Sale.Commands;
using Api.Gateway.Models.Sale.DTOs;
using Api.Gateway.WebClient.Proxy.Config;
using System.Text;
using System.Text.Json;

namespace Api.Gateway.WebClient.Proxy
{
    public class SaleProxy : ISaleProxy
    {
        private readonly string _apiGatewayUrl;
        private readonly HttpClient _httpClient;

        public SaleProxy(HttpClient httpClient, ApiGatewayUrl apiGatewayUrl)
        {           
            _httpClient = httpClient;
            _apiGatewayUrl = apiGatewayUrl.Value;
        }

        public async Task<List<SaleDto>> GetAllAsync()
        {
            var request = await _httpClient.GetAsync($"{_apiGatewayUrl}sales");
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

            var request = await _httpClient.PostAsync($"{_apiGatewayUrl}sales", content);
            request.EnsureSuccessStatusCode();
        }

        public async Task ChangeSaleStatusDelivered(int id)
        {
            var request = await _httpClient.PutAsync($"{_apiGatewayUrl}sales/changeSaleStatusDelivered/{id}", null);
            request.EnsureSuccessStatusCode();
        }
    }
}