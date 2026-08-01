using Microsoft.AspNetCore.Mvc;
using StockFlowAPI.Models;

namespace StockFlowAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CategoriesController : ControllerBase
{
    private static List<Category> categories = new()
    {
        new Category
        {
            Id = 1,
            Name = "Elektronik"
        },
        new Category
        {
            Id = 2,
            Name = "Aksesuar"
        }
    };


    // Tüm kategorileri getir
    [HttpGet]
    public IActionResult GetCategories()
    {
        return Ok(categories);
    }


    // Yeni kategori ekle
    [HttpPost]
    public IActionResult AddCategory(Category category)
    {
        category.Id = categories.Count + 1;
        categories.Add(category);

        return Ok(category);
    }


    // Kategori sil
    [HttpDelete("{id}")]
    public IActionResult DeleteCategory(int id)
    {
        var category = categories.FirstOrDefault(x => x.Id == id);

        if (category == null)
            return NotFound();

        categories.Remove(category);

        return Ok("Kategori silindi");
    }
}