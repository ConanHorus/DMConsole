// This file is under the MIT license.

using System.Collections.Generic;

namespace DMConsole.RNG.InstructionChain
{
  /// <summary>
  /// Divide link.
  /// </summary>
  public class Link_Divide
    : IRollInstructionLink
  {
    /// <inheritdoc/>
    public (bool success, RollInstruction inst, int index) Parse(string notation, int index)
    {
      if (notation[index] == '/')
      {
        return (success: true, new RollInstruction(RollNotation.Divide), index + 1);
      }

      return (success: false, inst: default, index);
    }

    /// <inheritdoc/>
    public void PerformInstruction(RollInstruction inst, Stack<RollInstruction> stack)
    {
      int b = stack.Pop().Total;
      int a = stack.Pop().Total;

      stack.Push(new RollInstruction(a / b));
    }

    /// <inheritdoc/>
    public bool ShouldPerformInstruction(RollInstruction inst)
    {
      return inst.Instruction == RollNotation.Divide;
    }
  }
}