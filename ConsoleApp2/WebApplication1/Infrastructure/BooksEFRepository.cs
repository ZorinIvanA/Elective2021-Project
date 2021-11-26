using System;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Domain;

namespace WebApplication1.Infrastructure
{
    public class BooksEFRepository : IBooksRepository
    {
        public Task Delete(int bookId)
        {
            return Task.Run(() =>
            {
                using (var context = new BooksContext())
                {
                    context.Books.Remove(context.Books.FirstOrDefault(x => x.Id == bookId));
                }
            });
        }

        public Task<Book> GetBookById(int bookId)
        {
            return Task.Run(() =>
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
            });
        }

        public Task<Book[]> GetBooks()
        {
            return Task.Run(() =>
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
            });
        }

        public Task Insert(Book book)
        {
            return Task.Run(() =>
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
            });
        }

        public Task SaveBookRead(int book, string user)
        {
            return Task.Run(() =>
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
            });
        }

        public Task Update(Book book)
        {
            return Task.Run(() =>
            {
                using (var context = new BooksContext())
                {
                    var bookToEdit = context.Books.FirstOrDefault(x => x.Id == book.Id);
                    bookToEdit.Id = book.Id.Value;
                    bookToEdit.Name = book.Name;
                    bookToEdit.PublishedYear = (short)book.PublishedYear;

                    context.SaveChanges();
                }
            });
        }
    }
}
