using System;
using System.Collections.Generic;
using SplashKitSDK;



public class WithdrawTransaction
{
    private Account _account;
    private decimal _amount;
    private bool _success = false;

    public bool Success
    {
        get { return _success; }
    }

    public WithdrawTransaction(Account account, decimal amount)
    {

        _account = account;
        _amount = amount;
    }

    public void Execute()
    {
        _success = _account.Withdraw(_amount);
    }

    public void Print()
    {
        if (Success == true)
        {
            Console.WriteLine("You have successfully withdrew {0}", _amount);
        }
        else
        {
            Console.WriteLine("Unsuccessful Withdrawal");
        }

    }
}

