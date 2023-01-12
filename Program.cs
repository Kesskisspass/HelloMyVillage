// See https://aka.ms/new-console-template for more information
// Console.WriteLine("Hello, World!");
// 
void main()
{
    Console.WriteLine(Forest.gain_wood); //affichera 10
    Console.WriteLine(Forest.stone_cost); //affichera 2
    Console.WriteLine(Forest.wood_cost); //affichera 1
    Forest test = new Forest();
    // test.wood_cost // --> erreur
    // test.gain_wood // --> erreur
    // Forest.gain_wood = 123 // --> erreur
    // test.gain_wood = 329 // --> erreur

}
main();