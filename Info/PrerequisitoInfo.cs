using Modelo;
using Modelo.Escuela;
using System;
using System.Collections.Generic;

namespace Info
{
    public class PrerequisitoInfo: EntityInfo
    {
        public static new string Publicar(IDBEntity entidad)
        {
            Prerequisito ente = (Prerequisito)entidad;
            return String.Format(
                "MallaId: {0} \n MateriaId: {1}",
                ente.MallaId,
                ente.MateriaId
            );
        }

        public static new string Publicar(IEnumerable<IDBEntity> lista)
        {
            string mensaje = "MallaId \t MateriaId\n";
            var listaEntidad = (List<Prerequisito>)lista;
            foreach (var ente in listaEntidad)
            {
                mensaje += String.Format(
                    "{0} \t {1}\n",
                    ente.MallaId,
                    ente.MateriaId
                );
            }
            return mensaje;
        }
    }
}
