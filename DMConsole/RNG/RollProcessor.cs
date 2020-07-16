// This file is under the MIT license.

using System.Collections.Generic;
using DMConsole.RNG.InstructionChain;

namespace DMConsole.RNG
{
  /// <summary>
  /// Roll processor class.
  /// </summary>
  public static class RollProcessor
  {
    /// <summary>
    /// Processes instruction queue.
    /// </summary>
    /// <param name="postfix">Postix instructions.</param>
    /// <param name="random">Random number generator.</param>
    /// <returns>Roll result.</returns>
    public static RollResult Process(Queue<RollInstruction> postfix, IRandomNumberGenerator random)
    {
      RollInstructionChain.SetRandom(random);

      var valueStack = new Stack<RollInstruction>();
      bool more;

      do
      {
        more = RollInstructionChain.PerformInstruction(postfix, valueStack);
      }
      while (more);

      return new RollResult(valueStack.Pop().Total);
    }
  }
}