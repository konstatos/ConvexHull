namespace ConvexHull
{
  /// <summary>
  /// Point for Convex Hull
  /// </summary>
  public class CPoint
  {
    private int y;
    private int x;

    public int Y { get { return y; } set { y = value; } }
    public int X { get { return x; } set { x = value; } }

    /// <summary>
    /// Point constructor
    /// </summary>
    /// <param name="_x">X</param>
    /// <param name="_y">Y</param>
    public CPoint(int _x, int _y)
    {
      x = _x;
      y = _y;
    }

    /// <summary>
    /// Convert to string
    /// </summary>
    /// <returns>"(X,Y)"</returns>
    public override string ToString()
    {
      return $"({x},{y})";
    }
  }
}