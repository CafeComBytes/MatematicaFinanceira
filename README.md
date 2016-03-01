[![Coverage Status](https://coveralls.io/repos/github/CafeComBytes/MatematicaFinanceira/badge.svg?branch=master)](https://coveralls.io/github/CafeComBytes/MatematicaFinanceira?branch=master)

[![Build status](https://ci.appveyor.com/api/projects/status/bypny4trlfnb18px?svg=true)](https://ci.appveyor.com/project/gimoteco/matematicafinanceira)

# MatematicaFinanceira

## Juros simples

``` csharp
using MatematicaFinanceira.Lib;

...

var capitalInicial = 5000m;
var taxaDeJuros = 0.05m;
var prazo = 4;
var juros = 1000m;

JurosSimples.CalcularJuros(capitalInicial, taxaDeJuros, prazo); // 1000m
JurosSimples.CalcularMontante(capitalInicial, taxaDeJuros, prazo); // 6000m
JurosSimples.CalcularTaxaDeJuros(capitalInicial, juros, prazo); // 0.05m
JurosSimples.CalcularPrazo(capitalInicial, juros, taxaDeJuros); // 4
```

## Juros compostos

``` csharp
using MatematicaFinanceira.Lib;

...

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
