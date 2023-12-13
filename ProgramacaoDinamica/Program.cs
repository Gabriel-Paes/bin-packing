class Container(int width, int length)
{
    public int Width { get; } = width;
    public int Length { get; } = length;
}

class BinPackingDynamicProgramming
{
    static int MinShips(List<Container> containers, int shipWidth, int shipLength)
    {
        int nContainers = containers.Count;
        int[,] dp = new int[nContainers + 1, shipWidth + 1];

        for (int i = 1; i <= nContainers; i++)
        {
            for (int j = 0; j <= shipWidth; j++)
            {
                dp[i, j] = dp[i - 1, j]; // Caso não incluir o container i no navio atual

                if (j >= containers[i - 1].Width && dp[i - 1, j - containers[i - 1].Width] + containers[i - 1].Length > dp[i, j])
                {
                    dp[i, j] = dp[i - 1, j - containers[i - 1].Width] + containers[i - 1].Length;
                }
            }
        }

        int maxShipLength = 0;
        for (int j = 0; j <= shipWidth; j++)
        {
            if (dp[nContainers, j] > maxShipLength)
            {
                maxShipLength = dp[nContainers, j];
            }
        }

        int nShips = (int)Math.Ceiling((double)maxShipLength / shipLength);
        return nShips;
    }

    static void Main()
    {
        List<Container> containers =
        [
            new Container(2, 3),
            new Container(1, 2),
            new Container(3, 4),
            new Container(2, 2),
            new Container(1, 1)
        ];

        int shipWidth = 5;
        int shipLength = 5;

        int result = MinShips(containers, shipWidth, shipLength);
        Console.WriteLine($"Número mínimo de navios necessários (Dynamic Programming): {result}");
    }
}