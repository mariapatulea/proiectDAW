using proiectDAW.Models.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace proiectDAW.Repositories
{
    public interface IUserRepository : IGenericRepository<User>
    {
        Task<List<User>> GetAllUsers();
        Task<User> GetUserByEmail(string email);
        Task<User> GetByIdWithRoles(int id);
    }
}
