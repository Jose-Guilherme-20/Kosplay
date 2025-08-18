using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using Azure;
using Kosplay.API.Vmodels.Auth;
using Kosplay.Domain.Interfaces.Services;
using Kosplay.Domain.Models.Entity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace Kosplay.API.Servicos
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<UserEntity> _userManager;
        private readonly RoleManager<IdentityRole<int>> _roleManager;
        private readonly IConfiguration _configuration;

        public AuthService(UserManager<UserEntity> userManager, RoleManager<IdentityRole<int>> roleManager, IConfiguration configuration)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _configuration = configuration;
        }

        public async Task<ResponseRegisterUserViewModel?> RegisterAsync(RequestRegisterUserViewModel request)
        {
            var userExists = await _userManager.FindByNameAsync(request.Username);

            if (userExists != null)
            {
                return null;
            }

            UserEntity user = new()
            {
                Email = request.Email,
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = request.Username
            };
            var result = await _userManager.CreateAsync(user, request.Password);

            if (!result.Succeeded)
            {
                return null;
            }

            return new ResponseRegisterUserViewModel { Id =  user.Id};
        }

        public async Task<ResponseAuthViewModel> LoginAsync(RequestAuthViewModel request)
        {
            var user = await _userManager.FindByEmailAsync(request.Email);
            if (user == null || !await _userManager.CheckPasswordAsync(user, request.Password))
            {
                throw new UnauthorizedAccessException("Invalid email or password.");
            }
            
            var roles = await _userManager.GetRolesAsync(user);

            var authClaims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Email, user.Email),
            };

            foreach (var role in roles)
            {
                authClaims.Add(new Claim(ClaimTypes.Role, role));
            }

            var token = CreateToken(authClaims);
            var refreshToken = GenerateRefreshToken();

            _ = int.TryParse(_configuration["JWT:RefreshTokenValidityInMinutes"],
                   out int refreshTokenValidityInMinutes);

            user.RefreshToken = refreshToken;
            user.RefreshTokenExpiryTime = DateTime.Now.AddMinutes(refreshTokenValidityInMinutes);

            await _userManager.UpdateAsync(user);

            return new ResponseAuthViewModel
            {
                Token = new JwtSecurityTokenHandler().WriteToken(token),
                Expiration = token.ValidTo.Minute,
                RefreshToken = refreshToken
            };

        }

        private JwtSecurityToken CreateToken(List<Claim> authClaims)
        {
            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8
                                 .GetBytes(_configuration["JWT:SecretKey"]));
            _ = int.TryParse(_configuration["JWT:TokenValidityInMinutes"], out
                int tokenValidityInMinutes);

            var token = new JwtSecurityToken(
                issuer: _configuration["JWT:ValidIssuer"],
                audience: _configuration["JWT:ValidAudience"],
                expires: DateTime.Now.AddMinutes(tokenValidityInMinutes),
                claims: authClaims,
                signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                );

            return token;
        }

        public async Task<ResponseRefreshTokenViewModel> RefreshTokenAsync(RequestRefreshTokenViewModel request)
        {
            if (request is null)
            {
                return null;
            }

            string? accessToken = request.AccessToken;
            string? refreshToken = request.RefreshToken;

            var principal = GetPrincipalFromExpiredToken(accessToken);
            if (principal == null)
            {
                return null;
            }

            string username = principal.Identity.Name;
            var user = await _userManager.FindByNameAsync(username);

            if (user == null || user.RefreshToken != refreshToken ||
                       user.RefreshTokenExpiryTime <= DateTime.Now)
            {
                return null;
            }

            var newAccessToken = CreateToken(principal.Claims.ToList());
            var newRefreshToken = GenerateRefreshToken();

            user.RefreshToken = newRefreshToken;
            await _userManager.UpdateAsync(user);

            return new ResponseRefreshTokenViewModel
            {
                AccessToken = new JwtSecurityTokenHandler().WriteToken(newAccessToken),
                RefreshToken = newRefreshToken
            };
        }

        private static string GenerateRefreshToken()
        {
            var randomNumber = new byte[64];
            using var rng = RandomNumberGenerator.Create();
            rng.GetBytes(randomNumber);
            return Convert.ToBase64String(randomNumber);
        }

        private ClaimsPrincipal? GetPrincipalFromExpiredToken(string? token)
        {
            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateAudience = false,
                ValidateIssuer = false,
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8
                                   .GetBytes(_configuration["JWT:SecretKey"])),
                ValidateLifetime = false
            };

            var tokenHandler = new JwtSecurityTokenHandler();


            var principal = tokenHandler.ValidateToken(token, tokenValidationParameters,
                            out SecurityToken securityToken);

            if (securityToken is not JwtSecurityToken jwtSecurityToken ||
                      !jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256,
                                     StringComparison.InvariantCultureIgnoreCase))
                throw new SecurityTokenException("Invalid token");

            return principal;
        }
    }
}
