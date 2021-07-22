using Microsoft.EntityFrameworkCore;
using Modelo.Escuela;
using Persistencia;
using Procesos;
using System;
using System.Linq;

namespace Reportes
{
    public class Reporte
    {
        // Consulta de los prerequisitos de una materia
        public static Materia Prerequisitos(string MateriaNombre)
        {
            Materia materia = new Materia();
            using (var db = new EscuelaContext())
            {
                materia = db.materias
                    .Include(mat => mat.Malla)
                        .ThenInclude(malla => malla.PreRequisitos)
                            .ThenInclude(pre => pre.Materia)
                    .Where(mat => mat.Nombre == MateriaNombre)
                    .Single();
            }
            return materia;
        }

        // Reporte de calificaciones de un estudiante
        static public Estudiante CalificacionesPorEstudiante(string sEstNombre)
        {
            Estudiante estudiante;
            // Consulta las notas de un estudiante
            using (var context = new EscuelaContext())
            {
                estudiante = context.estudiantes
                    .Include(est => est.Matriculas)
                        .ThenInclude(matr => matr.Matricula_Dets)
                            .ThenInclude(det => det.Calificacion)
                    .Include(est => est.Matriculas)
                        .ThenInclude(matr => matr.Matricula_Dets)
                            .ThenInclude(det => det.Curso)
                    .Include(est => est.Matriculas)
                        .ThenInclude(matr => matr.Periodo)
                    .Single(est => est.Nombre.Equals(sEstNombre));
            }
            return estudiante;
        }

        // Reporte de calificaciones de un curso
        static public void CalificacionesPorCurso(string CursoNombre)
        {
            using (var context = new EscuelaContext())
            {
                Curso curso = context.cursos
                    .Include(cur => cur.Matricula_Dets)
                        .ThenInclude(det => det.Calificacion)
                    .Include(cur => cur.Matricula_Dets)
                        .ThenInclude(det => det.Matricula)
                            .ThenInclude(matr => matr.Estudiante)
                    .Single(cur => cur.Nombre == CursoNombre);

                Console.WriteLine("Curso Id: {0} - {1}",
                    curso.CursoId, curso.Nombre);
                foreach (var det in curso.Matricula_Dets)
                {
                    Console.WriteLine("  {0}", det.Matricula.Estudiante.Nombre);
                    if (det.Calificacion != null)
                    {
                        CalificacionProc opCalif = new CalificacionProc(context);
                        Console.WriteLine("    Nota 1   Nota 2   Nota 3   Nota Final");
                        Console.WriteLine("    {0:#0.00}     {1:#0.00}     {2:#0.00}     {3:#0.00}   -->{4}",
                            det.Calificacion.Nota1, det.Calificacion.Nota2, det.Calificacion.Nota3,
                            opCalif.NotaFinal(det.Calificacion), opCalif.Aprobado(det.Calificacion));
                    }
                    else
                    {
                        Console.WriteLine("    Sin Calificaciones");
                    }
                }
            }

        }

        // Reporte explicativo de la validación de la matrícula
        static public bool ReporteValidarMatricula(int matriculaId)
        {
            using (var context = new EscuelaContext())
            {
                Matricula matricula = context.matriculas
                    .Include(matr => matr.Estudiante)
                    .Include(matr => matr.Matricula_Dets)
                        .ThenInclude(det => det.Curso)
                            .ThenInclude(cur => cur.Materia)
                                .ThenInclude(mat => mat.Prerequisitos)
                                    .ThenInclude(pre => pre.Malla)
                                        .ThenInclude(malla => malla.Materia)
                    .Single(matr => matr.MatriculaId == matriculaId);
                Console.WriteLine(" ");
                Console.WriteLine("Análisis de la matrícula {0} de {1}",
                    matricula.MatriculaId, matricula.Estudiante.Nombre);
                int estudianteId = matricula.EstudianteId;
                // Verifica de cada materia los pre-requisitos
                bool aprobado = true;
                foreach (var matrDet in matricula.Matricula_Dets)
                {
                    Console.WriteLine("    .");
                    Console.WriteLine("   [ ] Curso: {0}", matrDet.Curso.Nombre);
                    Materia materia = matrDet.Curso.Materia;
                    // 1.- Materia no tiene pre-requisitos
                    if (materia.Prerequisitos is null)
                    {
                        Console.WriteLine("    La materia " + materia.Nombre + " no tiene pre-requisitos");
                        break;
                    }
                    else // 2.- Materia si tiene pre-requisitos
                    {
                        // Reviso los pre-requisitos
                        Console.WriteLine("   --------------------------------------------");
                        Console.WriteLine("   La materia {0} tiene {1} prerequisitos",
                            materia.Nombre, materia.Prerequisitos.Count);
                        foreach (var pre in materia.Prerequisitos)
                        {
                            if (MatriculaProc.MateriaAprobada(estudianteId, pre.Malla.MateriaId))
                            {
                                Console.WriteLine("   - Pre Id {0}: {1} -> Aprobado", pre.Malla.MateriaId, pre.Malla.Materia.Nombre);
                            }
                            else
                            {
                                Console.WriteLine("   - Pre Id {0}: {1} -> Reprobado (*)", pre.Malla.MateriaId, pre.Malla.Materia.Nombre);
                                aprobado = false;
                            }
                        }
                    }
                }
                Console.WriteLine("   --------------------------------------------");
                Console.WriteLine("   RESULTADO: La matrícula es {0}", aprobado ? "APROBADA" : "RECHAZADA");
                return aprobado;
            }
        }
    }
}
