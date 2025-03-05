using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("What is your grade percent? ");
        string grade = Console.ReadLine();
        int grades = int.Parse(grade);

        string letter = "";

        if ( grades >= 90 )
        {
            letter = "A";
        }
        else if (grades >= 80)
        {
            letter = "B";
        }
        else if ( grades >= 70)
        {
            letter = "C";
        }
        else if (grades >= 60)
        {
            letter = "D";
        }
        else 
        {
            letter = "F";
        }

        Console.WriteLine($"Your letter grade is: {letter}");

        if (grades >= 70)
        {
            Console.WriteLine("You passed!");
        }
        else
        {
            Console.WriteLine("Better luck next time!");
        }
    }
}