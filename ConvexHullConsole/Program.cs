using ConvexHull;
using System;
using System.IO;

namespace ConvexHullConsole
{
  /// <summary>
  /// The console receiving the input image file, allocating it points and building a convex hull for them. 
  /// Outputs the result to the console or to the text file. 
  /// There is also a separate WPF project to visualize the points and the convex hull.
  /// </summary>
  public class Program
  {
    /// <summary>
    /// Main method, that activates convex hull scan
    /// File start.bat passes names of input and output files
    /// </summary>
    /// <param name="args">Input png file with black points on white background (if not exists - points will be generated),
    /// Output file (txt file in which will be recorded the points and the convex hull)</param>
    public static void Main(string[] args)
    {
      IOpenImage open = GetOpenFileStrategy(args);
      IConvexHullScan scan = new JarvisMatch();
      IOutput output = GetOutputStrategy(args);
      Console.WriteLine("Processing started...");

      try
      {
        new ConvexHullControl(open, scan, output);
      }
      catch (Exception e)
      {
        Console.WriteLine($"An error has occured: {e.Message}");
      }

      Console.WriteLine("Processing is over. Press Enter to exit.");
      Console.ReadLine();
    }

    private static IOutput GetOutputStrategy(string[] args)
    {
      IOutput output;
      if (args.Length > 1)
      {
        var outputFile = args[1];
        Console.WriteLine("Trying to write result to file: " + outputFile);
        output = new OutputToFile(outputFile);
      }
      else
      {
        Console.WriteLine("Enter target file name (or press Enter to output to console): ");
        var outputFile = Console.ReadLine();
        if (outputFile.Length > 0)
          output = new OutputToFile(outputFile);
        output = new OutputToConsole();
      }

      return output;
    }

    private static IOpenImage GetOpenFileStrategy(string[] args)
    {
      IOpenImage open;
      if (args.Length > 0)
      {
        var inputFile = args[0];
        Console.WriteLine("Trying to process file: " + inputFile);
        open = new OpenImageToBitmap(inputFile);
      }
      else
      {
        Console.WriteLine("Enter image file name (or press Enter to random points generate): ");
        var inputFile = Console.ReadLine();
        if (File.Exists(inputFile))
          open = new OpenImageToBitmap(inputFile);
        else
        {
          Console.WriteLine("File does not exist. Generate 1000 random points");
          open = new GenerateRandomPoints();
        }
      }

      return open;
    }
  }
}
