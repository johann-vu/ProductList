using ProductList.Models;

namespace ProductList.Plugin;

public class ProductRepository : IProductRepository
{
    private List<Product> _products = [];

    public List<Product> GetAllProducts()
    {
        return _products;
    }

    public Product GetProductById(int id)
    {
        var product = _products.Find(p => p.Id == id);
        if (product == null)
        {
            throw new Exception("Product not found");
        }

        return product;
    }

    public void ReplaceAllProducts(List<Product> products)
    {
        _products = products;
    }
}