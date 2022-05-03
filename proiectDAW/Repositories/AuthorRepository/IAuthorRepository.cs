using proiectDAW.Models.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace proiectDAW.Repositories
{
    public interface IAuthorRepository : IGenericRepository<Author>
    {
        // metode custom pentru Author
        Task<Author> GetAuthorByLastName(string lastName);
        Task<List<Author>> GetAllAuthorsWithEditor();
        Task<Author> GetAuthorByIdWithBooks(int id);
        Task<Author> UpdateAuthorLastName(int id, string newLastName);
    }
}
