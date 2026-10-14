using Lab04_Ancco_Andre.Models;
using Lab04_Ancco_Andre.Repositories;

namespace Lab04_Ancco_Andre.UseCases.Ordenes;

public class CreateOrdenUseCase(IUnitOfWork unitOfWork)
{
    public Ordene Execute(Ordene entity)
    {
        unitOfWork.Ordenes.Add(entity);
        unitOfWork.SaveChanges();
        return entity;
    }
}

