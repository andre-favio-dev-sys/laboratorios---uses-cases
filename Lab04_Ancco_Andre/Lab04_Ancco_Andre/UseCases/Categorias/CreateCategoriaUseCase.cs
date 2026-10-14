using Lab04_Ancco_Andre.Models;
using Lab04_Ancco_Andre.Repositories;

namespace Lab04_Ancco_Andre.UseCases.Categorias;

public class CreateCategoriaUseCase(IUnitOfWork unitOfWork)
{
    public Categoria Execute(Categoria entity)
    {
        unitOfWork.Categorias.Add(entity);
        unitOfWork.SaveChanges();
        return entity;
    }
}

