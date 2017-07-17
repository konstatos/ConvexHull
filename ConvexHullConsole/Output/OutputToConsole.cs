using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConvexHull
{
  /// <summary>
  /// Output 2 lists of points to console
  /// </summary>
  class OutputToConsole : IOutput
  {
    private void Output(List<CPoint> points, string title)
    {
      Contract.Requires(points != null);
      Contract.Requires(title != null);

      if (points == null)
      {
        Console.WriteLine($"{title}: points == null");
        return;
      }

      Console.WriteLine($"{title}: {points.Count}");
      Console.WriteLine(string.Join("; ", points));
    }

    /// <summary>
    /// Output all points
    /// </summary>
    /// <param name="points">All points</param>
    public void OutputPoints(List<CPoint> points)
    {
      Output(points, "All points");
    }

    /// <summary>
    /// Output convex hull
    /// </summary>
    /// <param name="points">Point list of convex hull</param>   
    public void OutputHull(List<CPoint> points)
    {
      Output(points, "Convex hull");
    }
  }
}
