using System;
using task_9.Entity;
using task_9.DAO;

namespace task_9
{
    class Program
    {
        static void Main()
        {
            BankAccount account = null;
            Console.WriteLine("Choose account type:\n1. Savings Account\n2. Current Account");
            int choice = int.Parse(Console.ReadLine());

            Console.Write("Enter Account Number: ");
            int accNumber = int.Parse(Console.ReadLine());
            Console.Write("Enter Customer Name: ");
            string name = Console.ReadLine();
            Console.Write("Enter Initial Balance: ");
            float balance = float.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    Console.Write("Enter Interest Rate: ");
                    float interestRate = float.Parse(Console.ReadLine());
                    account = new SavingsAccount(accNumber, name, balance, interestRate);
                    break;
                case 2:
                    account = new CurrentAccount(accNumber, name, balance);
                    break;
                default:
                    Console.WriteLine("Invalid choice.");
                    return;
            }

            int option;
            do
            {
                Console.WriteLine("\nMenu:\n1. Deposit\n2. Withdraw\n3. Calculate Interest\n4. Display Account Info\n5. Exit");
                Console.Write("Enter option: ");
                option = int.Parse(Console.ReadLine());

                switch (option)
                {
                    case 1:
                        Console.Write("Enter amount to deposit: ");
                        float depositAmount = float.Parse(Console.ReadLine());
                        account.Deposit(depositAmount);
                        break;
                    case 2:
                        Console.Write("Enter amount to withdraw: ");
                        float withdrawAmount = float.Parse(Console.ReadLine());
                        account.Withdraw(withdrawAmount);
                        break;
                    case 3:
                        account.CalculateInterest();
                        break;
                    case 4:
                        account.DisplayInfo();
                        break;
                    case 5:
                        Console.WriteLine("Exiting application...");
                        break;
                    default:
                        Console.WriteLine("Invalid option.");
                        break;
                }
            } while (option != 5);
        }
    }
}
