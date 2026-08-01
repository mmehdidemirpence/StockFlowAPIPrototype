using Microsoft.AspNetCore.Mvc;
using StockFlowAPI.Models;

namespace StockFlowAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SuppliersController : ControllerBase
{
    private static List<Supplier> suppliers = new()
    {
        new Supplier
        {
            Id = 1,
            CompanyName = "ABC Teknoloji",
            ContactName = "Mehmet Kaya",
            Phone = "5554443322"
        }
    };


    // Tüm tedarikçileri getir
    [HttpGet]
    public IActionResult GetSuppliers()
    {
        return Ok(suppliers);
    }


    // Yeni tedarikçi ekle
    [HttpPost]
    public IActionResult AddSupplier(Supplier supplier)
    {
        supplier.Id = suppliers.Count + 1;
        suppliers.Add(supplier);

        return Ok(supplier);
    }


    // Tedarikçi sil
    [HttpDelete("{id}")]
    public IActionResult DeleteSupplier(int id)
    {
        var supplier = suppliers.FirstOrDefault(x => x.Id == id);

        if (supplier == null)
            return NotFound();

        suppliers.Remove(supplier);

        return Ok("Tedarikçi silindi");
    }
}