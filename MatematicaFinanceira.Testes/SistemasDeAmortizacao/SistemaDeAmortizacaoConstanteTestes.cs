using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
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
            const decimal saldoDevedor = 10000m;
            const int prazo = 5;
            const decimal taxaDeJuros = 0.4m;
            const decimal amortizacao = saldoDevedor / prazo;
            var parcelasEsperadas = new List<Parcela>();
            prazo.ParaCadaFaca(numeroDaParcela =>
            {
                if (!parcelasEsperadas.Any())
                    parcelasEsperadas.Add(new Parcela(0, 0, saldoDevedor));

                var saldoDevedorDaParcelaPassada = saldoDevedor - (numeroDaParcela * amortizacao);
                var saldoDevedorDaParcela = saldoDevedor - ((numeroDaParcela + 1) * amortizacao);
                var juros = JurosCompostos.CalcularJuros(saldoDevedorDaParcelaPassada, taxaDeJuros, 1);
                var parcela = new Parcela(juros, amortizacao, saldoDevedorDaParcela);
                
                parcelasEsperadas.Add(parcela);
            });

            var parcelas = SistemaDeAmortizacaoConstante.CalcularParcelas(saldoDevedor, taxaDeJuros, prazo);
            
            CollectionAssert.AreEqual(parcelasEsperadas, parcelas);
        }

        [Test, Description("Sistema SAC quando amortização tem dizima ocorre OutOfMemoryException #12")]
        public void Teste_do_bug_do_overflow()
        {
            const decimal saldoDevedor = 100000m;
            const int prazo = 300;
            const decimal taxaDeJuros = 0.8m;
            
            Assert.DoesNotThrow(() =>
            {
                var parcelas = SistemaDeAmortizacaoConstante.CalcularParcelas(saldoDevedor, taxaDeJuros, prazo);
                Assert.AreEqual(parcelas.Last().SaldoDevedor, 0);
            });
            
        }

        [Test, Description("Soma das amortizações não da o saldo devedor no SAC #13")]
        public void Teste_do_bug_da_quitacao_de_saldo_devedor()
        {
            const decimal saldoDevedor = 1000;
            const int prazo = 3;
            const decimal taxaDeJuros = 0.02m;

            var parcelas = SistemaDeAmortizacaoConstante.CalcularParcelas(saldoDevedor, taxaDeJuros, prazo);

            Assert.AreEqual(saldoDevedor, parcelas.Sum(parcela => parcela.Amortizacao));
        }
    }
}