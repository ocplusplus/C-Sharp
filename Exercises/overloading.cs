using System;

class CalculateOverload
{    
    //test overloaded perimeter methods
    static void Main()
    {
        int length;
        int width;

        Console.Write("Enter an integer length(cm) for a rectangle: "); //prompt user
       //read length from user
        length = int.Parse(Console.ReadLine());
        Console.Write("Enter an integer width(cm) for a rectangle: "); //prompt user
        //read length from user
        width = int.Parse(Console.ReadLine());

        Console.WriteLine($"Perimeter of the rectangle with {length}cm length and {width}cm width is {Perimeter(length,width)}cm.");

        Console.Write("Enter an integer length(cm) for a square: "); //prompt user
        //read length from user
        length = int.Parse(Console.ReadLine());

        Console.WriteLine($"Perimeter of the square with {length}cm length is {Perimeter(length)}cm.");
    }
    static int Perimeter(int length, int width) //function for rectangle perimeter calculation
    {
        return 2 * length + 2 * width;
    }
    static int Perimeter(int length) //function for square perimeter calculation
    {
        return 4 * length;
    }
}
