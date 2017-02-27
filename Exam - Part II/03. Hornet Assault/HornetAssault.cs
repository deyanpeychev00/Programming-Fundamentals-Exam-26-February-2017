using System;
using System.Linq;

namespace _03.Hornet_Assault
{
    public class HornetAssault
    {
        public static void Main()
        {
            var beeHives = Console.ReadLine().Trim().Split().Select(long.Parse).ToList();
            var hornets = Console.ReadLine().Trim().Split().Select(long.Parse).ToList();
            var result = beeHives;
            for (int i = 0; i < beeHives.Count; i++)
            {
                var hornetsPower = hornets.Sum();
                if (beeHives[i] < hornetsPower)
                {
                    result[i] = 0;
                }
                else if (beeHives[i] >= hornetsPower)
                {
                    result[i] = result[i] - hornetsPower;
                    if (hornets.Any())
                    {
                        hornets.RemoveAt(0);
                    }
                    else
                    {
                        break;
                    }
                }
            }
            var final = result.Where(val => val != 0);
            if (final.Any())
            {
                Console.WriteLine(string.Join(" ", final));
            }
            else if (hornets.Any())
            {
                Console.WriteLine(string.Join(" ", hornets));
            }
        }
    }
}
