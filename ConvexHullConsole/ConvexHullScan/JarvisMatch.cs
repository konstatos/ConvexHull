using System;
using System.Linq;
using System.Collections.Generic;
using System.Diagnostics.Contracts;

namespace ConvexHull
{
  /// <summary>
  /// Jarvis Convex Hull from https://github.com/masphei/ConvexHull/blob/master/ConvexHull/jarvis_march.cs
  /// like normally works
  /// </summary>
  public class JarvisMatch : IConvexHullScan
  {
    const int TURN_LEFT = 1;
    const int TURN_RIGHT = -1;
    const int TURN_NONE = 0;

    int turn(CPoint p, CPoint q, CPoint r)
    {
      return ((q.X - p.X) * (r.Y - p.Y) - (r.X - p.X) * (q.Y - p.Y)).CompareTo(0);
    }

    int dist(CPoint p, CPoint q)
    {
      int dx = q.X - p.X;
      int dy = q.Y - p.Y;
      return dx * dx + dy * dy;
    }

    CPoint nextHullPoint(List<CPoint> points, CPoint p)
    {
      CPoint q = p;
      int t;
      foreach (CPoint r in points)
      {
        t = turn(p, q, r);
        if (t == TURN_RIGHT || t == TURN_NONE && dist(p, r) > dist(p, q))
          q = r;
      }
      return q;
    }

    double getAngle(CPoint p1, CPoint p2)
    {
      float xDiff = p2.X - p1.X;
      float yDiff = p2.Y - p1.Y;
      return Math.Atan2(yDiff, xDiff) * 180.0 / Math.PI;
    }

    /// <summary>
    /// Convex hull scan with Jarvis method
    /// </summary>
    /// <param name="points">All points</param>
    /// <returns>Convex hull points</returns>
    /// <remarks>It can be optimazed: for example extract hull[0] from loop</remarks>
    public List<CPoint> ConvexHullScan(List<CPoint> points)
    {
      Contract.Requires(points != null);
      Contract.Requires(points.Count > 0);

      List<CPoint> hull = new List<CPoint>();
      Contract.Ensures(hull != null);
      Contract.Ensures(hull.Count > 0);

      foreach (CPoint p in points)
      {
        if (hull.Count == 0)
          hull.Add(p);
        else
        {
          if (hull[0].X > p.X)
            hull[0] = p;
          else if (hull[0].X == p.X)
            if (hull[0].Y > p.Y)
              hull[0] = p;
        }
      }

      CPoint q;
      int counter = 0;
      while (counter < hull.Count)
      {
        q = nextHullPoint(points, hull[counter]);
        if (q != hull[0])
        {
          hull.Add(q);
        }
        counter++;
      }


      return hull;
    }
  }
}