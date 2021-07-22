using Modelo;
using Modelo.Escuela;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Info
{
    public class CalificacionInfo : EntityInfo
    {
        public static new string Publicar(IDBEntity entity)
        {
            var calificacion = (Calificacion)entity;
            return String.Format(
                "CalificacionId: {0} \n Matricula_DetId: {1} \n Notas: {2} {3} {4}",
                calificacion.CalificacionId,
                calificacion.Matricula_DetId,
                calificacion.Nota1,
                calificacion.Nota2,
                calificacion.Nota3
            );
        }

        public static new string Publicar(IEnumerable<IDBEntity> entity)
        {
            var calificaciones = (List<Calificacion>)entity;
            string msj = "CalificacionId \t Matricula_DetId \t Notas \n";
            foreach(var calificacion in calificaciones)
            {
                msj += String.Format(
                    "{0} \t {1} \t {2} \t {3} \t {4} \n",
                    calificacion.CalificacionId,
                    calificacion.Matricula_DetId,
                    calificacion.Nota1,
                    calificacion.Nota2,
                    calificacion.Nota3
                    );
            }
            return msj;
        }
    }
}
