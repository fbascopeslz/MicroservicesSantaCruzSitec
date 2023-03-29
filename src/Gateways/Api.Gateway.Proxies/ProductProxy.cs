using Api.Gateway.Models.Product.Commands;
using Api.Gateway.Models.Product.DTOs;
using Api.Gateway.Proxies.Interfaces;
using Microsoft.Extensions.Options;
using System.Text;
using System.Text.Json;

namespace Api.Gateway.Proxies
{
    public class ProductProxy : IProductProxy
    {
        private readonly ApiUrls _apiUrls;
        private readonly HttpClient _httpClient;

        public ProductProxy(HttpClient httpClient, IOptions<ApiUrls> apiUrls)
        {           
            _httpClient = httpClient;
            _apiUrls = apiUrls.Value;
        }

        public async Task<List<ProductDto>> GetAllAsync()
        {
            var request = await _httpClient.GetAsync($"{_apiUrls.ProductUrl}products");
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
            var request = await _httpClient.GetAsync($"{_apiUrls.ProductUrl}products/{id}");
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

            var request = await _httpClient.PostAsync($"{_apiUrls.ProductUrl}products", content);
            request.EnsureSuccessStatusCode();
        }                

        public async Task Update(int id, ProductUpdateCommand command)
        {
            var content = new StringContent(
                JsonSerializer.Serialize(command),
                Encoding.UTF8,
                "application/json"
            );

            var request = await _httpClient.PutAsync($"{_apiUrls.ProductUrl}products/{id}", content);
            request.EnsureSuccessStatusCode();
        }

        public async Task Delete(int id)
        {
            var request = await _httpClient.DeleteAsync($"{_apiUrls.ProductUrl}products/{id}");
            request.EnsureSuccessStatusCode();
        }
    }
}