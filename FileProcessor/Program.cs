using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using FileProcessor.BusinessLogic;

namespace FileProcessor
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Where is the input file located? Please include the path and file name:");
            var fileName = Console.ReadLine();

            Console.WriteLine("Please enter CSV if the file is comma separated or TSV if the file is tab separated:");
            var delimitType = Console.ReadLine().ToLower();

            while (delimitType != Constants.CSV && delimitType != Constants.TSV)
            {
                Console.WriteLine("The value entered is incorrect. Please enter CSV if the file is comma separated or TSV if the file is tab separated:");
                delimitType = Console.ReadLine().ToLower();
            }

            Console.WriteLine("Please enter the number of fields each record should contain:");
            var fieldNumber = Console.ReadLine();
            var match = Regex.Match(fieldNumber, @"[0-9]");
            while (!match.Success)
            {
                Console.WriteLine("The value entered is incorrect. Please enter the number of fields each record should contain:");
                fieldNumber = Console.ReadLine();
                match = Regex.Match(fieldNumber, @"[0-9]");
            }

            Console.WriteLine(FileProcessor.BusinessLogic.FileProcessor.ProcessFile(fileName, delimitType, Int16.Parse(fieldNumber)));

            Console.WriteLine("Please hit enter to quit the app.");
            Console.Read();
        }
    }
}


