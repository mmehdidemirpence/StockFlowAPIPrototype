using Microsoft.AspNetCore.Mvc;
using StockFlowAPI.Models;

namespace StockFlowAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CustomersController : ControllerBase
{
    private static List<Customer> customers = new()
    {
        new Customer
        {
            Id = 1,
            Name = "Ahmet Yılmaz",
            Email = "ahmet@mail.com",
            Phone = "5551112233"
        }
    };


    // Tüm müşterileri getir
    [HttpGet]
    public IActionResult GetCustomers()
    {
        return Ok(customers);
    }


    // Yeni müşteri ekle
    [HttpPost]
    public IActionResult AddCustomer(Customer customer)
    {
        customer.Id = customers.Count + 1;
        customers.Add(customer);

        return Ok(customer);
    }


    // Müşteri sil
    [HttpDelete("{id}")]
    public IActionResult DeleteCustomer(int id)
    {
        var customer = customers.FirstOrDefault(x => x.Id == id);

        if (customer == null)
            return NotFound();

        customers.Remove(customer);

        return Ok("Müşteri silindi");
    }
}