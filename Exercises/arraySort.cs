/* Use a one-dimensional array to solve the following problem: Read in 20 numbers, each of which is between 10 and 100, inclusive. 
As each number is read, validate it and store it in the array only if it is not a duplicate of a number already read. 
After reading all the values, display only the unique values that the user entered. 
Provide for the “worst case” in which all 20 numbers are different.*/
using System;
using System.Linq;

class Arrays
{
    static void Main()
    {
        Random randomNumbers = new Random();

        // randomly generate array, duplicates permitted
        int[] arrayDup = new int[20];
        for (int i = 0; i < arrayDup.Length; i++)
        {
            arrayDup[i] = randomNumbers.Next(10, 100); // Random number generator between 10 and 100
        }

        //sort and display original array, duplicates permitted
        Console.WriteLine($"Array (original, with duplicates allowed):");
        var sortedArrayDup = arrayDup.OrderBy(value => value).ToArray();
        foreach (var value in sortedArrayDup)
        {
            Console.Write(value + " ");
        }
        // Remove duplicates using Distinct, sort and display updated array without duplicates
        var arrayNoDup = arrayDup.Distinct().OrderBy(value => value).ToArray();
        Console.WriteLine($"\nArray (duplicates removed):");
        foreach (var value in arrayNoDup)
        {
            Console.Write(value + " ");
        }
        Console.WriteLine("\n");

        // Worst case scenario - using random number generator adding if statement to ensure distinctness in numbers
        int[] arrayUnique = new int[20];
        int index = 0;
        while (index < 20)
        {
            int value = randomNumbers.Next(10, 100);
            if (!arrayUnique.Contains(value)) // Ensuring each number is distinct
            {
                arrayUnique[index] = value;
                index++;
            }
        }

        // Sort and display the unique numbers array (worst-case scenario)
        Console.WriteLine($"Array (worst-case, all unique values):");
        var sortedArrayUnique = arrayUnique.OrderBy(value => value).ToArray();
        foreach (var value in sortedArrayUnique)
        {
            Console.Write(value + " ");
        }
    }
}
