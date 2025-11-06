using System;
using System.IO;
using System.Runtime.CompilerServices;
class LoadEntries
{
    // Load Entries from a file in the parent directory.
    public List<List<string>> _entries = new List<List<string>>();
    const int textIndex = 2;
    public void Load()
    {
        Console.WriteLine("Enter the filename to load (without the extension)");
        string filename = Console.ReadLine();
        filename += ".csv";
        string filePath = @".\" + filename;
        if (!File.Exists(filePath))
        {
            Console.WriteLine("No such file. Please try again.");
        }
        else
        {
            using (StreamReader sr = File.OpenText(filePath))
            {
                sr.ReadLine();
                string line;

                while ((line = sr.ReadLine()) != null)
                {
                    string[] items = line.Split(",");
                    items[textIndex] = items[textIndex].TrimStart('\"');
                    items[textIndex] = items[textIndex].TrimEnd('\"');

                    _entries.Add(new List<string>(items));

                }


            }
        }
    }
}