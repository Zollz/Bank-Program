using System;
using System.Collections.Generic;
using System.Text;


public class DepositTransaction : Transaction
{
    private Account _account;

    public DepositTransaction(Account account, decimal amount)
    {
        _account = account;
        _amount = amount;
    }

    public override void Execute()
    {
        base.Execute();
        _success = _account.Deposit(_amount);
    }

    public override void Print()
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