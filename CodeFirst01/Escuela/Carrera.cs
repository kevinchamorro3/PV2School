using System;
using System.Collections.Generic;
using System.Text;

namespace Modelo.Escuela
{
    public class Carrera : IDBEntity
    {
        public int CarreraId {get;set;}
        public string Nombre { get; set; }
        public float CostoCredito { get; set; }
        // Relación con matrículas
        public List<Matricula> Matriculas { get; set; }
        // Relación con los cursos
        public List<Curso> Cursos { get; set; }
    }
}
