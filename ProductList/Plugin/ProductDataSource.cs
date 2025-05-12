using Newtonsoft.Json;
using ProductList.Models;

namespace ProductList.Plugin;

public class ProductDataSource(HttpClient httpClient, string url) : IProductDataSource
{
    public async Task<List<Product>> LoadProducts()
    {
        try
        {
            var response = await httpClient.GetStringAsync(url);

            var products = JsonConvert.DeserializeObject<List<ProductDto>>(response);

            return products?.ConvertAll(p => p.ToEntity()) ?? [];
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error loading products: {ex.Message}");
            return [];
        }
    }
}