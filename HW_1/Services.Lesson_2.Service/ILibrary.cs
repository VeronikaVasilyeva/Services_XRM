using System;
using System.Collections.Generic;
using System.ServiceModel;

namespace Services.Lesson_2.Service
{
    [ServiceContract]
    public interface ILibrary
    {
        [OperationContract]
        void AddBook(Book book);

        [OperationContract]
        Book GetBookById(int id);

        [OperationContract]
        List<Book> GetBooksByAuthor(string author);

        [OperationContract]
        Book GiveBook(Int32 idBook, int idPerson);

        [OperationContract]
        void ReturnBook(int idBook, int idPerson);

    }
}
