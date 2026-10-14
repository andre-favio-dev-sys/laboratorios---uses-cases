using Lab04_Ancco_Andre.Models;
using Lab04_Ancco_Andre.Repositories;

namespace Lab04_Ancco_Andre.UseCases.Pagos;

public class GetAllPagosUseCase(IUnitOfWork unitOfWork)
{
    public IEnumerable<Pago> Execute() => unitOfWork.Pagos.GetAll();
}

