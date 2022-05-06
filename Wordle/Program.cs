using System;

namespace Wordle
{
    class Program
    {
        static void Main(string[] args)
        {
            //var guessResult = new GuessResult("arise");

            //Console.WriteLine(guessResult);

            var bot = new SuperDopeBot();

            var game = new WordleGame("stair");
            
            int guesses = game.Play(bot);

            Console.WriteLine(guesses);


        }
    }
}

