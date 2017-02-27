using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace _02.Hornet_Comm
{
    public class HornetComm
    {
        public static void Main()
        {

            var line = Console.ReadLine();
            var broadcastRegex = new Regex(@"(?<firstQuery>^\D+)\s<->\s((?<secondQuery>[a-zA-Z0-9]+|[0-9]+)$)");
            var privateMessageRegex = new Regex(@"(?<firstQuery>^\d+)\s<->\s((?<secondQuery>[a-zA-Z0-9]+|[0-9]+)$)");
            var privatesList = new List<string>();
            var broadcastList = new List<string>();
            while (line != "Hornet is Green")
            {
                var broadcastMatches = broadcastRegex.Match(line);
                var privateMessageMatches = privateMessageRegex.Match(line);
                if (broadcastMatches.Success)
                {
                    var broadcastMessage = broadcastMatches.Groups["firstQuery"].Value;
                    var broadcastFrequency = broadcastMatches.Groups["secondQuery"].Value;
                    var newFrequency = "";
                    foreach (var letter in broadcastFrequency.ToCharArray())
                    {
                        if (char.IsLower(letter))
                        {
                            newFrequency += (char)(letter - (char)32);
                        }
                        else if (char.IsUpper(letter))
                        {
                            newFrequency += (char)(letter + (char)32);
                        }
                        else
                        {
                            newFrequency += letter;
                        }
                    }
                    var broadcastResult = newFrequency + " -> " + broadcastMessage;
                    broadcastList.Add(broadcastResult);
                }
                if (privateMessageMatches.Success)
                {
                    var recipientsCode = privateMessageMatches.Groups["firstQuery"].Value;
                    var privateMessage = privateMessageMatches.Groups["secondQuery"].Value;
                    var code = new string(recipientsCode.Reverse().ToArray());
                    var privateResult = code + " -> " + privateMessage;
                    privatesList.Add(privateResult);
                }
                line = Console.ReadLine();
            }
            Console.WriteLine("Broadcasts:");
            if (broadcastList.Any())
            {
                foreach (var message in broadcastList)
                {
                    Console.WriteLine(message);
                }
            }
            else
            {
                Console.WriteLine("None");
            }
            Console.WriteLine("Messages:");
            if (privatesList.Any())
            {
                foreach (var message in privatesList)
                {
                    Console.WriteLine(message);
                }
            }
            else
            {
                Console.WriteLine("None");
            }
        }
    }
}
