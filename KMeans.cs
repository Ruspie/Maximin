using System;
using System.Collections.Generic;
using System.Drawing;

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
                int clusterNumber = GetClusterNumber(clusters, point);
                point.Color = clusters[clusterNumber].Color;
                points.Add(point);
                clusters[clusterNumber].VectorPoints.Add(point);
            }
            return points;
        }
        public static List<Cluster> InitializeClusters(int countClusters, int maxCoordinate)
        {
            Random random = new Random((int)DateTime.Now.Ticks);
            List<Cluster> clusters = new List<Cluster>();
            for (int i = 0; i < countClusters; i++)
            {
                clusters.Add(new Cluster(random.Next(maxCoordinate), random.Next(maxCoordinate),
                    Color.FromArgb(255,
                        (random.Next(255) * (i + 1) + 1) % 255, (random.Next(255) * (i + 1) + 1) % 255,
                        (random.Next(255) * (i + 1) + 1) % 255)));
            }
            return clusters;
        }

        private static int GetClusterNumber(List<Cluster> clusters, Point point)
        {
            double minDistance = double.PositiveInfinity;
            int resultNumber = 0, currentCluster = 0;
            foreach (var cluster in clusters)
            {
                double tempDistance;
                if ((tempDistance = GetDistanceToClusterCenter(cluster, point)) < minDistance)
                {
                    minDistance = tempDistance;
                    resultNumber = currentCluster;
                }
                currentCluster++;
            }
            return resultNumber;
        }

        private static double GetDistanceToClusterCenter(Cluster cluster, Point point)
        {
            return Math.Sqrt(Math.Pow(cluster.X - point.X, 2) + Math.Pow(cluster.Y - point.Y, 2));
        }

        public static List<Cluster> GetCentringClusters(List<Cluster> clusters, List<Point> points)
        {
            while (!CheckCenteringClusters(clusters))
            {
                foreach (var cluster in clusters)
                {
                    double sumX = 0;
                    double sumY = 0;
                    foreach (Point point in cluster.VectorPoints)
                    {
                        sumX += point.X;
                        sumY += point.Y;
                    }

                    cluster.PrevX = cluster.X;
                    cluster.PrevY = cluster.Y;

                    cluster.X = sumX / cluster.VectorPoints.Count;
                    cluster.Y = sumY / cluster.VectorPoints.Count;

                    cluster.VectorPoints.Clear();
                }

                foreach (var point in points)
                {
                    int clusterNumber = GetClusterNumber(clusters, point);
                    point.Color = clusters[clusterNumber].Color;
                    clusters[clusterNumber].VectorPoints.Add(point);
                }
            }
            return clusters;
        }

        private static bool CheckCenteringClusters(List<Cluster> clusters)
        {
            foreach (var cluster in clusters) {
                if (!cluster.IsCentering()) {
                    return false;
                }
            }
            return true;
        }
    }
}
