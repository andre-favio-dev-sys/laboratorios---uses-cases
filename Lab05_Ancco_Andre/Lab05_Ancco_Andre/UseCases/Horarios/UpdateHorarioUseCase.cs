using Lab05_Ancco_Andre.Models;
using Lab05_Ancco_Andre.Repositories;

namespace Lab05_Ancco_Andre.UseCases.Horarios;

public class UpdateHorarioUseCase(IUnitOfWork unitOfWork)
{
    public async Task<bool> ExecuteAsync(int id, Horario horario)
    {
        var repository = unitOfWork.Repository<Horario>();
        var actual = await repository.GetByIdAsync(id);

        if (actual == null)
            return false;

        actual.Dia = horario.Dia;
        actual.HoraInicio = horario.HoraInicio;
        actual.HoraFin = horario.HoraFin;

        repository.Update(actual);
        await unitOfWork.Complete();
        return true;
    }
}
