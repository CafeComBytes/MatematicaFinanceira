using MatematicaFinanceira.Lib;
using NUnit.Framework;
using Should.Fluent;

namespace MatematicaFinanceira.Testes
{
    [TestFixture]
    public class JurosCompostosTestes
    {
        [Test]
        public void Deve_calcular_juros()
        {
            var capitalInicial = 1000m;
            var taxaDeJuros = 0.2m;
            var prazo = 3;

            var juros = JurosCompostos.CalcularJuros(capitalInicial, taxaDeJuros, prazo);

            juros.Should().Equal(728m);
        }

        [Test]
        public void Deve_calcular_montante()
        {
            var capitalInicial = 1000m;
            var taxaDeJuros = 0.2m;
            var prazo = 3;

            var montante = JurosCompostos.CalcularMontante(capitalInicial, taxaDeJuros, prazo);

            montante.Should().Equal(1728m);
        }

        [Test]
        public void Deve_calcular_taxa_de_juros()
        {
            var capitalInicial = 1000m;
            var montante = 1728m;
            var prazo = 3;

            var taxaDeJuros = JurosCompostos.CalcularTaxaDeJuros(capitalInicial, montante, prazo);

            taxaDeJuros.Should().Equal(0.2m);
        }

        [Test]
        public void Deve_calcular_prazo()
        {
            var capitalInicial = 1000m;
            var montante = 1728m;
            var taxaDeJuros = 0.2m;

            var prazo = JurosCompostos.CalcularPrazo(capitalInicial, montante, taxaDeJuros);
            
            prazo.Should().Equal(3);
        }

        [Test]
        public void Deve_calcular_capital_inicial()
        {
            var montante = 1728m;
            var taxaDeJuros = 0.2m;
            var prazo = 3;

            var capitalInicial = JurosCompostos.CalcularCapitalInicial(montante, taxaDeJuros, prazo);

            capitalInicial.Should().Equal(1000m);
        }

        [Test]
        public void Deve_calcular_taxa_de_acumulacao_de_capital()
        {
            var taxaDeJuros = 0.2m;
            var prazo = 3;

            var taxaDeAcumulacaoDeCapital = JurosCompostos.CalcularTaxaDeAcumulacaoDeCapital(taxaDeJuros, prazo);

            taxaDeAcumulacaoDeCapital.Should().Equal(1.728m);
        }
    }
}
