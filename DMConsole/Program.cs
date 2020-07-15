// This file is under the MIT license.

using System;
using DMConsole.RNG;

namespace DMConsole
{
  /// <summary>
  /// Program class.
  /// </summary>
  internal class Program
  {
    /// <summary>
    /// Program entry point.
    /// </summary>
    /// <param name="args">Startup arguments.</param>
    private static void Main(string[] args)
    {
      Console.WriteLine("What dice would you like to roll?");
      Console.ForegroundColor = ConsoleColor.Yellow;
      Console.Write("> ");
      var input = Console.ReadLine();
      Console.ForegroundColor = ConsoleColor.Gray;

      Console.WriteLine();

      var diceBag = new DiceBag(new RandomNumberGenerator());
      Console.WriteLine(diceBag.Roll(input).Total);
      Console.WriteLine(diceBag.Roll(input).Total);
      Console.WriteLine(diceBag.Roll(input).Total);
      Console.WriteLine(diceBag.Roll(input).Total);
      Console.WriteLine(diceBag.Roll(input).Total);
      Console.WriteLine(diceBag.Roll(input).Total);
      Console.WriteLine(diceBag.Roll(input).Total);
      Console.WriteLine(diceBag.Roll(input).Total);
      Console.WriteLine(diceBag.Roll(input).Total);
      Console.WriteLine(diceBag.Roll(input).Total);

      Console.WriteLine();
    }
  }
}