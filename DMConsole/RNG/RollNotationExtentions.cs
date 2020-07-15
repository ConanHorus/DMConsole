// This file is under the MIT license.

namespace DMConsole.RNG
{
  /// <summary>
  /// Roll notation extentions.
  /// </summary>
  public static class RollNotationExtentions
  {
    /// <summary>
    /// Gets priority of roll notation enum.
    /// </summary>
    /// <param name="value">Roll notation enum.</param>
    /// <returns>Priority.</returns>
    public static ushort GetPriority(this RollNotation value)
    {
      RollNotationValue rnv = (uint)value;
      return rnv.Priority;
    }
  }
}