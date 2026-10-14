using Lab04_Ancco_Andre.Models;
using Lab04_Ancco_Andre.UseCases.Productos;
using Microsoft.AspNetCore.Mvc;

namespace Lab04_Ancco_Andre.Controller;

[ApiController]
[Route("api/[controller]")]
public class ProductosController(
    GetAllProductosUseCase getAll,
    GetProductoByIdUseCase getById,
    CreateProductoUseCase create,
    UpdateProductoUseCase update,
    DeleteProductoUseCase delete) : ControllerBase
{
    [HttpGet]
    public IActionResult GetAll() => Ok(getAll.Execute());

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var resultado = getById.Execute(id);
        return resultado == null ? NotFound(new { mensaje = "Producto no encontrado" }) : Ok(resultado);
    }

    [HttpPost]
    public IActionResult Create(Producto producto)
    {
        return Ok(create.Execute(producto));
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, Producto producto)
    {
        if (!update.Execute(id, producto))
            return NotFound(new { mensaje = "Producto no encontrado" });

        return Ok(new { mensaje = "Producto actualizado correctamente" });
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        if (!delete.Execute(id))
            return NotFound(new { mensaje = "Producto no encontrado" });

        return Ok(new { mensaje = "Producto eliminado correctamente" });
    }
}

