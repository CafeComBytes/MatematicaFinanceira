using MatematicaFinanceira.Lib;
using NUnit.Framework;
using Should.Fluent;

namespace MatematicaFinanceira.Testes
{
    [TestFixture]
    public class JurosSimplesTestes
    {
        [Test]
        public void Deve_calcular_juros()
        {
            var capitalInicial = 5000m;
            var taxaDeJuros = 0.05m;
            var prazo = 4;

            var juros = JurosSimples.CalcularJuros(capitalInicial, taxaDeJuros, prazo);

            juros.Should().Equal(1000m);
        }

        [Test]
        public void Deve_calcular_montante()
        {
            var capitalInicial = 5000m;
            var taxaDeJuros = 0.05m;
            var prazo = 4;

            var montante = JurosSimples.CalcularMontante(capitalInicial, taxaDeJuros, prazo);

            montante.Should().Equal(6000m);
        }

        [Test]
        public void Deve_calcular_taxa_de_juros()
        {
            var capitalInicial = 5000m;
            var prazo = 4;
            var juros = 1000m;

            var taxaDeJuros = JurosSimples.CalcularTaxaDeJuros(capitalInicial, juros, prazo);

            taxaDeJuros.Should().Equal(0.05m);
        }

        [Test]
        public void Deve_calcular_prazo()
        {
            var capitalInicial = 5000m;
            var juros = 1000m;
            var taxaDeJuros = 0.05m;

            var prazo = JurosSimples.CalcularPrazo(capitalInicial, juros, taxaDeJuros);

            prazo.Should().Equal(4);
        }

        [Test]
        public void Deve_calcular_capital_inicial()
        {
            var juros = 1000m;
            var taxaDeJuros = 0.05m;
            var prazo = 4;

            var capitalInicial = JurosSimples.CalcularCapitalInicial(juros, taxaDeJuros, prazo);

            capitalInicial.Should().Equal(5000m);
        }
    }
}
