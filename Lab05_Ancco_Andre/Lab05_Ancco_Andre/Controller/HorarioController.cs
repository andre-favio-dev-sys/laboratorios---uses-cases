using Lab05_Ancco_Andre.Models;
using Lab05_Ancco_Andre.UseCases.Horarios;
using Microsoft.AspNetCore.Mvc;

namespace Lab05_Ancco_Andre.Controller;

[ApiController]
[Route("api/[controller]")]
public class HorarioController(
    GetAllHorariosUseCase getAll,
    GetHorarioByIdUseCase getById,
    CreateHorarioUseCase create,
    UpdateHorarioUseCase update,
    DeleteHorarioUseCase delete) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAll() => Ok(await getAll.ExecuteAsync());

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var horario = await getById.ExecuteAsync(id);
        return horario == null ? NotFound() : Ok(horario);
    }

    [HttpPost]
    public async Task<IActionResult> Create(Horario horario) =>
        Ok(await create.ExecuteAsync(horario));

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, Horario horario) =>
        await update.ExecuteAsync(id, horario) ? NoContent() : NotFound();

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id) =>
        await delete.ExecuteAsync(id) ? NoContent() : NotFound();
}
