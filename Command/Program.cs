using CompositeCommand;

var command = new Command{ TheAction = Command.Action.Deposit, Amount = 100 };

var account = new Account();
account.Process(command);

Console.WriteLine(account.Balance);

Console.WriteLine("\nComposite Command\n");

#region  Composite Command 

var ba = new BankAccount();
ba.Deposit(200);

//Deposit and then undo command
Console.WriteLine("Call and then Undo deposit command\n");
var baCommand = new BankAccountCommand(ba, BankAccountCommand.Action.Deposit, 100);
baCommand.Call();
baCommand.Undo();
Console.WriteLine("\n");

//CompositeCommand execute many commands
Console.WriteLine("Execute deposit and withdraw commands and then undo\n");
var ba2 = new BankAccount(100);
var deposit = new BankAccountCommand(ba2, BankAccountCommand.Action.Deposit, 100);
var withdraw = new BankAccountCommand(ba2, BankAccountCommand.Action.Withdraw, 50);
var compCommand = new CompositeBankAccountCommand(new[] {deposit, withdraw});
compCommand.Call();
compCommand.Undo();

#endregion

public class Command
{
    public enum Action
    {
        Deposit,
        Withdraw
    }

    public Action TheAction;
    public int Amount;
    public bool Success;
}

public class Account
{
    public int Balance { get; set; }

    public void Process(Command c)
    {
        switch (c.TheAction)
        {
            case Command.Action.Deposit:
                Balance += c.Amount;
                c.Success = true;
                break;
            case Command.Action.Withdraw:
                c.Success = Balance >= c.Amount;
                if (c.Success) Balance -= c.Amount;
            break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }
}