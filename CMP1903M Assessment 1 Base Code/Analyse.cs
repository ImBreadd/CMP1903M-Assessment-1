using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMP1903M_Assessment_1_Base_Code
{
    public class Analyse

    {
        int totalSentences = 0;
        int totalVowels = 0;
        int totalConsonants = 0;
        int totalUpper = 0;
        int totalLower = 0;
        int totalLongWords = 0;
        int longWordLimit = 7;
        //string[] allWords = { };
        HashSet<char> vowels = new HashSet<char> { 'a', 'e', 'i', 'o', 'u' };
        HashSet<char> punctuation = new HashSet<char> { '.', '!', '?', };
        //Handles the analysis of text

        //Method: analyseText
        //Arguments: string
        //Returns: list of integers
        //Calculates and returns an analysis of the text

        public List<int> analyseText(string inputText)
        {
            //List of integers to hold the first five measurements:
            //1. Number of sentences
            string[] allSentences = inputText.Split(punctuation.ToArray());
            allSentences = allSentences.Where(s => !string.IsNullOrEmpty(s.Trim())).ToArray();
            totalSentences = allSentences.Length;
            string currentWord = "";
            string textWithoutPunctuation = String.Join(" ", allSentences);
            string[] words = textWithoutPunctuation.Split(" ");
            foreach (string word in words)
            {
                if (word.Length > longWordLimit)
                {
                    totalLongWords++;
                }
            }
            string textWithoutPunctuationOrSpaces = String.Join(String.Empty, words);
            var characterFrequency = new Dictionary<char, int>();
            foreach (char c in textWithoutPunctuationOrSpaces)
            {
                if (char.IsLetter(c))
                {
                    //Check case of character
                    if (char.IsUpper(c))
                    {
                        totalUpper++;
                    }
                    else
                    {
                        totalLower++;
                    }
                    //Check if character is a vowel or consonant
                    if (vowels.Contains(char.ToLower(c)))
                    {
                        totalVowels++;
                    }
                    else
                    {
                        totalConsonants++;
                    }
                    //Build a frequency dictionary
                    int frequency;
                    characterFrequency.TryGetValue(c, out frequency);
                    characterFrequency[c] = frequency++;                                       
                }
            }           
            List<int> values = new List<int> { totalSentences, totalVowels, totalConsonants, totalUpper, totalLower, totalLongWords };
            return values;
        }
    }
}
