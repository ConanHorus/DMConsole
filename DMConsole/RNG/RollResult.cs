// This file is under the MIT license.

namespace DMConsole.RNG
{
  /// <summary>
  /// Roll result struct.
  /// </summary>
  public struct RollResult
  {
    /// <summary>
    /// Gets total.
    /// </summary>
    public int Total { get; }

    /// <summary>
    /// Initializes a new instance of the <see cref="RollResult"/> struct.
    /// </summary>
    /// <param name="total">Total.</param>
    public RollResult(int total)
    {
      this.Total = total;
    }
  }
}