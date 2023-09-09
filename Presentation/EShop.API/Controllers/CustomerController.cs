using EShop.Application.Abstractions;
using EShop.Application.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EShop.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CustomerController : ControllerBase
	{
		private readonly IJwtGenerator _jwtGenerator;

		public CustomerController(IJwtGenerator jwtGenerator)
		{
			_jwtGenerator = jwtGenerator;
		}

		//[HttpPost("login")]
		//public async Task<IActionResult> Login([FromBody] CustomerDto userDto)
		//{
		//	try
		//	{
		//		var token = await loginRegisterService.Login(userDto);
		//		return Ok(token);
		//	}
		//	catch (Exception ex)
		//	{
		//		return BadRequest(ex.Message);
		//	}
		//}

		//[HttpPost("register")]
		//public async Task<IActionResult> Register([FromBody] CustomerDto userDto)
		//{
		//	try
		//	{
		//		if (await loginRegisterService.Register(userDto))
		//			return Ok();
		//		throw new Exception("something went wrong");
		//	}
		//	catch (Exception ex)
		//	{
		//		return BadRequest(ex.Message);
		//	}
		//}
	}
}
