using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using proiectDAW.Models.Constants;
using proiectDAW.Models.DTOs;
using proiectDAW.Models.Entities;
using proiectDAW.Repositories;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace proiectDAW.Services.UserServices
{
    public class UserService : IUserService
    {
        private readonly UserManager<User> _userManager;
        private readonly IRepositoryWrapper _repositoryWrapper;
        public UserService(UserManager<User> userManager, IRepositoryWrapper repositoryWrapper)
        {
            _userManager = userManager;
            _repositoryWrapper = repositoryWrapper;
        }

        public async Task<string> LoginUser(LoginUserDTO loginUserDTO)
        {
            User user = await _userManager.FindByEmailAsync(loginUserDTO.Email);
            if (user != null)
            {
                user = await _repositoryWrapper.User.GetByIdWithRoles(user.Id);

                List<string> roles = user.UserRoles.Select(userRole => userRole.Role.Name).ToList();

                var newJTI = Guid.NewGuid().ToString();
                var tokenHandler = new JwtSecurityTokenHandler();
                var signInKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("this is my custom secret key for auth"));

                var token = GenerateJwtToken(signInKey, user, roles, tokenHandler, newJTI);

                _repositoryWrapper.SessionToken.Create(new SessionToken(newJTI, user.Id, token.ValidTo));
                await _repositoryWrapper.SaveAsync();

                return tokenHandler.WriteToken(token);
            }
            return "";
        }

        private SecurityToken GenerateJwtToken(SymmetricSecurityKey signinKey, User user, List<string> roles, JwtSecurityTokenHandler tokenHandler, string jti)
        {
            var subject = new ClaimsIdentity(new Claim[]
            {
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Name, user.FirstName + " " + user.LastName),
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.Jti, jti)
            });

            foreach (var role in roles)
            {
                subject.AddClaim(new Claim(ClaimTypes.Role, role));
            }

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = subject,
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = new SigningCredentials(signinKey, SecurityAlgorithms.HmacSha256)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return token;
        }

        public async Task<bool> RegisterUserAsync(RegisterUserDTO registerUserDTO)
        {
            var registerUser = new User();
            registerUser.Email = registerUserDTO.Email;
            registerUser.FirstName = registerUserDTO.FirstName;
            registerUser.LastName = registerUserDTO.LastName;
            registerUser.UserName = registerUserDTO.Email;
            var result = await _userManager.CreateAsync(registerUser, registerUserDTO.Password);

            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(registerUser, UserRoleType.Admin);
                return true;
            }

            return false;
        }
    }
}
