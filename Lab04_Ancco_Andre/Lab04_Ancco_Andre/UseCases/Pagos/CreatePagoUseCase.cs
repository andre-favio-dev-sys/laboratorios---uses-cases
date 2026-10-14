using Lab04_Ancco_Andre.Models;
using Lab04_Ancco_Andre.Repositories;

namespace Lab04_Ancco_Andre.UseCases.Pagos;

public class CreatePagoUseCase(IUnitOfWork unitOfWork)
{
    public Pago Execute(Pago entity)
    {
        unitOfWork.Pagos.Add(entity);
        unitOfWork.SaveChanges();
        return entity;
    }
}

