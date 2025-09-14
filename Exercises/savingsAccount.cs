/*Create the class SavingsAccount. Use the static read-write property AnnualInterestRate to store the annual interest rate for all account holders. 
Each object of the class contains a property SavingsBalance, indicating the amount the saver currently has on deposit. 
Provide method CalculateMonthlyInterest to calculate the monthly interest by multiplying the SavingsBalance by AnnualInterestRate 
divided by 12-this interest should be added to savings-Balance. Write an app to test class SavingsAccount. Create two savingsAccount objects, 
saver1 and saver2, with balances of $2000.00 and $3000.00, respectively. Set AnnualInterestRate to 4% then calculate the monthly interest and display 
the new balances for both savers. Then set the AnnualInterestRate to 5%, calculate the next month’s interest and display the new balances for both savers.*/

using System;

public class SavingsAccount
{
    private static double annualInterestRate; //read-write property for all account holders
    private double savingsBalance; 

    // Constructor
    public SavingsAccount(double initialBalance)
    {
        savingsBalance = initialBalance;
    }

    // static property
    public static double AnnualInterestRate
    {
        get { return annualInterestRate; }
        set { annualInterestRate = value; }
    }

    // instance property
    public double SavingsBalance
    {
        get { return savingsBalance; }
    }

    // method to calculate and apply the monthly interest to each account balance
    public void CalculateMonthlyInterest()
    {
        double monthlyInterest = (savingsBalance * annualInterestRate) / 12;
        savingsBalance += monthlyInterest;
    }
}

// test app for class SavingsAccount
class SavingsAccountTest
{
    static void Main()
    {
        // saver1 and saver2 accounts for testing
        SavingsAccount saver1 = new SavingsAccount(2000.00);
        SavingsAccount saver2 = new SavingsAccount(3000.00);

        // set interest rate at 4% for first test
        SavingsAccount.AnnualInterestRate = 0.04;

        // call the calculation for the 4% interest for each account
        saver1.CalculateMonthlyInterest();
        saver2.CalculateMonthlyInterest();

        //output of balances after 1 month at 4% interest
        Console.WriteLine("After 1 month at 4% interest:");
        Console.WriteLine("Saver1 balance: $" + Math.Round(saver1.SavingsBalance, 2).ToString("0.00"));
        Console.WriteLine("Saver2 balance: $" + Math.Round(saver2.SavingsBalance, 2).ToString("0.00"));

        // Set interest rate to 5% (0.05)
        SavingsAccount.AnnualInterestRate = 0.05;

        // call the calculation for the 5% interest for each account for the next month
        saver1.CalculateMonthlyInterest();
        saver2.CalculateMonthlyInterest();

        //output of balances after 1 month at 5% interest after 1 month at 4% interest
        Console.WriteLine("\nAfter 1 more month, but at 5% interest:");
        Console.WriteLine("Saver1 balance: $" + Math.Round(saver1.SavingsBalance, 2).ToString("0.00"));
        Console.WriteLine("Saver2 balance: $" + Math.Round(saver2.SavingsBalance, 2).ToString("0.00"));
    }
}
