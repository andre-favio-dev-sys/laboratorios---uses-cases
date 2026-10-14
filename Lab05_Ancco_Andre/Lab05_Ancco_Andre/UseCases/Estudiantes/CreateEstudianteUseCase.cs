using Lab05_Ancco_Andre.Models;
using Lab05_Ancco_Andre.Repositories;

namespace Lab05_Ancco_Andre.UseCases.Estudiantes;

public class CreateEstudianteUseCase(IUnitOfWork unitOfWork)
{
    public async Task<Estudiante> ExecuteAsync(Estudiante estudiante)
    {
        await unitOfWork.Repository<Estudiante>().InsertAsync(estudiante);
        await unitOfWork.Complete();
        return estudiante;
    }
}
