var person = new Person();
person.Age = 17;

var responsiblePerson = new ResponsiblePerson(person);
Console.WriteLine(responsiblePerson.Drink());
Console.WriteLine(responsiblePerson.Drive());
Console.WriteLine(responsiblePerson.DrinkAndDrive());

public class Person
{
    public int Age { get; set; }

    public string Drink()
    {
        return "drinking";
    }

    public string Drive()
    {
        return "driving";
    }

    public string DrinkAndDrive()
    {
        return "driving while drunk";
    }
}

public class ResponsiblePerson
{
    private readonly Person person;
    public ResponsiblePerson(Person person)
    {
        this.person = person;
    }

    public int Age 
    { 
        get { return person.Age; }
        set { person.Age = value; }
    }

    public string Drink()
    {
        if (Age < 18)
            return "too young";
        return person.Drink();
    }

    public string Drive(){
        if (Age < 16)
            return "too young";
        return person.Drive();
    }

    public string DrinkAndDrive(){
        return "dead";
    }
}
