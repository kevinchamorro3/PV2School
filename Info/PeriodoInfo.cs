using Modelo;
using Modelo.Escuela;
using System;
using System.Collections.Generic;

namespace Info
{
    public class PeriodoInfo : EntityInfo
    {
        public static new string Publicar(IDBEntity entidad)
        {
            Periodo periodo = (Periodo)entidad;
            return String.Format(
                " {0} \n {1} \n {2} \n {3}",
                periodo.PeriodoId,
                periodo.Estado,
                periodo.FechaInicio,
                periodo.FechaFin                
                );
        }

        public static new string Publicar(IEnumerable<IDBEntity> lista)
        {
            string mensaje ="PeriodoId \t Estado \t Inicio \t Fin \n";
            var listaPeriodos = (List<Periodo>)lista;
            foreach(var periodo in listaPeriodos)
            {
                mensaje += String.Format(
                    "{0} \t {1} \t {2} \t {3} \n",
                    periodo.PeriodoId,
                    periodo.Estado,
                    periodo.FechaInicio,
                    periodo.FechaFin
                    );
            }
            return mensaje;
        }
    }
}
