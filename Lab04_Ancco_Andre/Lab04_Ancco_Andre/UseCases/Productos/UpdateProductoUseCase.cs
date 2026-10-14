using Lab04_Ancco_Andre.Models;
using Lab04_Ancco_Andre.Repositories;

namespace Lab04_Ancco_Andre.UseCases.Productos;

public class UpdateProductoUseCase(IUnitOfWork unitOfWork)
{
    public bool Execute(int id, Producto entity)
    {
        var actual = unitOfWork.Productos.GetById(id);
        if (actual == null)
            return false;

        actual.Nombre = entity.Nombre;
        actual.Descripcion = entity.Descripcion;
        actual.Precio = entity.Precio;
        actual.Stock = entity.Stock;
        actual.Categoriaid = entity.Categoriaid;

        unitOfWork.Productos.Update(actual);
        unitOfWork.SaveChanges();
        return true;
    }
}

