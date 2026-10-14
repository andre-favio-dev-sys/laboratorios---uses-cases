using Lab04_Ancco_Andre.Models;
using Lab04_Ancco_Andre.Repositories;

namespace Lab04_Ancco_Andre.UseCases.Categorias;

public class GetAllCategoriasUseCase(IUnitOfWork unitOfWork)
{
    public IEnumerable<Categoria> Execute() => unitOfWork.Categorias.GetAll();
}

