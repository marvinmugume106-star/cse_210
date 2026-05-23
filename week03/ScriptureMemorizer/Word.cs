using System;
using System.Text;

public class Word
{
    private readonly string _originalText;
    public bool IsHidden { get; private set; }

    public Word(string text)
    {
        _originalText = text;
        IsHidden = false;
    }

    public void Hide()
    {
        IsHidden = true;
    }

    public string GetDisplayText()
    {
        if (!IsHidden)
        {
            return _originalText;
        }

        var builder = new StringBuilder(_originalText.Length);

        foreach (char c in _originalText)
        {
            builder.Append(char.IsLetter(c) ? '_' : c);
        }

        return builder.ToString();
    }
}
