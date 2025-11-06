using System;
using System.IO;
using System.Runtime.CompilerServices;
class SaveEntries
{
    // Save current entries into a file in the parent directory.
    public List<List<string>> _entries = new List<List<string>>();
    const int timeIndex = 0;
    const int promptIndex = 1;
    const int textIndex = 2;

    public void SaveToCSV()
    {
        Console.Write("Please enter a filename without the extension: ");
        string filename = Console.ReadLine();
        filename += ".csv";
        string filePath = @".\" + filename;

        foreach (List<string> entry in _entries)
        {
            string stagedString = $"{entry[timeIndex]},{entry[promptIndex]},\"{entry[textIndex]}\"";
            if (!File.Exists(filePath))
            {
                using (StreamWriter sw = File.CreateText(filePath))
                {
                    sw.WriteLine("Date,Prompt,Entry");
                    sw.WriteLine(stagedString);
                }
            }
            else
            {
                using (StreamWriter sw = File.AppendText(filePath))
                {
                    sw.WriteLine(stagedString);
                }
            }
        }
    }
}