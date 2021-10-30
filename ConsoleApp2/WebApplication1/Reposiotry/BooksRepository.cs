using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Controllers;

namespace WebApplication1.Reposiotry
{
    public class BooksRepository : IBooksRepository
    {
        public Book[] GetBooks()
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

                    return books.ToArray();
                }
            }
        }

        public Book GetBookById(int bookId)
        {
            using (SqlConnection connection = new SqlConnection("Server=zorin;database=Books;Trusted_Connection=True;"))
            {
                connection.Open();
                using (var command = new SqlCommand($"SELECT * FROM books WHERE id={bookId}", connection))
                {
                    var reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        Book newBook = new Book();
                        newBook.PublishedYear = int.Parse(reader["published_year"].ToString());
                        newBook.Name = reader["name"].ToString();

                        return newBook;
                    }
                    else
                        return null;
                }
            }
        }


        public void Insert(Book book)
        {
            ExecuteSqlCommand($"INSERT INTO books (name, published_year) VALUES ('{book.Name}', {book.PublishedYear})");
        }

        public void Update(Book book)
        {
            ExecuteSqlCommand($"UPDATE books SET name='{book.Name}', published_year={book.PublishedYear} WHERE id={book.Id}");
        }


        public void Delete(int bookId)
        {
            ExecuteSqlCommand($"DELETE FROM books WHERE id={bookId}");
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
