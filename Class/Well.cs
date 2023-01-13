class Well
{
    public static readonly int gain_water = 10;
    public static readonly int wood_cost = 2;
    public static readonly int stone_cost = 2;
    public static readonly int water_cost = 1;
    private int level = 1;
    public int bringWater(int villagers)
    {
        return villagers * gain_water * level;
    }
    public int getLevel()
    {
        return level;
    }
    public void upgrade()
    {
        level++;
    }
}