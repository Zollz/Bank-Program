using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using SplashKitSDK;


public class TransferTransaction : Transaction
{
    private Account _toAccount;
    private Account _fromAccount;
    private WithdrawTransaction _theWithdraw;
    private DepositTransaction _theDeposit;

    public TransferTransaction(Account fromAccount, Account toAccount, decimal amount)
    {
        _amount = amount;
        _toAccount = toAccount;
        _fromAccount = fromAccount;
        DepositTransaction theDeposit = new DepositTransaction(_toAccount, _amount);
        WithdrawTransaction theWithdraw = new WithdrawTransaction(_fromAccount, _amount);
        _theWithdraw = theWithdraw;
        _theDeposit = theDeposit;
    }

    public override void Print()
    {
        Console.WriteLine("Transferred ${0} from {1}'s Account to {2}'s Account", _amount, _fromAccount.Name, _toAccount.Name);
    }

    public override void Execute()
    {
        base.Execute();
        _theWithdraw.Execute();

        if (_theWithdraw.Success)
        {
            _theDeposit.Execute();

            if (!_theDeposit.Success)
            {
                _fromAccount.Deposit(_amount);
            }
        }
        else
        {
            Console.WriteLine("Transfer not successful");
        }
    }

}