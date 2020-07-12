// This file is under the MIT license.

using System;

namespace DMConsole.RNG
{
  /// <summary>
  /// Class for rolling and tracking rolls of dice.
  /// </summary>
  public class DiceBag
  {
    /// <summary>
    /// Random number generator.
    /// </summary>
    private readonly IRandomNumberGenerator randomNumberGenerator;

    /// <summary>
    /// Roll notation parser.
    /// </summary>
    private readonly RollNotationParser rollNotationParser = new RollNotationParser();

    /// <summary>
    /// Initializes a new instance of the <see cref="DiceBag"/> class.
    /// </summary>
    /// <param name="randomNumberGenerator">Random number generator.</param>
    public DiceBag(IRandomNumberGenerator randomNumberGenerator)
    {
      this.randomNumberGenerator = randomNumberGenerator;
    }

    /// <summary>
    /// Generates new <see cref="DiceBag"/> instance.
    /// </summary>
    /// <returns>New <see cref="DiceBag"/> instance.</returns>
    public static DiceBag GenerateNew()
    {
      return new DiceBag(new RandomNumberGenerator());
    }

    /// <summary>
    /// Rolls dice according to expression.
    /// </summary>
    /// <param name="expression">Expression comprised of roll notation.</param>
    /// <returns>Roll result.</returns>
    /// <exception cref="ArgumentNullException">Expression is null, empty, or white space.</exception>
    /// <exception cref="ArgumentException">Roll notation is malformed.</exception>
    public RollResult Roll(string expression)
    {
      if (string.IsNullOrWhiteSpace(expression))
      {
        throw new ArgumentNullException(nameof(expression));
      }

      var instructions = this.rollNotationParser.Parse(expression);
      return this.rollProcessor(instructions);
    }
  }
}