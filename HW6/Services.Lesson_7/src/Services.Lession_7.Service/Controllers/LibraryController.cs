using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Services.Lesson_6.Models;
using Services.Lesson_6.Warehouse;

namespace Services.Lession_7.Service.Controllers
{
    [ApiVersion("0.9")]
    [ApiVersion("1.0")]
    [ApiVersion("2.0")]
    [Route("library")]
    public class LibraryController : Controller
    {
        protected static readonly BooksWh BooksWarehause = new BooksWh();
        protected static readonly EntryWh EntryWarehause = new EntryWh();

    }

    [ApiVersion("0.9")]
    [Route("library/v{version:apiVersion}")]
    public class LibraryControllerV09 : LibraryController
    {
        [HttpGet("/books")]
        //получили список всех книг в библиотеке
        public IEnumerable<BookModel> GetAllBooks()
        {
            return BooksWarehause.Books;
        }

        // GET library/books/2
        // получили описание книги по ее id
        [HttpGet("/books/{id}")]
        public object GetBook(int id)
        {
            var book = BooksWarehause.GetById(id);
            return book ?? new StatusCodeResult(404);
        }

        // GET library/books/author/year
        // получили описание книги у автора за конкретный год
        [HttpGet("/books/{author}/{year}")]
        public object GetBookByAuthorWithTitle(string author, int year)
        {
            var booksByAuther = BooksWarehause.GetByAuthor(author);
            if (booksByAuther != null)
            {
                var books = booksByAuther.FindAll(i => i.Year == year);
                return (object)books ?? new StatusCodeResult(404);
            }
            else
            {
                return new StatusCodeResult(404);

            }
        }

        // POST library/books
        //Отдать новую книжку библиотеке
        [HttpPost("/books")]
        public void AddNewBook([FromBody]BookModel book)
        {
            BooksWarehause.AddBook(book);
        }

        [HttpDelete("/entry/{book}/{person}")]
        //вернуть книгу, по факту удалить запись о том, что брал ее
        public ActionResult ReturnBook(int idBook, int idPerson)
        {

            var entry = EntryWarehause._entries.Find(i => i.IdBook == idBook && i.IdPerson == idPerson);
            if (entry != null)
            {
                EntryWarehause.ReturnBook(idBook, idPerson);
                return new OkObjectResult("Returned");
            }

            return new NotFoundObjectResult("Not found");
        }

        [HttpGet("/entry/{book}/{person}")]
        //взять книгу, по факту добавить запись о том, что взял ее
        public ActionResult GiveBookV09(int idBook, int idPerson)
        {
            var response = EntryWarehause.GiveBook(idBook, idPerson);
            if (response.Equals("Ok"))
            {
                return new OkObjectResult("Ok");
            }
            else
            {
                return new JsonResult(response);
            }
        }
    }

    [ApiVersion("1.0")]
    [ApiVersion("2.0")]
    [Route("library/v{version:apiVersion}/")]
    public class LibraryControllerV10V20 : LibraryControllerV09
    {
        [HttpGet("/entry/{book}/{person}")]
        //взять книгу, по факту добавить запись о том, что взял ее
        public ActionResult GiveBookV10(int idBook, int idPerson)
        {
            var response = EntryWarehause.GiveBook(idBook, idPerson);
            if (response.Equals("Ok"))
            {
                return new OkObjectResult("Ok");
            }
            else
            {
                //в этой версии изменился тип возвращаемой ошибки
                return new BadRequestObjectResult(response);
            }
        }

        [HttpGet("{id}"), MapToApiVersion("2.0")]
        public string GetDatav2(int id)
        {
            return "Id for v2: " + id;
        }

        [HttpDelete("/entry/{book}/{person}"), MapToApiVersion("2.0")]
        //вернуть книгу, по факту удалить запись о том, что брал ее
        public ActionResult ReturnBookV20(int idBook, int idPerson)
        {
            var entry = EntryWarehause._entries.Find(i => i.IdBook == idBook && i.IdPerson == idPerson);
            if (entry != null)
            {
                EntryWarehause.ReturnBook(idBook, idPerson);
                //в этой версиипоменялось сообщение
                return new OkObjectResult("Ok. Please, Come again!");
            }

            return new NotFoundObjectResult("Not found");
        }

    }
}
