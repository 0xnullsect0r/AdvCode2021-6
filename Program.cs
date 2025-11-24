using System;
using System.Collections.Generic;
using System.Linq;

namespace AdvCode2021_6
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Paste your puzzle input here:");
            var line = Console.ReadLine();

            var fish = new List<int>();
            if (!string.IsNullOrWhiteSpace(line))
            {
                var tokens = line.Split(',', StringSplitOptions.RemoveEmptyEntries);
                foreach (var t in tokens)
                {
                    if (int.TryParse(t.Trim(), out var value))
                        fish.Add(value);
                    else
                        Console.WriteLine($"Warning: could not parse '{t}'");
                }
            }

            var counts = new long[9];
            foreach (var f in fish)
            {
                if (f >= 0 && f <= 8)
                    counts[f]++;
            }

            for (int day = 0; day < 256; day++)
            {
                long zeros = counts[0];
                for (int t = 0; t < 8; t++)
                    counts[t] = counts[t + 1];
                counts[6] += zeros;
                counts[8] = zeros;
            }

            Console.WriteLine($"After 256 days: {counts.Sum()}");
        }
    }
}