namespace ProductList.Models;

public class Product
{
    public int Id { get; set; }
    public string BrandName { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public List<Article> Articles { get; set; } = [];
}

public class Article
{
    public int Id { get; set; }
    public string ShortDescription { get; set; } = string.Empty;
    public double Price { get; set; }
    public string Unit { get; set; } = string.Empty;
    
    public double PricePerLiter { get; set; }
    public string Image { get; set; } = string.Empty;
}