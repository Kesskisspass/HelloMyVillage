class Tools
{
    // Tools utilisés pour l'app

    // Input User (string & int)
    // A utiliser lorsqu'on a besoin d'un input user de type String
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

    // A utiliser lorsqu'on a besoin d'un input user de type Int
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
    // Renvoie un message felicitation random lorsqu'une action utilisateur a reussi
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
    // Renvoie le msg en parametre en rouge (action utilisateur n'a pas pu aboutir)
    static public void displayErrorMessage(string msg)
    {
        Console.BackgroundColor = ConsoleColor.Red;
        Console.ForegroundColor = ConsoleColor.Black;
        Console.Write(msg);
        Console.ResetColor();
        System.Console.WriteLine();
    }
}