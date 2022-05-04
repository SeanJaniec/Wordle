using System;
using System.Collections.Generic;
using System.IO;



namespace Wordle
{
	public interface IWordleBot
	{
        public List<GuessResult> Guesses { get; set; }

        public string GenerateGuess()
        {
            string guess = "";

            List<char> correctLetters = new List<char>();
            List<char> misplacedLetters = new List<char>();
            List<char> incorrectLetters = new List<char>();


            foreach (GuessResult guessResult in Guesses)
            {
                foreach (LetterGuess letterGuess in guessResult.Guess)
                {
                    if (letterGuess.LetterResult == LetterResult.Correct)
                    {
                        correctLetters.Add(letterGuess.Letter);
                    }
                    else if (letterGuess.LetterResult == LetterResult.Misplaced)
                    {
                        misplacedLetters.Add(letterGuess.Letter);
                    }
                    else
                    {
                        incorrectLetters.Add(letterGuess.Letter);
                    }

                }
            }

            string filePath = @"C:\Users\seanj\OneDrive\Documents\GitHub\Wordle\Wordle\data\english_words_10k_mit.txt";

            string[] lines = File.ReadAllLines(filePath);

            List<string> sixLetterWords = new List<string>();

            foreach (var line in lines)
            {
                if (line.Length == 5)
                {
                    sixLetterWords.Add(line);
                }
            }

            if ((correctLetters.Count + misplacedLetters.Count) == 0)
            {
                guess = "their";
            }

            else if ((correctLetters.Count + misplacedLetters.Count) < 3)
            {

                foreach (char incorrectLetter in incorrectLetters)
                {
                    foreach (string word in sixLetterWords)
                    {
                        if (word.Contains(incorrectLetter))
                        {
                            sixLetterWords.Remove(word);
                        }
                    }
                }




                foreach (string word in sixLetterWords)
                {
                    if (word.Contains(misplacedLetters[4]) && word.Contains(misplacedLetters[3]) && word.Contains(misplacedLetters[2]) && word.Contains(misplacedLetters[1]) && word.Contains(misplacedLetters[0]))
                    {
                        guess = word;
                        return guess;
                    }
                    else if (word.Contains(misplacedLetters[3]) && word.Contains(misplacedLetters[2]) && word.Contains(misplacedLetters[1]) && word.Contains(misplacedLetters[0]))
                    {
                        guess = word;
                        return guess;

                    }
                    else if (word.Contains(misplacedLetters[2]) && word.Contains(misplacedLetters[1]) && word.Contains(misplacedLetters[0]))
                    {
                        guess = word;
                        return guess;

                    }
                    else if (word.Contains(misplacedLetters[1]) && word.Contains(misplacedLetters[0]))
                    {
                        guess = word;
                        return guess;

                    }
                    else if (word.Contains(misplacedLetters[0]))
                    {
                        guess = word;
                        return guess;

                    }
                    else
                    {
                        guess = "clamp";
                    }



                }
            }

            else
            {
                foreach (char incorrectLetter in incorrectLetters)
                {
                    foreach (string word in sixLetterWords)
                    {
                        if (word.Contains(incorrectLetter))
                        {
                            sixLetterWords.Remove(word);
                        }
                    }
                }

                foreach (string word in sixLetterWords)
                {
                    //five kinda right
                    if (word.Contains(correctLetters[4]) && word.Contains(correctLetters[3]) && word.Contains(correctLetters[2]) && word.Contains(correctLetters[1]) && word.Contains(correctLetters[0]))
                    {
                        guess = word;
                        return guess;
                    }
                    else if (word.Contains(misplacedLetters[0]) && word.Contains(correctLetters[3]) && word.Contains(correctLetters[2]) && word.Contains(correctLetters[1]) && word.Contains(correctLetters[0]))
                    {
                        guess = word;
                        return guess;
                    }
                    else if (word.Contains(misplacedLetters[1]) && word.Contains(misplacedLetters[0]) && word.Contains(correctLetters[2]) && word.Contains(correctLetters[1]) && word.Contains(correctLetters[0]))
                    {
                        guess = word;
                        return guess;
                    }

                    else if (word.Contains(misplacedLetters[2]) && word.Contains(misplacedLetters[1]) && word.Contains(misplacedLetters[0]) && word.Contains(correctLetters[1]) && word.Contains(correctLetters[0]))
                    {
                        guess = word;
                        return guess;
                    }
                    else if (word.Contains(misplacedLetters[3]) && word.Contains(misplacedLetters[2]) && word.Contains(misplacedLetters[1]) && word.Contains(misplacedLetters[0]) && word.Contains(correctLetters[0]))
                    {
                        guess = word;
                        return guess;
                    }
                    else if (word.Contains(misplacedLetters[4]) && word.Contains(misplacedLetters[3]) && word.Contains(misplacedLetters[2]) && word.Contains(misplacedLetters[1]) && word.Contains(misplacedLetters[0]))
                    {
                        guess = word;
                        return guess;
                    }

                    //four kinda right
                    else if (word.Contains(correctLetters[3]) && word.Contains(correctLetters[2]) && word.Contains(correctLetters[1]) && word.Contains(correctLetters[0]))
                    {
                        guess = word;
                        return guess;
                    }
                    else if (word.Contains(misplacedLetters[0]) && word.Contains(correctLetters[2]) && word.Contains(correctLetters[1]) && word.Contains(correctLetters[0]))
                    {
                        guess = word;
                        return guess;
                    }
                    else if (word.Contains(misplacedLetters[0]) && word.Contains(misplacedLetters[1]) && word.Contains(correctLetters[1]) && word.Contains(correctLetters[0]))
                    {
                        guess = word;
                        return guess;
                    }
                    else if (word.Contains(misplacedLetters[0]) && word.Contains(misplacedLetters[1]) && word.Contains(misplacedLetters[2]) && word.Contains(correctLetters[0]))
                    {
                        guess = word;
                        return guess;
                    }
                    else if (word.Contains(misplacedLetters[0]) && word.Contains(misplacedLetters[1]) && word.Contains(misplacedLetters[2]) && word.Contains(misplacedLetters[3]))
                    {
                        guess = word;
                        return guess;
                    }
                    // three kinda right
                    else if (word.Contains(correctLetters[2]) && word.Contains(correctLetters[1]) && word.Contains(correctLetters[0]))
                    {
                        guess = word;
                        return guess;
                    }
                    else if (word.Contains(misplacedLetters[0]) && word.Contains(correctLetters[1]) && word.Contains(correctLetters[0]))
                    {
                        guess = word;
                        return guess;
                    }
                    else if (word.Contains(misplacedLetters[0]) && word.Contains(misplacedLetters[1]) && word.Contains(correctLetters[0]))
                    {
                        guess = word;
                        return guess;
                    }
                    else if (word.Contains(misplacedLetters[0]) && word.Contains(misplacedLetters[1]) && word.Contains(misplacedLetters[2]))
                    {
                        guess = word;
                        return guess;
                    }




                }
            }





            return guess;

        }

        public bool IsValidWord(string word) {

            string filePath = @"C:\Users\seanj\OneDrive\Documents\GitHub\Wordle\Wordle\data\english_words_10k_mit.txt";

            string[] lines = File.ReadAllLines(filePath);

            int linesLength = lines.Length;
            while(linesLength != 0)
            {
                if (lines[linesLength] == word)
                {
                    return true;
                }
                linesLength--;
            }

            return false;
           
        }

    }
}

