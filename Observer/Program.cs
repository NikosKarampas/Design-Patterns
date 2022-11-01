using System.Collections.Generic;
//using System.Runtime.Remoting.Channels;

var game = new Game();
var rat = new Rat(game);
var rat2 = new Rat(game);

Console.WriteLine(rat.Attack);
Console.WriteLine(rat2.Attack);

public class Game
{
    public event EventHandler RatEnters, RatDies;
    public event EventHandler<Rat> NotifyRat;
    
    public void FireRatEnters(object sender){
        RatEnters?.Invoke(sender, EventArgs.Empty);
    }

    public void FireRatDies(object sender){
        RatDies?.Invoke(sender, EventArgs.Empty);
    }

    public void FireNotifyRat(object sender, Rat rat){
        NotifyRat?.Invoke(sender, rat);
    }
}

public class Rat : IDisposable
{
    private readonly Game game;
    public int Attack = 1;

    public Rat(Game game)
    {
        this.game = game;

        game.RatEnters += (sender, args) => {
            if (sender != this)
            {
                ++Attack;
                game.FireNotifyRat(this, (Rat)sender);
            }
        };

        game.NotifyRat += (sender, rat) =>
        {
          if (rat == this) ++Attack;
        };

        game.RatDies += (sender, args) => --Attack;

        game.FireRatEnters(this);
    }


    public void Dispose()
    {
        game.FireRatDies(this);
    }
}