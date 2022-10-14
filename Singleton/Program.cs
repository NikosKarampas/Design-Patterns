var chiefExecutiveOfficer = new ChiefExecutiveOfficer();
Console.WriteLine("Is Singleton: " + SingletonTester.IsSingleton(() => chiefExecutiveOfficer));

public class ChiefExecutiveOfficer
{
    private static string name;
    private static int age;

    public string Name
    {
        get => name;
        set => name = value;
    }

    public int Age
    {
        get => age;
        set => age = value;
    }

    public override string ToString()
    {
        return $"{nameof(Name)}: {Name}, {nameof(Age)}: {Age}";
    }
}

public class SingletonTester
{
    public static bool IsSingleton(Func<object> func)
    {
        var obj1 = func();
        var obj2 = func();
        return ReferenceEquals(obj1, obj2);
    }
}
