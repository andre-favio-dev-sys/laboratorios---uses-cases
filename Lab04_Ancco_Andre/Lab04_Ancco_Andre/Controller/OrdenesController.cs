using Lab04_Ancco_Andre.Models;
using Lab04_Ancco_Andre.UseCases.Ordenes;
using Microsoft.AspNetCore.Mvc;

namespace Lab04_Ancco_Andre.Controller;

[ApiController]
[Route("api/[controller]")]
public class OrdenesController(
    GetAllOrdenesUseCase getAll,
    GetOrdenByIdUseCase getById,
    CreateOrdenUseCase create,
    UpdateOrdenUseCase update,
    DeleteOrdenUseCase delete) : ControllerBase
{
    [HttpGet]
    public IActionResult GetAll() => Ok(getAll.Execute());

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var resultado = getById.Execute(id);
        return resultado == null ? NotFound(new { mensaje = "Orden no encontrada" }) : Ok(resultado);
    }

    [HttpPost]
    public IActionResult Create(Ordene orden)
    {
        return Ok(create.Execute(orden));
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, Ordene orden)
    {
        if (!update.Execute(id, orden))
            return NotFound(new { mensaje = "Orden no encontrada" });

        return Ok(new { mensaje = "Orden actualizada correctamente" });
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        if (!delete.Execute(id))
            return NotFound(new { mensaje = "Orden no encontrada" });

        return Ok(new { mensaje = "Orden eliminada correctamente" });
    }
}

