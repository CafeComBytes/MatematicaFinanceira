using System;

namespace MatematicaFinanceira.Lib
{
    public class JurosSimples
    {
        public static decimal CalcularJuros(decimal capitalInicial, decimal taxaDeJuros, int prazo)
        {
            return capitalInicial * taxaDeJuros * prazo;
        }

        public static decimal CalcularMontante(decimal capitalInicial, decimal taxaDeJuros, int prazo)
        {
            return capitalInicial + CalcularJuros(capitalInicial, taxaDeJuros, prazo);
        }

        public static decimal CalcularTaxaDeJuros(decimal capitalInicial, decimal juros, int prazo)
        {
            return juros / (capitalInicial * prazo);
        }

        public static decimal CalcularCapitalInicial(decimal juros, decimal taxaDeJuros, int prazo)
        {
            return juros / (taxaDeJuros * prazo);
        }

        public static int CalcularPrazo(decimal capitalInicial, decimal juros, decimal taxaDeJuros)
        {
            return Convert.ToInt32(juros / (capitalInicial * taxaDeJuros));
        }
    }
}