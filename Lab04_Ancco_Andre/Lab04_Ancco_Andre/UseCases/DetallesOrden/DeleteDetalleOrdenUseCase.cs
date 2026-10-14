using Lab04_Ancco_Andre.Models;
using Lab04_Ancco_Andre.Repositories;

namespace Lab04_Ancco_Andre.UseCases.DetallesOrden;

public class DeleteDetalleOrdenUseCase(IUnitOfWork unitOfWork)
{
    public bool Execute(int id)
    {
        var entity = unitOfWork.DetallesOrden.GetById(id);
        if (entity == null)
            return false;

        unitOfWork.DetallesOrden.Delete(entity);
        unitOfWork.SaveChanges();
        return true;
    }
}

