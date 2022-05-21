using Microsoft.EntityFrameworkCore;
using proiectDAW.Models;
using proiectDAW.Models.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace proiectDAW.Repositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(AppDbContext context) : base(context) { }

        public async Task<List<User>> GetAllUsers()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<User> GetByIdWithRoles(int id)
        {
            return await _context.Users
                .Include(user => user.UserRoles)
                    .ThenInclude(userRole => userRole.Role)
                .FirstOrDefaultAsync(user => user.Id.Equals(id));
        }

        public async Task<User> GetUserByEmail(string email)
        {
            return await _context.Users.FirstOrDefaultAsync(user => user.Email.Equals(email));
        }
    }
}
