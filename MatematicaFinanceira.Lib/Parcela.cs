using System;

namespace MatematicaFinanceira.Lib
{
    public class Parcela
    {
        public decimal Juros { get; set; }
        public decimal Amortizacao { get; set; }

        public decimal SaldoDevedor { get; set; }
        public decimal Prestacao { get { return Juros + Amortizacao; } }

        public Parcela(decimal juros, decimal amortizacao, decimal saldoDevedor)
        {
            Juros = juros;
            Amortizacao = amortizacao;
            SaldoDevedor = saldoDevedor;
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            var outraParcela = (Parcela)obj;

            return Juros == outraParcela.Juros
                   && Amortizacao == outraParcela.Amortizacao
                   && SaldoDevedor == outraParcela.SaldoDevedor;
        }

        public static bool operator ==(Parcela esquerda, Parcela direita)
        {
            return esquerda.Equals(direita);
        }

        public static bool operator !=(Parcela esquerda, Parcela direita)
        {
            return !(esquerda == direita);
        }
        
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}