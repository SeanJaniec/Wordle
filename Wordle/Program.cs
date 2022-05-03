using System;
using System.IO;

namespace Wordle
{
    class Program
    {
        static void Main(string[] args)
        {
            //var guessResult = new GuessResult("arise");

            //Console.WriteLine(guessResult);

            string filePath = Directory.GetCurrentDirectory() + "/data/english_words_full.txt";

            Console.WriteLine(filePath);

            int totalGuesses = 0;

            var secretWords = new string[] { "crane", "trash" };

            foreach (var secretWord in secretWords ) {
                var bot = new HumanBot();

                var game = new WordleGame(secretWord);

                int guesses = game.Play(bot);
                Console.WriteLine("Gameover.");
                Console.WriteLine($"Num Guesses: {guesses}");

                totalGuesses += guesses;

            }
            double averageGuesses = (double)totalGuesses / secretWords.Length;
            Console.WriteLine($"Average Guesses: {averageGuesses}");
            Console.WriteLine();
        }
    }
}

