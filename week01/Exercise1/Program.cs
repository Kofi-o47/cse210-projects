using System;
using System.Runtime.ExceptionServices;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("What is your first name? ");
        string firstname = Console.ReadLine();


        Console.Write("what is your last name? ");
        string lastname = Console.ReadLine();

        Console.WriteLine($"Your name is {lastname}, {firstname} {lastname}");

    }
}