using Persistencia;
using System.Linq;
using System;
using Modelo.Escuela;
using Escenarios;
using Reportes;
using Procesos;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Simulacion
{
    class Program
    {
        static void Main(string[] args)
        {
            // Código para crear el escenario 1
            Escenario01 escenario = new Escenario01();
            EscenarioControl control = new EscenarioControl();
            control.Grabar(escenario);
            // Estudiante y carrera
            string estNombre = "Pedro Infante";
            string carNombre = "Comercio Electrónico";
            // Matrícula de segundo nivel
            Matricula matrPedroNivel2;
            DateTime dt2020_PAO2 = new DateTime(2020, 9, 1);
            string[] Nivel2cursos = new string[] {
                "Nivel 2 Diurna de Diseño Web",
                "Nivel 2 Diurno de Administración BBDD" };
            // Notas de segundo Nivel
            Dictionary<string, Calificacion> dicPedroCursosCalifsNivel2 = new()
            {
                {
                    Nivel2cursos[0],
                    new Calificacion() { Nota1 = 5.55f, Nota2 = 4.34f, Nota3 = 5.74f }
                },
                {
                    Nivel2cursos[1],
                    new Calificacion() { Nota1 = 8.78f, Nota2 = 7.12f, Nota3 = 6.25f }
                }
            };
            // Persistencia
            using (var db = new EscuelaContext())
            {
                matrPedroNivel2 = MatriculaProc.CreaMatricula(db, estNombre, carNombre, dt2020_PAO2, Nivel2cursos);
                MatriculaProc.RegistrarNotas(matrPedroNivel2, dicPedroCursosCalifsNivel2);
                db.matriculas.Add(matrPedroNivel2);
                db.SaveChanges();
            }
            //----------------------------------------------------------------------------------------------
            // Matrícula de tercer nivel
            Matricula matrPedroNivel3;
            DateTime dt2021_PAO1 = new DateTime(2021, 4, 1);
            string[] Nivel3cursos = new string[] {
                "Nivel 3 Diurno de Lógica de Programación",
                "Nivel 3 Diurno de Productos Digitales",
                "Nivel 3 Diurno de Video Marketing" };
            // Notas de tercer Nivel
            Dictionary<string, Calificacion> dicPedroCursosCalifsNivel3 = new()
            {
                {
                    Nivel3cursos[0],
                    new Calificacion() { Nota1 = 6.65f, Nota2 = 8.94f, Nota3 = 9.74f }
                },
                {
                    Nivel3cursos[1],
                    new Calificacion() { Nota1 = 7.84f, Nota2 = 9.12f, Nota3 = 8.50f }
                },
                {
                    Nivel3cursos[2],
                    new Calificacion() { Nota1 = 4.84f, Nota2 = 5.12f, Nota3 = 8.50f }
                }
            };
            // Persistencia
            using (var db = new EscuelaContext())
            {
                matrPedroNivel3 = MatriculaProc.CreaMatricula(db, estNombre, carNombre, dt2021_PAO1, Nivel3cursos);
                MatriculaProc.RegistrarNotas(matrPedroNivel3, dicPedroCursosCalifsNivel3);
                db.matriculas.Add(matrPedroNivel3);
                db.SaveChanges();
            }
            //----------------------------------------------------------------------------------------------
            //Reporte
            Publicar.RecordAcademico(Reporte.CalificacionesPorEstudiante(estNombre));
        }
        //Regla de negocio
        public void EstadoMatricula()
        {   //listamos las patriculas pendientes
            using (var db = new EscuelaContext())
            {
                var listaMatriculas = db.matriculas
                    .Include(matr=>matr.Estudiante)
                    .Include(matr=>matr.Matricula_Dets)
                        .ThenInclude(det=>det.Curso)
                            .ThenInclude(cur=>cur.Materia)
                                .ThenInclude(mat=>mat.Malla)
                                    .ThenInclude(mall=>mall.PreRequisitos)
                                        .ThenInclude(pre=>pre.Materia)
                    .Where(matr => matr.Estado == "Pendiente").ToList();
                //Revisamos las matriculas
                foreach (var matricula in listaMatriculas)
                {
                    Console.WriteLine("MatriculaID: "+matricula.MatriculaId);
                    foreach (var det in matricula.Matricula_Dets)                        
                    {
                        Console.WriteLine("\tCurso: "+det.Curso.Nombre);
                        Console.WriteLine("\t     Materia: " + det.Curso.Materia.Nombre);
                        Console.WriteLine("\t     Lista de prerequisitos: ");
                        foreach (var pre in det.Curso.Materia.Malla.PreRequisitos)
                        {
                            Console.WriteLine("\t       " + pre.Materia.Nombre);

                        }

                    }
                }

            }
        }
        private static bool MateriaAprobada(Estudiante estudiante, Materia materia, Configuracion configuracion)
        {
            bool aprobado = true;
            //pesos de las notas
            var peso1 = configuracion.PesoNota1;
            var peso2 = configuracion.PesoNota2;
            var peso3 = configuracion.PesoNota3;
            //consultar las matriculas del estudiante
            using (var db = new EscuelaContext())
            {
                var listaMatriculas = db.matriculas
                    .Include(matr => matr.Matricula_Dets)
                        .ThenInclude(det=>det.Calificacion)
                    .Include(matr=>matr.Matricula_Dets.Where(det=>det.Curso.MateriaId==materia.MateriaId))
                        .ThenInclude(det=>det.Curso)
                            .ThenInclude(cur=>cur.Materia)
                    .Where(matri => 
                    matri.EstudianteId == estudiante.EstudianteId &&
                    matri.Estado == "Aprobada").ToList();
                //debbuger
                Console.WriteLine("---------------------------------------------");
                Console.WriteLine(" "+estudiante.Nombre+ " "+materia.Nombre);
                foreach (var matricula in listaMatriculas)
                {
                    Console.WriteLine("\tMatricula ID: "+matricula.MatriculaId);
                    var cont = 0;
                    foreach (var det in matricula.Matricula_Dets)
                    {
                        var materiaReq = det.Curso.Materia;
                        Console.WriteLine("\t " + matricula.MatriculaId);
                        Console.WriteLine(det.Calificacion.Nota1);
                        Console.WriteLine(det.Calificacion.Nota2);
                        Console.WriteLine(det.Calificacion.Nota3);
                        Console.WriteLine(det.Calificacion.Aprueba(peso1,peso2,peso3,configuracion.NotaMinima));
                        return det.Calificacion.Aprueba(peso1, peso2, peso3, configuracion.NotaMinima);
                        cont++;
                    }
                    if (cont == 0) 
                    { 
                        return false;
                    }
                    else 
                    { 
                        return false;
                    }
                }
            }
                return aprobado;
        }

        
    }
}
