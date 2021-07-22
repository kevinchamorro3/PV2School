using System;
using System.Collections.Generic;
using System.Text;

namespace Modelo.Escuela
{
    public class Matricula_Det : IDBEntity
    {
        public int Matricula_DetId { get; set; }
        // Relaciones con Matricula y Curso
        public int MatriculaId { get; set; }
        public Matricula Matricula { get; set; }
        public int CursoId { get; set; }
        public Curso Curso { get; set;}
        // Relación Uno a Uno
        public Calificacion Calificacion { get; set; }
    }
}
