using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Wordle
{
    class SuperDopeBot : IWordleBot
    {
        public List<GuessResult> Guesses { get; set; } = new List<GuessResult>();


        public string GenerateGuess()
        {

            string guess = "";

            List<char> correctLetters = new List<char>();
            List<char> misplacedLetters = new List<char>();
            List<char> incorrectLetters = new List<char>();





            string filePath = @"C:\Users\seanj\OneDrive\Documents\GitHub\Wordle\Wordle\data\english_words_10k_mit.txt";

            string[] lines = File.ReadAllLines(filePath);

            List<string> fiveLetterWords = new List<string>();

            foreach (var line in lines)
            {
                if (line.Length == 5)
                {
                    fiveLetterWords.Add(line);
                }
            }



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

            if (Guesses.Count == 0)
            {
                guess = "their";



            }

            else if ((correctLetters.Count + misplacedLetters.Count) < 3)
            {


                foreach (char incorrectLetter in incorrectLetters)
                {
                    foreach (string word in fiveLetterWords.ToList())
                    {
                        if (word.Contains(incorrectLetter))
                        {
                            fiveLetterWords.Remove(word);
                        }
                    }
                }




                //foreach (string word in fiveLetterWords)
                //{
                //    if (word.Contains(misplacedLetters[4]) && word.Contains(misplacedLetters[3]) && word.Contains(misplacedLetters[2]) && word.Contains(misplacedLetters[1]) && word.Contains(misplacedLetters[0]))
                //    {
                //        guess = word;
                //        return guess;
                //    }
                //    else if (word.Contains(misplacedLetters[3]) && word.Contains(misplacedLetters[2]) && word.Contains(misplacedLetters[1]) && word.Contains(misplacedLetters[0]))
                //    {
                //        guess = word;
                //        return guess;

                //    }
                //    else if (word.Contains(misplacedLetters[2]) && word.Contains(misplacedLetters[1]) && word.Contains(misplacedLetters[0]))
                //    {
                //        guess = word;
                //        return guess;

                //    }
                //    else if (word.Contains(misplacedLetters[1]) && word.Contains(misplacedLetters[0]))
                //    {
                //        guess = word;
                //        return guess;

                //    }
                //    else if (word.Contains(misplacedLetters[0]))
                //    {
                //        guess = word;
                //        return guess;

                //    }
                //    else
                //    {
                //        guess = "clamp";
                //    }



                //}
                guess = fiveLetterWords[0];

            }
            else
            {
                //foreach (string word in fiveLetterWords)
                //{
                //    foreach (char incorrectLetter in incorrectLetters)
                //    {
                //        if (word.Contains(incorrectLetter))
                //        {
                //            fiveLetterWords.Remove(word);
                //        }
                //    }
                //}
                int guessNum = 0;
                foreach(GuessResult guessResult in Guesses)
                {
                    guessNum++;
                }
                guess = fiveLetterWords[guessNum];

                //foreach (string word in fiveLetterWords)
                //{
                //    //five kinda right
                //    if (word.Contains(correctLetters[4]) && word.Contains(correctLetters[3]) && word.Contains(correctLetters[2]) && word.Contains(correctLetters[1]) && word.Contains(correctLetters[0]))
                //    {
                //        guess = word;
                //        return guess;
                //    }
                //    else if (word.Contains(misplacedLetters[0]) && word.Contains(correctLetters[3]) && word.Contains(correctLetters[2]) && word.Contains(correctLetters[1]) && word.Contains(correctLetters[0]))
                //    {
                //        guess = word;
                //        return guess;
                //    }
                //    else if (word.Contains(misplacedLetters[1]) && word.Contains(misplacedLetters[0]) && word.Contains(correctLetters[2]) && word.Contains(correctLetters[1]) && word.Contains(correctLetters[0]))
                //    {
                //        guess = word;
                //        return guess;
                //    }

                //    else if (word.Contains(misplacedLetters[2]) && word.Contains(misplacedLetters[1]) && word.Contains(misplacedLetters[0]) && word.Contains(correctLetters[1]) && word.Contains(correctLetters[0]))
                //    {
                //        guess = word;
                //        return guess;
                //    }
                //    else if (word.Contains(misplacedLetters[3]) && word.Contains(misplacedLetters[2]) && word.Contains(misplacedLetters[1]) && word.Contains(misplacedLetters[0]) && word.Contains(correctLetters[0]))
                //    {
                //        guess = word;
                //        return guess;
                //    }
                //    else if (word.Contains(misplacedLetters[4]) && word.Contains(misplacedLetters[3]) && word.Contains(misplacedLetters[2]) && word.Contains(misplacedLetters[1]) && word.Contains(misplacedLetters[0]))
                //    {
                //        guess = word;
                //        return guess;
                //    }

                //    //four kinda right
                //    else if (word.Contains(correctLetters[3]) && word.Contains(correctLetters[2]) && word.Contains(correctLetters[1]) && word.Contains(correctLetters[0]))
                //    {
                //        guess = word;
                //        return guess;
                //    }
                //    else if (word.Contains(misplacedLetters[0]) && word.Contains(correctLetters[2]) && word.Contains(correctLetters[1]) && word.Contains(correctLetters[0]))
                //    {
                //        guess = word;
                //        return guess;
                //    }
                //    else if (word.Contains(misplacedLetters[0]) && word.Contains(misplacedLetters[1]) && word.Contains(correctLetters[1]) && word.Contains(correctLetters[0]))
                //    {
                //        guess = word;
                //        return guess;
                //    }
                //    else if (word.Contains(misplacedLetters[0]) && word.Contains(misplacedLetters[1]) && word.Contains(misplacedLetters[2]) && word.Contains(correctLetters[0]))
                //    {
                //        guess = word;
                //        return guess;
                //    }
                //    else if (word.Contains(misplacedLetters[0]) && word.Contains(misplacedLetters[1]) && word.Contains(misplacedLetters[2]) && word.Contains(misplacedLetters[3]))
                //    {
                //        guess = word;
                //        return guess;
                //    }
                //    // three kinda right
                //    else if (word.Contains(correctLetters[2]) && word.Contains(correctLetters[1]) && word.Contains(correctLetters[0]))
                //    {
                //        guess = word;
                //        return guess;
                //    }
                //    else if (word.Contains(misplacedLetters[0]) && word.Contains(correctLetters[1]) && word.Contains(correctLetters[0]))
                //    {
                //        guess = word;
                //        return guess;
                //    }
                //    else if (word.Contains(misplacedLetters[0]) && word.Contains(misplacedLetters[1]) && word.Contains(correctLetters[0]))
                //    {
                //        guess = word;
                //        return guess;
                //    }
                //    else if (word.Contains(misplacedLetters[0]) && word.Contains(misplacedLetters[1]) && word.Contains(misplacedLetters[2]))
                //    {
                //        guess = word;
                //        return guess;
                //    }




                //}
            }





            return guess;

        }
    }
}
