using proiectDAW.Models.Entities;
using System.Threading.Tasks;

namespace proiectDAW.Repositories
{
    public interface IBookRepository : IGenericRepository<Book>
    {
        // metode custom pentru Book
        Task<Book> GetBookByTitle(string title);
        Task<Book> GetBookByIdWithAuthor(int id);
        Task<Book> UpdateBookPages(int id, int numberOfPages);
    }
}
