public class BankingService
{
    private double _lastTransactionAmount = 0;

    public double CheckBalance(double balance)
    {
        return balance;
    }

    public void Deposit(ref double balance, double depositAmount)
    {
        if (depositAmount > 0)
        {
            balance += depositAmount;
            _lastTransactionAmount = depositAmount;
        }
        else
        {
            throw new ArgumentException("Invalid deposit amount. Please enter a positive value.");
        }
    }

    public bool Withdraw(ref double balance, double withdrawAmount, out double newBalance)
    {
        newBalance = balance;
        if (withdrawAmount <= 0)
        {
            throw new ArgumentException("Invalid withdrawal amount. Please enter a positive value.");
        }

        if (withdrawAmount <= balance)
        {
            balance -= withdrawAmount;
            newBalance = balance;
            _lastTransactionAmount = -withdrawAmount;
            return true;
        }
        else
        {
            return false;
        }
    }

    public void PrintMiniStatement(double balance)
    {
       
        Console.WriteLine("--- Mini Statement ---");
        Console.WriteLine($"Current Balance: Pesos {balance:F2}");
        Console.WriteLine($"Last Transaction Amount: Pesos {_lastTransactionAmount:F2}");
    }
}
