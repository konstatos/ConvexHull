using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace ConvexHull
{
  /// <summary>
  /// Graham Convex Hull from https://github.com/masphei/ConvexHull/blob/master/ConvexHull/graham_scan.cs
  /// sometimes ignores top points
  /// </summary>
  public class GrahamScan : IConvexHullScan
  {
    const int TURN_LEFT = 1;
    const int TURN_RIGHT = -1;
    const int TURN_NONE = 0;

    int turn(CPoint p, CPoint q, CPoint r)
    {
      return ((q.X - p.X) * (r.Y - p.Y) - (r.X - p.X) * (q.Y - p.Y)).CompareTo(0);
    }

    void keepLeft(List<CPoint> hull, CPoint r)
    {
      while (hull.Count > 1 && turn(hull[hull.Count - 2], hull[hull.Count - 1], r) != TURN_LEFT)
      {
        //Debug.WriteLine("Removing Point ({0}, {1}) because turning right ", hull[hull.Count - 1].X, hull[hull.Count - 1].Y);
        hull.RemoveAt(hull.Count - 1);
      }
      if (hull.Count == 0 || hull[hull.Count - 1] != r)
      {
        //Debug.WriteLine("Adding Point ({0}, {1})", r.X, r.Y);
        hull.Add(r);
      }
      //Debug.WriteLine("# Current Convex Hull #");
      //foreach (Point value in hull)
      //{
      //  Debug.WriteLine("(" + value.X + "," + value.Y + ") ");
      //}
      //Debug.WriteLine("");
      //Debug.WriteLine("");
    }

    double getAngle(CPoint p1, CPoint p2)
    {
      float xDiff = p2.X - p1.X;
      float yDiff = p2.Y - p1.Y;
      return Math.Atan2(yDiff, xDiff) * 180.0 / Math.PI;
    }

    List<CPoint> MergeSort(CPoint p0, List<CPoint> arrPoint)
    {
      if (arrPoint.Count == 1)
      {
        return arrPoint;
      }
      List<CPoint> arrSortedInt = new List<CPoint>();
      int middle = (int)arrPoint.Count / 2;
      List<CPoint> leftArray = arrPoint.GetRange(0, middle);
      List<CPoint> rightArray = arrPoint.GetRange(middle, arrPoint.Count - middle);
      leftArray = MergeSort(p0, leftArray);
      rightArray = MergeSort(p0, rightArray);
      int leftptr = 0;
      int rightptr = 0;
      for (int i = 0; i < leftArray.Count + rightArray.Count; i++)
      {
        if (leftptr == leftArray.Count)
        {
          arrSortedInt.Add(rightArray[rightptr]);
          rightptr++;
        }
        else if (rightptr == rightArray.Count)
        {
          arrSortedInt.Add(leftArray[leftptr]);
          leftptr++;
        }
        else if (getAngle(p0, leftArray[leftptr]) < getAngle(p0, rightArray[rightptr]))
        {
          arrSortedInt.Add(leftArray[leftptr]);
          leftptr++;
        }
        else
        {
          arrSortedInt.Add(rightArray[rightptr]);
          rightptr++;
        }
      }
      return arrSortedInt;
    }

    /// <summary>
    /// Convex hull scan with Graham method
    /// </summary>
    /// <param name="points">All points</param>
    /// <returns>Convex hull points</returns>
    /// <remarks>not used, becouse sometimes work not correct</remarks>
    public List<CPoint> ConvexHullScan(List<CPoint> points)
    {
      CPoint p0 = null;
      foreach (CPoint value in points)
      {
        if (p0 == null)
          p0 = value;
        else
        {
          if (p0.Y > value.Y)
            p0 = value;
        }
      }
      List<CPoint> order = new List<CPoint>();
      foreach (CPoint value in points)
      {
        if (p0 != value)
          order.Add(value);
      }

      order = MergeSort(p0, order);
      List<CPoint> result = new List<CPoint>
      {
        p0,
        order[0],
        order[1]
      };
      order.RemoveAt(0);
      order.RemoveAt(0);
      foreach (CPoint value in order)
      {
        keepLeft(result, value);
      }
      return result;
    }
  }
}