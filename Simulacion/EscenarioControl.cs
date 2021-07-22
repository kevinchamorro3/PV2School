using Escenarios;
using Modelo.Escuela;
using Persistencia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Escenarios.Escenario;

namespace Simulacion
{
    public class EscenarioControl
    {
        public void Grabar( IEscenario escenario )
        {
            var datos = escenario.Carga();

            using (var db = new EscuelaContext())
            {
                // Reiniciamos la base de datos
                db.Database.EnsureDeleted();
                db.Database.EnsureCreated();
                // Insertamos los datos
                db.configuracion.AddRange   ((List<Configuracion>)  datos[ListaTipo.Configuracion]  );
                db.estudiantes.AddRange     ((List<Estudiante>)     datos[ListaTipo.Estudiantes]    );
                db.periodos.AddRange        ((List<Periodo>)        datos[ListaTipo.Periodos]       );
                db.carreras.AddRange        ((List<Carrera>)        datos[ListaTipo.Carreras]       );
                db.materias.AddRange        ((List<Materia>)        datos[ListaTipo.Materias]       );
                db.mallas.AddRange          ((List<Malla>)          datos[ListaTipo.Mallas]         );
                db.prerequisitos.AddRange   ((List<Prerequisito>)   datos[ListaTipo.PreRequisitos]  );
                db.cursos.AddRange          ((List<Curso>)          datos[ListaTipo.Cursos]         );
                // Genera la persistencia
                db.SaveChanges();
            }
        }
    }
}
