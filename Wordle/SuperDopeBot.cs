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

            string filePathPrimary = @"C:\Users\seanj\OneDrive\Documents\GitHub\Wordle\Wordle\data\english_words_10k_mit.txt";

            string[] Primary = File.ReadAllLines(filePathPrimary);


            string filePath = @"C:\Users\seanj\OneDrive\Documents\GitHub\Wordle\Wordle\data\english_words_full.txt";

            string[] lines = File.ReadAllLines(filePath);

            List<string> fiveLetterWords = new List<string>();


            foreach (var line in Primary)
            {
                if (line.Length == 5)
                {
                    fiveLetterWords.Add(line);
                }
            }


            foreach (var line in lines)
            {
                if (line.Length == 5 && !fiveLetterWords.Contains(line))
                {
                    fiveLetterWords.Add(line);
                }
            }




            // int index = 0;

            List<char> correctletters = new List<char>();


            foreach (GuessResult guessresult in Guesses)
            {
                foreach(LetterGuess letterGuess in guessresult.Guess)
                {
                    
                    if(letterGuess.LetterResult == LetterResult.Correct || letterGuess.LetterResult == LetterResult.Misplaced && !correctletters.Contains(letterGuess.Letter))
                    {

                        correctletters.Add(letterGuess.Letter);

                        //if(index % 5 == 0)
                        //{
                        //    char one = letterGuess.Letter;
                        //}
                        //if (index % 5 == 1)
                        //{
                        //    char two = letterGuess.Letter;
                        //}
                        //if (index % 5 == 2)
                        //{
                        //    char three = letterGuess.Letter;
                        //}
                        //if (index % 5 == 3)
                        //{
                        //    char four = letterGuess.Letter;
                        //}
                        //if (index % 5 == 4)
                        //{
                        //    char five = letterGuess.Letter;
                        //}
                    } 
                }
            }

            foreach(char letter in correctletters)
            {
                System.Console.WriteLine(letter);
            }

            List<string> fiveLetterWords2 = new List<string>();

            List<int> guessnums = new List<int>();

            int index = 0;

         




            if (Guesses.Count == 0)
            {
                guess = "brick";
                return guess;
            }
            else if (Guesses.Count == 1 && correctletters.Count != 5)
            {

                guess = "glent";
                return guess;

            }
            else if (Guesses.Count == 2 && correctletters.Count != 5)
            {
                guess = "waqfs";
                return guess;

            }
            else if (Guesses.Count == 3 && correctletters.Count != 5)
            {
                guess = "vozhd";
                return guess;

            }
            else if (Guesses.Count == 4 && correctletters.Count != 5)
            {
                guess = "jumpy";
                return guess;

            }
            else
            {
                


                foreach (string word in fiveLetterWords)
                {
                    int numOfMatching = 0;


                    for (int i = 0; i < word.Length; i++)
                    {
                        if (word.Contains(correctletters[i]))
                        {
                            numOfMatching++;
                        }

                    }

                    if (numOfMatching == 5)
                    {
                        fiveLetterWords2.Add(word);
                    }

                    numOfMatching = 0;
                }

             
                
            }

            if(guessnums.Count == 0)
            {
                foreach (string word in fiveLetterWords2)
                {
                    guessnums.Add(index);
                    index++;
                }
            }
           


            guess = fiveLetterWords2[guessnums.First()];
            guessnums.RemoveAt(0);

            foreach (char letter in correctletters.ToList())
            {
                System.Console.WriteLine(letter);
            }

            foreach(string word in fiveLetterWords2)
            {
                System.Console.WriteLine(word);
            }


            
            
           

            
















            return guess;




            // string guess = "";



            // List<char> correctLetters = new List<char>();
            // List<char> misplacedLetters = new List<char>();
            // List<char> incorrectLetters = new List<char>();


            // string filePathPrimary = @"C:\Users\seanj\OneDrive\Documents\GitHub\Wordle\Wordle\data\english_words_10k_mit.txt";

            // string[] Primary = File.ReadAllLines(filePathPrimary);


            // string filePath = @"C:\Users\seanj\OneDrive\Documents\GitHub\Wordle\Wordle\data\english_words_full.txt";

            // string[] lines = File.ReadAllLines(filePath);

            // List<string> fiveLetterWords = new List<string>();

            //// string[] fiveLetterWords = new string[] { };

            // //for (int i = fiveLetterWords.Count-1; i >= 0; i--)
            // //{
            // //    fiveLetterWords.RemoveAt(i);
            // //}

            //     ////create fiveletterword list

            //     foreach (var line in Primary)
            //     {
            //         if (line.Length == 5)
            //         {
            //             fiveLetterWords.Add(line);
            //         }
            //     }


            // foreach (var line in lines)
            // {
            //     if (line.Length == 5 && !fiveLetterWords.Contains(line))
            //     {
            //         fiveLetterWords.Add(line);
            //     }
            // }





            // //add letterresults to respective lists

            // foreach (GuessResult guessResult in Guesses)
            // {
            //     foreach (LetterGuess letterGuess in guessResult.Guess)
            //     {
            //         if (letterGuess.LetterResult == LetterResult.Correct && !correctLetters.Contains(letterGuess.Letter))
            //         {
            //             correctLetters.Add(letterGuess.Letter);
            //         }
            //         else if (letterGuess.LetterResult == LetterResult.Misplaced && !misplacedLetters.Contains(letterGuess.Letter))
            //         {
            //             misplacedLetters.Add(letterGuess.Letter);
            //         }
            //         else if (letterGuess.LetterResult == LetterResult.Incorrect)
            //         {
            //             foreach(string word in fiveLetterWords.ToArray())
            //             {
            //                 if (word.Contains(letterGuess.Letter))
            //                 {
            //                     fiveLetterWords.Remove(word);
            //                 }

            //             }
            //             //incorrectLetters.Add(letterGuess.Letter);
            //         }

            //     }
            // }

            // // if has an incorrect letter, remove


            // //foreach (string word in fiveLetterWords.ToList())
            // //{
            // //    foreach (char incorrectLetter in incorrectLetters)
            // //    {
            // //        if (word.Contains(incorrectLetter))
            // //        {
            // //            fiveLetterWords.Remove(word);
            // //        }
            // //    }
            // //}

            // //changing misplaced to correct

            // //foreach (char misplacedLetter in misplacedLetters.ToArray())
            // //{
            // //    if (correctLetters.Contains(misplacedLetter))
            // //    {
            // //        misplacedLetters.Remove(misplacedLetter);
            // //    }
            // //}

            // //

            // //foreach (string word in fiveLetterWords.ToArray())
            // //{
            // //    for (int i = 0; i < word.Length - 1; i++)
            // //    {
            // //        if (word[i] == word[i + 1])
            // //        {
            // //            fiveLetterWords.Remove(word);
            // //        }
            // //    }
            // //}


            // System.Console.WriteLine(correctLetters.Count);
            // System.Console.WriteLine(incorrectLetters.Count);
            // System.Console.WriteLine(misplacedLetters.Count);



            // System.Console.WriteLine(fiveLetterWords.Count);

            // //if doesnt contain correct letter, remove

            // foreach (string word in fiveLetterWords.ToList())
            // {
            //     foreach (char correctLetter in correctLetters)
            //     {
            //         if (!word.Contains(correctLetter))
            //         {
            //             fiveLetterWords.Remove(word);
            //         }
            //     }
            // }

            // System.Console.WriteLine(fiveLetterWords.Count);






            // if (Guesses.Count == 0)
            // {
            //     guess = "their";

            //     return guess;



            // }






            // else
            // {



            //     foreach (string word in fiveLetterWords)
            //     {
            //         foreach (GuessResult guessResult in Guesses)
            //         {
            //             foreach (LetterGuess letterGuess in guessResult.Guess)
            //             {
            //                 for (int i = 0; i < 5; i++)
            //                 {
            //                     //if letter in each word equals the corresponding letter in each guess and correctletters doesnt already contain it
            //                     if (word[i] == letterGuess.Letter && !correctLetters.Contains(word[i]))
            //                     {
            //                         correctLetters.Add(letterGuess.Letter);
            //                     }
            //                 }
            //             }

            //         }
            //     }



            //     if (fiveLetterWords.Count != 0)
            //     {
            //         guess = fiveLetterWords[0];

            //     }


            //     //    guess = fiveLetterWords[0];













            //     //}






            // }

            // return guess;

        }
    }
}
