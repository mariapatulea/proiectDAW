using Microsoft.EntityFrameworkCore;
using proiectDAW.Models;
using proiectDAW.Models.Entities;
using System.Threading.Tasks;

namespace proiectDAW.Repositories
{
    public class SessionTokenRepository : GenericRepository<SessionToken>, ISessionTokenRepository
    {
        public SessionTokenRepository(AppDbContext context) : base(context) { }

        public async Task<SessionToken> GetByJti(string jti)
        {
            return await _context.SessionTokens.FirstOrDefaultAsync(token => token.Jti.Equals(jti));
        }
    }
}
