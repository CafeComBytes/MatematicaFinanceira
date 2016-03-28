[![Coverage Status](https://coveralls.io/repos/github/CafeComBytes/MatematicaFinanceira/badge.svg?branch=master)](https://coveralls.io/github/CafeComBytes/MatematicaFinanceira?branch=master)

[![Build status](https://ci.appveyor.com/api/projects/status/bypny4trlfnb18px?svg=true)](https://ci.appveyor.com/project/gimoteco/matematicafinanceira)

# MatematicaFinanceira

## Usando a biblioteca

Para usar a biblioteca basta baixá-la pelo NuGet e adicionar a referência no projeto.

``` powershell
Install-Package MatematicaFinanceira.Lib
```

e adicionar o namespace da biblioteca no seu código.

``` csharp
using MatematicaFinanceira.Lib;
```

## Juros

### Juros simples

``` csharp

var capitalInicial = 5000m;
var taxaDeJuros = 0.05m;
var prazo = 4;
var juros = 1000m;

JurosSimples.CalcularJuros(capitalInicial, taxaDeJuros, prazo); // 1000m
JurosSimples.CalcularMontante(capitalInicial, taxaDeJuros, prazo); // 6000m
JurosSimples.CalcularTaxaDeJuros(capitalInicial, juros, prazo); // 0.05m
JurosSimples.CalcularPrazo(capitalInicial, juros, taxaDeJuros); // 4
```

### Juros compostos

``` csharp
var capitalInicial = 1000m;
var montante = 1728m;
var prazo = 3;
var taxaDeJuros = 0.2m;

JurosCompostos.CalcularTaxaDeJuros(capitalInicial, montante, prazo); // 0.2m
JurosCompostos.CalcularJuros(capitalInicial, taxaDeJuros, prazo); // 728m
JurosCompostos.CalcularMontante(capitalInicial, taxaDeJuros, prazo); // 1728m
JurosCompostos.CalcularPrazo(capitalInicial, montante, taxaDeJuros); //  3
JurosCompostos.CalcularCapitalInicial(montante, taxaDeJuros, prazo); // 1000m
JurosCompostos.CalcularTaxaDeAcumulacaoDeCapital(taxaDeJuros, prazo); // 1.728m
```

## Sistemas de amortização

Os métodos de cálculo de parcelas para os variados sistemas de amortização retornam listas imutáveis de parcelas.

### Parcela

Uma parcela tem como propriedades juros, amortização, valor da prestação e saldo devedor.
``` csharp
var parcela = new Parcela(juros, amortizacao, saldoDevedor);
Console.WriteLine(parcela.Juros);
Console.WriteLine(parcela.Amortizacao);
Console.WriteLine(parcela.SaldoDevedor);
Console.WriteLine(parcela.Prestacao);
```

### Sistema de amortização constante (SAC)
``` csharp
var parcelas = SistemaDeAmortizacaoConstante.CalcularParcelas(saldoDevedor, taxaDeJuros, prazo);
```
### Sistema de amortização price
``` csharp
var parcelas = SistemaDeAmortizacaoPrice.CalcularParcelas(saldoDevedor, taxaDeJuros, prazo);
```
### Sistema de amortização misto (SAM)
``` csharp
var parcelas = SistemaDeAmortizacaoMisto.CalcularParcelas(saldoDevedor, taxaDeJuros, prazo);
```
