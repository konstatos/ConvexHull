using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConvexHull
{
  /// <summary>
  /// Output 2 lists of points to console
  /// </summary>
  class OutputToFile : IOutput
  {
    string _TargetFileName;

    public OutputToFile(string targetFileName)
    {
      if (string.IsNullOrWhiteSpace(targetFileName))
        throw new ArgumentException("Target file name is incorrect", "targetFileName");

      _TargetFileName = targetFileName;
      File.WriteAllText(_TargetFileName, "Convex hull finder results: \n\r");
    }

    private void Output(List<CPoint> points, string title)
    {
      Contract.Requires(points != null);
      Contract.Requires(title != null);
      Contract.Requires(_TargetFileName != null);

      if (points == null)
        throw new ArgumentNullException("points");

      using (var sw = File.AppendText(_TargetFileName))
      {
        sw.WriteLine($"{title}: {points.Count}");
        sw.WriteLine(string.Join("; ", points));
        sw.Flush();
      }
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
