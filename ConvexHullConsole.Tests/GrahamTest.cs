// <copyright file="GrahamTest.cs">Copyright ©  2017</copyright>

using System;
using System.Linq;
using ConvexHull;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace ConvexHull.Tests
{
  /// <summary>Этот класс содержит параметризованные модульные тесты для Graham</summary>
  [TestClass]
  [PexClass(typeof(Graham))]
  [PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
  [PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
  public partial class GrahamTest
  {
    static IConvexHullScan scan = new Graham();
    //private static void TestForConvexHull(List<CPoint> input, List<CPoint> hull)
    //{
    //  var res = scan.ConvexHullScan(input);
    //  Assert.AreEqual(res.ToStr(), hull.ToStr());
    //}

    //[TestMethod]
    //public void MatchTestManual0()
    //{
    //  TestForConvexHull(new List<CPoint>() { }, new List<CPoint>() { });
    //}

    //[TestMethod]
    //public void MatchTestManual1()
    //{
    //  TestForConvexHull(new List<CPoint>() { new CPoint(50, 50) }, new List<CPoint>() { new CPoint(50, 50) });
    //}

    //[TestMethod]
    //public void MatchTestManual2()
    //{
    //  TestForConvexHull(new List<CPoint>() { new CPoint(50, 50), new CPoint(60, 50) },
    //    new List<CPoint>() { new CPoint(50, 50), new CPoint(60, 50) });
    //}

    //[TestMethod]
    //public void MatchTestManual2Equal()
    //{
    //  TestForConvexHull(new List<CPoint>() { new CPoint(50, 50), new CPoint(50, 50) },
    //    new List<CPoint>() { new CPoint(50, 50) });
    //}

    //[TestMethod]
    //public void MatchTestManual3()
    //{
    //  TestForConvexHull(new List<CPoint>() { new CPoint(50, 50), new CPoint(50, 10), new CPoint(20, 50) },
    //    new List<CPoint>() { new CPoint(20, 50), new CPoint(50, 10), new CPoint(50, 50) });
    //}

    //[TestMethod]
    //public void MatchTestManual4()
    //{
    //  TestForConvexHull(new List<CPoint>()
    //  { new CPoint(50, 50), new CPoint(50, 10), new CPoint(20, 50), new CPoint(40, 40) },
    //    new List<CPoint>() { new CPoint(20, 50), new CPoint(50, 10), new CPoint(50, 50) });
    //}

    //[TestMethod]
    //public void MatchTestManual6()
    //{
    //  TestForConvexHull(new List<CPoint>()
    //  { new CPoint(50, 50), new CPoint(35, 40), new CPoint(50, 10), new CPoint(30, 40),
    //    new CPoint(20, 50), new CPoint(40, 40) },
    //    new List<CPoint>() { new CPoint(20, 50), new CPoint(50, 10), new CPoint(50, 50) });
    //}

    //[TestMethod]
    //public void MatchTestManual7()
    //{
    //  TestForConvexHull(new List<CPoint>() { new CPoint(0, 0), new CPoint(35, 40),
    //    new CPoint(50, 10), new CPoint(30, 40), new CPoint(20, 50), new CPoint(40, 40) },
    //    new List<CPoint>() { new CPoint(0, 0), new CPoint(50, 10),
    //      new CPoint(40, 40), new CPoint(20, 50), });
    //}
  }
}
