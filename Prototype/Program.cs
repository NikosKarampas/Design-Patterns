var line1 =  new Line(){
    Start = new Point(){ X = 1, Y = 1 },
    End = new Point(){ X = 2, Y = 2 }
};

var line2 = line1.DeepCopy();

Console.WriteLine(line1.ToString());
Console.WriteLine(line2.ToString());

public class Point
{
    public int X, Y;
}

public class Line
{
    public Point Start, End;

    public Line DeepCopy()
    {
        var newStart = new Point{X = Start.X, Y = Start.Y};
        var newEnd = new Point {X = End.X, Y = End.Y};
        return new Line {Start = newStart, End = newEnd};
    }

    public override string ToString()
    {
        string start = "Start X: " +  Start.X + " Y: " + Start.Y;
        string end = "End X: " +  End.X + " Y: " + End.Y;
        return start + " " + end;
    }
}