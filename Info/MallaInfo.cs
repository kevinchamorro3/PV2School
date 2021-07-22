using Modelo;
using Modelo.Escuela;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Info
{
    public class MallaInfo: EntityInfo
    {
        public static new string Publicar(IDBEntity entidad)
        {
            Malla malla = (Malla)entidad;
            return String.Format(
                "MallaId: {0} \n Nivel: {1}\n CarreraId: {2} \n MateriaId: {3}",
                malla.MallaId,
                malla.Nivel,
                malla.CarreraId,
                malla.MateriaId
            );
        }

        public static new string Publicar(IEnumerable<IDBEntity> lista)
        {
            string mensaje = "MallaId \t Nivel \t CarreraId \t MateriaId \n";
            var listaEntidad = (List<Malla>)lista;
            foreach (var ente in listaEntidad)
            {
                mensaje += String.Format(
                    "{0} \t {1} \t {2} \t {3}\n",
                    ente.MallaId,
                    ente.Nivel,
                    ente.CarreraId,
                    ente.MateriaId
                );
            }
            return mensaje;
        }
    }
}
