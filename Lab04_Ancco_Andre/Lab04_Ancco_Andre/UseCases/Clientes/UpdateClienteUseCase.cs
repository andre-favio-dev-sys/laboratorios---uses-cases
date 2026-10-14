using Lab04_Ancco_Andre.Models;
using Lab04_Ancco_Andre.Repositories;

namespace Lab04_Ancco_Andre.UseCases.Clientes;

public class UpdateClienteUseCase(IUnitOfWork unitOfWork)
{
    public bool Execute(int id, Cliente entity)
    {
        var actual = unitOfWork.Clientes.GetById(id);
        if (actual == null)
            return false;

        actual.Nombre = entity.Nombre;
        actual.Correo = entity.Correo;

        unitOfWork.Clientes.Update(actual);
        unitOfWork.SaveChanges();
        return true;
    }
}

