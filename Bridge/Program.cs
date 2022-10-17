using System.Text;

var triangle = new Triangle(new VectorRenderer()).ToString();
var square = new Square(new RasterRenderer()).ToString();

Console.WriteLine(triangle);
Console.WriteLine(square);

public interface IRenderer
{
    string WhatToRenderAs { get; }
}

public class VectorRenderer : IRenderer
{
    public string WhatToRenderAs {
        get { return "lines"; }
    }
}

public class RasterRenderer : IRenderer
{
    public string WhatToRenderAs{
        get { return "pixels"; }
    }
}

public abstract class Shape
{
    private IRenderer renderer;
    protected Shape(IRenderer renderer)
    {
        this.renderer = renderer;
    }

    public string Name { get; set; }

    public override string ToString()
    {
        return "Drawing " + Name + " as " + renderer.WhatToRenderAs; 
    }
}

public class Triangle : Shape 
{
    public Triangle(IRenderer renderer) : base(renderer){
        Name = "Triangle";
    }
}

public class Square : Shape 
{
    public Square(IRenderer renderer) : base(renderer){
        Name = "Square";
    }
}

