using Lab05_Ancco_Andre.Models;
using Lab05_Ancco_Andre.Repositories;

namespace Lab05_Ancco_Andre.UseCases.Estudiantes;

public class GetEstudianteByIdUseCase(IUnitOfWork unitOfWork)
{
    public Task<Estudiante?> ExecuteAsync(int id)
    {
        return unitOfWork.Repository<Estudiante>().GetByIdAsync(id);
    }
}
