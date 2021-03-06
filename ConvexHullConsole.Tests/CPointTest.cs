// <copyright file="CPointTest.cs">Copyright ©  2017</copyright>

using System;
using ConvexHull;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ConvexHull.Tests
{
  /// <summary>Этот класс содержит параметризованные модульные тесты для CPoint</summary>
  [TestClass]
  [PexClass(typeof(CPoint))]
  [PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
  [PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
  public partial class CPointTest
  {
    [TestMethod]
    public void CPoint()
    {
      var p = new CPoint(100, 500);
      PexAssert.AreEqual(p.X, 100);
      PexAssert.AreEqual(p.Y, 500);
    }
  }
}
