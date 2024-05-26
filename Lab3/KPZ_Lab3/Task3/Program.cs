using System;

public class Program
{
    public static void Main(string[] args)
    {
        IRenderer vectorRenderer = new VectorRenderer();
        IRenderer rasterRenderer = new RasterRenderer();

        Shape circle = new Circle(vectorRenderer);
        Shape square = new Square(rasterRenderer);
        Shape triangle = new Triangle(vectorRenderer);

        circle.Draw();
        square.Draw();
        triangle.Draw();

        circle = new Circle(rasterRenderer);
        circle.Draw();
    }
}
