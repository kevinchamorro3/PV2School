using System;
using System.Collections.Generic;
using System.Text;

namespace Modelo.Escuela
{
    public class Matricula : IDBEntity
    {
        // Datos generales
        public int MatriculaId { get; set; }
        public DateTime Fecha { get; set; }
        public string Estado { get; set; }   // PENdiente, APRobada, ANUlada
        // Relación con el estudiante
        public int EstudianteId { get; set; }
        public Estudiante Estudiante { get; set; }
        // Relación con la carrera
        public Carrera Carrera { get; set; }
        public int CarreraId { get; set; }
        // Relación con el período
        public Periodo Periodo { get; set; }
        public int PeriodoId { get; set; }
        // Detalles de la matrícula
        public List<Matricula_Det> Matricula_Dets{ get; set; }
    }
}
