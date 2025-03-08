using System;
using System.Runtime.ExceptionServices;

class Program
{
    static void Main(string[] args)
    {
        // user input for first name 
        Console.Write("What is your first name? ");
        string firstname = Console.ReadLine();

       // user input for last name 
        Console.Write("what is your last name? ");
        string lastname = Console.ReadLine();
        
        // display for first and last name 
        Console.WriteLine($"Your name is {lastname}, {firstname} {lastname}.");

    }
}