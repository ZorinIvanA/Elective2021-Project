using System;
using System.Linq;
using WebApplication1.Domain;

namespace WebApplication1.Infrastructure
{
    public class BooksEFRepository : IBooksRepository
    {
        public void Delete(int bookId)
        {
            using (var context = new BooksContext())
            {
                context.Books.Remove(context.Books.FirstOrDefault(x => x.Id == bookId));
            }
        }

        public Book GetBookById(int bookId)
        {
            Book book;
            using (var context = new BooksContext())
            {
                var bookDto = context.Books.FirstOrDefault(x => x.Id == bookId);
                book = new Book
                {
                    Id = bookDto.Id,
                    Name = bookDto.Name,
                    PublishedYear = bookDto.PublishedYear.Value
                };
            }
            return book;
        }

        public Book[] GetBooks()
        {
            var books = new Book[] { };
            using (var context = new BooksContext())
            {
                books = (from bookDto in context.Books
                         select new Book
                         {
                             Id = bookDto.Id,
                             Name = bookDto.Name,
                             PublishedYear = bookDto.PublishedYear.Value
                         }).ToArray();
            }
            return books;
        }

        public void Insert(Book book)
        {
            using (var context = new BooksContext())
            {
                context.Books.Add(new BookDTO
                {
                    Id = 0,
                    Name = book.Name,
                    PublishedYear = (short)book.PublishedYear
                });
                context.SaveChanges();
            }
        }

        public void SaveBookRead(int book, string user)
        {
            using (var context = new BooksContext())
            {
                context.BooksReads.Add(new BooksRead
                {
                    Id = Guid.NewGuid(),
                    BookId = book,
                    Reader = user
                });
                context.SaveChanges();
            }
        }

        public void Update(Book book)
        {
            using (var context = new BooksContext())
            {
                var bookToEdit = context.Books.FirstOrDefault(x => x.Id == book.Id);
                bookToEdit.Id = book.Id.Value;
                bookToEdit.Name = book.Name;
                bookToEdit.PublishedYear = (short)book.PublishedYear;

                context.SaveChanges();
            }
        }
    }
}
