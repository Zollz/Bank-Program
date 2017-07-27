using System;
using SplashKitSDK;

public class Program
{
    public enum MenuOption
    {
        Withdraw,
        Deposit,
        Transfer,
        Print,
        Quit
    }


    private static MenuOption ReadUserOption()
    {
        int input;
        // do while loop selection
        do
        {
            Console.WriteLine("1. Withdraw");
            Console.WriteLine("2. Deposit");
            Console.WriteLine("3. Transfer Balance");
            Console.WriteLine("4. Print Balance");
            Console.WriteLine("5. Quit");
            input = Convert.ToInt32(Console.ReadLine());
        } while (input < 1 || input > 5);
        // matching enumeration return
        return (MenuOption) (input - 1);
    }

    private static void DoWithdraw(Account account)
    {
        decimal withdraw;
        Console.WriteLine("How much would you like to withdraw?");
        withdraw = Convert.ToDecimal(Console.ReadLine());
        WithdrawTransaction newTransaction = new WithdrawTransaction(account, withdraw);
        newTransaction.Execute();
        newTransaction.Print();
    }

    private static void DoDeposit(Account account)
    {
        decimal deposit;
        Console.WriteLine("How much would you like to deposit?");
        deposit = Convert.ToDecimal(Console.ReadLine());
        DepositTransaction newDeposit = new DepositTransaction(account, deposit);
        newDeposit.Execute();
        newDeposit.Print();
    }

    private static void DoPrint(Account account, Account account2)
    {
        account.Print();
        account2.Print();
    }

    private static void DoTransfer(Account account, Account account2)
    {
        decimal _amount;
        Console.WriteLine("How much would you like to transfer?");
        _amount = Convert.ToDecimal(Console.ReadLine());
        TransferTransaction transfer = new TransferTransaction(account2, account, _amount);
        WithdrawTransaction transfer1 = new WithdrawTransaction(account2, _amount);
        transfer1.Execute();
        transfer.Execute();
        transfer.Print();
    }

    public static void Main()
    {
        MenuOption userSelection;
        Account account = new Account("Eddie", 200); //account creation
        Account account2 = new Account("Jeff", 500);
        do
        {
            userSelection = ReadUserOption();
            Console.WriteLine("You have selected {0}", userSelection);

            switch (userSelection)
            {
                case MenuOption.Withdraw:
                    DoWithdraw(account);
                    break;
                case MenuOption.Deposit:
                    DoDeposit(account);
                    break;
                case MenuOption.Transfer:
                    DoTransfer(account, account2);
                    break;
                case MenuOption.Print:
                    DoPrint(account, account2);
                    break;
                case MenuOption.Quit:
                    Console.WriteLine("Quitting Program");
                    break;
            }
        } while (userSelection != MenuOption.Quit);
    }
}