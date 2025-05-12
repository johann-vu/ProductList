using ProductList.Models;

namespace ProductList.Plugin;

public interface IProductRepository
{
    List<Product> GetAllProducts();
    Product GetProductById(int id);
    void ReplaceAllProducts(List<Product> products);
}