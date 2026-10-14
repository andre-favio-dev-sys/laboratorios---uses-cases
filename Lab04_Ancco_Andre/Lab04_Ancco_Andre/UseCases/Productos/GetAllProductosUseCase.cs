using Lab04_Ancco_Andre.Models;
using Lab04_Ancco_Andre.Repositories;

namespace Lab04_Ancco_Andre.UseCases.Productos;

public class GetAllProductosUseCase(IUnitOfWork unitOfWork)
{
    public IEnumerable<Producto> Execute() => unitOfWork.Productos.GetAll();
}

