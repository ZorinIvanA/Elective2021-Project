using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;
using WebApplication1.Application;
using WebApplication1.Domain;

namespace WebApplication1.Controllers
{
    [Route("api/books")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        IBooksRepository _booksRepository;
        ILogger<BooksController> _logger;
        IBookFactory _bookFactory;

        public BooksController(
            IBooksRepository repository,
            IBookFactory booksFactory,
            ILogger<BooksController> logger)
        {
            _booksRepository = repository;
            _logger = logger;
            _bookFactory = booksFactory ?? throw new ArgumentNullException(nameof(booksFactory));
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _booksRepository.GetBooks());
        }

        [HttpGet("{bookId}")]
        public async Task<IActionResult> Get(int bookId)
        {
            try
            {
                var book = await _booksRepository.GetBookById(bookId);

                if (book != null)
                    return Ok(book);
                else
                    return NoContent();

            }
            catch (Exception ex)
            {
                _logger.LogError("Ошибка", ex);
                return StatusCode(StatusCodes.Status500InternalServerError, "Ошибка");
            }
        }


        [HttpPut]
        public async Task<IActionResult> Put([FromBody] Book book)
        {
            if (book.Id.HasValue)
            {
                //Изменение существующей записи
                return await UpdateAsync(book);
            }
            else
            {
                //Добавление записи
                return await InsertAsync(book);
            }
        }

        private Task<IActionResult> UpdateAsync(Book book)
        {
            return Task.Run(() =>
            {
                _booksRepository.Update(book);
                return Ok() as IActionResult;
            });
        }

        private Task<IActionResult> InsertAsync(Book book)
        {
            return Task.Run(() =>
            {
                _booksRepository.Insert(book);
                return StatusCode(201) as IActionResult;
            });
        }

        [HttpDelete("{bookId}")]
        public async Task<IActionResult> Delete(int bookId)
        {
            await _booksRepository.Delete(bookId);
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> TakeBook(TakeBookModel model)
        {
            try
            {
                await _bookFactory.CreateBookAsync(model.Book)
                    .ContinueWith(previousTask => previousTask.Result.Take(model.User));

                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError("Ошибка", ex);
                return StatusCode(StatusCodes.Status500InternalServerError, "Ошибка");
            }
        }
    }
}

