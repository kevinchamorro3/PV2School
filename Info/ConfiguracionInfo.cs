using Modelo;
using Modelo.Escuela;
using System;
using System.Collections.Generic;

namespace Info
{
    public class ConfiguracionInfo : EntityInfo
    {
        public new static string Publicar(IDBEntity entidad)
        {
            var configuracion = (Configuracion) entidad;
            return String.Format(
                "Institución:  {0} \n Período Vigente Id: {1} \n Nota Mínima: {2} \n Pesos: {3} {4} {5}",
                configuracion.EscuelaNombre,
                configuracion.PeriodoVigenteId,
                configuracion.NotaMinima,
                configuracion.PesoNota1,
                configuracion.PesoNota2,
                configuracion.PesoNota3
                );
        }

        public static new string Publicar(IEnumerable<IDBEntity> lista)
        {
            string msj = "EscuelaNombre \t PeriodoVigenteId \t NotaMinima \t Pesos \n";
            var configuraciones = (List<Configuracion>)lista;
            foreach(var configuracion in configuraciones)
            {
                msj += String.Format(
                    "{0} \t {1} \t {2} \t {3} {4} {5} \n",
                    configuracion.EscuelaNombre,
                    configuracion.PeriodoVigenteId,
                    configuracion.NotaMinima,
                    configuracion.PesoNota1,
                    configuracion.PesoNota2,
                    configuracion.PesoNota3
                );
            }
            return msj;
        }

    }
}
