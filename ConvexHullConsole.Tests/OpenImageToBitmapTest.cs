using System.Collections.Generic;
// <copyright file="OpenImageToBitmapTest.cs">Copyright ©  2017</copyright>

using System;
using ConvexHull;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ConvexHull.Tests
{
  /// <summary>Этот класс содержит параметризованные модульные тесты для OpenImageToBitmap</summary>
  [TestClass]
  [PexClass(typeof(OpenImageToBitmap))]
  [PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
  [PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
  public partial class OpenImageToBitmapTest
  {
    [TestMethod]
    public void OpenImageOk()
    {
      const string fn = "pMin.png";
      var f = new OpenImageToBitmap(fn);
      PexAssert.AreEqual(f.OpenImage().ToStr(),
        new List<CPoint>() { new CPoint(0, 0), new CPoint(1,1),
        new CPoint(12,35),new CPoint(47,29),new CPoint(51,8),
        new CPoint(29,17),new CPoint(81,58) }.ToStr());
    }

    public void OpenFileNoName()
    {
      try
      {
        var f = new OpenImageToBitmap("");
      }
      catch (ArgumentException e)
      {
        return;
      }
      Assert.Fail();
    }

    [TestMethod]
    public void OpenFileNullName()
    {
      try
      {
        var f = new OpenImageToBitmap(null);
      }
      catch (ArgumentException e)
      {
        return;
      }
      Assert.Fail();
    }
  }
}
