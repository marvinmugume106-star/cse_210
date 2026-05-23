using System;
using System.Collections.Generic;

public static class ScriptureLibrary
{
    private static readonly Random _random = new Random();

    private static readonly List<(Reference Reference, string Text)> _scriptures = new()
    {
        (new Reference("Proverbs", 3, 5, 6), "Trust in the Lord with all thine heart; and lean not unto thine own understanding."),
        (new Reference("John", 3, 16), "For God so loved the world, that he gave his only begotten Son, that whosoever believeth in him should not perish, but have everlasting life."),
        (new Reference("Philippians", 4, 13), "I can do all things through Christ which strengtheneth me."),
        (new Reference("Psalm", 23, 1, 6), "The Lord is my shepherd; I shall not want. He maketh me to lie down in green pastures: he leadeth me beside the still waters. He restoreth my soul: he leadeth me in the paths of righteousness for his name's sake. Yea, though I walk through the valley of the shadow of death, I will fear no evil: for thou art with me.")
    };

    public static Scripture GetRandomScripture()
    {
        var scriptureData = _scriptures[_random.Next(_scriptures.Count)];
        return new Scripture(scriptureData.Reference, scriptureData.Text);
    }
}
