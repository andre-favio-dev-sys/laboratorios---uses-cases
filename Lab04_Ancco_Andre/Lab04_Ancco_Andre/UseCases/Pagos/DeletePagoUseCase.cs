using Lab04_Ancco_Andre.Models;
using Lab04_Ancco_Andre.Repositories;

namespace Lab04_Ancco_Andre.UseCases.Pagos;

public class DeletePagoUseCase(IUnitOfWork unitOfWork)
{
    public bool Execute(int id)
    {
        var entity = unitOfWork.Pagos.GetById(id);
        if (entity == null)
            return false;

        unitOfWork.Pagos.Delete(entity);
        unitOfWork.SaveChanges();
        return true;
    }
}

