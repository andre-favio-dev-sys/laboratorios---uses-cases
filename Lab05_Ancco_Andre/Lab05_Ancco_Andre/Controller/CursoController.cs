using Lab05_Ancco_Andre.Models;
using Lab05_Ancco_Andre.UseCases.Cursos;
using Microsoft.AspNetCore.Mvc;

namespace Lab05_Ancco_Andre.Controller;

[ApiController]
[Route("api/[controller]")]
public class CursoController(
    GetAllCursosUseCase getAll,
    GetCursoByIdUseCase getById,
    CreateCursoUseCase create,
    UpdateCursoUseCase update,
    DeleteCursoUseCase delete) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAll() => Ok(await getAll.ExecuteAsync());

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var curso = await getById.ExecuteAsync(id);
        return curso == null ? NotFound() : Ok(curso);
    }

    [HttpPost]
    public async Task<IActionResult> Create(Curso curso) =>
        Ok(await create.ExecuteAsync(curso));

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, Curso curso) =>
        await update.ExecuteAsync(id, curso) ? NoContent() : NotFound();

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id) =>
        await delete.ExecuteAsync(id) ? NoContent() : NotFound();
}
