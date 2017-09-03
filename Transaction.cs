using System;
using System.Collections.Generic;
using System.Text;


public abstract class Transaction
{
    protected bool _success;
    protected decimal _amount;
    private DateTime _dateStamp;

    public virtual bool Success { get { return _success; } }
    public virtual DateTime DateStamp { get { return _dateStamp; } }
    public abstract void Print();

    public virtual void Execute()
    {
        _dateStamp = DateTime.Now;
    }

}

