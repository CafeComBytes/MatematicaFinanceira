using System.Collections.Generic;

namespace MatematicaFinanceira.Lib
{
    public class SistemaDeAmortizacaoConstante
    {
        public static IReadOnlyList<Parcela> CalcularParcelas(decimal saldoDevedor, decimal taxaDeJuros, int prazo)
        {
            var parcelas = new List<Parcela>();
            var saldoDevedorAtual = saldoDevedor;
            var amortizacaoAtravesDoPrazo = saldoDevedor / prazo;

            parcelas.Add(new Parcela(juros: 0, amortizacao: 0, saldoDevedor: saldoDevedor));

            while (saldoDevedorAtual != 0)
            {
                var juros = JurosCompostos.CalcularJuros(saldoDevedorAtual, taxaDeJuros, prazo: 1);
                saldoDevedorAtual -= amortizacaoAtravesDoPrazo;
                parcelas.Add(new Parcela(juros, amortizacaoAtravesDoPrazo, saldoDevedorAtual));
            }

            return parcelas;
        }
    }
}