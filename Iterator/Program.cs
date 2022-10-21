using System.Collections.Generic;
using System.Collections;
using System.Linq;

Console.WriteLine("test");

var creature = new Creature();
creature.Strength = 3;
creature.Agility = 4;
creature.Intelligence = 5;

foreach (var cr in creature)
{
  Console.WriteLine(cr);
}

Console.WriteLine(creature[0]);

public class Creature : IEnumerable<int>
{
  private int [] stats = new int[3];

  private const int strength = 0;
  private const int agility = 1;
  private const int intelligence = 2;

  public int Strength
  {
    get => stats[strength];
    set => stats[strength] = value;
  }

  public int Agility
  {
    get => stats[agility];
    set => stats[agility] = value;
  }

  public int Intelligence
  {
    get => stats[intelligence];
    set => stats[intelligence] = value;
  }

  public double AverageStat => 
    stats.Average();

  public IEnumerator<int> GetEnumerator()
  {
    return stats.AsEnumerable().GetEnumerator();
  }

  IEnumerator IEnumerable.GetEnumerator()
  {
    return GetEnumerator();
  }

  public int this[int index]
  {
    get { return stats[index]; }
    set { stats[index] = value; }
  }
}
