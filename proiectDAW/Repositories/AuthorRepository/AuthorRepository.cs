using Microsoft.EntityFrameworkCore;
using proiectDAW.Models;
using proiectDAW.Models.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace proiectDAW.Repositories
{
    public class AuthorRepository : GenericRepository<Author>, IAuthorRepository
    {
        public AuthorRepository(AppDbContext context) : base(context) { }

        public async Task<List<Author>> GetAllAuthorsWithEditor()
        {
            return await _context.Authors.Include(author => author.Editor).ToListAsync();
        }

        public async Task<Author> GetAuthorByIdWithBooks(int id)
        {
            return await _context.Authors.Include(author => author.PublishedBooks).Where(author => author.Id == id).FirstOrDefaultAsync();
        }

        public async Task<Author> GetAuthorByLastName(string lastName)
        {
            return await _context.Authors.Where(author => author.LastName == lastName).FirstOrDefaultAsync();
        }

        public async Task<Author> UpdateAuthorLastName(int id, string newLastName)
        {
            _context.Authors.Where(author => author.Id == id).ToList().ForEach(author => author.LastName = newLastName);
            return await _context.Authors.Where(author => author.Id == id).FirstOrDefaultAsync();
        }
    }
}
