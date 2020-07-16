// This file is under the MIT license.

using System.Collections.Generic;

namespace DMConsole.RNG.InstructionChain
{
  /// <summary>
  /// Close paren link.
  /// </summary>
  public class Link_CloseParen
    : IRollInstructionLink
  {
    /// <inheritdoc/>
    public (bool success, RollInstruction inst, int index) Parse(string notation, int index)
    {
      if (notation[index] == ')')
      {
        return (success: true, new RollInstruction(RollNotation.CloseParen), index + 1);
      }

      return (success: false, inst: default, index);
    }

    /// <inheritdoc/>
    public void PerformInstruction(RollInstruction inst, Stack<RollInstruction> stack)
    {
      throw new System.NotImplementedException();
    }

    /// <inheritdoc/>
    public bool ShouldPerformInstruction(RollInstruction inst)
    {
      return false;
    }
  }
}