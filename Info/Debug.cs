using Modelo;
using Modelo.Escuela;
using System;
using System.Collections.Generic;

namespace Info
{
    public class Debug
    {
        public static void Print(IDBEntity entidad)
        {
            string msj = "";
            if (entidad is Periodo)
            {
                msj = PeriodoInfo.Publicar((Periodo)entidad);
            }
            else if (entidad is Estudiante)
            {
                msj = EstudianteInfo.Publicar((Estudiante)entidad);
            }
            else if (entidad is Materia)
            {
                msj = MateriaInfo.Publicar((Materia)entidad);
            }
            else if (entidad is Malla)
            {
                msj = MallaInfo.Publicar((Malla)entidad);
            }
            else if (entidad is Prerequisito)
            {
                msj = PrerequisitoInfo.Publicar((Prerequisito)entidad);
            }
            //
            Console.WriteLine(msj);
        }

        public static void Print(IEnumerable<IDBEntity> lista)
        {
            string msj = "";
            if (lista is List<Periodo>)
            {
                msj = PeriodoInfo.Publicar(lista);
            }
            else if (lista is List<Estudiante>)
            {
                msj = EstudianteInfo.Publicar(lista);
            }
            else if (lista is List<Materia>)
            {
                msj = MateriaInfo.Publicar(lista);
            }
            else if (lista is List<Malla>)
            {
                msj = MallaInfo.Publicar(lista);
            }
            else if (lista is List<Prerequisito>)
            {
                msj = PrerequisitoInfo.Publicar(lista);
            }
            //
            Console.WriteLine(msj);
        }
    }
}
