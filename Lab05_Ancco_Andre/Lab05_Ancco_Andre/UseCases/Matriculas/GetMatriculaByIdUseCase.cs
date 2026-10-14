using Lab05_Ancco_Andre.Models;
using Lab05_Ancco_Andre.Repositories;

namespace Lab05_Ancco_Andre.UseCases.Matriculas;

public class GetMatriculaByIdUseCase(IUnitOfWork unitOfWork)
{
    public Task<Matricula?> ExecuteAsync(int id)
    {
        return unitOfWork.Repository<Matricula>().GetByIdAsync(id);
    }
}
