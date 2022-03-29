using System;
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

        public static AnalysisData analyseText(string inputText)
        {
            int totalSentences = 0;
            int totalLongWords = 0;
            int totalVowels = 0;
            int totalUpper = 0;
            List<string> longWordList = new List<string>();

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
                    longWordList.Add(word.ToLower());
                    
                }
            }

            // Individual character analysis
            string charactersFromText = String.Join(String.Empty, words);
            int totalCharacterCount = charactersFromText.Length;
            Dictionary<char, int> characterFrequency = new Dictionary<char, int>();
            foreach (char c in charactersFromText)
            {
                if (char.IsUpper(c))
                {
                    totalUpper++;
                }
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
            return new AnalysisData(inputText, totalSentences, totalVowels, totalCharacterCount-totalVowels, totalUpper,totalCharacterCount-totalUpper, totalLongWords, longWordList, characterFrequency);           
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
        public List<string> longWordList { get; }
        public Dictionary<char, int> CharacterFrequency { get; }
        public AnalysisData(string OriginalText, int TotalSentences, int TotalVowels, int TotalConsonants, int TotalUpper, int TotalLower, int TotalLongWords, List<string> LongWordList, Dictionary<char, int> CharacterFrequency)
        {
            this.OriginalText = OriginalText;
            this.TotalSentences = TotalSentences;
            this.TotalVowels = TotalVowels;
            this.TotalConsonants = TotalConsonants;
            this.TotalUpper = TotalUpper;
            this.TotalLower = TotalLower;
            this.TotalLongWords = TotalLongWords;
            this.longWordList = LongWordList;
            this.CharacterFrequency = CharacterFrequency;
        }
    }
}
