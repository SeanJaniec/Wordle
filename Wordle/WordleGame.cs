using System;
namespace Wordle
{
	public class WordleGame
	{
        public string SecretWord { get; set; }
		public int MaxGuesses { get; set; } = 10000;

		public WordleGame(string secretWord = "arise")
		{
			SecretWord = secretWord;
		}

		public int Play(IWordleBot bot)
        {
			int guessNumber;
			for(guessNumber = 0; guessNumber < MaxGuesses; guessNumber++)
            {
				string guess = bot.GenerateGuess();
                Console.WriteLine($"guess {guessNumber + 1}: {guess}");

				GuessResult guessResult = CheckGuess(guess);
				bot.Guesses.Add(guessResult);
                Console.WriteLine(guessResult);

				if(IsCorrect(guessResult))
                {
					return guessNumber;
                }
            }

			return guessNumber;
        }

		// TODO
		public GuessResult CheckGuess( string guess )
        {
			GuessResult guessResult = new GuessResult(guess);

			// string[] secretLetters = (string)SecretWord.Split('');

			foreach (LetterGuess letter in guessResult.Guess)
            {
				int index = 0;

				if (guessResult.Guess[index].Equals(SecretWord[index]))
                {
					letter.LetterResult = LetterResult.Correct;
                }
				else if (SecretWord.Contains(guessResult.Guess[index].Letter))
                {
					letter.LetterResult = LetterResult.Misplaced;

				}
                else
                {
					letter.LetterResult = LetterResult.Incorrect;

				}
			}

        

            return guessResult;
        }

		private bool IsCorrect(GuessResult guessResult)
        {
			foreach(var letterGuess in guessResult.Guess)
			{
				if (letterGuess.LetterResult != LetterResult.Correct)
					return false;

			}

			return true;
        }




	}
}

