// See https://aka.ms/new-console-template for more information
// Console.WriteLine("Hello, World!");
// 
void main()
{
    Village myVillage = new Village("Victor le createur");
    myVillage.getName(); // affichera Victor le createur
    Console.WriteLine(myVillage.listHouse.Length); // affichera 1
    // myVillage.addHouse();
    // myVillage.addHouse();
    // Console.WriteLine(myVillage.listHouse.Length); // affichera 3
    Console.WriteLine(myVillage.villageois); // affichera 30

    Console.WriteLine(Mine.gain_stone); // affichera 10
    Console.WriteLine(Mine.stone_cost); // affichera 2
    Console.WriteLine(Mine.wood_cost); // affichera 1

}
main();