using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Domain
{
    public class BooksFactory : IBookFactory
    {
        IBooksRepository _booksRepository;

        public BooksFactory(IBooksRepository repository)
        {
            _booksRepository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public Task<Book> CreateBookAsync(int id)
        {
            return Task.Run(() =>
            {
                return new Book(id, _booksRepository);
            });
        }
    }
}
