using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KMeans
{
    public static class KMeans
    {
        public static List<Point> InitializePoints(int countPoints, List<Cluster> clusters,  int maxCordinate)
        {
            Random random = new Random((int) DateTime.Now.Ticks);
            List<Point> points = new List<Point>();
            for (int i = 0; i < countPoints; i++) {
                Point point = new Point(random.Next(maxCordinate), random.Next(maxCordinate), Color.Black);
                point.Color = GetClusterColor(clusters, point);
                points.Add(point);
            }
            return points;
        }

        public static List<Cluster> InitializeClusters(int countClusters, int maxCoordinate)
        {
            Random random = new Random((int) DateTime.Now.Ticks);
            List<Cluster> clusters = new List<Cluster>();
            for (int i = 0; i < countClusters; i++) {
                clusters.Add(new Cluster(random.Next(maxCoordinate), random.Next(maxCoordinate),
                    Color.FromArgb(255, 
                        (random.Next(255)*i + 20)%255, (random.Next(255)*i + 20)%255, (random.Next(255)*i + 20)%255)));
            }
            return clusters;
        }

        private static Color GetClusterColor(List<Cluster> clusters, Point point)
        {
            double minDistance = GetDistanceToClusterCenter(clusters[0], point);
            int resultNumber = 0, currentCluster = 0;
            foreach (var cluster in clusters) {
                double tempDistance;
                if ((tempDistance = GetDistanceToClusterCenter(cluster, point)) < minDistance) {
                    minDistance = tempDistance;
                    resultNumber = currentCluster;
                }
                currentCluster++;
            }
            return clusters[resultNumber].Color;
        }

        private static double GetDistanceToClusterCenter(Cluster cluster, Point point)
        {
            return Math.Sqrt(Math.Pow(cluster.X - point.X, 2) + Math.Pow(cluster.Y - point.Y, 2));
        }
    }
}
