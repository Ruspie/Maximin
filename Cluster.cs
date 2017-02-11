using System;
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
        public Color Color { get; set; }

        public Cluster(double x, double y, Color color)
        {
            X = x;
            Y = y;
            Color = color;
        }
    }
}
