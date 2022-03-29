//Base code project for CMP1903M Assessment 1
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMP1903M_Assessment_1_Base_Code
{
   
    class Program
    {
        static void Main()
        {
            Console.WriteLine("1. Do you want to enter the text via the keyboard?\n2. Do you want to read in the form of a text file?");
            Console.Write("Option: ");
            string? option = Console.ReadLine();
            int choice = 0;
            bool success = int.TryParse(option, out choice);
            if (success == false)
            {
                Console.WriteLine("Invalid option selected.");
                Environment.Exit(1);
            }
            
            Input input = new Input();
            switch (choice)
            {
                case 1:
                    option = input.manualTextInput();
                    break;
                case 2:
                    option = input.fileTextInput();
                    break;
                default:
                    Console.WriteLine("(" + choice + ") is not a valid option.");
                    Environment.Exit(1);
                    break;
            }
            AnalysisData data = Analyse.analyseText(option);
            Report.outputReportToConsole(data);
            bool fileInputIsSelected = choice == 2;
            if (fileInputIsSelected)
            {
                Report.outputLongWordsToTextFile(data);
            }
            


        }
        
        
    
    }
}
