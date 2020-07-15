// This file is under the MIT license.

using System.Collections.Generic;

namespace DMConsole.RNG
{
  /// <summary>
  /// Roll processor class.
  /// </summary>
  public static class RollProcessor
  {
    /// <summary>
    /// Processes instruction queue.
    /// </summary>
    /// <param name="postfix">Postix instructions.</param>
    /// <param name="random">Random number generator.</param>
    /// <returns>Roll result.</returns>
    public static RollResult Process(Queue<RollInstruction> postfix, IRandomNumberGenerator random)
    {
      var valueStack = new Stack<RollInstruction>();

      while (postfix.Count > 0)
      {
        var next = postfix.Dequeue();

        if (next.IsInstruction)
        {
          switch (next.Instruction)
          {
            case RollNotation.D:
              int rolled = 0;
              var sides = valueStack.Pop();
              var number = valueStack.Pop();
              for (int i = 0; i < number.Total; i++)
              {
                rolled += random.Next(1, sides.Total);
              }

              valueStack.Push(new RollInstruction(rolled));
              break;

            case RollNotation.Add:
              var b = valueStack.Pop();
              var a = valueStack.Pop();
              valueStack.Push(new RollInstruction(a.Total + b.Total));
              break;

            case RollNotation.Subtract:
              var d = valueStack.Pop();
              var c = valueStack.Pop();
              valueStack.Push(new RollInstruction(c.Total - d.Total));
              break;
          }
        }
        else
        {
          valueStack.Push(next);
        }
      }

      return new RollResult(valueStack.Pop().Total);
    }
  }
}