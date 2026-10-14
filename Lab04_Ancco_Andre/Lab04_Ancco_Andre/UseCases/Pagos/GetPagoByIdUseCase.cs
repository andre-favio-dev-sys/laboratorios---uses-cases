using Lab04_Ancco_Andre.Models;
using Lab04_Ancco_Andre.Repositories;

namespace Lab04_Ancco_Andre.UseCases.Pagos;

public class GetPagoByIdUseCase(IUnitOfWork unitOfWork)
{
    public Pago? Execute(int id) => unitOfWork.Pagos.GetById(id);
}

