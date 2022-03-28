using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMP1903M_Assessment_1_Base_Code
{
    public class Input
    {
        //Handles the text input for Assessment 1
        string text = "nothing";
        
        //Method: manualTextInput
        //Arguments: none
        //Returns: string
        //Gets text input from the keyboard
        public string manualTextInput()
        {
            String entry = "";
            while (!entry.Contains('*'))
            {
                Console.Write("Indicate the end of the entry with an *\nYour entry:");
                entry+=Console.ReadLine();
            }
            text = entry;
            trimTextEnd();
            

            return text;
        }

        //Method: fileTextInput
        //Arguments: string (the file path)
        //Returns: string
        //Gets text input from a .txt file
        public string fileTextInput()
        {
            string text = "";
            Console.Write("Enter file name: ");
            string? fileName = Console.ReadLine();
            if (fileName == null || fileName == "")
            {
                fileName = "CMP1903M Assessment 1 Test File.txt";
            }
            try
            {
                text = System.IO.File.ReadAllText(fileName); 
                trimTextEnd();
            }
            catch (Exception e)
            {
                Console.Error.WriteLine(e.Message);
                Environment.Exit(1);
            }
            return text;
        }
        //Removes the asterix and everything after it
        private void trimTextEnd()
        {   
            this.text = this.text.Substring(0, this.text.IndexOf("*"));

        }
    }
}
