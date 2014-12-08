namespace ColoredConsolePlayground
{
    using ColoredConsole;
    using System;
    using System.Linq;

    class Program
    {
        static void Main(string[] args)
        {
            ColorConsole.Write();
            ColorConsole.WriteLine(null);
            ColorConsole.WriteLine("It's so easy to add some ", "color".Magenta(), " to your console.");
            ColorConsole.Write(null);
            ColorConsole.WriteLine();

            ColorConsole.WriteLine("You can use all these ", "colors".Color((ConsoleColor)new Random().Next(1, 14)), ".");
            foreach (var color in Enum.GetValues(typeof(ConsoleColor)).Cast<ConsoleColor>())
            {
                ColorConsole.WriteLine(color.ToString().Color(color), "  ", ("On " + color.ToString()).White().On(color));
            }

            ColorConsole.WriteLine();
            var colorToken = new ColorToken("I'm a ColorToken, change me when you want :)", ConsoleColor.White, ConsoleColor.Blue);
            ColorConsole.WriteLine(colorToken);
            ColorConsole.WriteLine(colorToken.Cyan().OnDarkYellow());
            ColorConsole.WriteLine();

            ColorConsole.WriteLine(new[] { "You can even use ", "masking".Magenta(), "." }.Coalesce(ConsoleColor.DarkYellow, null));
            ColorConsole.WriteLine(new[] { "You can even use ", "masking".Magenta(), "." }.Coalesce(ConsoleColor.DarkYellow));
            ColorConsole.WriteLine(new[] { "You can even use ", "masking".Magenta(), "." }.Coalesce(null, null));
            ColorConsole.WriteLine(new[] { "You can even use ", "masking".Magenta(), "." }.Coalesce(null, ConsoleColor.DarkYellow));
            ColorConsole.WriteLine(new[] { "You can even use ", "masking".Magenta().OnYellow(), "." }.Coalesce(null, ConsoleColor.DarkYellow));
            ColorConsole.WriteLine(new[] { "You can even use ", "masking".Magenta().OnYellow(), "." }.Coalesce(ConsoleColor.Black, ConsoleColor.DarkYellow));

            ColorToken[] noTokens = null;
            // watch as I do nothing
            ColorConsole.WriteLine(new[] { new ColorToken(), null }.Coalesce(null, null));
            ColorConsole.WriteLine(noTokens.Coalesce(ConsoleColor.Red));

            var lines = System.IO.File.ReadAllLines(System.IO.Path.Combine(System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location), "kiwi.txt"));
            Array.ForEach(
                lines,
                line => ColorConsole.Write(line.DarkRed().OnDarkGreen(), " ".PadRight(Console.WindowWidth - line.Length).OnDarkGreen()));
        }
    }
}
