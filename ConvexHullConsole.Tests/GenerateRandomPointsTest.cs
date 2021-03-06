using System.Collections.Generic;
// <copyright file="GenerateRandomPointsTest.cs">Copyright ©  2017</copyright>

using System;
using ConvexHull;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ConvexHull.Tests
{
    /// <summary>Этот класс содержит параметризованные модульные тесты для GenerateRandomPoints</summary>
    [TestClass]
    [PexClass(typeof(GenerateRandomPoints))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    [PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    public partial class GenerateRandomPointsTest
    {

    /// <summary>Тестовая заглушка для OpenImage()</summary>
    [PexMethod]
    public List<CPoint> OpenImageTest([PexAssumeUnderTest]GenerateRandomPoints target)
    {
      List<CPoint> result = target.OpenImage();
      return result;
    }

    [TestMethod]
    public void OpenImageTestManual()
    {
      GenerateRandomPoints generateRandomPoints;
      List<CPoint> list;
      generateRandomPoints = new GenerateRandomPoints(100, 100);
      list = this.OpenImageTest(generateRandomPoints);
      Assert.IsNotNull((object)generateRandomPoints);
      Assert.AreEqual(list.Count, 100);
    }
  }
}
