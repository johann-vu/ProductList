using ProductList.Plugin;

namespace TestProject.Plugin;

[TestFixture]
[TestOf(typeof(ProductDataSource))]
public class ProductDataSourceTest
{
    [Test]
    public void LoadProducts()
    {
        var source = new ProductDataSource(new HttpClient(),
            "https://flapotest.blob.core.windows.net/test/ProductData.json");
        var products = source.LoadProducts().Result;
        Assert.That(products, Is.Not.Null);
    }
}