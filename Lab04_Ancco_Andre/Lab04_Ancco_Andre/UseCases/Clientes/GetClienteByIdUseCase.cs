using Lab04_Ancco_Andre.Models;
using Lab04_Ancco_Andre.Repositories;

namespace Lab04_Ancco_Andre.UseCases.Clientes;

public class GetClienteByIdUseCase(IUnitOfWork unitOfWork)
{
    public Cliente? Execute(int id) => unitOfWork.Clientes.GetById(id);
}

