using System;
using System.Collections.Generic;
using System.Text;

namespace Modelo.Escuela
{
    public class Estudiante : IDBEntity
    {
        // Atributos
        public int EstudianteId { get; set; }
        public string Nombre { get; set; }
        // Relación con matrículas
        public List<Matricula> Matriculas { get; set; }

    }
}
