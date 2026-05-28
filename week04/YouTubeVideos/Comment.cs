class Comment
{
    private string _author;
    private string _text;

    public string Author => _author;
    public string Text => _text;

    public Comment(string author, string text)
    {
        _author = author;
        _text = text;
    }
}
