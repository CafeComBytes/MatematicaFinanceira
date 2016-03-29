using System;
using System.Linq;
using MatematicaFinanceira.Lib;
using NUnit.Framework;

namespace MatematicaFinanceira.Testes
{
    [TestFixture]
    public class SistemaDeAmortizacaoPriceTestes
    {
        [Test]
        public void Deve_gerar_parcela_zero()
        {
            const decimal saldoDevedor = 300000;
            const int prazo = 5;
            const decimal taxaDeJuros = 0.04m;
            var parcelaZeroEsperada = new Parcela(juros: 0, amortizacao: 0, saldoDevedor: saldoDevedor);

            var parcelaZero = SistemaDeAmortizacaoPrice.CalcularParcelas(saldoDevedor, taxaDeJuros, prazo).First();

            Assert.AreEqual(parcelaZeroEsperada, parcelaZero);
        }

        [Test]
        public void Deve_gerar_primeira_parcela()
        {
            const decimal saldoDevedor = 300000;
            const int prazo = 5;
            const decimal taxaDeJuros = 0.04m;
            var primeiraParcelaEsperada = new Parcela(juros: 12000, amortizacao: 55388.13m, saldoDevedor: 244611.87m);

            var primeiraParcela = SistemaDeAmortizacaoPrice.CalcularParcelas(saldoDevedor, taxaDeJuros, prazo)[1];

            Assert.AreEqual(primeiraParcelaEsperada.SaldoDevedor, primeiraParcela.SaldoDevedor);
            Assert.AreEqual(primeiraParcelaEsperada.Amortizacao, primeiraParcela.Amortizacao);
            Assert.AreEqual(primeiraParcelaEsperada.Juros, primeiraParcela.Juros);
        }

        [Test]
        public void Deve_gerar_ultima_parcela()
        {
            const decimal saldoDevedor = 300000;
            const int prazo = 5;
            const decimal taxaDeJuros = 0.04m;
            var primeiraParcelaEsperada = new Parcela(juros: 2591.85m, amortizacao: 64796.28m, saldoDevedor: 0);

            var primeiraParcela = SistemaDeAmortizacaoPrice.CalcularParcelas(saldoDevedor, taxaDeJuros, prazo).Last();

            Assert.AreEqual(primeiraParcelaEsperada, primeiraParcela);
        }

        [Test, Description("Exceção de overflow no cálculo price #10")]
        public void Teste_do_bug_de_overflow()
        {
            const decimal saldoDevedor = 10000;
            const decimal taxaDeJuros = 0.4m;
            const int prazo = 5;

            Assert.DoesNotThrow(() => SistemaDeAmortizacaoPrice.CalcularParcelas(saldoDevedor, taxaDeJuros, prazo));

            var ultimaParcela = SistemaDeAmortizacaoPrice.CalcularParcelas(saldoDevedor, taxaDeJuros, prazo).Last();
            Assert.AreEqual(ultimaParcela.SaldoDevedor, 0);
        }
    }
}