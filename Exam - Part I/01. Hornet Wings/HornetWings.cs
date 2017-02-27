using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.Hornet_Wings
{
    public class HornetWings
    {
        public static void Main()
        {
            var wingFlaps = long.Parse(Console.ReadLine());
            var distanceForThousandWingFlaps = double.Parse(Console.ReadLine());
            var enduranceOfContestant = long.Parse(Console.ReadLine());

            double distance = (wingFlaps / 1000) * distanceForThousandWingFlaps;
            var seconds = wingFlaps / 100;
            var restSeconds = (wingFlaps / enduranceOfContestant) * 5;
            var finalSeconds = seconds + restSeconds;

            Console.WriteLine($"{distance:f2} m.");
            Console.WriteLine($"{finalSeconds} s.");
        }
    }
}
