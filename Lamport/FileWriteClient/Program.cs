using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FileWriteClient.ServiceReference1;
using System.Threading;

namespace FileWriteClient
{
    class Program
    {
        private static readonly int _anountTreads = 40;

        public static void Main(string[] args)
        {
            for (var x = 0; x < _anountTreads; x++)
            {
                var y = x;
                Task.Run(() => CreateClient(y));
            }

            Console.ReadKey();
        }

        private static void CreateClient(int pid)
        {
            var client = new ServiceClient();
            client.WriteToFile(pid, string.Join(pid.ToString(), new string[15]));
        }
    }
}