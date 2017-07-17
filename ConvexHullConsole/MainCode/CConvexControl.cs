using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;

namespace ConvexHull
{
  /// <summary>
  /// Integrates loading and processing of images
  /// </summary>
  public class ConvexHullControl
  {
    /// <summary> Images download strategy. 
    /// Existing strategies: GenerateRandomPoints, OpenImageToBitmap </summary>
    protected IOpenImage OpenImage { get; set; }

    /// <summary> Images processing strategy. 
    /// Existing strategies: JarvisMatch - works normal; 
    /// GrahamScan, Graham - other options considered algorithm is not always working correctly </summary>
    protected IConvexHullScan ConvexHullScan { get; set; }

    /// <summary> Output strategy. 
    /// Existing strategies: OutputToConsole, OutputToFile, OutputToCanvas </summary>
    protected IOutput Output { get; set; }

    /// <summary> All points from image </summary>
    public List<CPoint> SourcePoints { get; private set; }

    /// <summary> Convex hull points </summary>
    public List<CPoint> ConvexHull { get; private set; }

    /// <summary>
    /// Initialise convex calculator with strategies of image loading, 
    /// convex hull find, output and executes all this actions
    /// </summary>
    /// <param name="openImage">Strategy of image loading</param>
    /// <param name="convexHullScan">Strategy of convex hull find</param>
    /// <param name="output">Strategy of output</param>
    public ConvexHullControl(IOpenImage openImage, 
      IConvexHullScan convexHullScan, IOutput output = null)
    {
      Contract.Requires(OpenImage != null);
      Contract.Requires(ConvexHullScan != null);

      OpenImage = openImage ?? throw new ArgumentNullException(nameof(openImage));
      ConvexHullScan = convexHullScan ?? throw new ArgumentNullException(nameof(convexHullScan));
      Output = output;

      try
      {
        SourcePoints = OpenImage.OpenImage();
        Output?.OutputPoints(SourcePoints);
      }
      catch (Exception e)
      {
        throw new Exception("The image loading failed", e);
      }

      try
      {
        ConvexHull = ConvexHullScan.ConvexHullScan(SourcePoints);
        Output?.OutputHull(ConvexHull);
      }
      catch (Exception e)
      {
        throw new Exception("The convex hull scan failed", e);
      }
    }
  }
}
