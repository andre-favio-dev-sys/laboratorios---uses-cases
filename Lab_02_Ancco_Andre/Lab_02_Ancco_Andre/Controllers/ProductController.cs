using Lab_02_Ancco_Andre.Models.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace Lab_02_Ancco_Andre.Controllers;

[ApiController]
[Route("api/products")]
public class ProductController : ControllerBase
{
    private static List<string> products = new() { "Laptop", "Mouse", "Teclado" };

    [HttpGet]
    public IActionResult GetAll() => Ok(products);

    [HttpPost]
    public IActionResult Add([FromBody] ProductDto product)
    {
        products.Add(product.Name);
        return Ok(new { message = "Producto agregado", products });
    }

    [HttpDelete("{index}")]
    public IActionResult Delete(int index)
    {
        if (index < 0 || index >= products.Count)
            return NotFound(new { message = "Índice fuera de rango" });

        products.RemoveAt(index);
        return Ok(new { message = "Producto eliminado", products });
    }
}