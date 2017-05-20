using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Services.Lesson_6.Models;

namespace Services.Lesson_6.Warehouse
{
    public class BooksWh
    {
        public readonly List<BookModel> Books = new List<BookModel>
            {
                new BookModel{Id = 0, Author = "Rouling", Title = "GP", Year = 2001, Type = BookType.Fiction},
                new BookModel{Id = 1, Author = "Tolkin", Title = "The Hobbit", Year = 1980, Type = BookType.Fiction},
                new BookModel{Id = 2, Author = "Barrouz-Willer", Title = "Probability", Year = 1960, Type = BookType.Journal}
            };

        public void AddBook(BookModel book)
        {
            Books.Add(book);
        }

        public object GetById(int id)
        {
            var bookModel = Books.Find(i => i.Id == id);
            return bookModel;
        }

        public List<BookModel> GetByAuthor(string author)
        {
            var authorModel = Books.FindAll(i => i.Author.Equals(author));
            return new List<BookModel>();
        }

        public void Delete(int id)
        {
            var book = Books.Find(i => i.Id == id);
            Books.Remove(book);
        }

    }
}
