using System;

class Program
{
    static void Main(string[] args)
    {
        Scripture scripture = ScriptureLibrary.GetRandomScripture();

        while (true)
        {
            Console.Clear();
            Console.WriteLine("Scripture Memorizer");
            Console.WriteLine("===================\n");
            Console.WriteLine(scripture.GetDisplayText());
            Console.WriteLine("\nPress Enter to hide words or type 'quit' to exit.");
            string input = Console.ReadLine();

            if (input != null && input.Trim().Equals("quit", StringComparison.OrdinalIgnoreCase))
            {
                break;
            }

            scripture.HideRandomWords();

            if (scripture.IsCompletelyHidden())
            {
                Console.Clear();
                Console.WriteLine(scripture.GetDisplayText());
                Console.WriteLine("\nAll words are hidden. Program ending.");
                break;
            }
        }
    }
}

/*
===========================================================
EXCEEDING REQUIREMENTS (Creativity Beyond Core Design)
-----------------------------------------------------------
1. Added a ScriptureLibrary with multiple scriptures so the program selects a passage at random.
2. Uses Reference, Scripture, and Word classes with encapsulation and multiple constructors.
3. Hides only still-visible words and preserves punctuation while replacing letters with underscores.
===========================================================
*/
