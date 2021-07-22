using System;
using System.Collections.Generic;
using System.Text;

namespace Modelo.Escuela
{
    public class Malla : IDBEntity
    {
        public int MallaId { get; set; }
        public string Nivel { get; set; }
        // Relación con la Carrera
        public int CarreraId { get; set; }
        public Carrera Carrera { get; set; }
        // Relación con la Materia
        public int MateriaId { get; set; }
        public Materia Materia { get; set; }
        // Grafo: Materias pre-requisitos
        public List<Prerequisito> PreRequisitos { get; set; }
    }
}
