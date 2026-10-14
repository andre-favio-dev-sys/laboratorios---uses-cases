using Lab04_Ancco_Andre.Models;
using Lab04_Ancco_Andre.Repositories;

namespace Lab04_Ancco_Andre.UseCases.DetallesOrden;

public class GetAllDetallesOrdenUseCase(IUnitOfWork unitOfWork)
{
    public IEnumerable<Detallesorden> Execute() => unitOfWork.DetallesOrden.GetAll();
}

