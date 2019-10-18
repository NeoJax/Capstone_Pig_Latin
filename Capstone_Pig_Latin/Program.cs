using System;
using System.Text;
using System.Text.RegularExpressions;

namespace Capstone_Pig_Latin
{
    class Program
    {
        static void Main(string[] args)
        {
            WordPrompt();
        }

        // This method prompts a word from the user
        public static void WordPrompt()
        {
            //string inputString = Console.ReadLine();
            PigLatinFind("This is a test. This is another test whales are nice. This is the 3rd test. 1950");
        }

        // This method finds the words that need to be made into Pig Latin
        public static void PigLatinFind(string inputString)
        {
            string symbolPattern = @"[^A-z]";
            string[] inputWords = inputString.Split(" ");
            string changedWord = "";
            for (int i = 0; i < inputWords.Length; i++)
            {
                if (!Regex.IsMatch(inputWords[i], symbolPattern))
                {
                    changedWord = PigLatin(inputWords[i]);
                    inputWords[i] = changedWord;
                }
            }
            for (int j = 0; j < inputWords.Length; j++)
            {
                Console.Write(inputWords[j] + " ");
            }
        }

        public static string PigLatin(string inputWord)
        {
            string vowelPattern1 = @"^[AEIOUaeiou]";
            string vowelPattern2 = @"[AEIOUaeiou]";
            string consonantPattern = @"^[BCDFGHJKLMNPQRSTVWXYZbcdfghjklmnpqrstvwxyz]";
            StringBuilder modifiedWord = new StringBuilder(inputWord, inputWord.Length + 2);
            Regex findVowel = new Regex(vowelPattern2);
            Match matchVowel = findVowel.Match(inputWord);
            int matchIndex = matchVowel.Index;
            if (Regex.IsMatch(inputWord, vowelPattern1))
            {
                inputWord += "way";
            }
            else if (Regex.IsMatch(inputWord, consonantPattern))
            {
                inputWord = inputWord.Remove(0, matchIndex);
            }
            return inputWord;
        }

        // This method makes sure the user wants to continue
        public static void GetContinue()
        {

        }
    }
}
