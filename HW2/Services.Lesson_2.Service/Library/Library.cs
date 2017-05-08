using System;
using System.Collections.Generic;
using Services.Lesson_3.Service.Library.BookStorage;
using Services.Lesson_3.Service.Library.InformationStorage;

namespace Services.Lesson_3.Service.Library
{
    public class Library
    {
        private InformationStorage.InformationStorage infoStorage = new InformationStorage.InformationStorage();
        private BooksStorage bookStorage = new BooksStorage();

        public void AddBookToStorage(Book book)
        {
            bookStorage.Add(book);
        }

        public Book GetBookById(int id)
        {
            return bookStorage.GetById(id);
        }

        public List<Book> GetBooksByAuthor(string author)
        {
            return bookStorage.GetByAuthor(author);
        }

        public Book GiveBook(int idBook, int idPerson)
        {
            var book = bookStorage.GetById(idBook);
            var person = new Person {Id = idPerson};
            infoStorage.AddEntry(book, person);

            return book;
        }

        public void ReturnBook(int idBook, int idPerson)
        {
            var book = bookStorage.GetById(idBook);
            var person = new Person {Id = idPerson};
            infoStorage.RemoveEntry(book, person);
        }
    }
}