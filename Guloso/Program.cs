class Container(int width, int length)
{
    public int Width { get; } = width;
    public int Length { get; } = length;
}

class BinPacking
{
    static int GulosoBinPacking(List<Container> containers, int shipWidth, int shipLength)
    {
        containers.Sort((a, b) => b.Width.CompareTo(a.Width)); // Ordena os containers por largura em ordem decrescente

        int nShips = 0;
        List<int> remainingWidth = [shipWidth];
        List<int> remainingLength = [shipLength];

        foreach (var container in containers)
        {
            bool placed = false;

            for (int j = 0; j <= nShips; j++)
            {
                if (container.Width <= remainingWidth[j] && container.Length <= remainingLength[j])
                {
                    remainingWidth[j] -= container.Width;
                    remainingLength[j] -= container.Length;
                    placed = true;
                    break;
                }
            }

            if (!placed)
            {
                nShips++;
                remainingWidth.Add(shipWidth - container.Width);
                remainingLength.Add(shipLength - container.Length);
            }
        }

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

        int result = GulosoBinPacking(containers, shipWidth, shipLength);
        Console.WriteLine($"Número mínimo de navios necessários (Guloso Bin Packing): {result}");
    }
}