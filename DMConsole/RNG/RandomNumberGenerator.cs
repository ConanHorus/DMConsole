// This file is under the MIT license.

using System;

namespace DMConsole.RNG
{
  /// <inheritdoc/>
  public class RandomNumberGenerator
    : IRandomNumberGenerator
  {
    /// <summary>
    /// System random.
    /// </summary>
    private static readonly Random Random = new Random();

    /// <inheritdoc/>
    public int Next(int min, int max)
    {
      if (min < 0)
      {
        throw new ArgumentException("Minimum value cannot be less than 0", nameof(min));
      }

      if (max < min)
      {
        throw new ArgumentException("Maximum value must be greater than minimum value", nameof(max));
      }

      return Random.Next(min, max + 1);
    }
  }
}