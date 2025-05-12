using ProductList.Models;
using ProductList.Plugin;

namespace ProductList.Services;

public class ProductsService(IProductRepository productRepository, IProductDataSource productDataSource)
{
    public List<Product> GetProducts(bool sortDescending = true, double? maxPrice = null)
    {
        var products = productRepository.GetAllProducts()
            .Select(p => new Product
            {
                Id = p.Id,
                Name = p.Name,
                BrandName = p.BrandName,
                Articles = p.Articles.ToList()
            })
            .ToList();

        if (maxPrice.HasValue)
        {
            products = products.ConvertAll(p =>
            {
                p.Articles = p.Articles.Where(a => a.PricePerLiter <= maxPrice.Value).ToList();
                return p;
            });
            products = products.FindAll(p => p.Articles.Count > 0);
        }

        products = sortDescending
            ? products.OrderByDescending(p => p.Articles.Max(a => a.Price)).ToList()
            : products.OrderBy(p => p.Articles.Max(a => a.Price)).ToList();


        return products;
    }

    public Product GetProductById(int id)
    {
        return productRepository.GetProductById(id);
    }

    public void LoadProducts()
    {
        var products = productDataSource.LoadProducts().Result;
        productRepository.ReplaceAllProducts(products);
    }
}