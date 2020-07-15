// This file is under the MIT license.

using System.Collections.Generic;
using DMConsole.RNG;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace DMConsoleTests.RNG
{
  /// <summary>
  /// Test class for <see cref="RollProcessor"/> class.
  /// </summary>
  [TestClass]
  public class RollProcessorTests
  {
    /// <summary>
    /// Tests processing "3d6" where all dice roll 1.
    /// </summary>
    [TestMethod]
    public void Process_3D6_1s()
    {
      var postfix = new Queue<RollInstruction>();
      postfix.Enqueue(new RollInstruction(3));
      postfix.Enqueue(new RollInstruction(6));
      postfix.Enqueue(new RollInstruction(RollNotation.D));

      var randomNumberGeneratorMock = new Mock<IRandomNumberGenerator>();
      randomNumberGeneratorMock.Setup(x => x.Next(It.IsAny<int>(), It.IsAny<int>())).Returns(1);

      var result = RollProcessor.Process(postfix, randomNumberGeneratorMock.Object);

      Assert.AreEqual(3, result.Total);
    }

    /// <summary>
    /// Tests processing "3d6" where all dice roll 6.
    /// </summary>
    [TestMethod]
    public void Process_3D6_6s()
    {
      var postfix = new Queue<RollInstruction>();
      postfix.Enqueue(new RollInstruction(3));
      postfix.Enqueue(new RollInstruction(6));
      postfix.Enqueue(new RollInstruction(RollNotation.D));

      var randomNumberGeneratorMock = new Mock<IRandomNumberGenerator>();
      randomNumberGeneratorMock.Setup(x => x.Next(It.IsAny<int>(), It.IsAny<int>())).Returns(6);

      var result = RollProcessor.Process(postfix, randomNumberGeneratorMock.Object);

      Assert.AreEqual(18, result.Total);
    }
  }
}