using Lab04_Ancco_Andre.Models;
using Lab04_Ancco_Andre.Repositories;

namespace Lab04_Ancco_Andre.UseCases.DetallesOrden;

public class CreateDetalleOrdenUseCase(IUnitOfWork unitOfWork)
{
    public Detallesorden Execute(Detallesorden entity)
    {
        unitOfWork.DetallesOrden.Add(entity);
        unitOfWork.SaveChanges();
        return entity;
    }
}

