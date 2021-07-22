using Modelo;
using Modelo.Escuela;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Info
{
    public class MateriaInfo: EntityInfo
    {
        public static new string Publicar(IDBEntity entidad)
        {
            Materia ente = (Materia)entidad;
            return String.Format(
                "MateriaId: {0} \n Nombre: {1}\n Area: {2} \n Creditos: {3}",
                ente.MateriaId,
                ente.Nombre,
                ente.Area,
                ente.Creditos
            );
        }

        public static new string Publicar(IEnumerable<IDBEntity> lista)
        {
            string msj = "MateriaId \t Nombre\t Area\t Creditos\n";
            var listaEntidad = (List<Materia>)lista;
            foreach (var ente in listaEntidad)
            {
                msj += String.Format(
                    "{0} \t {1} \t {2} \t {3}\n",
                    ente.MateriaId,
                    ente.Nombre,
                    ente.Area,
                    ente.Creditos
                );
            }
            return msj;
        }
    }
}
