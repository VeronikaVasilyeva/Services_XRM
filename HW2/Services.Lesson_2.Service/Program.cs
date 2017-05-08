using System;
using System.ServiceModel;

namespace Services.Lesson_3.Service
{
    public class Program
    {
        public static void Main()
        {
            var host = new ServiceHost(typeof(LibraryFacade));

            host.Open();

            Console.WriteLine("Press enter...");
            Console.ReadLine();

            host.Close();
        }
    }
}