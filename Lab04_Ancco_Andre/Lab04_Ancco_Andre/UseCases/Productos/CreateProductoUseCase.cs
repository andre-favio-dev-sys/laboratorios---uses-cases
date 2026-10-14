using Lab04_Ancco_Andre.Models;
using Lab04_Ancco_Andre.Repositories;

namespace Lab04_Ancco_Andre.UseCases.Productos;

public class CreateProductoUseCase(IUnitOfWork unitOfWork)
{
    public Producto Execute(Producto entity)
    {
        unitOfWork.Productos.Add(entity);
        unitOfWork.SaveChanges();
        return entity;
    }
}

