using System;
using SplashKitSDK;

public class Program
{
    public enum MenuOption
    {
        NewAccount,
        Withdraw,
        Deposit,
        Transfer,
        Print,
        TransactionHistory,
        Quit
    }


    private static MenuOption ReadUserOption()
    {
        int input;
        // do while loop selection
        do
        {
            Console.WriteLine("1. Create New Account");
            Console.WriteLine("2. Withdraw");
            Console.WriteLine("3. Deposit");
            Console.WriteLine("4. Transfer Balance");
            Console.WriteLine("5. Print Balance");
            Console.WriteLine("6. Transaction History");
            Console.WriteLine("7. Quit");
            input = Convert.ToInt32(Console.ReadLine());
        } while (input < 1 || input > 7);
        // matching enumeration return
        return (MenuOption)(input - 1);
    }

    private static void DoWithdraw(Bank fromBank)
    {
        decimal withdraw;
        Account fromAccount = FindAccount(fromBank);

        if (fromAccount == null)
        {
            Console.WriteLine("Account does not exist.");
            return; 
        }

        Console.WriteLine("How much would you like to withdraw?");
        withdraw = Convert.ToDecimal(Console.ReadLine());
        WithdrawTransaction newTransaction = new WithdrawTransaction(fromAccount, withdraw);
        fromBank.ExecuteTransaction(newTransaction);
        fromAccount.Print();
    }

    private static void DoDeposit(Bank toBank)
    {
        decimal deposit;
        Account toAccount = FindAccount(toBank);

        if (toAccount == null)
        {
            Console.WriteLine("Account does not exist.");
            return;
        }

        Console.WriteLine("How much would you like to deposit?");
        deposit = Convert.ToDecimal(Console.ReadLine());
        DepositTransaction newDeposit = new DepositTransaction(toAccount, deposit);
        toBank.ExecuteTransaction(newDeposit);
        toAccount.Print();
    }

    private static void DoPrint(Bank bank)
    {
        Account bankAccount = FindAccount(bank);
        bankAccount.Print();
    }

    private static void DoTransferHistory(Bank bank)
    {
        bank.PrintTransactionHistory();
    }

    private static void DoTransfer(Bank toBank, Bank fromBank)
    {
        decimal _amount;
        Account fromAccount = FindAccount(fromBank);
        Account toAccount = FindAccount(toBank);
        if (toAccount == null) 
        {
            Console.WriteLine("Account does not exist.");
            return;
        }

        if (fromAccount == null)
        {
            Console.WriteLine("Account does not exist.");
            return;
        }

        if (toAccount == fromAccount)
        {
            Console.WriteLine("Cannot transfer to the same account");
            return;
        }

        Console.WriteLine("How much would you like to transfer?");
        _amount = Convert.ToDecimal(Console.ReadLine());
        TransferTransaction transfer = new TransferTransaction(fromAccount, toAccount, _amount);
        toBank.ExecuteTransaction(transfer);
        toAccount.Print();
        fromAccount.Print();
    }

    public static void DoNewAccount(Bank bank)//account creation
    {
        string accountName;
        int balance;
        Console.WriteLine("What is your account name?");
        accountName = Console.ReadLine();
        Console.WriteLine("How much would you like to deposit?");
        balance = Convert.ToInt32(Console.ReadLine());
        Account newAccount = new Account(accountName, balance);
        bank.AddAccount(newAccount);
    }

    public static Account FindAccount(Bank fromBank)
    {
        Console.WriteLine("Enter the account name: ");
        String name = Console.ReadLine();
        Account result = fromBank.GetAccount(name);

        if (result == null)
        {
            Console.WriteLine("No account found with that name");
        }
        return result;
    }

    public static void Main()
    {
        MenuOption userSelection;
        Bank bank = new Bank();
        do
        {
            userSelection = ReadUserOption();
            Console.WriteLine("You have selected {0}", userSelection);

            switch (userSelection)
            {
                case MenuOption.NewAccount:
                    DoNewAccount(bank);
                    break;
                case MenuOption.Withdraw:
                    DoWithdraw(bank);
                    break;
                case MenuOption.Deposit:
                    DoDeposit(bank);
                    break;
                case MenuOption.Transfer:
                    DoTransfer(bank, bank);
                    break;
                case MenuOption.Print:
                    DoPrint(bank);
                    break;
                case MenuOption.TransactionHistory:
                    DoTransferHistory(bank);
                    break;
                case MenuOption.Quit:
                    Console.WriteLine("Quitting Program");
                    break;
            }
        } while (userSelection != MenuOption.Quit);
    }
}