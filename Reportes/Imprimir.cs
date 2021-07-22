
using Modelo.Escuela;
using System;

namespace Reportes
{
    public class Publicar
    {
        // Publica en pantalla los prerequisitos de una materia
        public static void Prerequisitos(Materia materia)
        {
            Console.WriteLine(String.Format(
                    "\nReporte de Prerequisitos de: ({0}) {1}",
                    materia.MateriaId,
                    materia.Nombre
                    ));
            Console.WriteLine("Lista de Prerequisitos");
            Console.WriteLine("MallaId Materia");
            foreach (var prerequisito in materia.Malla.PreRequisitos)
            {
                Console.WriteLine(String.Format(
                    "{0}\t({1}) {2}",
                    prerequisito.MallaId,
                    prerequisito.MateriaId,
                    prerequisito.Materia.Nombre
                ));
            }
        }
        // Publica el record académico 
        public static void RecordAcademico(Estudiante estudiante)
        {
            // Barre las matrículas del estudiante
            Console.WriteLine("Reporte de Notas del Estudiante {0}", estudiante.Nombre);
            foreach (var matricula in estudiante.Matriculas)
            {
                Console.WriteLine("Matricula Id: {0} Período: {1:yyyy/dd/MM} - {2:yyyy/dd/MM}",
                    matricula.MatriculaId, matricula.Periodo.FechaInicio, matricula.Periodo.FechaFin);
                // Barre los detalles de cada matrícula
                foreach (var matrDet in matricula.Matricula_Dets)
                {
                    Console.WriteLine(" Det: {0} - Curso {1}", matrDet.Matricula_DetId, matrDet.Curso.Nombre);
                    if (matrDet.Calificacion != null)
                    {
                        Calificacion calif = matrDet.Calificacion;
                        Console.WriteLine(" Calif Id: {0}", matrDet.Calificacion.CalificacionId);
                        Console.WriteLine("    Nota 1   Nota 2   Nota3");
                        Console.WriteLine("    {0:#0.00}     {1:#0.00}     {2:#0.00}",
                            calif.Nota1, calif.Nota2, calif.Nota3
                        );
                    }
                }
            }
        }
    }
}
