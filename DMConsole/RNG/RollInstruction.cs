// This file is under the MIT license.

namespace DMConsole.RNG
{
  /// <summary>
  /// Roll instruction.
  /// </summary>
  public struct RollInstruction
  {
    /// <summary>
    /// Gets a value indicating whether this is an instruction (true) or a value (false).
    /// </summary>
    public bool IsInstruction => this.Instruction != RollNotation.Value;

    /// <summary>
    /// Gets a value indicating whether this is a value (true) or an instruction (false).
    /// </summary>
    public bool IsValue => this.Instruction == RollNotation.Value;

    /// <summary>
    /// Gets total.
    /// </summary>
    public int Total { get; }

    /// <summary>
    /// Gets instruction.
    /// </summary>
    public RollNotation Instruction { get; }

    /// <summary>
    /// Initializes a new instance of the <see cref="RollInstruction"/> struct.
    /// </summary>
    /// <param name="instruction">Instruction.</param>
    public RollInstruction(RollNotation instruction)
    {
      this.Instruction = instruction;
      this.Total = 0;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="RollInstruction"/> struct.
    /// </summary>
    /// <param name="total">Total.</param>
    public RollInstruction(int total)
    {
      this.Instruction = RollNotation.Value;
      this.Total = total;
    }
  }
}