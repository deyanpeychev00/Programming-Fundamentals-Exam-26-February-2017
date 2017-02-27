using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;


namespace _04.Hornet_Armada
{
    public class HornetArmada
    {
        public static void Main()
        {
            var n = int.Parse(Console.ReadLine());
            var matchRegex = new Regex(@"(?<lastActivity>\d+)\s+=\s+(?<legionName>[^\=\-\>\:\ ]+)\s+->\s+(?<soliderType>[^\=\-\>\:\ ]+):(?<soliderCount>\d+)");
            var legionWithSoliders = new Dictionary<string, Dictionary<string, long>>();
            var legionWithActivity = new Dictionary<string, long>();
            for (int i = 0; i < n; i++)
            {
                var line = Console.ReadLine();
                var matches = matchRegex.Match(line);
                var legionName = new string(matches.Groups["legionName"].Value.ToArray());
                var lastActivity = long.Parse(matches.Groups["lastActivity"].Value);
                var soliderType = new string(matches.Groups["soliderType"].Value.ToArray());
                var soliderCount = long.Parse(matches.Groups["soliderCount"].Value);

                if (!legionWithActivity.ContainsKey(legionName))
                {
                    legionWithActivity.Add(legionName, lastActivity);
                    legionWithSoliders.Add(legionName, new Dictionary<string, long>());
                }
                legionWithActivity[legionName] = Math.Max(legionWithActivity[legionName], lastActivity);
                if (!legionWithSoliders[legionName].ContainsKey(soliderType))
                {
                    legionWithSoliders[legionName].Add(soliderType, soliderCount);
                }
                else
                {
                    legionWithSoliders[legionName][soliderType] += soliderCount;
                }
            }
            var filter = Console.ReadLine().Split('\\');
            if (filter.Length > 1)
            {
                var lastActivityFilter = long.Parse(filter[0]);
                var soliderTypeFilter = filter[1];
                foreach (var legionName in legionWithSoliders
                    .Where(legion => legion.Value.ContainsKey(soliderTypeFilter))
                    .OrderByDescending(legion => legion.Value[soliderTypeFilter]))
                {
                    if (legionWithActivity[legionName.Key] < lastActivityFilter)
                    {
                        Console.WriteLine($"{legionName.Key} -> {legionName.Value[soliderTypeFilter]}");
                    }
                }
            }
            else
            {
                var resultDictionary = new Dictionary<string, long>();
                var soliderTypeFilter = filter[0];
                foreach (var legionName in legionWithSoliders
                    .Where(legion => legion.Value.ContainsKey(soliderTypeFilter))
                    .OrderByDescending(legion => legion.Value[soliderTypeFilter]))
                {
                    resultDictionary.Add(legionName.Key, legionWithActivity[legionName.Key]);
                }
                foreach (var kvp in resultDictionary.OrderByDescending(value => value.Value))
                {
                    Console.WriteLine($"{kvp.Value} : {kvp.Key}");
                }
            }
        }
    }
}
