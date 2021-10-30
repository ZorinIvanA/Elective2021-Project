using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;

namespace WebApplication1.Controllers
{
    [Route("api/books")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            using (SqlConnection connection = new SqlConnection("Server=zorin;database=Books;Trusted_Connection=True;"))
            {
                connection.Open();
                using (var command = new SqlCommand("SELECT * FROM books", connection))
                {
                    List<Book> books = new List<Book> { };
                    var reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Book newBook = new Book();
                        newBook.PublishedYear = int.Parse(reader["published_year"].ToString());
                        newBook.Name = reader["name"].ToString();

                        books.Add(newBook);
                    }

                    return Ok(books);
                }
            }
        }


        [HttpPut]
        public IActionResult Put([FromBody] Book book)
        {
            if (book.Id.HasValue)
            {
                //Изменение существующей записи
                ExecuteSqlCommand($"UPDATE books SET name='{book.Name}', published_year={book.PublishedYear} WHERE id={book.Id}");
                return Ok();
            }
            else
            {
                //Добавление записи
                ExecuteSqlCommand($"INSERT INTO books (name, published_year) VALUES ('{book.Name}', {book.PublishedYear})");
                return StatusCode(201);
            }
        }

        protected void ExecuteSqlCommand(string commandText)
        {
            using (SqlConnection connection = new SqlConnection("Server=zorin;database=Books;Trusted_Connection=True;"))
            {
                connection.Open();                
                using (var command = new SqlCommand(commandText, connection))
                {
                    var s = command.CommandText;
                    var reader = command.ExecuteNonQuery();
                }
            }
        }
    }
}
