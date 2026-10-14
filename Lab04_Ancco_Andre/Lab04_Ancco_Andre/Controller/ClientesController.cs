using Lab04_Ancco_Andre.Models;
using Lab04_Ancco_Andre.UseCases.Clientes;
using Microsoft.AspNetCore.Mvc;

namespace Lab04_Ancco_Andre.Controller;

[ApiController]
[Route("api/[controller]")]
public class ClientesController(
    GetAllClientesUseCase getAll,
    GetClienteByIdUseCase getById,
    CreateClienteUseCase create,
    UpdateClienteUseCase update,
    DeleteClienteUseCase delete) : ControllerBase
{
    [HttpGet]
    public IActionResult GetAll() => Ok(getAll.Execute());

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var resultado = getById.Execute(id);
        return resultado == null ? NotFound(new { mensaje = "Cliente no encontrado" }) : Ok(resultado);
    }

    [HttpPost]
    public IActionResult Create(Cliente cliente)
    {
        var creado = create.Execute(cliente);
        return CreatedAtAction(nameof(GetById), new { id = creado.Clienteid }, creado);
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, Cliente cliente)
    {
        if (!update.Execute(id, cliente))
            return NotFound(new { mensaje = "Cliente no encontrado" });

        return Ok(new { mensaje = "Cliente actualizado correctamente" });
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        if (!delete.Execute(id))
            return NotFound(new { mensaje = "Cliente no encontrado" });

        return Ok(new { mensaje = "Cliente eliminado correctamente" });
    }
}

