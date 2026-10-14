using Lab04_Ancco_Andre.Models;
using Lab04_Ancco_Andre.Repositories;

namespace Lab04_Ancco_Andre.UseCases.Clientes;

public class DeleteClienteUseCase(IUnitOfWork unitOfWork)
{
    public bool Execute(int id)
    {
        var entity = unitOfWork.Clientes.GetById(id);
        if (entity == null)
            return false;

        unitOfWork.Clientes.Delete(entity);
        unitOfWork.SaveChanges();
        return true;
    }
}

