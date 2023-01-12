class Ressources
{
    private int _woods;
    private int _stones;
    //Constructeur par défaut
    public Ressources()
    {
        _woods = 10;
        _stones = 10;
    }

    // Constructeur parametrique (non demandé)
    // public Ressources(int woods, int stones)
    // {
    //     this._woods = woods;
    //     this._stones = stones;
    // }


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
        _stones += nbr;
    }


}