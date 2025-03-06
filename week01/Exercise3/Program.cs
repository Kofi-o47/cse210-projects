using System;

class Program
{
    static void Main(string[] args)
    {
        
        
        Random randomGenerator = new Random();
        int magic_number = randomGenerator.Next(1,101);

        string keep_playing = "Yes";

        while(keep_playing =="Yes")
        {
        int guess = -1;
        int guess_count = 0;
        
            while(guess != magic_number)
            {
             Console.Write("What is your guess? ");
             guess = int.Parse(Console.ReadLine());
             guess_count = guess_count + 1;
            

             if(guess < magic_number)
             {
                Console.WriteLine("Higher");
             }
             else if(guess > magic_number)
             {
                Console.WriteLine("Lower");
             }
             else
             {
                Console.WriteLine("You guessed it!");
             }

            }
        Console.WriteLine($"It took you {guess_count} guesses.");
        Console.Write("Would you like to play again (Yes / No)? ");
        keep_playing = Console.ReadLine();
        
        }

        Console.WriteLine("Thank you for playing.Goodbye");
    }
}