using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        string filePath = "unsorted-names-list.txt"; //ensure file is in same folder as the exe file

        try
        {
            // Read unsorted names from file
            string[] unsortedNames = File.ReadAllLines(filePath);

            // Sort names
            string[] sortedNames = SortNames(unsortedNames);

            // Display sorted names
            Console.WriteLine("Sorted names:");
            foreach (string name in sortedNames)
            {
                Console.WriteLine(name);
            }

            // Write sorted names to file
            File.WriteAllLines("sorted-names-list.txt", sortedNames);
            Console.WriteLine("Sorted names written to sorted-names-list.txt");
        }
      
        catch (Exception ex) // exception handling
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
    }
    //Method to sort names
    static string[] SortNames(string[] unsortedNames)
    {
        return unsortedNames
            .Select(name => new
            {
                OriginalName = name,
                Parts = name.Split(' ') //splits names into parts for sorting
            })
            .OrderBy(x => x.Parts.Last()) //orders by last name first
            .ThenBy(x => x.Parts.Take(x.Parts.Length - 1)) //then orders by given names
            .Select(x => x.OriginalName) //selects original name
            .ToArray(); //convert to array
    }
}
