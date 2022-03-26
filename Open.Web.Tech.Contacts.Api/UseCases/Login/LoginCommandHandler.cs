using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Open.Web.Tech.Contacts.Api.Data;
using Open.Web.Tech.Contacts.Api.Data.Models;
using Open.Web.Tech.Contacts.Api.Interfaces.Commands;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Open.Web.Tech.Contacts.Api.UseCases.Login
{
    /// <summary>
    /// LoginCommandHandler
    /// </summary>
    public class LoginCommandHandler : IRequestHandler<LoginCommand, string>
    {
        private IConfiguration _config;

        private readonly ApiContext _context;

        /// <summary>
        /// Constructor : login
        /// </summary>
        /// <param name="config">config</param>
        /// <param name="context">context</param>
        public LoginCommandHandler(ApiContext context, IConfiguration config)
        {
            _config = config;
            _context = context;
        }

        /// <summary>
        /// IRequestHandler{TRequest,TResponse}.Handle(TRequest, CancellationToken)
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        public Task<string> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request));
            }
            return HandleAsync(request);
        }

        private async Task<string> HandleAsync(LoginCommand request)
        {
            var user = await AuthenticateAsync(request);

            if (user != null)
            {
                var token = Generate(user);
                return token;
            }

            return string.Empty;
        }

        private string Generate(User user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.UserName),
                new Claim(ClaimTypes.Email, user.EmailAddress),
                new Claim(ClaimTypes.Role, user.Role),
                new Claim(ClaimTypes.Actor, user.ContactUid.ToString())
            };

            var token = new JwtSecurityToken(_config["Jwt:Issuer"],
              _config["Jwt:Audience"],
              claims,
              expires: DateTime.Now.AddMinutes(15),
              signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        private async Task<User> AuthenticateAsync(LoginCommand userLogin)
        {
            var currentUser = await _context.Users
                .FirstOrDefaultAsync(o => o.UserName.ToLower() == userLogin.UserName.ToLower() && o.Password == userLogin.Password);

            if (currentUser != null)
            {
                return currentUser;
            }

            return null;
        }

    }
}
