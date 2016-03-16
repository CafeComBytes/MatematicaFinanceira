using System;
using System.Collections.Generic;

namespace MatematicaFinanceira.Lib
{
    public class SistemaDeAmortizacaoPrice
    {
        public static IReadOnlyList<Parcela> CalcularParcelas(decimal saldoDevedor, decimal taxaDeJuros, int prazo)
        {
            var parcelas = new List<Parcela>()
            {
                new Parcela(juros: 0, amortizacao: 0, saldoDevedor: saldoDevedor)
            };

            var saldoDevedorAtual = saldoDevedor;
            var coeficienteK = (taxaDeJuros * (1 + taxaDeJuros).ElevadoPor(prazo)) / ((1 + taxaDeJuros).ElevadoPor(prazo) - 1);
            var prestacaoAtravesDoPrazo = coeficienteK * saldoDevedor;

            while (saldoDevedorAtual != 0)
            {
                var juros = JurosCompostos.CalcularJuros(saldoDevedorAtual, taxaDeJuros, 1);
                var amortizacao = prestacaoAtravesDoPrazo - juros;
                saldoDevedorAtual -= amortizacao.Arredondado(2);
                var parcelaAtual = new Parcela(juros.Arredondado(2), amortizacao.Arredondado(2), saldoDevedorAtual.Arredondado(2));
                parcelas.Add(parcelaAtual);
            }

            return parcelas;
        }
    }
}