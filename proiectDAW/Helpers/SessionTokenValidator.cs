using proiectDAW.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;

namespace proiectDAW.Helpers
{
    public class SessionTokenValidator
    {
        public static async Task ValidateSessionToken(TokenValidatedContext context)
        {
            var repository = context.HttpContext.RequestServices.GetRequiredService<IRepositoryWrapper>();
            if (context.Principal.HasClaim(claim => claim.Type.Equals(JwtRegisteredClaimNames.Jti)))
            {
                var jti = context.Principal.Claims.FirstOrDefault(claim => claim.Type.Equals(JwtRegisteredClaimNames.Jti)).Value;
                var tokenInDb = await repository.SessionToken.GetByJti(jti);

                if (tokenInDb != null && tokenInDb.ExpirationDate > DateTime.Now)
                {
                    return;
                }
            }
            context.Fail("");
        }
    }
}
