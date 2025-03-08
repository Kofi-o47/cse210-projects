using System;

class Program
{
    static void Main(string[] args)
    {
        DisplayWelcomeMessage();

        string user_input_Name = PromptUser_input_Name();
        int user_input_Number = PromptUser_input_Number();

        int squaredNumber = SquareNumber(user_input_Number);

        DisplayResult(user_input_Name, squaredNumber);
    }

    static void DisplayWelcomeMessage()
    {
        Console.WriteLine("Welcome to the program!");
    }

    static string PromptUser_input_Name()
    {
        Console.Write("Please enter your name: ");
        string name = Console.ReadLine();

        return name;
    }

    static int PromptUser_input_Number()
    {
        Console.Write("Please enter your favorite number: ");
        int number = int.Parse(Console.ReadLine());

        return number;
    }

    static int SquareNumber(int number)
    {
        int square = number * number;
        return square;
    }

    static void DisplayResult(string name, int square)
    {
        Console.WriteLine($"{name}, the square of your number is {square}");
    }
}
    
    
