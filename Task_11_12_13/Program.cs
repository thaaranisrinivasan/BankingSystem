using System;
using System.Collections.Generic;
using BankingApplication.Entity;
using BankingApplication.Exception;

namespace BankingApplication.Main
{
    class Program
    {
        static List<Account> accounts = new List<Account>(); // Stores all accounts

        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("\n===== BANKING SYSTEM MENU =====");
                Console.WriteLine("1. Create Account");
                Console.WriteLine("2. Deposit Money");
                Console.WriteLine("3. Withdraw Money");
                Console.WriteLine("4. Display Account Details");
                Console.WriteLine("5. Exit");
                Console.Write("Enter your choice: ");

                if (!int.TryParse(Console.ReadLine(), out int choice))
                {
                    Console.WriteLine("Invalid choice! Please enter a number.");
                    continue;
                }

                switch (choice)
                {
                    case 1:
                        CreateAccount();
                        break;
                    case 2:
                        DepositMoney();
                        break;
                    case 3:
                        WithdrawMoney();
                        break;
                    case 4:
                        DisplayAccounts();
                        break;
                    case 5:
                        Console.WriteLine("Exiting program. Thank you!");
                        return;
                    default:
                        Console.WriteLine("Invalid choice! Try again.");
                        break;
                }
            }
        }

        static void CreateAccount()
        {
            Console.Write("\nEnter Name: ");
            string name = Console.ReadLine() ?? "Unknown";

            Console.Write("Enter Email: ");
            string email = Console.ReadLine() ?? "Unknown";

            Console.Write("Enter Phone Number: ");
            if (!long.TryParse(Console.ReadLine(), out long phoneNumber))
            {
                Console.WriteLine("Invalid phone number! Account not created.");
                return;
            }

            Customer customer = new Customer(phoneNumber, name, email);

            Console.WriteLine("\nSelect Account Type:");
            Console.WriteLine("1. Savings Account");
            Console.WriteLine("2. Current Account");
            Console.WriteLine("3. Zero Balance Account");
            Console.Write("Enter your choice: ");

            if (!int.TryParse(Console.ReadLine(), out int accType))
            {
                Console.WriteLine("Invalid choice! Account not created.");
                return;
            }

            Account newAccount = null;

            switch (accType)
            {
                case 1:
                    Console.Write("Enter Initial Balance: ");
                    if (!double.TryParse(Console.ReadLine(), out double savingsBalance))
                    {
                        Console.WriteLine("Invalid amount! Account not created.");
                        return;
                    }
                    Console.Write("Enter Interest Rate: ");
                    if (!double.TryParse(Console.ReadLine(), out double interestRate))
                    {
                        Console.WriteLine("Invalid interest rate! Account not created.");
                        return;
                    }
                    newAccount = new SavingsAccount(savingsBalance, customer, interestRate);
                    break;

                case 2:
                    Console.Write("Enter Initial Balance: ");
                    if (!double.TryParse(Console.ReadLine(), out double currentBalance))
                    {
                        Console.WriteLine("Invalid amount! Account not created.");
                        return;
                    }
                    Console.Write("Enter Overdraft Limit: ");
                    if (!double.TryParse(Console.ReadLine(), out double overdraftLimit))
                    {
                        Console.WriteLine("Invalid overdraft limit! Account not created.");
                        return;
                    }
                    newAccount = new CurrentAccount(currentBalance, customer, overdraftLimit);
                    break;

                case 3:
                    newAccount = new ZeroBalanceAccount(customer);
                    break;

                default:
                    Console.WriteLine("Invalid choice! Account not created.");
                    return;
            }

            accounts.Add(newAccount);
            Console.WriteLine($"Account Created Successfully! Account No: {newAccount.AccountNumber}");
        }

        static void DepositMoney()
        {
            Console.Write("\nEnter Account Number: ");
            if (!long.TryParse(Console.ReadLine(), out long accNumber))
            {
                Console.WriteLine("Invalid account number!");
                return;
            }

            Account acc = accounts.Find(a => a.AccountNumber == accNumber);
            if (acc == null)
            {
                Console.WriteLine("Account not found!");
                return;
            }

            Console.Write("Enter Deposit Amount: ");
            if (!double.TryParse(Console.ReadLine(), out double amount))
            {
                Console.WriteLine("Invalid amount!");
                return;
            }

            acc.Deposit(amount);
            Console.WriteLine($"Amount Deposited Successfully! New Balance: {acc.Balance}");
        }

        static void WithdrawMoney()
        {
            Console.Write("\nEnter Account Number: ");
            if (!long.TryParse(Console.ReadLine(), out long accNumber))
            {
                Console.WriteLine("Invalid account number!");
                return;
            }

            Account acc = accounts.Find(a => a.AccountNumber == accNumber);
            if (acc == null)
            {
                Console.WriteLine("Account not found!");
                return;
            }

            Console.Write("Enter Withdrawal Amount: ");
            if (!double.TryParse(Console.ReadLine(), out double amount))
            {
                Console.WriteLine("Invalid amount!");
                return;
            }

            try
            {
                acc.Withdraw(amount);
                Console.WriteLine($"Withdrawal Successful! New Balance: {acc.Balance}");
            }
            catch (InsufficientFundException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            catch (OverDraftLimitExceededException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            
        }

        static void DisplayAccounts()
        {
            if (accounts.Count == 0)
            {
                Console.WriteLine("\nNo accounts found!");
                return;
            }

            Console.WriteLine("\n===== ACCOUNT DETAILS =====");
            foreach (var acc in accounts)
            {
                Console.WriteLine(acc);
            }
        }
    }
}
