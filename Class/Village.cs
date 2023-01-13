class Village
{
    private string _name;
    private Ressources _myRessources;
    public House chefHome;
    public int villageois = 0;
    public House[] listHouse;
    public Mine myMine;
    public Forest myForest;
    public Well myWell;
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
        this.myWell = new Well();


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
        if (_myRessources.getWater() < (villagers * Mine.water_cost))
        {
            Tools.displayErrorMessage("Pas assez d'eau...");
            return;
        }
        _myRessources.useWood(villagers * Mine.wood_cost);
        _myRessources.useStone(villagers * Mine.stone_cost);
        _myRessources.useWater(villagers * Mine.water_cost);
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
        if (_myRessources.getWater() < (villagers * Forest.water_cost))
        {
            Tools.displayErrorMessage("Pas assez d'eau...");
            return;
        }
        _myRessources.useWood(villagers * Forest.wood_cost);
        _myRessources.useStone(villagers * Forest.stone_cost);
        _myRessources.useWater(villagers * Forest.water_cost);
        _myRessources.addWood(myForest.cutWood(villagers));
        Tools.displayValidationMsg();
    }
    public void bringWater(int villagers)
    {
        if (villagers > this.villageois)
        {
            Tools.displayErrorMessage("Pas assez de villageois...");
            return;
        }
        if (_myRessources.getWood() < (villagers * Well.wood_cost))
        {
            Tools.displayErrorMessage("Pas assez de bois...");
            return;
        }
        if (_myRessources.getStone() < (villagers * Well.stone_cost))
        {
            Tools.displayErrorMessage("Pas assez de pierres...");
            return;
        }
        if (_myRessources.getWater() < (villagers * Well.water_cost))
        {
            Tools.displayErrorMessage("Pas assez d'eau...");
            return;
        }
        _myRessources.useWood(villagers * Well.wood_cost);
        _myRessources.useStone(villagers * Well.stone_cost);
        _myRessources.useWater(villagers * Well.water_cost);
        _myRessources.addWater(myWell.bringWater(villagers));
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
            _myRessources.addWater(1);
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
    public void upgradeWell()
    {
        int cost = ((myWell.getLevel() + 1) * Well.gain_water) * 10;
        if (_myRessources.getWater() >= cost)
        {
            _myRessources.useWater(cost);
            myWell.upgrade();
            Tools.displayValidationMsg();
        }
        else
        {
            Tools.displayErrorMessage("Vous n'avez pas assez d'eau pour cela.");
        }

    }
    public void displayMenu()
    {
        System.Console.WriteLine();
        displayInfos();
        System.Console.WriteLine("1 - Ramasser des pierres à la mine");
        System.Console.WriteLine("2 - Couper du bois");
        System.Console.WriteLine("3 - Aller chercher de l'eau au puit");
        System.Console.WriteLine("4 - Construire des maisons");
        System.Console.WriteLine("5 - Augmenter le stockage des ressources");
        System.Console.WriteLine("6 - Agrandir votre forêt");
        System.Console.WriteLine("7 - Agrandir votre mine");
        System.Console.WriteLine("8 - Agrandir votre puit");
        System.Console.WriteLine("9 - Chercher un peu autour de vous");
        System.Console.WriteLine("10 - Quitter");
        System.Console.WriteLine("##########################################################################################################################################################");
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
                bringWater(Tools.getUserInputInt("Combien de villageois voulez-vous envoyer chercher de l'eau?"));
                break;
            case 4:
                buildHouse(Tools.getUserInputInt("Combien de maisons voulez-vous construire ?"));
                break;
            case 5:
                upgradeRessource();
                break;
            case 6:
                upgradeForest();
                break;
            case 7:
                upgradeMine();
                break;
            case 8:
                upgradeWell();
                break;
            case 9:
                lookAround();
                break;
            case 10:
                isPlaying = false;
                break;
        }
        // Display Error if case != 1 - 10
        if (userInput < 1 || userInput > 10)
            Tools.displayErrorMessage("Vous devez entrer un nombre entre 1 et 10 pour indiquer votre choix.");
    }
    //  Display All Info Village
    public void displayInfos()
    {
        string infosVillage = $"# NB MAISON : {listHouse.Length} | NB VILLAGEOIS : {villageois} | NB BOIS : {_myRessources.getWood()}/{_myRessources.getWoodMax()} | NB PIERRES : {_myRessources.getStone()}/{_myRessources.getStonesMax()} | NB EAU : {_myRessources.getWater()}/{_myRessources.getWaterMax()} | NIV RES: {_myRessources.level}  | NIV FORET: {myForest.getLevel()} | NIV MINE: {myMine.getLevel()} | NIV EAU: {myWell.getLevel()} #";

        // Boucle pour afficher un ligne "#" de la meme taille que les infos
        for (int i = 0; i < infosVillage.Length; i++)
            System.Console.Write("#");
        System.Console.WriteLine();

        System.Console.WriteLine(infosVillage);

        for (int i = 0; i < infosVillage.Length; i++)
            System.Console.Write("#");
        System.Console.WriteLine();
    }


}