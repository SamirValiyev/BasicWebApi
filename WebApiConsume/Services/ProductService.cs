using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text.Json;
using WebApiConsume.Models;

namespace WebApiConsume.Services
{
    public class ProductService
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ProductService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IList<ProductResponse>> GetProductsAsync()
        {
            HttpClient client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("http://localhost:5046/api/Products");
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var jsonData =await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<IList<ProductResponse>>(jsonData);
            }
            else
            {
               return null;
            }
        }
    }
}
