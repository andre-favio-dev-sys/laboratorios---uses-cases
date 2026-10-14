using Lab05_Ancco_Andre.Models;
using Lab05_Ancco_Andre.Repositories;

namespace Lab05_Ancco_Andre.UseCases.Matriculas;

public class GetDetalleCursoUseCase(IUnitOfWork unitOfWork)
{
    public async Task<object?> ExecuteAsync(int idCurso)
    {
        var curso = await unitOfWork.Repository<Curso>().GetByIdAsync(idCurso);

        if (curso == null)
            return null;

        var matriculas = await unitOfWork.Repository<Matricula>().GetAllAsync();
        var estudiantes = await unitOfWork.Repository<Estudiante>().GetAllAsync();
        var profesores = await unitOfWork.Repository<Profesore>().GetAllAsync();

        var profesor = profesores.FirstOrDefault(p =>
            p.IdProfesor == curso.IdProfesor);

        var estudiantesDelCurso = matriculas
            .Where(m => m.IdCurso == idCurso)
            .Join(
                estudiantes,
                matricula => matricula.IdEstudiante,
                estudiante => estudiante.IdEstudiante,
                (matricula, estudiante) => new
                {
                    estudiante.IdEstudiante,
                    estudiante.Nombre,
                    matricula.Semestre
                })
            .ToList();

        return new
        {
            curso.IdCurso,
            Curso = curso.Nombre,
            Docente = profesor?.Nombre,
            Estudiantes = estudiantesDelCurso
        };
    }
}
