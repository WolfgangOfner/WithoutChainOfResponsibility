using System;
using System.Collections.Generic;

namespace WithoutChainOfResponsibility
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var employees = new List<Employee>
            {
                new Employee("Tom", "Marketing", 0),
                new Employee("Susan", "Teamleader Marketing", 10_000),
                new Employee("Lisa", "Area Manager Marketing", 100_000),
                new Employee("Wolfgang", "CEO", 1_000_000_000)
            };

            while (true)
            {
                decimal expenseReportAmount;

                Console.WriteLine("Enter report amount or -1 to end program");
                var input = Console.ReadLine();

                try
                {
                    expenseReportAmount = Convert.ToDecimal(input);
                }
                catch (Exception)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Your input was not a valid decimal number\n");
                    Console.ResetColor();
                    continue;
                }

                if (expenseReportAmount == -1)
                {
                    break;
                }

                var expensesProcessed = false;
                IExpenseReport expense = new ExpenseReport(expenseReportAmount);

                foreach (var item in employees)
                {
                    var response = item.ApproveExpense(expense);

                    if (response != ApprovalResponse.BeyondApprovalLimit)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine($"The request was {response}\n");
                        Console.ResetColor();
                        expensesProcessed = true;
                        break;
                    }
                }

                if (!expensesProcessed)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("The amount was too high. No one can approve such a high number\n");
                    Console.ResetColor();
                }
            }

            Console.ReadKey();
        }
    }
}