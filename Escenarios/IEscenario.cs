using System.Collections.Generic;
using Modelo;
using static Escenarios.Escenario;

namespace Escenarios
{
    public interface IEscenario
    {
        public Dictionary<ListaTipo, IEnumerable<IDBEntity>> Carga();
    }
}
