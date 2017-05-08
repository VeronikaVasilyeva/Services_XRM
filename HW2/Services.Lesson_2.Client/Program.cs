using System;
using System.Collections.Generic;
using Services.Lesson_3.Client.ServiceReference1;

namespace Services.Lesson_3.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            var client = new LibraryClient();

            client.IntroduceYourself(5, "Вася");

            List<int> arr = new List<int>{ 1, 2, 3 };
            client.ChooseNewBooks(arr);

            client.HandOverBooks(new List<int>{ 2, 3 });

            client.ChooseNewBooks(arr);

            client.ApplayChanges();

            client.GoAway();


            Console.ReadKey();
        }
    }
}