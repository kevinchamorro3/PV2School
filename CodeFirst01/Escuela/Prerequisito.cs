using System;
using System.Collections.Generic;
using System.Text;

namespace Modelo.Escuela
{
    public class Prerequisito : IDBEntity
    {
        public int MallaId { get; set; }
        public int MateriaId { get; set; }
        // Relaciones
        public Malla Malla { get; set; }
        public Materia Materia { get; set; }
    }
}
