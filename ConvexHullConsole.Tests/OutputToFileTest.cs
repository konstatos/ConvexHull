// <copyright file="OutputToFileTest.cs">Copyright ©  2017</copyright>

using System;
using ConvexHull;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.IO;

namespace ConvexHull.Tests
{
  /// <summary>Этот класс содержит параметризованные модульные тесты для OutputToFile</summary>
  [TestClass]
  [PexClass(typeof(OutputToFile))]
  [PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
  [PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
  public partial class OutputToFileTest
  {
    [TestMethod]
    public void OutputToFileNoName()
    {
      try
      {
        var f = new OutputToFile("");
      }
      catch (ArgumentException e)
      {
        return;
      }
      Assert.Fail();
    }

    [TestMethod]
    public void OutputToFileNullName()
    {
      try
      {
        var f = new OutputToFile(null);
      }
      catch (ArgumentException e)
      {
        return;
      }
      Assert.Fail();
    }

    [TestMethod]
    public void OutputToFileOk()
    {
      const string fn = "ex.txt";
      var f = new OutputToFile(fn);
      f.OutputHull(new List<CPoint>() { new CPoint(50, 50), new CPoint(60, 50) });
      f.OutputPoints(new List<CPoint>() { new CPoint(50, 50), new CPoint(60, 50) });
      File.Exists(fn);
    }
  }
}
