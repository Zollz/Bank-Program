using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using SplashKitSDK;


class TransferTransaction
{
    private Account _toAccount;
    private Account _fromAccount;
    private decimal _amount;
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

    public bool Success
    {
        get { return _theWithdraw.Success && _theDeposit.Success; }
    }

    public void Print()
    {
        Console.WriteLine("Transferred $" + _amount + " from  Jeffs's Account to My Account");
    }

    public void Execute()
    {
        _theWithdraw.Execute();

        if (_theWithdraw.Success)
        {
            _theDeposit.Execute();

            if (_theDeposit.Success)
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