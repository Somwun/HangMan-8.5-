using System.Security.Cryptography;

namespace HangMan___8._5_
{
    internal class Program
    {      
        static void Main(string[] args)
        {
            List<string> words = new List<string>() {"COMPUTER", "BROKEN", "FETUS", "HANGMAN", "CHRISTMAS", "HALLOWEEN", "LUNG", "SNAKE", "PILLOW", "HIPPO", "LETTER", "WORD", "OFFICE", "SCHOOL", "NEW", "WHILE", "LEEP", "LONG", "PILLATES", "VISUAL", "STUDIO", "FOREHEAD", "PROGRAM", "BUTTHOLE" };
            Random genorator = new Random();
            int wrongGuess = 0, totalGuesses = 0;
            string word = words[genorator.Next(words.Count())], guess, userInput;
            bool repeat = true, wrong = false;
            List<char> displayWord = new List<char>();
            List<char> guesses = new List<char>();

            foreach (char letter in word)
            {
                displayWord.Add('_');
            }
            while (repeat)
            {
                if (totalGuesses == 0)
                    WriteGuesses(guesses);
                if (wrongGuess == 0)
                    Console.WriteLine("\n\n\n\n\n\n\n");
                for (int i = 0; i < word.Count(); i ++)
                {
                    Console.Write(displayWord[i]);
                }
                Console.WriteLine("");
                guess = Console.ReadLine().ToUpper().Trim();
                while (int.TryParse(guess, out int trash) || guess.Count() != 1 || displayWord.Contains(guess[0])|| guesses.Contains(guess[0]))
                {
                    if (guess == word)
                        break;
                    Console.WriteLine("Invalid input");
                    guess = Console.ReadLine().ToUpper().Trim();
                }
                totalGuesses++;
                if (!word.Contains(guess))
                {
                    wrongGuess += 1;
                    guesses.Add(guess[0]);
                    Draw(wrongGuess, guesses);
                }
                else if (word == guess)
                {
                    for (int i = 0; i < word.Count(); i++)
                    {
                        displayWord[i] = word[i];
                    }
                }
                else if (word.Count() == guess.Count())
                {
                    for (int i = 0; i < word.Count(); i++)
                    {
                        if (displayWord[i] != word[i])
                        {
                            wrong = true;
                        }
                    }
                    if (wrong == true)
                    {
                        wrongGuess += 1;
                        guesses.Add(guess.ToUpper()[0]);
                        Draw(wrongGuess, guesses);
                    }
                }
                else
                {
                    for (int i = 0; i < word.Count(); i ++)
                    {
                        if (word[i] == guess[0])
                        {
                            displayWord[i] = word[i];
                        }
                    }
                    Draw(wrongGuess, guesses);
                }
                if (!displayWord.Contains('_') || wrongGuess == 7)
                {
                    if (guess != word)
                    {
                        for (int i = 0; i < word.Count(); i++)
                        {
                            Console.Write(displayWord[i]);
                        }
                    }
                    Console.WriteLine();
                    switch (wrongGuess)
                    {
                        case 0:
                            Console.WriteLine("Wow, you're not stupid!");
                            break;
                        case <= 3:
                            Console.WriteLine("Wow, you're only kind of stupid!");
                            break;
                        case <= 5:
                            Console.WriteLine("Wow, you're pretty stupid, but you still got it so yay!");
                            break;
                        case 6:
                            Console.WriteLine("I don't even know how you can read let alone play hangman, but I guess you still won so... yay");
                            break;
                        case 7:
                            Console.WriteLine($"Ha, stupid\nHow did you not know the word was {word.ToLower()}?");
                            break;
                    }
                    Console.WriteLine("Type quit to exit, or press enter to continue");
                    userInput = Console.ReadLine().ToLower().Trim();
                    if (userInput == "quit")
                        repeat = false;
                    else
                    {
                        Console.Clear();
                        word = words[genorator.Next(words.Count())];
                        displayWord.Clear();
                        foreach (char letter in word)
                        {
                            displayWord.Add('_');
                        }
                        wrongGuess = 0;
                        totalGuesses = 0;
                        guesses.Clear();
                    }
                }
            }
        }
        static void Draw(int wrongGuess, List<char> guesses)
        {
            Console.Clear();
            WriteGuesses(guesses);
            switch (wrongGuess)
            {
                case 1:
                    Console.WriteLine("  +---+\r\n  |   |\r\n      |\r\n      |\r\n      |\r\n      |\r\n=========");
                    break;
                case 2:
                    Console.WriteLine("  +---+\r\n  |   |\r\n  O   |\r\n      |\r\n      |\r\n      |\r\n=========");
                    break;
                case 3:
                    Console.WriteLine("  +---+\r\n  |   |\r\n  O   |\r\n  |   |\r\n      |\r\n      |\r\n=========");
                    break;
                case 4:
                    Console.WriteLine("  +---+\r\n  |   |\r\n  O   |\r\n /|   |\r\n      |\r\n      |\r\n=========");
                    break;
                case 5:
                    Console.WriteLine("  +---+\r\n  |   |\r\n  O   |\r\n /|\\  |\r\n      |\r\n      |\r\n=========");
                    break;
                case 6:
                    Console.WriteLine("  +---+\r\n  |   |\r\n  O   |\r\n /|\\  |\r\n /    |\r\n      |\r\n=========");
                    break;
                case 7:
                    Console.WriteLine("  +---+\r\n  |   |\r\n  O   |\r\n /|\\  |\r\n / \\  |\r\n      |\r\n=========");
                    break;
            }
        }
        static void WriteGuesses(List<char> guesses)
        {
            Console.Write("Guesses: ");
            for (int i = 0; i < guesses.Count(); i ++)
            {
                Console.Write($"{guesses[i]} ");
            }
            Console.WriteLine();
        }
    }
}