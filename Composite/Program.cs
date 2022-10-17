using System.Collections;
using System.Collections.Generic;

var singleValue = new SingleValue { Value = 2 };

var otherValues = new ManyValues();
    otherValues.Add(10);
    otherValues.Add(20);

int sum = new List<IValueContainer>{ singleValue, otherValues}.Sum();

Console.WriteLine("Sum is " + sum);

public interface IValueContainer : IEnumerable<int>
{
    
}

public class SingleValue : IValueContainer
{
    public int Value;
    public IEnumerator<int> GetEnumerator()
    {
        yield return Value;
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}

public class ManyValues : List<int>, IValueContainer
{
    
}

public static class ExtensionMethods
{
    public static int Sum(this List<IValueContainer> containers)
    {
        int result = 0;
        foreach (var c in containers)
        foreach (var i in c)
            result += i;
        return result;
    }
}
