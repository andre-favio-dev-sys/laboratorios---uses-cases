using Lab04_Ancco_Andre.Models;
using Lab04_Ancco_Andre.UseCases.DetallesOrden;
using Microsoft.AspNetCore.Mvc;

namespace Lab04_Ancco_Andre.Controller;

[ApiController]
[Route("api/[controller]")]
public class DetallesOrdenController(
    GetAllDetallesOrdenUseCase getAll,
    GetDetalleOrdenByIdUseCase getById,
    CreateDetalleOrdenUseCase create,
    UpdateDetalleOrdenUseCase update,
    DeleteDetalleOrdenUseCase delete) : ControllerBase
{
    [HttpGet]
    public IActionResult GetAll() => Ok(getAll.Execute());

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var resultado = getById.Execute(id);
        return resultado == null ? NotFound(new { mensaje = "Detalle de orden no encontrado" }) : Ok(resultado);
    }

    [HttpPost]
    public IActionResult Create(Detallesorden detalle)
    {
        return Ok(create.Execute(detalle));
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, Detallesorden detalle)
    {
        if (!update.Execute(id, detalle))
            return NotFound(new { mensaje = "Detalle de orden no encontrado" });

        return Ok(new { mensaje = "Detalle de orden actualizado correctamente" });
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        if (!delete.Execute(id))
            return NotFound(new { mensaje = "Detalle de orden no encontrado" });

        return Ok(new { mensaje = "Detalle de orden eliminado correctamente" });
    }
}

