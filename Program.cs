using System;
using System.Collections.Generic;
using System.IO;

namespace NumberBlockSorting
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputFilename = "phoneNumbers.txt";
            string outputFilename = "output.txt";

            FileSort fileSort = new FileSort();

            List<string> phoneNumbers = fileSort.ReadPhoneNumbersFromFile(inputFilename);

            if (phoneNumbers.Count > 0)
            {
                List<string> consecutiveNumbers = fileSort.FindConsecutiveNumbers(phoneNumbers);

                using (StreamWriter file = new StreamWriter(outputFilename))
                {
                    file.WriteLine("Consecutive number blocks:\n");
                    foreach (var number in consecutiveNumber)
                    {
                        file.WriteLine(number);
                    }
                }
                int totalNumbers = phoneNumbers.Count;
                Console.WriteLine($"Saved the numbers to {outputFilename}.");
                Console.WriteLine($"Found {totalNumbers} phone numbers in the file.");
            }
            else
            {
                Console.WriteLine("No phone numbers were found in the file.");
            }
        }
    }
}