using Lab05_Ancco_Andre.Models;
using Lab05_Ancco_Andre.Repositories;

namespace Lab05_Ancco_Andre.UseCases.Estudiantes;

public class UpdateEstudianteUseCase(IUnitOfWork unitOfWork)
{
    public async Task<bool> ExecuteAsync(int id, Estudiante estudiante)
    {
        var repository = unitOfWork.Repository<Estudiante>();
        var actual = await repository.GetByIdAsync(id);

        if (actual == null)
            return false;

        actual.Nombre = estudiante.Nombre;
        actual.Edad = estudiante.Edad;
        actual.Direccion = estudiante.Direccion;
        actual.Telefono = estudiante.Telefono;
        actual.Correo = estudiante.Correo;

        repository.Update(actual);
        await unitOfWork.Complete();
        return true;
    }
}
