using Lab04_Ancco_Andre.Models;
using Lab04_Ancco_Andre.Repositories;

namespace Lab04_Ancco_Andre.UseCases.Ordenes;

public class DeleteOrdenUseCase(IUnitOfWork unitOfWork)
{
    public bool Execute(int id)
    {
        var entity = unitOfWork.Ordenes.GetById(id);
        if (entity == null)
            return false;

        unitOfWork.Ordenes.Delete(entity);
        unitOfWork.SaveChanges();
        return true;
    }
}

