// This file is under the MIT license.

using System.Collections.Generic;

namespace DMConsole.RNG.InstructionChain
{
  /// <summary>
  /// D link.
  /// </summary>
  public class Link_D
    : IRollInstructionLink
  {
    /// <summary>
    /// Random number generator.
    /// </summary>
    private IRandomNumberGenerator randomNumberGenerator;

    /// <summary>
    /// Sets random number generator.
    /// </summary>
    /// <param name="randomNumberGenerator">Random number generator.</param>
    public void SetRandom(IRandomNumberGenerator randomNumberGenerator)
    {
      this.randomNumberGenerator = randomNumberGenerator;
    }

    /// <inheritdoc/>
    public (bool success, RollInstruction inst, int index) Parse(string notation, int index)
    {
      char c = notation[index];

      if (c == 'd' || c == 'D')
      {
        return (success: true, new RollInstruction(RollNotation.D), index + 1);
      }

      return (success: false, inst: default, index);
    }

    /// <inheritdoc/>
    public void PerformInstruction(RollInstruction inst, Stack<RollInstruction> stack)
    {
      var b = stack.Pop();
      var a = stack.Pop();

      int count = a.Total;
      int sides = b.Total;

      int number = 0;
      for (int i = 0; i < count; i++)
      {
        number += this.randomNumberGenerator.Next(1, sides);
      }

      stack.Push(new RollInstruction(number));
    }

    /// <inheritdoc/>
    public bool ShouldPerformInstruction(RollInstruction inst)
    {
      return inst.Instruction == RollNotation.D;
    }
  }
}