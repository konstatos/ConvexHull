// <copyright file="OutputToConsoleTest.cs">Copyright ©  2017</copyright>

using System;
using ConvexHull;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace ConvexHull.Tests
{
  /// <summary>Этот класс содержит параметризованные модульные тесты для OutputToConsole</summary>
  [TestClass]
  [PexClass(typeof(OutputToConsole))]
  [PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
  [PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
  public partial class OutputToConsoleTest
  {
    [TestMethod]
    public void OutputToFileOk()
    {
      var f = new OutputToConsole();
      f.OutputHull(new List<CPoint>() { new CPoint(50, 50), new CPoint(60, 50) });
      f.OutputPoints(new List<CPoint>() { new CPoint(50, 50), new CPoint(60, 50) });
    }
  }
}
