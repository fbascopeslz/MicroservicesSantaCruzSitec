using Api.Gateway.Models.Product.Commands;
using Api.Gateway.Models.Product.DTOs;
using Api.Gateway.WebClient.Proxy.Config;
using System.Text;
using System.Text.Json;

namespace Api.Gateway.WebClient.Proxy
{
    public class ProductProxy : IProductProxy
    {
        private readonly string _apiGatewayUrl;
        private readonly HttpClient _httpClient;

        public ProductProxy(HttpClient httpClient, ApiGatewayUrl apiGatewayUrl)
        {           
            _httpClient = httpClient;
            _apiGatewayUrl = apiGatewayUrl.Value;
        }        

        public async Task<List<ProductDto>> GetAllAsync()
        {
            var request = await _httpClient.GetAsync($"{_apiGatewayUrl}products");
            request.EnsureSuccessStatusCode();

            return JsonSerializer.Deserialize<List<ProductDto>>(
                await request.Content.ReadAsStringAsync(),
                new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                }
            );
        }
        public async Task<ProductDto> GetById(int id)
        {
            var request = await _httpClient.GetAsync($"{_apiGatewayUrl}products/{id}");
            request.EnsureSuccessStatusCode();

            return JsonSerializer.Deserialize<ProductDto>(
                await request.Content.ReadAsStringAsync(),
                new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                }
            );
        }

        public async Task Create(ProductCreateCommand command)
        {
            var content = new StringContent(
                JsonSerializer.Serialize(command),
                Encoding.UTF8,
                "application/json"
            );

            var request = await _httpClient.PostAsync($"{_apiGatewayUrl}products", content);
            request.EnsureSuccessStatusCode();
        }

        public async Task Update(int id, ProductUpdateCommand command)
        {
            var content = new StringContent(
                JsonSerializer.Serialize(command),
                Encoding.UTF8,
                "application/json"
            );

            var request = await _httpClient.PutAsync($"{_apiGatewayUrl}products/{id}", content);
            request.EnsureSuccessStatusCode();
        }

        public async Task Delete(int id)
        {
            var request = await _httpClient.DeleteAsync($"{_apiGatewayUrl}products/{id}");
            request.EnsureSuccessStatusCode();
        }
    }
}