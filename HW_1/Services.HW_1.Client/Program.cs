using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Services.HW_1.Client.LibraryServiceClient;

namespace Services.HW_1.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            var client = new LibraryClient();

            client.AddBook(new Book { Id = 10, Title = "Harry Potter10", Author = "J.Rouling", Year = 2000, Type = BookType.Fiction });

            Book book = client.GetBookById(0);

            Book[] books = client.GetBooksByAuthor("J.Rouling");

            Book takenBook = client.GiveBook(0, 0);

            client.ReturnBook(0, 0);

            Console.Write("I'am client of Library");
            Console.ReadLine();
        }
    }
}
