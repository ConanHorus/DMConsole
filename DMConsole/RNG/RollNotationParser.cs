// This file is under the MIT license.

using System.Collections.Generic;

namespace DMConsole.RNG
{
  /// <summary>
  /// Roll notation parsing class.
  /// </summary>
  public class RollNotationParser
  {
    /// <summary>
    /// Parses roll notation into postfix roll instructions.
    /// </summary>
    /// <param name="notation">Notation to parse.</param>
    /// <returns>Roll instructions as postfix.</returns>
    public Queue<RollInstruction> Parse(string notation)
    {
      var infix = this.Convert(notation);
      var stack = new Stack<RollInstruction>();
      var postfix = new Queue<RollInstruction>();

      RollInstruction st;
      foreach (var inst in infix)
      {
        if (inst.IsValue)
        {
          postfix.Enqueue(inst);
        }
        else
        {
          while (stack.Count > 0)
          {
            st = stack.Pop();
            if (st.Instruction.GetPriority() >= inst.Instruction.GetPriority())
            {
              postfix.Enqueue(st);
            }
            else
            {
              stack.Push(st);
              break;
            }
          }

          stack.Push(inst);
        }
      }

      while (stack.Count > 0)
      {
        postfix.Enqueue(stack.Pop());
      }

      return postfix;
    }

    /// <summary>
    /// Converts roll notation into infix roll instructions.
    /// </summary>
    /// <param name="notation">Notation to convert.</param>
    /// <returns>Roll instructions as infix.</returns>
    public List<RollInstruction> Convert(string notation)
    {
      bool wasDigit = false;
      int number = 0;
      var infix = new List<RollInstruction>();

      foreach (char c in notation)
      {
        if (char.IsDigit(c))
        {
          number *= 10;
          number += c - '0';
          wasDigit = true;
        }
        else
        {
          if (wasDigit)
          {
            infix.Add(new RollInstruction(number));
          }

          wasDigit = false;
          number = 0;
        }

        switch (c)
        {
          case 'd':
          case 'D':
            infix.Add(new RollInstruction(RollNotation.D));
            break;

          case '+':
            infix.Add(new RollInstruction(RollNotation.Add));
            break;

          case '-':
            infix.Add(new RollInstruction(RollNotation.Subtract));
            break;

          default:
            break;
        }
      }

      if (wasDigit)
      {
        infix.Add(new RollInstruction(number));
      }

      return infix;
    }
  }
}