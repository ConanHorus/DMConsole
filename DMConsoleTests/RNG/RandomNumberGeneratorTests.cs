// This file is under the MIT license.

using System;
using DMConsole.RNG;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DMConsoleTests.RNG
{
  /// <summary>
  /// Tests for the <see cref="RandomNumberGenerator"/> class.
  /// </summary>
  [TestClass]
  public class RandomNumberGeneratorTests
  {
    /// <summary>
    /// Tests calling Next() when both numbers are the same.
    /// </summary>
    [TestMethod]
    public void Next_SameNumber()
    {
      var randomNumberGenerator = new RandomNumberGenerator();

      int result = randomNumberGenerator.Next(2, 2);

      Assert.AreEqual(2, result);
    }

    /// <summary>
    /// Tests calling Next() when minimum number is less than 0.
    /// </summary>
    [TestMethod]
    public void Next_NegativeMinimum()
    {
      var randomNumberGenerator = new RandomNumberGenerator();

      Assert.ThrowsException<ArgumentException>(() => randomNumberGenerator.Next(-1, 3));
    }

    /// <summary>
    /// Tests calling Next() when maximum number is less than minimum number.
    /// </summary>
    [TestMethod]
    public void Next_MaxLessThanMin()
    {
      var randomNumberGenerator = new RandomNumberGenerator();

      Assert.ThrowsException<ArgumentException>(() => randomNumberGenerator.Next(4, 3));
    }
  }
}