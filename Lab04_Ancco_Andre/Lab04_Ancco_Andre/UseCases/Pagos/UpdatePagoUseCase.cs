using Lab04_Ancco_Andre.Models;
using Lab04_Ancco_Andre.Repositories;

namespace Lab04_Ancco_Andre.UseCases.Pagos;

public class UpdatePagoUseCase(IUnitOfWork unitOfWork)
{
    public bool Execute(int id, Pago entity)
    {
        var actual = unitOfWork.Pagos.GetById(id);
        if (actual == null)
            return false;

        actual.Ordenid = entity.Ordenid;
        actual.Monto = entity.Monto;
        actual.Fechapago = entity.Fechapago;
        actual.Metodopago = entity.Metodopago;

        unitOfWork.Pagos.Update(actual);
        unitOfWork.SaveChanges();
        return true;
    }
}

