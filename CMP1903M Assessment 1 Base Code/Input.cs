using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMP1903M_Assessment_1_Base_Code
{
    public class Input
    {
        //Method: manualTextInput
        //Arguments: none
        //Returns: string
        //Gets text input from the keyboard
        public string manualTextInput()
        {
            string text = "";
            String entry = "";
            Console.Write("Indicate the end of the entry with an *\nYour entry: ");
            while (!entry.Contains('*'))
            {
                entry += Console.ReadLine();
            }
            text = entry;
            text = trimTextEnd(text);
            

            return text;
        }

        //Method: fileTextInput
        //Arguments: string (the file path)
        //Returns: string
        //Gets text input from a .txt file
        public string fileTextInput()
        {
            string text = "";
            Console.Write("Enter file name (CMP1903M Assessment 1 Test File.txt): ");
            string? fileName = Console.ReadLine();
            if (fileName == null || fileName == "")
            {
                fileName = "CMP1903M Assessment 1 Test File.txt";
            }
            try
            {
                text = System.IO.File.ReadAllText(fileName);
                text = trimTextEnd(text);
            }
            catch (Exception e)
            {
                Console.Error.WriteLine(e.Message);
                Environment.Exit(1);
            }
            return text;
        }
        //Removes the asterix and everything after it
        private string trimTextEnd(string input)
        {   
            return input.Substring(0, input.IndexOf("*"));

        }
    }
}
