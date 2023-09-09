using EShop.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShop.Application.Abstractions
{
	public interface IJwtGenerator
	{
		string CreateToken(CustomerDto customerDto);
	}
}
