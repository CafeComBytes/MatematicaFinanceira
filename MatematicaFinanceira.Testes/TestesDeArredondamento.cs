using MatematicaFinanceira.Lib;
using NUnit.Framework;

namespace MatematicaFinanceira.Testes
{
    [TestFixture]
    public class TestesDeArredondamento
    {
        [Test]
        public void Nao_deve_arredondar_digito_inferior_5()
        {
            Assert.AreEqual(0.12m, 0.124m.Arredondado(2));
        }

        [Test]
        public void Deve_aumentar_quando_digito_depois_do_piso_for_superior_a_5()
        {
            Assert.AreEqual(0.16m, 0.156m.Arredondado(2));
        }

        [Test]
        public void Deve_aumentar_quando_o_digito_sendo_5_e_tiver_um_numero_diferente_de_zero_a_direita()
        {
            Assert.AreEqual(0.13m, 0.125001m.Arredondado(2));
        }
    }
}