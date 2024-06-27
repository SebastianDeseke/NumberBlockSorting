using System;
using System.Collections.Generic;
using System.IO;

namespace NumberBlockSorting
{
    public class FileSort
    {
        public List<string> ReadPhoneNumbersFromFile(string filename)
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

        public List<string> FindConsecutiveNumbers(List<string> numbers)
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
    }
}
