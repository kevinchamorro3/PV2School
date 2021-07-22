using Modelo.Escuela;
using Persistencia;
using System;
using System.Linq;

namespace Procesos
{
    public class MallaProc
    {
        // Cambio de malla de un prerequisito
        public static void CambioPrequerisito(
            Malla MallaOrigen, Malla MallaDestino, Prerequisito Prerequisito
            )
        {            
            using (var db = new EscuelaContext())
            {
                // Información del prerequisito
                int materiaPreReqId = Prerequisito.MateriaId;
                // Insertar el prerequisito
                var nuevoPreRequisito = new Prerequisito()
                {
                    MallaId = MallaDestino.MallaId,
                    MateriaId = materiaPreReqId
                };
                db.prerequisitos.Add(nuevoPreRequisito);
                // Borrar el prerequisito
                var preRequisitoABorrar = db.prerequisitos
                    .Single(pre =>
                       pre.MallaId == MallaOrigen.MallaId &&
                       pre.MateriaId == materiaPreReqId
                    );
                db.prerequisitos.Remove(preRequisitoABorrar);
                // Guarda los cambios
                db.SaveChanges();
            }
        }
    }
}
