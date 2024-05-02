using System;

// Interface for reading names from a file
interface INamesReader
{
    string[] ReadNames(string filePath);
}

// Interface for writing names to a file
interface INamesWriter
{
    void WriteNames(string[] names, string filePath);
}

// Interface for sorting names
interface INamesSorter
{
    string[] SortNames(string[] unsortedNames);
}

// Class responsible for reading names from a file
class FileNamesReader : INamesReader
{
    public string[] ReadNames(string filePath)
    {
        return System.IO.File.ReadAllLines(filePath);
    }
}

// Class responsible for writing names to a file
class FileNamesWriter : INamesWriter
{
    public void WriteNames(string[] names, string filePath)
    {
        System.IO.File.WriteAllLines(filePath, names);
    }
}

// Class responsible for sorting names
class LastNameFirstNamesSorter : INamesSorter
{
    public string[] SortNames(string[] unsortedNames)
    {
        return unsortedNames
            .Select(name => new
            {
                OriginalName = name,
                Parts = name.Split(' ')
            })
            .OrderBy(x => x.Parts.Last())
            .ThenBy(x => x.Parts.Take(x.Parts.Length - 1))
            .Select(x => x.OriginalName)
            .ToArray();
    }
}

// Class responsible for coordinating the process of reading, sorting, writing names, and displaying the sorted list
class NamesProcessor
{
    private readonly INamesReader _namesReader;
    private readonly INamesSorter _namesSorter;
    private readonly INamesWriter _namesWriter;

    public NamesProcessor(INamesReader namesReader, INamesSorter namesSorter, INamesWriter namesWriter)
    {
        _namesReader = namesReader;
        _namesSorter = namesSorter;
        _namesWriter = namesWriter;
    }

    // Method to process names
    public string[] ProcessNames(string inputFilePath, string outputFilePath)
    {
        try
        {
            // Read unsorted names from file
            string[] unsortedNames = _namesReader.ReadNames(inputFilePath);

            // Sort names
            string[] sortedNames = _namesSorter.SortNames(unsortedNames);

            // Write sorted names to file
            _namesWriter.WriteNames(sortedNames, outputFilePath);

            // Display sorted names
            Console.WriteLine("Sorted names:");
            foreach (string name in sortedNames)
            {
                Console.WriteLine(name);
            }
            
            // Inform user that sorted names have been written to file
            Console.WriteLine("Sorted names written to sorted-names-list.txt");
            
            return sortedNames;
        }
        catch (Exception ex)
        {
            // Handle any exceptions that occur during the process
            Console.WriteLine($"An error occurred: {ex.Message}");
            return new string[0]; // Return an empty array in case of error
        }
    }
}

// Main program entry point
class Program
{
    static void Main(string[] args)
    {
        // Input and output file paths
        string inputFilePath = "unsorted-names-list.txt";
        string outputFilePath = "sorted-names-list.txt";

        // Create an instance of NamesProcessor with concrete implementations of dependencies
        var namesProcessor = new NamesProcessor(new FileNamesReader(), new LastNameFirstNamesSorter(), new FileNamesWriter());
        
        // Process names
        string[] sortedNames = namesProcessor.ProcessNames(inputFilePath, outputFilePath);
    }
}
