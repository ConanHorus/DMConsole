// This file is under the MIT license.

using System;
using System.Runtime.Serialization;

namespace DMConsole.RNG
{
  /// <summary>
  /// Notation validation exception.
  /// </summary>
  public class NotationValidationException
    : Exception
  {
    /// <summary>
    /// Initializes a new instance of the <see cref="NotationValidationException"/> class.
    /// </summary>
    public NotationValidationException()
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="NotationValidationException"/> class.
    /// </summary>
    /// <param name="message">Message.</param>
    public NotationValidationException(string message)
      : base(message)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="NotationValidationException"/> class.
    /// </summary>
    /// <param name="message">Message.</param>
    /// <param name="innerException">Inner exception.</param>
    public NotationValidationException(string message, Exception innerException)
      : base(message, innerException)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="NotationValidationException"/> class.
    /// </summary>
    /// <param name="info">Info.</param>
    /// <param name="context">Context.</param>
    protected NotationValidationException(SerializationInfo info, StreamingContext context)
      : base(info, context)
    {
    }
  }
}