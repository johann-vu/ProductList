using ProductList.Models;

namespace ProductList.Plugin;

public interface IProductDataSource
{
    Task<List<Product>> LoadProducts();
}