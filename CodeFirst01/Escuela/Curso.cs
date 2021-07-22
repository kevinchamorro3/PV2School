using System;
using System.Collections.Generic;
using System.Text;

namespace Modelo.Escuela
{
    // Curso tercero de matemáticas de la mañana del semestre AGO-MAR 2021
    public class Curso : IDBEntity
    {
        public int CursoId { get; set; }
        public string Nombre { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public string Jornada { get; set; }
        // Relación con la carrera
        public int CarreraId { get; set; }
        public Carrera Carrera { get; set; }
        // Relación con el Período
        public Periodo Periodo { get; set; }
        public int PeriodoId { get; set; }
        // Relación con Materia
        public int MateriaId { get; set; }
        public Materia Materia { get; set; }
        // Relación con Matrícula
        public List<Matricula_Det> Matricula_Dets { get; set; }
    }
}
