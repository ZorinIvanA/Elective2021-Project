using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Domain
{
    public interface IBooksRepository
    {
        Book[] GetBooks();
        Book GetBookById(int bookId);

        void Insert(Book book);

        void Update(Book book);

        void Delete(int bookId);

        void SaveBookRead(int book, string user);
    }
}
