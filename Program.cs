using System;
using System.Collections.Generic;
using System.IO;

class Program
{
    static void Main()
    {
        string filename = "wordlist.txt";
        int anagrams = 0;

        try
        {
            List<string> lines = new List<string>();
            Dictionary<int, List<string>> wordsByLength = new Dictionary<int, List<string>>();
            List<string> searched = new List<string>();

            using (StreamReader sr = new StreamReader(filename))
            {
                string line;
                while((line = sr.ReadLine()) != null)
                {
                    lines.Add(line);
                }
            }

            // sort into length
            //lines = lines.OrderBy(x => x.Length).ToList();

            // sort all into alphabetical order
            for (int i = 0; i < lines.Count; i++)
            {
                lines[i] = lines[i].ToLower().Trim();
                char[] chars = lines[i].ToArray();
                Array.Sort(chars);
                lines[i] = new string(chars);
            }

            var res = lines.GroupBy(x => x);

            foreach (var e in res)
            {
                if (e.Count() > 1)
                {
                    anagrams++;
                }
            }

            Console.WriteLine(anagrams);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}

struct Pair
{
    public string first { get; private set; }
    public string second { get; private set; }

    public Pair(string first, string second)
    {
        this.first = first;
        this.second = second;
    }
}