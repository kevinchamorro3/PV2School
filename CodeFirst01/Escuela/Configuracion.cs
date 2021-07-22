using System;
using System.Collections.Generic;
using System.Text;

namespace Modelo.Escuela
{
    public class Configuracion : IDBEntity
    {
        public int ConfiguracionId { get; set; }
        public string EscuelaNombre { get; set; }
        // Período vigente
        public Periodo PeriodoVigente { get; set; }
        public int PeriodoVigenteId { get; set; }
        // Control de créditos
        public int CreditosMaximo { get; set; }
        // Pesos de cada nota
        public float PesoNota1 { get; set; }
        public float PesoNota2 { get; set; }
        public float PesoNota3 { get; set; }
        // Nota mínima 
        public float NotaMinima { get; set; }
    }
}
