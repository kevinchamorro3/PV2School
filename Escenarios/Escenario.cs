using Modelo;

using System.Collections.Generic;


namespace Escenarios
{
    public class Escenario
    {
        public enum ListaTipo { 
            Periodos, 
            Configuracion, 
            Carreras, 
            Estudiantes, 
            Materias, 
            Mallas, 
            PreRequisitos, 
            Cursos }

        public Dictionary<ListaTipo, IEnumerable<IDBEntity>> datos;        

        public Escenario()
        {
            datos = new();
        }
    }
}
