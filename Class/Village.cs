class Village
{
    private string _name;
    private Ressources _myRessources;
    public House chefHome;
    public int villageois = 0;
    public House[] listHouse;
    public Mine myMine;
    public Forest myForest;
    public bool isPlaying;

    public Village(string name)
    {
        this._name = name;
        this._myRessources = new Ressources();
        this.chefHome = new House();
        this.villageois += House.villageois;
        this.listHouse = new House[] { this.chefHome };
        this.myMine = new Mine();
        this.myForest = new Forest();


        Tools.displayWelcome(_name);
        isPlaying = true;
        while (isPlaying)
        {
            displayMenu();
        }
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
            Tools.displayErrorMessage("Pas assez de villageois...");
            return;
        }
        if (_myRessources.getWood() < (villagers * Mine.wood_cost))
        {
            Tools.displayErrorMessage("Pas assez de bois...");
            return;
        }
        if (_myRessources.getStone() < (villagers * Mine.stone_cost))
        {
            Tools.displayErrorMessage("Pas assez de pierres...");
            return;
        }
        _myRessources.useWood(villagers * Mine.wood_cost);
        _myRessources.useStone(villagers * Mine.stone_cost);
        _myRessources.addStone(myMine.mineStone(villagers));
        Tools.displayValidationMsg();
    }
    public void cutWood(int villagers)
    {
        if (villagers > this.villageois)
        {
            Tools.displayErrorMessage("Pas assez de villageois...");
            return;
        }
        if (_myRessources.getWood() < (villagers * Forest.wood_cost))
        {
            Tools.displayErrorMessage("Pas assez de bois...");
            return;
        }
        if (_myRessources.getStone() < (villagers * Forest.stone_cost))
        {
            Tools.displayErrorMessage("Pas assez de pierres...");
            return;
        }
        _myRessources.useWood(villagers * Forest.wood_cost);
        _myRessources.useStone(villagers * Forest.stone_cost);
        _myRessources.addWood(myForest.cutWood(villagers));
        Tools.displayValidationMsg();
    }

    public void buildHouse(int nbr)
    {
        int woodNeeded = nbr * House.wood_needed;
        int stoneNeeded = nbr * House.stone_needed;

        // check ressources suffisantes pour les maisons
        if (woodNeeded > _myRessources.getWood() || stoneNeeded > _myRessources.getStone())
        {
            // Erreur
            Tools.displayErrorMessage("Il vous manque du bois ou des pierres pour construire ces maisons.");
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
            Tools.displayValidationMsg();
        }
    }
    public void upgradeRessource()
    {
        _myRessources.upgrade();
    }
    public void lookAround()
    {
        if (_myRessources.level >= 1)
        {
            _myRessources.addStone(1);
            _myRessources.addWood(1);
            Tools.displayValidationMsg();
        }
    }
    public void upgradeMine()
    {
        int cost = ((myMine.getLevel() + 1) * Mine.gain_stone) * 10;
        if (_myRessources.getStone() >= cost)
        {
            _myRessources.useStone(cost);
            myMine.upgrade();
            Tools.displayValidationMsg();
        }
        else
        {
            Tools.displayErrorMessage("Pas assez de pierres pour cela.");
        }

    }
    public void upgradeForest()
    {
        int cost = ((myForest.getLevel() + 1) * Forest.gain_wood) * 10;
        if (_myRessources.getWood() >= cost)
        {
            _myRessources.useWood(cost);
            myForest.upgrade();
            Tools.displayValidationMsg();
        }
        else
        {
            Tools.displayErrorMessage("Vous n'avez pas assez de bois pour cela.");
        }

    }
    public void displayMenu()
    {
        System.Console.WriteLine();
        System.Console.WriteLine("##########################################################################################################################");
        displayInfos();
        System.Console.WriteLine("##########################################################################################################################");
        System.Console.WriteLine("1 - Ramasser des pierres à la mine");
        System.Console.WriteLine("2 - Couper du bois");
        System.Console.WriteLine("3 - Construire des maisons");
        System.Console.WriteLine("4 - Augmenter le stockage des ressources");
        System.Console.WriteLine("5 - Agrandir votre forêt");
        System.Console.WriteLine("6 - Agrandir votre mine");
        System.Console.WriteLine("7 - Chercher un peu autour de vous");
        System.Console.WriteLine("8 - Quitter");
        System.Console.WriteLine("##########################################################################################################################");
        System.Console.WriteLine();

        int userInput = Tools.getUserInputInt("Que choisissez-vous de faire ?");

        switch (userInput)
        {
            case 1:
                mineStone(Tools.getUserInputInt("Combien de villageois voulez-vous envoyer à la mine ?"));
                break;
            case 2:
                cutWood(Tools.getUserInputInt("Combien de villageois voulez-vous envoyer couper du bois?"));
                break;
            case 3:
                buildHouse(Tools.getUserInputInt("Combien de maisons voulez-vous construire ?"));
                break;
            case 4:
                upgradeRessource();
                break;
            case 5:
                upgradeForest();
                break;
            case 6:
                upgradeMine();
                break;
            case 7:
                lookAround();
                break;
            case 8:
                isPlaying = false;
                break;
        }
        // Display Error if case != 1 - 8
        if (userInput < 1 || userInput > 8)
            Tools.displayErrorMessage("Vous devez entrer un chiffre entre 1 et 8 pour indiquer votre choix.");
    }
    //  Display All Info Village
    public void displayInfos()
    {
        System.Console.WriteLine($"# NB MAISON : {listHouse.Length} | NB VILLAGEOIS : {villageois} | NB BOIS : {_myRessources.getWood()}/{_myRessources.getWoodMax()} | NB PIERRES : {_myRessources.getStone()}/{_myRessources.getStonesMax()} | NIV RES: {_myRessources.level}  | NIV FORET: {myForest.getLevel()} | NIV MINE: {myMine.getLevel()} #");
    }


}