using MatematicaFinanceira.Lib;
using NUnit.Framework;

namespace MatematicaFinanceira.Testes
{
    [TestFixture]
    public class ParcelaTestes
    {
        [Test]
        public void Deve_comparar_duas_parcelas_iguais()
        {
            var parcela1 = new Parcela(juros: 10, amortizacao: 11, saldoDevedor: 13);
            var parcela2 = new Parcela(juros: 10, amortizacao: 11, saldoDevedor: 13);

            Assert.IsTrue(parcela1 == parcela2);
            Assert.IsTrue(parcela2.Equals(parcela1));
        }

        [Test]
        public void Deve_comparar_duas_parcelas_diferentes()
        {
            var parcela1 = new Parcela(juros: 10, amortizacao: 12, saldoDevedor: 100);
            var parcela2 = new Parcela(juros: 10, amortizacao: 15, saldoDevedor: 100);

            Assert.IsTrue(parcela1 != parcela2);
            Assert.IsFalse(parcela2.Equals(parcela1));
            Assert.IsFalse(parcela2.Equals(null));
            Assert.IsFalse(parcela2.Equals(1));
        }

        [Test]
        public void Prestacao_deve_ser_a_soma_de_amortizacao_e_juros()
        {
            var parcela = new Parcela(juros: 10, amortizacao: 15, saldoDevedor: 16);

            Assert.AreEqual(parcela.Juros + parcela.Amortizacao, parcela.Prestacao);
        }

        [Test]
        public void Prestacao_deve_gerar_hashcode_unico_por_parcela()
        {
            var parcela = new Parcela(juros: 10, amortizacao: 15, saldoDevedor: 200);

            var hashCode = string.Format("{0}_{1}_{2}", parcela.Juros, parcela.Amortizacao, parcela.SaldoDevedor).GetHashCode();

            Assert.AreEqual(hashCode, parcela.GetHashCode());
        }
        
    }
}