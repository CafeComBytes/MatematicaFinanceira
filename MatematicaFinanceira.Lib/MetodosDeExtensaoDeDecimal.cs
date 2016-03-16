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
    }
}