using Lab05_Ancco_Andre.Models;
using Lab05_Ancco_Andre.UseCases.Matriculas;
using Microsoft.AspNetCore.Mvc;

namespace Lab05_Ancco_Andre.Controller;

[ApiController]
[Route("api/[controller]")]
public class MatriculaController(
    GetAllMatriculasUseCase getAll,
    GetMatriculaByIdUseCase getById,
    CreateMatriculaUseCase create,
    UpdateMatriculaUseCase update,
    DeleteMatriculaUseCase delete,
    GetDetalleCursoUseCase getDetalleCurso) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAll() => Ok(await getAll.ExecuteAsync());

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var matricula = await getById.ExecuteAsync(id);
        return matricula == null ? NotFound() : Ok(matricula);
    }

    [HttpPost]
    public async Task<IActionResult> Create(Matricula matricula) =>
        Ok(await create.ExecuteAsync(matricula));

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, Matricula matricula) =>
        await update.ExecuteAsync(id, matricula) ? NoContent() : NotFound();

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id) =>
        await delete.ExecuteAsync(id) ? NoContent() : NotFound();

    [HttpGet("curso/{idCurso}/detalle")]
    public async Task<IActionResult> GetDetalleCurso(int idCurso)
    {
        var detalle = await getDetalleCurso.ExecuteAsync(idCurso);
        return detalle == null ? NotFound() : Ok(detalle);
    }
}
