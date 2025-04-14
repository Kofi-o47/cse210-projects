using System;
using System.Collections.Generic;
using System.IO;

namespace EternalQuest
{
    class Program
    {
        static void Main(string[] args)
        {
            GoalManager goalManager = new GoalManager();
            
            Console.WriteLine("Welcome to the Eternal Quest Program!");
            
            bool quit = false;
            while (!quit)
            {
                Console.WriteLine("\nMenu Options:");
                Console.WriteLine("1. Create New Goal");
                Console.WriteLine("2. List Goals");
                Console.WriteLine("3. Save Goals");
                Console.WriteLine("4. Load Goals");
                Console.WriteLine("5. Record Event");
                Console.WriteLine("6. Display Score");
                Console.WriteLine("7. Quit");
                Console.Write("Select a choice from the menu: ");
                
                int choice = int.Parse(Console.ReadLine());
                
                switch (choice)
                {
                    case 1:
                        goalManager.CreateGoal();
                        break;
                    case 2:
                        goalManager.ListGoals();
                        break;
                    case 3:
                        goalManager.SaveGoals();
                        break;
                    case 4:
                        goalManager.LoadGoals();
                        break;
                    case 5:
                        goalManager.RecordEvent();
                        break;
                    case 6:
                        goalManager.DisplayScore();
                        break;
                    case 7:
                        quit = true;
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
            
            Console.WriteLine("Goodbye!");
        }
    }

    public class GoalManager
    {
        private List<Goal> _goals;
        private int _score;

        public GoalManager()
        {
            _goals = new List<Goal>();
            _score = 0;
        }

        public void CreateGoal()
        {
            Console.WriteLine("The types of Goals are:");
            Console.WriteLine("1. Simple Goal");
            Console.WriteLine("2. Eternal Goal");
            Console.WriteLine("3. Checklist Goal");
            Console.Write("Which type of goal would you like to create? ");
            int choice = int.Parse(Console.ReadLine());

            Console.Write("What is the name of your goal? ");
            string name = Console.ReadLine();
            Console.Write("What is a short description of it? ");
            string description = Console.ReadLine();
            Console.Write("What is the amount of points associated with this goal? ");
            int points = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    _goals.Add(new SimpleGoal(name, description, points));
                    break;
                case 2:
                    _goals.Add(new EternalGoal(name, description, points));
                    break;
                case 3:
                    Console.Write("How many times does this goal need to be accomplished for a bonus? ");
                    int target = int.Parse(Console.ReadLine());
                    Console.Write("What is the bonus for accomplishing it that many times? ");
                    int bonus = int.Parse(Console.ReadLine());
                    _goals.Add(new ChecklistGoal(name, description, points, target, bonus));
                    break;
                default:
                    Console.WriteLine("Invalid choice.");
                    break;
            }
        }

        public void ListGoals()
        {
            Console.WriteLine("The goals are:");
            for (int i = 0; i < _goals.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {_goals[i].GetDetailsString()}");
            }
        }

        public void RecordEvent()
        {
            ListGoals();
            Console.Write("Which goal did you accomplish? ");
            int choice = int.Parse(Console.ReadLine()) - 1;

            if (choice >= 0 && choice < _goals.Count)
            {
                int pointsEarned = _goals[choice].RecordEvent();
                _score += pointsEarned;
                Console.WriteLine($"Congratulations! You have earned {pointsEarned} points!");
                Console.WriteLine($"You now have {_score} points.");
            }
            else
            {
                Console.WriteLine("Invalid goal selection.");
            }
        }

        public void DisplayScore()
        {
            Console.WriteLine($"You have {_score} points.");
        }

        public void SaveGoals()
        {
            Console.Write("What is the filename for the goal file? ");
            string filename = Console.ReadLine();

            using (StreamWriter outputFile = new StreamWriter(filename))
            {
                outputFile.WriteLine(_score);
                foreach (Goal goal in _goals)
                {
                    outputFile.WriteLine(goal.GetStringRepresentation());
                }
            }
        }

        public void LoadGoals()
        {
            Console.Write("What is the filename for the goal file? ");
            string filename = Console.ReadLine();

            if (File.Exists(filename))
            {
                string[] lines = File.ReadAllLines(filename);
                _score = int.Parse(lines[0]);

                _goals.Clear();
                for (int i = 1; i < lines.Length; i++)
                {
                    string[] parts = lines[i].Split(':');
                    string type = parts[0];
                    string[] details = parts[1].Split(',');

                    switch (type)
                    {
                        case "SimpleGoal":
                            bool isComplete = bool.Parse(details[3]);
                            var simpleGoal = new SimpleGoal(details[0], details[1], int.Parse(details[2]));
                            if (isComplete) simpleGoal.RecordEvent();
                            _goals.Add(simpleGoal);
                            break;
                        case "EternalGoal":
                            _goals.Add(new EternalGoal(details[0], details[1], int.Parse(details[2])));
                            break;
                        case "ChecklistGoal":
                            var checklistGoal = new ChecklistGoal(
                                details[0], details[1], 
                                int.Parse(details[2]), 
                                int.Parse(details[4]), 
                                int.Parse(details[3]));
                            for (int j = 0; j < int.Parse(details[5]); j++)
                            {
                                checklistGoal.RecordEvent();
                            }
                            _goals.Add(checklistGoal);
                            break;
                    }
                }
            }
        }
    }

