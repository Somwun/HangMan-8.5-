using System.Security.Cryptography;

namespace HangMan___8._5_
{
    internal class Program
    {      
        static void Main(string[] args)
        {
            int wrongGuess = 0;
            string word = "COMPUTER", guess;
            bool repeat = true, wrong = false;
            List<char> displayWord = new List<char>();
            foreach (char letter in word)
            {
                displayWord.Add('_');
            }
            while (repeat)
            {
                if (wrongGuess == 0)
                    Console.WriteLine("\n\n\n\n\n\n\n");
                for (int i = 0; i < word.Count(); i ++)
                {
                    Console.Write(displayWord[i]);
                }
                Console.WriteLine("");
                guess = Console.ReadLine().ToUpper().Trim();
                while (int.TryParse(guess, out int trash) || guess.Count() != 1 & guess.Count() != word.Count() || displayWord.Contains(guess[0]) & guess.Count() != word.Count())
                {
                    Console.WriteLine("Invalid input");
                    guess = Console.ReadLine().ToLower().Trim();
                }
                if (!word.Contains(guess))
                {
                    wrongGuess += 1;
                    Draw(wrongGuess);
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
                        Draw(wrongGuess);
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
                    Console.Clear();
                }
            }
        }
        static void Draw(int wrongGuess)
        {
            switch (wrongGuess)
            {
                case 1:
                    Console.Clear();
                    Console.WriteLine("  +---+\r\n  |   |\r\n      |\r\n      |\r\n      |\r\n      |\r\n=========");
                    break;
                case 2:
                    Console.Clear();
                    Console.WriteLine("  +---+\r\n  |   |\r\n  O   |\r\n      |\r\n      |\r\n      |\r\n=========");
                    break;
                case 3:
                    Console.Clear();
                    Console.WriteLine("  +---+\r\n  |   |\r\n  O   |\r\n  |   |\r\n      |\r\n      |\r\n=========");
                    break;
                case 4:
                    Console.Clear();
                    Console.WriteLine("  +---+\r\n  |   |\r\n  O   |\r\n /|   |\r\n      |\r\n      |\r\n=========");
                    break;
                case 5:
                    Console.Clear();
                    Console.WriteLine("  +---+\r\n  |   |\r\n  O   |\r\n /|\\  |\r\n      |\r\n      |\r\n=========");
                    break;
                case 6:
                    Console.Clear();
                    Console.WriteLine("  +---+\r\n  |   |\r\n  O   |\r\n /|\\  |\r\n /    |\r\n      |\r\n=========");
                    break;
                case 7:
                    Console.Clear();
                    Console.WriteLine("  +---+\r\n  |   |\r\n  O   |\r\n /|\\  |\r\n / \\  |\r\n      |\r\n=========");
                    Environment.Exit(0);
                    break;
            }
        }
    }
}