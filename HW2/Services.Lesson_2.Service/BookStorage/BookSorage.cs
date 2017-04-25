using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Services.Lesson_2.Service
{
    public class BooksStorage
    {
        private static List<Book> _books;

        public BooksStorage()
        {
            if (_books == null)
            {
                _books = new List<Book>();

                _books.Add(new Book { Id = 0, Title = "Harry Potter1", Author = "J.Rouling", Year = 2000, Type = BookType.Fiction });
                _books.Add(new Book { Id = 1, Title = "Harry Potter2", Author = "J.Rouling", Year = 2001, Type = BookType.Fiction });
                _books.Add(new Book { Id = 2, Title = "Harry Potter3", Author = "J.Rouling", Year = 2003, Type = BookType.Fiction });
                _books.Add(new Book { Id = 3, Title = "A National Geografic Journal", Author = "Author1", Year = 2017, Type = BookType.Journal });
                _books.Add(new Book { Id = 4, Title = "The Sleeping Beauty", Author = "Author2", Year = 1800, Type = BookType.Fiction });
                _books.Add(new Book { Id = 5, Title = "The IELTS English book", Author = "Author3", Year = 2005, Type = BookType.Textbook });
            }
        }

        public Book GetById(int id)
        {
            Console.WriteLine("Get");
            return _books.First(i => i.Id == id);
        }

        public List<Book> GetByAuthor(string author)
        {
            Console.WriteLine("GetAll");
            return _books.Where(i => i.Author.Equals(author)).ToList();
        }

        public void Add(Book book)
        {
            Console.WriteLine("Add");
            _books.Add(book);
        }
    }
}