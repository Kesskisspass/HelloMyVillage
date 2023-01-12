class Village
{
    private string _name;
    private Ressources _myRessources;
    public House chefHome;
    public int villageois = 0;
    public House[] listHouse;

    public Village(string name)
    {
        this._name = name;
        this._myRessources = new Ressources();
        this.chefHome = new House();
        this.villageois += House.villageois;
        this.listHouse = new House[] { this.chefHome };
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
}