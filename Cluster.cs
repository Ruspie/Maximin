using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public bool isCentering()
        {
            return (PrevX == X) && (PrevY == Y);
        }
    }
}
