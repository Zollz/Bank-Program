using System;
using System.Collections.Generic;
using SplashKitSDK;



public class WithdrawTransaction : Transaction
{
    private Account _account;

    public WithdrawTransaction(Account account, decimal amount)
    {

        _account = account;
        _amount = amount;
    }

    public override void Execute()
    {
        base.Execute();
        _success = _account.Withdraw(_amount);
    }

    public override void Print()
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

