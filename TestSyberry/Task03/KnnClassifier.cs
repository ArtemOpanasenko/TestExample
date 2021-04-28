using System;
using System.Collections.Generic;
using System.Linq;

namespace Task03
{
    public static class KnnClassifier
    {
        public static string Classify(IEnumerable<(string name, double x, double y)> data,
            (double x, double y) point, int k = 3)
        {
            if (data == null)
            {
                throw new ArgumentNullException(nameof(data));
            }

            if (k <= 1)
            {
                throw new ArgumentException("Must be greater than 1", nameof(k));
            }

            return data.AsParallel()
                .Select(t => (t.name, distance: Distance((t.x, t.y), point)))
                .OrderBy(pair => pair.distance)
                .Take(k)
                .GroupBy(pair => pair.name)
                .Select(group => (group.Key, count: group.Count()))
                .OrderByDescending(pair => pair.count)
                .First().Key;

            static double Distance((double x, double y) p1, (double x, double y) p2)
            {
                return (p1.x - p2.x) * (p1.x - p2.x) + (p1.y - p2.y) * (p1.y - p2.y);
            }
        }
    }
}