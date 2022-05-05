using Microsoft.EntityFrameworkCore;
using proiectDAW.Models;
using proiectDAW.Models.Entities;
using System.Linq;
using System.Threading.Tasks;

namespace proiectDAW.Repositories
{
    public class BookRepository : GenericRepository<Book>, IBookRepository
    {
        public BookRepository(AppDbContext context) : base(context) { }

        public async Task<Book> GetBookByIdWithAuthor(int id)
        {
            return await _context.Books.Include(book => book.Author).Where(book => book.Id == id).FirstOrDefaultAsync();
        }

        public async Task<Book> GetBookByTitle(string title)
        {
            return await _context.Books.Where(book => book.Title == title).FirstOrDefaultAsync();
        }

        public async Task<Book> UpdateBookPages(int id, int numberOfPages)
        {
            _context.Books.Where(book => book.Id == id).ToList().ForEach(book => book.NumarPagini = numberOfPages);
            return await _context.Books.Where(book => book.Id == id).FirstOrDefaultAsync();
        }
    }
}
