using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Configuration;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TokenSimulation
{
    internal class Program
    {
        static void Main()
        {
            var computers = InitializeComputers();
            PrintComputers(computers);
            Console.WriteLine("Press any key to start simulation");
            Console.ReadKey();
            Console.WriteLine();
            RunSimulation(computers);
        }

        private static Computer[] InitializeComputers()
        {
            var computers = new Computer[10];

            var ips = new HashSet<string>();
            for (var i = 0; i < computers.Length; i++)
            {
                computers[i] = new Computer();
                var random = new Random();
                var ip = random.Next(0, 256) + "." + random.Next(0, 256) + "." + random.Next(0, 256) + "." +
                         random.Next(0, 256);
                while (ips.Contains(ip))
                {
                    ip = random.Next(0, 256) + "." + random.Next(0, 256) + "." + random.Next(0, 256) + "." +
                         random.Next(0, 256);
                }
                ips.Add(ip);
                computers[i].Ip = ip;
            }

            return computers;
        }

        private static void PrintComputers(Computer[] computers)
        {
            for (var i = 0; i < computers.Length; i++)
            {
                Console.WriteLine($"C{i} = {computers[i]}.");
            }
        }

        private static void RunSimulation(Computer[] computers)
        {
            Random random = new Random();
            var IndexSource = random.Next(0, 10);
            var IpSource = computers[IndexSource].Ip;
            Console.WriteLine($"Computer Source: {IndexSource}");

            var IndexDestination = random.Next(0, 10);
            while(IndexDestination==IndexSource)
            {
                IndexDestination = random.Next(0, 10);
            }
            var IpDestination = computers[IndexDestination].Ip;
            Console.WriteLine($"Computer Destination: {IndexDestination}");
            Console.Write("Insert Message: ");
            var message = Console.ReadLine();


           var currentIndex = IndexSource;
            for(int i=0;i<10;i++)
            {
                
                    computers[currentIndex].LocalToken = new Token
                    {
                        Message = message,
                        IsFree = false,
                        HasArrivedToDestination = false,
                        IPDestination = IpDestination,
                        IPSource = IpSource
                    };
                
                SendToken(computers, message, currentIndex, computers[currentIndex].LocalToken);
                currentIndex = IndexSource;

                Console.WriteLine();
                PrintComputers(computers);
              
                IndexSource = random.Next(0, 10);
                IpSource = computers[IndexSource].Ip;
                Console.WriteLine($"Computer Source: {IndexSource}");
                IndexDestination = random.Next(0, 10);
                while (IndexDestination == IndexSource)
                {
                    IndexDestination = random.Next(0, 10);
                }
                IpDestination = computers[IndexDestination].Ip;
                Console.WriteLine($"Computer Destination: {IndexDestination}");
                Console.Write("Insert Message: ");
                message = Console.ReadLine();
            }
        }

        private static void SendToken(Computer[] computers, string message, int currentIndex, Token token)
        {
            bool hasBeenSent= false;
            while(true)
            {
                if (computers[currentIndex].Ip == token.IPSource)
                { 
                    hasBeenSent= true;
                    if(token.HasArrivedToDestination)
                    {
                        Console.WriteLine($"C{currentIndex}: Am primit tokenul inapoi");
                        token.IsFree = true;
                        break;
                    }
                    else
                    {
                        Console.WriteLine($"C{currentIndex}: Am preluat jetonul");
                        
                    }
                }
                if (computers[currentIndex].Ip == token.IPDestination && hasBeenSent)
                {
                    Console.WriteLine($"C{currentIndex}: Am ajuns la destinatie");
                    computers[currentIndex].Message = token.Message;
                    token.HasArrivedToDestination = true;
                }

                computers[currentIndex].LocalToken = null;
                Console.WriteLine($"C{currentIndex}: Trimite tokenul");
                currentIndex = (currentIndex + 1) % computers.Length;
                computers[currentIndex].LocalToken = token;
                Thread.Sleep(500);
            }
        }
    }
}
