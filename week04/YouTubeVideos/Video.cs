using System;
using System.Collections.Generic;

class Video
{
    private string _title;
    private string _author;
    private int _lengthSeconds;
    private readonly List<Comment> _comments = new List<Comment>();

    public string Title => _title;
    public string Author => _author;
    public int LengthSeconds => _lengthSeconds;

    public Video(string title, string author, int lengthSeconds)
    {
        _title = title;
        _author = author;
        _lengthSeconds = lengthSeconds;
    }

    public void AddComment(Comment comment)
    {
        if (comment == null)
        {
            return;
        }
        _comments.Add(comment);
    }

    public int GetCommentCount()
    {
        return _comments.Count;
    }

    public void DisplayVideoInfo()
    {
        Console.WriteLine($"Title: {Title}");
        Console.WriteLine($"Author: {Author}");
        Console.WriteLine($"Length: {LengthSeconds} seconds");
        Console.WriteLine($"Comments ({GetCommentCount()}):");

        foreach (var comment in _comments)
        {
            Console.WriteLine($"- {comment.Author}: {comment.Text}");
        }
    }
}
