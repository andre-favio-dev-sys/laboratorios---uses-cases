using Lab04_Ancco_Andre.Models;
using Lab04_Ancco_Andre.Repositories;

namespace Lab04_Ancco_Andre.UseCases.Categorias;

public class GetCategoriaByIdUseCase(IUnitOfWork unitOfWork)
{
    public Categoria? Execute(int id) => unitOfWork.Categorias.GetById(id);
}

