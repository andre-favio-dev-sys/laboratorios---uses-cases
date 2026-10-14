using Lab05_Ancco_Andre.Models;
using Lab05_Ancco_Andre.Repositories;

namespace Lab05_Ancco_Andre.UseCases.Estudiantes;

public class GetAllEstudiantesUseCase(IUnitOfWork unitOfWork)
{
    public Task<IEnumerable<Estudiante>> ExecuteAsync()
    {
        return unitOfWork.Repository<Estudiante>().GetAllAsync();
    }
}
