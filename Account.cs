using System;
using SplashKitSDK;



public class Account
{
    private decimal _balance;
    private string _name;


    public Account(string name, decimal startingBalance)
    {
        _name = name;
        _balance = startingBalance;
        Console.WriteLine("Your name is {0} your account balance is ${1}", _name, _balance);
    }

    public bool Deposit(decimal amountToAdd)
    {
        if (amountToAdd > 0)
        {
            _balance += amountToAdd;
            return true;
        }
        return false;
    }

    public bool Withdraw(decimal amountToSubtract)
    {
        if (amountToSubtract > _balance)
        {
            Console.WriteLine("Not enough in balance.");
            return false;
        }

        if (amountToSubtract > 0)
        {
            _balance -= amountToSubtract;
            return true;
        }
        return false;
    }

    public void Print()
    {
        Console.WriteLine("{0}'s account has ${1} in its balance", _name , _balance);
    }

    public string Name
    {
        get { return _name; }
    }

}

