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
            using (SqlConnection connection = new SqlConnection("Server=zorin;database=Books;Trusted_Connection=True;"))
            {
                connection.Open();
                if (book.Id.HasValue)
                {
                    //Изменение существующей записи
                    using (var command = new SqlCommand($"UPDATE books SET name='{book.Name}', published_year={book.PublishedYear} WHERE id={book.Id}", connection))
                    {
                        var s = command.CommandText;
                        var reader = command.ExecuteNonQuery();
                        return Ok();
                    }
                }
                else
                {
                    //Добавление новой записи
                    using (var command = new SqlCommand($"INSERT INTO books (name, published_year) VALUES ('{book.Name}', {book.PublishedYear})", connection))
                    {
                        var s = command.CommandText;
                        var reader = command.ExecuteNonQuery();

                        return StatusCode(201);
                    }
                }
            }
        }
    }
}
