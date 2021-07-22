using Procesos;
using Reportes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulacion
{
    public class CambioPreRequisito
    {
        public static void Do() 
        {
            // Publicar la situación antes del cambio
            Console.WriteLine("Situación antes del cambio");
            var matProdDig = Reporte.Prerequisitos("Productos Digitales");
            Publicar.Prerequisitos(matProdDig);
            var matELearning = Reporte.Prerequisitos("E-Learning");
            Publicar.Prerequisitos(matELearning);

            MallaProc.CambioPrequerisito(
                matProdDig.Malla,
                matELearning.Malla,
                matProdDig.Malla.PreRequisitos[0]);

            Console.WriteLine("Situación después del cambio");
            // Publicar la situación después del cambio
            matProdDig = Reporte.Prerequisitos("Productos Digitales");
            Publicar.Prerequisitos(matProdDig);
            matELearning = Reporte.Prerequisitos("E-Learning");
            Publicar.Prerequisitos(matELearning);
        }
    }
}
