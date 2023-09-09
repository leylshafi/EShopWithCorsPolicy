using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using EShop.Application.Abstractions;
using EShop.Application.ViewModels;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace EShop.Infrastructure.Concretes
{
	public class JwtGenerator : IJwtGenerator
	{
		private readonly IConfigurationBuilder builder;
		public JwtGenerator(IConfigurationBuilder configurationBuilder)
		{
			builder = configurationBuilder;
		}

		public string CreateToken(CustomerDto customerDto)
		{
			List<Claim> claims = new List<Claim>()
			{
				new Claim(ClaimTypes.Name,customerDto.Name)
			};
			builder.SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../../Presentation/EShop.API"))
				.AddJsonFile("appsettings.json");
			var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Build()["Token"]));
			var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
			var token = new JwtSecurityToken(
				claims: claims,
				expires: DateTime.Now.AddDays(1),
				signingCredentials: creds
				);
			var jwt = new JwtSecurityTokenHandler().WriteToken(token);
			return jwt;
		}
	}
}
