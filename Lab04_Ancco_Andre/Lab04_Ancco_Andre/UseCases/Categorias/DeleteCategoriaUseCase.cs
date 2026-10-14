using Lab04_Ancco_Andre.Models;
using Lab04_Ancco_Andre.Repositories;

namespace Lab04_Ancco_Andre.UseCases.Categorias;

public class DeleteCategoriaUseCase(IUnitOfWork unitOfWork)
{
    public bool Execute(int id)
    {
        var entity = unitOfWork.Categorias.GetById(id);
        if (entity == null)
            return false;

        unitOfWork.Categorias.Delete(entity);
        unitOfWork.SaveChanges();
        return true;
    }
}

