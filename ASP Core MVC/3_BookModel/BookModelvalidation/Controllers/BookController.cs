using Microsoft.AspNetCore.Mvc;
using BookModelvalidation.Models;

namespace BookModelvalidation.Controllers
{
    [Route("Book")]
    public class BookController : Controller
    {
        public static List<Book> books = new List<Book>
        {
            new Book { Isbn = 1, BookName = "C# Programming", AuthorName = "John Doe", PublishedDate = new DateTime(2020, 1, 1), BookUrl = "http://example.com/csharp" },
            new Book { Isbn = 2, BookName = "ASP.NET Core", AuthorName = "Jane Smith", PublishedDate = new DateTime(2021, 5, 15), BookUrl = "http://example.com/aspnetcore" }
        };

        [Route("/")]
        [Route("List",Name = "List")]
        public IActionResult BookList()
        {
            return View(books);
        }

        [Route("AddBook",Name = "AddBook")]

        public IActionResult AddBook()
        {
            return View();
        }

        [Route("SaveBook", Name = "SaveBook")]

        public IActionResult AddBook(Book book)
        {
            if (ModelState.IsValid)
            {
                books.Add(book);
                return RedirectToRoute("List");
            }
            else
            {
                return View("AddBook", book);
            }
        }
    }
}
