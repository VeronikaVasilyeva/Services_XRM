using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Services.Lesson_6.Warehouse;
using Microsoft.AspNetCore.Session;
using Microsoft.Extensions.Caching.Memory;
using Services.Lesson_6.Models;

namespace Services.Lesson_6.Controllers
{ 
    [Route("api/[controller]")]
    public class LibraryController : Controller
    {
        private static readonly BooksWh BooksWarehause = new BooksWh();
        private static readonly EntryWh EntryWarehause = new EntryWh();


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
            return book ?? new StatusCodeResult(404) ;
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
                return (object) books ?? new StatusCodeResult(404);
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

            var entry = EntryWarehause._entries.Find(i => i.IdBook == idBook && i.IdPerson == idPerson );
            if (entry != null)
            {
                EntryWarehause.ReturnBook(idBook, idPerson);
                return new OkObjectResult("Returned");
            }

            return new NotFoundObjectResult("Not found");
        }

        [HttpGet("/entry/{book}/{person}")]
        //взять книгу, по факту добавить запись о том, что взял ее
        public ActionResult GiveBook(int idBook, int idPerson)
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
}
