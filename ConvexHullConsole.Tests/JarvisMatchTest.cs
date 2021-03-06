// <copyright file="JarvisMatchTest.cs">Copyright ©  2017</copyright>

using System;
using ConvexHull;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace ConvexHull.Tests
{
  /// <summary>Этот класс содержит параметризованные модульные тесты для JarvisMatch</summary>
  [TestClass]
  [PexClass(typeof(JarvisMatch))]
  [PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
  [PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
  public partial class JarvisMatchTest
  {
    static IConvexHullScan scan = new JarvisMatch();
    private static void TestForConvexHull(List<CPoint> input, List<CPoint> hull)
    {
      var res = scan.ConvexHullScan(input);
      Assert.AreEqual(res.ToStr(), hull.ToStr());
    }

    [TestMethod]
    public void MatchTestManual0Points()
    {
      TestForConvexHull(new List<CPoint>() { }, new List<CPoint>() { });
    }

    [TestMethod]
    public void MatchTestManual1Point()
    {
      TestForConvexHull(new List<CPoint>() { new CPoint(50, 50) },
        new List<CPoint>() { new CPoint(50, 50) });
    }

    [TestMethod]
    public void MatchTestManual2Points()
    {
      TestForConvexHull(new List<CPoint>() { new CPoint(50, 50), new CPoint(60, 50) },
        new List<CPoint>() { new CPoint(50, 50), new CPoint(60, 50) });
    }

    [TestMethod]
    public void MatchTestManual2EqualPoints()
    {
      TestForConvexHull(new List<CPoint>() { new CPoint(50, 50), new CPoint(50, 50) },
        new List<CPoint>() { new CPoint(50, 50) });
    }

    [TestMethod]
    public void MatchTestManual3Points()
    {
      TestForConvexHull(new List<CPoint>() { new CPoint(50, 50),
        new CPoint(50, 10), new CPoint(20, 50) },
        new List<CPoint>() { new CPoint(20, 50), new CPoint(50, 10), new CPoint(50, 50) });
    }

    [TestMethod]
    public void MatchTestManual4Points()
    {
      TestForConvexHull(new List<CPoint>()
      { new CPoint(50, 50), new CPoint(50, 10), new CPoint(20, 50), new CPoint(40, 40) },
        new List<CPoint>() { new CPoint(20, 50), new CPoint(50, 10), new CPoint(50, 50) });
    }

    [TestMethod]
    public void MatchTestManual6Points()
    {
      TestForConvexHull(new List<CPoint>()
      { new CPoint(50, 50), new CPoint(35, 40), new CPoint(50, 10), new CPoint(30, 40),
        new CPoint(20, 50), new CPoint(40, 40) },
        new List<CPoint>() { new CPoint(20, 50), new CPoint(50, 10), new CPoint(50, 50) });
    }

    [TestMethod]
    public void MatchTestManual7Points()
    {
      TestForConvexHull(new List<CPoint>() { new CPoint(0, 0), new CPoint(35, 40),
        new CPoint(50, 10), new CPoint(30, 40), new CPoint(20, 50),
        new CPoint(20, 50), new CPoint(40, 40) },
        new List<CPoint>() { new CPoint(0, 0), new CPoint(50, 10),
          new CPoint(40, 40), new CPoint(20, 50), });
    }


    [TestMethod]
    public void MatchTestManual7PointsNegativ()
    {
      TestForConvexHull(new List<CPoint>() { new CPoint(0, 0), new CPoint(35, 40),
        new CPoint(50, 10), new CPoint(-30, 40), new CPoint(20, 50),
        new CPoint(20, 50), new CPoint(40, 40) },
        new List<CPoint>() { new CPoint(0, 0), new CPoint(-30, 40), new CPoint(50, 10),
          new CPoint(40, 40), new CPoint(20, 50), });
    }
  }
}
