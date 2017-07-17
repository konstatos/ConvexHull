using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace ConvexHull
{
  /// <summary>
  /// Output 2 lists of points to console
  /// </summary>
  class OutputToCanvas : IOutput
  {
    Canvas _TargetCanvas;
    private int _PointSize = 10;
    SolidColorBrush _PointBrush = new SolidColorBrush(Colors.Black);
    SolidColorBrush _HullBrush = new SolidColorBrush(Color.FromArgb(50, 100, 190, 100));

    public OutputToCanvas(Canvas target)
    {
      _TargetCanvas = target;
    }

    /// <summary>
    /// Output all points as ellipses on canvas
    /// </summary>
    /// <param name="points">All points</param>
    public void OutputPoints(List<CPoint> points)
    {
      _TargetCanvas.Children.Clear();
      _TargetCanvas.Width = points.Max(x=>x.X);
      _TargetCanvas.Height = points.Max(x=>x.Y);
      var s = _PointSize / 2;
      foreach (var p in points)
      {
        _TargetCanvas.Children.Add(new Ellipse()
        {
          Width = _PointSize,
          Height = _PointSize,
          Fill = _PointBrush,
          Margin = new Thickness(p.X - s, p.Y - s, 0, 0)
        });
      }
    }

    /// <summary>
    /// Output convex hull as poligon on canvas
    /// </summary>
    /// <param name="points">Point list of convex hull</param>   
    public void OutputHull(List<CPoint> points)
    {
      var hull = new Polygon() { Fill = _HullBrush };
      foreach (var p in points) hull.Points.Add(new Point(p.X, p.Y));
      _TargetCanvas.Children.Add(hull);
    }
  }
}
