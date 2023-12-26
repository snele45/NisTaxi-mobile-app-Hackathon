using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using WebApplication1.Entities;

namespace WebApplication1.Authentication
{
	public sealed class JwtProvider : IJwtProvider
	{
		public string Generate(Driver user)
		{
			var claims = new Claim[]
			{
				new (JwtRegisteredClaimNames.Sub, user.Id.ToString()),
				new (ClaimTypes.MobilePhone, user.PhoneNumber),
				new (ClaimTypes.GivenName, user.DriverName),
				new ("Id", user.Id.ToString())
			};

			var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("SuperSecretKey12345"));
			var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

			var token = new JwtSecurityToken(
				"Naftna Industrija Srbije",
				"Naftna Industrija Srbije",
				claims,
				expires: DateTime.Now.AddHours(30),
				signingCredentials: credentials);

			return new JwtSecurityTokenHandler().WriteToken(token);
		}
	}
}
