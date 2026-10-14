using Lab04_Ancco_Andre.Models;
using Lab04_Ancco_Andre.Repositories;

namespace Lab04_Ancco_Andre.UseCases.Ordenes;

public class UpdateOrdenUseCase(IUnitOfWork unitOfWork)
{
    public bool Execute(int id, Ordene entity)
    {
        var actual = unitOfWork.Ordenes.GetById(id);
        if (actual == null)
            return false;

        actual.Clienteid = entity.Clienteid;
        actual.Fechaorden = entity.Fechaorden;
        actual.Total = entity.Total;

        unitOfWork.Ordenes.Update(actual);
        unitOfWork.SaveChanges();
        return true;
    }
}

