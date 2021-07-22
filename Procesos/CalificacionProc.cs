using Microsoft.EntityFrameworkCore;
using Modelo.Escuela;
using Persistencia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Procesos
{
    public class CalificacionProc
    {
        public EscuelaContext _context;

        float pesoNota1, pesoNota2, pesoNota3, notaMinima;

        public CalificacionProc(EscuelaContext context)
        {
            _context = context;
            // Carga los parámetros para calcular la nota final
            var config = context.configuracion
                .Include(ctx => ctx.PeriodoVigente)
                .Single(ctx => ctx.ConfiguracionId == 1);
            pesoNota1 = config.PesoNota1;
            pesoNota2 = config.PesoNota2;
            pesoNota3 = config.PesoNota3;
            notaMinima = config.NotaMinima;
        }

        public bool Aprobado(int calificacionId)
        {
            Calificacion calif = _context.calificaciones
                .Single(calif => calif.CalificacionId == calificacionId);
            return Aprobado(calif);
        }

        public bool Aprobado(Calificacion calif)
        {
            return calif.Aprueba(pesoNota1, pesoNota2, pesoNota3, notaMinima);
        }

        public float NotaFinal(Calificacion calif)
        {
            return calif.NotaFinal(pesoNota1, pesoNota2, pesoNota3);
        }

        public void RegistrarNotas(Matricula_Det det, Calificacion calif)
        {
            det.Calificacion = calif;

            try
            {
                _context.calificaciones.Add(calif);
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException exception)
            {
                Exception ex = new Exception("Conficto de concurrencia", exception);
                throw ex;
            }
        }
    }
}
