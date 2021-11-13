using Microsoft.AspNetCore.Mvc;
using WebApplication1.Application;
using WebApplication1.Domain;

namespace WebApplication1.Controllers
{
    [Route("api/books")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        IBooksRepository _booksRepository;

        public BooksController(IBooksRepository repository)
        {
            _booksRepository = repository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_booksRepository.GetBooks());
        }

        [HttpGet("{bookId}")]
        public IActionResult Get(int bookId)
        {
            var book = _booksRepository.GetBookById(bookId);
            if (book != null)
                return Ok(book);
            else
                return NoContent();
        }


        [HttpPut]
        public IActionResult Put([FromBody] Book book)
        {
            if (book.Id.HasValue)
            {
                //Изменение существующей записи
                _booksRepository.Update(book);
                return Ok();
            }
            else
            {
                //Добавление записи
                _booksRepository.Insert(book);
                return StatusCode(201);
            }
        }

        [HttpDelete("{bookId}")]
        public IActionResult Delete(int bookId)
        {
            _booksRepository.Delete(bookId);
            return Ok();
        }

        [HttpPost]
        public IActionResult TakeBook(TakeBookModel model)
        {
            var book = new Book(model.Book, _booksRepository);
            book.Take(model.User);

            return Ok();
        }
    }
}

