// This file is under the MIT license.

using DMConsole.RNG;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace DMConsoleTests.RNG
{
  /// <summary>
  /// Unit tests for <see cref="DiceBag"/> class.
  /// </summary>
  [TestClass]
  public class DiceBagTests
  {
    /// <summary>
    /// Test rolling "3d6" where all dice roll as 1s.
    /// </summary>
    [TestMethod]
    public void Roll3D6_1s()
    {
      var randomMock = new Mock<IRandomNumberGenerator>();
      randomMock.Setup(x => x.Next(It.IsAny<int>(), It.IsAny<int>())).Returns(1);
      var diceBag = new DiceBag(randomMock.Object);

      var result = diceBag.Roll("3d6");

      Assert.AreEqual(3, result.Total);
    }

    /// <summary>
    /// Test rolling "3d6" where all dice roll as 6s.
    /// </summary>
    [TestMethod]
    public void Roll3D6_6s()
    {
      var randomMock = new Mock<IRandomNumberGenerator>();
      randomMock.Setup(x => x.Next(It.IsAny<int>(), It.IsAny<int>())).Returns(6);
      var diceBag = new DiceBag(randomMock.Object);

      var result = diceBag.Roll("3d6");

      Assert.AreEqual(18, result.Total);
    }

    /// <summary>
    /// Test rolling "3d6+1" where all dice roll as 1s.
    /// </summary>
    [TestMethod]
    public void Roll3D6Plus1_1s()
    {
      var randomMock = new Mock<IRandomNumberGenerator>();
      randomMock.Setup(x => x.Next(It.IsAny<int>(), It.IsAny<int>())).Returns(1);
      var diceBag = new DiceBag(randomMock.Object);

      var result = diceBag.Roll("3d6+1");

      Assert.AreEqual(4, result.Total);
    }

    /// <summary>
    /// Test rolling "3d6+1" where all dice roll as 6s.
    /// </summary>
    [TestMethod]
    public void Roll3D6Plus1_6s()
    {
      var randomMock = new Mock<IRandomNumberGenerator>();
      randomMock.Setup(x => x.Next(It.IsAny<int>(), It.IsAny<int>())).Returns(6);
      var diceBag = new DiceBag(randomMock.Object);

      var result = diceBag.Roll("3d6+1");

      Assert.AreEqual(19, result.Total);
    }

    /// <summary>
    /// Test rolling "1+3d6" where all dice roll as 1s.
    /// </summary>
    [TestMethod]
    public void Roll1Plus3D6_1s()
    {
      var randomMock = new Mock<IRandomNumberGenerator>();
      randomMock.Setup(x => x.Next(It.IsAny<int>(), It.IsAny<int>())).Returns(1);
      var diceBag = new DiceBag(randomMock.Object);

      var result = diceBag.Roll("1+3d6");

      Assert.AreEqual(4, result.Total);
    }

    /// <summary>
    /// Test rolling "1+3d6" where all dice roll as 6s.
    /// </summary>
    [TestMethod]
    public void Roll1Plus3D6_6s()
    {
      var randomMock = new Mock<IRandomNumberGenerator>();
      randomMock.Setup(x => x.Next(It.IsAny<int>(), It.IsAny<int>())).Returns(6);
      var diceBag = new DiceBag(randomMock.Object);

      var result = diceBag.Roll("1+3d6");

      Assert.AreEqual(19, result.Total);
    }

    /// <summary>
    /// Test generating a new dice bag.
    /// </summary>
    [TestMethod]
    public void GenerateNew()
    {
      var diceBag = DiceBag.GenerateNew();

      Assert.IsTrue(diceBag is DiceBag);
    }
  }
}