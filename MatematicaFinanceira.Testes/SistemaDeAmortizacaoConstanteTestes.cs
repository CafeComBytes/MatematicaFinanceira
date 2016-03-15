using System.Collections.Generic;
using MatematicaFinanceira.Lib;
using NUnit.Framework;

namespace MatematicaFinanceira.Testes
{
    [TestFixture]
    public class SistemaDeAmortizacaoConstanteTestes
    {
        [Test]
        public void Deve_calcular_parcela_zero()
        {
            const decimal saldoDevedor = 150000;
            var parcelaEsperada = new Parcela(juros: 0, amortizacao: 0, saldoDevedor: saldoDevedor);

            var parcelaZero = SistemaDeAmortizacaoConstante.CalcularParcelas(saldoDevedor, taxaDeJuros: 0, prazo: 1)[0];

            Assert.AreEqual(parcelaEsperada, parcelaZero);
        }

        [Test]
        public void Deve_calcular_primeira_parcela()
        {
            const decimal saldoDevedor = 300000;
            const int prazo = 5;
            const decimal taxaDeJuros = 0.04m;
            const decimal amortizacao = saldoDevedor / prazo;
            var juros = JurosCompostos.CalcularJuros(saldoDevedor, taxaDeJuros, 1);
            var primeiraParcelaEsperada = new Parcela(juros, amortizacao, saldoDevedor - amortizacao);

            var primeiraParcela = SistemaDeAmortizacaoConstante.CalcularParcelas(saldoDevedor, taxaDeJuros, prazo)[1];
            
            Assert.AreEqual(primeiraParcelaEsperada, primeiraParcela);
        }

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