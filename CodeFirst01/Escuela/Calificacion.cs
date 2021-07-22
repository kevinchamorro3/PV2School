using System;
using System.Collections.Generic;
using System.Text;

namespace Modelo.Escuela
{
    public class Calificacion : IDBEntity
    {
        public int CalificacionId { get; set; }
        // Relación Uno a Uno
        public int Matricula_DetId { get; set; }
        public Matricula_Det Matricula_Det { get; set; }
        // Composición de las notas
        public float Nota1 { get; set; }
        public float Nota2 { get; set; }
        public float Nota3 { get; set; }

        // Cálculo de la nota final
        public float NotaFinal(float peso1, float peso2, float peso3)
        {            
            // Cálculo
            float suma = 0;
            suma += Nota1 * peso1;
            suma += Nota2 * peso2;
            suma += Nota3 * peso3;
            suma = MathF.Round(suma, 2);
            return suma;
        }
        // Verifica si cumple el mínimo
        public bool Aprueba(float peso1, float peso2, float peso3, float NotaMinima)
        {
            bool res;
            res = NotaFinal(peso1, peso2, peso3) >= NotaMinima;
            return res;
        }
    }
}
