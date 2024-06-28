using System;
using System.Collections.Generic;
using System.IO;

namespace NumberBlockSorting.Functions
{
    public class FileSort
    {
        public static List<string> ReadPhoneNumbersFromFile(string filename)
        {
            List<string> phoneNumbers = new List<string>();
            try
            {
                using (StreamReader file = new StreamReader(filename))
                {
                    string? line;
                    while ((line = file.ReadLine()) != null)
                    {
                        phoneNumbers.Add(line);
                    }
                }
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine($"Error: The file {filename} was not found.");
            }
            catch (FormatException)
            {
                Console.WriteLine("Error: The file contains non-numeric values.");
            }
            return phoneNumbers;
        }

        public static List<string> FindConsecutiveNumbers(List<string> numbers)
        {
            numbers.Sort();
            List<string> consecutiveSequences = new List<string>();
            List<string> currentSequence = new List<string>();

            foreach (var number in numbers)
            {
                if (currentSequence.Count == 0 || number == currentSequence[currentSequence.Count - 1] + 1)
                {
                    currentSequence.Add(number);
                }
                else
                {
                    if (currentSequence.Count > 1)
                    {
                        consecutiveSequences.Add($"{currentSequence[0]}, {currentSequence[currentSequence.Count - 1]}");
                    }
                    else
                    {
                        consecutiveSequences.Add($"{currentSequence[0]}, {currentSequence[0]}");
                    }
                }
                currentSequence = new List<string> { number };
            }
            // Check for the last sequence
            if (currentSequence.Count > 1)
            {
                consecutiveSequences.Add($"{currentSequence[0]}, {currentSequence[-1]}");
            }
            else
            {
                consecutiveSequences.Add($"{currentSequence[0]}, {currentSequence[0]}");
            }
            return consecutiveSequences;
        }

        public static void outputConsecutiveSequences(List<string> consecutiveSequences, string outputFile)
        {
            int count = 0;
            using (StreamWriter file = new(outputFile))
            {
                file.WriteLine("Consecutive Numbers Found:\n");
                foreach (var number in consecutiveSequences)
                {
                    file.WriteLine(number);
                    count++;
                }
                file.WriteLine($"\nTotal Consecutive Sequences: {count}");
                Console.WriteLine($"Consecutive sequences, amount = {count}, written to {outputFile}");
            }
        }
    }
}
