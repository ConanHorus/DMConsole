// This file is under the MIT license.

namespace DMConsole.RNG
{
  /// <summary>
  /// Notation validation response.
  /// </summary>
  public struct NotationValidation
  {
    /// <summary>
    /// Gets a value indicating whether validation is good.
    /// </summary>
    public bool IsGood { get; private set; }

    /// <summary>
    /// Gets message which describes failure.
    /// </summary>
    public string Message { get; private set; }

    /// <summary>
    /// Returns a good validation.
    /// </summary>
    /// <returns>Good validation.</returns>
    public static NotationValidation Good()
    {
      return new NotationValidation
      {
        IsGood = true,
        Message = null
      };
    }

    /// <summary>
    /// Returns a bad validation.
    /// </summary>
    /// <param name="message">Message.</param>
    /// <returns>Bad validation.</returns>
    public static NotationValidation Bad(string message)
    {
      return new NotationValidation
      {
        IsGood = false,
        Message = message
      };
    }
  }
}