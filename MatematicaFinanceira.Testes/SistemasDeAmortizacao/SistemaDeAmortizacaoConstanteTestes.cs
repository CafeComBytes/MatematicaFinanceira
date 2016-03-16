using System.Collections.Generic;
using MatematicaFinanceira.Lib;
using NUnit.Framework;

namespace MatematicaFinanceira.Testes
{
    [TestFixture]
    public class SistemaDeAmortizacaoConstanteTestes
    {
        [Test]
        public void Deve_gerar_todas_as_parcelas()
        {
            const decimal saldoDevedor = 300000;
            const int prazo = 5;
            const decimal taxaDeJuros = 0.04m;
            var parcelasEsperadas = new[]
            {
                new Parcela(juros:0, amortizacao:0, saldoDevedor:300000), 
                new Parcela(juros:12000, amortizacao:60000, saldoDevedor:240000), 
                new Parcela(juros:9600, amortizacao:60000, saldoDevedor:180000), 
                new Parcela(juros:7200, amortizacao:60000, saldoDevedor:120000), 
                new Parcela(juros:4800, amortizacao:60000, saldoDevedor:60000), 
                new Parcela(juros:2400, amortizacao:60000, saldoDevedor:0), 
            };

            var parcelas = SistemaDeAmortizacaoConstante.CalcularParcelas(saldoDevedor, taxaDeJuros, prazo);

            CollectionAssert.AreEqual(parcelasEsperadas, parcelas);
        }
    }
}