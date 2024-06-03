using Application.Interfaces;
using Application.Interfaces.Utilities;
using Application.Requests.Auth;
using Domain.Models;
using Domain.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Application.Utilities
{
    public class AuthService : IAuthService
    {
        private readonly IConfiguration _configuration;
        private readonly IUserService _userService;


        public AuthService(IConfiguration configuration, IUserService userService)
        {
            _configuration = configuration;
            _userService = userService;
        }

        public string AuthenticateAdmin(AuthenticateRequest request)
        {
            return Authenticate(request, 1).Item1;
        }
        public string AuthenticateCliente(AuthenticateRequest request)
        {
            return Authenticate(request, 2).Item1; 
        }
        public string AuthenticateAlumno(AuthenticateRequest request)
        {
            return Authenticate(request, 3).Item1;
        }

        public bool ValidateAuthenticate(string token, int userId)
        {
            var tokenHandler = new JwtSecurityTokenHandler();

            var parameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidIssuer = _configuration.GetSection("JWT")["Issuer"],
                ValidateAudience = true,
                ValidAudience = _configuration.GetSection("JWT")["Audience"],
                ValidateIssuerSigningKey = true,
                ValidateLifetime = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetSection("JWT")["SigningKey"]!)),
                ClockSkew = TimeSpan.Zero
            };

            var principal = tokenHandler.ValidateToken(token, parameters, out _);
            var usereName = principal.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Name);
            var userRoles = principal.Claims.Where(x => x.Type == ClaimTypes.Role).Select(x => x.Value).ToList();

            var user = _userService.GetUserByUserName(usereName!.Value);
            if (user == null || user.TipoUsuario.TipoUsuarioId != userId || !userRoles.Exists(x => x.ToString() == user.TipoUsuario.TipoUsuario))
            {
                return false;
            }
            return true;
        }

        public (string,int) Authenticate(AuthenticateRequest request, int? roleId = null)
        {
            var usereName = RutUtils.CleanUserRut(request.username);
            var user = _userService.GetUserByUserName(usereName);
            if (user == null)
            {
                throw new ValidationException("Credenciales de acceso invalidos");
            }
            var HashPassword = HashUtils.GetHashFirst(request.password);
            if (user.Contrasenia != HashPassword)
            {
                throw new ValidationException("Credenciales de acceso invalidos");
            }
            if (roleId != null && user.TipoUsuarioId != roleId)
            {
                throw new ValidationException("Sin Autorización");
            }

            var newToken = GenetateJWT(user.Usuario, user.UsuarioId.ToString(), user.TipoUsuario.TipoUsuario.ToString());

            return (newToken, user.TipoUsuarioId);
        }

        public bool IsAuthenticated()
        {
            throw new NotImplementedException();
        }
        private string GenetateJWT(string username, string userId, string rolName)
        {
            var _key = _configuration.GetSection("JWT")["SigningKey"]!;
            var issuer = _configuration.GetSection("JWT")["Issuer"]!;
            var audience = _configuration.GetSection("JWT")["Audience"]!;

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_key));
            var signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var _claims = new List<Claim>
            {
                new(JwtRegisteredClaimNames.Sub,username),
                new(JwtRegisteredClaimNames.Jti,userId),
                new(ClaimTypes.Name, username),
                new(ClaimTypes.Role, rolName),
            };

            var securityToken = new JwtSecurityToken(
                issuer: issuer,
                audience: audience,
                claims: _claims,
                expires: DateTime.Now.AddMinutes(120),
                signingCredentials: signingCredentials
            );

            return new JwtSecurityTokenHandler().WriteToken(securityToken);
        }

    }
}
