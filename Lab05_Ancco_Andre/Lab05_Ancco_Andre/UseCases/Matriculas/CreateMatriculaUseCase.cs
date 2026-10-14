using Lab05_Ancco_Andre.Models;
using Lab05_Ancco_Andre.Repositories;

namespace Lab05_Ancco_Andre.UseCases.Matriculas;

public class CreateMatriculaUseCase(IUnitOfWork unitOfWork)
{
    public async Task<Matricula> ExecuteAsync(Matricula matricula)
    {
        await unitOfWork.Repository<Matricula>().InsertAsync(matricula);
        await unitOfWork.Complete();
        return matricula;
    }
}
