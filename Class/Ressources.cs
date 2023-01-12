class Ressources
{
    private int _woods;
    private int _stones;
    public int level;
    private int wood_max;
    private int stones_max;
    private int ressources_max = 250;

    //Constructeur par défaut
    public Ressources()
    {
        _woods = 10;
        _stones = 10;
        level = 1;
    }

    // getters
    public int getWood()
    {
        return _woods;
    }

    public int getStone()
    {
        return _stones;
    }


    public void useStone(int nbr)
    {
        if (_stones >= nbr)
        {
            _stones -= nbr;
        }
        else
        {
            Console.WriteLine($"You can't use {nbr} stones, you have only {_stones} stones.");
        }
    }

    public void useWood(int nbr)
    {
        if (_woods >= nbr)
        {
            _woods -= nbr;
        }
        else
        {
            Console.WriteLine($"You can't use {nbr} woods, you have only {_woods} woods.");
        }
    }

    public void addStone(int nbr)
    {
        if ((_stones + nbr) < ressources_max)
            _stones += nbr;
        else
            _stones = ressources_max;

    }
    public void addWood(int nbr)
    {
        if ((_woods + nbr) < ressources_max)
            _woods += nbr;
        else
            _woods = ressources_max;
    }

    public void upgrade()
    {
        _woods = (_woods * 8) / 10;
        _stones = (_stones * 8) / 10;
        ressources_max *= 2;
        level++;
    }


}