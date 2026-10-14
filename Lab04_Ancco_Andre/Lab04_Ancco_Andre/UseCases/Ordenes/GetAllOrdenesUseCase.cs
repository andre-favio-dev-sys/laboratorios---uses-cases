using Lab04_Ancco_Andre.Models;
using Lab04_Ancco_Andre.Repositories;

namespace Lab04_Ancco_Andre.UseCases.Ordenes;

public class GetAllOrdenesUseCase(IUnitOfWork unitOfWork)
{
    public IEnumerable<Ordene> Execute() => unitOfWork.Ordenes.GetAll();
}

