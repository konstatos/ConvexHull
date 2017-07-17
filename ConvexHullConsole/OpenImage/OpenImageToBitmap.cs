using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace ConvexHull
{
  /// <summary>
  /// Оpen the PNG image and take from it the coordinates of the dark dots
  /// </summary>
  /// <remarks>further improvement: use of specialized libraries in the processing of PNG images, work with the file directly, using assembler</remarks>
  public class OpenImageToBitmap : IOpenImage
  {
    string _ImageFilePath;

    /// <summary>
    /// Constructor that accepts the file name
    /// </summary>
    /// <param name="path">Image file name</param>
    public OpenImageToBitmap(string path)
    {
      if (string.IsNullOrWhiteSpace(path))
        throw new ArgumentException("Image file name is incorrect", "path");
      _ImageFilePath = path;
    }

    static Bitmap LoadBitmap(string fileName)
    {
      using (FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read, FileShare.Read))
        return new Bitmap(fs);
    }

    /// <summary>
    /// Load image and take dark points from it; modified sample from https://habrahabr.ru/post/196578/
    /// </summary>
    public unsafe List<CPoint> OpenImage()
    {
      var bmp = LoadBitmap(_ImageFilePath);

      int width = bmp.Width, height = bmp.Height;
      BitmapData bd = bmp.LockBits(new Rectangle(0, 0, width, height),
        ImageLockMode.ReadOnly, PixelFormat.Format24bppRgb);
      var res = new List<CPoint>();
      try
      {
        byte* curpos;
        {
          for (int h = 0; h < height; h++)
          {
            curpos = ((byte*)bd.Scan0) + h * bd.Stride;
            for (int w = 0; w < width; w++)
            {
              if (*(curpos) < 100) res.Add(new CPoint(w, h));
              curpos += 3;
            }
          }
        }
      }
      finally
      {
        bmp.UnlockBits(bd);
      }
      return res;
    }
  }
}
