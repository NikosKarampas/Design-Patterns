var square = new Square{Side = 11};
var squareToRectangle = new SquareToRectangleAdapter(square);
bool result = ExtensionMethods.Area(squareToRectangle) == 121;

Console.WriteLine("Area is 121: " + result.ToString());

public class Square
{
    public int Side;
}

public interface IRectangle
{
    int Width { get; }
    int Height { get; }
}

public static class ExtensionMethods
{
    public static int Area(this IRectangle rc)
    {
        return rc.Width * rc.Height;
    }
}

public class SquareToRectangleAdapter : IRectangle
{
    private readonly Square square;

    public SquareToRectangleAdapter(Square square)
    {
    this.square = square;
    }

    public int Width => square.Side;
    public int Height => square.Side;
}