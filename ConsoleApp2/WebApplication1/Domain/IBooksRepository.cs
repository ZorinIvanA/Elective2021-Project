using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Domain
{
    public interface IBooksRepository
    {
        Task<Book[]> GetBooks();
        Task<Book> GetBookById(int bookId);

        Task Insert(Book book);

        Task Update(Book book);

        Task Delete(int bookId);

        Task SaveBookRead(int book, string user);
    }
}
