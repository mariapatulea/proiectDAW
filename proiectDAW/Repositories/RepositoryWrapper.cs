using proiectDAW.Models;
using proiectDAW.Models.Entities;
using System.Threading.Tasks;

namespace proiectDAW.Repositories
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private readonly AppDbContext _context;
        private IAuthorRepository _author;

        public RepositoryWrapper(AppDbContext context)
        {
            _context = context;
        }

        public IAuthorRepository Author
        {
            get
            {
                if (_author == null)
                {
                    _author = new AuthorRepository(_context);
                }
                return _author;
            }
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
