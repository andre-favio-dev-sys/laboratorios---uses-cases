using Lab04_Ancco_Andre.Models;
using Lab04_Ancco_Andre.Repositories;

namespace Lab04_Ancco_Andre.UseCases.Clientes;

public class GetAllClientesUseCase(IUnitOfWork unitOfWork)
{
    public IEnumerable<Cliente> Execute() => unitOfWork.Clientes.GetAll();
}

