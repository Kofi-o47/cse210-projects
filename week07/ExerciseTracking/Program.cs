using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // Create a list of activities
        List<Activity> activities = new List<Activity>
        {
            new Running(new DateTime(2023, 11, 3), 30, 3.0),      // 3.0 miles in 30 minutes
            new StationaryBike(new DateTime(2023, 11, 4), 45, 15), // 15 mph for 45 minutes
            new Swimming(new DateTime(2023, 11, 5), 60, 30)        // 30 laps in 60 minutes
        };

        // Display activity summaries
        Console.WriteLine("Exercise Activity Tracking");
        Console.WriteLine("=========================");
        Console.WriteLine();

        foreach (var activity in activities)
        {
            Console.WriteLine(activity.GetSummary());
            Console.WriteLine();
        }
    }
}

// Base Activity class
public abstract class Activity
{
    private DateTime _date;
    private int _durationMinutes; // in minutes

    protected Activity(DateTime date, int durationMinutes)
    {
        _date = date;
        _durationMinutes = durationMinutes;
    }

    public DateTime Date => _date;
    public int DurationMinutes => _durationMinutes;

    // Abstract methods to be implemented by derived classes
    public abstract double GetDistance(); // in miles
    public abstract double GetSpeed();    // in mph
    public abstract double GetPace();     // in min/mile

    // Virtual method that can be overridden by derived classes
    public virtual string GetSummary()
    {
        return $"{Date:dd MMM yyyy} {GetType().Name} ({DurationMinutes} min): " +
               $"Distance {GetDistance():0.0} miles, " +
               $"Speed {GetSpeed():0.0} mph, " +
               $"Pace {GetPace():0.0} min/mile";
    }
}

// Running activity class
public class Running : Activity
{
    private double _distance; // in miles

    public Running(DateTime date, int durationMinutes, double distance)
        : base(date, durationMinutes)
    {
        _distance = distance;
    }

    public override double GetDistance() => _distance;
    public override double GetSpeed() => (_distance / DurationMinutes) * 60;
    public override double GetPace() => DurationMinutes / _distance;
}

// Stationary Bike activity class
public class StationaryBike : Activity
{
    private double _speed; // in mph

    public StationaryBike(DateTime date, int durationMinutes, double speed)
        : base(date, durationMinutes)
    {
        _speed = speed;
    }

    public override double GetDistance() => (_speed * DurationMinutes) / 60;
    public override double GetSpeed() => _speed;
    public override double GetPace() => 60 / _speed;
}

// Swimming activity class
public class Swimming : Activity
{
    private int _laps;
    private const double LapLengthMeters = 50;
    private const double MetersToMiles = 0.000621371;

    public Swimming(DateTime date, int durationMinutes, int laps)
        : base(date, durationMinutes)
    {
        _laps = laps;
    }

    public override double GetDistance() => (_laps * LapLengthMeters) * MetersToMiles;
    public override double GetSpeed() => (GetDistance() / DurationMinutes) * 60;
    public override double GetPace() => DurationMinutes / GetDistance();
}