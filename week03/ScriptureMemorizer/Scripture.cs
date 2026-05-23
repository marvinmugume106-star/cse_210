using System;
using System.Collections.Generic;
using System.Linq;

public class Scripture
{
    private readonly List<Word> _words;
    private readonly Reference _reference;
    private readonly Random _random;

    public Scripture(Reference reference, string text)
    {
        _reference = reference;
        _words = text.Split(' ', StringSplitOptions.RemoveEmptyEntries)
                     .Select(token => new Word(token))
                     .ToList();
        _random = new Random();
    }

    public string GetDisplayText()
    {
        return $"{_reference}\n{string.Join(' ', _words.Select(w => w.GetDisplayText()))}";
    }

    public void HideRandomWords()
    {
        var visibleWords = _words.Where(w => !w.IsHidden).ToList();
        if (!visibleWords.Any())
        {
            return;
        }

        int wordsToHide = Math.Min(3, visibleWords.Count);
        var indexes = Enumerable.Range(0, visibleWords.Count).OrderBy(_ => _random.Next()).Take(wordsToHide);

        foreach (int index in indexes)
        {
            visibleWords[index].Hide();
        }
    }

    public bool IsCompletelyHidden()
    {
        return _words.All(w => w.IsHidden);
    }
}
