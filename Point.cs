using System.Drawing;

namespace KMeans
{
    public class Point
    {
        public double X { get; private set; }
        public double Y { get; private set; }
        public Color Color { get; set; }
        public Point(double x, double y, Color color)
        {
            X = x;
            Y = y;
            Color = color;
        }
    }
}
