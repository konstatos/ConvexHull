using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConvexHull
{
  /// <summary>
  /// Interface for getting points from image (or point generation) strategy
  /// </summary>
  public interface IOpenImage
  {
    /// <summary>
    /// Method for getting points from image (or point generation) strategy
    /// </summary>
    /// <returns>Points for convex hull find</returns>
    List<CPoint> OpenImage();
  }

  /// <summary>
  /// Interface for convex hull find strategy
  /// </summary>
  public interface IConvexHullScan
  {
    /// <summary>
    /// Method for convex hull find strategy
    /// </summary>
    /// <param name="points">Points for convex hull find</param>
    /// <returns>Convex hull points</returns>
    List<CPoint> ConvexHullScan(List<CPoint> points);
  }

  /// <summary>
  /// Interface for points output strategy
  /// </summary>
  public interface IOutput
  {
    /// <summary>
    /// Output all points
    /// </summary>
    /// <param name="points">All points</param>
    void OutputPoints(List<CPoint> points);

    /// <summary>
    /// Output convex hull
    /// </summary>
    /// <param name="points">Point list of convex hull</param>
    void OutputHull(List<CPoint> points);
  }
}
