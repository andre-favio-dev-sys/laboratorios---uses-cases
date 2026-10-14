using Lab04_Ancco_Andre.Models;
using Lab04_Ancco_Andre.Repositories;

namespace Lab04_Ancco_Andre.UseCases.Clientes;

public class CreateClienteUseCase(IUnitOfWork unitOfWork)
{
    public Cliente Execute(Cliente entity)
    {
        unitOfWork.Clientes.Add(entity);
        unitOfWork.SaveChanges();
        return entity;
    }
}

