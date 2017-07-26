using System;
using System.Collections.Generic;
using System.Text;



public class DepositTransaction
{
    private Account _account;
    private decimal _amount;
    private bool _success = false;

    public bool Success
    {
        get { return _success; }
    }

    public DepositTransaction(Account account, decimal amount)
    {
        _account = account;
        _amount = amount;
    }

    public void Execute()
    {
        _success = _account.Deposit(_amount);
    }

    public void Print()
    {
        if (Success == true)
        {
            Console.WriteLine("You have successfully deposited {0}", _amount);
        }
        else
        {
            Console.WriteLine("Unsuccessful Deposit");
        }

    }
}
