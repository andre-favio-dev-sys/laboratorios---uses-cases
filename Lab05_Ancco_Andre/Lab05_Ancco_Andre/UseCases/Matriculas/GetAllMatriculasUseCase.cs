using Lab05_Ancco_Andre.Models;
using Lab05_Ancco_Andre.Repositories;

namespace Lab05_Ancco_Andre.UseCases.Matriculas;

public class GetAllMatriculasUseCase(IUnitOfWork unitOfWork)
{
    public Task<IEnumerable<Matricula>> ExecuteAsync()
    {
        return unitOfWork.Repository<Matricula>().GetAllAsync();
    }
}
