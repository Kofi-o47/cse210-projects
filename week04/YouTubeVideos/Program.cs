using System;

class Program
{
    static void Main(string[] args)
    {
        // Create a list to hold videos
        List<Video> videos = new List<Video>();

        // Create and add first video with comments
        Video video1 = new Video("C# Tutorial for Beginners", "Programming Master", 1200);
        video1.AddComment(new Comment("JohnDoe", "Great tutorial!"));
        video1.AddComment(new Comment("JaneSmith", "Very helpful, thanks!"));
        video1.AddComment(new Comment("CodeNewbie", "I learned so much from this."));
        videos.Add(video1);

        // Create and add second video with comments
        Video video2 = new Video("ASP.NET Core Crash Course", "Web Dev Guru", 1800);
        video2.AddComment(new Comment("WebDeveloper", "Clear explanations."));
        video2.AddComment(new Comment("FrontEndFan", "Would love more examples."));
        video2.AddComment(new Comment("DotNetLover", "Perfect for my skill level."));
        video2.AddComment(new Comment("Student123", "When is the next part coming?"));
        videos.Add(video2);

        // Create and add third video with comments
        Video video3 = new Video("Design Patterns Explained", "Software Architect", 2400);
        video3.AddComment(new Comment("SeniorDev", "Excellent overview."));
        video3.AddComment(new Comment("JuniorDev", "Some concepts are still unclear."));
        video3.AddComment(new Comment("TeamLead", "I'll share this with my team."));
        videos.Add(video3);

        // Create and add fourth video with comments
        Video video4 = new Video("Entity Framework Basics", "Database Expert", 900);
        video4.AddComment(new Comment("DBAnalyst", "Very practical examples."));
        video4.AddComment(new Comment("ORMFan", "Simplified a complex topic."));
        videos.Add(video4);

        // Display information for each video
        foreach (var video in videos)
        {
            video.DisplayVideoInfo();
    }
    }
public class Comment
{
    // Properties
    public string CommenterName { get; set; }
    public string CommentText { get; set; }

    // Constructor
    public Comment(string commenterName, string commentText)
    {
        CommenterName = commenterName;
        CommentText = commentText;
    }

    // Method to display the comment
    public override string ToString()
    {
        return $"{CommenterName}: {CommentText}";
    }
}

// Video class to represent a YouTube video
public class Video
{
    // Properties
    public string Title { get; set; }
    public string Author { get; set; }
    public int LengthInSeconds { get; set; }
    private List<Comment> Comments { get; } = new List<Comment>();

    // Constructor
    public Video(string title, string author, int lengthInSeconds)
    {
        Title = title;
        Author = author;
        LengthInSeconds = lengthInSeconds;
    }

    // Method to add a comment
    public void AddComment(Comment comment)
    {
        Comments.Add(comment);
    }

    // Method to get the number of comments
    public int GetNumberOfComments()
    {
        return Comments.Count;
    }

    // Method to display all comments
    public void DisplayComments()
    {
        foreach (var comment in Comments)
        {
            Console.WriteLine($" - {comment}");
        }
    }

    // Method to display video information
    public void DisplayVideoInfo()
    {
        Console.WriteLine($"Title: {Title}");
        Console.WriteLine($"Author: {Author}");
        Console.WriteLine($"Length: {LengthInSeconds} seconds");
        Console.WriteLine($"Number of comments: {GetNumberOfComments()}");
        Console.WriteLine("Comments:");
        DisplayComments();
        Console.WriteLine();
    }
}
}