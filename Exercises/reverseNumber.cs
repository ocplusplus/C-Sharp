//Write an application that takes a number and displays it with its digits reversed. 

using System;
class ReverseNumber
{
    static int reverse(int userNumber)
    {
        int reverseNumber = 0; //initialize reverse number at zero
        int remainder; //remainder for calculating reverse number

        //calculate reverse number
        while (userNumber != 0)
        {
            remainder = userNumber % 10;
            reverseNumber = reverseNumber * 10 + remainder;
            userNumber = userNumber / 10;
        }
        return reverseNumber;
    }
    public static void Main()
        //Main method begins execution of C# program
        {
             int userNumber; //number that the user inputs

            Console.Write("Enter a number: "); //prompt user
           //read prompt from user
           userNumber = int.Parse(Console.ReadLine());
       
        Console.Write("Reversed number: " + reverse(userNumber));
        }
}
