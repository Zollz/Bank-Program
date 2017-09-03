using System;
using System.Collections.Generic;
using System.Text;


public class Bank
{

    private List<Account> _account = new List<Account>();
    private List<Transaction> _transactionHistory = new List<Transaction>();


    public void AddAccount(Account account)
    {
        _account.Add(account);
    }

    public Account GetAccount(string name)
    {
        foreach (Account account in _account)
        {
            if (string.Equals(name, account.Name, StringComparison.CurrentCultureIgnoreCase))
            {
                return account;
            }
        }
        return null;
    }

    public void ExecuteTransaction(Transaction transaction)
    {
        _transactionHistory.Add(transaction);
        transaction.Execute();
    }

    public void PrintTransactionHistory()
    {
        foreach(Transaction transaction in _transactionHistory)
        {
            transaction.Print();
        }
    }
}

