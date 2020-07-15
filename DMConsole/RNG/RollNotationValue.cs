// This file is under the MIT license.

namespace DMConsole.RNG
{
  /// <summary>
  /// Roll notation value.
  /// </summary>
  public struct RollNotationValue
  {
    /// <summary>
    /// Internal value.
    /// </summary>
    private readonly uint internalValue;

    /// <summary>
    /// Gets unique value.
    /// </summary>
    public ushort UniqueValue => (ushort)this.internalValue;

    /// <summary>
    /// Gets priority.
    /// </summary>
    public ushort Priority => (ushort)(this.internalValue >> 16);

    /// <summary>
    /// Initializes a new instance of the <see cref="RollNotationValue"/> struct.
    /// </summary>
    /// <param name="value">Value to use.</param>
    public RollNotationValue(int value)
    {
      this.internalValue = (uint)value;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="RollNotationValue"/> struct.
    /// </summary>
    /// <param name="value">Value to use.</param>
    public RollNotationValue(uint value)
    {
      this.internalValue = value;
    }

    public static implicit operator RollNotationValue(int value)
    {
      return new RollNotationValue(value);
    }

    public static implicit operator RollNotationValue(uint value)
    {
      return new RollNotationValue(value);
    }

    public static bool operator ==(RollNotationValue left, RollNotationValue right)
    {
      return left.Equals(right);
    }

    public static bool operator !=(RollNotationValue left, RollNotationValue right)
    {
      return !(left == right);
    }

    /// <inheritdoc/>
    public override bool Equals(object obj)
    {
      if (obj is RollNotationValue rnv)
      {
        return this.internalValue == rnv.internalValue;
      }
      else if (obj is int a)
      {
        return this.internalValue == (uint)a;
      }
      else if (obj is uint b)
      {
        return this.internalValue == b;
      }

      return false;
    }

    /// <inheritdoc/>
    public override int GetHashCode()
    {
      return this.internalValue.GetHashCode();
    }
  }
}