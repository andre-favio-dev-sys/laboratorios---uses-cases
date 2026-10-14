using Lab04_Ancco_Andre.Models;
using Lab04_Ancco_Andre.UseCases.Categorias;
using Microsoft.AspNetCore.Mvc;

namespace Lab04_Ancco_Andre.Controller;

[ApiController]
[Route("api/[controller]")]
public class CategoriasController(
    GetAllCategoriasUseCase getAll,
    GetCategoriaByIdUseCase getById,
    CreateCategoriaUseCase create,
    UpdateCategoriaUseCase update,
    DeleteCategoriaUseCase delete) : ControllerBase
{
    [HttpGet]
    public IActionResult GetAll() => Ok(getAll.Execute());

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var resultado = getById.Execute(id);
        return resultado == null ? NotFound() : Ok(resultado);
    }

    [HttpPost]
    public IActionResult Create(Categoria categoria)
    {
        return Ok(create.Execute(categoria));
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, Categoria categoria)
    {
        if (!update.Execute(id, categoria))
            return NotFound();

        return Ok(new { mensaje = "Categoría actualizada correctamente" });
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        if (!delete.Execute(id))
            return NotFound();

        return Ok(new { mensaje = "Categoría eliminada correctamente" });
    }
}

