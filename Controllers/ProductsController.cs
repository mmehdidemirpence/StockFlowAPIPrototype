using Microsoft.AspNetCore.Mvc;
using StockFlowAPI.Models;

namespace StockFlowAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductsController : ControllerBase
{
    private static List<Product> products = new()
    {
        new Product
        {
            Id = 1,
            Name = "Laptop",
            Stock = 10,
            Price = 25000
        },
        new Product
        {
            Id = 2,
            Name = "Mouse",
            Stock = 50,
            Price = 500
        }
    };


    // Tüm ürünleri getir
    [HttpGet]
    public IActionResult GetProducts()
    {
        return Ok(products);
    }


    // ID ile ürün getir
    [HttpGet("{id}")]
    public IActionResult GetProduct(int id)
    {
        var product = products.FirstOrDefault(x => x.Id == id);

        if (product == null)
            return NotFound();

        return Ok(product);
    }


    // Yeni ürün ekle
    [HttpPost]
    public IActionResult AddProduct(Product product)
    {
        product.Id = products.Count + 1;
        products.Add(product);

        return Ok(product);
    }


    // Ürün güncelle
    [HttpPut("{id}")]
    public IActionResult UpdateProduct(int id, Product updatedProduct)
    {
        var product = products.FirstOrDefault(x => x.Id == id);

        if (product == null)
            return NotFound();

        product.Name = updatedProduct.Name;
        product.Stock = updatedProduct.Stock;
        product.Price = updatedProduct.Price;

        return Ok(product);
    }


    // Ürün sil
    [HttpDelete("{id}")]
    public IActionResult DeleteProduct(int id)
    {
        var product = products.FirstOrDefault(x => x.Id == id);

        if (product == null)
            return NotFound();

        products.Remove(product);

        return Ok("Ürün silindi");
    }
}