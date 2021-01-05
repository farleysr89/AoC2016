using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Day10
{
    internal class Program
    {
        private static void Main()
        {
            SolvePart1();
            SolvePart2();
        }

        private static void SolvePart1()
        {
            var input = File.ReadAllText("Input.txt");
            var data = input.Split('\n').ToList();
            data = data.OrderByDescending(x => x).ToList();
            var tmpData = new List<string>(data);
            var bots = new List<Bot>();
            foreach (var s in tmpData.Where(x => x.StartsWith('v')))
            {
                var parts = s.Split(" ");
                var value = int.Parse(parts[1]);
                var bot = int.Parse(parts[5]);
                if (bots.All(x => x.id != bot))
                {
                    bots.Add(new Bot { id = bot });
                }
                bots.First(x => x.id == bot).chips.Add(value);
                data.Remove(s);
            }

            var outputs = new List<Output>();
            var outBot = 0;
            while (tmpData.Any())
            {
                foreach (var s in tmpData)
                {
                    if (s == "")
                    {
                        data.Remove(s);
                        continue;
                    }
                    int bot2 = -1, bot3 = -1, output1 = -1, output2 = -1;
                    var parts = s.Split(" ");
                    var bot1 = int.Parse(parts[1]);
                    if (!bots.Any(b => b.id == bot1 && b.chips.Count > 1)) continue;

                    switch (parts[5])
                    {
                        case "bot":
                            bot2 = int.Parse(parts[6]);
                            break;
                        case "output":
                            output1 = int.Parse(parts[6]);
                            break;
                        default:
                            Console.WriteLine("Something Broke!");
                            break;
                    }

                    switch (parts[10])
                    {
                        case "bot":
                            bot3 = int.Parse(parts[11]);
                            break;
                        case "output":
                            output2 = int.Parse(parts[11]);
                            break;
                        default:
                            Console.WriteLine("Something Broke!");
                            break;
                    }

                    var bot = bots.First(b => b.id == bot1);
                    if (bot.chips.Contains(61) && bot.chips.Contains(17)) outBot = bot1;
                    if (bot2 != -1)
                    {
                        if (bots.All(b => b.id != bot2))
                            bots.Add(new Bot { id = bot2 });
                        bots.First(b => b.id == bot2).chips.Add(bot.chips.Min());
                    }
                    else if (output1 != -1) outputs.Add(new Output() { id = output1, value = bot.chips.Min() });
                    else Console.WriteLine("Something Broke!");
                    if (bot3 != -1)
                    {
                        if (bots.All(b => b.id != bot3))
                            bots.Add(new Bot { id = bot3 });
                        bots.First(b => b.id == bot3).chips.Add(bot.chips.Max());
                    }
                    else if (output2 != -1) outputs.Add(new Output() { id = output2, value = bot.chips.Max() });
                    else Console.WriteLine("Something Broke!");
                    bot.chips = new List<int>();
                    data.Remove(s);
                }
                tmpData = new List<string>(data);
            }
            Console.WriteLine("Bot id is " + outBot);
        }

        private static void SolvePart2()
        {
            var input = File.ReadAllText("Input.txt");
            var data = input.Split('\n').ToList();
            Console.WriteLine("");
        }
    }
    public class Bot
    {
        public int id;
        public List<int> chips = new List<int>();
    }

    public class Output
    {
        public int id;
        public int value;
    }
}
