using System;
using System.ServiceModel;

namespace Services.Lesson_2.Service
{
    public class Program
    {
        public static void Main()
        {
            var host = new ServiceHost(typeof(Library), new Uri("http://localhost:8080/library"));
            //передаем реализацию сервиса и базовый адрес

            host.Open();

            Console.WriteLine("Press enter...");
            Console.ReadLine();

            host.Close();
        }
    }
}


