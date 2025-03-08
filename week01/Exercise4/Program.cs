using System;
using System.Collections.Generic;
using System.Globalization;
using System.Security.Cryptography.X509Certificates;
using System.Transactions;

class Program
{
    static void Main(string[] args)
    {
        List<int> numbers = new List<int>();
        
        // user input 
        Console.WriteLine("Enter a list of numbers, type 0 when finihed.");
        int user_input = -1;
        int numbers_of_input = 0;

        while (user_input != 0)
       {
        Console.Write("Enter number: ");
        numbers_of_input = numbers_of_input + 1;

         user_input = int.Parse(Console.ReadLine());
         
         // store number if user_input is not equal to 0
         if (user_input != 0)
         {
            numbers.Add(user_input);
         }

  
       }
       // sum all user input.
         int sum =0;
         foreach(int number in numbers)
         {
           sum += number;
         }

       Console.WriteLine($"The sum is: {sum}");

      double average = numbers.Average();
      Console.WriteLine($"The average is: {average}");

      int largest = numbers.Max();
      Console.WriteLine($"The largest number is: {largest}");

      int smallestPostiveNumber = numbers.Where(x => x > 0).Min();
      Console.WriteLine($"The smallest positive number is : {smallestPostiveNumber}");

      Console.WriteLine("The sorted list is:");
      numbers.Sort();
      foreach (int number in numbers)
      {
        Console.WriteLine(number);
      }
    }
}
       