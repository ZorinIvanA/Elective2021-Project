using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using WebApplication1.Reposiotry;

namespace WebApplication1.Controllers
{
    [Route("api/books")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            BooksRepository repository = new BooksRepository();
            return Ok(repository.GetBooks());
        }

        [HttpGet("{bookId}")]
        public IActionResult Get(int bookId)
        {
            using (SqlConnection connection = new SqlConnection("Server=zorin;database=Books;Trusted_Connection=True;"))
            {
                BooksRepository repository = new BooksRepository();
                var book = repository.GetBookById(bookId);
                if (book != null)
                    return Ok(book);
                else
                    return NoContent();
            }
        }


        [HttpPut]
        public IActionResult Put([FromBody] Book book)
        {
            BooksRepository repository = new BooksRepository();
            if (book.Id.HasValue)
            {
                //Изменение существующей записи
                repository.Update(book);
                return Ok();
            }
            else
            {
                //Добавление записи
                repository.Insert(book);
                return StatusCode(201);
            }
        }

        [HttpDelete("{bookId}")]
        public IActionResult Delete(int bookId)
        {
            BooksRepository repository = new BooksRepository();
            repository.Delete(bookId);
            return Ok();
        }
    }
}

