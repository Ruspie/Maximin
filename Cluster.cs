using System;
using System.Collections.Generic;
using System.Drawing;

namespace KMeans
{
    public class Cluster
    {
        public double X { get; set; }
        public double Y { get; set; }
        public double PrevX { private get; set; }
        public double PrevY { private get; set; }
        public Color Color { get; private set; }
        public List<Point> VectorPoints { get; private set; }

        public Cluster(double x, double y, Color color)
        {
            X = x;
            Y = y;
            PrevX = double.PositiveInfinity;
            PrevY = double.PositiveInfinity;
            Color = color;
            VectorPoints = new List<Point>();
        }
        public Cluster(double x, double y, Color color, List<Point> vectorPoints)
        {
            X = x;
            Y = y;
            PrevX = double.PositiveInfinity;
            PrevY = double.PositiveInfinity;
            Color = color;
            VectorPoints = vectorPoints;
        }

        public bool IsCentering()
        {
            return (Math.Abs(PrevX - X) < double.Epsilon) && (Math.Abs(PrevY - Y) < double.Epsilon);
        }
    }
}
