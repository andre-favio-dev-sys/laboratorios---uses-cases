using Lab04_Ancco_Andre.Models;
using Lab04_Ancco_Andre.UseCases.Pagos;
using Microsoft.AspNetCore.Mvc;

namespace Lab04_Ancco_Andre.Controller;

[ApiController]
[Route("api/[controller]")]
public class PagosController(
    GetAllPagosUseCase getAll,
    GetPagoByIdUseCase getById,
    CreatePagoUseCase create,
    UpdatePagoUseCase update,
    DeletePagoUseCase delete) : ControllerBase
{
    [HttpGet]
    public IActionResult GetAll() => Ok(getAll.Execute());

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var resultado = getById.Execute(id);
        return resultado == null ? NotFound(new { mensaje = "Pago no encontrado" }) : Ok(resultado);
    }

    [HttpPost]
    public IActionResult Create(Pago pago)
    {
        return Ok(create.Execute(pago));
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, Pago pago)
    {
        if (!update.Execute(id, pago))
            return NotFound(new { mensaje = "Pago no encontrado" });

        return Ok(new { mensaje = "Pago actualizado correctamente" });
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        if (!delete.Execute(id))
            return NotFound(new { mensaje = "Pago no encontrado" });

        return Ok(new { mensaje = "Pago eliminado correctamente" });
    }
}

