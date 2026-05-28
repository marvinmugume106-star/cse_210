using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        var videos = new List<Video>
        {
            CreateVideo("Intro to C#", "Marvin", 300, new[]
            {
                ("Alice", "Great explanation!"),
                ("Bob", "Very helpful, thanks."),
                ("Charlie", "Can you cover loops next?"),
                ("Diana", "I loved the examples.")
            }),

            CreateVideo("OOP Basics", "Marvin", 450, new[]
            {
                ("Ethan", "Clear and concise."),
                ("Fiona", "Loved the examples."),
                ("George", "This helped me a lot."),
                ("Hannah", "Nice explanation of classes.")
            }),

            CreateVideo("Abstraction Explained", "Marvin", 400, new[]
            {
                ("Ian", "Thanks for simplifying it."),
                ("Judy", "I finally get abstraction."),
                ("Ken", "Great video."),
                ("Lara", "This was eye-opening.")
            }),

            CreateVideo("Encapsulation Basics", "Marvin", 380, new[]
            {
                ("Mia", "Encapsulation makes so much sense now."),
                ("Noah", "Very clear examples."),
                ("Olivia", "Thank you for this."),
                ("Paul", "Excellent video.")
            })
        };

        foreach (var video in videos)
        {
            video.DisplayVideoInfo();
            Console.WriteLine();
        }
    }

    private static Video CreateVideo(string title, string author, int lengthSeconds, (string author, string text)[] comments)
    {
        var video = new Video(title, author, lengthSeconds);
        foreach (var comment in comments)
        {
            video.AddComment(new Comment(comment.author, comment.text));
        }
        return video;
    }
}