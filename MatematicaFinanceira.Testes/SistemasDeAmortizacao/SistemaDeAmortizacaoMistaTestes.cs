using System.Collections;
using System.Linq;
using MatematicaFinanceira.Lib;
using NUnit.Framework;

namespace MatematicaFinanceira.Testes
{
    [TestFixture]
    public class SistemaDeAmortizacaoMistaTestes
    {
        [Test]
        public void Deve_gerar_as_parcelas()
        {
            const decimal saldoDevedor = 300000;
            const int prazo = 5;
            const decimal taxaDeJuros = 0.04m;
            var parcelasEsperadas = new[]
            {
                new Parcela(0, 0, 300000),
                new Parcela(12000, 57694.06m, 242305.94m),
                new Parcela(9692.24m, 58801.83m, 183504.11m),
                new Parcela(7340.16m, 59953.91m, 123550.20m),
                new Parcela(4942.01m, 61152.06m, 62398.14m),
                new Parcela(2495.93m, 62398.14m, 0),
            };

            var parcelas = SistemaDeAmortizacaoMisto.CalcularParcelas(saldoDevedor, taxaDeJuros, prazo);

            CollectionAssert.AreEqual(parcelasEsperadas, parcelas);
        }

        [Test, Description("Sistema SAM não está zerando saldo devedor #11")]
        public void Teste_do_bug_da_quitacao_de_saldo()
        {
            const decimal saldoDevedor = 10000;
            const int prazo = 5;
            const decimal taxaDeJuros = 0.004m;

            var parcelas = SistemaDeAmortizacaoMisto.CalcularParcelas(saldoDevedor, taxaDeJuros, prazo);

            Assert.AreEqual(parcelas.Last().SaldoDevedor, 0);
        }
    }
}