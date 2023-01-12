public class Mine
{
    public static readonly int gain_stone = 10;
    public static readonly int stone_cost = 2;
    public static readonly int wood_cost = 1;

    public Mine()
    {
        Console.WriteLine("Mine created");
    }

    public int mineStone(int villagers)
    {
        return villagers * gain_stone;
    }
}