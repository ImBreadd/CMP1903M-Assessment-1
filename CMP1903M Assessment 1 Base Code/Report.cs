using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMP1903M_Assessment_1_Base_Code
{
    class Report
    {
        //Outputs to console
        public static void outputReportToConsole(AnalysisData data)
        {
            Console.Write(outputStringFromAnalysisData(data));
        }
        //Outputs to text file
        public static void outputReportToTextFile(AnalysisData data)
        {
            File.WriteAllText("Text-Analysis-Report-" + DateTime.Now.Ticks + ".txt", data.OriginalText + "\n\n" + outputStringFromAnalysisData(data));
        }
        //Builds output string
        private static string outputStringFromAnalysisData(AnalysisData data)
        {
            char[] letters = "abcdefghijklmnopqrstuvwxyz".ToCharArray();
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Number of sentences: " + data.TotalSentences);
            sb.AppendLine("Number of vowels: " + data.TotalVowels);
            sb.AppendLine("Number of consonants: " + data.TotalConsonants);
            sb.AppendLine("Number of upper case letters: " + data.TotalUpper);
            sb.AppendLine("Number of lower case letters: " + data.TotalLower);
            sb.AppendLine("Number of words longer than seven letters: " + data.TotalLongWords);
            //Build character frequency table
            sb.AppendLine("Frequency of individual letters: ");
            int numberOfColumns = 5;
            for (int i = 0; i < letters.Length; i = i + numberOfColumns)
            {
                char[] rowLetters = letters.Skip(i).Take(numberOfColumns).ToArray();
                string row = "";
                foreach (char letter in rowLetters)
                {
                    int count = data.CharacterFrequency.ContainsKey(letter) ? data.CharacterFrequency[letter] : 0;
                    row += String.Format("{0}: {1,5} ", letter, count);
                }
                sb.AppendLine(row);
            }
            return sb.ToString();
        }
    }

}
