class Ressources
{
    private int _woods;
    private int _stones;
    private int _water;
    public int level;
    private int _wood_max;
    private int _stones_max;
    private int _water_max;
    // private int _ressources_max = 250;

    //Constructeur par défaut
    public Ressources()
    {
        _woods = 10;
        _stones = 10;
        _water = 10;
        level = 1;
        _wood_max = 250;
        _stones_max = 250;
        _water_max = 250;
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
    public int getWoodMax()
    {
        return _wood_max;
    }
    public int getStonesMax()
    {
        return _stones_max;
    }
    public int getWater()
    {
        return _water;
    }
    public int getWaterMax()
    {
        return _water_max;
    }


    public void useStone(int nbr)
    {
        if (_stones >= nbr)
        {
            _stones -= nbr;
        }
        else
        {
            Tools.displayErrorMessage($"Vous ne pouvez pas utiliser {nbr} pierres, vous avez seulement {_stones} pierres.");
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
            Tools.displayErrorMessage($"Vous ne pouvez pas utiliser {nbr} bois, vous avez seulement {_woods} bois.");
        }
    }
    public void useWater(int nbr)
    {
        if (_water >= nbr)
        {
            _water -= nbr;
        }
        else
        {
            Tools.displayErrorMessage($"Vous ne pouvez pas utiliser {nbr} eau, vous avez seulement {_water} eau.");
        }
    }

    public void addStone(int nbr)
    {
        if ((_stones + nbr) < _stones_max)
            _stones += nbr;
        else
            _stones = _stones_max;

    }
    public void addWood(int nbr)
    {
        if ((_woods + nbr) < _wood_max)
            _woods += nbr;
        else
            _woods = _wood_max;
    }
    public void addWater(int nbr)
    {
        if ((_water + nbr) < _water_max)
            _water += nbr;
        else
            _water = _water_max;
    }

    public void upgrade()
    {
        if ((_woods >= (_wood_max * 8 / 10)) && _stones >= (_stones_max * 8 / 10) && _water >= (_water_max * 8 / 10))
        {
            _woods -= (_woods * 8) / 10;
            _stones -= (_stones * 8) / 10;
            _water -= (_water * 8) / 10;
            _wood_max *= 2;
            _stones_max *= 2;
            _water_max *= 2;

            level++;
            Tools.displayValidationMsg();
        }
        else
        {
            Tools.displayErrorMessage("Vous n'avez pas suffisamment de pierres, de bois ou d'eau pour augmenter vos capacités de stockage !");
        }
    }
}