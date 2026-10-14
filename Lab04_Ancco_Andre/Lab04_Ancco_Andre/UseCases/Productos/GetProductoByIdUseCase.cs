using Lab04_Ancco_Andre.Models;
using Lab04_Ancco_Andre.Repositories;

namespace Lab04_Ancco_Andre.UseCases.Productos;

public class GetProductoByIdUseCase(IUnitOfWork unitOfWork)
{
    public Producto? Execute(int id) => unitOfWork.Productos.GetById(id);
}

