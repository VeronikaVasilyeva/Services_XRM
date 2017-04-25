using System;
using Services.Lesson_2.Client.ServiceReference1;

namespace Services.Lesson_2.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            var client = new LibraryClient();

            client.AddBook(new Book {   Id = 10, Title = "Harry Potter10",
                                        Author = "J.Rouling",
                                        Year = 2000,
                                        Type = BookType.Fiction });

            Book book = client.GetBookById(0);

            Book[] books = client.GetBooksByAuthor("J.Rouling");

            Book takenBook = client.GiveBook(0, 0);

            client.ReturnBook(0, 0);

            Console.Write("I'am client of Library");
            Console.ReadLine();
        }
    }
}