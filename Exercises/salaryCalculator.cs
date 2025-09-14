/*(Salary Calculator) Develop a C# app that will determine the gross pay for each of five employees. 
The company pays straight time for the first 50 hours worked by each employee and triple for all hours worked in excess of 50 hours. 
You’re given a list of the five employees of the company, the number of hours each employee worked last week and the hourly rate of each employee. 
Your app should input this information for each employee, then should determine and display the employee’s gross pay. 
*/
using System;

class Employee
{
    // Properties for the employee details
    public int EmployeeID { get; set; }
    public int HoursWorked { get; set; }
    public double HourlyRate { get; set; }

    // Method for calculating gross pay
    public double GrossPay
    {
        get
        {
            if (HoursWorked <= 50)
            {
                return HoursWorked * HourlyRate;
            }
            else
            {
                double overtimeHours = HoursWorked - 50;
                return (50 * HourlyRate) + (overtimeHours * HourlyRate * 3);
            }
        }
    }
}

class GrossPay
{
    //Main method begins execution of C# program
    static void Main()
    {
        Employee[] employees = new Employee[5];

        Console.WriteLine("Enter the details for three employees:");

        for (int i = 0; i < 5; i++)
        {
            employees[i] = new Employee();

            Console.WriteLine($"Employee # {i + 1}");

            Console.Write("Enter Employee ID: "); //prompt user
            //read employee ID
            employees[i].EmployeeID = int.Parse(Console.ReadLine());

            Console.Write("Enter the number of hours the employee worked: "); //prompt user
            //read the employee's number of hours worked
            employees[i].HoursWorked = int.Parse(Console.ReadLine());

            Console.Write("Enter the employee's hourly rate: "); //prompt user
            //read the employee's hourly rate
            employees[i].HourlyRate = double.Parse(Console.ReadLine());
        }
        //summary
        Console.WriteLine("Gross Pay Details for the 5 employees:");
        for (int i = 0; i < 5; i++)
        {
            Console.WriteLine($"Employee ID: {employees[i].EmployeeID}, Gross Pay: {employees[i].GrossPay:c}");
        }
    } //end Main
} //end class GrossPay
