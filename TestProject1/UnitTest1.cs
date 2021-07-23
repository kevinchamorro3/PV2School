using Modelo.Escuela;
using System;
using Xunit;

namespace TestProject1
{
    public class UnitTest1
    {
        [Theory]
        [InlineData(5.55, 4.34, 5.74, false)]
        [InlineData(8.78, 7.12, 6.25, true)]
        [InlineData(6.65, 8.94, 9.74, true)]
        [InlineData(7.84, 9.12,8.5,true)]
        [InlineData(4.48,5.12 ,8.5 ,false)]
        [InlineData(7.02,7.24 ,6.69 , false)]
        [InlineData(9.12, 7.33, 7.25, true)]
        [InlineData(7.84, 7.12, 8.5, true)]
        [InlineData(8.55, 8.34, 8.74, true)]
        [InlineData(8.78, 9.33, 6.27, true)]
        [InlineData(6.89, 6.82, 7.34, true)]
        [InlineData(7.84, 7.12, 5.50, false)]
        [InlineData(9.84, 8.12, 7.37, true)]
        [InlineData(6.89,7.23,6.99, true)]
        [InlineData(8.45,7.65,7.25,true)]

        public void Test1(float n1, float n2, float n3, bool resultadoEsperado )
        {
            //preparacion  calse calificiacion 
            bool real;
            Calificacion califificacion = new Calificacion()
            {
                Nota1 = n1,
                Nota2 = n2,
                Nota3 = n3
            };
            float peso1 = 0.30f;
            float peso2 = 0.30f;
            float peso3 = 0.40f;
            float notMin = 7.00f;

            //ejecucion
            real = califificacion.Aprueba(peso1, peso2, peso3, notMin );
            //verificacion
            if (resultadoEsperado)
            {
                Assert.True(real);
            }
            else
            {
                Assert.False(real);
            }
        }
        [Theory]
        [InlineData(5.55, 4.34, 5.74, false)]
        [InlineData(8.78, 7.12, 6.25, true)]
        [InlineData(6.65, 8.94, 9.74, true)]
        [InlineData(7.84, 9.12, 8.5, true)]
        [InlineData(4.48, 5.12, 8.5, false)]
        [InlineData(7.02, 7.24, 6.69, true)]
        [InlineData(9.12, 7.33, 7.25, true)]
        [InlineData(7.84, 7.12, 8.5, true)]
        [InlineData(8.55, 8.34, 8.74, true)]
        [InlineData(8.78, 9.33, 6.27, true)]
        [InlineData(6.89, 6.82, 7.34, true)]
        [InlineData(7.84, 7.12, 5.50, false)]
        [InlineData(9.84, 8.12, 7.37, true)]
        [InlineData(6.89, 7.23, 6.99, true)]
        [InlineData(8.45, 7.65, 7.25, true)]
        public void Test2(float n1, float n2, float n3, bool resultadoEsperado)
        {
            //preparacion  calse calificiacion 
            bool real;
            Calificacion califificacion = new Calificacion()
            {
                Nota1 = n1,
                Nota2 = n2,
                Nota3 = n3
            };
            float peso1 = 0.35f;
            float peso2 = 0.35f;
            float peso3 = 0.30f;
            float notMin = 7.00f;

            //ejecucion
            real = califificacion.Aprueba(peso1, peso2, peso3, notMin);
            //verificacion
            if (resultadoEsperado)
            {
                Assert.True(real);
            }
            else
            {
                Assert.False(real);
            }
        }
    }
}
