using Lab04_Ancco_Andre.Models;
using Lab04_Ancco_Andre.Repositories;

namespace Lab04_Ancco_Andre.UseCases.DetallesOrden;

public class GetDetalleOrdenByIdUseCase(IUnitOfWork unitOfWork)
{
    public Detallesorden? Execute(int id) => unitOfWork.DetallesOrden.GetById(id);
}

