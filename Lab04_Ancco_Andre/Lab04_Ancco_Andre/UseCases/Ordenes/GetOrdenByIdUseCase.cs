using Lab04_Ancco_Andre.Models;
using Lab04_Ancco_Andre.Repositories;

namespace Lab04_Ancco_Andre.UseCases.Ordenes;

public class GetOrdenByIdUseCase(IUnitOfWork unitOfWork)
{
    public Ordene? Execute(int id) => unitOfWork.Ordenes.GetById(id);
}

