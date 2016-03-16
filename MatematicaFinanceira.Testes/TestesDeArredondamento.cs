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
    }
}