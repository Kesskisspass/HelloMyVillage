class Forest
{
    public static readonly int gain_wood = 10;
    public static readonly int stone_cost = 2;
    public static readonly int wood_cost = 1;
    public static readonly int water_cost = 1;
    private int level = 1;
    public int cutWood(int villagers)
    {
        return villagers * gain_wood * level;
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