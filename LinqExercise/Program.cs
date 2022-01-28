using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqExercise
{
    class Program
    {
        //Static array of integers
        private static int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0 };

        static void Main(string[] args)
        {
            /*
             * 
             * Complete every task using Method OR Query syntax.
             *
             * HINT: Use the List of Methods defined in the Lecture Material Google Doc ***********
             *
             * You may find that Method syntax is easier to use since it is most like C#
             * Every one of these can be completed using Linq and then printing with a foreach loop.
             * Push to your github when completed!
             * 
             */

            //Print the Sum and Average of numbers
            var numbersSum = numbers.Sum();
            Console.WriteLine($"Sum: {numbersSum}");
            var numbersAverage = numbers.Average();
            Console.WriteLine($"\nAverage: {numbersAverage}");

            //Order numbers in ascending order and decsending order. Print each to console.
            var numbersAsc = numbers.OrderBy(x => x);
            Console.WriteLine("\nAscending:");
            numbersAsc.ToList().ForEach(num => Console.WriteLine(num));

            var numbersDes = numbers.OrderByDescending(x => x);
            Console.WriteLine("\nDescending:");
            numbersDes.ToList().ForEach(num => Console.WriteLine(num));

            //Print to the console only the numbers greater than 6
            var numbers6 = numbers.Where(x => x > 6);
            Console.WriteLine("\nGreater than 6:");
            numbers6.ToList().ForEach(num => Console.WriteLine(num));

            //Order numbers in any order (acsending or desc) but only print 4 of them **foreach loop only!**
            var numbers4 = numbersDes.Take(4);
            Console.WriteLine("\nThe 4 largest numbers:");
            numbers4.ToList().ForEach(num => Console.WriteLine(num));

            //Change the value at index 4 to your age, then print the numbers in decsending order
            numbers[4] = 20;
            var numbersNewDes = numbers.OrderByDescending(x => x);
            Console.WriteLine("\nDescending with my age:");
            numbersNewDes.ToList().ForEach(num => Console.WriteLine(num));

            // List of employees ***Do not remove this***
            var employees = CreateEmployees();

            //Print all the employees' FullName properties to the console only if their FirstName starts with a C OR an S.
            //Order this in acsending order by FirstName.
            var employeesFirNamCS = employees.Where(emp => emp.FirstName[0] == 'C' || emp.FirstName[0] == 'S');
            var employeesFirNamAcs = employeesFirNamCS.OrderBy(emp => emp.FirstName);
            Console.WriteLine("\nEmployees with C or S in acsending order:");
            employeesFirNamAcs.ToList().ForEach(emp => Console.WriteLine(emp.FullName));

            //Print all the employees' FullName and Age who are over the age 26 to the console.
            //Order this by Age first and then by FirstName in the same result.
            var employeesOv26 = employees.Where(emp => emp.Age > 26);
            var employeesOv26Asc = employeesOv26.OrderBy(emp => emp.FirstName).OrderBy(emp => emp.Age);
            Console.WriteLine("\nEmployees over 26 in ascending order:");
            employeesOv26Asc.ToList().ForEach(emp => Console.WriteLine(emp.FullName + " " + emp.Age));

            //Print the Sum and then the Average of the employees' YearsOfExperience
            //if their YOE is less than or equal to 10 AND Age is greater than 35
            var employeesYOE = employees.Where(emp => emp.YearsOfExperience <= 10 && emp.Age > 35);
            var employeesSum = employeesYOE.Sum(emp => emp.YearsOfExperience);
            var employeesAvg = employeesYOE.Average(emp => emp.YearsOfExperience);
            Console.WriteLine($"\nSum of Years of Experience: {employeesSum}");
            Console.WriteLine($"\nAverage of Years of Experience: {employeesAvg}");

            //Add an employee to the end of the list without using employees.Add()
            employees.Append(new Employee("Jaylon", "Carter", 20, 5));
            
            Console.WriteLine();

            Console.ReadLine();
        }

        #region CreateEmployeesMethod
        private static List<Employee> CreateEmployees()
        {
            List<Employee> employees = new List<Employee>();
            employees.Add(new Employee("Cruz", "Sanchez", 25, 10));
            employees.Add(new Employee("Steven", "Bustamento", 56, 5));
            employees.Add(new Employee("Micheal", "Doyle", 36, 8));
            employees.Add(new Employee("Daniel", "Walsh", 72, 22));
            employees.Add(new Employee("Jill", "Valentine", 32, 43));
            employees.Add(new Employee("Yusuke", "Urameshi", 14, 1));
            employees.Add(new Employee("Big", "Boss", 23, 14));
            employees.Add(new Employee("Solid", "Snake", 18, 3));
            employees.Add(new Employee("Chris", "Redfield", 44, 7));
            employees.Add(new Employee("Faye", "Valentine", 32, 10));

            return employees;
        }
        #endregion
    }
}
