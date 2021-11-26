using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebApplication1.Domain
{
    public class Book
    {
        IBooksRepository _booksRepository;

        public Book(int id, IBooksRepository booksRepository)
        {
            _booksRepository = booksRepository;

            var book = _booksRepository.GetBookById(id).Result;
            this.Id = book.Id;
            this.Name = book.Name;
            this.PublishedYear = book.PublishedYear;
        }

        public Book()
        {

        }

        public string Name { get; set; }
        public int PublishedYear { get; set; }
        public int? Id { get; set; }

        public Task Take(string user)
        {
            var book = _booksRepository.GetBookById(Id.Value);
            if (book != null)
                return _booksRepository.SaveBookRead(Id.Value, user);
            else
                throw new KeyNotFoundException();
        }
    }
}
