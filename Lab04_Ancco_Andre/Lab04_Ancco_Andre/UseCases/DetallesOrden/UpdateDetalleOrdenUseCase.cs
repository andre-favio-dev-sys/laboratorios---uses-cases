using Lab04_Ancco_Andre.Models;
using Lab04_Ancco_Andre.Repositories;

namespace Lab04_Ancco_Andre.UseCases.DetallesOrden;

public class UpdateDetalleOrdenUseCase(IUnitOfWork unitOfWork)
{
    public bool Execute(int id, Detallesorden entity)
    {
        var actual = unitOfWork.DetallesOrden.GetById(id);
        if (actual == null)
            return false;

        actual.Ordenid = entity.Ordenid;
        actual.Productoid = entity.Productoid;
        actual.Cantidad = entity.Cantidad;
        actual.Precio = entity.Precio;

        unitOfWork.DetallesOrden.Update(actual);
        unitOfWork.SaveChanges();
        return true;
    }
}

