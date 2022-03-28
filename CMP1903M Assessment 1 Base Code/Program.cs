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
            //Local list of integers to hold the first five measurements of the text
            List<int> parameters = new List<int>();

            //Create 'Input' object
            //Get either manually entered text, or text from a file
            Console.WriteLine("1. Do you want to enter the text via the keyboard?\n2. Do you want to read in the form of a text file?");
            String option=Console.ReadLine();
            int choice = 0;
            bool success = int.TryParse(option, out choice);
            if (success==false)
            {
                Console.WriteLine("No");
                Environment.Exit(1);
            }
            
            Input input = new Input();
            if (choice==1)
            {
                
                option = input.manualTextInput();
            }
            else if (choice==2)
            {
                 option = input.fileTextInput("CMP1903M Assessment 1 Test File.txt");
            }
            else
            {
                
            }
             Console.WriteLine(option);
 
            //Create an 'Analyse' object
            Analyse analyse = new Analyse();
            //Pass the text input to the 'analyseText' method
            //Receive a list of integers back
            parameters = analyse.analyseText(option);
            //Report the results of the analysis
            Report.outputConsole(parameters);
            //TO ADD: Get the frequency of individual letters?


        }
        
        
    
    }
}
