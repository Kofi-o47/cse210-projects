using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("What is your grade percent? ");
        string grade = Console.ReadLine();
        int grades = int.Parse(grade);

        // percentages and their repective grades 
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

       // sign for percentage grades with displays 
        string sign = "";
        
        int last_digit = grades % 10;

        if (last_digit >= 7)
        {
            sign = "+";
        }
        else if (last_digit < 3)
        {
            sign ="-";
        }

        if (grades >= 93)
        {
            sign = "";
        }

        if (letter == "F")
        {
            sign = "";
        }
        Console.WriteLine($"Your letter garede is :{letter}{sign}.");

        if (grades >= 70)
        {
            Console.WriteLine("Congratulations! You passed the class!");
        }
        else
        {
            Console.WriteLine("Stay Focused and you'll get it next time!");
        }

    }
}