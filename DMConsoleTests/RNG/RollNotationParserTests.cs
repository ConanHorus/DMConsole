// This file is under the MIT license.

using DMConsole.RNG;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DMConsoleTests.RNG
{
  /// <summary>
  /// Unit tests for <see cref="RollNotationParser"/> class.
  /// </summary>
  [TestClass]
  public class RollNotationParserTests
  {
    /// <summary>
    /// Tests parsing "3d6".
    /// </summary>
    [TestMethod]
    public void Parse_3D6()
    {
      var rollNotationParser = new RollNotationParser();

      var postfix = rollNotationParser.Parse("3d6");

      Assert.AreEqual(3, postfix.Dequeue().Total, "Instruction 1");
      Assert.AreEqual(6, postfix.Dequeue().Total, "Instruction 2");
      Assert.AreEqual(RollNotation.D, postfix.Dequeue().Instruction, "Instruction 3");
    }

    /// <summary>
    /// Tests converting "3d6" into infix instructions.
    /// </summary>
    [TestMethod]
    public void ConvertNotation_3D6()
    {
      var rollNotationParser = new RollNotationParser();

      var infix = rollNotationParser.Convert("3d6");

      Assert.AreEqual(3, infix[0].Total, "Instruction 1");
      Assert.AreEqual(RollNotation.D, infix[1].Instruction, "Instruction 2");
      Assert.AreEqual(6, infix[2].Total, "Instruction 3");
    }
  }
}