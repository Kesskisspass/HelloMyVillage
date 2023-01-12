class Tools
{
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

    // Valid Action msg
    static public void displayValidationMsg()
    {
        var rnd = new Random();
        string[] congrats = { "Joli travail !", "Félicitations !", "Bien joué !", "Impressionnant !", "Incroyable !", "Fantastique !", "Trop fort !", "Chapeau bas !", "Sortez le champagne !" };
        var randomIndex = rnd.Next(congrats.Length);
        string validationMessage = congrats[randomIndex];
        Console.BackgroundColor = ConsoleColor.Green;
        Console.ForegroundColor = ConsoleColor.Black;
        Console.Write(validationMessage);
        Console.ResetColor();
        System.Console.WriteLine();

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