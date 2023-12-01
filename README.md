# Bin Packing

Para a fórmula matemática temos:

```
n = (∑wi / b) + 1
```

Onde `n` recebe o número de bins que precisamos para `∑wi` somatoria de wi dividido por `b` que é a capaciadade da bin com a soma de mais uma.

Vamos para um exemplo:

wi = [1,2,3,4]

b = 5

n = (10 / 5) + 1

n = 3

Para esse caso acima não seria necessário a caixa adicional então resolvi melhorar um pouco a fórmula matemática para tratar esse ponto.

```
n = (∑wi / b)

n = (∑wi % b) != 0 ? ++n : n
```

```csharp
static int amountBins(int[] itemSizes, int binSize)
{
    int bins = itemSizes.Sum() / binSize;
    return (itemSizes.Sum() % binSize != 0) ? ++bins : bins;
}
```
