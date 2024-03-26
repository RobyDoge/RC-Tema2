using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Configuration;
using System.Text;
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
                Console.WriteLine($"C{i} = {computers[i]};");
            }
        }

        private static void RunSimulation(Computer[] computers)
        {
            Console.Write("Insert Computer Source: ");
            var source = int.Parse(Console.ReadLine());
            Console.Write("Insert Computer Destination: ");
            var destination = int.Parse(Console.ReadLine());
            Console.Write("Insert Message: ");
            var message = Console.ReadLine();


        }

    }
}
