// <copyright file="ConvexHullControlTest.cs">Copyright ©  2017</copyright>

using System;
using ConvexHull;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace ConvexHull.Tests
{
  /// <summary>Этот класс содержит параметризованные модульные тесты для ConvexHullControl</summary>
  [TestClass]
  [PexClass(typeof(ConvexHullControl))]
  [PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
  [PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
  public partial class ConvexHullControlTest
  {
    [TestMethod]
    // полный тест на небольшом изображении
    public void ProcessOk()
    {
      var res = new ConvexHullControl(new OpenImageToBitmap("pMin.png"), new JarvisMatch());
      PexAssert.AreEqual(new List<CPoint>() {  new CPoint(0,0),
         new CPoint(12,35), new CPoint(51,8), new CPoint(81,58) }.ToStr(),
         res.ConvexHull.ToStr());
    }

    [TestMethod]
    public void OpenFileNullName()
    {
      try
      {
        var f = new ConvexHullControl(new OpenImageToBitmap(null), new JarvisMatch());
      }
      catch (ArgumentException e)
      {
        return;
      }
      Assert.Fail();
    }

    [TestMethod]
    public void NullStrategies()
    {
      try
      {
        var f = new ConvexHullControl(null, null);
      }
      catch (ArgumentNullException e)
      {
        return;
      }
      Assert.Fail();
    }
  }
}
