using System;

namespace MatematicaFinanceira.Lib
{
    public static class JurosCompostos
    {
        public static decimal CalcularTaxaDeAcumulacaoDeCapital(decimal taxaDeJuros, int prazo)
        {
            return (decimal)Math.Pow((double)(1 + taxaDeJuros), prazo);
        }

        public static decimal CalcularJuros(decimal capitalInicial, decimal taxaDeJuros, int prazo)
        {
            return CalcularMontante(capitalInicial, taxaDeJuros, prazo) - capitalInicial;
        }

        public static decimal CalcularMontante(decimal capitalInicial, decimal taxaDeJuros, int prazo)
        {
            return capitalInicial * CalcularTaxaDeAcumulacaoDeCapital(taxaDeJuros, prazo);
        }

        public static decimal CalcularCapitalInicial(decimal montante, decimal taxaDeJuros, int prazo)
        {
            return montante / CalcularTaxaDeAcumulacaoDeCapital(taxaDeJuros, prazo);
        }

        public static decimal CalcularTaxaDeJuros(decimal capitalInicial, decimal montante, int prazo)
        {
            return (decimal)Math.Pow((double)(montante / capitalInicial), (double)1 / prazo) - 1;
        }

        public static int CalcularPrazo(decimal capitalInicial, decimal montante, decimal taxaDeJuros)
        {
            return (int)(Math.Log((double)(montante / capitalInicial)) / Math.Log(1 + (double)taxaDeJuros));
        }
    }
}
