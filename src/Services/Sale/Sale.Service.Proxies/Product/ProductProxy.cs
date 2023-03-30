using Microsoft.Extensions.Options;
using Sale.Service.Proxies.Product.Commands;
using Sale.Service.Proxies.Product.Interfaces;
using System.Text;
using System.Text.Json;

namespace Sale.Service.Proxies.Product
{
    public class ProductProxy : IProductProxy
    {
        private readonly ApiUrls _apiUrls;
        private readonly HttpClient _httpClient;

        public ProductProxy(IOptions<ApiUrls> apiUrls, HttpClient httpClient)
        {
            _apiUrls = apiUrls.Value;
            _httpClient = httpClient;
        }

        public async Task UpdateStockAsync(ProductUpdateStockCommand command)
        {
            var content = new StringContent(
                JsonSerializer.Serialize(command),
                Encoding.UTF8,
                "application/json"
            );

            var request = await _httpClient.PutAsync($"{_apiUrls.ProductUrl}products/updateStock", content);

            request.EnsureSuccessStatusCode();
        }
    }
}