    public abstract class Goal
    {
        protected string _name;
        protected string _description;
        protected int _points;
        protected bool _isComplete;

        public Goal(string name, string description, int points)
        {
            _name = name;
            _description = description;
            _points = points;
            _isComplete = false;
        }

        public abstract int RecordEvent();
        public abstract string GetDetailsString();
        public abstract string GetStringRepresentation();

        public bool IsComplete()
        {
            return _isComplete;
        }

        public string GetName()
        {
            return _name;
        }
    }

    public class SimpleGoal : Goal
    {
        public SimpleGoal(string name, string description, int points) 
            : base(name, description, points)
        {
        }

        public override int RecordEvent()
        {
            if (!_isComplete)
            {
                _isComplete = true;
                return _points;
            }
            return 0;
        }

        public override string GetDetailsString()
        {
            return $"[{(_isComplete ? "X" : " ")}] {_name} ({_description})";
        }

        public override string GetStringRepresentation()
        {
            return $"SimpleGoal:{_name},{_description},{_points},{_isComplete}";
        }
    }

    public class EternalGoal : Goal
    {
        public EternalGoal(string name, string description, int points) 
            : base(name, description, points)
        {
        }

        public override int RecordEvent()
        {
            return _points;
        }

        public override string GetDetailsString()
        {
            return $"[ ] {_name} ({_description})";
        }

        public override string GetStringRepresentation()
        {
            return $"EternalGoal:{_name},{_description},{_points}";
        }
    }

    public class ChecklistGoal : Goal
    {
        private int _amountCompleted;
        private int _target;
        private int _bonus;

        public ChecklistGoal(string name, string description, int points, int target, int bonus) 
            : base(name, description, points)
        {
            _amountCompleted = 0;
            _target = target-1;
            _bonus = bonus;
        }

        public override int RecordEvent()
        {
            if (!_isComplete)
            {
                _amountCompleted++;
                if (_amountCompleted >= _target)
                {
                    _isComplete = true;
                    return _points + _bonus;
                }
                return _points;
            }
            return 0;
        }

        public override string GetDetailsString()
        {
            return $"[{(_isComplete ? "X" : " ")}] {_name} ({_description}) -- Completed {_amountCompleted}/{_target}";
        }

        public override string GetStringRepresentation()
        {
            return $"ChecklistGoal:{_name},{_description},{_points},{_bonus},{_target},{_amountCompleted}";
        }
    }
}