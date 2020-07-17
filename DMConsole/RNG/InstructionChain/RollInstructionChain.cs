// This file is under the MIT license.

using System.Collections.Generic;

namespace DMConsole.RNG.InstructionChain
{
  /// <summary>
  /// Encapsulating class for roll instruction chain links.
  /// </summary>
  public static class RollInstructionChain
  {
    /// <summary>
    /// Collection of links.
    /// </summary>
    private static IRollInstructionLink[] links = null;

    /// <summary>
    /// Parses next instruction from notation.
    /// </summary>
    /// <param name="notation">Notation to parse.</param>
    /// <param name="index">Index in notation.</param>
    /// <returns>Parsed instruction.</returns>
    public static (bool success, RollInstruction inst, int index) ParseNextInstruction(string notation, int index)
    {
      Setup();

      while (index < notation.Length && char.IsWhiteSpace(notation[index]))
      {
        index++;
      }

      if (index >= notation.Length)
      {
        return (success: false, inst: default, notation.Length);
      }

      foreach (var link in links)
      {
        var parsed = link.Parse(notation, index);
        if (parsed.success)
        {
          return parsed;
        }
      }

      return (success: false, inst: default, index);
    }

    /// <summary>
    /// Performs a single instruction.
    /// </summary>
    /// <param name="postfix">Postfix notation.</param>
    /// <param name="stack">Numbers stack.</param>
    /// <returns>Whether there are more instructions to perform.</returns>
    public static bool PerformInstruction(Queue<RollInstruction> postfix, Stack<RollInstruction> stack)
    {
      Setup();

      var inst = postfix.Dequeue();

      foreach (var link in links)
      {
        if (link.ShouldPerformInstruction(inst))
        {
          link.PerformInstruction(inst, stack);
          break;
        }
      }

      return postfix.Count > 0;
    }

    /// <summary>
    /// Sets random number generator.
    /// </summary>
    /// <param name="random">Random number generator.</param>
    public static void SetRandom(IRandomNumberGenerator random)
    {
      Setup();

      foreach (var link in links)
      {
        if (link is Link_D d)
        {
          d.SetRandom(random);
          return;
        }
      }
    }

    /// <summary>
    /// Sets up this instruction chain.
    /// </summary>
    public static void Setup()
    {
      if (links is null)
      {
        links = new IRollInstructionLink[]
        {
          new Link_Number(),
          new Link_D(),
          new Link_OpenParen(),
          new Link_CloseParen(),
          new Link_Add(),
          new Link_Subtract(),
          new Link_Multiply(),
          new Link_Divide()
        };
      }
    }
  }
}