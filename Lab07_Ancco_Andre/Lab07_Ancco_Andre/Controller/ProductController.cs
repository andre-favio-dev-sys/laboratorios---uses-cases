using Lab07_Ancco_Andre.DTOs;
using Lab07_Ancco_Andre.UseCases.Products;
using Microsoft.AspNetCore.Mvc;

namespace Lab07_Ancco_Andre.Controller;

[ApiController]
[Route("api/[controller]")]
public class ProductController(CreateProductUseCase createProduct) : ControllerBase
{
    [HttpPost]
    public IActionResult CreateProduct([FromBody] CreateProductDto product)
    {
        var message = createProduct.Execute(product);
        return Ok(new { message });
    }
}
