using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;


class TransferTransaction
{
    private Account _toAccount;
    private Account _fromAccount;
    private decimal _amount;
    private WithdrawTransaction _theWithdraw;
    private DepositTransaction _theDeposit;

    public TransferTransaction(Account fromAccount, Account toAccount, decimal amount)
    {
        WithdrawTransaction theWithdraw = new WithdrawTransaction(_fromAccount, _amount);
        DepositTransaction theDeposit = new DepositTransaction(_toAccount, _amount);
        _theWithdraw = theWithdraw;
        _theDeposit = theDeposit;
        _amount = amount;
        _toAccount = toAccount;
        _fromAccount = fromAccount;

    }

    public bool Success
    {
        get { return _theWithdraw.Success && _theDeposit.Success; }
    }

    public void Print()
    {
        Console.WriteLine("Transferred $" + _amount + " from " + _fromAccount + "'s Account to My Account");
    }

    public void Execute()
    {
        _theWithdraw.Execute();

        if (_theWithdraw.Success == true)
        {
            _theDeposit.Execute();

            if (_theDeposit.Success == true)
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

