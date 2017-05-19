using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Web;

namespace FileWriterService
{
    public class Program
    {
        public static void Main()
        {
            var srv = new FileWriterService();
            srv.InitializeCollections();
            var host = new ServiceHost(srv);

            host.Open();

            Console.WriteLine("Press enter...");
            Console.ReadLine();

            host.Close();
        }
    }
}