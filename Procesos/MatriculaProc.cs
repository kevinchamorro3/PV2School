using Microsoft.EntityFrameworkCore;
using Modelo.Escuela;
using Persistencia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Procesos
{
    public class MatriculaProc
    {
        public EscuelaContext _context;

        public MatriculaProc(EscuelaContext context)
        {
            _context = context;
        }

        // Registro de una matrícula
        static public Matricula CreaMatricula(
            EscuelaContext context, string estNombre, string carNombre, DateTime periodoFechaInicio, string[] cursosNombres)
        {
            // 1.- Consulta del estudiante
            Estudiante estudiante = context.estudiantes
                .Single(est => est.Nombre == estNombre);
            // 2.- Consulta de la carrera
            Carrera carrera = context.carreras
                .Single(car => car.Nombre == carNombre);
            // 3.- Consulta del período
            Periodo periodo = context.periodos
                .Single(periodo => periodo.FechaInicio == periodoFechaInicio);
            // 4.- Cabecera de Matrícula
            Matricula matricula = new Matricula()
            {
                Estudiante = estudiante,
                Fecha = periodoFechaInicio, // Se matricula el mismo día que inicia el período
                Carrera = carrera,
                Estado = "Pendiente",
                Periodo = periodo
            };
            // 5.- Detalles de la Matrícula
            matricula.Matricula_Dets = new List<Matricula_Det>();
            foreach (var cursoNombre in cursosNombres)
            {
                Curso curso = context.cursos
                    .Single(cur => cur.Nombre == cursoNombre);
                Matricula_Det matricula_Det = new Matricula_Det()
                {
                    Matricula = matricula,
                    Curso = curso
                };
                matricula.Matricula_Dets.Add(matricula_Det);
            }

            return matricula;
        }

        // Registrar las calificaciones de un estudiante
        static public void RegistrarNotas(
            Matricula matricula, Dictionary<string, Calificacion> dicCursosCalifs)
        {
            // Buscar el curso para asignar las calificaciones
            foreach (var det in matricula.Matricula_Dets)
            {
                det.Calificacion = dicCursosCalifs[det.Curso.Nombre];
            }
        }

        // Validación de la matrícula
        static public bool ValidarMatricula(int matriculaId)
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
                int estudianteId = matricula.EstudianteId;
                // Verifica de cada materia los pre-requisitos
                bool aprobado = true;
                foreach (var matrDet in matricula.Matricula_Dets)
                {
                    Materia materia = matrDet.Curso.Materia;
                    // 1.- Materia no tiene pre-requisitos
                    if (materia.Prerequisitos is null)
                    {
                        break;
                    }
                    else // 2.- Materia si tiene pre-requisitos
                    {
                        // Reviso los pre-requisitos
                        foreach (var pre in materia.Prerequisitos)
                        {
                            if (!MateriaAprobada(estudianteId, pre.Malla.MateriaId))
                            {
                                aprobado = false;
                            }
                        }
                    }
                }
                return aprobado;
            }
        }

        //Verifica que haya aprobado una materia
        static public bool MateriaAprobada(int estudianteId, int materiaId)
        {
            bool resultado = false;
            using (var context = new EscuelaContext())
            {
                Materia materia = context.materias
                    .Include(mat => mat.Cursos)
                        .ThenInclude(cur => cur.Matricula_Dets)
                            .ThenInclude(det => det.Calificacion)
                    .Include(mat => mat.Cursos)
                        .ThenInclude(cur => cur.Matricula_Dets.Where(det => det.Matricula.EstudianteId == estudianteId))
                            .ThenInclude(det => det.Matricula)
                    .Single(mat => mat.MateriaId == materiaId);
                foreach (var curso in materia.Cursos)
                {
                    foreach (var det in curso.Matricula_Dets)
                    {
                        if (det.Calificacion is null)
                        {
                            // 1.- No hay calificaciones
                            return false;
                        }
                        else
                        {
                            // 2.- Revisa calificaciónes
                            CalificacionProc opCalif = new CalificacionProc(context);
                            if (opCalif.Aprobado(det.Calificacion))
                                return true;
                        }
                    }
                }
            }
            return resultado;
        }
    }
}
