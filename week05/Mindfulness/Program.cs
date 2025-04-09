using System;
using System.Collections.Generic;
using System.Threading;

namespace MindfulnessProgram
{
    // Base Activity class
    public abstract class Activity
    {
        protected string Name { get; set; }
        protected string Description { get; set; }
        protected int Duration { get; set; }

        public void Start()
        {
            Console.Clear();
            Console.WriteLine($"Welcome to the {Name} Activity.");
            Console.WriteLine();
            Console.WriteLine(Description);
            Console.WriteLine();
            Console.Write("How long, in seconds, would you like for your session? ");
            Duration = int.Parse(Console.ReadLine());
            
            Console.WriteLine();
            Console.WriteLine("Get ready to begin...");
            ShowSpinner(3);
        }

        public void End()
        {
            Console.WriteLine();
            Console.WriteLine("Good job!");
            ShowSpinner(3);
            Console.WriteLine($"You have completed the {Name} Activity for {Duration} seconds.");
            ShowSpinner(3);
        }

        protected void ShowSpinner(int seconds)
        {
            for (int i = 0; i < seconds; i++)
            {
                Console.Write("|");
                Thread.Sleep(250);
                Console.Write("\b \b");
                Console.Write("/");
                Thread.Sleep(250);
                Console.Write("\b \b");
                Console.Write("-");
                Thread.Sleep(250);
                Console.Write("\b \b");
                Console.Write("\\");
                Thread.Sleep(250);
                Console.Write("\b \b");
            }
        }

        protected void ShowCountdown(int seconds)
        {
            for (int i = seconds; i > 0; i--)
            {
                Console.Write(i);
                Thread.Sleep(1000);
                Console.Write("\b \b");
            }
        }

        public abstract void Run();
    }

    // Breathing Activity
    public class BreathingActivity : Activity
    {
        public BreathingActivity()
        {
            Name = "Breathing";
            Description = "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.";
        }

        public override void Run()
        {
            Start();
            
            int remainingTime = Duration;
            while (remainingTime > 0)
            {
                Console.WriteLine();
                Console.Write("Breathe in... ");
                ShowCountdown(4);
                remainingTime -= 4;
                
                if (remainingTime <= 0) break;
                
                Console.WriteLine();
                Console.Write("Now breathe out... ");
                ShowCountdown(6);
                remainingTime -= 6;
            }
            
            End();
        }
    }

    // Reflection Activity
    public class ReflectionActivity : Activity
    {
        private List<string> _prompts = new List<string>
        {
            "Think of a time when you stood up for someone else.",
            "Think of a time when you did something really difficult.",
            "Think of a time when you helped someone in need.",
            "Think of a time when you did something truly selfless."
        };

        private List<string> _questions = new List<string>
        {
            "Why was this experience meaningful to you?",
            "Have you ever done anything like this before?",
            "How did you get started?",
            "How did you feel when it was complete?",
            "What made this time different than other times when you were not as successful?",
            "What is your favorite thing about this experience?",
            "What could you learn from this experience that applies to other situations?",
            "What did you learn about yourself through this experience?",
            "How can you keep this experience in mind in the future?"
        };

        public ReflectionActivity()
        {
            Name = "Reflection";
            Description = "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.";
        }

        public override void Run()
        {
            Start();
            
            Console.WriteLine();
            Console.WriteLine("Consider the following prompt:");
            Console.WriteLine();
            Console.WriteLine($"--- {GetRandomPrompt()} ---");
            Console.WriteLine();
            Console.WriteLine("When you have something in mind, press Enter to continue.");
            Console.ReadLine();
            
            Console.WriteLine("Now ponder on each of the following questions as they relate to this experience.");
            Console.Write("You may begin in: ");
            ShowCountdown(5);
            
            Console.Clear();
            
            DateTime endTime = DateTime.Now.AddSeconds(Duration);
            while (DateTime.Now < endTime)
            {
                Console.WriteLine();
                Console.Write(GetRandomQuestion() + " ");
                ShowSpinner(10);
            }
            
            End();
        }

        private string GetRandomPrompt()
        {
            Random random = new Random();
            return _prompts[random.Next(_prompts.Count)];
        }

        private string GetRandomQuestion()
        {
            Random random = new Random();
            return _questions[random.Next(_questions.Count)];
        }
    }

    // Listing Activity
    public class ListingActivity : Activity
    {
        private List<string> _prompts = new List<string>
        {
            "Who are people that you appreciate?",
            "What are personal strengths of yours?",
            "Who are people that you have helped this week?",
            "When have you felt the Holy Ghost this month?",
            "Who are some of your personal heroes?"
        };

        public ListingActivity()
        {
            Name = "Listing";
            Description = "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.";
        }

        public override void Run()
        {
            Start();
            
            Console.WriteLine();
            Console.WriteLine("List as many responses as you can to the following prompt:");
            Console.WriteLine();
            Console.WriteLine($"--- {GetRandomPrompt()} ---");
            Console.WriteLine();
            Console.Write("You may begin in: ");
            ShowCountdown(5);
            Console.WriteLine();
            
            List<string> items = new List<string>();
            DateTime endTime = DateTime.Now.AddSeconds(Duration);
            while (DateTime.Now < endTime)
            {
                Console.Write("> ");
                items.Add(Console.ReadLine());
            }
            
            Console.WriteLine();
            Console.WriteLine($"You listed {items.Count} items!");
            
            End();
        }

        private string GetRandomPrompt()
        {
            Random random = new Random();
            return _prompts[random.Next(_prompts.Count)];
        }
    }

    // Main Program
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Mindfulness Program Menu");
                Console.WriteLine("1. Breathing Activity");
                Console.WriteLine("2. Reflection Activity");
                Console.WriteLine("3. Listing Activity");
                Console.WriteLine("4. Quit");
                Console.Write("Select an activity (1-4): ");
                
                string choice = Console.ReadLine();
                
                Activity activity = null;
                
                switch (choice)
                {
                    case "1":
                        activity = new BreathingActivity();
                        break;
                    case "2":
                        activity = new ReflectionActivity();
                        break;
                    case "3":
                        activity = new ListingActivity();
                        break;
                    case "4":
                        Console.WriteLine("Thank you for using the Mindfulness Program. Goodbye!");
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        Thread.Sleep(1000);
                        continue;
                }
                
                activity.Run();
            }
        }
    }
}