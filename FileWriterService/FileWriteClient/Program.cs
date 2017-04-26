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
        static void Main(string[] args)
        {
            Thread thread1 = new Thread(new ThreadStart(createClient));
            Thread thread2 = new Thread(new ThreadStart(createClient));
            thread1.Start();
            thread2.Start();
            thread1.Join();
            thread2.Join();


            Console.Write("the end");
            Console.ReadKey();
        }

        static void createClient()
        {
            var client = new FileWriterServiceRef.ServiceClient();
            client.WriteToFile(10, "bla");
        }
    }
}
