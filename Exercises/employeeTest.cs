/*(Employee Class) Create a class called Employee that includes two instance variables—a name (type String) and a monthly salary (double). 
Provide a constructor that initializes the two instance variables. 
Provide a set and a get method for each instance variable. If the monthly salary is not positive, do not set its value. 
Write a test app named EmployeeTest that demonstrates class Employee’s capabilities. Create two Employee objects and display each object’s yearly salary. 
Then give each Employee a 50% raise and display each Employee’s yearly salary again. */

using System;

namespace EmployeeClass
{
    class Employee
    {
        private string name;
        private double salary;

        // Constructor
        public Employee(string name, double salary)
        {
            this.name = name;

            if (salary > 0)
                this.salary = salary;
            else
                this.salary = 0;
        }

        // set and get name
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        // set and get salary
        public double Salary
        {
            get { return salary; }
            set
            {
                if (value > 0)
                    salary = value;
            }
        }
    }

    class EmployeeTest
    {
        static void Main(string[] args)
        {
            // Create employee objects
            Employee employee1 = new Employee("Lisa Vanderpump", 21000);
            Employee employee2 = new Employee("Ken Todd", 20000);

            // yearly salaries before adjustment
            Console.WriteLine("Yearly Salaries before adjustment:");
            Console.WriteLine("{0}: ${1}", employee1.Name, employee1.Salary * 12);
            Console.WriteLine("{0}: ${1}", employee2.Name, employee2.Salary * 12);

            // equation to apply 50% raise
            employee1.Salary = employee1.Salary * 1.5;
            employee2.Salary = employee2.Salary * 1.5;

            //yearly salaries after adjustment/raise
            Console.WriteLine("\nYearly Salaries with 50% Raise:");
            Console.WriteLine("{0}: ${1}", employee1.Name, employee1.Salary * 12);
            Console.WriteLine("{0}: ${1}", employee2.Name, employee2.Salary * 12);

            Console.ReadLine();
        }
    }
}
