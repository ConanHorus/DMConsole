// This file is under the MIT license.

namespace DMConsole.RNG
{
  /// <summary>
  /// Random number generator specifically for rolling dice.
  /// </summary>
  public interface IRandomNumberGenerator
  {
    /// <summary>
    /// Gets next randomly generated number.
    /// </summary>
    /// <param name="min">Minimum value, inclusive.</param>
    /// <param name="max">Maximum value, inclusive.</param>
    /// <returns>Next randomly generated number.</returns>
    int Next(int min, int max);
  }
}