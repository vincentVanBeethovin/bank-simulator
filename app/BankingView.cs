using System;
using ATMApp.Services;

namespace ATMApp.View
{
    public static class BankingView
    {
        public static void Run()
        {
            double balance = 1000.00;
            Console.WriteLine("Vincent Ray A. Vinzon");
            Console.WriteLine("=== Simple ATM System ===");
            Console.WriteLine();
            Console.WriteLine($"Initial Balance: Php{balance:F2}");
            Console.WriteLine();

            while (true)
            {
                Console.WriteLine("1. Check Balance");
                Console.WriteLine("2. Deposit Money");
                Console.WriteLine("3. Withdraw Money");
                Console.WriteLine("4. Print Mini Statement");
                Console.WriteLine("5. Exit");
                Console.Write("Enter your choice: ");
                
                if (!int.TryParse(Console.ReadLine(), out int choice))
                {
                    Console.WriteLine("Invalid Choice Selected. Please try again.\n");
                    continue;
                }

                switch (choice)
                {
                    case 1:
                        Console.WriteLine($"Current Balance: Php{BankingServices.GetBalance(balance):F2}\n");
                        break;
                    case 2:
                        Console.Write("Enter amount to deposit: ");
                        if (!double.TryParse(Console.ReadLine(), out double depositAmount) || !BankingServices.Deposit(ref balance, depositAmount))
                        {
                            Console.WriteLine("Invalid deposit amount. Please enter a positive number.\n");
                            continue;
                        }
                        Console.WriteLine("Deposit successful.");
                        Console.WriteLine($"Updated Balance: Php{balance:F2}\n");
                        break;
                    case 3:
                        Console.Write("Enter amount to withdraw: ");
                        if (!double.TryParse(Console.ReadLine(), out double withdrawAmount))
                        {
                            Console.WriteLine("Invalid withdrawal amount. Please enter a positive number.\n");
                            continue;
                        }
                        BankingServices.Withdraw(ref balance, withdrawAmount, out bool success);
                        if (!success)
                        {
                            if (withdrawAmount <= 0)
                                Console.WriteLine("Invalid withdrawal amount. Please enter a positive number.\n");
                            else
                                Console.WriteLine("Withdrawal failed. Insufficient balance.\n");
                            continue;
                        }
                        Console.WriteLine("Withdrawal successful.");
                        Console.WriteLine($"Updated Balance: Php{balance:F2}\n");
                        break;
                    case 4:
                        Console.WriteLine("--- Mini Statement ---");
                        Console.WriteLine($"Current Balance: Php{balance:F2}");
                        Console.WriteLine($"Last Transaction: Php{BankingServices.GetLastTransaction():F2}\n");
                        break;
                    case 5:
                        Console.WriteLine("Thank you for using the ATM. Goodbye!");
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.\n");
                        break;
                }
            }
        }
    }
}
