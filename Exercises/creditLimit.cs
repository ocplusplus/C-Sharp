 /*Develop a C# application that will determine whether any of several department-store customers has exceeded the credit limit on a charge account. 
 For each customer, the following facts are available (use a sentinel value): account number, balance at the beginning of the month, 
 total of all items charged by the customer this month, total of all credits applied to the customer’s account this month and allowed credit limit. 
 The program should input all these facts as double values, calculate the new balance (= beginning balance + charges – credits), 
 display the new balance and determine whether the new balance exceeds the customer’s credit limit. For those customers whose credit limit is exceeded, 
 the program should display the message "Credit limit exceeded". */
using System;

class BankAccount 
{
    //properties for account details
    public string AccountNumber { get; set; }
    public decimal StartBalance { get; set; }
    public decimal Charges { get; set; }
    public decimal Credits { get; set; }
    public decimal CreditLimit { get; set; }

    //constructor initializes account details
    public BankAccount(string accountNumber, decimal startBalance, decimal charges, decimal credits, decimal creditLimit)
    {
        AccountNumber = accountNumber;
        StartBalance = startBalance;
        Charges = charges;
        Credits = credits;
        CreditLimit = creditLimit;
    }

    //method for calculating the new balance
    public decimal CalculateNewBalance()
    {
        return StartBalance + Charges - Credits;
    }

    //method for calculating whether credit limit is exceeded
    public bool IsCreditLimitExceeded()
    {
        return CalculateNewBalance() > CreditLimit;
    }
}

class Program
{
    //Main method begins execution of C# program
    static void Main()
    {
        //loop to process multiple customer account details
        while (true)
        {
            Console.WriteLine("Enter account number (or '0' to quit):"); //prompt user
            //read customer's account number
            string accountNumber = Console.ReadLine();

            if (accountNumber == "0")
                break;

            Console.WriteLine("Enter starting balance:"); //prompt user
            //read starting balance for customer
            decimal startBalance = decimal.Parse(Console.ReadLine());

            Console.WriteLine("Enter total charges:"); //prompt user
            //read total charges for customer
            decimal charges = decimal.Parse(Console.ReadLine());

            Console.WriteLine("Enter total credits:"); //prompt user
            //read total credits for customer
            decimal credits = decimal.Parse(Console.ReadLine());

            Console.WriteLine("Enter credit limit:"); //prompt user
            //read customer's credit limit
            decimal creditLimit = decimal.Parse(Console.ReadLine());

            //new bank account object
            BankAccount account = new BankAccount(accountNumber, startBalance, charges, credits, creditLimit);
            decimal newBalance = account.CalculateNewBalance();

            //account summary
            Console.WriteLine($"Account #{account.AccountNumber}");
            Console.WriteLine($"New balance: {newBalance}");

            //check if credit limit is exceeded
            if (account.IsCreditLimitExceeded())
            {
                Console.WriteLine("Credit limit exceeded.");
            }
            else
            {
                decimal remainingCredit = account.CreditLimit - newBalance;
                Console.WriteLine($"Remaining credit: {remainingCredit}");
            }
        }

        Console.WriteLine("Program ended.");
    }
}
