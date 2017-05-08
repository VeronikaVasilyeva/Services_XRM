using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FileWriteClient.FileWriterServiceRef;
using System.Threading;

namespace FileWriteClient
{
    class Program
    {
        private static readonly int _anountTreads = 10;

        static void Main(string[] args)
        {
            for (int x = 0; x < _anountTreads; x++)
            {
                int y = x;
                Task.Run(() => CreateClient(y));
            }

            Console.ReadKey();
        }

        static void CreateClient(int pid)
        {
            var client = new FileWriterServiceRef.ServiceClient();

            client.WriteToFile(pid, string.Join(pid.ToString(), new string[64]));
        }
    }

}