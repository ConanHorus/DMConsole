// This file is under the MIT license.

using System.Collections.Generic;

namespace DMConsole.RNG.InstructionChain
{
  /// <summary>
  /// Open paren link.
  /// </summary>
  public class Link_OpenParen
    : IRollInstructionLink
  {
    /// <inheritdoc/>
    public (bool success, RollInstruction inst, int index) Parse(string notation, int index)
    {
      if (notation[index] == '(')
      {
        return (success: true, new RollInstruction(RollNotation.OpenParen), index + 1);
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