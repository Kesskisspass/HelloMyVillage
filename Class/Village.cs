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
            displayErrorMessage("Not enough villagers.");
            return;
        }
        if (_myRessources.getWood() < (villagers * Mine.wood_cost))
        {
            displayErrorMessage("Not enough wood.");
            return;
        }
        if (_myRessources.getStone() < (villagers * Mine.stone_cost))
        {
            displayErrorMessage("Not enough stones.");
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
            displayErrorMessage("Not enough villagers.");
            return;
        }
        if (_myRessources.getWood() < (villagers * Forest.wood_cost))
        {
            displayErrorMessage("Not enough wood.");
            return;
        }
        if (_myRessources.getStone() < (villagers * Forest.stone_cost))
        {
            displayErrorMessage("Not enough stones.");
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
            displayErrorMessage("Not enough ressources.");
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
        }
    }
    public void upgradeMine()
    {
        int cout = ((myMine.getLevel() + 1) * Mine.gain_stone) * 10;
        if (_myRessources.getStone() >= cout)
        {
            _myRessources.useStone(cout);
            myMine.upgrade();
        }
        else
        {
            displayErrorMessage("Not enough ressources.");
        }

    }
    public void upgradeForest()
    {
        int cout = ((myForest.getLevel() + 1) * Forest.gain_wood) * 10;
        if (_myRessources.getWood() >= cout)
        {
            _myRessources.useWood(cout);
            myForest.upgrade();
        }
        else
        {
            // System.Console.WriteLine("Not enough ressources.");
            displayErrorMessage("Not enough ressources.");
        }

    }
    public void displayMenu()
    {
        // Console.Clear();
        System.Console.WriteLine();
        System.Console.WriteLine("########################################################################################################################");
        displayInfos();
        System.Console.WriteLine("########################################################################################################################");
        System.Console.WriteLine("1 - Mine Stones");
        System.Console.WriteLine("2 - Cut Wood");
        System.Console.WriteLine("3 - Build House");
        System.Console.WriteLine("4 - Upgrade Ressources");
        System.Console.WriteLine("5 - Upgrade Forest");
        System.Console.WriteLine("6 - Upgrade Mine");
        System.Console.WriteLine("7 - Look Around");
        System.Console.WriteLine("8 - Quitter");
        System.Console.WriteLine("########################################################################################################################");
        System.Console.WriteLine();
        System.Console.WriteLine("Que choisissez-vous faire ?");

        string userInput = Console.ReadLine();

        switch (userInput)
        {
            case "1":
                mineStone(getUserInputInt("Combien de villageois voulez-vous envoyer ?"));
                break;
            case "2":
                cutWood(getUserInputInt("Combien de villageois voulez-vous envoyer ?"));
                break;
            case "3":
                buildHouse(getUserInputInt("Combien de maisons voulez-vous construire ?"));
                break;
            case "4":
                upgradeRessource();
                break;
            case "5":
                upgradeForest();
                break;
            case "6":
                upgradeMine();
                break;
            case "7":
                lookAround();
                break;
            case "8":
                isPlaying = false;
                break;
        }


    }
    //  Display All Info Village
    public void displayInfos()
    {
        System.Console.WriteLine($"# NB HOUSE : {listHouse.Length} | NB VILLAGERS : {villageois} | NB WOOD : {_myRessources.getWood()}/{_myRessources.getWoodMax()} | NB STONES : {_myRessources.getStone()}/{_myRessources.getStonesMax()} | LVL RES: {_myRessources.level}  | LVL FOREST: {myForest.getLevel()} | LVL MINE: {myMine.getLevel()} #");
    }

    // Tools 
    // Input User (string & int)
    static public string getUserInputString(string msg)
    {
        string userInput = "";
        while (userInput.Length == 0)
        {
            System.Console.WriteLine(msg);
            userInput = Console.ReadLine();
        }
        return userInput;
    }
    static public int getUserInputInt(string msg)
    {
        int userInput = -1;
        while (userInput < 0)
        {
            System.Console.WriteLine(msg);
            string userInputString = Console.ReadLine();
            if (int.TryParse(userInputString, out int result))
                userInput = Convert.ToInt32(userInputString);
        }
        return userInput;
    }

    // Error message 
    static public void displayErrorMessage(string msg)
    {
        Console.BackgroundColor = ConsoleColor.Red;
        Console.ForegroundColor = ConsoleColor.Black;
        Console.Write(msg);
        Console.ResetColor();
    }
}