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

      var rollInstructionStack = rollNotationParser.Parse("3d6");

      Assert.AreEqual(3, rollInstructionStack.Pop().Total, "Instruction 1");
      Assert.AreEqual(6, rollInstructionStack.Pop().Total, "Instruction 2");
      Assert.AreEqual(RollNotation.D, rollInstructionStack.Pop().Instruction, "Instruction 3");
    }
  }
}