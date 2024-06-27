using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace NumberBlockSorting
{
    class Program
    {
        //necessary for using Windows Forms in cosole application
        [STAThread]
        static void Main(string[] args)
        {
            string inputFilename = string.Empty;
            string outputFilename = "output.txt";

            OpenFileDialog openFileDialog = new ()
            {
                DefaultExt = ".txt",
                Filter = "Text documents (.txt) | *.txt"
            };

            DialogResult result = openFileDialog.ShowDialog();

            if (result == DialogResult.OK){
                inputFilename = openFileDialog.FileName;
            }
            else {
                Console.WriteLine("No file selected. Exiting program.");
                return;
            }

            FileSort fileSort = new ();

            List<string> phoneNumbers = fileSort.ReadPhoneNumbersFromFile(inputFilename);

            if (phoneNumbers.Count > 0)
            {
                List<string> consecutiveNumbers = fileSort.FindConsecutiveNumbers(phoneNumbers);

                using (StreamWriter file = new (outputFilename))
                {
                    file.WriteLine("Consecutive number blocks:\n");
                    foreach (var number in consecutiveNumbers)
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