using Lab05_Ancco_Andre.Models;
using Lab05_Ancco_Andre.UseCases.Estudiantes;
using Microsoft.AspNetCore.Mvc;

namespace Lab05_Ancco_Andre.Controller;

[ApiController]
[Route("api/[controller]")]
public class EstudianteController(
    GetAllEstudiantesUseCase getAll,
    GetEstudianteByIdUseCase getById,
    CreateEstudianteUseCase create,
    UpdateEstudianteUseCase update,
    DeleteEstudianteUseCase delete) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAll() => Ok(await getAll.ExecuteAsync());

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var estudiante = await getById.ExecuteAsync(id);
        return estudiante == null ? NotFound() : Ok(estudiante);
    }

    [HttpPost]
    public async Task<IActionResult> Create(Estudiante estudiante) =>
        Ok(await create.ExecuteAsync(estudiante));

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, Estudiante estudiante) =>
        await update.ExecuteAsync(id, estudiante) ? NoContent() : NotFound();

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id) =>
        await delete.ExecuteAsync(id) ? NoContent() : NotFound();
}
