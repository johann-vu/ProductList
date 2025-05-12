using Microsoft.AspNetCore.Mvc;
using ProductList.Plugin;
using ProductList.Services;

var repo = new ProductRepository();
var dataSource =
    new ProductDataSource(new HttpClient(), "https://flapotest.blob.core.windows.net/test/ProductData.json");
var service = new ProductsService(repo, dataSource);
service.LoadProducts();

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
        b =>
        {
            b.AllowAnyOrigin();
            b.AllowAnyMethod();
            b.AllowAnyHeader();
        });
});

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("/api/products",
        (
            bool? sortDescending,
            double? maxPrice) =>
        {
            var products = service.GetProducts(sortDescending ?? false, maxPrice);
            return Results.Ok(products);
        })
    .WithName("GetProducts")
    .WithOpenApi();

app.MapGet("/api/products/{id}", (string id) =>
    {
        var parsedId = int.Parse(id);
        var product = service.GetProductById(parsedId);
        return product;
    })
    .WithName("GetProduct")
    .WithOpenApi();

app.UseCors(MyAllowSpecificOrigins);

app.UseDefaultFiles();
app.UseStaticFiles();

app.MapFallbackToFile("index.html");


app.Run();