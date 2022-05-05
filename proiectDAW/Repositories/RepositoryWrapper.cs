using proiectDAW.Models;
using proiectDAW.Models.Entities;
using System.Threading.Tasks;

namespace proiectDAW.Repositories
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private readonly AppDbContext _context;
        private IAuthorRepository _author;
        private IEditorRepository _editor;
        private IBookRepository _book;

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

        public IEditorRepository Editor
        {
            get
            {
                if (_editor == null)
                {
                    _editor = new EditorRepository(_context);
                }
                return _editor;
            }
        }

        public IBookRepository Book
        {
            get
            {
                if (_book == null)
                {
                    _book = new BookRepository(_context);
                }
                return _book;
            }
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
