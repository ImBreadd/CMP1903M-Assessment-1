using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMP1903M_Assessment_1_Base_Code
{
    class Report
    {
        public static void outputConsole(List<int> parameters)
        {
            Console.WriteLine($"Number of sentences:{parameters[0]}\nNumber of vowels:{parameters[1]}\nNumber of consonants:{parameters[2]}\nNumber of upper case letters:{parameters[3]}\nNumber of lower case letters:{parameters[4]}\nNumber of words with 7 or more letters:{parameters[5]}");
        }
        //Handles the reporting of the analysis
        //Maybe have different methods for different formats of output?
        //eg.   public void outputConsole(List<int>)

    }

}
