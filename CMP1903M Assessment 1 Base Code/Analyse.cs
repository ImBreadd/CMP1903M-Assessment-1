﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMP1903M_Assessment_1_Base_Code
{
    public class Analyse

    {       
        static readonly int longWordLimit = 7;
        static readonly HashSet<char> vowels = new HashSet<char> { 'a', 'e', 'i', 'o', 'u' };
        static readonly HashSet<char> punctuation = new HashSet<char> { '.', '!', '?' };
        //Handles the analysis of text

        //Method: analyseText
        //Arguments: string
        //Returns: AnalysisData containing metrics about the text
        //Calculates and returns an analysis of the text

        public static AnalysisData analyseText(string inputText)
        {
            //List of integers to hold the first five measurements:
            int totalSentences = 0;
            int totalLongWords = 0;
            int totalVowels = 0;
            int totalUpper = 0;

            // Number of sentences
            string[] allSentences = inputText.Split(punctuation.ToArray(), StringSplitOptions.RemoveEmptyEntries);
            totalSentences = allSentences.Length;

            // Number of words
            char[] numerals = "0123456789".ToCharArray();
            char[] ignoredCharacters = ",'-:;$£%(){}~@:?><\\\"/#=_+`¬~|".ToCharArray();
            string textWithoutPunctuation = String.Join(" ", allSentences);
            string textWithoutPunctuationAndIgnoredCharacters = String.Join("", textWithoutPunctuation.Split(ignoredCharacters, StringSplitOptions.RemoveEmptyEntries));
            string textWithoutPunctuationAndIgnoredCharactersAndNumerals = String.Join("", textWithoutPunctuationAndIgnoredCharacters.Split(numerals, StringSplitOptions.RemoveEmptyEntries));
            string[] words = textWithoutPunctuationAndIgnoredCharactersAndNumerals.Split(" ", StringSplitOptions.RemoveEmptyEntries);
            foreach (string word in words)
            {
                if (word.Length >= longWordLimit)
                {
                    totalLongWords++;                   
                }
            }

            // Individual character analysis
            string charactersFromText = String.Join(String.Empty, words);
            int totalCharacterCount = charactersFromText.Length;
            Dictionary<char, int> characterFrequency = new Dictionary<char, int>();
            foreach (char c in charactersFromText)
            {
                //Check case of character
                if (char.IsUpper(c))
                {
                    totalUpper++;
                }
                //Check if character is a vowel or consonant
                if (vowels.Contains(char.ToLower(c)))
                {
                    totalVowels++;
                }
                //Build a frequency dictionary
                if (characterFrequency.ContainsKey(c))
                {
                    characterFrequency[c]++;
                }
                else
                {
                    characterFrequency[c] = 1;
                }                                                                                  
            }
            return new AnalysisData(inputText, totalSentences, totalVowels, totalCharacterCount-totalVowels, totalUpper,totalCharacterCount-totalUpper, totalLongWords, characterFrequency);           
        }
    }

    public class AnalysisData
    {
        public string OriginalText { get; }
        public int TotalSentences { get; }
        public int TotalVowels { get; }
        public int TotalConsonants { get; }
        public int TotalUpper { get; }
        public int TotalLower { get; }
        public int TotalLongWords { get; }
        public Dictionary<char, int> CharacterFrequency { get; }
        public AnalysisData(string OriginalText, int TotalSentences, int TotalVowels, int TotalConsonants, int TotalUpper, int TotalLower, int TotalLongWords, Dictionary<char, int> CharacterFrequency)
        {
            this.OriginalText = OriginalText;
            this.TotalSentences = TotalSentences;
            this.TotalVowels = TotalVowels;
            this.TotalConsonants = TotalConsonants;
            this.TotalUpper = TotalUpper;
            this.TotalLower = TotalLower;
            this.TotalLongWords = TotalLongWords;
            this.CharacterFrequency = CharacterFrequency;
        }
    }
}
