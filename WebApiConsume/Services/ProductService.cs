using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
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
        [HttpGet]
        public async Task<IList<ProductResponse>> GetProductsAsync()
        {
            HttpClient client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("http://localhost:5046/api/Products");
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<IList<ProductResponse>>(jsonData);
            }
            else
            {
                return null;
            }
        }
        [HttpPost]
        public async Task<ProductResponse> CreateProductAsync(ProductRequest productRequest)
        {

            HttpClient client = _httpClientFactory.CreateClient();

            var jsonData = JsonConvert.SerializeObject(productRequest);
            StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");

            var responseMessage = await client.PostAsync("http://localhost:5046/api/Products", content);

            if (responseMessage.IsSuccessStatusCode)
            {
                var result = await responseMessage.Content.ReadAsStringAsync();


                return JsonConvert.DeserializeObject<ProductResponse>(result);
            }
            else
            {
                throw new Exception($"API xətası: {responseMessage.StatusCode} - {await responseMessage.Content.ReadAsStringAsync()}");
            }


        }
        [HttpGet]
        public async Task<ProductResponse> UpdateProductAsync(int id)
        {
            HttpClient client = _httpClientFactory.CreateClient();
         
            var responseMessage = await client.GetAsync($"http://localhost:5046/api/Products/{id}");
            if (responseMessage.StatusCode==System.Net.HttpStatusCode.OK)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<ProductResponse>(jsonData);
            }
            else
            {
                return null;
            }

        }
        [HttpPost]
        public async Task<ProductResponse> UpdateProductAsync(ProductResponse productResponse)
        {
            HttpClient client = _httpClientFactory.CreateClient();

            var jsonData=JsonConvert.SerializeObject(productResponse);
            var content=new StringContent(jsonData,Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync("http://localhost:5046/api/Products", content);
            if(responseMessage.IsSuccessStatusCode)
            {
                var result = await responseMessage.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<ProductResponse>(result);
            }
            else
            {
                return null;
            }

        }

        [HttpGet]
        public async Task<IList<ProductResponse>> RemoveProductAsync(int id)
        {
            HttpClient client = _httpClientFactory.CreateClient();
            var removeResponse= await client.DeleteAsync($"http://localhost:5046/api/Products/{id}");
            if(removeResponse.IsSuccessStatusCode)
            {
                var getResponse = await client.GetAsync("http://localhost:5046/api/Products");
                if (getResponse.IsSuccessStatusCode)
                {
                    var productsJson=await getResponse.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<IList<ProductResponse>>(productsJson);
                    
                }
            }
            return new List<ProductResponse>();
        }
    }
}
