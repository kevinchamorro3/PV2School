using System;
using System.Collections.Generic;
using System.Text;

namespace Modelo.Escuela
{
    public class Periodo : IDBEntity
    {
        public int PeriodoId { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public string Estado { get; set; } // ABRierto CERrado
        // Relación con los cursos abiertos en un período
        public List<Curso> Cursos { get; set; }
        // Relación con las matrículas realizadas en un período
        public List<Matricula> Matriculas { get; set; }
    }
}
