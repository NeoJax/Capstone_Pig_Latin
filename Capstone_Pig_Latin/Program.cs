// ===============================
// AUTHOR     : Jonathan Lubaway
// CREATE DATE: October 18th, 2019
// PURPOSE    : Translate from English to Pig Latin
// ===============================
using System;
using System.Text;
using System.Text.RegularExpressions;

namespace Capstone_Pig_Latin
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Pig Latin translator! \n");
            WordPrompt();
        }

        // This method prompts a word from the user
        public static void WordPrompt()
        {
            Console.WriteLine("Please enter a string");

            string inputString = Console.ReadLine();

            // Determines if someone has actually put in atleast a letter
            if (inputString.Length == 0)
            {
                Console.WriteLine("Please enter something \n");
                WordPrompt();
            }
            else
            {
                PigLatinFind(inputString);
            }
        }

        // This method finds the words that need to be made into Pig Latin
        public static void PigLatinFind(string inputString)
        {
            // This pattern determines if there is a symbol in the word other than a single quote
            string symbolPattern = @"[^A-Za-z,']";

            // I split up the string so I can modify each word
            string[] inputWords = inputString.Split(" ");
            string changedWord = "";

            // This determines whether a word is to be modified or not
            for (int i = 0; i < inputWords.Length; i++)
            {
                if (!Regex.IsMatch(inputWords[i], symbolPattern))
                {
                    changedWord = PigLatin(inputWords[i]);
                    inputWords[i] = changedWord;
                }
            }

            // When the translation is done this prints all the words out in the correct order
            for (int j = 0; j < inputWords.Length; j++)
            {
                Console.Write(inputWords[j] + " ");
            }
            Console.WriteLine("\n");
            GetContinue();
        }

        // This method translates from English to Pig Latin
        public static string PigLatin(string inputWord)
        {
            // Two patterns for finding vowels the first one checks the start of the word
            string vowelPattern1 = @"^[AEIOUaeiou]";

            // The second pattern is for finding the first vowel
            string vowelPattern2 = @"[AEIOUaeiou]";
            string consonantPattern = @"^[BCDFGHJKLMNPQRSTVWXYZbcdfghjklmnpqrstvwxyz]";
            string consonantReplace = "";

            // This Regex finds a vowel in the designated word and saves the index
            Regex findVowel = new Regex(vowelPattern2);
            Match matchVowel = findVowel.Match(inputWord);
            int matchIndex = matchVowel.Index;

            // The first if statement adds "way" to any word that starts with a vowel
            if (Regex.IsMatch(inputWord, vowelPattern1))
            {
                inputWord += "way";
            }

            // The second if statement moves all consonants in front of the first vowel
            // to the back of the word and adds "ay" after
            else if (Regex.IsMatch(inputWord, consonantPattern))
            {
                consonantReplace = inputWord.Substring(0, matchIndex);
                inputWord = inputWord.Remove(0, matchIndex);
                inputWord += consonantReplace + "ay";
            }
            return inputWord;
        }

        // This method makes sure the user wants to continue
        public static void GetContinue()
        {
            Console.Write("Would you like to change more things to Pig Latin? ");
            string inputContinue = Console.ReadLine();
            Console.WriteLine();
            if (inputContinue == "y")
            {
                WordPrompt();
            }
            else if (inputContinue == "n")
            {
                Console.WriteLine("Enjoyway ouryay ayday.");
            }
            else
            {
                Console.WriteLine("Please enter a valid input \n");
                GetContinue();
            }
        }
    }
}
