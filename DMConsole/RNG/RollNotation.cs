// This file is under the MIT license.

namespace DMConsole.RNG
{
  /// <summary>
  /// Roll notation enum.
  /// </summary>
  public enum RollNotation
    : uint
  {
    /// <summary>
    /// Value.
    /// </summary>
    Value = 0x0000_0000,

    /// <summary>
    /// "D" as in "3d6" to indicate number of sides on a die.
    /// </summary>
    D = 0xFFFF_0001,

    /// <summary>
    /// Addition.
    /// </summary>
    Add = 0x0001_0002,

    /// <summary>
    /// Subtraction.
    /// </summary>
    Subtract = 0x0001_0003
  }
}