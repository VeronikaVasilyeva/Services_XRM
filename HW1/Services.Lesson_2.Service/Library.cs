using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Services.Lesson_2.Service
{
    public class Library : ILibrary
    {
        private InformationStorage infoStorage = new InformationStorage();
        private BooksStorage bookStorage = new BooksStorage();

        public void AddBook(Book book)
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
            var person = new Person();
            person.Id = idPerson;

            infoStorage.AddEntry(book, person);

            return book;
        }

        public void ReturnBook(int idBook, int idPerson)
        {
            var book = bookStorage.GetById(idBook);
            var person = new Person();
            person.Id = idPerson;

            infoStorage.RemoveEntry(book, person);
        }
    }
}
