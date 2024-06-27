# Number Block Sorting Software

## Description

This is a simple code intended for sorting a listing of numbers and finding which block they belong to, if they are part of a order block.

For those who aren't around the VoIP business, thats fine, I will give you a brief explenation. When you get a number from a provider, you basically order a number from them. _This number gets determined by the governing body_ (In Germany the BNA) and when verified you receive it. In that same way, busineeses can order multiple "blocks" of numbers. A block basically just means that that the last digits follow. So a 10 block would have a traling 90 - 99.

## Usage

- \_ -

## Notes

If you want another output name of file, you change that at this code block in the MainForm.cs

```c#
    FileSort fileSort = new ();
    var phoneNumbers = FileSort.ReadPhoneNumbersFromFile(inputFileName);
    var consecutiveSequences = FileSort.FindConsecutiveNumbers(phoneNumbers);
    FileSort.outputConsecutiveSequences(consecutiveSequences, "output.txt");
    MessageBox.Show(string.Join(Environment.NewLine, consecutiveSequences), "Consecutive Numbers", MessageBoxButtons.OK, MessageBoxIcon.Information);
```
