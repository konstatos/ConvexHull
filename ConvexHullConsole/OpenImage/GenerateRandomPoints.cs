using System;
using System.Collections.Generic;

namespace ConvexHull
{
  /// <summary>
  /// Randomly generates points. Used when the console is not given the name of the file
  /// </summary>
  public class GenerateRandomPoints : IOpenImage
  {
    private Random _Random = new Random();
    private int _MaxSize;
    private int _TestPointsCount;

    /// <summary>
    /// Randomly generates points constructor
    /// </summary>
    /// <param name="maxSize">Field size</param>
    /// <param name="testPointsCount">Points count</param>
    public GenerateRandomPoints(int maxSize = 1000, int testPointsCount = 1000)
    {
      _MaxSize = maxSize;
      _TestPointsCount = testPointsCount;
    }

    /// <summary>
    /// Randomly generates points; path is not used
    /// </summary>
    public List<CPoint> OpenImage()
    {
      var points = new List<CPoint>();
      var s = (int)Math.Sqrt(_MaxSize);
      for (int i = 0; i < _TestPointsCount; i++)
      {
        points.Add(new CPoint(_Random.Next(s) * _Random.Next(s), _Random.Next(s) * _Random.Next(s)));
      }
      return points;
    }
  }
}