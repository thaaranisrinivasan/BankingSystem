using System;
using Bank_10.Entity;
using Bank_10.DAO;

namespace Bank_10.Main
{
    class BankApp
    {
        static void Main()
        {
            Bank bank = new Bank();
            while (true)
            {
                Console.WriteLine("+-----------------------------+");
                Console.WriteLine("|       BANK SYSTEM MENU      |");
                Console.WriteLine("+-----------------------------+");
                Console.WriteLine("| 1. Create Account           |");
                Console.WriteLine("| 2. Deposit                  |");
                Console.WriteLine("| 3. Withdraw                 |");
                Console.WriteLine("| 4. Transfer                 |");
                Console.WriteLine("| 5. Get Account Details      |");
                Console.WriteLine("| 6. Exit                     |");
                Console.WriteLine("+-----------------------------+");
                Console.Write("Enter choice: ");

                int choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        Console.Write("Enter Customer ID: ");
                        int id = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Enter First Name: ");
                        string firstName = Console.ReadLine();
                        Console.Write("Enter Last Name: ");
                        string lastName = Console.ReadLine();
                        Console.Write("Enter Email: ");
                        string email = Console.ReadLine();
                        Console.Write("Enter Phone: ");
                        string phone = Console.ReadLine();
                        Console.Write("Enter Address: ");
                        string address = Console.ReadLine();

                        Customer customer = new Customer(id, firstName, lastName, email, phone, address);

                        Console.Write("Enter Account Type (Savings/Current): ");
                        string accType = Console.ReadLine();
                        Console.Write("Enter Initial Balance: ");
                        float balance = float.Parse(Console.ReadLine());

                        Account acc = bank.CreateAccount(customer, accType, balance);
                        acc.DisplayAccountInfo();
                        break;

                    case 2:
                        Console.Write("Enter Account Number: ");
                        long depAccNo = long.Parse(Console.ReadLine());
                        Console.Write("Enter Deposit Amount: ");
                        float depAmount = float.Parse(Console.ReadLine());
                        Console.WriteLine("New Balance: " + bank.Deposit(depAccNo, depAmount));
                        break;

                    case 3:
                        Console.Write("Enter Account Number: ");
                        long withAccNo = long.Parse(Console.ReadLine());
                        Console.Write("Enter Withdrawal Amount: ");
                        float withAmount = float.Parse(Console.ReadLine());
                        Console.WriteLine("New Balance: " + bank.Withdraw(withAccNo, withAmount));
                        break;

                    case 4:
                        Console.Write("Enter From Account Number: ");
                        long fromAcc = long.Parse(Console.ReadLine());
                        Console.Write("Enter To Account Number: ");
                        long toAcc = long.Parse(Console.ReadLine());
                        Console.Write("Enter Transfer Amount: ");
                        float transferAmount = float.Parse(Console.ReadLine());
                        bank.Transfer(fromAcc, toAcc, transferAmount);
                        break;

                    case 5:
                        Console.Write("Enter Account Number: ");
                        long accNo = long.Parse(Console.ReadLine());
                        bank.GetAccountDetails(accNo);
                        break;

                    case 6:
                        return;
                }
            }
        }
    }
}
