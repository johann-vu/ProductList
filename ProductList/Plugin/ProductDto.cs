using System.Globalization;
using System.Text.RegularExpressions;
using Newtonsoft.Json;
using ProductList.Models;

namespace ProductList.Plugin;

public class ArticleDto
{
    [JsonProperty("id")] public int Id { get; set; }

    [JsonProperty("shortDescription")] public string ShortDescription { get; set; }

    [JsonProperty("price")] public double Price { get; set; }

    [JsonProperty("unit")] public string Unit { get; set; }

    [JsonProperty("pricePerUnitText")] public string PricePerUnitText { get; set; }

    [JsonProperty("image")] public string Image { get; set; }

    public Article ToEntity()
    {
        Match match = Regex.Match(PricePerUnitText, @"\d+,\d+");
        var pricePerUnitValue = match.Success ? double.Parse(match.Value, new CultureInfo("de-DE")) : 0;

        var article = new Article
        {
            Id = Id,
            ShortDescription = ShortDescription,
            Price = Price,
            Unit = Unit,
            PricePerLiter = pricePerUnitValue,
            Image = Image
        };
        return article;
    }
}

public class ProductDto
{
    [JsonProperty("id")] public int Id { get; set; }

    [JsonProperty("brandName")] public string BrandName { get; set; }

    [JsonProperty("name")] public string Name { get; set; }

    [JsonProperty("descriptionText")] public string DescriptionText { get; set; }

    [JsonProperty("articles")] public List<ArticleDto> Articles { get; set; }

    public Product ToEntity()
    {
        var articles = Articles.ConvertAll(d => d.ToEntity());
        var product = new Product
        {
            Id = Id,
            BrandName = BrandName,
            Name = Name,
            Articles = articles
        };
        return product;
    }
}