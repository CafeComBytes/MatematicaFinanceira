using System.Collections.Generic;

namespace MatematicaFinanceira.Lib
{
    public class SistemaDeAmortizacaoMista
    {
        public static IReadOnlyList<Parcela> CalcularParcelas(decimal saldoDevedor, decimal taxaDeJuros, int prazo)
        {
            var parcelas = new List<Parcela> { new Parcela(juros: 0, amortizacao: 0, saldoDevedor: saldoDevedor) };

            var parcelasNoSAC = SistemaDeAmortizacaoConstante.CalcularParcelas(saldoDevedor, taxaDeJuros, prazo);
            var parcelasNoPrice = SistemaDeAmortizacaoPrice.CalcularParcelas(saldoDevedor, taxaDeJuros, prazo);
            var saldoDevedorAtual = saldoDevedor;

            for (var indiceDaParcela = 1; indiceDaParcela < parcelasNoSAC.Count; indiceDaParcela++)
            {
                var parcelaMedia = (parcelasNoSAC[indiceDaParcela].Prestacao + parcelasNoPrice[indiceDaParcela].Prestacao) / 2;
                var juros = JurosCompostos.CalcularJuros(saldoDevedorAtual, taxaDeJuros, 1);
                var amortizacao = parcelaMedia - juros;
                saldoDevedorAtual -= amortizacao.Arredondado(2);
                var parcelaAtual = new Parcela(juros.Arredondado(2), amortizacao.Arredondado(2), saldoDevedorAtual.Arredondado(2));
                parcelas.Add(parcelaAtual);
            }

            return parcelas;
        }
    }
}