// See https://aka.ms/new-console-template for more information

using System.Text;

var cb = new CodeBuilder("Person")
    .AddField("Name", "string")
    .AddField("Age", "int")
    .AddField("Address", "string");

Console.WriteLine(cb);

public class CodeElement{
    public string Type, Text;
    private const int indentSize = 2;

    public List<CodeElement> codeElements = new List<CodeElement>();

    public CodeElement(){

    }

    public CodeElement(string text ,string type){
        this.Type = type;
        this.Text = text;
    }

    private string OutputString(int indent){
        var sb = new StringBuilder();
        sb.Append($"public class {Text}\n\n");
        sb.Append("{\n");

        foreach (var codeElement in codeElements)
        {
            var i = new string(' ', indentSize * indent);
            sb.Append($"{i}public {codeElement.Type} {codeElement.Text};\n");
        }
        sb.Append("\n");
        sb.Append("}");

        return sb.ToString();
    }    

    public override string ToString()
    {
        return OutputString(2);
    }
}

public class CodeBuilder {        
    private readonly string className;
    
    public CodeBuilder(string className)
    {
        this.className = className;
        root.Text = className;
    }

    CodeElement root = new CodeElement();    

    public CodeBuilder AddField(string propertyType, string text){
        root.codeElements.Add(new CodeElement(propertyType, text));
        return this;
    }

    public override string ToString()
    {
      return root.ToString();
    }    
}
