using System;

namespace MatematicaFinanceira.Lib
{
    public static class MetodosDeExtensaoDeDecimal
    {
        public static decimal ElevadoPor(this decimal @base, int expoente)
        {
            return (decimal)Math.Pow((double)@base, expoente);
        }

        public static decimal Arredondado(this decimal numero, int casasDecimais)
        {
            return decimal.Round(numero, casasDecimais);
        }

        public static void ParaCadaFaca(this int numeroDeVezes, Action<int> metodo)
        {
            for (var i = 0; i < numeroDeVezes; i++)
                metodo.Invoke(i);
        }
    }
}