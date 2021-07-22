using System.Collections.Generic;

namespace Modelo.Escuela
{
    public class Materia : IDBEntity
    {
        public int MateriaId { get; set; }
        public string Nombre { get; set; }
        public string Area { get; set; }
        public int Creditos { get; set; }
        // Relación con Cursos que dictan esta materia
        public List<Curso> Cursos { get; set; }
        // Relación de uno a uno con la malla
        public Malla Malla { get; set; } 
        // Relación con los prerequisitos de la materia
        public List<Prerequisito> Prerequisitos { get; set; } 
    }
}
