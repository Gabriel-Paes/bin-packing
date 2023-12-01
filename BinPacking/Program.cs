int[] values = [500, 300, 400, 700];
int capacity = 1000;

int n = amountBins(values, capacity);

Console.WriteLine(n);

var results = BinPacking(values, capacity);

foreach (var (prd1, prd2, tot) in results)
{
    Console.WriteLine("{0} + {1} = {2}", prd1, prd2, tot);
}

static int amountBins(int[] itemSizes, int binSize)
{
    int bins = itemSizes.Sum() / binSize;
    return (itemSizes.Sum() % binSize != 0) ? ++bins : bins;
}

static List<(int prd1, int prd2, int tot)> BinPacking(int[] itemSizes, int binSize)
{
    List<(int prd1, int prd2, int tot)> results = [];

    for (int i = 0; i < itemSizes.Length; i++)
    {
        for (int j = i + 1; j < itemSizes.Length; j++)
        {
            if (itemSizes[i] + itemSizes[j] <= binSize)
            {
                results.Add((itemSizes[i], itemSizes[j], itemSizes[i] + itemSizes[j]));
            } else if (itemSizes[i] <= binSize) {
                results.Add((itemSizes[i], 0, itemSizes[i]));
            }
        }
    }

    results.Sort((a, b) => b.tot - a.tot);

    return results;
}