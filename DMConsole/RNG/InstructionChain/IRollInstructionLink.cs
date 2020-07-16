// This file is under the MIT license.

using System.Collections.Generic;

namespace DMConsole.RNG.InstructionChain
{
  /// <summary>
  /// Roll instruction link.
  /// </summary>
  public interface IRollInstructionLink
  {
    /// <summary>
    /// Attempts to parse next instruction.
    /// </summary>
    /// <param name="notation">Notation to parse from.</param>
    /// <param name="index">Index.</param>
    /// <returns>Instruction and whether successful.</returns>
    (bool success, RollInstruction inst, int index) Parse(string notation, int index);

    /// <summary>
    /// Determines whether to perform instruction.
    /// </summary>
    /// <param name="inst">Instruction to test.</param>
    /// <returns>Whether to perform instruction.</returns>
    bool ShouldPerformInstruction(RollInstruction inst);

    /// <summary>
    /// Performs instruction.
    /// </summary>
    /// <param name="inst">Instruction.</param>
    /// <param name="stack">Scratch stack.</param>
    void PerformInstruction(RollInstruction inst, Stack<RollInstruction> stack);
  }
}