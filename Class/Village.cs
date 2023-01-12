class Village
{
    private string _name;
    private Ressources _myRessources;
    public House chefHome;
    public int villageois = 0;
    public House[] listHouse;
    public Mine myMine;
    public Forest myForest;

    public Village(string name)
    {
        this._name = name;
        this._myRessources = new Ressources();
        this.chefHome = new House();
        this.villageois += House.villageois;
        this.listHouse = new House[] { this.chefHome };
        this.myMine = new Mine();
        this.myForest = new Forest();
    }

    public string getName()
    {
        return _name;
    }
    public int getWood()
    {
        return _myRessources.getWood();
    }

    public int getStone()
    {
        return _myRessources.getStone();
    }
    private void addHouse()
    {
        Array.Resize(ref listHouse, listHouse.Length + 1);
        listHouse[listHouse.Length - 1] = new House();
        this.villageois += House.villageois;
    }
    public void mineStone(int villagers)
    {
        if (villagers > this.villageois)
        {
            System.Console.WriteLine("Not enough villagers");
            return;
        }
        if (_myRessources.getWood() < (villagers * Mine.wood_cost))
        {
            Console.WriteLine("Not enough wood");
            return;
        }
        if (_myRessources.getStone() < (villagers * Mine.stone_cost))
        {
            Console.WriteLine("Not enough stone");
            return;
        }
        _myRessources.useWood(villagers * Mine.wood_cost);
        _myRessources.useStone(villagers * Mine.stone_cost);
        _myRessources.addStone(myMine.mineStone(villagers));
    }
    public void cutWood(int villagers)
    {
        if (villagers > this.villageois)
        {
            System.Console.WriteLine("Not enough villagers");
            return;
        }
        if (_myRessources.getWood() < (villagers * Forest.wood_cost))
        {
            Console.WriteLine("Not enough wood");
            return;
        }
        if (_myRessources.getStone() < (villagers * Forest.stone_cost))
        {
            Console.WriteLine("Not enough stone");
            return;
        }
        _myRessources.useWood(villagers * Forest.wood_cost);
        _myRessources.useStone(villagers * Forest.stone_cost);
        _myRessources.addWood(myForest.cutWood(villagers));
    }

    public void buildHouse(int nbr)
    {
        int woodNeeded = nbr * House.wood_needed;
        int stoneNeeded = nbr * House.stone_needed;

        // check ressources suffisantes pour les maisons
        if (woodNeeded > _myRessources.getWood() || stoneNeeded > _myRessources.getStone())
        {
            // Erreur
            System.Console.WriteLine("Not enough ressources.");
        }
        else
        {
            // update des ressources
            _myRessources.useWood(woodNeeded);
            _myRessources.useStone(stoneNeeded);

            // Création des houses
            for (int i = 0; i < nbr; i++)
            {
                addHouse();
            }
        }

    }
}