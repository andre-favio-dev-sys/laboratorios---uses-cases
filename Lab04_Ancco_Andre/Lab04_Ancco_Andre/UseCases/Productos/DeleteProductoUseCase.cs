using Lab04_Ancco_Andre.Models;
using Lab04_Ancco_Andre.Repositories;

namespace Lab04_Ancco_Andre.UseCases.Productos;

public class DeleteProductoUseCase(IUnitOfWork unitOfWork)
{
    public bool Execute(int id)
    {
        var entity = unitOfWork.Productos.GetById(id);
        if (entity == null)
            return false;

        unitOfWork.Productos.Delete(entity);
        unitOfWork.SaveChanges();
        return true;
    }
}

