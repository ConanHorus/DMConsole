// This file is under the MIT license.

using System.Collections.Generic;
using DMConsole.RNG.InstructionChain;

namespace DMConsole.RNG
{
  /// <summary>
  /// Roll notation parsing class.
  /// </summary>
  public static class RollNotationParser
  {
    /// <summary>
    /// Parses roll notation into postfix roll instructions.
    /// </summary>
    /// <param name="notation">Notation to parse.</param>
    /// <returns>Roll instructions as postfix.</returns>
    public static Queue<RollInstruction> Parse(string notation)
    {
      var validation = Validate(notation);
      if (!validation.IsGood)
      {
        throw new NotationValidationException(validation.Message);
      }

      var infix = Convert(notation);
      var stack = new Stack<RollInstruction>();
      var postfix = new Queue<RollInstruction>();

      foreach (var inst in infix)
      {
        if (inst.IsValue)
        {
          postfix.Enqueue(inst);
        }
        else
        {
          PostfixInstruction(inst, stack, postfix);
        }
      }

      while (stack.Count > 0)
      {
        postfix.Enqueue(stack.Pop());
      }

      return postfix;
    }

    /// <summary>
    /// Validation method.
    /// </summary>
    /// <param name="notation">Notation to validate.</param>
    /// <returns>Notation validation response.</returns>
    public static NotationValidation Validate(string notation)
    {
      int parenLevel = 0;

      foreach (char c in notation)
      {
        if (c == '(')
        {
          parenLevel++;
        }

        if (c == ')')
        {
          parenLevel--;
        }

        if (parenLevel < 0)
        {
          return NotationValidation.Bad("Miss-match parentheses.");
        }
      }

      if (parenLevel > 0)
      {
        return NotationValidation.Bad("Miss-match parentheses.");
      }

      return NotationValidation.Good();
    }

    /// <summary>
    /// Converts roll notation into infix roll instructions.
    /// </summary>
    /// <param name="notation">Notation to convert.</param>
    /// <returns>Roll instructions as infix.</returns>
    public static List<RollInstruction> Convert(string notation)
    {
      int index = 0;
      var infix = new List<RollInstruction>();

      while (index < notation.Length)
      {
        var parsed = RollInstructionChain.ParseNextInstruction(notation, index);
        if (parsed.success)
        {
          infix.Add(parsed.inst);
        }

        index = parsed.index;
      }

      return infix;
    }

    /// <summary>
    /// Post-fixes instruction.
    /// </summary>
    /// <param name="inst">Instruction to postfix.</param>
    /// <param name="stack">Stack.</param>
    /// <param name="postfix">Postix.</param>
    private static void PostfixInstruction(
      RollInstruction inst,
      Stack<RollInstruction> stack,
      Queue<RollInstruction> postfix)
    {
      RollInstruction holder;
      if (inst.Instruction == RollNotation.OpenParen)
      {
        stack.Push(inst);
      }
      else if (inst.Instruction == RollNotation.CloseParen)
      {
        holder = stack.Pop();
        while (holder.Instruction != RollNotation.OpenParen)
        {
          postfix.Enqueue(holder);
          holder = stack.Pop();
        }
      }
      else
      {
        while (stack.Count > 0)
        {
          holder = stack.Pop();
          if (holder.Instruction.GetPriority() >= inst.Instruction.GetPriority())
          {
            postfix.Enqueue(holder);
          }
          else
          {
            stack.Push(holder);
            break;
          }
        }
      }

      stack.Push(inst);
    }
  }
}