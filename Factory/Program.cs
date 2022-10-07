// See https://aka.ms/new-console-template for more information

var person1 = new PersonFactory();
person1.CreatePerson("Nick");

var person2 = new PersonFactory();
person2.CreatePerson("George");

var person3 = new PersonFactory();
person3.CreatePerson("Michael");

Console.WriteLine(person1);
Console.WriteLine(person2);
Console.WriteLine(person3);

public class Person
{
    public int Id { get; set; }
    public string Name { get; set; }
    
    public override string ToString()
    {
        string newPersonObj = "Id: " + Id.ToString() + " Name: " + Name;
        return newPersonObj;
    }
}
  
public class PersonFactory
{
    private static int id = 0;
    private Person person;
    public Person CreatePerson(string name){
        person = new Person(){
            Id = id++,
            Name = name
        };
        return person;
    }
    public override string ToString()
    {
        return person.ToString();
    }
}
