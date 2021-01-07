using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Day20
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
            var ranges = data.Where(s => s != "").OrderBy(i => long.Parse(i.Split("-")[0])).Select(r => new Tuple<long, long>(long.Parse(r.Split("-")[0]), long.Parse(r.Split("-")[1]))).ToList();
            ranges = Merge(ranges).ToList();
            long end = -1;
            long ip = -1;
            foreach (var (item1, item2) in ranges)
            {
                if (end == -1)
                {
                    end = item2;
                    continue;
                }

                if (item1 > end + 1)
                {
                    ip = end + 1;
                    break;
                }

                end = item2;
            }
            Console.WriteLine("First ip = " + ip);
        }

        private static void SolvePart2()
        {
            var input = File.ReadAllText("Input.txt");
            var data = input.Split('\n').ToList();
            var ranges = data.Where(s => s != "").OrderBy(i => long.Parse(i.Split("-")[0])).Select(r => new Tuple<long, long>(long.Parse(r.Split("-")[0]), long.Parse(r.Split("-")[1]))).ToList();
            ranges = Merge(ranges).ToList();
            long end = -1;
            long count = 0;
            foreach (var (item1, item2) in ranges)
            {
                if (end == -1)
                {
                    end = item2;
                    continue;
                }

                if (item1 > end + 1)
                {
                    count += item1 - end - 1;
                }

                end = item2;
            }

            count += 4294967295 - end;
            Console.WriteLine("Count of valid ips = " + count);
        }

        // Function from here: https://stackoverflow.com/a/29096584
        public static IEnumerable<Tuple<long, long>> Merge(IEnumerable<Tuple<long, long>> ranges)
        {
            using var enumerator = ranges.OrderBy(r => r.Item1).GetEnumerator();
            var recordsRemain = enumerator.MoveNext();
            while (recordsRemain)
            {
                var extentStart = enumerator.Current.Item1;
                var extentEnd = enumerator.Current.Item2;
                while ((recordsRemain = enumerator.MoveNext()) && enumerator.Current.Item1 < extentEnd)
                {
                    if (enumerator.Current.Item2 > extentEnd)
                    {
                        extentEnd = enumerator.Current.Item2;
                    }
                }
                yield return Tuple.Create(extentStart, extentEnd);
            }
        }
    }
}
