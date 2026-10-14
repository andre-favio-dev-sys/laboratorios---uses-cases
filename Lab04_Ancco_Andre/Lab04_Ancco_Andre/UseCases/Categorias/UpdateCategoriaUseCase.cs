using Lab04_Ancco_Andre.Models;
using Lab04_Ancco_Andre.Repositories;

namespace Lab04_Ancco_Andre.UseCases.Categorias;

public class UpdateCategoriaUseCase(IUnitOfWork unitOfWork)
{
    public bool Execute(int id, Categoria entity)
    {
        var actual = unitOfWork.Categorias.GetById(id);
        if (actual == null)
            return false;

        actual.Nombre = entity.Nombre;

        unitOfWork.Categorias.Update(actual);
        unitOfWork.SaveChanges();
        return true;
    }
}

