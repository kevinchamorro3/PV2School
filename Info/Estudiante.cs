using Modelo;
using Modelo.Escuela;
using System;
using System.Collections.Generic;

namespace Info
{
    public class EstudianteInfo : EntityInfo
    {
        public static new string Publicar(IDBEntity entidad)
        {
            Estudiante estudiante = (Estudiante)entidad;
            return String.Format(
                " {0} \n {1}",
                estudiante.EstudianteId,
                estudiante.Nombre
            );
        }

        public static new string Publicar(IEnumerable<IDBEntity> lista)
        {
            string mensaje ="EstudianteID \t Nombre\n";
            var listaEstudiantes = (List<Estudiante>)lista;
            foreach(var estudiante in listaEstudiantes)
            {
                mensaje += String.Format(
                    "{0} \t {1}\n",
                    estudiante.EstudianteId,
                    estudiante.Nombre
                );
            }
            return mensaje;
        }
    }
}
