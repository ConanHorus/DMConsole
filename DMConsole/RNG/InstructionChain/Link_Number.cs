// This file is under the MIT license.

using System.Collections.Generic;

namespace DMConsole.RNG.InstructionChain
{
  /// <summary>
  /// Number link.
  /// </summary>
  public class Link_Number
    : IRollInstructionLink
  {
    /// <inheritdoc/>
    public (bool success, RollInstruction inst, int index) Parse(string notation, int index)
    {
      if (!char.IsNumber(notation[index]))
      {
        return (success: false, default, index);
      }

      int number = 0;
      while (index < notation.Length && char.IsNumber(notation[index]))
      {
        number *= 10;
        number += notation[index] - '0';
        index++;
      }

      return (success: true, new RollInstruction(number), index);
    }

    /// <inheritdoc/>
    public void PerformInstruction(RollInstruction inst, Stack<RollInstruction> stack)
    {
      stack.Push(inst);
    }

    /// <inheritdoc/>
    public bool ShouldPerformInstruction(RollInstruction inst)
    {
      return inst.IsValue;
    }
  }
}